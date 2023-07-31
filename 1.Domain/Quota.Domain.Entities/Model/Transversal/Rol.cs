namespace Quota.Domain.Entities.Model.Transversal
{
    using System;
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[rol]")]
    [Serializable]
    public class Rol : BaseEntity
    {
        public string RolName { get; set; }
        public bool Active { get; set; }

    }
}
