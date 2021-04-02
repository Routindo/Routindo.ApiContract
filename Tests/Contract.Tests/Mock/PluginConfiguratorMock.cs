using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Routindo.Contract.Arguments;
using Routindo.Contract.UI;

namespace Routindo.Contract.Tests.Mock
{
    class PluginConfiguratorMock: PluginConfiguratorViewModelBase
    {
        private string _emailProperty;
        private int _numberProperty;
        private int _negativeNumberProperty;
        private int _positiveNumberProperty;
        private int _zeroNumberProperty;
        private int _nonClearedErrorsProperty;
        private string _nonNullOrEmptyStringProperty;
        private int _portNumber;

        public string EmailProperty
        {
            get => _emailProperty;
            set
            {
                ClearPropertyErrors();
                _emailProperty = value;
                ValidateEmail(value);
            }
        }

        public int NumberProperty
        {
            get => _numberProperty;
            set
            {
                ClearPropertyErrors();
                _numberProperty = value;
                ValidateNumber(value, i => true);
            }
        }

        public int NegativeNumberProperty
        {
            get => _negativeNumberProperty;
            set
            {
                ClearPropertyErrors();
                _negativeNumberProperty = value;
                ValidateNumber(value, i => i<0);
            }
        }

        public int PositiveNumberProperty
        {
            get => _positiveNumberProperty;
            set
            {
                ClearPropertyErrors();
                _positiveNumberProperty = value;
                ValidateNumber(value, i => i>0);
            }
        }

        public int ZeroNumberProperty
        {
            get => _zeroNumberProperty;
            set
            {
                ClearPropertyErrors();
                _zeroNumberProperty = value;
                ValidateNumber(value, i => i == 0);
            }
        }

        public int NonClearedErrorsPositiveProperty
        {
            get => _nonClearedErrorsProperty;
            set
            {
                _nonClearedErrorsProperty = value;
                ValidateNumber(value, i => i>0);
            }
        }

        public string NonNullOrEmptyStringProperty
        {
            get => _nonNullOrEmptyStringProperty;
            set
            {
                ClearPropertyErrors();
                _nonNullOrEmptyStringProperty = value;
                ValidateNonNullOrEmptyString(value);
            }
        }

        public int PortNumber
        {
            get => _portNumber;
            set
            {
                ClearPropertyErrors();
                _portNumber = value;
                ValidatePortNumber(value);
            }
        }

        public override void Configure()
        {
            throw new NotImplementedException();
        }

        public override void SetArguments(ArgumentCollection arguments)
        {
            throw new NotImplementedException();
        }
    }
}
