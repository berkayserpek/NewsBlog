using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.IdentityNumber).MinimumLength(11).WithMessage("Kimlik no 11 haneli olmak zorundadır!");
            RuleFor(x => x.IdentityNumber).MaximumLength(11).WithMessage("Kimlik no 11 haneden fazla olamaz!");
        }
    }
}
