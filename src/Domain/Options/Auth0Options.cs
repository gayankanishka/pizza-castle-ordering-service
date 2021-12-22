namespace PizzaCastle.OrderingService.Domain.Options;

public class Auth0Options
{
    public const string Auth0 = "Auth0";

    public string Authority { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}