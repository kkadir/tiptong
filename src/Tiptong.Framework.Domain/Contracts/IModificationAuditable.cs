namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    public interface IModificationAuditable<T>
    {
        T ModifiedBy { get; set; }

        DateTime? ModificationDate { get; set; }
    }
}