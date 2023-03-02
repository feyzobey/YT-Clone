using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VideoClone.Core.Entities.Concrete;
using VideoClone.Core.Extensions;
using VideoClone.Core.Utilities.Security.Encryption;

namespace VideoClone.Core.Utilities.Security.Jwt;

public class JwtHelper : ITokenHelper
{
    private readonly DateTime _accessTokenExpiration;
    private readonly TokenOptions _tokenOptions;

    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;

        var tokenOptionsSection = Configuration.GetSection("TokenOptions");
        _tokenOptions = new TokenOptions();
        tokenOptionsSection.Bind(_tokenOptions);
        _tokenOptions.Issuer = tokenOptionsSection["Issuer"];
        _tokenOptions.Audience = tokenOptionsSection["Audience"];
        _tokenOptions.SecurityKey = tokenOptionsSection["SecurityKey"];
        _tokenOptions.AccessTokenExpiration = int.Parse(tokenOptionsSection["AccessTokenExpiration"]);

        _accessTokenExpiration = DateTime.Now.AddHours(_tokenOptions.AccessTokenExpiration);
    }

    private IConfiguration Configuration { get; }

    public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
    {
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };
    }

    private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
        SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
    {
        var jwt = new JwtSecurityToken(
            tokenOptions.Issuer,
            tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(user, operationClaims),
            signingCredentials: signingCredentials
        );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddName($"{user.FirstName} ${user.LastName}");
        claims.AddEmail(user.Email);
        claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
        return claims;
    }
}