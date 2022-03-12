# DisCatSharp.ProjectTemplates
These project templates serve as a starting point for creating your Discord bot(s) in C#! 

## Web Host Bot (Class Library)
Allows you, the developer, to pick and choose which modules you'd like to include from [DisCatSharp](https://github.com/Aiko-IT-Systems/DisCatSharp) then sets up
the project for you.

This is a class library, meant to be added as a project reference for hosted projects. Add your Bot's namespace in the web host project, this will
allow you to use the extension methods provided in `ServiceCollectionExtensions` to add both the configuration file and bot.

## Web Host
Contains the skeleton of your typical web project.

Converting Microsoft's Web Project template to have DCS as well is a low-priority WIP. For those waiting for this, or need it, please open an issue for it. If enough community interest is there we can allocate more resources towards getting it completed.

# **Important** 
Rider currently **DOES NOT** support parameters in custom projects. So unfortunately, anyone who wants to use these templates with Rider
will need to utilize the command line...

To view the available parameters for the Bot Template, please use this command
```
dotnet new DCSWebHostBot --help
```
