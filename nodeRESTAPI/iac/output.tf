output "servicePlanDetails" {
  value = azurerm_service_plan.test_sp
}

output "webappDetails" {
  value     = azurerm_linux_web_app.test_webapp
  sensitive = true
}
