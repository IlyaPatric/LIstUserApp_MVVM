using LIstUserApp.Services;
using System.Diagnostics;

namespace LIstUserApp.Model;

public class UserRepository
{
    static UserService userService;

    static List<User> _users { get; set; } = new ();

    public UserRepository(UserService service)
    {
        userService = service;

        _ = GetAllUsersFromApi();
    }

    public static async Task GetAllUsersFromApi()
    {
        try
        {
            var users = await userService.GetUsers();

            foreach (var user in users)
                _users.Add(user);
        }
        catch(Exception ex) {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"Error with api - {ex.Message}", "OK");
        }
    }

    public static List<User> GetAllUsers() => _users;

    public static User GetUserById(User user) =>  _users.FirstOrDefault(_user => _user.Id == user.Id);

    public static void UpdateUser(User user)
    {
        var userOnUpdate = GetUserById(user);
        if (userOnUpdate != null)
        {
            userOnUpdate.FirstName = user.FirstName;
            userOnUpdate.SecondName = user.SecondName;
            userOnUpdate.Birthday = user.Birthday;

            _users[user.Id] = userOnUpdate;
        }
    }

    public static void DeleteUser(User user)
    {
        if (user is null)
            return;

        _users.Remove(user);
    }

    public static void InsertUser(User user) 
    { 
        if (user is null)
            return;

        user.Id = _users.Count;
        _users.Add(user);
    }
}
