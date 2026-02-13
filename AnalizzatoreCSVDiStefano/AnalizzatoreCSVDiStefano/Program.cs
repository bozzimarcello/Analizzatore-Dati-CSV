using AnalizzatoreCSVDiStefano;

List<Record> countryList = new List<Record>();

countryList = CsvReader.ReadFromFile("C:\\List_of_countries_by_number_of_military_and_paramilitary_personnel_2023.csv");

foreach (Record p in countryList)
{
    Console.WriteLine(" Country: " + p.Country +
                      "\n Active military: " + p.ActiveMilitary +
                      "\n Reserve military: " + p.ReserveMilitary +
                      "\n Paramilitary: " + p.Paramilitary +
                      "\n Total: " + p.Total +
                      "\n Per 1000 heads (total): " + p.PerThousandTotal +
                      "\n Per 1000 heads (active): " + p.PerThousandActive);

    Console.WriteLine("---------------");
}