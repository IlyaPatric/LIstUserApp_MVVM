using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LIstUserApp.Model;

namespace LIstUserApp.ViewModel;

[QueryProperty(nameof(User), "User")]
public partial class DetailsViewModel : BaseViewModel
{
    /*User user;

    public User User
    {
        get => user;
        set
        {
            user = UserRepository.GetUserById(value);
        }
    }*/

    [ObservableProperty]
    User user;

    readonly ErrorsViewModel errorViewModel;

    public DetailsViewModel()
    {
    }

    [RelayCommand]
    async void SaveData(User user)
    {
        UserRepository.UpdateUser(user);
        await Shell.Current.GoToAsync("../");
    }
}
