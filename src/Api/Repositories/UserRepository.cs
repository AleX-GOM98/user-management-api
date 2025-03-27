using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using UserManagementApi.Models;

namespace UserManagementApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AmazonDynamoDBClient _dynamoDbClient;
        private readonly DynamoDBContext _context;
        private const string TableName = "users-table"; // Alterado para o nome correto da tabela

        public UserRepository()
        {
            _dynamoDbClient = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_dynamoDbClient);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.SaveAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var scanResults = await _context.ScanAsync<User>(new List<ScanCondition>()).GetRemainingAsync();
            return scanResults;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.LoadAsync<User>(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _context.SaveAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _context.DeleteAsync<User>(id);
        }
    }
}
