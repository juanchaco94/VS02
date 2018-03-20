using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class ambient
    {
        [Key]
        public int IdAmbient { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(25)]
        public string name { get; set; }

        [Display(Name = "Sede")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdSeat { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool status { get; set; }

        #region Relaciones de la clase
        public virtual Seat Seat { get; set; }
        public virtual ICollection<group> group { get; set; }
        #endregion


    }
}