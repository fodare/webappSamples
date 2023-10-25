variable "resourceGroupName" {
  type        = string
  description = "Desired resource group name"
  default     = "test-rg"
}

variable "resourceLocation" {
  type        = string
  description = "Resource group location"
  default     = "westEurope"
}

variable "servicePlanName" {
  type        = string
  description = "Service plan name"
  default     = "test-sp"
}

variable "webappName" {
  type        = string
  description = "Desired web-app name"
}

variable "encryptionSecret" {
  description = "App encryption secret"
  type        = string
}
