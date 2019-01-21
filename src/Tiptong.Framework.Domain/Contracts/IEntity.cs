namespace Tiptong.Framework.Domain.Contracts
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        T GenerateIdentity();

        void SetIdentity(T identity);

        bool HasValidIdentity();

        bool ValidateIdentity(T identity);
    }
}