using System;
using System.Collections;
using System.Collections.Generic;
using API.Extentions;

namespace API.Entities
{
    public class AppUser //class this is our first entity
    {
        public int Id { get; set; } //class property and will be used as primary key in our database
        public string UserName {get; set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string LookingFor { get; set; }
        public string Introduction { get; set; }
        public string Intrests { get; set; }
        public ICollection<Photo> Photos { get; set; }
        
       /*  public int GetAfe()
        {
            return DateOfBirth.CalculateAge();
        } */
    }
}