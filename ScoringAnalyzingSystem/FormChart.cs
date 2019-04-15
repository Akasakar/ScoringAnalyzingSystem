using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ScoringAnalyzingSystem
{
    /// <summary>
    /// 数据绘图
    /// </summary>
    public partial class FormChart : Form
    {
        /// <summary>
        /// 专业集合
        /// </summary>
        private HashSet<string> MajorSet = new HashSet<string>();

        public FormChart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化绘图
        /// </summary>
        /// <param name="School">学校名</param>
        /// <param name="dtMajor">专业分数表</param>
        /// <param name="dtDif">批次线表</param>
        /// <param name="dtRank">专业排名表</param>
        /// <param name="dtSum">专业录取人数表</param>
        public void init_FormChart(string School, DataTable dtMajor, DataTable dtDif, DataTable dtRank, DataTable dtSum)
        {
            this.Text = School + " 折线图";
            myChart.Titles.Add(School);
            init_MajorSet(dtMajor);
            init_toolStripMenuItemMajor();
            init_ChartSeries(dtMajor, dtDif, dtRank, dtSum);
        }

        /// <summary>
        /// 初始化专业集合
        /// </summary>
        /// <param name="dt">专业表</param>
        private void init_MajorSet(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
                MajorSet.Add(dr[0].ToString());
        }

        /// <summary>
        /// 根据专业集合表初始化右键专业名称项的数据集
        /// </summary>
        private void init_toolStripMenuItemMajor()
        {
            ToolStripMenuItem tSMI1 = new ToolStripMenuItem();
            tSMI1.Name = "toolStripMenuItem历年总体";
            tSMI1.Text = "历年总体";
            tSMI1.ToolTipText = "历年总体";
            tSMI1.Click += new System.EventHandler(this.toolStripMenuItemMajor_Click);
            toolStripMenuItemMajor.DropDownItems.Add(tSMI1);
            ToolStripMenuItem tSMI2 = new ToolStripMenuItem();
            tSMI2.Name = "toolStripMenuItem特殊专业";
            tSMI2.Text = "特殊专业";
            tSMI2.ToolTipText = "特殊专业";
            tSMI2.Click += new System.EventHandler(this.toolStripMenuItemMajor_Click);
            toolStripMenuItemMajor.DropDownItems.Add(tSMI2);
            foreach (string ms in MajorSet)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = "toolStripMenuItem" + ms;
                toolStripMenuItem.Text = ms.Substring(0, Math.Min(10, ms.Length));
                toolStripMenuItem.ToolTipText = ms;
                toolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemMajor_Click);
                toolStripMenuItemMajor.DropDownItems.Add(toolStripMenuItem);
            }
            //toolStripMenuItemMajor.AutoSize = false;
        }

        /// <summary>
        /// 添加各专业的series
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="ChartArea">区域名</param>
        /// <param name="Legend">图例名</param>
        /// <param name="LegendToolTip">图例映射格式</param>
        /// <param name="ToolTip">点映射格式</param>
        /// <param name="ChartType">图类型</param>
        private void init_Series(DataTable dt, string ChartArea, string Legend, string LegendToolTip, string ToolTip, System.Windows.Forms.DataVisualization.Charting.SeriesChartType ChartType)
        {
            //MessageBox.Show(ChartArea + " " + Legend);
            //各专业映射
            Dictionary<string, List<int>> mpx = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> mpy = new Dictionary<string, List<int>>();
            foreach (string ms in MajorSet)
            {
                mpx[ms] = new List<int>();
                mpy[ms] = new List<int>();
            }

            foreach (DataRow dr in dt.Rows)
            {
                mpx[dr[0].ToString()].Add((int)dr[1]);
                mpy[dr[0].ToString()].Add((int)dr[2]);
            }

            string s = null;
            foreach (string ms in MajorSet)
            {
                s = ms + ChartArea;
                myChart.Series.Add(s);
                myChart.Series[s].ChartArea = ChartArea;
                myChart.Series[s].IsVisibleInLegend = true;
                myChart.Series[s].Legend = Legend;
                myChart.Series[s].LegendText = ms;

                myChart.Series[s].LegendToolTip = string.Format(LegendToolTip, ms, ms, ms);
                myChart.Series[s].ToolTip = string.Format(ToolTip, ms);

                myChart.Series[s].ChartType = ChartType;
                myChart.Series[s].Enabled = false;
                myChart.Series[s].IsValueShownAsLabel = true;
                if (!ChartArea.Equals("ChartAreaSum"))
                    myChart.Series[s].BorderWidth = 3;
                myChart.Series[s].Color = System.Drawing.Color.Blue;
                try
                {
                    myChart.Series[s].Points.DataBindXY(mpx[ms], mpy[ms]);
                }
                catch (Exception ex)
                {
                    myChart.Series[s].Points.Clear();
                    MessageBox.Show(ms + " 出现重复列\n" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 为整数数组初始化数值v
        /// </summary>
        /// <param name="a">数组</param>
        /// <param name="v">初始化数值</param>
        private void init_Integers(int[] a, int v)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] = v;
        }

        /// <summary>
        /// 特殊的线，可能是重复专业，少数名族，特别招生
        /// </summary>
        /// <param name="dtMajor">专业分数表</param>
        /// <param name="ab0">特殊名</param>
        private void SpecialLine(DataTable dtMajor, char ab0)
        {
            List<int> LxMin = new List<int>();
            List<int> LyMin = new List<int>();
            const int yearStart = 2010;
            int[] mp = new int[20];
            string s = null;
            for (char rep = '0'; rep < '3'; rep++)
            {
                init_Integers(mp, 800);
                foreach (DataRow dr in dtMajor.Rows)
                {
                    string tmp = dr[0].ToString();
                    char c = tmp[tmp.Length - 2];
                    if (c != ab0) continue;
                    c = tmp[tmp.Length - 1];
                    if (c != rep) continue;
                    mp[(int)dr[1] - yearStart] = Math.Min(mp[(int)dr[1] - yearStart], (int)dr[2]);
                }
                s = "历年总体" + "ChartAreaMajor" + ab0 + rep;
                myChart.Series.Add(s);
                myChart.Series[s].ChartArea = "ChartAreaMajor";
                myChart.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                myChart.Series[s].IsVisibleInLegend = true;
                myChart.Series[s].Legend = "LegendMajor";
                myChart.Series[s].LegendText = "最低录取线" + ab0 + rep;
                myChart.Series[s].LegendToolTip = "最低分:#MIN\n最高分:#MAX\n平均分:#AVG\n";
                myChart.Series[s].IsValueShownAsLabel = true;
                myChart.Series[s].BorderWidth = 2;
                //添加点
                for (int i = 0; i < mp.Length; i++)
                {
                    if (mp[i] == 800) continue;
                    LxMin.Add(i + yearStart);
                    LyMin.Add(mp[i]);
                    System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint(i + yearStart, mp[i]);
                    dp.ToolTip = "";
                    foreach (DataRow dr in dtMajor.Rows)
                        if (i + yearStart == (int)dr[1] && mp[i] == (int)dr[2])
                            dp.ToolTip += dr[0].ToString() + "\n";
                    myChart.Series[s].Points.Add(dp);
                }
                if (myChart.Series[s].Points.Count == 0)
                    myChart.Series[s].Enabled = false;

                //s = "历年总体" + "ChartAreaDif" + ab0 + rep;
                //myChart.Series.Add(s);
                //myChart.Series[s].ChartArea = "ChartAreaDif";
                //myChart.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //myChart.Series[s].IsVisibleInLegend = true;
                //myChart.Series[s].Legend = "LegendDif";
                //myChart.Series[s].LegendText = "最低录取线" + ab0 + rep;
                //myChart.Series[s].ToolTip = "#VALX年 #VAL 分";
                //myChart.Series[s].LegendToolTip = "最低分:#MIN\n最高分:#MAX\n平均分:#AVG\n";
                //myChart.Series[s].IsValueShownAsLabel = true;
                //myChart.Series[s].BorderWidth = 2;
                //myChart.Series[s].Points.DataBindXY(LxMin, LyMin);
            }
        }

        /// <summary>
        /// 添加学校的最低录取标准线
        /// </summary>
        /// <param name="dtMajor">专业分数表</param>
        /// <param name="dtDif">批次线表</param>
        /// <param name="dtRank">专业排名表</param>
        /// <param name="dtSum">录取人数表</param>
        private void init_ChartSeries(DataTable dtMajor, DataTable dtDif, DataTable dtRank, DataTable dtSum)
        {

            List<int> LxMin = new List<int>();
            List<int> LyMin = new List<int>();
            List<int> LxDif = new List<int>();
            List<int> LyDif = new List<int>();
            List<int> LxMax = new List<int>();
            List<int> LyMax = new List<int>();
            List<int> LxSum = new List<int>();
            List<int> LySum = new List<int>();

            const int yearStart = 2010;
            int ymin;
            int ymax;
            int dis;
            int[] mp = new int[20];
            string s = null;

            #region 该校最低录取分数线，绘制到专业分数图
            init_Integers(mp, 800);
            foreach (DataRow dr in dtMajor.Rows)
            {
                string tmp = dr[0].ToString();
                char c = tmp[tmp.Length - 2];
                if (c == 'A' || c == 'B' || c == '0') continue;
                mp[(int)dr[1] - yearStart] = Math.Min(mp[(int)dr[1] - yearStart], (int)dr[2]);
            }
            s = "历年总体" + "ChartAreaMajor";
            myChart.Series.Add(s);
            myChart.Series[s].ChartArea = "ChartAreaMajor";
            myChart.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            myChart.Series[s].IsVisibleInLegend = true;
            myChart.Series[s].Legend = "LegendMajor";
            myChart.Series[s].LegendText = "最低录取线";
            myChart.Series[s].LegendToolTip = "最低分:#MIN\n最高分:#MAX\n平均分:#AVG\n";
            myChart.Series[s].IsValueShownAsLabel = true;
            myChart.Series[s].BorderWidth = 3;
            myChart.Series[s].Color = System.Drawing.Color.Red;
            //添加点
            for (int i = 0; i < mp.Length; i++)
            {
                if (mp[i] == 800) continue;
                LxMin.Add(i + yearStart);
                LyMin.Add(mp[i]);
                System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint(i + yearStart, mp[i]);
                dp.ToolTip = "";
                foreach (DataRow dr in dtMajor.Rows)
                    if (i + yearStart == (int)dr[1] && mp[i] == (int)dr[2])
                        dp.ToolTip += dr[0].ToString() + "\n";
                myChart.Series[s].Points.Add(dp);
            }
            #endregion

            #region 该校最低录取线，绘制到线差图
            s = "历年总体" + "ChartAreaDif";
            myChart.Series.Add(s);
            myChart.Series[s].ChartArea = "ChartAreaDif";
            myChart.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            myChart.Series[s].IsVisibleInLegend = true;
            myChart.Series[s].Legend = "LegendDif";
            myChart.Series[s].LegendText = "最低录取线";
            myChart.Series[s].ToolTip = "#VALX年 #VAL 分";
            myChart.Series[s].LegendToolTip = "最低分:#MIN\n最高分:#MAX\n平均分:#AVG\n";
            myChart.Series[s].IsValueShownAsLabel = true;
            myChart.Series[s].BorderWidth = 3;
            myChart.Series[s].Color = System.Drawing.Color.Green;
            myChart.Series[s].Points.DataBindXY(LxMin, LyMin);
            #endregion

            #region 特殊线，绘制到专业分数图
            SpecialLine(dtMajor, 'A');
            SpecialLine(dtMajor, 'B');
            SpecialLine(dtMajor, '0');
            #endregion

            #region 批次线，绘制到线差图
            ymin = 800;
            ymax = 0;
            init_Integers(mp, 800);
            foreach (DataRow dr in dtMajor.Rows)
            {
                mp[(int)dr[1] - yearStart] = Math.Min(mp[(int)dr[1] - yearStart], (int)dr[2]);
                ymin = Math.Min(ymin, (int)dr[2]);
                ymax = Math.Max(ymax, (int)dr[2]);
            }
            foreach (DataRow dr in dtDif.Rows)
            {
                LxDif.Add((int)dr[1]);
                LyDif.Add((int)dr[2]);
                ymin = Math.Min(ymin, (int)dr[2]);
                ymax = Math.Max(ymax, (int)dr[2]);
            }

            //绘图区域Y轴坐标范围和间隔
            dis = 10;
            myChart.ChartAreas["ChartAreaMajor"].AxisY.Minimum = ymin / dis * dis;
            myChart.ChartAreas["ChartAreaMajor"].AxisY.Maximum = (ymax + dis - 1) / dis * dis;
            myChart.ChartAreas["ChartAreaDif"].AxisY.Minimum = ymin / dis * dis;
            myChart.ChartAreas["ChartAreaDif"].AxisY.Maximum = (ymax + dis - 1) / dis * dis;

            s = dtDif.Rows[0][0].ToString();
            myChart.Series.Add(s);
            myChart.Series[s].ChartArea = "ChartAreaDif";
            myChart.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            myChart.Series[s].IsVisibleInLegend = true;
            myChart.Series[s].Legend = "LegendDif";
            myChart.Series[s].LegendText = s;
            myChart.Series[s].ToolTip = string.Format("#VALX年 {0}:#VAL", s);
            myChart.Series[s].LegendToolTip = string.Format("{0}历年最低:#MIN\n{1}历年最高:#MAX\n{1}历年平均:#AVG\n", s, s, s);
            myChart.Series[s].IsValueShownAsLabel = true;
            myChart.Series[s].BorderWidth = 3;
            myChart.Series[s].Color = System.Drawing.Color.Red;
            myChart.Series[s].Points.DataBindXY(LxDif, LyDif);
            #endregion

            #region 该校最低录取排名线，绘制到排名线图
            ymin = 500000;
            ymax = 0;
            init_Integers(mp, 0);
            foreach (DataRow dr in dtRank.Rows)
            {
                ymin = Math.Min(ymin, (int)dr[2]);
                ymax = Math.Max(ymax, (int)dr[2]);
                string tmp = dr[0].ToString();
                char c = tmp[tmp.Length - 2];
                if (c == 'A' || c == 'B' || c == '0') continue;
                mp[(int)dr[1] - yearStart] = Math.Max(mp[(int)dr[1] - yearStart], (int)dr[2]);
            }
            for (int i = 0; i < mp.Length; i++)
            {
                if (mp[i] == 0) continue;
                LxMax.Add(i + yearStart);
                LyMax.Add(mp[i]);
            }
            //绘图区域Y轴坐标范围和间隔
            dis = (int)Math.Pow(10, Math.Max(1, (int)Math.Log10(Math.Abs(ymax - ymin))));
            myChart.ChartAreas["ChartAreaRank"].AxisY.Minimum = ymin / dis * dis;
            myChart.ChartAreas["ChartAreaRank"].AxisY.Maximum = (ymax + dis - 1) / dis * dis;

            s = "历年总体" + "ChartAreaRank";
            myChart.Series.Add(s);
            myChart.Series[s].ChartArea = "ChartAreaRank";
            myChart.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            myChart.Series[s].IsVisibleInLegend = true;
            myChart.Series[s].Legend = "LegendRank";
            myChart.Series[s].LegendText = "最低段位线";
            myChart.Series[s].ToolTip = "#VALX年专业最低段位:#VAL";
            myChart.Series[s].LegendToolTip = "最低:#MAX\n最高:#MIN\n平均:#AVG\n";
            myChart.Series[s].IsValueShownAsLabel = true;
            myChart.Series[s].BorderWidth = 3;
            myChart.Series[s].Color = System.Drawing.Color.Red;
            myChart.Series[s].Points.DataBindXY(LxMax, LyMax);
            #endregion

            #region 该校总招生人数柱状图，会知道招生人数图
            ymax = 0;
            init_Integers(mp, 0);
            foreach (DataRow dr in dtSum.Rows)
                mp[(int)dr[1] - yearStart] += (int)dr[2];
            for (int i = 0; i < mp.Length; i++)
            {
                if (mp[i] == 0) continue;
                LxSum.Add(i + yearStart);
                LySum.Add(mp[i]);
                ymax = Math.Max(ymax, mp[i]);
            }
            //绘图区域Y轴坐标范围和间隔
            myChart.ChartAreas["ChartAreaSum"].AxisY.Minimum = 0;
            myChart.ChartAreas["ChartAreaSum"].AxisY.Maximum = (ymax + 9) / 10 * 10;

            s = "历年总体" + "ChartAreaSum";
            myChart.Series.Add(s);
            myChart.Series[s].ChartArea = "ChartAreaSum";
            myChart.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            myChart.Series[s].IsVisibleInLegend = true;
            myChart.Series[s].Legend = "LegendSum";
            myChart.Series[s].LegendText = "总招生人数";
            myChart.Series[s].ToolTip = "#VALX年总招生:#VAL人";
            myChart.Series[s].LegendToolTip = "最低:#MIN\n最高:#MAX\n平均:#AVG\n";
            myChart.Series[s].IsValueShownAsLabel = true;
            //myChart.Series[s].BorderWidth = 3;
            myChart.Series[s].Color = System.Drawing.Color.Orange;
            myChart.Series[s].Points.DataBindXY(LxSum, LySum);
            #endregion

            init_Series(dtMajor, "ChartAreaMajor", "LegendMajor", "{0}最低:#MIN\n{1}最高:#MAX\n{2}平均:#AVG\n", "#VALX年{0}:#VAL", System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line);

            init_Series(dtMajor, "ChartAreaDif", "LegendDif", "{0}最低:#MIN\n{1}最高:#MAX\n{2}平均:#AVG\n", "#VALX年{0}:#VAL", System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line);

            init_Series(dtRank, "ChartAreaRank", "LegendRank", "{0}最低段位:#MAX\n{1}最高段位:#MIN\n{2}平均段位:#AVG\n", "#VALX年{0}:#VAL", System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line);

            init_Series(dtSum, "ChartAreaSum", "LegendSum", "{0}最少:#MIN人\n{1}最多:#MAX人\n{2}平均:#AVG人\n", "#VALX年{0}:#VAL 人", System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column);

            //MajorSet.Add("历年总体");
        }

        /// <summary>
        /// 部分折线暂时不展示
        /// </summary>
        /// <param name="s">折线名称</param>
        private void HideLine(string s)
        {
            for (char rep = '0'; rep < '3'; rep++)
            {
                try
                {
                    if (myChart.Series[s + rep].Points.Count != 0)
                        myChart.Series[s + rep].Enabled = !myChart.Series[s + rep].Enabled;
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 点击专业事件，显示或隐藏专业折线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemMajor_Click(object sender, EventArgs e)
        {
            ///添加点击专业的事件
            ToolStripMenuItem TSMI = (ToolStripMenuItem)sender;
            string Text = TSMI.ToolTipText;
            if (Text.Equals("历年总体"))
            {
                myChart.Series["历年总体ChartAreaMajor"].Enabled = !myChart.Series["历年总体ChartAreaMajor"].Enabled;
                myChart.Series["历年总体ChartAreaDif"].Enabled = !myChart.Series["历年总体ChartAreaDif"].Enabled;
                myChart.Series["历年总体ChartAreaRank"].Enabled = !myChart.Series["历年总体ChartAreaRank"].Enabled;
                return;
            }
            else if (Text.Equals("特殊专业"))
            {
                HideLine("历年总体ChartAreaMajorA");
                HideLine("历年总体ChartAreaMajorB");
                HideLine("历年总体ChartAreaMajor0");
                //HideLine("历年总体ChartAreaDifA");
                //HideLine("历年总体ChartAreaDifB");
                //HideLine("历年总体ChartAreaDif0");
            }

            string[] sType = { "ChartAreaMajor", "ChartAreaDif", "ChartAreaRank", "ChartAreaSum" };
            string s = null;
            foreach (string ms in MajorSet)
            {
                bool ok = ms.Equals(Text);
                for (int i = 0; i < sType.Length; i++)
                {
                    s = ms + sType[i];
                    myChart.Series[s].Enabled = ok;
                }
            }
        }

        private void toolStripMenuItemCopyImage_Click(object sender, EventArgs e)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                myChart.SaveImage(ms, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
                Clipboard.Clear();
                Clipboard.SetImage(new System.Drawing.Bitmap(ms));
            }
        }

        private void toolStripMenuItemExportImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "有损压缩|*.jpeg|无损压缩|*.png";
            sfd.FileName = "picture";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;
                if (sfd.FilterIndex == 0)
                    myChart.SaveImage(fileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
                else myChart.SaveImage(fileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                MessageBox.Show("SaveImage OK");
            }
        }

        private void toolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
