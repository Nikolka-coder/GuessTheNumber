namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.ErrorMessages;

    public class GuessTheNumberHasntCreatedException : GuessTheNumberException
    {
        public GuessTheNumberHasntCreatedException()
            : base(ErrorMessages.GuessTheNumberHasntCreated)
        {
        }

        public GuessTheNumberHasntCreatedException(string message)
            : base(message)
        {
        }

        public GuessTheNumberHasntCreatedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberHasntCreatedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.UserHasntCreated;
    }
}