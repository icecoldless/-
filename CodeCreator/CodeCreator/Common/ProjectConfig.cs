using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***
*	Title：
*	Description：
*/
namespace CodeCreator.Common
{
    public class ProjectConfig
    {
        public string ProjName { get; set; }
        public string ModelName => $"{ProjName}.Models";
        public string DALName => $"{ProjName}.DAL";
        public string BLLName => $"{ProjName}.BLL";
        public bool CanNull = false;

        public ProjectConfig(string projName,bool canNull)
        {
            this.ProjName = projName;
            this.CanNull = canNull;
        }
    }
}
