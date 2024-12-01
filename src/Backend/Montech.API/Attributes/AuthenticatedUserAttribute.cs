using Microsoft.AspNetCore.Mvc;
using Montech.API.Filters;

namespace Montech.API.Attributes;

public class AuthenticatedUserAttribute : TypeFilterAttribute
{
    public AuthenticatedUserAttribute() : base(typeof(AuthenticatedUserFilter))
    {

    }
}
