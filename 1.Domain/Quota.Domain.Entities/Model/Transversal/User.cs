namespace Quota.Domain.Entities.Model.Authentication
{
    using Dapper.Contrib.Extensions;
    using Quota.Domain.Entities.Model.Transversal;
    using System;
        
    [Table("perezgomez.usuarios")]
    [Serializable]
    public class User: BaseEntity
    {
        public string nombre { get; set; }

        public string usuario { get; set; }

        public string contrasena { get; set; }

        public string activo { get; set; }

        public int? rol { get; set; }

        public int? idinstitucion { get; set; }

        public string usuariowin { get; set; }

        public string correoelectronico { get; set; }

        public string contrasenacorreo { get; set; }

        public int? vuv { get; set; }

        public int? primeravez { get; set; }

        /// <summary>
        /// Gets or sets the Rol
        /// </summary>
        [Computed]
        public Rol rolObj { get; set; }

    }
}
