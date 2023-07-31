namespace Quota.Domain.Entities.Model.Authentication
{
    using Dapper.Contrib.Extensions;
    using Quota.Domain.Entities.Model.Transversal;
    using System;
        
    [Table("dbo.user")]
    [Serializable]
    public class User: BaseEntity
    {
        public int NumberId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RolId { get; set; }

        /// <summary>
        /// Gets or sets the Rol
        /// </summary>
        [Computed]
        public Rol Rol { get; set; }

    }
}
