using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RememberMeBackend.Models.Data {
    [Table("dbo.memories")]
    public class Memory {
        [Key]
        public string MemoryUuid { get; set; }
        public string MemoryDescription { get; set; }
        public string MemoryDate { get; set; }
        public int MemoryRating { get; set; }
        public float MemoryLocationLat { get; set; }
        public float MemoryLocationLong { get; set; }
        public string MemoryLocationName { get; set; }
        public string MemoryPath { get; set; }
        public string MemoryType { get; set; }
        public string MemoryCreator { get; set; }
        public string MemoryTarget { get; set; }
        public long MemoryLastModified { get; set; }
    }
}