namespace Quota.Domain.Entities.Model.Transversal
{
    using Dapper.Contrib.Extensions;
    using System;

    /// <summary>
    /// Defines the <see cref="Country" />
    /// </summary>

    public class City : Location
    {
        public Guid? stateId { get; set; }

        public Guid? countryId { get; set; }
    }
}
