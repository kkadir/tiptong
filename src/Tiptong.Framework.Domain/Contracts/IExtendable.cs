namespace Tiptong.Framework.Domain.Contracts
{
    /// <summary>
    /// Enables extending the data of an <see cref="Entity{T}"/>.
    /// </summary>
    public interface IExtendable
    {
        /// <summary>
        /// Gets or sets the extended <see cref="Entity{T}"/> data .
        /// </summary>
        /// <value>
        /// The exteded <see cref="Entity{T}"/> data.
        /// </value>
        string ExtendedData { get; set; }
    }
}