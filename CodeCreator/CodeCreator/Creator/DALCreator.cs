using System;
using System.Collections.Generic;
using System.Text;

/***
*	Title：
*	Description：
*/
namespace CodeCreator.Creator
{
    public class DALCreator
    {
        public Dictionary<string, string> Create(List<string> LstTbName,CreateData cd)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < LstTbName.Count; i++)
            {
                sb.Clear();
                string tbName = LstTbName[i];
                sb.AppendLine("using System;").AppendLine("using System.Collections.Generic;").AppendLine("using System.Data.SqlClient;").AppendLine($"using {Creator.Instance.Config.ModelName};").AppendLine($"using {Creator.Instance.Config.ProjName}.Common;").AppendLine($"namespace {Creator.Instance.Config.DALName}").AppendLine("{");
                sb.AppendLine($"public class {tbName}{cd.DalSuffix}").AppendLine("{");
                if(cd.IsPage)
                {
                    sb.AppendLine($"public PageData PageData = new PageData({cd.PageSize});");
                }
                //CRUD
                sb.AppendLine(CreateInsertMethod(tbName));
                sb.AppendLine(CreateDelMethod(tbName));
                sb.AppendLine(CreateUpdateMethod(tbName));
                sb.AppendLine(CreateGetMethod(tbName));
                sb.AppendLine(CreateReadMethod(tbName));
                if(cd.IsPage)
                {
                    sb.AppendLine(CreatePageMethod(tbName));
                }
                if (cd.IsExistedName)
                    sb.AppendLine(CreateIsExistedName(tbName));
                sb.AppendLine("}").AppendLine("}");
                dic.Add(tbName, sb.ToString());
            }
            return dic;
        }

        //插入方法
        public string CreateInsertMethod(string tbName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public int Add({tbName} {tbName.ToLower()})").AppendLine("{").AppendLine("int res = 0;");
            //封装参数
            sb.AppendLine($"SqlParameter[] param = new SqlParameter[] {{");
            for (int i = 0; i < Creator.Instance.SetTb.Tables[tbName].Columns.Count; i++)
            {
                if (!Creator.Instance.SetTb.Tables[tbName].Columns[i].AutoIncrement)
                {
                    if(Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName.Contains("Time"))
                    {
                        if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            sb = sb.Remove(sb.Length-3,1);
                            sb.AppendLine("                };");
                        }
                    }
                    else
                    {
                        sb.Append($"                    new SqlParameter(\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\",{tbName.ToLower()}.{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName})");
                        if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                        {
                            sb.AppendLine(",");
                        }
                        else
                        {
                            sb.AppendLine();
                            sb.AppendLine("                };");
                        }
                    }
                   
                }
            }
            //构建sql语句
            sb.Append($"string sql = \"insert into {tbName}(");
            for (int i = 0; i < Creator.Instance.SetTb.Tables[tbName].Columns.Count; i++)
            {
                if (!Creator.Instance.SetTb.Tables[tbName].Columns[i].AutoIncrement)
                {
                    if (Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName.Contains("Time"))
                    {
                        if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            sb = sb.Remove(sb.Length - 1, 1);
                            sb.Append(") values(");
                        }
                    }
                    else
                    {
                        sb.Append($"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}");
                        if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                            sb.Append(",");
                        else
                            sb.Append(") values(");
                    }
                }
            }
            for (int i = 0; i < Creator.Instance.SetTb.Tables[tbName].Columns.Count; i++)
            {
                if (!Creator.Instance.SetTb.Tables[tbName].Columns[i].AutoIncrement)
                {
                    if (Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName.Contains("Time"))
                    {
                        if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            sb = sb.Remove(sb.Length - 1, 1);
                            sb.AppendLine(")\";");
                        }
                    }
                    else
                    {
                        sb.Append($"@{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}");
                        if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                            sb.Append(",");
                        else
                            sb.AppendLine(")\";");
                    }
                }
            }
            sb.AppendLine("try").AppendLine("{").AppendLine("res = SQLHelper.Update(sql,param);").AppendLine("}").AppendLine("catch (Exception ex)").AppendLine("{").AppendLine(" throw ex;").AppendLine("}");
            sb.AppendLine("return res;").AppendLine("}");
            sb.AppendLine();
            return sb.ToString();
        }

        //删除方法
        public string CreateDelMethod(string tbName)
        {
            StringBuilder sb = new StringBuilder();
            string pkColName = Creator.Instance.Helper.GetPkColumnName(tbName);
            sb.AppendLine($"public int Del(string {pkColName.ToLower()})").AppendLine("{").AppendLine($"string sql = \"delete from {tbName} where {pkColName} = @{pkColName}\";").AppendLine("try").AppendLine("{");
            sb.AppendLine("SqlParameter[] param = new SqlParameter[]").AppendLine("{").AppendLine($"                    new SqlParameter(\"@{pkColName}\",{pkColName.ToLower()})").AppendLine("};");
            sb.AppendLine("return SQLHelper.Update(sql, param);").AppendLine("}").AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}").AppendLine();
            return sb.ToString();
        }

        //改方法
        public string CreateUpdateMethod(string tbName)
        {
            StringBuilder sb = new StringBuilder();
            string pkColName = Creator.Instance.Helper.GetPkColumnName(tbName);
            sb.AppendLine($"public int Update({tbName} {tbName.ToLower()})").AppendLine("{").AppendLine("SqlParameter[] param = new SqlParameter[]").AppendLine("{");
            //封装参数
            for (int i = 0; i < Creator.Instance.SetTb.Tables[tbName].Columns.Count; i++)
            {
                if (Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName.Contains("Time"))
                {
                    if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        sb = sb.Remove(sb.Length - 3, 1);
                        sb.AppendLine("};");
                    }
                }
                else
                {
                    sb.Append($"                new SqlParameter(\"@{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\",{tbName.ToLower()}.{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName})");
                    if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                        sb.AppendLine(",");
                    else
                    {
                        sb.AppendLine();
                        sb.AppendLine("};");
                    }
                }
            }
            //sql语句
            sb.Append($"string sql = \"update {tbName} set ");
            for (int i = 0; i < Creator.Instance.SetTb.Tables[tbName].Columns.Count; i++)
            {
                if (!Creator.Instance.SetTb.Tables[tbName].Columns[i].AutoIncrement)
                {
                    if (Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName.Contains("Time"))
                    {
                        if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            sb.Append("UpdateTime=getdate()");
                            sb.Append(" ");
                        }
                    }
                    else
                    {
                        sb.Append($"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}=@{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}");
                        if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                            sb.Append(",");
                        else
                            sb.Append(" ");
                    }
                 
                }
            }
            sb.AppendLine($"where {pkColName} = @{pkColName}\";");
            //end
            sb.Append("try").AppendLine("{").AppendLine("return SQLHelper.Update(sql, param);").AppendLine("}").AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}").AppendLine();
            return sb.ToString();
        }

        //Get
        public string CreateGetMethod(string tbName)
        {
            StringBuilder sb = new StringBuilder();
            string pkColName = Creator.Instance.Helper.GetPkColumnName(tbName);
            sb.AppendLine($"public {tbName} Get(string id)").AppendLine("{");
            //sql
            sb.AppendLine($"string sql = \"select * from {tbName} where {pkColName} = @Id\";");
            sb.AppendLine("SqlParameter[] param = new SqlParameter[] { new SqlParameter(\"@Id\",id)};");
            sb.AppendLine($"{tbName} {tbName.ToLower()}=null;").AppendLine("try").AppendLine("{").AppendLine("SqlDataReader reader = SQLHelper.GetReader(sql,param);").AppendLine("while (reader.Read())").AppendLine("{");
            sb.Append($"{tbName.ToLower()}=");
            GetEncapsulationObjectStr(sb, tbName);
            sb.AppendLine(";").AppendLine("}");
            //while end
            sb.AppendLine("reader.Close();").AppendLine($"return {tbName.ToLower()};").AppendLine("}").AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}");
            return sb.ToString();
        }

        //GetLst
        public string CreateReadMethod(string tbName)
        {
            StringBuilder sb = new StringBuilder();
            string pkColName = Creator.Instance.Helper.GetPkColumnName(tbName);
            sb.AppendLine($"public List<{tbName}> GetLst(string whereStr)").AppendLine("{");
            sb.AppendLine($"List<{tbName}> lst = new List<{tbName}>();");
            //sql语句
            sb.Append($"string sql = \"select ");
            for (int i = 0; i < Creator.Instance.SetTb.Tables[tbName].Columns.Count; i++)
            {
                sb.Append($"{Creator.Instance.SetTb.Tables[tbName].Columns[i]}");
                if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                    sb.Append(",");
                else
                    sb.Append(" ");
            }
            sb.AppendLine($"from {tbName}\";").AppendLine("if (whereStr != null)").AppendLine("sql += $\" where {whereStr}\";");
            sb.AppendLine("try").AppendLine("{").AppendLine("SqlDataReader reader = SQLHelper.GetReader(sql);");
            sb.AppendLine("while (reader.Read())").AppendLine("{").Append("lst.Add(").AppendLine($"new {tbName}()").AppendLine("{");
            string isNull;
            for (int i = 0; i < Creator.Instance.SetTb.Tables[tbName].Columns.Count; i++)
            {
                isNull = (Creator.Instance.CanNull && Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType.IsValueType && Creator.Instance.SetTb.Tables[tbName].Columns[i].AllowDBNull) ? "?" : string.Empty;
                sb.Append($"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}=");
                if (Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType == typeof(System.Int32))
                {
                    sb.Append($"(int{isNull})reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"]");
                }
                else if (Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType == typeof(System.Boolean))
                {
                    sb.Append($"(bool{isNull})reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"]");
                }
                else if (Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType == typeof(System.String))
                {
                    sb.Append($"reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"].ToString()");
                }
                else if (Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType != typeof(System.Guid) && Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType != typeof(System.DateTime))
                {
                    sb.Append($"({Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType.Name.ToLower()}{isNull})reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"]");
                }
                else
                {
                    sb.Append($"({Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType.Name}{isNull})reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"]");
                }
                if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }
            sb.AppendLine("});").AppendLine("}").AppendLine("reader.Close();").AppendLine("return lst;").AppendLine("}").AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}");
            return sb.ToString();
        }

        private string CreatePageMethod(string tbName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" public List<{tbName}> GetPageLst(int pageIndex,string whereStr)").AppendLine("{").AppendLine($"List<{tbName}> lst = new List<{tbName}>();");
            //try
            sb.AppendLine("try").AppendLine("{").AppendLine($"SqlDataReader reader = SQLHelper.GetPageLst(\"{tbName}\", \"{Creator.Instance.Helper.GetPkColumnName(tbName)}\", pageSize: PageData.PageSize, curPage: pageIndex,whereStr: whereStr);");
            sb.AppendLine("while (reader.Read())").AppendLine("{").Append("lst.Add(");
            GetEncapsulationObjectStr(sb, tbName);
            sb.AppendLine(");").AppendLine("}").AppendLine("if (PageData.RecordCount == 0 && reader.NextResult())").AppendLine("{").AppendLine("if (reader.Read())").AppendLine("{").AppendLine("PageData.RecordCount = (int)reader[\"RecordCount\"];").AppendLine("}").AppendLine("}").AppendLine("reader.Close();").AppendLine("return lst;").AppendLine("}");
            //catch
            sb.AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}");
            return sb.ToString();
        }

        string CreateIsExistedName(string tbName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public bool IsExistedName(string name)").AppendLine("{").AppendLine($"string sql = \"select count(*) from {tbName} where Name = @Name\";").AppendLine("SqlParameter[] param = new SqlParameter[] {").AppendLine("                new SqlParameter(\"@Name\",name)").AppendLine("            };");
            sb.AppendLine("try").AppendLine("{").AppendLine("return 0 != (int)SQLHelper.GetSingleResult(sql, param);").AppendLine("}").AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}");
            sb.AppendLine();
            sb.AppendLine($"public bool IsExistedName(string name,string id)").AppendLine("{").AppendLine($"string sql = \"select count(*) from {tbName} where Name = @Name and Id <> @Id\";").AppendLine("SqlParameter[] param = new SqlParameter[] {").AppendLine("                new SqlParameter(\"@Name\",name),").AppendLine("                new SqlParameter(\"@Id\",id)").AppendLine("            };");
            sb.AppendLine("try").AppendLine("{").AppendLine("return 0 != (int)SQLHelper.GetSingleResult(sql, param);").AppendLine("}").AppendLine("catch (Exception ex)").AppendLine("{").AppendLine("throw ex;").AppendLine("}").AppendLine("}");
            return sb.ToString();
        }


        /// <summary>
        /// 获得封装对象的字符串
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="tbName"></param>
        string GetEncapsulationObjectStr(StringBuilder sb,string tbName)
        {
            sb.AppendLine($"new {tbName}()").AppendLine("{");
            string isNull;
            for (int i = 0; i < Creator.Instance.SetTb.Tables[tbName].Columns.Count; i++)
            {
                isNull = (Creator.Instance.CanNull && Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType.IsValueType && Creator.Instance.SetTb.Tables[tbName].Columns[i].AllowDBNull) ? "?" : string.Empty;
                sb.Append($"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}=");
                if (Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType == typeof(System.Int32))
                {
                    sb.Append($"(int{isNull})reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"]");
                }
                else if (Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType == typeof(System.Boolean))
                {
                    sb.Append($"(bool{isNull})reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"]");
                }
                else if (Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType == typeof(System.String))
                {
                    sb.Append($"reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"].ToString()");
                }
                else if (Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType != typeof(System.Guid) && Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType != typeof(System.DateTime))
                {
                    sb.Append($"({Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType.Name.ToLower()}{isNull})reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"]");
                }
                else
                {
                    sb.Append($"({Creator.Instance.SetTb.Tables[tbName].Columns[i].DataType.Name}{isNull})reader[\"{Creator.Instance.SetTb.Tables[tbName].Columns[i].ColumnName}\"]");
                }
                if (i != Creator.Instance.SetTb.Tables[tbName].Columns.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
