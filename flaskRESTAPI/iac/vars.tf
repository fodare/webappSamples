variable "resource_group" {
  description = "Respurce group name"
  type        = string
}

variable "resource_group_location" {
  description = "Resource group location"
  type        = string
  default     = "westeurope"
}

variable "service_plan_name" {
  description = "Desired service plan name"
  type        = string
}

variable "web_app_name" {
  type        = string
  description = "Web app name"
}

variable "secret_encryption" {
  description = "Application encyption secret key"
  type        = string
}
