namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}