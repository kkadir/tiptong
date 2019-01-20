namespace Tiptong.Framework.Domain.Strategies
{
    using System;
    using Tiptong.Framework.Domain.Contracts;

    public sealed class LongIdentityStrategy : IIdentityStrategy<long>
    {
        public long GenerateIdentity()
        {
            return new Random(DateTime.Now.Millisecond).Next(1, Int32.MaxValue);
        }

        public bool ValidateIdentity(long identity)
        {
            return identity > 0;
        }
    }
}