namespace Montech.Exceptions.ExceptionBase;

public class InvalidLoginException : MontechException
{
    public InvalidLoginException() : base(ResourceMessagesExcpetions.EMAIL_OR_PASSWORD_INVALID)
    {
    }
}
