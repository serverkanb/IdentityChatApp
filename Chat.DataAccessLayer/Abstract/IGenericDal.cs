﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetList();

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
