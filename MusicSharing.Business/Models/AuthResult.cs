namespace MusicSharing.Business.Models
{
    public class AuthResult
    {
        public string access_token { get; set; } = default!;
        public string token_type { get; set; } = default!;
        public int expires_in { get; set; }
    }
}
