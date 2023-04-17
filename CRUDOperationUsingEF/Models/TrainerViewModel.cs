using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDOperationUsingEF.Models
{
    [MetadataType(typeof(TrainerMetaData))]
    public partial class Trainer
    {

    }
    public class TrainerMetaData
    {
        public int TrainerId { get; set; }
        [Display(Name="Trainer Name")]
        public string Name { get; set; }
        public virtual ICollection<Student1> Student1 { get; set; }
    }
}