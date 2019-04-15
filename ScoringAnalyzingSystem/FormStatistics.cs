using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ScoringAnalyzingSystem
{
    /// <summary>
    /// 数据报表，展示去年学校和专业数量的信息
    /// </summary>
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化数据报表
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="year">时间</param>
        public void init_Statistics(DataTable dt, int year)
        {
            Dictionary<string, int> mp = new Dictionary<string, int>();
            foreach (DataRow dr in dt.Rows)
                mp[dr[0].ToString()] = 0;
            foreach (DataRow dr in dt.Rows)
                if (year == (int)dr[2])
                    mp[dr[0].ToString()]++;
            int sum = 0;
            List<KeyValuePair<string, int>> lsi = new List<KeyValuePair<string, int>>();
            foreach (string s in mp.Keys)
            {
                lsi.Add(new KeyValuePair<string, int>(s, mp[s]));
                sum += mp[s];
            }
            lsi.Sort((x, y) => y.Value.CompareTo(x.Value));
            string Statistics = string.Format("共{0, 4}所大学{1, 10}\t有{2}个专业可供选择\n", mp.Count, ' ', sum);
            foreach (KeyValuePair<string, int> si in lsi)
                Statistics += string.Format("{0, -24}\t有{1}个专业\n", si.Key, si.Value);
            rtbStats.Text = Statistics;
            //MessageBox.Show(Statistics);
        }
    }
}
