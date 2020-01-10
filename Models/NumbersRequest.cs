using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluestoneApi.Models
{
    public class NumbersRequest
    {
        public string numbers { get; set; }
        public bool isSort { get; set; }
        public bool isFilter { get; set; }
    }
}
