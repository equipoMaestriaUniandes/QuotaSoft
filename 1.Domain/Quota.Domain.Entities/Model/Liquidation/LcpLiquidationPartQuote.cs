namespace QuotaSoft.Domain.Entities.Model.Liquidation
{
    using Dapper.Contrib.Extensions;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using System;

    [Table("dbo.LcpLiquidationPartQuote")]
    [Serializable]
    public class LcpLiquidationPartQuote : BaseEntity
    {
        public int LiquidationNumber { get; set; }
        public int LiquidationType { get; set; }
        public int LiquidationYear { get; set; }
        public Guid? PerUserRetiredId { get; set; }
        public int RetireResolutionNumber { get; set; }
        public DateTime? RetireResolutionDate { get; set; }
        public DateTime? DoneDatePayment { get; set; }
        public DateTime? CutoffDate { get; set; }
        public decimal AllowenceValueMonthly { get; set; }
        public decimal AllowenceValueCurrently { get; set; }

        /// <summary>
        /// Gets or sets the Rol
        /// </summary>
        [Computed]
        public User User { get; set; }

    }
}
