using System;
using System.Collections.Generic;
using System.Linq;

namespace Routindo.Contract.Arguments
{
    public class ArgumentCollection : List<Argument>
    {
        public static ArgumentCollection New()
        {
            return new ArgumentCollection();
        }

        protected ArgumentCollection()
        {
        }

        public ArgumentCollection(params (string key, object value)[] args)
        {
            Set(args);
        }

        public ArgumentCollection(ArgumentCollection argumentCollection)
        {
            AddRange(argumentCollection);
        }

        public object this[string name]
        {
            get => this.Single(e => e.Key == name).Value;
            private set
            {
                if (this.All(e => e.Key != name))
                    Add(new Argument(name, value));
                else
                    this.Single(e => e.Key == name).Value = value;
            }
        }

        public static ArgumentCollection FromDictionary(Dictionary<string, object> dictionary)
        {
            var args = new ArgumentCollection();
            args.Set(dictionary);

            return args;
        }

        private void Set(Dictionary<string, object> dictionary)
        {
            Clear();
            AddRange(dictionary.Select(e => new Argument(e.Key, e.Value)));
        }

        /// <summary>
        ///     Sets the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void Set(params (string key, object value)[] args)
        {
            foreach (var (key, value) in args) this[key] = value;
        }

        public void Add(string key, object value)
        {
            this[key] = value;
        }

        public bool HasArgument(string name)
        {
            return this.Any(e => e.Key == name); //&& this.SingleOrDefault(e => e.Key == name)?.Value != null;
        }

        public string ContentString()
        {
            return $"[{string.Join(";", this.Select(e => $"({e.Key}|{e.Value})").ToArray())}]";
        }

        public string ContentValuesString()
        {
            return $"[{string.Join(";", this.Select(e => $"({e.Value})").ToArray())}]";
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The casted type
        /// </returns>
        /// <exception cref="FormatException">If the Type of 'T' is not expected</exception>
        public T GetValue<T>(string key)
        {
            if (!this.HasArgument(key))
                return default;

            var value = this[key];

            if (value == null)
                return default;

            Type targetType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            var convertedArgument = Convert.ChangeType(value, targetType);

            return (T) convertedArgument;
        }
    }
}