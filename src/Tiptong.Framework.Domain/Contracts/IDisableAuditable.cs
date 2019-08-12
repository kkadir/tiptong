namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    /// <summary>
    /// Enables auditing of the disabling properties of an <see cref="Entity{T}"/>.
    /// </summary>
    /// <typeparam name="TUser">
    /// The type of the user who disabled the <see cref="Entity{T}"/>.
    /// <typeparam name="TPrimaryKey">The type of the primary key of the user.</typeparam>
    /// </typeparam>
    public interface IDisableAuditable<TUser, TPrimaryKey> where TUser : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Gets or sets the user who disabled the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value> The user who disabled the <see cref="Entity{T}"/>. </value>
        TUser DisabledBy { get; set; }

        /// <summary>
        /// Gets or sets the disable timestamp of the <see cref="Entity{T}"/>.
        /// </summary>
        /// <value>
        /// The disable timestamp of the <see cref="Entity{T}"/>.
        /// </value>
        DateTime? DisableTimestamp { get; set; }
    }
}
