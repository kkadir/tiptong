namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    /// <summary>
    /// Enables auditing of the locking properties of an <see cref="Entity{T}"/>.
    /// </summary>
    /// <typeparam name="TUser">
    /// The type of the user who locked the <see cref="Entity{T}"/>.
    /// <typeparam name="TPrimaryKey">The type of the primary key of the user.</typeparam>
    /// </typeparam>
    public interface ILockAuditable<TUser, TPrimaryKey> where TUser : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Gets or sets the user who locked the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value> The user who locked the <see cref="Entity{T}"/>. </value>
        TUser LockedBy { get; set; }

        /// <summary>
        /// Gets or sets the lock timestamp of the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value>
        /// The lock timestamp of the <see cref="Entity{T}"/>.
        /// </value>
        DateTime? LockTimestamp { get; set; }
    }
}
