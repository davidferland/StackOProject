using System;
namespace StackO.Core.Models {
    public class BaseEntity {
        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }
    }
}