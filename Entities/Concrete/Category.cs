
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    // Çıplak class kalmasın  her iki sınıf interface i implemente edecek

    public class Category:IEntity
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

    }
}
