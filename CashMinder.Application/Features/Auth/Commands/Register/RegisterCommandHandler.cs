using System.Security.Claims;
using CashMinder.Application.Bases;
using CashMinder.Application.Features.Auth.Rules;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CashMinder.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;
        
        private readonly IValidator<RegisterCommandRequest> validator;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userId;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IValidator<RegisterCommandRequest> validator) : base()
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.validator = validator;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            await authRules.UserShouldNotExist(await userManager.FindByEmailAsync(request.Email));
            User user = mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if(!await roleManager.RoleExistsAsync("User"))
                    await roleManager.CreateAsync(new Role{
                        Id = Guid.NewGuid(),
                        Name = "User",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
                
                await userManager.AddToRoleAsync(user, "User");
            }
            return Unit.Value;
        }
    }
}