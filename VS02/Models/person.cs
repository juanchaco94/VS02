using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class person
    {
        [Key]
        public int IdPerson { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string firstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string lastName { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdDocumentType { get; set; }

        [Display(Name = "Número de documento")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15)]
        public string identityNumber { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(10)]
        public string phone { get; set; }

        [Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime birthDate { get; set; }

        [Display(Name = "Rol del usuario")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdRol { get; set; }

        [Display(Name = "Dirección de residencia")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string address { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdGender { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool status { get; set; }


        #region Relaciones de la clase
        public virtual documentType documentType { get; set; }

        public virtual rol rol { get; set; }

        public virtual gender genders { get; set; }
        #endregion
    }
}