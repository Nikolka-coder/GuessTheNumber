namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.ErrorMessages;

    public class GuessTheNumberAllGamesAlreadyFinishedException : GuessTheNumberException
    {
        public GuessTheNumberAllGamesAlreadyFinishedException()
            : base(ErrorMessages.GuessTheNumberAllGamesAlreadyFinished)
        {
        }

        public GuessTheNumberAllGamesAlreadyFinishedException(string message)
            : base(message)
        {
        }

        public GuessTheNumberAllGamesAlreadyFinishedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberAllGamesAlreadyFinishedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.GameProcess.AllGamesFinished;
    }
}