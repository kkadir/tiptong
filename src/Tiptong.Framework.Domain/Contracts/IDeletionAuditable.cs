namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    /// <summary>
    /// Enables auditing of the deletion properties of an <see cref="Entity{T}" />.
    /// </summary>
    /// <typeparam name="TUser">The type of the user who deleted the <see cref="Entity{T}" />.</typeparam>
    /// <typeparam name="TPrimaryKey">The type of the primary key of the user.</typeparam>
    public interface IDeletionAuditable<TUser, TPrimaryKey> where TUser : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Gets or sets the user who deleted the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value> The user who deleted the <see cref="Entity{T}"/>. </value>
        TUser DeletedBy { get; set; }

        /// <summary>
        /// Gets or sets the deletion timestamp of the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value>
        /// The deletion timestamp of the <see cref="Entity{T}"/>.
        /// </value>
        DateTime? DeletionTimestamp { get; set; }
    }
}