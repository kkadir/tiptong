namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    /// <summary>
    /// Enables auditing of the creation properties of an <see cref="Entity{T}"/>.
    /// </summary>
    /// <typeparam name="TUser">
    /// The type of the user who created the <see cref="Entity{T}"/>.
    /// <typeparam name="TPrimaryKey">The type of the primary key of the user.</typeparam>
    /// </typeparam>
    public interface ICreationAuditable<TUser, TPrimaryKey> where TUser : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Gets or sets the user who created the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value> The user who created the <see cref="Entity{T}"/>. </value>
        TUser CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value>
        /// The creation timestamp of the <see cref="Entity{T}"/>.
        /// </value>
        DateTime CreationTimestamp { get; set; }
    }
}