using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    public class Page
    {
        public string page { get; set; }
        public DateTime dateTime { get; set; }
        public Page(string page,DateTime dateTime)
        {
            this.page = page;
            this.dateTime = dateTime;
        }
    }
}
