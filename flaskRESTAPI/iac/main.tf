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
  features {
  }
}

resource "azurerm_resource_group" "test_rg" {
  name     = var.resource_group
  location = var.resource_group_location
}

resource "azurerm_service_plan" "sp" {
  name                = var.service_plan_name
  resource_group_name = azurerm_resource_group.test_rg.name
  location            = azurerm_resource_group.test_rg.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "alwa" {
  name                = var.service_plan_name
  resource_group_name = azurerm_resource_group.test_rg.name
  location            = azurerm_resource_group.test_rg.location
  service_plan_id     = azurerm_service_plan.sp.id
  site_config {
    always_on = false
    application_stack {
      python_version = "3.9"
    }
  }
  app_settings = {
    secret_key                     = var.secret_encryption
    SCM_DO_BUILD_DURING_DEPLOYMENT = true
  }

}
