namespace Montech.Communication.Responses.Usuario;

public class ResponseUsuarioRegistradoJson
{
    public string Nome { get; set; } = string.Empty;
    public ResponseTokensJson Tokens { get; set; } = default!;
}
