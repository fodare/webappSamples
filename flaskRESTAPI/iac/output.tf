output "service_plan_details" {
  value = azurerm_service_plan.sp
}

output "web_app_details" {
  value     = azurerm_linux_web_app.alwa
  sensitive = true
}
