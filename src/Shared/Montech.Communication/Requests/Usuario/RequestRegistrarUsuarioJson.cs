namespace Montech.Communication.Requests.Usuario;

public class RequestRegistrarUsuarioJson
{
    public string Nome { get; set; } = string.Empty;
    public string CpfOrCnpj { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
