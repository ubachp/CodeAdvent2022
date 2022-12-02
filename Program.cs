using CodeAdvent2022;
using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Configuration;
//%APPDATA%\Microsoft\UserSecrets\9FA2FF08-7902-463C-8E4A-FD09C453E5DF

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var cookie = configuration.GetSection("Cookie").Value;
Guard.IsNotNullOrWhiteSpace(configuration.GetSection("Cookie").Value, nameof(configuration));
#pragma warning disable CS8601 // Possible null reference assignment.
CodeAdvent.Cookie = cookie;
#pragma warning restore CS8601 // Possible null reference assignment.
await CodeAdvent.Run();
