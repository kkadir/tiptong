namespace Tiptong.Framework.Domain.Contracts
{
    using System;
    
    public interface ICreationAuditable<T>
    {
        T CreatedBy { get; set; }

        DateTime CreationDate { get; set; }
    }
}