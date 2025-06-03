using FluentValidation;
using ProjectTimeApi.DTOs;
using ProjectTimeApi.Data;
using ProjectTimeApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ProjectTimeApi.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator(IUserRepository repository)
        {
            RuleFor(x => x.Email)
                .MustAsync(async (email, _) => !await repository.ExistsByEmailAsync(email))
                .WithMessage("Email is already taken");
        }
    }
}
