using Montech.Application.Services.Cryptography;

namespace CommonTestUtilities.Cryptography;

public static class PasswordEncrypterBuilder
{
    public static CriptografiaSenha Build()
    {
        return new CriptografiaSenha("nthk001011");
    }
}
