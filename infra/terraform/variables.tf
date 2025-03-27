variable "aws_region" {
  description = "Região onde os recursos serão criados"
  type        = string
  default     = "us-east-1"
}

variable "aws_profile" {
  description = "Perfil AWS configurado no arquivo de credenciais (~/.aws/credentials)"
  type        = string
  default     = "default"
}
