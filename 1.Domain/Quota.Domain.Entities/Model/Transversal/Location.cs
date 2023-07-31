namespace Quota.Domain.Entities.Model.Transversal
{
    using Dapper.Contrib.Extensions;

    public class Location : BaseEntity
    {
        public string name { get; set; }
    }
}
