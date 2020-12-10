namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.ErrorMessages;

    public class GuessTheNumberEmailAlreadyExistException : GuessTheNumberException
    {
        public GuessTheNumberEmailAlreadyExistException()
            : base(ErrorMessages.GuessTheNumberEmailAlreadyExist)
        {
        }

        public GuessTheNumberEmailAlreadyExistException(string message)
            : base(message)
        {
        }

        public GuessTheNumberEmailAlreadyExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberEmailAlreadyExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.EmailAlreadyExist;
    }
}