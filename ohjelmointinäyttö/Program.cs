using System;
using System.Security;

namespace ohjelmointinäyttö
{
    class Program

    {
        static void Main(string[] args)
        {
            while (true)
            {

                string syöte;
                Console.WriteLine("Anna komento:");
                Console.WriteLine("  - rekisteröi");
                Console.WriteLine("  - kirjaudu");
                Console.WriteLine("  - poistu");
                syöte = Console.ReadLine();

                switch (syöte)
                {
                    case "rekisteröi":

                        break;
                    case "kirjaudu":

                        break;
                    case "poistu":
                        
                        break;
                    default:
                        break;
                }
            }

            Console.Write("Käyttäjätunnus: ");
            string inputUsername = Console.ReadLine();

            Console.Write("Salasana: ");
            SecureString inputPassword = GetPassword();

        }
        // Suorittaa kirjautumisen
        // Jos on oikea tunnus, kirjautuu sisään
        // Jos ei ole niin väärä salasana tai tunnus


        static void Kirjaudu()
        {

        }

        static void RekisteröiKäyttäjä()
        {

        }

        static SecureString GetPassword()
        {
            var pwd = new SecureString();
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


