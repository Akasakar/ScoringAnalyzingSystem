using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScoringAnalyzingSystem
{
    /// <summary>
    /// 静态类 对Excel读写操作
    /// </summary>
    public static class IOExcel
    {
        /// <summary>
        /// 检查数据格式
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        private static bool checkExcel(string tableName, DataTable dt)
        {
            if (dt == null) return false;
            if (tableName.Equals("SASinfo") && dt.Columns.Count != 11) return false;
            if (tableName.Equals("Line") && dt.Columns.Count != 4) return false;
            if (tableName.Equals("Regional") && dt.Columns.Count != 2) return false;
            return true;
        }

        /// <summary>
        /// 将Excel数据导入至数据库
        /// </summary>
        /// <param name="fileName">Excel文件名</param>
        /// <param name="tableName">要插入数据库的表名</param>
        /// <param name="CONNECTION">连接字符串</param>
        public static void IOtoSQL(string fileName, string tableName, string CONNECTION)
        {
            SQLTool mysql = new SQLTool();
            mysql.open(CONNECTION);
            try
            {
                DataTable dt = ReadExcelToTable(fileName);
                if (!checkExcel(tableName, dt))
                    throw new Exception("文件格式不符合要求\n请查看帮助信息");

                dt.Columns.Add("autoid", typeof(int));

                mysql.BatchInsert(dt, tableName);

                MessageBox.Show(System.IO.Path.GetFileNameWithoutExtension(fileName) + "\n数据导入成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mysql.close();
            }
        }

        /// <summary>
        /// 读取Excle,把第一个sheel中的内容放入datatable
        /// </summary>
        /// <param name="ExcelFilePath">excle的路径</param>
        /// <returns></returns>
        public static DataTable ReadExcelToTable(string ExcelFilePath)//excel存放的路径
        {
            try
            {
                //连接字符串
                int HDR = 1, IMEX = 1;
                string connstring = null;
                if (System.IO.Path.GetExtension(ExcelFilePath).Equals(".xls"))
                    connstring = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR={1};IMEX={2:D}\";", ExcelFilePath, HDR, IMEX); //0ffice 97-2003
                else if (System.IO.Path.GetExtension(ExcelFilePath).Equals(".xlsx"))
                    connstring = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR={1};IMEX={2:D}\";", ExcelFilePath, HDR, IMEX); // Office 07及以上版本 不能出现多余的空格 而且分号注意
                else
                {
                    MessageBox.Show("无效的文件类型");
                    return null;
                }

                using (OleDbConnection conn = new OleDbConnection(connstring))
                {
                    conn.Open();
                    DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
                    string firstSheetName = sheetsName.Rows[0][2].ToString(); //得到第一个sheet的名字

                    string sql = string.Format("SELECT * FROM [{0}]", firstSheetName); //查询字符串
                    //string sql = string.Format("SELECT * FROM [{0}] WHERE [日期] is not null", firstSheetName); //查询字符串

                    OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
                    DataSet set = new DataSet();
                    ada.Fill(set);

                    //释放资源
                    conn.Dispose();
                    conn.Close();

                    return set.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}
