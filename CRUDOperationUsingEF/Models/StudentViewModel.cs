using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDOperationUsingEF.Models
{
    [MetadataType(typeof(Student1MetaData))]
    public partial class Student1
    {

    }
    public class Student1MetaData
    {
        public int RollNumber { get; set; }
        [Display(Name="Student Name")]
        public string Name { get; set; }
        [Display(Name="Student Age")]
        public Nullable<int> Age { get; set; }
        [Display(Name="Student Email")]
        public string Email { get; set; }
        [Display(Name="Date Of Birth")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Display(Name = "Added Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> AddedDate { get; set; }
        [Display(Name = "Student City")]
        public string City { get; set; }
        public Nullable<int> TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}