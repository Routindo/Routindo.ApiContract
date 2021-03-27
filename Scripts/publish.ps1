[CmdletBinding()] 
Param(
	$AppName = "Routindo",
    $ProjectName = "Contract",
    $UpdateLibs = "true",
    $Clean = "true",
    $Restore = "true",
    $Build = "true",
    $Publish = "true",
	$Pack = "true",
	$DeploymentPath = "..\..\_DEPLOYMENT",
    $Share = "true",
	$SharePath = "..\..\Libs\Shared"
);

$clean_publish = 1;

$separator = "\";
$SourceFolder = "..\" + $separator + "Source";
$configuration = "Release";
$runtime = "win-x64";


clear
$projects = @{}
$projects.Add(1, $ProjectName)
$projects.Add(2, $ProjectName + '.UI')
# $projects.Add(3,'Routindo.' +  $ProjectName + '.Components')

$output = $DeploymentPath + $separator + $ProjectName; # $SourceFolder + $separator + $projects[1] + $separator + "bin" + $separator + $configuration + $separator + "Publish" + $separator + $runtime;

if($Clean -eq "true") {
    # Restore dependencies 
    $projects.GETENUMERATOR() |  Sort-Object KEY  | % { 
        "Cleaning " + $_.KEY.ToString() + " - " + $_.VALUE
        $clean_command = "dotnet clean" + " " + $SourceFolder + $separator + $_.VALUE + $separator + $AppName + "." + $_.VALUE + ".csproj"
        iex $clean_command
    }
}

if($Restore -eq "true") {
    # Restore dependencies 
    $projects.GETENUMERATOR() |  Sort-Object KEY  | % { 
        "Restoring " + $_.KEY.ToString() + " - " + $_.VALUE
        $restore_command = "dotnet restore" + " " + $SourceFolder + $separator + $_.VALUE + $separator +  $AppName + "." + $_.VALUE + ".csproj"
        iex $restore_command
    }
}

if($Build -eq "true") {
    # No reference to update from shared libs
}

if($Build -eq "true") {
    # Build projects 
    $projects.GETENUMERATOR() |  Sort-Object KEY  | % { 
        "Building " + $_.KEY.ToString() + " - " + $_.VALUE
        $build_command = "dotnet build" + " " + $SourceFolder + $separator + $_.VALUE + $separator +  $AppName + "." + $_.VALUE + ".csproj"
        iex $build_command
    }
}

if($Publish -eq "true") { 
    if($clean_publish -eq 1) {
        Get-ChildItem $output -Recurse | Remove-Item -Recurse
    }
    # Publish projects
    $projects.GETENUMERATOR() |  Sort-Object KEY  | % { 
        "Publishing " + $_.KEY.ToString() + " - " + $_.VALUE
        $publish_command = "dotnet publish" + " " + $SourceFolder + $separator + $_.VALUE + $separator + $AppName + "." +  $_.VALUE + ".csproj" + " " + "--configuration " + $configuration + " --runtime " + $runtime + " /p:DebugType=None /p:DebugSymbols=false /p:CopyLocalLockFileAssemblies=true" + " --output " + $output 
        iex $publish_command
    }
}

if($Pack -eq "true") {
    Write-Host "Packing a new version" 
    $contractLibrary = Resolve-Path $([IO.Path]::Combine($output, $AppName + "." + $ProjectName + ".dll"))
    $contractVersion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($contractLibrary).ProductVersion
    Write-Host "Target version:" + $contractVersion
    $packFileName = $AppName + "." + $ProjectName + "-" + $contractVersion + ".zip"
    Compress-Archive -Update -Path $([IO.Path]::Combine($output, "*.*")) -DestinationPath $([IO.Path]::Combine($DeploymentPath, $packFileName))
}


if($Share -eq "true") {
    Write-Host "Sharing to Libs" 
	$ProjectSharePath = Join-Path -Path $SharePath -ChildPath $ProjectName
    Write-Host "Folder Share Path: " + $ProjectSharePath 
	New-Item -ItemType Directory -Force -Path $ProjectSharePath
	Get-ChildItem -Path $ProjectSharePath -Include *.* -Recurse | foreach { $_.Delete()}
    Get-ChildItem -Path $output  | Copy-Item -Destination $ProjectSharePath -Recurse 
}