namespace Quota.Domain.Entities.Model.Transversal
{
    using Dapper.Contrib.Extensions;

    /// <summary>
    /// Defines the <see cref="Menu" />
    /// </summary>
    
    public class Menu : BaseEntity
    {
        /// <summary>
        /// Gets or sets the titulo
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets the modulo
        /// </summary>
        public string module { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Menu"/> is activo.
        /// </summary>
        public bool  active { get; set; }
    }
}
