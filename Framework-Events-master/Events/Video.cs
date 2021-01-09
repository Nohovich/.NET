using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Video
    {
        public string Title { get; set; }

        public Video(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
