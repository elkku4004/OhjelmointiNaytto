using System;
using System.Collections.Generic;
using System.Security;

namespace ohjelmointinäyttö
{
    class Program

    {

        static List<Käyttäjä> Käyttäjät = new List<Käyttäjä>();  // käyttäjä luokan lista

        static void Main(string[] args)
        {
            
                
                
                string syöte;
                Console.WriteLine("Anna komento:");
                Console.WriteLine("  - rekisteröi");
                Console.WriteLine("  - kirjaudu");
                Console.WriteLine("  - poistu");
                syöte = Console.ReadLine();
                    // Kun avaa konsolin, nämä tulevat näkyviin.
                    switch (syöte)
                    {
                        case "rekisteröi":
                            RekisteröiKäyttäjä();  // rekisteröi ohjeet
                            break;
                        case "kirjaudu":  // kirjaudu ohjeet
                            Kirjaudu();
                            break;
                        case "poistu":  
                        Poistu();   // poistu ohjeet

                            break;
                        default:
                                break;
                        // loopin endaus, vittu miten tää toimii perkele
                        {
                            break;
                        }

                    }
            

          

        }
        // Suorittaa kirjautumisen
        // Jos on oikea tunnus, kirjautuu sisään
        // Jos ei ole niin väärä salasana tai tunnus


        static void Kirjaudu()      // kirjaudu metodi aloitus
        {
            Console.Write("Käyttäjätunnus: ");
            string inputUsername = Console.ReadLine();

            Console.Write("Salasana: ");
            SecureString inputPassword = GetPassword();

            Console.WriteLine("Kirjauduit sisään");

            


        }

        static void RekisteröiKäyttäjä()  // käyttäjän rekisteröinti metodi
        {
            Console.Write("Anna Käyttäjätunnus: ");    // annetaan käyttäjätunnus
            string inputUsername = Console.ReadLine();

            Console.Write("Anna Salasana: ");  // Annetaan salasana
            SecureString inputPassword = GetPassword();

            Käyttäjä uusiKäyttäjä = new Käyttäjä();
            uusiKäyttäjä.KäyttäjäTunnus = inputUsername;  // uuden käyttäjän luominen

        }

        static void Poistu()
        {
            Console.Write("Poistu");
            
           
                // tähänki pitäs heittää ny jotai
        }

        static SecureString GetPassword()  // salasanan maskeeramis metodi securestring
        {
            var pwd = new SecureString();  // loopin aloitus
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)   // Jos painaa enter, lopettaa kirjoittamisen.
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)  // Jos painaa backspace niin menee yhden taaksepäin.
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }

                else if (i.KeyChar != '\u0000')
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");  // jos painaa jotain näppäintä, se muuttuu *.
                }
            }
            return pwd;
        }
    }
} 


// todo lista
// käyttäjien lista, Tiedostoon kirjoittaminen
// onko käyttäjätunnus ja salasana oikeat
// printtaa consoliin kaiken vaa kerran
// salasanan ja käyttäjätunnuksen minimerkkien määrä
// jos jaksaa ni "encrypted database" hommat