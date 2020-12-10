namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.ErrorMessages;

    public class GuessTheNumberTokenInvalidException : GuessTheNumberException
    {
        public GuessTheNumberTokenInvalidException()
            : base(ErrorMessages.GuessTheNumberTokenInvalid)
        {
        }

        public GuessTheNumberTokenInvalidException(string message)
            : base(message)
        {
        }

        public GuessTheNumberTokenInvalidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberTokenInvalidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.TokenInvalid;
    }
}