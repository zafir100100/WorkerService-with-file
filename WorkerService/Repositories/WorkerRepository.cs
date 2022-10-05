using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService.Models;

namespace WorkerService.Repositories
{
    class WorkerRepository
    {
        public Root root;
        public int WorkerSerial;

        public Models.Worker? worker;
        public Models.GlobalWritingConfig globalWritingConfig;
        public int? DelayInSeconds;
        public string? DatedTime;

        public WorkerRepository(Root root, int WorkerSerial)
        {
            this.root = root;
            this.WorkerSerial = WorkerSerial;
            this.SetWorker();
            this.SetDatedTime();
            this.SetDelayInSeconds();
        }

        public void SetWorker()
        {
            if (root?.Application?.Workers?.Count > 0)
            {
                Models.Worker? worker = root?.Application?.Workers?.Where(i => i.Name.Contains("worker-" + this.WorkerSerial)).FirstOrDefault();
                this.worker = worker;

                ////set back to root
                //this.root?.Application?.Workers?.Clear();
                //if (worker != null)
                //{
                //    this.root?.Application?.Workers?.Add(worker);
                //}
            }
        }

        public void SetDatedTime()
        {
            this.DatedTime = DateTime.Now.ToString("dd/MMM/yyyy h:mm tt");
        }

        public void SetDelayInSeconds()
        {
            string? delay = root?.Application?.GlobalWritingConfig?.Delay;
            if (delay != null)
            {
                delay = delay.Replace("s", "");
                try
                {
                    this.DelayInSeconds = Int32.Parse(delay);
                }
                catch (FormatException)
                {

                }
            }
        }

        public void WriteFile()
        {
            if (root?.Application?.GlobalWritingConfig?.TextLines?.Count > 0)
            {
                List<string?> newTextLines = new();
                foreach (var item in this.root.Application.GlobalWritingConfig.TextLines)
                {
                    if (item.StartsWith(this.WorkerSerial.ToString() + " "))
                    {
                        newTextLines.Add(item);
                        //newTextLines.Add(item + Environment.NewLine + this.DelayInSeconds + "s delay");
                    }
                }

                foreach (var item in newTextLines)
                {
                    if (item != null && this.worker?.WritingFilePath != null)
                    {
                        FileRepository fr = new();
                        fr.WriteFile(new List<string> { this.worker?.Name + " - " + item + " - " + this?.DatedTime, this.DelayInSeconds + "s delay" }, this.worker.WritingFilePath.Replace("d:/", ""));
                        //fr.WriteFile(new List<string> { this.DelayInSeconds + "s delay" }, this.worker.WritingFilePath.Replace("d:/", ""));
                    }
                }
            }
        }

    }
}
