using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models.Blog
{
    public class Blog
    {
        public int ID { get; set; }
        public string Tilulo { get; set; }
        public string Resumo { get; set; }
        public string Url { get; set; }
    }
}
