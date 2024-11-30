namespace Montech.Exceptions.ExceptionBase;

public class ErrorOnValidationException : MontechException
{
    public IList<string> ErrorMessages { get; set; }

    public ErrorOnValidationException(IList<string> errorsMessages) : base(string.Empty)
    {
        ErrorMessages = errorsMessages;
    }
}
