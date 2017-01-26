using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RememberMeBackend.Models.Data {
    [Table("dbo.albums")]
    public class Album {
        [Key]
        public string AlbumUuid { get; set; }
        public string AlbumName { get; set; }
        public string AlbumThumbnail { get; set; }
        public string AlbumCreator { get; set; }
        public string AlbumTarget { get; set; }
        public long AlbumLastModified { get; set; }

        //FK Collections
        public virtual ICollection<Memory> Memories { get; private set; }
        public virtual ICollection<Session> Sessions { get; private set; }
        
        //FK Attributes
        public virtual ApplicationUser Creator { get; set; }
        public virtual ApplicationUser Target { get; set; }

    }
}