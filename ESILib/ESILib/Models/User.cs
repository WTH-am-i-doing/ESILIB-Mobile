using System;
using System.Collections.Generic;
using System.Text;

namespace ESILib.Models
{
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }
        public List<Request> requestHistory { get; set; }
        public Book Current { get; set; }
    }
}
