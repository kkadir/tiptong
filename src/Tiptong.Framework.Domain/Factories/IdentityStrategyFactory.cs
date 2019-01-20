namespace Tiptong.Framework.Domain.Factories
{
    using System;
    using Tiptong.Framework.Domain.Contracts;
    using Tiptong.Framework.Domain.Strategies;

    public static class IdentityStrategyFactory
    {
        public static IIdentityStrategy<T> GetIdentityStrategy<T>()
        {
            if (typeof(T) == typeof(int))
            {
                return new IntegerIdentityStrategy() as IIdentityStrategy<T>;
            }
            else if (typeof(T) == typeof(long))
            {
                return new LongIdentityStrategy() as IIdentityStrategy<T>;
            }
            else if (typeof(T) == typeof(Guid))
            {
                return new GuidIdentityStrategy() as IIdentityStrategy<T>;
            }

            throw new InvalidOperationException($"Type: {typeof(T)} Doesn't Have an Identity Strategy Defined.");
        }
    }
}