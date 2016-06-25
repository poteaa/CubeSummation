using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CubeSumDataBase
{
    public class QueValDB
    {
        [Key]
        public int QueValId { get; set; }
        public virtual QueryDB Query { get; set; }
        public virtual QueryValueDB QueryValue { get; set; }
    }
}
