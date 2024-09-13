using System.Net.Http.Json;

namespace MonkeyFinderHybrid.Services;

public class MonkeyService
{
    private List<Monkey> monkeyList = new();

    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList.Count > 0)
        {
            return monkeyList;
        }

        var response = await httpClient.GetAsync("https://montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            var resultMonkeys = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);

            if (resultMonkeys is not null)
            {
                monkeyList = resultMonkeys;
            }
        }

        return monkeyList;
    }

    private readonly HttpClient httpClient;

    public MonkeyService()
    {
        httpClient = new HttpClient();
    }
}