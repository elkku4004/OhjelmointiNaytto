﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;

namespace ohjelmointinäyttö
{
    class Program

    {

        static List<Käyttäjä> Käyttäjät = new List<Käyttäjä>();  // käyttäjä luokan lista
        static SqlConnection conn;

        static void Main(string[] args) 
        {
            ConnectDatabase();


            for (int i = 0; i <= 1; i++)
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
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("SELECT * Users VALUES ");

            string sqlQuery = strBuilder.ToString();

            using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
            {
                command.ExecuteNonQuery(); //Suorittaa Query
                Console.WriteLine("\nQuery suoritettu.");
            }

        }

        static void RekisteröiKäyttäjä()  // käyttäjän rekisteröinti metodi
        {
            Console.Write("Anna Käyttäjätunnus: ");    // annetaan käyttäjätunnus
            string inputUsername = Console.ReadLine();

            Console.Write("Anna Salasana: ");  // Annetaan salasana
            SecureString inputPassword = GetPassword();

            Käyttäjä uusiKäyttäjä = new Käyttäjä();
            uusiKäyttäjä.KäyttäjäTunnus = inputUsername;  // uuden käyttäjän luominen
            uusiKäyttäjä.Salasana = inputPassword;  // uuden käyttäjän luominen

            //create a new SQL Query using StringBuilder
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("INSERT INTO Users VALUES ");
            strBuilder.Append("('" + uusiKäyttäjä.KäyttäjäTunnus + "','" + uusiKäyttäjä.Salasana + "','" + DateTime.Now.ToString() +"');");

            string sqlQuery = strBuilder.ToString();

            using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
            {
                command.ExecuteNonQuery(); //Suorittaa queryn
                Console.WriteLine("\nQuery Executed.");
            }
        }

        static void Poistu()
        {
            Console.Write("Poistutaan");
            //Thread.Sleep(1000); // Jos halutaan että käyttäjä ehtii nähä "Poistutaan" viestin
            System.Environment.Exit(0);
        }

        static void ConnectDatabase()
        {
            Console.WriteLine("Getting Connection...");

            var datasource = @"STUDY21P-104827\SQLEXPRESS";// SQL palvelimen sijainti
            var database = "Ohjelmointi"; //Tietokannan nimi

            //your connection string 
            string connString = @"Server=" + datasource + ";Database="
                        + database + ";Trusted_Connection=SSPI;Encrypt=False;TrustServerCertificate=true";

            //create instanace of database connection
            conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Opening Connection...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection Successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while opening connection. Info: " + e.Message);
            }
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
// onko käyttäjätunnus ja salasana oikeat
// printtaa consoliin kaiken vaa kerran
// salasanan ja käyttäjätunnuksen minimerkkien määrä
// vittu saatana miksi kirjautuminen ei toimi paska kieli
