resource "aws_dynamodb_table" "users_table" {
  name           = "users-table"
  billing_mode   = "PROVISIONED"
  read_capacity  = 5
  write_capacity = 5

  hash_key       = "UserId" # A chave primária (alterar conforme necessário)
  range_key      = "Email"  # A chave de ordenação (opcional)

  attribute {
    name = "UserId"
    type = "S"
  }

  attribute {
    name = "Email"
    type = "S"
  }

  # Definindo índice global (GSI) para o atributo Email
  global_secondary_index {
    name               = "Email-index"
    hash_key           = "Email"
    projection_type    = "ALL"  # Projeção dos atributos no índice
    read_capacity      = 5
    write_capacity     = 5
  }
}
