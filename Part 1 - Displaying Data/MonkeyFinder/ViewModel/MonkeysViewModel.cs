namespace MonkeyFinder.ViewModel;
using MonkeyFinder.Services;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService _monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        _monkeyService = monkeyService;
    }

    [RelayCommand]
    private async Task GetMonkeyAsync()
    {
        if(IsBusy)
            return;
        try
        {
            IsBusy = true;
            var monkeys = await _monkeyService.GetMonkeys();
            if(Monkeys.Count != 0)
                Monkeys.Clear();
            foreach(var monkey in monkeys)
                Monkeys.Add(monkey); // better to have an observable collection that can do batch notifications
        }
        catch(Exception ex)
        {
            // TODO: decouple the view model from the view by imeplementing a service that can display alerts
            await Shell.Current.DisplayAlert("Error!",$"Unable to get monkeys: {ex.Message}", "OK");

        }
        finally
        {
            IsBusy = false;
        }
    }
}
