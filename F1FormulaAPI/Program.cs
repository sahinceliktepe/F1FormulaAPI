
using Newtonsoft.Json;
using System.Text;

HttpClient client = new HttpClient();

while (true)
{
    Console.Clear();

    Console.Write("Year : ");
    string year = Console.ReadLine();


    Console.Write("Round : ");
    string round = Console.ReadLine();

    Console.WriteLine("");

    await GetRaceResults(year, round);

    Console.WriteLine(new string('-', 100));

    Console.Write("Please press the enter !!!");
    Console.ReadKey();
    
}

async Task GetRaceResults(string year, string round)
{
    try
    {
        string response = await client.GetStringAsync($"http://ergast.com/api/f1/{ year }/{ round }/results.json");

        RaceResult result = JsonConvert.DeserializeObject<RaceResult>(response);

        if (result.MRData.RaceTable.Races.Length == 0)
        {
            Console.WriteLine("No race for this year or this round");
            return;
        }

        Console.WriteLine($"{"Pos",-5} {"Number",-8} {"Driver",-20} {"Constructor",-15} {"Laps",-5} {"Grid",-5}  {"Status", -10} {"Points", 10}");
        RaceResult.MRDataTemplate.RaceTableTemplate.RacesTemplate[] races = result.MRData.RaceTable.Races;
        for (int i = 0; i < races.Length; i++)
        {
            RaceResult.MRDataTemplate.RaceTableTemplate.RacesTemplate.ResultsTemplate[] results = races[i].Results;
            for (int j = 0; j < results.Length; j++)
            {
                if (j == 3) { break; }

                string position = results[j].position;
                string number = results[j].number;
                string driver = results[j].Driver.givenName + " " + results[j].Driver.familyName;
                string constructor = results[j].Constructor.name;
                string laps = results[j].laps;
                string grid = results[j].grid;
                string status = results[j].status;
                string points = results[j].points;

                Console.WriteLine($"{position,-5} {number,-8} {driver,-20} {constructor,-15} {laps,-5} {grid,-5} {status,-10} {points,10}");
            }
        }
    }
    catch
    {
        Console.WriteLine("Please type a valid year and round");
    }
}

