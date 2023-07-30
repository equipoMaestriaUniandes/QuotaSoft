namespace Quota.Domain.Entities.Model.Transversal
{
    using Dapper.Contrib.Extensions;

    /// <summary>
    /// Defines the <see cref="Menu" />
    /// </summary>
    [Table("perezgomez.menus")]
    public class Menu : BaseEntity
    {
        /// <summary>
        /// Gets or sets the titulo
        /// </summary>
        public string titulo { get; set; }

        /// <summary>
        /// Gets or sets the modulo
        /// </summary>
        public string modulo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Menu"/> is activo.
        /// </summary>
        public int? activo { get; set; }

        /// <summary>
        /// Gets or sets the parent
        /// </summary>
        public int? idNavegabilidadPadre { get; set; }

        /// <summary>
        /// Gets or sets the parent
        /// </summary>
        public int? ordenPresentacion { get; set; }

        /// <summary>
        /// Gets or sets the parent
        /// </summary>
        public string icono { get; set; }

        /// <summary>
        /// Gets or sets the parent
        /// </summary>
        public string urlFormulario { get; set; }
    }
}
