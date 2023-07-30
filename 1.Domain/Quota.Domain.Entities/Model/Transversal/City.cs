namespace Quota.Domain.Entities.Model.Transversal
{
    using Dapper.Contrib.Extensions;

    /// <summary>
    /// Defines the <see cref="Country" />
    /// </summary>
    [Table("perezgomez.municipios")]
    public class City : Location
    {
        public int? codigoDep { get; set; }

        public int? codigoPais { get; set; }
    }
}
