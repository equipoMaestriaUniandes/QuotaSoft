namespace Quota.Domain.Entities.Model.Transversal
{
    using Dapper.Contrib.Extensions;
    using System;

    [Serializable]
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public virtual int id { get; set; } 
    }
}
