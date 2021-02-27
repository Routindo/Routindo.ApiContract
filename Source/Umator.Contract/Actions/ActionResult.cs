using System;

namespace Umator.Contract
{
    public class ActionResult
    {
        public static ActionResult Failed()
        {
            return new ActionResult(false);
        }

        public static ActionResult Succeeded()
        {
            return new ActionResult(true);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActionResult" /> class.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="exception">The exception.</param>
        public ActionResult(bool result, Exception exception) : this(result, exception, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActionResult" /> class.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="additionalInformation">The additional information.</param>
        public ActionResult(bool result, ArgumentCollection additionalInformation) : this(result, null,
            additionalInformation)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActionResult" /> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="additionalInformation">The additional information.</param>
        public ActionResult(Exception exception, ArgumentCollection additionalInformation) : this(false, exception,
            additionalInformation)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActionResult" /> class.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="exception">The exception.</param>
        /// <param name="additionalInformation">The additional information.</param>
        public ActionResult(bool result, Exception exception = null, ArgumentCollection additionalInformation = null)
        {
            Result = result;
            AttachedException = exception;
            AdditionalInformation = additionalInformation;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ActionResult" /> is result.
        /// </summary>
        /// <value>
        ///     <c>true</c> if result; otherwise, <c>false</c>.
        /// </value>
        public bool Result { get; set; }

        /// <summary>
        ///     Gets or sets the attached exception.
        /// </summary>
        /// <value>
        ///     The attached exception.
        /// </value>
        public Exception AttachedException { get; set; }

        /// <summary>
        ///     Gets or sets the addition information.
        /// </summary>
        /// <value>
        ///     The addition information.
        /// </value>
        public ArgumentCollection AdditionalInformation { get; set; }
    }
}