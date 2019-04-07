namespace komis.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Drawing;
    using System.IO;


    internal sealed class Configuration : DbMigrationsConfiguration<komis.BazaKontekst>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        public byte[] ImageToByteJpeg(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public byte[] ImageToBytePng(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        protected override void Seed(komis.BazaKontekst context)
        {

            //  This method will be called after migrating to the latest version.


            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // context.Klienci.AddOrUpdate(
            // new Klient { }
            //   );

               /*  context.Marki.AddOrUpdate(
                      new Marka { Nazwa_Marki = "Mazda" },
                      new Marka { Nazwa_Marki = "Audi" },
                      new Marka { Nazwa_Marki = "Honda" },
                      new Marka { Nazwa_Marki= "Fendt" },
                      new Marka { Nazwa_Marki = "Kwasaki"},
                      new Marka { Nazwa_Marki = "KTM"},
                      new Marka { Nazwa_Marki = "Irizar" } //7
                      );
            */
             /* context.Rodzaje.AddOrUpdate(
                    new Rodzaj { Rodzajpojazdu = "Samochod" },
                    new Rodzaj { Rodzajpojazdu = "Motocykl" },
                    new Rodzaj { Rodzajpojazdu = "Traktor" },
                    new Rodzaj { Rodzajpojazdu = "Autokar"}
                    );
            
             /*  context.Osoby.AddOrUpdate(
                    new Osoba { Imie = "Leokadia", Nazwisko = "Maj", Miasto = "Dobre miasto", E_mail = "l.maj@o2.pl", Data_Urodzenia = new DateTime(1985, 04, 12), Pesel = 85041245776, Kod_pocztowy = "11-040", Nr_telefonu = 500467822, Nr_domu = 5, Nr_mieszkania = 4, Ulica = "Lotnikow", Nr_dowodu = "DBN475214"},
                    new Osoba { Imie = "Mariusz", Nazwisko = "Konieczny", Miasto = "Lysomice", E_mail = "m.konieczny@o2.pl", Data_Urodzenia = new DateTime(1967, 01, 15), Pesel = 67011544465, Kod_pocztowy = "87-148", Nr_telefonu = 660467215, Nr_domu = 6, Nr_mieszkania = 1, Ulica = "Warszawska", Nr_dowodu = "BHN457635"},
                    new Osoba { Imie = "Mariola", Nazwisko = "Andrzejczyk", Miasto = "Rumia", E_mail = "m.andrzejczyk@o2.pl", Data_Urodzenia = new DateTime(1991, 03, 08), Pesel = 91030855110, Kod_pocztowy = "84-230", Nr_telefonu = 642546821, Nr_domu = 1, Nr_mieszkania = 14, Ulica = "Akacjowa", Nr_dowodu = "MHL546222"},
                    new Osoba { Imie = "Andrzej", Nazwisko = "Jakubowski", Miasto = "Torun", E_mail = "a.jakubowski@o2.pl", Data_Urodzenia = new DateTime(1969, 02, 14), Pesel = 69021455769, Kod_pocztowy = "87-109", Nr_telefonu = 642546221, Nr_domu = 20, Nr_mieszkania = 4, Ulica = "Koniuchy", Nr_dowodu = "AMK568421"},
                    new Osoba { Imie = "Marcelina", Nazwisko = "Zawadzka", Miasto = "Torun", E_mail = "m.zawadzka@o2.pl", Data_Urodzenia = new DateTime(1979, 06, 10), Pesel = 79061035912, Kod_pocztowy = "87-119", Nr_telefonu = 692486324, Nr_domu = 36, Nr_mieszkania = 1, Ulica = "Wroclawska", Nr_dowodu = "AMK454815" }
                    );
              /*  
               context.Klienci.AddOrUpdate(
                    new Klient { IdOsoby = 1},
                    new Klient { IdOsoby = 2},
                    new Klient { IdOsoby = 3},
                    new Klient { IdOsoby = 5}
                    );
                /*
                context.Sprzedawcy.AddOrUpdate(
                    new Sprzedawca { IdOsoby = 4},
                    new Sprzedawca { IdOsoby = 5}
                    );

            /*    context.Modele_pojazdu.AddOrUpdate(
                    new Model_pojazdu { Nazwa_Modelu = "323F", IdMarki = 1},
                    new Model_pojazdu { Nazwa_Modelu = "R8", IdMarki = 2},
                    new Model_pojazdu {Nazwa_Modelu = "NSX", IdMarki = 3},
                    new Model_pojazdu { Nazwa_Modelu = "CBR 650F", IdMarki = 3},
                    new Model_pojazdu { Nazwa_Modelu = "930 VARIO", IdMarki = 4},
                    new Model_pojazdu { Nazwa_Modelu = "Ninja", IdMarki = 5},
                    new Model_pojazdu { Nazwa_Modelu = "250 SXF", IdMarki = 6},
                    new Model_pojazdu { Nazwa_Modelu = "I6", IdMarki = 7}
                    );
                 /*
                Image a323f2003Image = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\323f2003.jpg");
                Image a323fbgImage = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\323fbg.jpg");
                Image cbrImage = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\cbr.jpg");
                Image frendtImage = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\frendt.jpg");
                Image izidarImage = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\izidar.jpg");
                Image ktmImage = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\ktm.jpg");
                Image nsxImage = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\nsx.jpg");
                Image r8Image = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\r8.jpg");
                Image ninjaImage = Image.FromFile("C:\\Users\\panda\\Desktop\\komiszdj\\ninja.jpg");



                context.Pojazdy.AddOrUpdate(
                    new Pojazd { IdMarki = 1, IdModelu = 1, IdRodzaju = 1, Rok_produkcji = 2003, Przebieg =  280000, Data_rejestracji = new DateTime(2005, 04, 01), Data_przyjecia = new DateTime(2016, 06, 25), Zdjecie = ImageToByteJpeg(a323f2003Image), Pojemnoœæ_silnika = 2000, Powypadkowy = false, Cena = 4600.0M, Rezerwacja = false, Data_wydania= DateTime.Now},
                    new Pojazd { IdMarki = 1, IdModelu = 1, IdRodzaju = 1, Rok_produkcji = 1991, Przebieg = 239000, Data_rejestracji = new DateTime(1992, 02, 07), Data_przyjecia = new DateTime(2016, 04, 24), Zdjecie = ImageToByteJpeg(a323fbgImage), Pojemnoœæ_silnika = 1600, Powypadkowy = false, Cena = 1400.0M, Rezerwacja = false, Data_wydania = DateTime.Now },
                    new Pojazd { IdMarki = 2, IdModelu = 2, IdRodzaju = 1, Rok_produkcji = 2016, Przebieg = 18000, Data_rejestracji = new DateTime(2017, 02, 07), Data_przyjecia = new DateTime(2017, 04, 05), Zdjecie = ImageToByteJpeg(r8Image), Pojemnoœæ_silnika = 5200, Powypadkowy = false, Cena = 527000.0M, Rezerwacja = true, Data_wydania = DateTime.Now },
                    new Pojazd { IdMarki = 3, IdModelu = 3, IdRodzaju = 1, Rok_produkcji = 2017, Przebieg = 11000, Data_rejestracji = new DateTime(2017, 02, 15), Data_przyjecia = new DateTime(2017, 04, 06), Zdjecie = ImageToByteJpeg(nsxImage), Pojemnoœæ_silnika = 3500, Powypadkowy = false, Cena = 1028000.0M, Rezerwacja = false, Data_wydania = DateTime.Now },
                    new Pojazd { IdMarki = 3, IdModelu = 4, IdRodzaju = 2, Rok_produkcji = 2015, Przebieg = 6800, Data_rejestracji = new DateTime(2016, 01, 25), Data_przyjecia = new DateTime(2017, 05, 06), Zdjecie = ImageToByteJpeg(cbrImage), Pojemnoœæ_silnika = 650, Powypadkowy = false, Cena = 21000.0M, Rezerwacja = true, Data_wydania = DateTime.Now },
                    new Pojazd { IdMarki = 4, IdModelu = 5, IdRodzaju = 3, Rok_produkcji = 2011, Przebieg = 800, Data_rejestracji = new DateTime(2012, 11, 22), Data_przyjecia = new DateTime(2016, 04, 07), Zdjecie = ImageToByteJpeg(frendtImage), Pojemnoœæ_silnika = 330, Powypadkowy = false, Cena = 312000.0M, Rezerwacja = false, Data_wydania = DateTime.Now },
                    new Pojazd { IdMarki = 5, IdModelu = 6, IdRodzaju = 2, Rok_produkcji = 2007, Przebieg = 11000, Data_rejestracji = new DateTime(2008, 10, 03), Data_przyjecia = new DateTime(2017, 05, 08), Zdjecie = ImageToByteJpeg(ninjaImage), Pojemnoœæ_silnika = 998, Powypadkowy = false, Cena = 24999.0M, Rezerwacja = false, Data_wydania = DateTime.Now },
                    new Pojazd { IdMarki = 6, IdModelu = 7, IdRodzaju = 2, Rok_produkcji = 2014, Przebieg = 140, Data_rejestracji = new DateTime(2015, 07, 07), Data_przyjecia = new DateTime(2016, 04, 02), Zdjecie = ImageToByteJpeg(ktmImage), Pojemnoœæ_silnika = 250, Powypadkowy = false, Cena = 19999.0M, Rezerwacja = false, Data_wydania = DateTime.Now },
                    new Pojazd { IdMarki = 7, IdModelu = 8, IdRodzaju = 4, Rok_produkcji = 2014, Przebieg = 287700, Data_rejestracji = new DateTime(2016, 04, 02), Data_przyjecia = new DateTime(2017, 07, 03), Zdjecie = ImageToByteJpeg(izidarImage), Pojemnoœæ_silnika = 12902, Powypadkowy = false, Cena = 1146800.0M, Rezerwacja = false, Data_wydania = DateTime.Now }
                    );
                
                /*
            context.Tranzakcje.AddOrUpdate(
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 1, IdKlienta = 2, PojazdID = 1, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = new DateTime(2016, 06, 25), Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 2, IdKlienta = 2, PojazdID = 2, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = new DateTime(2016, 04, 24), Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 2, IdKlienta = 2, PojazdID = 3, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = new DateTime(2017, 04, 05), Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 2, IdKlienta = 2, PojazdID = 4, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = new DateTime(2017, 04, 06), Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 1, IdKlienta = 2, PojazdID = 5, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = new DateTime(2017, 05, 06), Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 1, IdKlienta = 2, PojazdID = 6, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = new DateTime(2016, 04, 07), Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 1, IdKlienta = 2, PojazdID = 7, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = new DateTime(2017, 05, 08), Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 2, IdKlienta = 2, PojazdID = 8, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = new DateTime(2016, 04, 02), Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Kupno", IdSprzedawcy = 1, IdKlienta = 1, PojazdID = 9, Sposob_p³atnoœci = "Gotowka", Data_tranzakcji = DateTime.Now, Zap³acono = true },
                new Tranzakcja { Rodzaj_tranzakcji = "Sprzedaz", IdSprzedawcy = 2, IdKlienta = 4, PojazdID = 3, Data_tranzakcji = DateTime.Now, Zap³acono = false },
                new Tranzakcja { Rodzaj_tranzakcji = "Sprzedaz", IdSprzedawcy = 1, IdKlienta = 3, PojazdID = 5, Data_tranzakcji = new DateTime(2017, 06, 01), Zap³acono = false }
                );*/
        }
    }
}
