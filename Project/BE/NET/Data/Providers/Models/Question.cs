using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Data.Providers.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ScriptId { get; set; }
        public int AudioId { get; set; }

    }
}