using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RememberMeBackend.Models.Data {
    [Table("dbo.timelines")]
    public class Timeline {
        [Key]
        public string TimelineUuid { get; set; }
        public string TimelineMemory { get; set; }
        public string TimelineUser { get; set; }
        public long TimelineLastModified { get; set; }
    }
}