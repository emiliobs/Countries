namespace Countries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class UserType
    {
      
        public int UserTypeId { get; set; }

       
        public string Name { get; set; }

        //lado uno de la relacion
       
        public virtual ICollection<User> Users { get; set; }
    }
}
