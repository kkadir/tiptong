namespace Tiptong.Framework.Domain.Contracts
{
    using System;

    /// <summary>
    /// Enables auditing of the creation properties of an <see cref="Entity{T}"/>.
    /// </summary>
    /// <typeparam name="TUserId">The primary key type of the user who created the entity.</typeparam>
    public interface ICreationAuditable<TUserId>
    {

        /// <summary>
        /// Gets or sets the user who created the entity.
        /// </summary>
        /// <value> The user who created the entity. </value>
        TUserId CreatedBy { get; set; }


        /// <summary>
        /// Gets or sets the creation time stamp of the entity.
        /// </summary>
        /// <value>
        /// The creation time stamp of the entity.
        /// </value>
        DateTime CreationTimeStamp { get; set; }
    }
}