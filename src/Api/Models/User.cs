namespace UserManagementApi.Models
{
    public class User
    {
        public required string Id { get; set; }    // ID do usuário, será a chave primária no DynamoDB
        public required string Name { get; set; }  // Nome do usuário
        public required string Email { get; set; } // E-mail do usuário
        public DateTime CreatedAt { get; set; } // Data de criação
    }
}
