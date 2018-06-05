using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecture.Models
{
    [Serializable]
    public class Person
    {
        public int ID { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [UIHint("Sex")]
        public int Sex { get; set; }

        [Required(ErrorMessage = "Enter the issued date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BithDate { get; set; }


        public override string ToString()
        {
            return "ID : " + ID + "\n" +
                   "First Name : " + FirstName + "\n" +
                   "Last Name :" + LastName + "\n" +
                   "BirthDate : " + BithDate;
        }
    }
}