﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic repository design pattern 
    //Generic constraint (kısıt)
    // class : referans tip
    // IEntity veya IEntity implemente eden bir nesne olabilir.
    // newlwnwbbilir olmalı IEntity interface olduğu için newlenemez.
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
