using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace designPatterns.model
{
    public abstract class WindowModel
    {
        public String Description { get; set; }
        public String ConsoleOutput { get; set; }

        public WindowModel(String desc)
        {
            Description = desc;
        }

        public abstract void Run();
    }
}
