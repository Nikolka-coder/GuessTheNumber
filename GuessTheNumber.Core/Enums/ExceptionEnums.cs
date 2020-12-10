namespace GuessTheNumber.Core.Enums
{
    public class ExceptionEnums
    {
        public enum Authentication
        {
            CredentialIncorrent = (int)300,
            EmailAlreadyExist = (int)301,
            ModelIsNotValid = (int)302,
            TokenInvalid = (int)303,
            UserDoesNotExist = (int)304,
            UserHasntCreated = (int)305
        }

        public enum Global
        {
            Base = (int)500
        }

        public enum GameProcess
        {
            AllGamesFinished = (int)306
        }
    }
}