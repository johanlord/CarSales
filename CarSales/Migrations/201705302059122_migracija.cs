namespace CarSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automobil",
                c => new
                    {
                        AutomobilId = c.Int(nullable: false, identity: true),
                        Korisnik = c.String(nullable: false),
                        Marka = c.String(nullable: false, maxLength: 50),
                        Model = c.String(nullable: false, maxLength: 50),
                        Godiste = c.Int(nullable: false),
                        ZapreminaMotora = c.Int(nullable: false),
                        Snaga = c.Int(nullable: false),
                        Gorivo = c.String(nullable: false),
                        Karoserija = c.String(nullable: false),
                        Opis = c.String(nullable: false, maxLength: 150),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kontakt = c.String(nullable: false),
                        FajlSlike = c.Binary(),
                        TipFajla = c.String(),
                    })
                .PrimaryKey(t => t.AutomobilId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Automobil");
        }
    }
}
