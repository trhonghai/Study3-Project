using NET.Data;
using NET.Helpers;

namespace NET.Dto
{
    public class LoginResponseDto
    {
        public TokenType AccessToken { get; set; }
        public TokenType RefreshToken { get; set; }

        
     
    }
}