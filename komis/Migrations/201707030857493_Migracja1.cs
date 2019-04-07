namespace komis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Klients",
                c => new
                    {
                        IdKlienta = c.Int(nullable: false, identity: true),
                        IdOsoby = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdKlienta)
                .ForeignKey("dbo.Osobas", t => t.IdOsoby, cascadeDelete: true)
                .Index(t => t.IdOsoby);
            
            CreateTable(
                "dbo.Osobas",
                c => new
                    {
                        IdOsoby = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Pesel = c.Long(nullable: false),
                        Kod_pocztowy = c.String(),
                        Miasto = c.String(),
                        Ulica = c.String(),
                        Nr_mieszkania = c.Int(nullable: false),
                        Nr_domu = c.Int(nullable: false),
                        Data_Urodzenia = c.DateTime(nullable: false),
                        Nr_telefonu = c.Long(nullable: false),
                        E_mail = c.String(),
                        Nr_dowodu = c.String(),
                    })
                .PrimaryKey(t => t.IdOsoby);
            
            CreateTable(
                "dbo.Sprzedawcas",
                c => new
                    {
                        IdSprzedawcy = c.Int(nullable: false, identity: true),
                        IdOsoby = c.Int(nullable: false),
                        Tranzakcja_IdTranzakcji = c.Int(),
                    })
                .PrimaryKey(t => t.IdSprzedawcy)
                .ForeignKey("dbo.Osobas", t => t.IdOsoby, cascadeDelete: true)
                .ForeignKey("dbo.Tranzakcjas", t => t.Tranzakcja_IdTranzakcji)
                .Index(t => t.IdOsoby)
                .Index(t => t.Tranzakcja_IdTranzakcji);
            
            CreateTable(
                "dbo.Tranzakcjas",
                c => new
                    {
                        IdTranzakcji = c.Int(nullable: false, identity: true),
                        Rodzaj_tranzakcji = c.String(),
                        IdSprzedawcy = c.Int(nullable: false),
                        IdKlienta = c.Int(nullable: false),
                        PojazdID = c.Int(nullable: false),
                        Sposob_płatności = c.String(),
                        Data_tranzakcji = c.DateTime(nullable: false),
                        Zapłacono = c.Boolean(nullable: false),
                        Osoba_IdOsoby = c.Int(),
                    })
                .PrimaryKey(t => t.IdTranzakcji)
                .ForeignKey("dbo.Klients", t => t.IdKlienta, cascadeDelete: true)
                .ForeignKey("dbo.Pojazds", t => t.PojazdID, cascadeDelete: true)
                .ForeignKey("dbo.Osobas", t => t.Osoba_IdOsoby)
                .Index(t => t.IdKlienta)
                .Index(t => t.PojazdID)
                .Index(t => t.Osoba_IdOsoby);
            
            CreateTable(
                "dbo.Pojazds",
                c => new
                    {
                        PojazdID = c.Int(nullable: false, identity: true),
                        IdMarki = c.Int(nullable: false),
                        IdModelu = c.Int(nullable: false),
                        IdRodzaju = c.Int(nullable: false),
                        Rok_produkcji = c.Int(nullable: false),
                        Przebieg = c.Long(nullable: false),
                        Data_rejestracji = c.DateTime(nullable: false),
                        Data_przyjecia = c.DateTime(nullable: false),
                        Data_wydania = c.DateTime(nullable: false),
                        Zdjecie = c.Binary(),
                        Pojemność_silnika = c.Int(nullable: false),
                        Powypadkowy = c.Boolean(nullable: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rezerwacja = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PojazdID)
                .ForeignKey("dbo.Model_pojazdu", t => t.IdModelu, cascadeDelete: true)
                .ForeignKey("dbo.Markas", t => t.IdMarki, cascadeDelete: true)
                .ForeignKey("dbo.Rodzajs", t => t.IdRodzaju, cascadeDelete: true)
                .Index(t => t.IdMarki)
                .Index(t => t.IdModelu)
                .Index(t => t.IdRodzaju);
            
            CreateTable(
                "dbo.Markas",
                c => new
                    {
                        IdMarki = c.Int(nullable: false, identity: true),
                        Nazwa_Marki = c.String(),
                        Model_pojazdu_IdModelu = c.Int(),
                    })
                .PrimaryKey(t => t.IdMarki)
                .ForeignKey("dbo.Model_pojazdu", t => t.Model_pojazdu_IdModelu)
                .Index(t => t.Model_pojazdu_IdModelu);
            
            CreateTable(
                "dbo.Model_pojazdu",
                c => new
                    {
                        IdModelu = c.Int(nullable: false, identity: true),
                        Nazwa_Modelu = c.String(),
                        IdMarki = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdModelu);
            
            CreateTable(
                "dbo.Rodzajs",
                c => new
                    {
                        IdRodzaju = c.Int(nullable: false, identity: true),
                        Rodzajpojazdu = c.String(),
                    })
                .PrimaryKey(t => t.IdRodzaju);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tranzakcjas", "Osoba_IdOsoby", "dbo.Osobas");
            DropForeignKey("dbo.Sprzedawcas", "Tranzakcja_IdTranzakcji", "dbo.Tranzakcjas");
            DropForeignKey("dbo.Tranzakcjas", "PojazdID", "dbo.Pojazds");
            DropForeignKey("dbo.Pojazds", "IdRodzaju", "dbo.Rodzajs");
            DropForeignKey("dbo.Pojazds", "IdMarki", "dbo.Markas");
            DropForeignKey("dbo.Pojazds", "IdModelu", "dbo.Model_pojazdu");
            DropForeignKey("dbo.Markas", "Model_pojazdu_IdModelu", "dbo.Model_pojazdu");
            DropForeignKey("dbo.Tranzakcjas", "IdKlienta", "dbo.Klients");
            DropForeignKey("dbo.Sprzedawcas", "IdOsoby", "dbo.Osobas");
            DropForeignKey("dbo.Klients", "IdOsoby", "dbo.Osobas");
            DropIndex("dbo.Markas", new[] { "Model_pojazdu_IdModelu" });
            DropIndex("dbo.Pojazds", new[] { "IdRodzaju" });
            DropIndex("dbo.Pojazds", new[] { "IdModelu" });
            DropIndex("dbo.Pojazds", new[] { "IdMarki" });
            DropIndex("dbo.Tranzakcjas", new[] { "Osoba_IdOsoby" });
            DropIndex("dbo.Tranzakcjas", new[] { "PojazdID" });
            DropIndex("dbo.Tranzakcjas", new[] { "IdKlienta" });
            DropIndex("dbo.Sprzedawcas", new[] { "Tranzakcja_IdTranzakcji" });
            DropIndex("dbo.Sprzedawcas", new[] { "IdOsoby" });
            DropIndex("dbo.Klients", new[] { "IdOsoby" });
            DropTable("dbo.Rodzajs");
            DropTable("dbo.Model_pojazdu");
            DropTable("dbo.Markas");
            DropTable("dbo.Pojazds");
            DropTable("dbo.Tranzakcjas");
            DropTable("dbo.Sprzedawcas");
            DropTable("dbo.Osobas");
            DropTable("dbo.Klients");
        }
    }
}
