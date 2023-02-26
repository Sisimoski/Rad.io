# Rad.io

A multiplatform app that lets you play radio stations from your desktop or phone.

# Run Mac Catalyst App

`dotnet build -t:Run -f net7.0-maccatalyst`

# Run iOS App on iPhone 14 Pro Simulator

For example:

`dotnet build -t:Run -f net7.0-ios -p:_DeviceName=:v2:udid=7EAB42EA-A6D7-4568-BD4C-3F94C58E7CBA`
