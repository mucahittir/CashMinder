using CashMinder.Application.Bases;

namespace CashMinder.Application.Features.Auth.Exceptions
{
    public class RefreshTokenExpiredException : BaseException
    {
        public RefreshTokenExpiredException() : base("Refresh token expired") { }
    }
}