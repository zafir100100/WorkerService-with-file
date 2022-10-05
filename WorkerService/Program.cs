using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //services.AddHostedService<Worker>();
        services.AddHostedService<Worker1>();
        //services.AddHostedService<Worker2>();
        services.AddHostedService<Worker3>();
    })
    .Build();

await host.RunAsync();
