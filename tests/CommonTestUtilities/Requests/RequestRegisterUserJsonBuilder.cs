using Bogus;
using Montech.Communication.Requests.Usuario;

namespace CommonTestUtilities.Requests;

public static class RequestRegisterUserJsonBuilder
{
    public static RequestRegistrarUsuarioJson Build(int passwordLength = 10)
    {
        return new Faker<RequestRegistrarUsuarioJson>()
            .RuleFor(user => user.Nome, (f) => f.Person.FirstName)
            .RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Nome))
            .RuleFor(user => user.Senha, (f) => f.Internet.Password(passwordLength));
    }
}

