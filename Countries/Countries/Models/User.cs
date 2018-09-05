using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.Models
{
    public class User
    {
      
        public int UserId { get; set; }

      
        public string FirstName { get; set; }

      
        public string LastName { get; set; }

      
        public string Email { get; set; }

       
        public string Telephone { get; set; }

     
        public string ImagePath { get; set; }

        public int UserTypeId { get; set; }

     
        public virtual UserType UserType { get; set; }

       
        public byte[] ImageArray { get; set; }

        
        public string Password { get; set; }

       
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImagePath))
                {
                    return "noimage";
                }

                return $"http://countriesapi.azurewebsites.net/{ImagePath.Substring(1)}";
            }
        }

      
        public string FullName => $"{FirstName} { LastName}";
    }
}
