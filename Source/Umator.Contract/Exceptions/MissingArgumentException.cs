using System;

namespace Umator.Contract
{
    public class MissingArgumentException : Exception
    {
        public MissingArgumentException(string key, string message = null) : base(message)
        {
            Key = key;
        }

        public string Key { get; }

        public override string ToString()
        {
            return $"Missing argument : {Key}" + base.ToString();
        }
    }
}