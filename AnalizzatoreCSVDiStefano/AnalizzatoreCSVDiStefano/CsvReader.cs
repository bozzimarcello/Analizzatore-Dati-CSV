using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AnalizzatoreCSVDiStefano
{
    internal class CsvReader
    {
        public static List<Record> ReadFromFile(string fileName)
        {
            List<Record> countryList = new List<Record>();

            try
            {

                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                StreamReader fileReader = new StreamReader(fileStream);

                //Prima iterazione (non ignora virgolette)

                /*if (!fileReader.EndOfStream)
                {
                    fileReader.ReadLine();
                }

                while (!fileReader.EndOfStream)
                {
                    string row = fileReader.ReadLine();

                    string[] cells = row.Split(',');

                    Record newCountry = new Record();

                    newCountry.Country = cells[0];
                    newCountry.ActiveMilitary = cells[1];
                    newCountry.ReserveMilitary = cells[2];
                    newCountry.Paramilitary = cells[3];
                    newCountry.Total = cells[4];
                    newCountry.PerThousandTotal = cells[5];
                    newCountry.PerThousandActive = cells[6];

                    countryList.Add(newCountry);
                }*/

                //Seconda iterazione (scartata, libreria già fatta)

                /*using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    if (!parser.EndOfData)
                        parser.ReadLine();

                    while (!parser.EndOfData)
                    {
                        string[] cells = parser.ReadFields();

                        Record newCountry = new Record
                        {
                            Country = cells[0],
                            ActiveMilitary = cells[1],
                            ReserveMilitary = cells[2],
                            Paramilitary = cells[3],
                            Total = cells[4],
                            PerThousandTotal = cells[5],
                            PerThousandActive = cells[6]
                        };

                        countryList.Add(newCountry);
                    }
                }*/

                if (!fileReader.EndOfStream)
                {
                    fileReader.ReadLine();
                }

                while (!fileReader.EndOfStream)
                {
                    string row = fileReader.ReadLine();

                    string[] cells;

                    cells = ParseCSV(row);

                    Record newCountry = new Record();

                    newCountry.Country = cells[0];
                    newCountry.ActiveMilitary = cells[1];
                    newCountry.ReserveMilitary = cells[2];
                    newCountry.Paramilitary = cells[3];
                    newCountry.Total = cells[4];
                    newCountry.PerThousandTotal = cells[5];
                    newCountry.PerThousandActive = cells[6];

                    countryList.Add(newCountry);
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Errore: Il file specificato non esiste. Verifica il percorso.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: Formato dei dati non valido. Controlla il file CSV.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }

            return countryList;
        }

        public static string[] ParseCSV(string line)
        {
            // dentro line potrebbe esserci:
            // 4,Carlo,Neri,"Nota: questo campo, contiene virgole, e punti e virgola;",20.7,2026-01-04

            string[] cells;

            // body
            if (line.IndexOf('"') == -1)
            {
                cells = line.Split(',');
            }
            else
            {
                //Realizzato grazie ad AI, 40 min passati a cercare fix
                List<string> result = new List<string>();
                string current = "";
                bool insideQuotes = false;

                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];

                    if (c == '"')
                    {
                        insideQuotes = !insideQuotes;
                    }
                    else if (c == ',' && !insideQuotes)
                    {
                        result.Add(current);
                        current = "";
                    }
                    else
                    {
                        current += c;
                    }
                }

                result.Add(current);
                cells = result.ToArray();
            }

            return cells;
        }
    }
}
