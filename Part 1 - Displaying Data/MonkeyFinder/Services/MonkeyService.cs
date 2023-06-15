using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    HttpClient _httpClient;

    public MonkeyService()
    {
        _httpClient = new HttpClient();
    }

    List<Monkey> _monkeyList = new();
    public async Task<List<Monkey>> GetMonkeys()
    {
        if(_monkeyList?.Count>0)
            return _monkeyList;

        // if there the monky list is empty, get the monkeys from the url https://montemagno.com/monkeys.json
        var url = "https://montemagno.com/monkeys.json";
        var response = await _httpClient.GetAsync(url);
        if(response.IsSuccessStatusCode)
        {
            _monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }
        return _monkeyList;
    }
}
