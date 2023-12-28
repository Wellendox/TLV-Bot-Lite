try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

    builder.Host.ConfigureDiscordHost((context, config) =>
        {
            config.SocketConfig = new DiscordSocketConfig
            {
                LogLevel = Misc.IsDebug() ? LogSeverity.Debug : LogSeverity.Warning,
                MessageCacheSize = 1000,
                GatewayIntents = GatewayIntents.All,
                AlwaysDownloadUsers = true,
                UseInteractionSnowflakeDate = false,
                AlwaysResolveStickers = true,
                AlwaysDownloadDefaultStickers = true,
                DefaultRetryMode = RetryMode.AlwaysRetry
            };

            config.Token = context.Configuration.GetSection("Discord").GetValue<string>("Token") ?? string.Empty;
            config.LogFormat = (message, _) => $"{message.Source}: {message.Message}";
        })
        .UseInteractionService((_, config) =>
        {
            config.DefaultRunMode = RunMode.Async;
            config.LogLevel = Misc.IsDebug() ? LogSeverity.Debug : LogSeverity.Warning;
            config.UseCompiledLambda = true;
        }).ConfigureServices((context, services) =>
        {
            services.AddHostedService<InteractionHandler>();
            services.AddSingleton<InteractionService>();
            services.AddSingleton(context.Configuration);
            services.AddHttpContextAccessor();
        });
    var app = builder.Build();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}