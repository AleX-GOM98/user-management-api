terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
  }

  required_version = ">= 1.3.0"
}

provider "aws" {
  region = var.aws_region

  # Obtém as credenciais da AWS a partir do perfil configurado no ambiente local
  shared_credentials_files = ["~/.aws/credentials"]
  profile                  = var.aws_profile
}
