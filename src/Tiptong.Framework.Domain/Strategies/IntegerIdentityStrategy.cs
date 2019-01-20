namespace Tiptong.Framework.Domain.Strategies
{
    using System;
    using Tiptong.Framework.Domain.Contracts;

    public sealed class IntegerIdentityStrategy : IIdentityStrategy<int>
    {
        public int GenerateIdentity()
        {
            return new Random(DateTime.Now.Millisecond).Next(1, Int32.MaxValue);
        }

        public bool ValidateIdentity(int identity)
        {
            return identity > 0;
        }
    }
}