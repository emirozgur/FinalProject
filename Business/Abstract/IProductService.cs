using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        //Enitity diğer iki katmana bağlanması için referans ver ondan sonra izim uzayına  using Entities.Concrete; getirebilirsiniz
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min,decimal max);

    }
}
