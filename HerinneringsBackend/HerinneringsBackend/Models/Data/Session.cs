using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RememberMeBackend.Models.Data {
    [Table("dbo.sessions")]
    public class Session {
        [Key]
        public string SessionUuid { get; set; }
        public string SessionName { get; set; }
        public string SessionDate { get; set; }
        public string SessionNotes { get; set; }
        public string SessionDuration { get; set; }
        public int SessionCount { get; set; }
        public bool SessionIsFinished { get; set; }
        public string SessionCreator { get; set; }
        public string SessionTarget { get; set; }
        public long SessionLastModified { get; set; }
    }
}