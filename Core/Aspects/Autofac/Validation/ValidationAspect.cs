using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    // MethodInterception u using Core.Utilities.Interceptors içinden çöz
    //ValidationAspect methodInterception olduğu için onun implemente ettiği attribute ve IInterceptor özelliği taşır
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
            //Validationaspect attribute u çağırıldığı yerden gönderilen validatör tipinee göre çalışır( Bu, Contructor metodu)
        {
            // defensive coding

            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            // IValidator u using FluentValidation; dan çöz.
            // Önce gönderilen validatör tipinin atanabilir olup olmadığını kontrol ediyor
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
                //throw new System.Exception(AspectMessages.WrongValidationType);
                // bu hatayı geçici olarak bu şekilde düzenledik.
                //eğer atanabilir bir tip gönderiğlmemişse hata fırlatıyor.
            }
            // atanabilir bir tip gönderilmişse atamayı yapıyor.
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        // IInvocation u using Castle.Dynamic.Proxy; den çöz
        //burada validator çağırıldığı metottan önce çalışacağı için onBefore ezildi.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //burada validatör tipin çalışma anında instance ı oluşturulup(ProductValidator), IValidator ile çalışabilecek şekilde düzenleniyor.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //vaildate edilecek metodun parametrelerinden 1.sinin tipi alınıyor
            //(Business.ValidationRules.FluentValidation > ProductValidator : AbstractValidator<Product>)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //metodun parametreleri gezilir eşit olanları doğrulanır.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
                // ValidationTool u using Core.CrossCuttingConserns.Validation; dan çöz
            }
        }  
    }
}
