namespace Tiptong.Framework.Domain
{
    using System;
    using Tiptong.Framework.Domain.Contracts;
    using Tiptong.Framework.Domain.Factories;

    public abstract class Entity<T> : IEntity<T>
    {
        private readonly IIdentityStrategy<T> _identityStrategy = IdentityStrategyFactory.GetIdentityStrategy<T>();

        public virtual T Id { get; set ; }

        public T GenerateIdentity()
        {
            return _identityStrategy.GenerateIdentity();
        }

        public bool HasValidIdentity()
        {
            return ValidateIdentity(Id);
        }

        public void SetIdentity(T identity)
        {
            if(ValidateIdentity(identity))
            {
                Id = identity;
            }
        }

        public bool ValidateIdentity(T identity)
        {
            return _identityStrategy.ValidateIdentity(identity);
        }
    }
}