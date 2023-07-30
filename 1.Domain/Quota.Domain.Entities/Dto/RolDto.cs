namespace Quota.Domain.Entities.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RolDto
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// Gets or sets the rolCode
        /// </summary>
        public int? rolCode { get; set; }

        /// <summary>
        /// Gets or sets the rolName
        /// </summary>
        public string rolName { get; set; }

        /// <summary>
        /// Gets or sets the isAdmin
        /// </summary>
        public bool? isAdmin { get; set; }
    }
}
