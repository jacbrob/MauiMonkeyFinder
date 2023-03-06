using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public partial class MonkeyService
{
    HttpClient httpClient;
    List<Monkey> monkeyList = new();

    public MonkeyService()
    {
        httpClient = new HttpClient();
    }

    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        var response = await httpClient.GetAsync("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json");
        if (response.IsSuccessStatusCode)
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();

        return monkeyList;
    }
}
