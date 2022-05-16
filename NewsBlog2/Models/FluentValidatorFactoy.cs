using BusinessLayer.ValidationRules;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Models
{
    public class FluentValidatorFactoy : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();
        static FluentValidatorFactoy()
        {
            validators.Add(typeof(IValidator<UserRegisterVM>), new UserValidator());
        }
        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}
