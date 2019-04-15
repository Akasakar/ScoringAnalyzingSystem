using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ScoringAnalyzingSystem
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 连接字符串，windows用户登录
        /// </summary>
        private static string CONNECTION = @"server = .; database = SASdatabase; Trusted_Connection=SSPI";

        /// <summary>
        /// 批次线表
        /// </summary>
        private DataTable dt_batch = null;

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从数据库读取批次线，初始化表
        /// </summary>
        private void init_dt_batch()
        {
            SQLTool mysql = new SQLTool();
            mysql.open(CONNECTION);
            try
            {
                dt_batch = mysql.select(SQLCmdStr.selectLine());
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
        /// 更新批次线下拉框
        /// </summary>
        private void updataComboBox_batch()
        {
            string depart = "理科";
            if (radioButtonArt.Checked) depart = "文科";
            int year;

            List<string> ls = new List<string>();
            for (int i = 0; i < dt_batch.Rows.Count; i++)
            {
                string batch = dt_batch.Rows[i][1].ToString();
                if (!batch.Equals(depart)) continue;

                try
                {
                    year = int.Parse(dt_batch.Rows[i][2].ToString());
                    //if (year != int.Parse(comboBoxYearR.Text)) continue;
                    if (year != DateTime.Now.Year) continue;    //今年批次线
                }
                catch (FormatException fex)
                {
                    MessageBox.Show(fex.Message);
                    break;
                }

                string constr = dt_batch.Rows[i][3].ToString()
                                + "-"
                                + dt_batch.Rows[i][0].ToString();
                ls.Add(constr);
            }
            ls.Sort();

            comboBoxBatch.Items.Clear();
            foreach (string s in ls)
            {
                comboBoxBatch.Items.Add(s.Split('-')[1]);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxYearL.SelectedIndex = 0;
            comboBoxYearR.Text = DateTime.Now.Year.ToString();

            init_dt_batch();
            updataComboBox_batch();
        }

        /// <summary>
        /// Excel 导入tableName表数据至数据库
        /// </summary>
        /// <param name="tableName">表名</param>
        private void importData(string tableName)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件|*.xls;*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                IOExcel.IOtoSQL(fileName, tableName, CONNECTION);
            }
        }

        private void ToolStripMenuItemImportLine_Click(object sender, EventArgs e)
        {
            importData("Line");
        }

        private void ToolStripMenuItemImportSASinfo_Click(object sender, EventArgs e)
        {
            importData("SASinfo");
        }

        private void ToolStripMenuItemImportRegional_Click(object sender, EventArgs e)
        {
            importData("Regional");
        }

        /// <summary>
        /// 从数据库里删除表tableName内所有数据
        /// </summary>
        /// <param name="tableName">表名</param>
        private void DeleteData(string tableName)
        {
            SQLTool mysql = new SQLTool();

            try
            {
                mysql.open(CONNECTION);
                mysql.delete(SQLCmdStr.deleteTable(tableName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                mysql.close();
            }
            MessageBox.Show(tableName + " 删除成功");
        }

        private void ToolStripMenuItemDelSASinfo_Click(object sender, EventArgs e)
        {
            DeleteData("SASinfo");
        }

        private void ToolStripMenuItemDelLine_Click(object sender, EventArgs e)
        {
            DeleteData("Line");
        }

        private void ToolStripMenuItemDelRegional_Click(object sender, EventArgs e)
        {
            DeleteData("Regional");
        }

        /// <summary>
        /// 绘出该校该批次下文/理科所有专业数据线
        /// </summary>
        /// <param name="school">学校名</param>
        /// <param name="depart">批次</param>
        /// <param name="batch">文理</param>
        private void drawChart(string school, string depart, string batch)
        {
            SQLTool mysql = new SQLTool();
            mysql.open(CONNECTION);
            try
            {
                if (!batch.Equals("%三批%") && mysql.isThree(SQLCmdStr.isThree(school)))
                {
                    MessageBox.Show(string.Format("{0}在三本有招生!!!", school));
                }

                DataTable dtMajor = mysql.select(SQLCmdStr.selectMajor(school, depart, batch));
                DataTable dtDif = mysql.select(SQLCmdStr.selectDif(depart, batch));
                DataTable dtRank = mysql.select(SQLCmdStr.selectRank(school, depart, batch));
                DataTable dtSum = mysql.select(SQLCmdStr.selectSum(school, depart, batch));

                FormChart fc = new FormChart();
                fc.init_FormChart(school, dtMajor, dtDif, dtRank, dtSum);

                fc.Show();
                if (fc.IsDisposed) fc.Dispose();
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
        /// 双击dataGridViewSQL表格绘图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSQL_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewSQL.DataSource == null) return;

            int row = dataGridViewSQL.CurrentRow.Index;
            string school, depart, batch = "%";
            school = dataGridViewSQL.Rows[row].Cells[0].Value.ToString();
            depart = radioButtonArt.Checked ? "文科" : "理科";

            string tmp = dataGridViewSQL.Rows[row].Cells[3].Value.ToString();
            if (tmp.IndexOf("一") > 0) batch = "%一批%";
            else if (tmp.IndexOf("二") > 0) batch = "%二批%";
            else if (tmp.IndexOf("三") > 0) batch = "%三批%";
            else if (tmp.IndexOf("高") > 0) batch = "%高%";
            else batch = "%专科%";

            drawChart(school, depart, batch);
        }

        private void radioButtonArt_Click(object sender, EventArgs e)
        {
            updataComboBox_batch();
        }

        private void radioButtonScience_Click(object sender, EventArgs e)
        {
            updataComboBox_batch();
        }

        private void radioButtonScore_Click(object sender, EventArgs e)
        {
            comboBoxBatch.Visible = false;
            textBoxDif.Visible = false;

            textBoxScoreL.Visible = true;
            textBoxScoreR.Visible = true;
            labelScore.Visible = true;

            groupBoxScore.Text = "        分数—————范围";
        }

        private void radioButtonDif_Click(object sender, EventArgs e)
        {
            comboBoxBatch.Visible = true;
            textBoxDif.Visible = true;

            textBoxScoreL.Visible = false;
            textBoxScoreR.Visible = false;
            labelScore.Visible = false;

            groupBoxScore.Text = "        招生批次———线差";
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            string cmd = null;
            if (radioButtonScore.Checked) cmd = SQLCmdStr.selectSegbyScore(comboBoxYearL.Text, comboBoxYearR.Text, comboBoxRegional.Text, radioButtonArt.Checked, textBoxScoreL.Text, textBoxScoreR.Text, textBoxRankL.Text, textBoxRankR.Text);
            else cmd = SQLCmdStr.selectSegbyLine(comboBoxYearL.Text, comboBoxYearR.Text, comboBoxRegional.Text, radioButtonArt.Checked, comboBoxBatch.Text, textBoxDif.Text, textBoxRankL.Text, textBoxRankR.Text);
            if (cmd == null) return;

            SQLTool mysql = new SQLTool();
            mysql.open(CONNECTION);
            try
            {
                DataTable dt = mysql.select(cmd);

                FormStatistics fs = new FormStatistics();
                fs.init_Statistics(dt, DateTime.Now.Year - 1);
                fs.Show();
                if (fs.IsDisposed) fs.Dispose();

                dataGridViewSQL.DataSource = dt;
                dataGridViewSQL.Update();
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxYearL.SelectedIndex = 0;
            comboBoxYearR.Text = DateTime.Now.Year.ToString();

            comboBoxRegional.Text
                = textBoxScoreL.Text
                = textBoxScoreR.Text
                = textBoxDif.Text
                = textBoxRankL.Text
                = textBoxRankR.Text
                = "";

            comboBoxRegional.SelectedIndex
                = comboBoxBatch.SelectedIndex
                = -1;
        }

        private void ToolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            init_dt_batch();
            updataComboBox_batch();
        }

        private void ToolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.buttonQuery_Click(sender, e);
        }
    }
}
