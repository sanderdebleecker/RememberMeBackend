using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RememberMeBackend.Models.Data {
    [Table("dbo.trustees")]
    public class Trustee {
        [Key]
        [Column(Order=1)]
        public string TrusteeSource { get; set; }
        [Key]
        [Column(Order=2)]
        public string TrusteeDestination { get; set; }
        public bool TrusteeConfirmed { get; set; }
    }
}