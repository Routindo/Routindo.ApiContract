﻿using System;

namespace Umator.Contract.UI
{
    public interface IComponentConfigurator
    {
        ArgumentCollection InstanceArguments { get; set; }

        event EventHandler ConfigurationChanged; 

        void Configure();

        bool CanConfigure();

        void SetArguments(ArgumentCollection arguments);
    }
}
 