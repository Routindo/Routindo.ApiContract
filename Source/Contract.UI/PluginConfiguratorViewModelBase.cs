using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Routindo.Contract.Arguments;

namespace Routindo.Contract.UI
{
    public abstract class PluginConfiguratorViewModelBase: INotifyPropertyChanged , IComponentConfigurator, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        public ArgumentCollection InstanceArguments { get; set; }

        public event EventHandler ConfigurationChanged;

        public PluginConfiguratorViewModelBase()
        {
            ValidatePropertiesCommand = new RelayCommand(ValidateProperties);
        }

        public abstract void Configure();

        public virtual bool CanConfigure()
        {
            return !this.HasErrors;
        }

        public abstract void SetArguments(ArgumentCollection arguments);

        protected virtual void OnConfigurationChanged()
        {
            ConfigurationChanged?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            OnConfigurationChanged();
        }

        public virtual IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                return null;
            return _errorsByPropertyName.ContainsKey(propertyName) ? _errorsByPropertyName[propertyName] : null;
        }

        public virtual bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected virtual void AddPropertyError(string propertyName, string error)
        {
            if(string.IsNullOrWhiteSpace(propertyName))
                return;
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected virtual void ClearPropertyErrors([CallerMemberName] string propertyName = null)
        {
            if(string.IsNullOrWhiteSpace(propertyName))
                return;

            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        public ICommand ValidatePropertiesCommand { get; private set; }

        protected virtual void ValidateProperties()
        {
            
        }

        #region Validation

        protected virtual void ValidateEmail(string email, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return;
            }

            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!regex.IsMatch(email))
                AddPropertyError(propertyName, "Email must be in format 'username@domain.extension'");
        }

        protected virtual void ValidatePortNumber(string port, [CallerMemberName] string propertyName = null)
        {
            if (int.TryParse(port, out int castedPort))
            {
                ValidatePortNumber(castedPort, propertyName);
            }
        }

        protected virtual void ValidatePortNumber(int port, [CallerMemberName] string propertyName = null)
        {
            Regex regex = new Regex(@"^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$");
            if (port == 0 || !regex.IsMatch(port.ToString()))
                AddPropertyError(propertyName, "Please entry a correct port number");
        }

        protected virtual void ValidateNonNullOrEmptyString(string content, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(content))
                AddPropertyError(propertyName, "This field cannot be empty");
        }

        protected virtual void ValidateNumber(int number, Func<int, bool> func, [CallerMemberName] string propertyName = null)
        {
            if (!func(number))
            {
                AddPropertyError(propertyName, "Please enter a correct value.");
            }
        }

        #endregion
    }
}
