using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace RememberMeBackend.Models.Data {
    public class ApplicationUser : IdentityUser {
        //props
        public String UserFirstName { get; set; }
        public String UserLastName { get; set; }
        public String UserQuestion1 { get; set; }
        public String UserQuestion2 { get; set; }
        public String UserAnswer1 { get; set; }
        public String UserAnswer2 { get; set; }

        //FK dependencies
        public virtual ICollection<Memory> CreatedMemories { get; set; }
        public virtual ICollection<Memory> SharedMemories { get; set; }
        public virtual ICollection<Album> CreatedAlbums { get; set; }
        public virtual ICollection<Album> SharedAlbums { get; set; }
        public virtual ICollection<Session> CreatedSessions { get; set; }
        public virtual ICollection<Session> SharedSessions { get; set; }
        public virtual ICollection<Timeline> CreatedTimelines { get; set; }

        //meths
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType) {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}