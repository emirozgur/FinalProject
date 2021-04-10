using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConserns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
            // ProductValidator un bağlı olduğu IValidator nesnesi metoda parametre olarak gönderilir. bu parametre doğrulama kurallarını içerir. Doğrulanacak nesne ise object entity parametresi ile gelir.
        {
            var context = new ValidationContext<object>(entity);
            // context nesnesi ile ValidationContext sınıfından bir örnek oluşturulur. 
            var result = validator.Validate(context);
            // IValidator un validate metodu kullanılarak doğrulama yapılır.
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
                // Doğrulama başarısızsa hata fırlatır
            }
        }
    }
}
