using LIstUserApp.Model;
using Newtonsoft.Json;

namespace LIstUserApp.Services
{
    public class UserService
    {
        HttpClient HttpClient;
        public UserService()
        {
            HttpClient = new HttpClient();
        }

        List<User> users = new ();

        public async Task<List<User>> GetUsers()
        {
            if (users?.Count > 0)
                return users;

            var url = "https://fakerapi.it/api/v1/persons?_locale=ru_RU";

            var response = await HttpClient.GetStringAsync(url);

            dynamic data = JsonConvert.DeserializeObject(response);

            int id = 0;

            foreach ( var item in data.data)
            {
                users.Add(new User(
                    (string)item.firstname,
                    (string)item.lastname,
                    item.birthday.ToString("dd/MM/yyyy"),
                    "http://placeimg.com/640/480/people",
                    id
                ));

                id++;
            }

            return users;
        }

        /*using var stream = await FileSystem.OpenAppPackageFileAsync("users.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        List<User> users = new ();
        users = JsonConvert.DeserializeObject<List<User>>(contents);*/
    }
}
