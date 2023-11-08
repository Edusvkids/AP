namespace HGAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
