using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Data.Providers.StoredProcedures
{
    public class Script
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PartId { get; set; }
        public int AudioId { get; set; }

    }
}