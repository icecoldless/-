using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCreator.Common;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/***
*	Title：
*	Description：
*/
namespace CodeCreator.Creator
{
    public class Creator:Singleton<Creator>
    {
        public string ProjName { get; set; }
        public string DALSuffix { get; set; }
        public string BLLSuffix { get; set; }
        public string ConnStr { get; set; }
        public bool CanNull = false;
        public bool IsPage = false;
        public int PageSize = 0;

        ProjectConfig _Config;
        public ProjectConfig Config {
            get
            {
                if (_Config==null)
                {
                    _Config = new ProjectConfig(ProjName,CanNull);
                }
                return _Config;
            }
        }


        SQLHelper _Helper;
        public SQLHelper Helper
        {
            get
            {
                if (_Helper == null)
                {
                    _Helper = new SQLHelper(ConnStr);
                }
                return _Helper;
            }
        }

        List<string> _LstTbName;
        public List<string> LstTbName
        {
            get
            {
                if(_LstTbName==null)
                {
                    _LstTbName = new List<string>();
                    string sql = "select name from sysobjects where xtype='u'";
                    SqlDataReader reader = Helper.GetReader(sql);
                    while (reader.Read())
                    {
                        _LstTbName.Add(reader["name"].ToString());
                    }
                    reader.Close();
                }
                return _LstTbName;
            }
        }

 
        DataSet _SetTb;
        public DataSet SetTb
        {
            get
            {
                if (_SetTb==null)
                {
                    _SetTb = GetTbs();
                }
                return _SetTb;
            }
        }

        ModelCreator _Mc;

        public ModelCreator Mc
        {
            get
            {
                if (_Mc==null)
                {
                    _Mc = new ModelCreator();
                }
                return _Mc;
            }
        }

        DALCreator _Dc;

        public DALCreator Dc
        {
            get
            {
                if (_Dc == null)
                {
                    _Dc = new DALCreator();
                }
                return _Dc;
            }
        }

        BLLCreator _Bc;

        public BLLCreator Bc
        {
            get
            {
                if (_Bc == null)
                {
                    _Bc = new BLLCreator();
                }
                return _Bc;
            }
        }

        public bool IsExistedName { get; set; }

        public void Create(string path,List<string> LstTbName)
        {
            //保存Model
            CreateData cd = new CreateData()
            {
                IsPage = this.IsPage,
                PageSize=this.PageSize,
                IsExistedName = this.IsExistedName,
                DalSuffix = this.DALSuffix,
                BllSuffix = this.BLLSuffix
            };
            Dictionary<string, string> dicM = Mc.Create(LstTbName);
            if (!Directory.Exists(path + "\\Models"))
            {
                Directory.CreateDirectory(path + "\\Models");
            }
            SaveFile(path + "\\Models\\", string.Empty, dicM);

            //save DAL
            Dictionary<string, string> dicD = Dc.Create(LstTbName,cd);
            if (!Directory.Exists(path + "\\DAL"))
            {
                Directory.CreateDirectory(path + "\\DAL");
            }
            SaveFile(path + "\\DAL\\", DALSuffix, dicD);

            //save BLL
            Dictionary<string, string> dicB = Bc.Create(LstTbName, cd);
            if (!Directory.Exists(path + "\\BLL"))
            {
                Directory.CreateDirectory(path + "\\BLL");
            }
            SaveFile(path + "\\BLL\\", BLLSuffix, dicB);
        }


        public DataSet GetTbs()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < LstTbName.Count; i++)
            {
                dic.Add(LstTbName[i], $"select top 0 * from {LstTbName[i]}");
            }
            DataSet set = Helper.GetDataSet(dic);
            return set;
        }

        public void SaveFile(string path,string suffix,Dictionary<string,string> dic) //key-className,value-content
        {
            foreach (KeyValuePair<string,string> kv in dic)
            {
                using (FileStream fs = new FileStream(path + $"{kv.Key}{suffix}.cs",FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs,Encoding.Default))
                    {
                        sw.Write(kv.Value);
                    }
                }
            }
        }
    }
}
