using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService.Models
{
    public class WorkerConfig
    {
        public string? WorkerName { get; set; }
        public string? WorkerPath { get; set; }
        public List<string>? WorkerArgs { get; set; }
    }
}
