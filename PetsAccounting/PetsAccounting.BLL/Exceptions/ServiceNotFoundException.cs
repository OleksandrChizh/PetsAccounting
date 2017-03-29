using System;

namespace PetsAccounting.BLL.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException(string message) : base(message)
        {
        }
    }
}
