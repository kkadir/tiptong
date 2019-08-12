namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    /// <summary>
    /// Enables auditing of the creation properties of an <see cref="Entity{T}"/>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user who created the <see cref="Entity{T}"/>.</typeparam>
    public interface ICreationAuditable<TUser> where TUser : IEntity<TUser>
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
        DateTime CreationTimeStamp { get; set; }
    }
}