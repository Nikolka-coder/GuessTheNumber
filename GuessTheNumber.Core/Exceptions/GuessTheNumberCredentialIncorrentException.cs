namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.ErrorMessages;

    public class GuessTheNumberCredentialIncorrentException : GuessTheNumberException
    {
        public GuessTheNumberCredentialIncorrentException()
            : base(ErrorMessages.GuessTheNumberCredentialIncorrent)
        {
        }

        public GuessTheNumberCredentialIncorrentException(string message)
            : base(message)
        {
        }

        public GuessTheNumberCredentialIncorrentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberCredentialIncorrentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.CredentialIncorrent;
    }
}