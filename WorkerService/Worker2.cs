using WorkerService.Repositories;

namespace WorkerService
{
    public class Worker2 : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker2(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Models.Root? root = new FileRepository().ReadFile();
                if (root != null)
                {
                    WorkerRepository wr = new(root, 2);
                    wr.WriteFile();
                    await Task.Delay((wr?.DelayInSeconds ?? 0) * 1000, stoppingToken);
                }
            }
        }
    }
}