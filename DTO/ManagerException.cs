using System;

namespace DTOs
{
    public class ManagerException <T> : Exception
    {
        public T Data { get; set; }
        public ManagerException(T dataRes)
        {   
           Data = dataRes;
        }
    }
}