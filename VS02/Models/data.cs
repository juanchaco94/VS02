using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class data
    {
        [Key]
        public int IdData { get; set; }

        [Display(Name = "Número de ficha")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(20)]
        public string numberData { get; set; }

        [Display(Name = "Jornada")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdWorkingDay { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [Display(Name = "Fecha de finalización")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime finishDate { get; set; }

        [Display(Name = "Programa de formación")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdTrainingProgram { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool status { get; set; }

        [Display(Name = "Description")]
        [StringLength(30)]
        public string  description { get; set; }

        #region Relaciones de la clase
        //Ficha < Jornada
        public virtual workingDay workingDay { get; set; }
        public virtual trainingProgram trainingProgram { get; set; }
        public virtual ICollection<group> group { get; set; }
        #endregion
    }
}