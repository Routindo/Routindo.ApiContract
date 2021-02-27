﻿namespace Umator.Contract
{
    public interface IAction : IRuntimeComponent
    {
        /// <summary>
        ///     Executes the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        ActionResult Execute(ArgumentCollection arguments);
    }
}