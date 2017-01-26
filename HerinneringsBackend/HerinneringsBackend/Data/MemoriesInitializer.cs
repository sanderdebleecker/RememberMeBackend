﻿using RememberMeBackend.Models;
using RememberMeBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace RememberMeBackend.Data {
    public class MemoriesInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<MemoryDbContext> {
        protected override void Seed(MemoryDbContext context) {
            MD5Hasher md5 = new Data.MD5Hasher();
            ApplicationUser user = new ApplicationUser {
                Id = Guid.NewGuid().ToString("D"),
                UserFirstName = "Janikka",
                UserLastName = "Peeters",
                UserQuestion1 = "Q1?",
                UserAnswer1 = "A1",
                UserQuestion2 = "Q2?",
                UserAnswer2 = "A2",
                UserName = "JPeeters",
                PasswordHash = md5.Hash("somethingsomething54!"),
            };
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void TestSeed(MemoryDbContext context) {
            Seed(context);
        }
    }
}