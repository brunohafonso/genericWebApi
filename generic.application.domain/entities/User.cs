using System;
using System.ComponentModel.DataAnnotations;

namespace generic.application.domain.entities
{
    public class User : Base
    {
        [Required(ErrorMessage="")]
        [StringLength(50, MinimumLength=5, ErrorMessage="")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDay { get; set; }

        public User()
        {
            
        }
        
        public User(string Name, DateTime BirthDay)
        {
            this.Name = Name;
            this.BirthDay = BirthDay;
        }
    }
}