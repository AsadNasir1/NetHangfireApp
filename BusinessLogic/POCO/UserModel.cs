using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.POCO
{
    public class UserModel
    {
        public long UserID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be more than 50 characters")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public NGDate NGDateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class NGDate
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }
}
