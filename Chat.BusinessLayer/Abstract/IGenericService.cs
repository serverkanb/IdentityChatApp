﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BusinessLayer.Abstract
{

        public interface IGenericService<T> where T : class
        {
            List<T> GetList();
            T GetById(int id);
            void Create(T entity);
            void Update(T entity);
            void Delete(int id);
        }
    
}
