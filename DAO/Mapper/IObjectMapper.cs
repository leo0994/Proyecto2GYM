using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mapper
{
    public interface IObjectMapper<T>
    {
        T BuildObject(Dictionary<string, object> objectRow);
        List<T> BuildObjects(List<Dictionary<string, object>> objectRows);
    }
}
