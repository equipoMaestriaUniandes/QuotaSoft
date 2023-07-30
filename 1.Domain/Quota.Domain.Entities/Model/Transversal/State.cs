namespace Quota.Domain.Entities.Model.Transversal
{
    using Dapper.Contrib.Extensions;

    /// <summary>
    /// Defines the <see cref="Country" />
    /// </summary>
    [Table("perezgomez.departamentos")]
    public class State : Location
    {
    }
}
