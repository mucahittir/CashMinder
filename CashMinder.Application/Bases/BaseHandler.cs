using System.Security.Claims;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Http;

namespace CashMinder.Application.Bases
{
    public class BaseHandler
    {
        protected readonly IMapper? mapper;
        protected readonly IUnitOfWork? unitOfWork;
        protected readonly IHttpContextAccessor? httpContextAccessor;
        protected readonly string? userId;

        public BaseHandler(IMapper? mapper, IUnitOfWork? unitOfWork, IHttpContextAccessor? httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            userId = httpContextAccessor?.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}