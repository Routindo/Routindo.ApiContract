using System;

namespace Routindo.Contract.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ArgumentAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentAttribute"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        public ArgumentAttribute(string key, bool required = false)
        {
            Key = key;
            Required = required;
        }

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ArgumentAttribute"/> is required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if required; otherwise, <c>false</c>.
        /// </value>
        public bool Required { get; set; }
    }
}