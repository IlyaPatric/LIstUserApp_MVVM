using LIstUserApp.Model;
using System.Collections.ObjectModel;
using LIstUserApp.Services;
using System.Diagnostics;
using LIstUserApp.View;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Runtime.InteropServices;

namespace LIstUserApp.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<User> Users { get; } = new();

    public Command GetUsersCommand { get; }
    public Command RefreshUser { get; }

    public MainViewModel(UserRepository userRepository)
    {
        GetUsersCommand = new Command(async () => await GetUsersAsync(), () => !IsBusy);
        RefreshUser = new Command(async () => await GetUsersAsync());
        GetUsersAsync().Wait();
    }

    


    [RelayCommand]
    async Task GoToDetailPageAsync(User user)
    {
        if (user is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true, new Dictionary<string, object>
        {
            {"User", user}
        });
    }

    [RelayCommand]
    void RemoveUser(User user)
    {
        UserRepository.DeleteUser(user);
        Users.Remove(user);
    }

    async Task GetUsersAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;      
            var users = UserRepository.GetAllUsers();

            if (Users.Count != 0)
                Users.Clear();

            foreach (var user in users)
                Users.Add(user);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"Error with api {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
