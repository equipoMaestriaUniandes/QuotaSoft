namespace Quota.Domain.Entities.Config
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConstantsData
    {
        /// <summary>
        /// The batch size.
        /// </summary>
        public const int BatchSize = 5000;

        /// <summary>
        /// The bulk copy timeout.
        /// </summary>
        public const int BulkCopyTimeout = 3600000;
    }
}
