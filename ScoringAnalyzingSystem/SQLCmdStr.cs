using System;
using System.Windows.Forms;

namespace ScoringAnalyzingSystem
{
    /// <summary>
    /// 静态类 SQL命令语句
    /// </summary>
    static class SQLCmdStr
    {
        /// <summary>
        /// SQL语句，选择批次线
        /// </summary>
        /// <returns>返回"select * from Line"</returns>
        public static string selectLine()
        {
            return "select * from Line";
        }

        /// <summary>
        /// SQL语句，按照分数选择搜索区间
        /// <para>搜索2015年至今的吉林省，文科，660以上，不限排名的高校录取信息</para>
        /// <example><code>
        /// string cmd = selectSegbyScore("2015","","吉林省","文科","666","","","");
        /// </code></example>
        /// </summary>
        /// <param name="yearLText">时间左值，只能是数字字符串，内容可以为空</param>
        /// <param name="yearRText">时间右值，只能是数字字符串，内容可以为空</param>
        /// <param name="reginonalText">省市地区</param>
        /// <param name="artChecked">文科是否被选中</param>
        /// <param name="scoreLText">分数左值，只能是数字字符串，内容可以为空</param>
        /// <param name="scoreRText">分数右值，只能是数字字符串，内容可以为空</param>
        /// <param name="rankLText">排名左值，只能是数字字符串，内容可以为空</param>
        /// <param name="rankRText">排名右值，只能是数字字符串，内容可以为空</param>
        /// <returns></returns>
        public static string selectSegbyScore
            (
            string yearLText,
            string yearRText,
            string reginonalText,
            bool artChecked,
            string scoreLText,
            string scoreRText,
            string rankLText,
            string rankRText
            )
        {
            int yearL = 0, yearR = System.DateTime.Now.Year;
            string area = null;
            string depart = "理科";
            int scoreL = 0, scoreR = int.MaxValue;
            int lowRankL = 0, lowRankR = int.MaxValue;

            #region 数据文本处理，保证数据范围准确
            if (reginonalText != null && !reginonalText.Trim(' ').Equals(""))
                area = reginonalText.Trim(' ');
            if (artChecked) depart = "文科";
            try
            {
                yearL = Math.Max(yearL, int.Parse(yearLText));
                yearR = Math.Min(yearR, int.Parse(yearRText));

                if (scoreLText != null && !scoreLText.Trim(' ').Equals(""))
                    scoreL = Math.Max(scoreL, int.Parse(scoreLText));
                if (scoreRText != null && !scoreRText.Trim(' ').Equals(""))
                    scoreR = Math.Min(scoreR, int.Parse(scoreRText));

                if (rankLText != null && !rankLText.Trim(' ').Equals(""))
                    lowRankL = Math.Max(lowRankL, int.Parse(rankLText));
                if (rankRText != null && !rankRText.Trim(' ').Equals(""))
                    lowRankR = Math.Min(lowRankR, int.Parse(rankRText));
            }
            catch (FormatException fex)
            {
                MessageBox.Show("\n时间分数等只允许数字值\n" + fex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            #endregion

            string cmd = "select 学校, 专业名称, 时间, 招生批次, 最低分, 最高分, 平均分, 最低位次, 录取数"
                        + " from SASinfo"
                        + " where 时间 between {0} and {1}"
                        + " and 文理 = '{2}'"
                        + " and 最低分 between {3} and {4}"
                        + " and 最低位次 between {5} and {6}";
            if (area != null) cmd += string.Format(" and 学校 in (select 学校  from Regional where 地区 = '{0}')", area);
            cmd += " order by 学校 asc, 专业名称 asc, 时间 desc, 最低分 desc";
            return string.Format(cmd, yearL, yearR, depart, scoreL, scoreR, lowRankL, lowRankR);
        }

        /// <summary>
        /// SQL语句，按照分数选择搜索区间
        /// <para>搜索2015年至今的吉林省，文科，本科一批线上30分，不限排名的高校录取信息</para>
        /// <example><code>
        /// string cmd = selectSegbyScore("2015","","吉林省","文科","本科一批","+30","","");
        /// </code></example>
        /// </summary>
        /// <param name="yearLText">时间左值，只能是数字字符串，内容可以为空</param>
        /// <param name="yearRText">时间右值，只能是数字字符串，内容可以为空</param>
        /// <param name="reginonalText">省市地区</param>
        /// <param name="artChecked">文科是否被选中</param>
        /// <param name="batchText">批次线</param>
        /// <param name="difText">线差，只能是数字字符串，内容可以为空</param>
        /// <param name="rankLText">排名左值，只能是数字字符串，内容可以为空</param>
        /// <param name="rankRText">排名右值，只能是数字字符串，内容可以为空</param>
        /// <returns></returns>
        public static string selectSegbyLine
            (
            string yearLText,
            string yearRText,
            string reginonalText,
            bool artChecked,
            string batchText,
            string difText,
            string rankLText,
            string rankRText
            )
        {
            int yearL = 0, yearR = DateTime.Now.Year;
            string area = null;
            string depart = "理科";
            string batch = batchText;
            int dif = 0;
            int rankL = 0, rankR = int.MaxValue;

            #region 数据文本处理，保证数据范围准确
            if (reginonalText != null && !reginonalText.Trim(' ').Equals(""))
                area = reginonalText.Trim(' ');
            if (artChecked) depart = "文科";
            try
            {
                yearL = Math.Max(yearL, int.Parse(yearLText));
                yearR = Math.Min(yearR, int.Parse(yearRText));

                if (difText != null && !difText.Trim(' ').Equals(""))
                    dif = int.Parse(difText);

                if (rankLText != null && !rankLText.Trim(' ').Equals(""))
                    rankL = Math.Max(rankL, int.Parse(rankLText));
                if (rankRText != null && !rankRText.Trim(' ').Equals(""))
                    rankR = Math.Min(rankR, int.Parse(rankRText));
            }
            catch (FormatException fex)
            {
                MessageBox.Show("\n时间分数等只允许数字值\n" + fex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            #endregion

            string cmd = null;
            cmd
                = "declare @yearL int, @yearR int; declare @area nvarchar(8); declare @depart nvarchar(8); declare @batch nvarchar(16); declare @dif int; declare @rankL int, @rankR int; "
                + "set @yearL = {0}; set @yearR = {1}; set @area = '{2}' set @depart = '{3}'; set @batch = '{4}' set @dif = {5} set @rankL = {6}; set @rankR = {7}; "
                + "select A.学校, A.专业名称, A.时间, A.招生批次, A.最低分, A.最高分, A.平均分, A.最低位次, A.录取数 "
                + "from SASinfo as A, (select 时间, 分数线 from Line where 招生批次 = @batch and 文理 = @depart and 时间 between @yearL and @yearR) as B "
                + "where A.文理 = @depart and A.最低位次 between @rankL and @rankR ";
            if (area != null) cmd += "and A.学校 in (select C.学校 from Regional as C where C.地区 = @area) ";
            cmd
                += "and A.时间 = B.时间 "
                + "and A.最低分 between (select case when B.分数线 < B.分数线 + @dif then B.分数线 else B.分数线 + @dif end) and (select case when B.分数线 < B.分数线 + @dif then B.分数线 + @dif else B.分数线 end) "
                + "order by 学校 asc, 专业名称 asc, 时间 desc, 最低分 desc;";
            return string.Format(cmd, yearL, yearR, area, depart, batch, dif, rankL, rankR);
        }

        /// <summary>
        /// SQL语句，搜索该校同批次线的所有专业录取分数信息
        /// <para>搜索吉林大学本科一批文科所有专业录取分数信息</para>
        /// <example><code>
        /// string cmd = selectMajor("吉林大学","文科","%一批%");
        /// </code></example>
        /// </summary>
        /// <param name="school">学校名</param>
        /// <param name="depart">文理</param>
        /// <param name="batch">批次</param>
        /// <returns></returns>
        public static string selectMajor(string school, string depart, string batch)
        {
            string cmd = null;
            cmd = "declare @school nvarchar(128);declare @depart nvarchar(8);declare @batch nvarchar(16);"
                + "set @school = '{0}';set @depart = '{1}';set @batch = '{2}';"
                + "select 专业名称, 时间, 最低分 from SASinfo "
                + "where 学校 = @school and 文理 = @depart and 招生批次 like @batch order by 专业名称, 时间";
            return string.Format(cmd, school, depart, batch);
        }

        /// <summary>
        /// SQL语句，搜索往年至今的批次线
        /// <example><code>
        /// string cmd = selectDif("理科","%一批%");
        /// </code></example>
        /// </summary>
        /// <param name="depart">文理</param>
        /// <param name="batch">批次</param>
        /// <returns></returns>
        public static string selectDif(string depart, string batch)
        {
            string cmd = "select 招生批次, 时间, 分数线 from Line where 文理 = '{0}' and 招生批次 like '{1}' order by 时间";
            return string.Format(cmd, depart, batch);
        }

        /// <summary>
        /// SQL语句，搜索该校同批次线的所有专业录取排名信息
        /// <para>搜索吉林大学本科一批文科所有专业录取排名信息</para>
        /// <example><code>
        /// string cmd = selectRank("吉林大学","文科","%一批%");
        /// </code></example>
        /// </summary>
        /// <param name="school">学校名</param>
        /// <param name="depart">文理</param>
        /// <param name="batch">批次</param>
        /// <returns></returns>
        public static string selectRank(string school, string depart, string batch)
        {
            string cmd = null;
            cmd = "declare @school nvarchar(128);declare @depart nvarchar(8);declare @batch nvarchar(16);"
                + "set @school = '{0}';set @depart = '{1}';set @batch = '{2}';"
                + "select 专业名称, 时间, 最低位次 from SASinfo "
                + "where 学校 = @school and 文理 = @depart and 招生批次 like @batch order by 专业名称, 时间";
            return string.Format(cmd, school, depart, batch);
        }

        /// <summary>
        /// SQL语句，搜索该校同批次线的所有专业录取人数信息
        /// <para>搜索吉林大学本科一批文科所有专业录取人数信息</para>
        /// <example><code>
        /// string cmd = selectSum("吉林大学","文科","%一批%");
        /// </code></example>
        /// </summary>
        /// <param name="school">学校名</param>
        /// <param name="depart">文理</param>
        /// <param name="batch">批次</param>
        /// <returns></returns>
        public static string selectSum(string school, string depart, string batch)
        {
            string cmd = null;
            cmd = "declare @school nvarchar(128);declare @depart nvarchar(8);declare @batch nvarchar(16);"
                + "set @school = '{0}';set @depart = '{1}';set @batch = '{2}';"
                + "select 专业名称, 时间, 录取数 from SASinfo "
                + "where 学校 = @school and 文理 = @depart and 招生批次 like @batch order by 专业名称, 时间";
            return string.Format(cmd, school, depart, batch);
        }

        /// <summary>
        /// SQL语句，该校是否在三批招生过
        /// </summary>
        /// <param name="School">学校名</param>
        /// <returns></returns>
        public static string isThree(string School)
        {
            return string.Format("select distinct(1) from SASinfo where 学校 = '{0}' and 招生批次 like '%三%'", School);
        }

        /// <summary>
        /// SQL语句，删除表内所有信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string deleteTable(string tableName)
        {
            return string.Format("truncate table {0}", tableName);
        }
    }
}
