namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Municipios",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 50),
                    ProvinciaId = c.Long(nullable: true),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincias", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => t.ProvinciaId);

            CreateTable(
                "dbo.Provincias",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Viviendas",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    MunicipioId = c.Long(nullable: true),
                    Direccion = c.String(nullable: false, maxLength: 100),
                    Cp = c.String(nullable: false, maxLength: 5),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipios", t => t.MunicipioId, cascadeDelete: true)
                .Index(t => t.MunicipioId);

            CreateTable(
                "dbo.Personas",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    HogarId = c.Long(nullable: true),
                    Dni = c.String(nullable: false, maxLength: 9),
                    Nombre = c.String(nullable: false, maxLength: 50),
                    Apellido = c.String(nullable: false, maxLength: 100),
                    FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Viviendas", t => t.HogarId, cascadeDelete: true)
                .Index(t => t.HogarId);

            CreateTable(
                "dbo.Propiedads",
                c => new
                {
                    PropietarioId = c.Long(nullable: false),
                    ViviendaId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new { t.PropietarioId, t.ViviendaId })
                .ForeignKey("dbo.Personas", t => t.PropietarioId, cascadeDelete: false)
                .ForeignKey("dbo.Viviendas", t => t.ViviendaId, cascadeDelete: false)
                .Index(t => t.PropietarioId)
                .Index(t => t.ViviendaId);

            //CreateTable(
            //    "dbo.Propiedades",
            //    c => new
            //    {
            //        PropietarioId = c.Long(nullable: false),
            //        ViviendaId = c.Long(nullable: false),
            //    })
            //    .PrimaryKey(t => new { t.PropietarioId, t.ViviendaId })
            //    .ForeignKey("dbo.Personas", t => t.PropietarioId, cascadeDelete: false)
            //    .ForeignKey("dbo.Viviendas", t => t.ViviendaId, cascadeDelete: false)
            //    .Index(t => t.PropietarioId)
            //    .Index(t => t.ViviendaId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Propiedads", "ViviendaId", "dbo.Viviendas");
            DropForeignKey("dbo.Propiedads", "PropietarioId", "dbo.Personas");
            DropForeignKey("dbo.Viviendas", "MunicipioId", "dbo.Municipios");
            DropForeignKey("dbo.Personas", "HogarId", "dbo.Viviendas");
            //DropForeignKey("dbo.Propiedades", "ViviendaId", "dbo.Viviendas");
            //DropForeignKey("dbo.Propiedades", "PropietarioId", "dbo.Personas");
            DropForeignKey("dbo.Municipios", "ProvinciaId", "dbo.Provincias");
            //DropIndex("dbo.Propiedades", new[] { "ViviendaId" });
            //DropIndex("dbo.Propiedades", new[] { "PropietarioId" });
            DropIndex("dbo.Propiedads", new[] { "ViviendaId" });
            DropIndex("dbo.Propiedads", new[] { "PropietarioId" });
            DropIndex("dbo.Personas", new[] { "HogarId" });
            DropIndex("dbo.Viviendas", new[] { "MunicipioId" });
            DropIndex("dbo.Municipios", new[] { "ProvinciaId" });
            //DropTable("dbo.Propiedades");
            DropTable("dbo.Propiedads");
            DropTable("dbo.Personas");
            DropTable("dbo.Viviendas");
            DropTable("dbo.Provincias");
            DropTable("dbo.Municipios");
        }
    }
}
