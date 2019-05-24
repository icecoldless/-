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
    public class BLLCreator
    {
        public Dictionary<string, string> Create(List<string> LstTbName,CreateData cd)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < LstTbName.Count; i++)
            {
                sb.Clear();
                string tbName = LstTbName[i];
                sb.AppendLine("using System;").AppendLine("using System.Collections.Generic;").AppendLine("using System.Data.SqlClient;").AppendLine($"using {Creator.Instance.Config.DALName};").AppendLine($"using {Creator.Instance.Config.ModelName};").AppendLine().AppendLine($"namespace {Creator.Instance.Config.BLLName}").AppendLine("{");
                sb.AppendLine($"public class {tbName}{cd.BllSuffix}").AppendLine("{").AppendLine($"{tbName}{cd.DalSuffix} _{tbName}{cd.DalSuffix}=new {tbName}{cd.DalSuffix}();");
                if (cd.IsPage)
                {
                    sb.AppendLine("public int PageCount").AppendLine("{").AppendLine("get").AppendLine("{").AppendLine($"return _{tbName}{cd.DalSuffix}.PageData.PageCount;").AppendLine("}").AppendLine("}");
                }
                //CRUD
                sb.AppendLine(CreateInsertMethod(tbName,cd.DalSuffix));
                sb.AppendLine(CreateDelMethod(tbName,cd.DalSuffix));
                sb.AppendLine(CreateUpdateMethod(tbName,cd.DalSuffix));
                sb.AppendLine(CreateGetMethod(tbName,cd.DalSuffix));
                sb.AppendLine(CreateReadMethod(tbName,cd.DalSuffix));
                if(cd.IsPage)
                {
                    sb.AppendLine(CreatePageMethod(tbName,cd.DalSuffix));
                }
                sb.AppendLine("}").AppendLine("}");
                dic.Add(tbName, sb.ToString());
            }
            return dic;
        }



        private string CreatePageMethod(string tbName, string dalSuffix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public List<{tbName}> GetPageLst(int pageIndex,string whereStr=null)").AppendLine("{").AppendLine("try").AppendLine("{").AppendLine($"return _{tbName}{dalSuffix}.GetPageLst(pageIndex,whereStr);").AppendLine("}");
            sb.AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}");
            return sb.ToString();
        }

        private string CreateInsertMethod(string tbName,string dllSuffix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public int Add({tbName} {tbName.ToLower()})").AppendLine("{").AppendLine("try").AppendLine("{").AppendLine($"return _{tbName}{dllSuffix}.Add({tbName.ToLower()});").AppendLine("}");
            sb.AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}").AppendLine();
            return sb.ToString();
        }

        private string CreateDelMethod(string tbName, string dllSuffix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public int Del(string id)").AppendLine("{").AppendLine("try").AppendLine("{").AppendLine($"return _{tbName}{dllSuffix}.Del(id);").AppendLine("}");
            sb.AppendLine("catch (SqlException se)").AppendLine("{").AppendLine("if (se.Number == 547)").AppendLine("{").AppendLine("throw new Exception(\"该数据与其他表之间存在主外键关系，无法删除\");").AppendLine("}").AppendLine("else").AppendLine("throw se;").AppendLine("}").AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}").AppendLine();
            return sb.ToString();
        }

        private string CreateUpdateMethod(string tbName,string dllSuffix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public int Update({tbName} {tbName.ToLower()})").AppendLine("{").AppendLine("try").AppendLine("{").AppendLine($"return _{tbName}{dllSuffix}.Update({tbName.ToLower()});").AppendLine("}");
            sb.AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}").AppendLine();
            return sb.ToString();
        }

        private string CreateGetMethod(string tbName, string dalSuffix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public {tbName} Get(string id)").AppendLine("{").AppendLine("try").AppendLine("{").AppendLine($"return _{tbName}{dalSuffix}.Get(id);").AppendLine("}");
            sb.AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}").AppendLine();
            return sb.ToString();
        }

        private string CreateReadMethod(string tbName,string dllSuffix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public List<{tbName}> GetLst(string whereStr=null)").AppendLine("{").AppendLine("try").AppendLine("{").AppendLine($"return _{tbName}{dllSuffix}.GetLst(whereStr);").AppendLine("}");
            sb.AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}").AppendLine();
            return sb.ToString();
        }
    }
}
