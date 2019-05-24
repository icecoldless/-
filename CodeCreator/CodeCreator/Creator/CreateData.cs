using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***
*	Title：
*	Description：
*/
namespace CodeCreator.Creator
{
    public class CreateData
    {
        public bool IsPage { get; set; }
        public int PageSize { get; set; }
        public bool IsExistedName { get; set; }
        public string DalSuffix { get; set; }
        public string BllSuffix { get; set; }
    }
}
