using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class workingDay
    {
        [Key]
        public int IdWorkingDay { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(20)]
        public string nombre { get; set; }

        #region Relaciones de la clase
        //Ficha > Jornada
        public virtual ICollection<data> data { get; set; }
        #endregion
    }
}