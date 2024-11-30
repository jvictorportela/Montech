namespace Montech.Communication.Responses;

public class ResponseErrorJson
{
    public IList<string> ErrorsMessage { get; set; }


    public ResponseErrorJson(IList<string> errorsMessage)
    {
        ErrorsMessage = errorsMessage;
    }

    public ResponseErrorJson(string error)
    {
        ErrorsMessage = new List<string>
        {
            error
        };
    }
}
