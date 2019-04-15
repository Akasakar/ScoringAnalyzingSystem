using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ScoringAnalyzingSystem
{
    /// <summary>
    /// SQL语句执行类
    /// </summary>
    class SQLTool
    {
        public SqlConnection SQLcnt = null;
        public SqlCommand SQLcmd = null;

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="CONNECTION">连接数据库字符串</param>
        public void open(string CONNECTION)
        {
            try
            {
                SQLcnt = new SqlConnection(CONNECTION);
                SQLcnt.Open();
                SQLcmd = SQLcnt.CreateCommand();
                SQLcmd.CommandType = System.Data.CommandType.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 向tableName表批量插入DataTable数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName">要插入的表名</param>
        public void BatchInsert(DataTable dt, string tableName)
        {
            SqlBulkCopy sbc = new SqlBulkCopy(SQLcnt.ConnectionString);
            try
            {
                sbc.DestinationTableName = tableName;
                sbc.BatchSize = dt.Rows.Count;
                sbc.BulkCopyTimeout = 20;

                for (int i = 0; i < dt.Columns.Count; i++)
                    sbc.ColumnMappings.Add(dt.Columns[i].ColumnName, i);

                sbc.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                sbc.Close();
            }
        }

        /// <summary>
        /// 返回select结果
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        /// <returns></returns>
        public DataTable select(string cmd)
        {
            SQLcmd.CommandText = cmd;
            SQLcmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(SQLcmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        public void delete(string cmd)
        {
            SQLcmd.CommandText = cmd;
            SQLcmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 判结果是否存在
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        /// <returns></returns>
        public bool isThree(string cmd)
        {
            SQLcmd.CommandText = cmd;
            return SQLcmd.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void close()
        {
            SQLcmd.Dispose();
            SQLcnt.Close();
            SQLcnt.Dispose();
        }
    }
}
