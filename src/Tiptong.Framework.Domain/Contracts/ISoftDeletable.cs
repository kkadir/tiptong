namespace Tiptong.Framework.Domain.Contracts
{
    public interface ISoftDeletable
    {
        bool isDeleted { get; set; }
    }
}