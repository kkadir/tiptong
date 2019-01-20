namespace Tiptong.Framework.Domain.Contracts
{
    public interface IIdentityStrategy<T>
    {
        T GenerateIdentity();

        bool ValidateIdentity(T identity);
    }
}