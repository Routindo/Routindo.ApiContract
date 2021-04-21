[CmdletBinding()] 
Param(
	$Clean = "true",
    $Restore = "true",
    $UpdateLibs = "true",
    $Build = "true",
    $Publish = "true",
    $PublishFolder = "",
    $SharedLibsFolder = "",
    $PackFolder = "",
    $Configuration = "Release",
    $Runtime = "win-x64",
    $PreRelease = ""
);

$DeploymentPath = Split-Path $MyInvocation.MyCommand.Path -Parent
$ConfigPath = Join-Path $DeploymentPath "config.xml"
Write-Host "Reading configuration file: " $ConfigPath -ForegroundColor Green
[xml]$xmlConfig = Get-Content -Path $ConfigPath

function Force-Resolve-Path {
    <#
    .SYNOPSIS
        Calls Resolve-Path but works for files that don't exist.
    #>
    param (
        [string] $FileName
    )

    $FileName = Resolve-Path $FileName -ErrorAction SilentlyContinue `
                                       -ErrorVariable _frperror
    if (-not($FileName)) {
        $FileName = $_frperror[0].TargetObject
    }

    return $FileName
}

function Get-Setting($SettingKey) {
    $SettingValue = $xmlConfig.Deployment.Settings.Setting | Where-Object Key -EQ $SettingKey | Select -Unique | % { $_.Value }
    return $SettingValue
}

function Get-Publish-Folder($Directory) {
    # The priority for output path is from arguments
    $Output = ""
    $Output = $PublishFolder
    if($Output -eq "") {
        # If publish folder from arguments is not set, try get the publish folder from the config file
        $Output = Force-Resolve-Path ( Join-Path (Join-Path $DeploymentPath (Get-Setting -SettingKey 'PublishFolder')) $Directory)
    }
    else {
        # Combine publish folder with the Library directory
        $Output = Force-Resolve-Path ( Join-Path $Output $Directory)
    }

    # Create the output folder if doesn't exist
    New-Item -ItemType Directory -Force -Path $Output | Out-Null
    return $Output
}

function Get-SharedLibs-Folder($Directory) {
    # The priority for output path is from arguments
    $Output = $SharedLibsFolder
    if($Output -eq "") {
        # If publish folder from arguments is not set, try get the publish folder from the config file
        $Output = Force-Resolve-Path ( Join-Path (Join-Path $DeploymentPath (Get-Setting -SettingKey 'SharedLibsFolder')) $Directory)
    }
    else {
        # Combine publish folder with the Library directory
        $Output = Force-Resolve-Path ( Join-Path $Output $Directory)
    }

    # Create the output folder if doesn't exist
    New-Item -ItemType Directory -Force -Path $Output | Out-Null
    return $Output
}

function Get-Pack-Folder {
    # The priority for output path is from arguments
    $Output = $PackFolder
    if($Output -eq "") {
        $Output = Force-Resolve-Path (Join-Path $DeploymentPath (Get-Setting -SettingKey 'PackFolder'))
    }

    # Create the output folder if doesn't exist
    New-Item -ItemType Directory -Force -Path $Output | Out-Null
    return $Output
}

function Clean-Project-Output($ProjectPath) {
    dotnet clean $ProjectPath
}

function Restore-Project-Dependencies($ProjectPath) {
    dotnet clean $ProjectPath
}

function Update-SharedLibs() {
    $SharedLibsSourceFolder = Force-Resolve-Path (Join-Path $DeploymentPath (Get-Setting -SettingKey 'SharedLibsFolder'))
    $DependenciesDestinationFolder = Force-Resolve-Path (Join-Path $DeploymentPath (Get-Setting -SettingKey 'DependenciesPath'))
	Write-Host "DependenciesDestinationFolder" $DependenciesDestinationFolder
	Write-Host "SharedLibsSourceFolder" $SharedLibsSourceFolder
    $xmlConfig.Deployment.Dependencies.Dependency | Sort-Object Order | ForEach-Object { 
        $DependencyDirectory = Force-Resolve-Path (Join-Path $SharedLibsSourceFolder $_.Directory)

        if(Test-Path $DependencyDirectory -PathType Container) {
            Get-ChildItem -Path $DependencyDirectory | Copy-Item -Destination $DependenciesDestinationFolder -Recurse
        }
        else {
            Write-Host "Source Folder not found for shared libs:" $DependencyDirectory -ForegroundColor Red
        }
    }
      
}

function Build-Project($ProjectPath) {
    dotnet build $ProjectPath --configuration $Configuration --runtime $Runtime
}

function Get-Version-Suffix($ProjectPath) {
    $commitHash = "c$((git -C (Split-Path $ProjectPath -Parent) rev-parse HEAD).Substring(0,8))";
    if([string]::IsNullOrEmpty($PreRelease)) {
        return $commitHash
    } 
    else {
        return "$($commitHash)+$($PreRelease)"
    }
}

function Execute-Publish-Command ($ProjectPath, $PublishOutput, $SelfContained) {
    $VersionSuffix = Get-Version-Suffix -ProjectPath $ProjectPath
    dotnet publish $ProjectPath --configuration $Configuration --runtime $Runtime /p:DebugType=None /p:DebugSymbols=false /p:CopyLocalLockFileAssemblies=true --version-suffix $VersionSuffix --self-contained $SelfContained --output $PublishOutput | Out-Default
}
function Publish-Project($ProjectPath, $Directory, $SelfContained, $Clean) {
    $PublishOutput = ""
    $PublishOutput = Get-Publish-Folder -Directory $Directory
    if($Clean -eq "true") {
        Get-ChildItem -Path $PublishOutput -Include *.* -Recurse | foreach { $_.Delete()} | Out-Null
    }
    Execute-Publish-Command -PublishOutput $PublishOutput -ProjectPath $ProjectPath -SelfContained $SelfContained | Out-Null
    return $PublishOutput
}

function Share-Library($PublishOutput, $Directory) {
    $SharedLibsDestinationFolder = Get-SharedLibs-Folder -Directory $Directory
    Get-ChildItem -Path $SharedLibsDestinationFolder -Include *.* -Recurse | foreach { $_.Delete() }
    Get-ChildItem -Path $PublishOutput  | Copy-Item -Destination $SharedLibsDestinationFolder -Recurse -Force
}

function Pack($PublishOutput, $Name) {
    $PackFolder = Get-Pack-Folder
    $LibraryPath = Resolve-Path (Join-Path $PublishOutput ($Name + ".dll"))
    $LibraryVersion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($LibraryPath).ProductVersion
    $packFileName = $Name + "-" + $LibraryVersion + ".zip"
    Compress-Archive -Force -Path $([IO.Path]::Combine($PublishOutput, "*.*")) -DestinationPath $([IO.Path]::Combine($PackFolder, $packFileName))
}

$SourceAbsolutPath = Resolve-Path (Join-Path $DeploymentPath (Get-Setting -SettingKey 'SourcePath'))

Write-Host "Source Absolut Path:" $SourceAbsolutPath


if($UpdateLibs -eq 'true') {
        Write-Host "Updating Shared Libs:" $_.Name
        Update-SharedLibs
}

Write-Host "Deploying libraries"

$xmlConfig.Deployment.Projects.Project | Sort-Object Order | ForEach-Object {

    $ProjectAbsolutPath = ""
    $ProjectAbsolutPath = Join-Path (Join-Path $SourceAbsolutPath $_.Directory) $_.File
    if($Clean -eq 'true') {
        Write-Host "Cleaning Project Output:" $_.Name
        Clean-Project-Output -ProjectPath $ProjectAbsolutPath
    }

    if($Restore -eq 'true') {
        Write-Host "Restoring Project Dependencies:" $_.Name
        Restore-Project-Dependencies -ProjectPath $ProjectAbsolutPath
    }

    if($Build -eq 'true') {
        Write-Host "Building Project:" $_.Name
        Build-Project -ProjectPath $ProjectAbsolutPath
    }

    if($Publish -eq 'true') {
        Write-Host "Publishing Project:" $_.Name
        $DeploymentDir = $_.DeploymentDir
        if([string]::IsNullOrEmpty($DeploymentDir)) {
            $DeploymentDir = $_.Directory
        }
        $commitHash = (git -C (Split-Path $ProjectAbsolutPath -Parent) rev-parse HEAD).Substring(0,9);
        Write-Host "Suffix: " $commitHash
        $PublishOutputFolder = Publish-Project -ProjectPath $ProjectAbsolutPath -Directory $DeploymentDir -SelfContained $_.SelfContained -Clean $_.CleanDeploymentDir

        if($_.Share -eq 'true') {
            Write-Host "Sharing Library:" $_.Name
            Share-Library -PublishOutput $PublishOutputFolder -Directory $DeploymentDir
        }

        if($_.Pack -eq 'true') {
            Write-Host "Packing Library:" $_.Name
            Pack -PublishOutput $PublishOutputFolder -Name $_.Name
        }
    }
}


