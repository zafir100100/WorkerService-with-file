using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService.Models
{
    public class Application
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public WorkerConfig? WorkerConfig { get; set; }
        public GlobalWritingConfig? GlobalWritingConfig { get; set; }
        public List<Worker>? Workers { get; set; }
    }
}
