namespace Countries.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        [Index("UserType_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        //lado uno de la relacion
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

    }
}