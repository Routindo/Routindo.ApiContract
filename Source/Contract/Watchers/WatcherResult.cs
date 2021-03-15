using System;
using Routindo.Contract.Arguments;

namespace Routindo.Contract.Watchers
{
    public class WatcherResult
    {
        public static readonly WatcherResult NotFound;

        public static WatcherResult Succeed(ArgumentCollection argumentCollection)
        {
            return new WatcherResult()
            {
                Result = true,
                WatchingArguments = argumentCollection
            };
        }

        static WatcherResult()
        {
            if (NotFound == null)
                NotFound = new WatcherResult { Result = false };
        }

        public bool Result { get; set; }

        public ArgumentCollection WatchingArguments { get; set; }

        public Exception AttachedException { get; set; }

        public WatcherResult WithArgument(string key, object value)
        {
            if(this.WatchingArguments == null)
                WatchingArguments = new ArgumentCollection();

            WatchingArguments.Add(key, value);

            return this;
        }

        public WatcherResult WithException(Exception exception)
        {
            this.AttachedException = exception;
            return this;
        }
    }
}