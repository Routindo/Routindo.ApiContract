using System;
using System.Text;

namespace Routindo.Contract.Exceptions
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Missing argument : {Key}");
            stringBuilder.Append(base.ToString());
            return stringBuilder.ToString();
        }
    }
}