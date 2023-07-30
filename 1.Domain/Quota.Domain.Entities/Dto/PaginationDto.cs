namespace Quota.Domain.Entities.Dto
{
    using System;

    public class PaginationDto
    {
        public int? Page { get; set; }

        public int? Offset { get; set; }

        public string ObjectId { get; set; }

        public DateTime? Date { get; set; }

        public string Key { get; set; }

        public string User { get; set; }
    }
}
