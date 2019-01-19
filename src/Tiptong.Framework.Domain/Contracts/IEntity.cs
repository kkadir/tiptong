namespace Tiptong.Framework.Domain.Contracts
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        T GenerateIdentity();

        void SetIdentity();

        bool ValidateIdentity();
    }
}