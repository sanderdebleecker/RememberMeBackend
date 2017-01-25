using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RememberMeBackend.Models.Data {
    [Table("dbo.users")]
    public class User {
        [Key]
        public String UserUuid { get; set; }
        public String UserFirstName { get; set; }
        public String UserLastName { get; set; }
        public String UserName { get; set; }
        public String UserPassword { get; set; }
        public String UserQuestion1 { get; set; }
        public String UserQuestion2 { get; set; }
        public String UserAnswer1 { get; set; }
        public String UserAnswer2 { get; set; }
    }
}