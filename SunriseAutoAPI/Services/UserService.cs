using Models;
using MongoDB.Driver;
using SunriseAutoAPI.DatabaseSettings;
using System.Collections.Generic;

namespace SunriseAutoAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<User> Get() => _users.Find<User>(user => true).ToList();

        public User Get(string cpf) => _users.Find<User>(user => user.CPF == cpf).FirstOrDefault();

        public User Replace(string cpf, User userIn)
        {
            var user = Get(cpf);
            if (user == null) return null;

            _users.ReplaceOne(user => user.CPF == cpf, userIn);
            return userIn;
        }
    }
}
