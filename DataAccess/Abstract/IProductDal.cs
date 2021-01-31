﻿using Entities.Concrete;// işaretleme yapmadan önce burada DataAccess üzerine sağ tıklayıp add project reference yapmalıyız ancak ondan sonra using i ekleyebiliriz.
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal// interface lerin operasyonları default public tir ancak kendileri public değildiir bu yüzden erişim bildirgecini public yaptık.
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);
    }
}
