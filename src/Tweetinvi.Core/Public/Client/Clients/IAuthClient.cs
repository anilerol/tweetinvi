using System;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Tweetinvi.Client
{
    public interface IAuthClient
    {
        /// <inheritdoc cref="CreateBearerToken(ICreateBearerTokenParameters)"/>
        Task<string> CreateBearerToken();

        /// <summary>
        /// Allows a registered application to obtain an OAuth 2 Bearer Token.
        /// Bearer token allows to make API requests on an application's own behalf, without a user context.
        /// This is called Application-only authentication.
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/token </para>
        /// <returns>The bearer token to use for application only authentication</returns>
        Task<string> CreateBearerToken(ICreateBearerTokenParameters parameters);

        /// <summary>
        /// Gets the bearer token generated by <see cref="CreateBearerToken()"/> and updates the client's current credentials.
        /// To learn more about bearer token read <see cref="CreateBearerToken()"/>.
        /// </summary>
        /// <para>
        /// IMPORTANT NOTE: The setter is for convenience. It is strongly recommended to create a new TwitterClient instead.
        /// As using this setter could result in unexpected concurrency between the time of set and the execution of previous
        /// non awaited async operations.
        /// </para>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/token </para>
        Task InitializeClientBearerToken();

        /// <summary>
        /// Initiates a pin based authentication process for a user.
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/request_token </para>
        /// <returns>An AuthenticationRequest containing the url to redirect the user</returns>
        Task<IAuthenticationRequest> RequestAuthenticationUrl();

        /// <inheritdoc cref="RequestAuthenticationUrl(IRequestAuthUrlParameters)" />
        Task<IAuthenticationRequest> RequestAuthenticationUrl(string callbackUrl);

        /// <inheritdoc cref="RequestAuthenticationUrl(IRequestAuthUrlParameters)" />
        Task<IAuthenticationRequest> RequestAuthenticationUrl(Uri callbackUri);

        /// <summary>
        /// Initiates the authentication process for a user.
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/request_token </para>
        /// <returns>An AuthenticationRequest containing the url to redirect the user</returns>
        Task<IAuthenticationRequest> RequestAuthenticationUrl(IRequestAuthUrlParameters parameters);

        /// <inheritdoc cref="RequestCredentials(IRequestCredentialsParameters)"/>
        Task<ITwitterCredentials> RequestCredentialsFromVerifierCode(string verifierCode, IAuthenticationRequest authenticationRequest);

        /// <summary>
        /// Request credentials with a verifierCode
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/token </para>
        /// <returns>The requested user credentials</returns>
        Task<ITwitterCredentials> RequestCredentials(IRequestCredentialsParameters parameters);

        /// <inheritdoc cref="RequestCredentialsFromCallbackUrl(Uri, IAuthenticationRequest)"/>
        Task<ITwitterCredentials> RequestCredentialsFromCallbackUrl(string callbackUrl, IAuthenticationRequest authenticationRequest);

        /// <summary>
        /// Request credentials from an AuthenticationRequest.
        /// This is assuming that the callback url contains the expected parameter,
        /// and that the AuthenticationTokenProvider has access to the returned token id.
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/token </para>
        /// <returns>The requested user credentials</returns>
        Task<ITwitterCredentials> RequestCredentialsFromCallbackUrl(Uri callbackUri, IAuthenticationRequest authenticationRequest);

        /// <inheritdoc cref="InvalidateBearerToken(IInvalidateBearerTokenParameters)"/>
        Task<InvalidateTokenResponse> InvalidateBearerToken();

        /// <summary>
        /// Invalidates a BearerToken
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/invalidate_bearer_token </para>
        Task<InvalidateTokenResponse> InvalidateBearerToken(IInvalidateBearerTokenParameters parameters);

        /// <inheritdoc cref="InvalidateAccessToken(IInvalidateAccessTokenParameters)" />
        Task<InvalidateTokenResponse> InvalidateAccessToken();

        /// <summary>
        /// Invalidate an AccessToken
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/invalidate_access_token </para>
        Task<InvalidateTokenResponse> InvalidateAccessToken(IInvalidateAccessTokenParameters parameters);
    }
}