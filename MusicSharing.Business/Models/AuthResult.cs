namespace MusicSharing.Business.Models
{
    /// <summary>
    /// The model for the authentication result.
    /// </summary>
    public class AuthResult
    {
        /// <summary>
        /// The access token.
        /// </summary>
        public string access_token { get; set; } = default!;

        /// <summary>
        /// The type of token.
        /// </summary>
        public string token_type { get; set; } = default!;

        /// <summary>
        /// The token's expiration date.
        /// </summary>
        public int expires_in { get; set; }
    }
}
