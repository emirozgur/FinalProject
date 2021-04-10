using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
        //ProductValidator aynı zamanda abstarctValidator dan dolayı bir IValidatordur ve çağırıldığı yere product gönderir
        //Biz bu sınıfı productManager in metodlarının başında ValidationAspect attributunda çağırırız
        
    {

        public ProductValidator()
        {
            //ProductValidatorun ctorunda Product varlığına özgü doğrulama kuralları yazılır
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
