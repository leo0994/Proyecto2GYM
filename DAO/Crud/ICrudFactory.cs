using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Crud
{
    public abstract class CrudFactory<T>
    {
        protected SqlDAO dao;

        public abstract T Create(T entityDTO);
        public abstract T Update(T entityDTO);
        public abstract T Delete(T entityDTO);
        public abstract List<T> RetrieveAll();
        public abstract T RetrieveById(int id);
    }
}
