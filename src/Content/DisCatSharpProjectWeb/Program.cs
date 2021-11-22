var builder = WebApplication
    .CreateBuilder(args);

/*
    Please note you can tweak this as you see fit...
    You don't HAVE to use any of the environment variables
    or user-secrets if you don't want to
 * /

/*
    Perhaps in deployment you're setting an environment variable for the token
    Or you just want to load certain things from environment.... 
 */
builder.Configuration.AddEnvironmentVariables();

#if (IncludeBot)
builder.Configuration.AddDisCatSharpProjectBotConfiguration();
#endif
//builder.Services.AddBotConfiguration();

/* 
    Ideally your Discord Token should be stored outside of your project (not in source control)
    One way of doing that in C# is via user-secrets.
    
    If you wish to know more on user-secrets:
    Microsoft documentation (https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows)
    
    The default example has a JSON object called 'DisCatSharp', 
    where the token is expected to be under the config object called 'Discord'
    So the user secret path would look like
    
    (run this in a terminal inside your project folder)
    dotnet user-secrets init
    dotnet user-secrets set "DisCatSharp:Discord:Token" "YOUR TOKEN GOES HERE"

    By Adding the above secret it would be as if it was inside your appsettings.json file under DisCatSharp -> Discord -> Token
 */
//builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

builder.Services.AddOptions();
builder.Services.AddLogging();

/*
    Please use the DisCatSharpBot Project Template for adding however many
    Bots you need

    For each of those projects, you will note a ServiceCollectionExtensions class.
    This contains the extension methods needed to add the bot into our web-app environment!

    Please be sure to add a reference to the project(s).
    Example of what it could look like (It should be matter of replacing 'Bot' with 
    whatever you called your bot project
    
    builder.Services.AddBotServices(); 
 */

//builder.Services.AddBotServices();
#if (IncludeBot)
builder.Services.AddDisCatSharpProjectBotServices();
#endif

// Still have the functionality of a website 
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();
