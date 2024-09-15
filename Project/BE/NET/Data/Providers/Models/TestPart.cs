using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Data.Providers.Models
{
    public class TestPart
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int PartId { get; set; }
        public int NoQuestion { get; set; }
        public int TimeLimit { get; set; }

    }
}