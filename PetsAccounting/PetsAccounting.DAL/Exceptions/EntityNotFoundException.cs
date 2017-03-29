using System;

namespace PetsAccounting.DAL.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message, Type entityType) : base(message)
        {
            EntityType = entityType;
        }

        public Type EntityType { get; private set; }
    }
}