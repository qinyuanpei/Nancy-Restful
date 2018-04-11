using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.Jwt.Models
{
    public class Bar
    {
        public string Owner { get; set; }

        public string TaskId { get; set; } = Guid.NewGuid().ToString("D");

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}