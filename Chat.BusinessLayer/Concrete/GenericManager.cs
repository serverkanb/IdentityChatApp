using Chat.BusinessLayer.Abstract;
using Chat.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void Create(T entity)
        {
            _genericDal.Create(entity);
        }

        public void Delete(int id)
        {
            _genericDal.Delete(id);
        }

        public T GetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public List<T> GetList()
        {
            return _genericDal.GetList();
        }

        public void Update(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
