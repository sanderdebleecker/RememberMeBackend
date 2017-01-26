using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

//TODO add excluded factor as salt

namespace RememberMeBackend.Data {
    public class MD5Hasher {
        public const string BAD_SALT = "badpoeder";

        public string Hash(string secret) {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] origin = System.Text.Encoding.ASCII.GetBytes(secret + BAD_SALT);
            byte[] hashed = md5.ComputeHash(origin);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashed.Length; i++) {
                sb.Append(hashed[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}