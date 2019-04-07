using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komis
{
    public class BazaKontekst : DbContext //Reszta zgodnie z tutorialem
    {
        public DbSet<Pojazd> Pojazdy { get; set; }
        public DbSet<Marka> Marki { get; set; }
        public DbSet<Model_pojazdu> Modele_pojazdu { get; set; }
        public DbSet<Rodzaj> Rodzaje { get; set; }
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Sprzedawca> Sprzedawcy { get; set; }
        public DbSet<Tranzakcja> Tranzakcje { get; set; }
    }

    public class Pojazd
    {
        [Key]
        public int PojazdID { get; set; }
        public int IdMarki { get; set; }
        public virtual Marka Marka { get; set; }
        public int IdModelu { get; set; }
        public virtual Model_pojazdu Model_pojazdu { get; set; }
        public int IdRodzaju { get; set; }
        public virtual Rodzaj Rodzaj { get; set; }
        public int Rok_produkcji { get; set; }
        public long Przebieg { get; set; }
        public DateTime Data_rejestracji { get; set; }
        public DateTime Data_przyjecia { get; set; }
        public DateTime Data_wydania { get; set; }
        public byte[] Zdjecie { get; set; }
        public int Pojemność_silnika { get; set; }
        public bool Powypadkowy { get; set; }
        public decimal Cena { get; set; }
        public bool Rezerwacja { get; set; }

        public virtual List<Tranzakcja> Tranzakcje { get; set; }
    }

    
    public class Marka 
    {
        [Key]
        public int IdMarki { get; set; }
        public string Nazwa_Marki { get; set; }

        public virtual List<Pojazd> Pojazdy { get; set; }
        public virtual Model_pojazdu Model_pojazdu { get; set; }

    }
    public class Model_pojazdu
    {
        [Key]
        public int IdModelu { get; set; }
        public string Nazwa_Modelu { get; set; }
        public int IdMarki { get; set; }
        public virtual List<Marka> Marki { get; set; }


        public virtual List<Pojazd> Pojazdy { get; set; }

    }


    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }
        public string Rodzajpojazdu { get; set; }

        public virtual List<Pojazd> Pojazdy { get; set; }
    }

    public class Osoba
    {
        [Key]
        public int IdOsoby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public long Pesel { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public int Nr_mieszkania { get; set; }
        public int Nr_domu { get; set; }
        public DateTime Data_Urodzenia { get; set; }
        public long Nr_telefonu { get; set; }
        public string E_mail { get; set; }
        public string Nr_dowodu { get; set; }

        public virtual List<Tranzakcja> Tranzakcje { get; set; } //niepotrzebne już?
        public virtual List<Klient> Klienci { get; set; }
        public virtual List<Sprzedawca> Sprzedawcy { get; set; }

    }

    public class Klient
    {
        [Key]
        public int IdKlienta { get; set; }
        public int IdOsoby { get; set; }
        public virtual Osoba Osoba { get; set; }

        public virtual List<Tranzakcja> Tranzakcje { get; set; }
    }

    public class Sprzedawca
    {
        [Key]
        public int IdSprzedawcy { get; set; }
        public int IdOsoby { get; set; }
        public virtual Osoba Osoba { get; set; }

        public virtual Tranzakcja Tranzakcja { get; set; }
    }

    public class Tranzakcja
    {
        [Key]
        public int IdTranzakcji { get; set; }
        public string Rodzaj_tranzakcji { get; set; }
        public int IdSprzedawcy { get; set; }
        public virtual List<Sprzedawca> Sprzedawcy { get; set; }
        public int IdKlienta { get; set; }
        public virtual Klient Klient { get; set; }
        public int PojazdID { get; set; }
        public virtual Pojazd Pojazd { get; set; }
        public string Sposob_płatności { get; set; }
        public DateTime Data_tranzakcji { get; set; }
        //  public Pojazd Cena { get; set; } 
        public bool Zapłacono { get; set; }
        //Collection navigation property
        //public IList<Pojazd> Pojazdy { get; set; }

    }
}
