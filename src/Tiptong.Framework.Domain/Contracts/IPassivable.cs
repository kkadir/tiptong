namespace Tiptong.Framework.Domain.Contracts
{
    public interface IPassivable
    {
        bool IsActive { get; set; }
    }
}