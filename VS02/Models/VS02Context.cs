using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class VS02Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VS02Context() : base("name=VS02Context")
        {
        }

        public System.Data.Entity.DbSet<VS02.Models.person> people { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.documentType> documentTypes { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.gender> genders { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.rol> rols { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.ambient> ambients { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.Seat> Seats { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.data> data { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.trainingProgram> trainingPrograms { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.workingDay> workingDays { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.group> groups { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.trimester> trimesters { get; set; }

        public System.Data.Entity.DbSet<VS02.Models.Specialty> Specialties { get; set; }
    }
}
