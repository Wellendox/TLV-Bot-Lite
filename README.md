# A lite version of my TLV Bot.

This Bot does **not** have:
- a database access
- cronjobs
- a REST API
- a GraphQL Integration
- a Web-Dashboard
- Music-Bot features

## **I am open to showing source code of the previous mentioned services upon inquiry. They do exist in my private repository for the full TLV Bot**

This is simply for my CV, and can be used for educational purposes for those who are interested in getting started with Discord Bot development simply by browsing through the code.


# Setup
## appsettings.json / appsettings.Development.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Discord": {
    "Name": "",
    "Token": "",
    "AppId": "",
    "AppSecret": ""
  },
  "AllowedHosts": "*"
}

```
## Create an Application + Bot in the Discord Developer Dashboard
[That can be done here](https://discord.com/developers/applications)

Use the Token / App secret / App id in the appsettings, and then simply use TLVBot as the startup project. Voilà!
