using Dapper.Contrib.Extensions;

namespace Quota.Domain.Entities.Model.Transversal
{

    /// <summary>
    /// Defines the <see cref="RolPermissions" />
    /// </summary>

    public class RolPermissions : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier menu.
        /// </summary>
        public string menu { get; set; }

        /// <summary>
        /// Gets or sets the identifier menu.
        /// </summary>
        public int menuId { get; set; }

        /// <summary>
        /// Gets or sets the identifier rol.
        /// </summary>
        public int rol { get; set; }

        /// <summary>
        /// Gets or sets the activo.
        /// </summary>
        public int active { get; set; }

        /// <summary>
        /// Gets or sets the Menu
        /// </summary>
        [Computed]
        public Menu Menu { get; set; }

        /// <summary>
        /// Gets or sets the Rol
        /// </summary>
        [Computed]
        public Rol Rol { get; set; }
    }
}
