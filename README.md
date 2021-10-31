# DisCatSharp.Hosting.ProjectTemplates

Supporting [DisCatSharp](https://github.com/Aiko-IT-Systems/DisCatSharp)'s library. These project templates serve as a starting point for 
creating your Discord bot(s) in C#!

## Web Host Bot (Class Library)
Allows you, the developer, to pick and choose which modules you'd like to include from [DisCatSharp](https://github.com/Aiko-IT-Systems/DisCatSharp) then sets up
the project for you.

This is a class library, meant to be added as a project reference for web-app projects. Add your Bot's namespace in the web host project, this will
allow you to use the extension methods provided in `ServiceCollectionExtensions` to add both the configuration file and bot.

## WIP: Web Host
Contains the skeleton of your typical web project. Adding support for MVC / API is in progress.

# Installation 

Run the following command in your terminal
```
dotnet new -i DisCatSharp.Hosting.ProjectTemplates
```
