using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService.Models
{
    public class Worker
    {
        public string? Name { get; set; }
        public List<string>? InternalTextLines { get; set; }
        public string? WritingFilePath { get; set; }
    }
}
