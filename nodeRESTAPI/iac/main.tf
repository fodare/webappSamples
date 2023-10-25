terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.0.0"
    }
  }
}

provider "azurerm" {
  skip_provider_registration = true
  features {}
}

resource "azurerm_resource_group" "test_rg" {
  name     = var.resourceGroupName
  location = var.resourceLocation
}

resource "azurerm_service_plan" "test_sp" {
  name                = var.servicePlanName
  resource_group_name = azurerm_resource_group.test_rg.name
  location            = azurerm_resource_group.test_rg.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "test_webapp" {
  name                = var.webappName
  resource_group_name = azurerm_resource_group.test_rg.name
  location            = azurerm_resource_group.test_rg.location
  service_plan_id     = azurerm_service_plan.test_sp.id
  site_config {
    always_on = false
    application_stack {
      node_version = "16-lts"
    }
  }
  app_settings = {
    PORT                           = 3000
    SECRET                         = var.encryptionSecret
    SALT_ROUNDS                    = 10
    SCM_DO_BUILD_DURING_DEPLOYMENT = true
  }
}
