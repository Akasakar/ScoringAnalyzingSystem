namespace ScoringAnalyzingSystem
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dataGridViewSQL = new System.Windows.Forms.DataGridView();
            this.labelYear = new System.Windows.Forms.Label();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.groupBoxYear = new System.Windows.Forms.GroupBox();
            this.comboBoxYearR = new System.Windows.Forms.ComboBox();
            this.comboBoxYearL = new System.Windows.Forms.ComboBox();
            this.comboBoxRegional = new System.Windows.Forms.ComboBox();
            this.groupBoxRegional = new System.Windows.Forms.GroupBox();
            this.radioButtonArt = new System.Windows.Forms.RadioButton();
            this.radioButtonScience = new System.Windows.Forms.RadioButton();
            this.groupBoxDepart = new System.Windows.Forms.GroupBox();
            this.textBoxScoreL = new System.Windows.Forms.TextBox();
            this.groupBoxScore = new System.Windows.Forms.GroupBox();
            this.textBoxDif = new System.Windows.Forms.TextBox();
            this.textBoxScoreR = new System.Windows.Forms.TextBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.radioButtonDif = new System.Windows.Forms.RadioButton();
            this.radioButtonScore = new System.Windows.Forms.RadioButton();
            this.comboBoxBatch = new System.Windows.Forms.ComboBox();
            this.groupBoxRank = new System.Windows.Forms.GroupBox();
            this.textBoxRankR = new System.Windows.Forms.TextBox();
            this.labelRank = new System.Windows.Forms.Label();
            this.textBoxRankL = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.menuStripFormMain = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemImportData = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemImportSASinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemImportLine = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemImportRegional = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelData = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelSASinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelLine = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelRegional = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSQL)).BeginInit();
            this.groupBoxYear.SuspendLayout();
            this.groupBoxRegional.SuspendLayout();
            this.groupBoxDepart.SuspendLayout();
            this.groupBoxScore.SuspendLayout();
            this.groupBoxRank.SuspendLayout();
            this.menuStripFormMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSQL
            // 
            this.dataGridViewSQL.AllowUserToAddRows = false;
            this.dataGridViewSQL.AllowUserToDeleteRows = false;
            this.dataGridViewSQL.AllowUserToOrderColumns = true;
            this.dataGridViewSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSQL.Location = new System.Drawing.Point(12, 85);
            this.dataGridViewSQL.Name = "dataGridViewSQL";
            this.dataGridViewSQL.ReadOnly = true;
            this.dataGridViewSQL.RowTemplate.Height = 23;
            this.dataGridViewSQL.Size = new System.Drawing.Size(887, 387);
            this.dataGridViewSQL.TabIndex = 2;
            this.dataGridViewSQL.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewSQL_MouseDoubleClick);
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(73, 26);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(15, 15);
            this.labelYear.TabIndex = 7;
            this.labelYear.Text = "-";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonQuery.Location = new System.Drawing.Point(826, 26);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(72, 23);
            this.buttonQuery.TabIndex = 26;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // groupBoxYear
            // 
            this.groupBoxYear.Controls.Add(this.comboBoxYearR);
            this.groupBoxYear.Controls.Add(this.comboBoxYearL);
            this.groupBoxYear.Controls.Add(this.labelYear);
            this.groupBoxYear.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxYear.Location = new System.Drawing.Point(12, 26);
            this.groupBoxYear.Name = "groupBoxYear";
            this.groupBoxYear.Size = new System.Drawing.Size(160, 53);
            this.groupBoxYear.TabIndex = 10;
            this.groupBoxYear.TabStop = false;
            this.groupBoxYear.Text = "时间/年";
            // 
            // comboBoxYearR
            // 
            this.comboBoxYearR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxYearR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearR.DropDownHeight = 120;
            this.comboBoxYearR.DropDownWidth = 40;
            this.comboBoxYearR.FormattingEnabled = true;
            this.comboBoxYearR.IntegralHeight = false;
            this.comboBoxYearR.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.comboBoxYearR.Location = new System.Drawing.Point(89, 23);
            this.comboBoxYearR.Name = "comboBoxYearR";
            this.comboBoxYearR.Size = new System.Drawing.Size(65, 22);
            this.comboBoxYearR.Sorted = true;
            this.comboBoxYearR.TabIndex = 12;
            // 
            // comboBoxYearL
            // 
            this.comboBoxYearL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxYearL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearL.DropDownHeight = 120;
            this.comboBoxYearL.DropDownWidth = 50;
            this.comboBoxYearL.FormattingEnabled = true;
            this.comboBoxYearL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxYearL.IntegralHeight = false;
            this.comboBoxYearL.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.comboBoxYearL.Location = new System.Drawing.Point(6, 23);
            this.comboBoxYearL.Name = "comboBoxYearL";
            this.comboBoxYearL.Size = new System.Drawing.Size(65, 22);
            this.comboBoxYearL.Sorted = true;
            this.comboBoxYearL.TabIndex = 11;
            // 
            // comboBoxRegional
            // 
            this.comboBoxRegional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxRegional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRegional.DropDownHeight = 200;
            this.comboBoxRegional.DropDownWidth = 75;
            this.comboBoxRegional.FormattingEnabled = true;
            this.comboBoxRegional.IntegralHeight = false;
            this.comboBoxRegional.Items.AddRange(new object[] {
            "安徽省",
            "澳门",
            "北京市",
            "福建省",
            "甘肃省",
            "广东省",
            "广西省",
            "贵州省",
            "海南省",
            "河北省",
            "河南省",
            "黑龙江省",
            "湖北省",
            "湖南省",
            "吉林省",
            "江苏省",
            "江西省",
            "辽宁省",
            "内蒙古",
            "宁夏",
            "青海省",
            "山东省",
            "山西省",
            "陕西省",
            "上海市",
            "四川省",
            "台湾",
            "天津市",
            "西藏",
            "香港",
            "新疆",
            "云南省",
            "浙江省",
            "重庆市"});
            this.comboBoxRegional.Location = new System.Drawing.Point(6, 23);
            this.comboBoxRegional.MaxDropDownItems = 36;
            this.comboBoxRegional.Name = "comboBoxRegional";
            this.comboBoxRegional.Size = new System.Drawing.Size(90, 22);
            this.comboBoxRegional.Sorted = true;
            this.comboBoxRegional.TabIndex = 14;
            // 
            // groupBoxRegional
            // 
            this.groupBoxRegional.Controls.Add(this.comboBoxRegional);
            this.groupBoxRegional.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxRegional.Location = new System.Drawing.Point(178, 26);
            this.groupBoxRegional.Name = "groupBoxRegional";
            this.groupBoxRegional.Size = new System.Drawing.Size(100, 53);
            this.groupBoxRegional.TabIndex = 13;
            this.groupBoxRegional.TabStop = false;
            this.groupBoxRegional.Text = "地区/省份";
            // 
            // radioButtonArt
            // 
            this.radioButtonArt.AutoSize = true;
            this.radioButtonArt.Checked = true;
            this.radioButtonArt.Location = new System.Drawing.Point(6, 24);
            this.radioButtonArt.Name = "radioButtonArt";
            this.radioButtonArt.Size = new System.Drawing.Size(55, 19);
            this.radioButtonArt.TabIndex = 16;
            this.radioButtonArt.TabStop = true;
            this.radioButtonArt.Text = "文科";
            this.radioButtonArt.UseVisualStyleBackColor = true;
            this.radioButtonArt.Click += new System.EventHandler(this.radioButtonArt_Click);
            // 
            // radioButtonScience
            // 
            this.radioButtonScience.AutoSize = true;
            this.radioButtonScience.Location = new System.Drawing.Point(63, 24);
            this.radioButtonScience.Name = "radioButtonScience";
            this.radioButtonScience.Size = new System.Drawing.Size(55, 19);
            this.radioButtonScience.TabIndex = 17;
            this.radioButtonScience.Text = "理科";
            this.radioButtonScience.UseVisualStyleBackColor = true;
            this.radioButtonScience.Click += new System.EventHandler(this.radioButtonScience_Click);
            // 
            // groupBoxDepart
            // 
            this.groupBoxDepart.Controls.Add(this.radioButtonScience);
            this.groupBoxDepart.Controls.Add(this.radioButtonArt);
            this.groupBoxDepart.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxDepart.Location = new System.Drawing.Point(284, 26);
            this.groupBoxDepart.Name = "groupBoxDepart";
            this.groupBoxDepart.Size = new System.Drawing.Size(118, 53);
            this.groupBoxDepart.TabIndex = 15;
            this.groupBoxDepart.TabStop = false;
            this.groupBoxDepart.Text = "文/理";
            // 
            // textBoxScoreL
            // 
            this.textBoxScoreL.Location = new System.Drawing.Point(63, 23);
            this.textBoxScoreL.Name = "textBoxScoreL";
            this.textBoxScoreL.Size = new System.Drawing.Size(81, 24);
            this.textBoxScoreL.TabIndex = 21;
            // 
            // groupBoxScore
            // 
            this.groupBoxScore.Controls.Add(this.textBoxDif);
            this.groupBoxScore.Controls.Add(this.textBoxScoreR);
            this.groupBoxScore.Controls.Add(this.labelScore);
            this.groupBoxScore.Controls.Add(this.radioButtonDif);
            this.groupBoxScore.Controls.Add(this.radioButtonScore);
            this.groupBoxScore.Controls.Add(this.comboBoxBatch);
            this.groupBoxScore.Controls.Add(this.textBoxScoreL);
            this.groupBoxScore.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxScore.Location = new System.Drawing.Point(408, 26);
            this.groupBoxScore.Name = "groupBoxScore";
            this.groupBoxScore.Size = new System.Drawing.Size(255, 53);
            this.groupBoxScore.TabIndex = 18;
            this.groupBoxScore.TabStop = false;
            this.groupBoxScore.Text = "        分数—————范围";
            // 
            // textBoxDif
            // 
            this.textBoxDif.Location = new System.Drawing.Point(187, 23);
            this.textBoxDif.Name = "textBoxDif";
            this.textBoxDif.Size = new System.Drawing.Size(61, 24);
            this.textBoxDif.TabIndex = 22;
            this.textBoxDif.Visible = false;
            // 
            // textBoxScoreR
            // 
            this.textBoxScoreR.Location = new System.Drawing.Point(167, 23);
            this.textBoxScoreR.Name = "textBoxScoreR";
            this.textBoxScoreR.Size = new System.Drawing.Size(81, 24);
            this.textBoxScoreR.TabIndex = 22;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(148, 27);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(15, 15);
            this.labelScore.TabIndex = 16;
            this.labelScore.Text = "-";
            // 
            // radioButtonDif
            // 
            this.radioButtonDif.AutoSize = true;
            this.radioButtonDif.Location = new System.Drawing.Point(5, 31);
            this.radioButtonDif.Name = "radioButtonDif";
            this.radioButtonDif.Size = new System.Drawing.Size(55, 19);
            this.radioButtonDif.TabIndex = 20;
            this.radioButtonDif.Text = "线差";
            this.radioButtonDif.UseVisualStyleBackColor = true;
            this.radioButtonDif.Click += new System.EventHandler(this.radioButtonDif_Click);
            // 
            // radioButtonScore
            // 
            this.radioButtonScore.AutoSize = true;
            this.radioButtonScore.Checked = true;
            this.radioButtonScore.Location = new System.Drawing.Point(5, 12);
            this.radioButtonScore.Name = "radioButtonScore";
            this.radioButtonScore.Size = new System.Drawing.Size(55, 19);
            this.radioButtonScore.TabIndex = 19;
            this.radioButtonScore.TabStop = true;
            this.radioButtonScore.Text = "分数";
            this.radioButtonScore.UseVisualStyleBackColor = true;
            this.radioButtonScore.Click += new System.EventHandler(this.radioButtonScore_Click);
            // 
            // comboBoxBatch
            // 
            this.comboBoxBatch.DropDownHeight = 50;
            this.comboBoxBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBatch.DropDownWidth = 90;
            this.comboBoxBatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxBatch.FormattingEnabled = true;
            this.comboBoxBatch.IntegralHeight = false;
            this.comboBoxBatch.Location = new System.Drawing.Point(63, 25);
            this.comboBoxBatch.MaxDropDownItems = 10;
            this.comboBoxBatch.Name = "comboBoxBatch";
            this.comboBoxBatch.Size = new System.Drawing.Size(115, 20);
            this.comboBoxBatch.TabIndex = 21;
            this.comboBoxBatch.Visible = false;
            // 
            // groupBoxRank
            // 
            this.groupBoxRank.Controls.Add(this.textBoxRankR);
            this.groupBoxRank.Controls.Add(this.labelRank);
            this.groupBoxRank.Controls.Add(this.textBoxRankL);
            this.groupBoxRank.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxRank.Location = new System.Drawing.Point(669, 26);
            this.groupBoxRank.Name = "groupBoxRank";
            this.groupBoxRank.Size = new System.Drawing.Size(151, 53);
            this.groupBoxRank.TabIndex = 23;
            this.groupBoxRank.TabStop = false;
            this.groupBoxRank.Text = "段位————范围";
            // 
            // textBoxRankR
            // 
            this.textBoxRankR.Location = new System.Drawing.Point(88, 23);
            this.textBoxRankR.Name = "textBoxRankR";
            this.textBoxRankR.Size = new System.Drawing.Size(57, 24);
            this.textBoxRankR.TabIndex = 25;
            // 
            // labelRank
            // 
            this.labelRank.AutoSize = true;
            this.labelRank.Location = new System.Drawing.Point(68, 26);
            this.labelRank.Name = "labelRank";
            this.labelRank.Size = new System.Drawing.Size(15, 15);
            this.labelRank.TabIndex = 16;
            this.labelRank.Text = "-";
            // 
            // textBoxRankL
            // 
            this.textBoxRankL.Location = new System.Drawing.Point(6, 23);
            this.textBoxRankL.Name = "textBoxRankL";
            this.textBoxRankL.Size = new System.Drawing.Size(57, 24);
            this.textBoxRankL.TabIndex = 24;
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReset.Location = new System.Drawing.Point(826, 55);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(72, 23);
            this.buttonReset.TabIndex = 27;
            this.buttonReset.Text = "重置";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // menuStripFormMain
            // 
            this.menuStripFormMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripFormMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMainMenu,
            this.ToolStripMenuItemImportData,
            this.ToolStripMenuItemDelData});
            this.menuStripFormMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripFormMain.Name = "menuStripFormMain";
            this.menuStripFormMain.Size = new System.Drawing.Size(907, 25);
            this.menuStripFormMain.TabIndex = 24;
            this.menuStripFormMain.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMainMenu
            // 
            this.ToolStripMenuItemMainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemRefresh,
            this.toolStripSeparator1,
            this.ToolStripMenuItemQuit});
            this.ToolStripMenuItemMainMenu.Name = "ToolStripMenuItemMainMenu";
            this.ToolStripMenuItemMainMenu.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItemMainMenu.Text = "菜单";
            // 
            // ToolStripMenuItemRefresh
            // 
            this.ToolStripMenuItemRefresh.Name = "ToolStripMenuItemRefresh";
            this.ToolStripMenuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.ToolStripMenuItemRefresh.Size = new System.Drawing.Size(147, 22);
            this.ToolStripMenuItemRefresh.Text = "刷新";
            this.ToolStripMenuItemRefresh.Click += new System.EventHandler(this.ToolStripMenuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // ToolStripMenuItemQuit
            // 
            this.ToolStripMenuItemQuit.Name = "ToolStripMenuItemQuit";
            this.ToolStripMenuItemQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.ToolStripMenuItemQuit.Size = new System.Drawing.Size(147, 22);
            this.ToolStripMenuItemQuit.Text = "退出";
            this.ToolStripMenuItemQuit.Click += new System.EventHandler(this.ToolStripMenuItemQuit_Click);
            // 
            // ToolStripMenuItemImportData
            // 
            this.ToolStripMenuItemImportData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemImportSASinfo,
            this.ToolStripMenuItemImportLine,
            this.ToolStripMenuItemImportRegional});
            this.ToolStripMenuItemImportData.Name = "ToolStripMenuItemImportData";
            this.ToolStripMenuItemImportData.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItemImportData.Text = "数据导入";
            // 
            // ToolStripMenuItemImportSASinfo
            // 
            this.ToolStripMenuItemImportSASinfo.Name = "ToolStripMenuItemImportSASinfo";
            this.ToolStripMenuItemImportSASinfo.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemImportSASinfo.Text = "高校录取数据";
            this.ToolStripMenuItemImportSASinfo.Click += new System.EventHandler(this.ToolStripMenuItemImportSASinfo_Click);
            // 
            // ToolStripMenuItemImportLine
            // 
            this.ToolStripMenuItemImportLine.Name = "ToolStripMenuItemImportLine";
            this.ToolStripMenuItemImportLine.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemImportLine.Text = "吉林省批次线";
            this.ToolStripMenuItemImportLine.Click += new System.EventHandler(this.ToolStripMenuItemImportLine_Click);
            // 
            // ToolStripMenuItemImportRegional
            // 
            this.ToolStripMenuItemImportRegional.Name = "ToolStripMenuItemImportRegional";
            this.ToolStripMenuItemImportRegional.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemImportRegional.Text = "高校归属地";
            this.ToolStripMenuItemImportRegional.Click += new System.EventHandler(this.ToolStripMenuItemImportRegional_Click);
            // 
            // ToolStripMenuItemDelData
            // 
            this.ToolStripMenuItemDelData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDelSASinfo,
            this.ToolStripMenuItemDelLine,
            this.ToolStripMenuItemDelRegional});
            this.ToolStripMenuItemDelData.Name = "ToolStripMenuItemDelData";
            this.ToolStripMenuItemDelData.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItemDelData.Text = "数据删除";
            // 
            // ToolStripMenuItemDelSASinfo
            // 
            this.ToolStripMenuItemDelSASinfo.Name = "ToolStripMenuItemDelSASinfo";
            this.ToolStripMenuItemDelSASinfo.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemDelSASinfo.Text = "高校录取数据删除";
            this.ToolStripMenuItemDelSASinfo.Click += new System.EventHandler(this.ToolStripMenuItemDelSASinfo_Click);
            // 
            // ToolStripMenuItemDelLine
            // 
            this.ToolStripMenuItemDelLine.Name = "ToolStripMenuItemDelLine";
            this.ToolStripMenuItemDelLine.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemDelLine.Text = "吉林省批次线数据删除";
            this.ToolStripMenuItemDelLine.Click += new System.EventHandler(this.ToolStripMenuItemDelLine_Click);
            // 
            // ToolStripMenuItemDelRegional
            // 
            this.ToolStripMenuItemDelRegional.Name = "ToolStripMenuItemDelRegional";
            this.ToolStripMenuItemDelRegional.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemDelRegional.Text = "高校归属地数据删除";
            this.ToolStripMenuItemDelRegional.Click += new System.EventHandler(this.ToolStripMenuItemDelRegional_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 484);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.groupBoxRank);
            this.Controls.Add(this.groupBoxScore);
            this.Controls.Add(this.groupBoxDepart);
            this.Controls.Add(this.groupBoxRegional);
            this.Controls.Add(this.groupBoxYear);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.dataGridViewSQL);
            this.Controls.Add(this.menuStripFormMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripFormMain;
            this.Name = "FormMain";
            this.Text = " SASinfo";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSQL)).EndInit();
            this.groupBoxYear.ResumeLayout(false);
            this.groupBoxYear.PerformLayout();
            this.groupBoxRegional.ResumeLayout(false);
            this.groupBoxDepart.ResumeLayout(false);
            this.groupBoxDepart.PerformLayout();
            this.groupBoxScore.ResumeLayout(false);
            this.groupBoxScore.PerformLayout();
            this.groupBoxRank.ResumeLayout(false);
            this.groupBoxRank.PerformLayout();
            this.menuStripFormMain.ResumeLayout(false);
            this.menuStripFormMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewSQL;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.GroupBox groupBoxYear;
        private System.Windows.Forms.ComboBox comboBoxYearL;
        private System.Windows.Forms.ComboBox comboBoxYearR;
        private System.Windows.Forms.ComboBox comboBoxRegional;
        private System.Windows.Forms.GroupBox groupBoxRegional;
        private System.Windows.Forms.RadioButton radioButtonArt;
        private System.Windows.Forms.RadioButton radioButtonScience;
        private System.Windows.Forms.GroupBox groupBoxDepart;
        private System.Windows.Forms.TextBox textBoxScoreL;
        private System.Windows.Forms.GroupBox groupBoxScore;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.GroupBox groupBoxRank;
        private System.Windows.Forms.Label labelRank;
        private System.Windows.Forms.TextBox textBoxRankL;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.MenuStrip menuStripFormMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMainMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemImportData;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemImportLine;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemImportSASinfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemImportRegional;
        private System.Windows.Forms.ComboBox comboBoxBatch;
        private System.Windows.Forms.RadioButton radioButtonDif;
        private System.Windows.Forms.RadioButton radioButtonScore;
        private System.Windows.Forms.TextBox textBoxScoreR;
        private System.Windows.Forms.TextBox textBoxDif;
        private System.Windows.Forms.TextBox textBoxRankR;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelData;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelLine;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelSASinfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelRegional;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuit;
    }
}

