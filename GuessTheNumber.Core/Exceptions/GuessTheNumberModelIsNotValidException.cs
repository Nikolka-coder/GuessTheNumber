namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.ErrorMessages;

    public class GuessTheNumberModelIsNotValidException : GuessTheNumberException
    {
        public GuessTheNumberModelIsNotValidException()
            : base(ErrorMessages.GuessTheNumberModelIsNotValid)
        {
        }

        public GuessTheNumberModelIsNotValidException(string message)
            : base(message)
        {
        }

        public GuessTheNumberModelIsNotValidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberModelIsNotValidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.ModelIsNotValid;
    }
}