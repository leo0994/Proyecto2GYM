using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mapper
{
    public interface ICrudStatements <T>
    {
        SqlOperation GetCreateStatement(T entityDTO);
        SqlOperation GetUpdateStatement(T entityDTO);
        SqlOperation GetDeleteStatement(int id);
        SqlOperation GetRetrieveAllStatement();
        SqlOperation GetRetrieveByIdStatement(int Id);
    }
}
