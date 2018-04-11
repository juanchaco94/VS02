namespace VS02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasemake : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ambients",
                c => new
                    {
                        IdAmbient = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 25),
                        IdSeat = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAmbient)
                .ForeignKey("dbo.Seats", t => t.IdSeat, cascadeDelete: true)
                .Index(t => t.IdSeat);
            
            CreateTable(
                "dbo.groups",
                c => new
                    {
                        IdGroup = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 25),
                        IdData = c.Int(nullable: false),
                        IdAmbient = c.Int(nullable: false),
                        IdTrimester = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdGroup)
                .ForeignKey("dbo.ambients", t => t.IdAmbient, cascadeDelete: true)
                .ForeignKey("dbo.data", t => t.IdData, cascadeDelete: true)
                .ForeignKey("dbo.trimesters", t => t.IdTrimester, cascadeDelete: true)
                .Index(t => t.IdData)
                .Index(t => t.IdAmbient)
                .Index(t => t.IdTrimester);
            
            CreateTable(
                "dbo.data",
                c => new
                    {
                        IdData = c.Int(nullable: false, identity: true),
                        numberData = c.String(nullable: false, maxLength: 20),
                        IdWorkingDay = c.Int(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        finishDate = c.DateTime(nullable: false),
                        IdTrainingProgram = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                        description = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.IdData)
                .ForeignKey("dbo.trainingPrograms", t => t.IdTrainingProgram, cascadeDelete: true)
                .ForeignKey("dbo.workingDays", t => t.IdWorkingDay, cascadeDelete: true)
                .Index(t => t.IdWorkingDay)
                .Index(t => t.IdTrainingProgram);
            
            CreateTable(
                "dbo.trainingPrograms",
                c => new
                    {
                        IdTrainingProgram = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        acronym = c.String(nullable: false, maxLength: 7),
                        IdSpecialty = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTrainingProgram)
                .ForeignKey("dbo.Specialties", t => t.IdSpecialty, cascadeDelete: true)
                .Index(t => t.IdSpecialty);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        IdSpecialty = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IdSpecialty);
            
            CreateTable(
                "dbo.workingDays",
                c => new
                    {
                        IdWorkingDay = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IdWorkingDay);
            
            CreateTable(
                "dbo.trimesters",
                c => new
                    {
                        IdTrimester = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.IdTrimester);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        IdSeat = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 25),
                        address = c.String(nullable: false, maxLength: 30),
                        mainPhone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdSeat);
            
            CreateTable(
                "dbo.documentTypes",
                c => new
                    {
                        IdDocumentType = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 30),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdDocumentType);
            
            CreateTable(
                "dbo.people",
                c => new
                    {
                        IdPerson = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false, maxLength: 30),
                        lastName = c.String(nullable: false, maxLength: 30),
                        IdDocumentType = c.Int(nullable: false),
                        identityNumber = c.String(nullable: false, maxLength: 15),
                        phone = c.String(nullable: false, maxLength: 10),
                        email = c.String(nullable: false, maxLength: 30),
                        birthDate = c.DateTime(nullable: false),
                        IdRol = c.Int(nullable: false),
                        address = c.String(nullable: false, maxLength: 30),
                        IdGender = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPerson)
                .ForeignKey("dbo.documentTypes", t => t.IdDocumentType, cascadeDelete: true)
                .ForeignKey("dbo.genders", t => t.IdGender, cascadeDelete: true)
                .ForeignKey("dbo.rols", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdDocumentType)
                .Index(t => t.IdRol)
                .Index(t => t.IdGender);
            
            CreateTable(
                "dbo.genders",
                c => new
                    {
                        IdGender = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 30),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdGender);
            
            CreateTable(
                "dbo.rols",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 30),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.people", "IdRol", "dbo.rols");
            DropForeignKey("dbo.people", "IdGender", "dbo.genders");
            DropForeignKey("dbo.people", "IdDocumentType", "dbo.documentTypes");
            DropForeignKey("dbo.ambients", "IdSeat", "dbo.Seats");
            DropForeignKey("dbo.groups", "IdTrimester", "dbo.trimesters");
            DropForeignKey("dbo.data", "IdWorkingDay", "dbo.workingDays");
            DropForeignKey("dbo.trainingPrograms", "IdSpecialty", "dbo.Specialties");
            DropForeignKey("dbo.data", "IdTrainingProgram", "dbo.trainingPrograms");
            DropForeignKey("dbo.groups", "IdData", "dbo.data");
            DropForeignKey("dbo.groups", "IdAmbient", "dbo.ambients");
            DropIndex("dbo.people", new[] { "IdGender" });
            DropIndex("dbo.people", new[] { "IdRol" });
            DropIndex("dbo.people", new[] { "IdDocumentType" });
            DropIndex("dbo.trainingPrograms", new[] { "IdSpecialty" });
            DropIndex("dbo.data", new[] { "IdTrainingProgram" });
            DropIndex("dbo.data", new[] { "IdWorkingDay" });
            DropIndex("dbo.groups", new[] { "IdTrimester" });
            DropIndex("dbo.groups", new[] { "IdAmbient" });
            DropIndex("dbo.groups", new[] { "IdData" });
            DropIndex("dbo.ambients", new[] { "IdSeat" });
            DropTable("dbo.rols");
            DropTable("dbo.genders");
            DropTable("dbo.people");
            DropTable("dbo.documentTypes");
            DropTable("dbo.Seats");
            DropTable("dbo.trimesters");
            DropTable("dbo.workingDays");
            DropTable("dbo.Specialties");
            DropTable("dbo.trainingPrograms");
            DropTable("dbo.data");
            DropTable("dbo.groups");
            DropTable("dbo.ambients");
        }
    }
}
