using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class Seat
    {
        [Key]
        public int IdSeat { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(25)]
        public string name { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string address { get; set; }

        [Display(Name = "Teléfono principal")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.PhoneNumber)]
        public string mainPhone { get; set; }

        #region Relaciones de la clase
        public virtual ICollection<ambient> ambient { get; set; }
        #endregion
    }
}