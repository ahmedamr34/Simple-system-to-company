using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Entities
{
    public class Email
    {
        public string Subject { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string ImageName { get; set; }
    }
}
