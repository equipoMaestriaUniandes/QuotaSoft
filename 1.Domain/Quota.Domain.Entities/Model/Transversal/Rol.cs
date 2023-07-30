namespace Quota.Domain.Entities.Model.Transversal
{
    using System;
    using Dapper.Contrib.Extensions;

    [Table("perezgomez.roles")]
    [Serializable]
    public class Rol : BaseEntity
    {
        public int? rol { get; set; }

        public string descripcion { get; set; }

        public int? activo { get; set; }

    }
}
