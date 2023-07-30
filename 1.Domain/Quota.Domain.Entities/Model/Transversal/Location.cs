namespace Quota.Domain.Entities.Model.Transversal
{
    using Dapper.Contrib.Extensions;

    public class Location : BaseEntity
    {
        public string nombre { get; set; }
    }
}
