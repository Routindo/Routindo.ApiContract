using System;

namespace Umator.Contract
{
    public  static class ActionResultExtensions
    {
        public static ActionResult WithException(this ActionResult actionResult, Exception exception)
        {
            actionResult.AttachedException = exception;
            return actionResult;
        }

        public static ActionResult WithAdditionInformation(this ActionResult actionResult, ArgumentCollection additionInformation)
        {
            actionResult.AdditionalInformation = additionInformation;
            return actionResult;
        }
    }
}
