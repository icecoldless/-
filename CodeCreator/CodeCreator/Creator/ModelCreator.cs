using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCreator.Common;
using System.Data;

/***
*	Title：
*	Description：
*/
namespace CodeCreator.Creator
{
    public class ModelCreator
    {
        public Dictionary<string, string> Create(List<string> LstTbName)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < LstTbName.Count; i++)
            {
                sb.Clear();
                string tbName = LstTbName[i];
                sb.AppendLine("using System;").AppendLine().AppendLine($"namespace {Creator.Instance.Config.ModelName}").AppendLine("{").AppendLine("[Serializable]");
                sb.AppendLine($"public partial class {tbName}").AppendLine("{");
                for (int j = 0; j < Creator.Instance.SetTb.Tables[tbName].Columns.Count; j++)
                {
                    sb.AppendLine($"public {GetRightDataType(Creator.Instance.SetTb.Tables[tbName].Columns[j])} {Creator.Instance.SetTb.Tables[tbName].Columns[j].ColumnName} {{ get; set; }}");
                }
                sb.AppendLine("}").AppendLine("}");
                dic.Add(tbName, sb.ToString());
            }
            return dic;
        }


        public string GetRightDataType(DataColumn col)
        {
            string t = col.DataType.Name;
            if(col.DataType==typeof(System.Int32))
            {
                t = "int";
            }else if (col.DataType==typeof(System.Boolean))
            {
                t = "bool";
            }else if (col.DataType!=typeof(System.DateTime)&&col.DataType!=typeof(System.Guid))
            {
                t = t.ToLower();
            }
            if (Creator.Instance.CanNull&&col.DataType.IsValueType&&col.AllowDBNull)
            {
                t += "?";
            }
            return t;
        }

    }
}
