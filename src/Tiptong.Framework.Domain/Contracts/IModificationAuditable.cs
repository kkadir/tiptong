namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    /// <summary>
    /// Enables auditing of the modification properties of an <see cref="Entity{T}"/>.
    /// </summary>
    /// <typeparam name="TUser">
    /// The type of the user who modified the <see cref="Entity{T}"/>.
    /// </typeparam>
    public interface IModificationAuditable<TUser> where TUser : IEntity<TUser>
    {
        /// <summary>
        /// Gets or sets the user who modified the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value> The user who modified the <see cref="Entity{T}"/>. </value>
        TUser ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modification timestamp of the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value>
        /// The modification timestamp of the <see cref="Entity{T}"/>.
        /// </value>
        DateTime? ModificationTimestamp { get; set; }
    }
}