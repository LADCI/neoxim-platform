using Autodesk.Forge;

namespace Neoxim.Platform.Infrastructure.Externals.Autodesk
{
    public record Token(string AccessToken, DateTime ExpiresAt);
    public partial class APS
    {
        private Token _internalTokenCache;
        private Token _publicTokenCache;

        private async Task<Token> GetTokenAsync(Scope[] scopes)
        {
            dynamic auth = await new TwoLeggedApi().AuthenticateAsync(_clientId, _clientSecret, "client_credentials", scopes);
            return new Token(auth.access_token, DateTime.UtcNow.AddSeconds(auth.expires_in));
        }

        public async Task<Token> GetPublicTokenAsync()
        {
            if(_publicTokenCache == null || _publicTokenCache.ExpiresAt < DateTime.UtcNow)
            {
                _publicTokenCache = await GetTokenAsync(new Scope[]{ Scope.ViewablesRead });
            }
            return _publicTokenCache;
        }

        public async Task<Token> GetInternalToken()
        {
            if(_internalTokenCache == null || _internalTokenCache.ExpiresAt < DateTime.UtcNow)
            {
                _internalTokenCache = await GetTokenAsync(new Scope[]{ Scope.BucketCreate, Scope.BucketRead, Scope.DataRead, Scope.DataWrite, Scope.DataCreate });
            }
            return _internalTokenCache;
        }
    }
}