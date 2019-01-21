namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletionTime { get; set; }
    }
}