namespace Tiptong.Framework.Domain
{
    using System;
    using System.Reflection;
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

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<T>))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = (Entity<T>)obj;
            if (!HasValidIdentity() || !other.HasValidIdentity())
            {
                return false;
            }

            if (!GetType().GetTypeInfo().IsAssignableFrom(other.GetType())
                || !other.GetType().GetTypeInfo().IsAssignableFrom(GetType()))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            if (HasValidIdentity())
            {
                return Id.GetHashCode();
            }

            return 0;
        }
    }
}