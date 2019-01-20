namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    public interface IDeletionAuditable<T>
    {
        T DeletedBy { get; set; }

        DateTime? DeletionTime { get; set; }
    }
}