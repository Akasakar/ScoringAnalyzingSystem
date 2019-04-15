namespace ScoringAnalyzingSystem
{
    partial class FormChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChart));
            this.myChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStripChartImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemMajor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMajorAndImage = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorImageAndQuit = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).BeginInit();
            this.contextMenuStripChartImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // myChart
            // 
            this.myChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            chartArea1.Name = "ChartAreaMajor";
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea2.Name = "ChartAreaRank";
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            chartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            chartArea3.Name = "ChartAreaDif";
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea4.Name = "ChartAreaSum";
            this.myChart.ChartAreas.Add(chartArea1);
            this.myChart.ChartAreas.Add(chartArea2);
            this.myChart.ChartAreas.Add(chartArea3);
            this.myChart.ChartAreas.Add(chartArea4);
            this.myChart.ContextMenuStrip = this.contextMenuStripChartImage;
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.DockedToChartArea = "ChartAreaMajor";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.MaximumAutoSize = 30F;
            legend1.Name = "LegendMajor";
            legend1.Title = "专业线";
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.DockedToChartArea = "ChartAreaRank";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.IsDockedInsideChartArea = false;
            legend2.MaximumAutoSize = 30F;
            legend2.Name = "LegendRank";
            legend2.Title = "段位";
            legend3.Alignment = System.Drawing.StringAlignment.Far;
            legend3.DockedToChartArea = "ChartAreaDif";
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.IsDockedInsideChartArea = false;
            legend3.MaximumAutoSize = 30F;
            legend3.Name = "LegendDif";
            legend3.Title = "专业线差";
            legend4.Alignment = System.Drawing.StringAlignment.Far;
            legend4.DockedToChartArea = "ChartAreaSum";
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend4.IsDockedInsideChartArea = false;
            legend4.MaximumAutoSize = 30F;
            legend4.Name = "LegendSum";
            legend4.Title = "招生人数";
            this.myChart.Legends.Add(legend1);
            this.myChart.Legends.Add(legend2);
            this.myChart.Legends.Add(legend3);
            this.myChart.Legends.Add(legend4);
            this.myChart.Location = new System.Drawing.Point(12, 12);
            this.myChart.Name = "myChart";
            this.myChart.Size = new System.Drawing.Size(776, 426);
            this.myChart.TabIndex = 0;
            this.myChart.Text = "myChart";
            // 
            // contextMenuStripChartImage
            // 
            this.contextMenuStripChartImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMajor,
            this.toolStripSeparatorMajorAndImage,
            this.toolStripMenuItemCopyImage,
            this.toolStripMenuItemExportImage,
            this.toolStripSeparatorImageAndQuit,
            this.toolStripMenuItemQuit});
            this.contextMenuStripChartImage.Name = "contextMenuStripChartImage";
            this.contextMenuStripChartImage.Size = new System.Drawing.Size(170, 104);
            this.contextMenuStripChartImage.Text = "图表菜单";
            // 
            // toolStripMenuItemMajor
            // 
            this.toolStripMenuItemMajor.Name = "toolStripMenuItemMajor";
            this.toolStripMenuItemMajor.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItemMajor.Text = "专业分类";
            // 
            // toolStripSeparatorMajorAndImage
            // 
            this.toolStripSeparatorMajorAndImage.Name = "toolStripSeparatorMajorAndImage";
            this.toolStripSeparatorMajorAndImage.Size = new System.Drawing.Size(166, 6);
            // 
            // toolStripMenuItemCopyImage
            // 
            this.toolStripMenuItemCopyImage.Name = "toolStripMenuItemCopyImage";
            this.toolStripMenuItemCopyImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemCopyImage.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItemCopyImage.Text = "复制图片";
            this.toolStripMenuItemCopyImage.Click += new System.EventHandler(this.toolStripMenuItemCopyImage_Click);
            // 
            // toolStripMenuItemExportImage
            // 
            this.toolStripMenuItemExportImage.Name = "toolStripMenuItemExportImage";
            this.toolStripMenuItemExportImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.toolStripMenuItemExportImage.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItemExportImage.Text = "导出图片";
            this.toolStripMenuItemExportImage.Click += new System.EventHandler(this.toolStripMenuItemExportImage_Click);
            // 
            // toolStripSeparatorImageAndQuit
            // 
            this.toolStripSeparatorImageAndQuit.Name = "toolStripSeparatorImageAndQuit";
            this.toolStripSeparatorImageAndQuit.Size = new System.Drawing.Size(166, 6);
            // 
            // toolStripMenuItemQuit
            // 
            this.toolStripMenuItemQuit.Name = "toolStripMenuItemQuit";
            this.toolStripMenuItemQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.toolStripMenuItemQuit.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItemQuit.Text = "退出";
            this.toolStripMenuItemQuit.Click += new System.EventHandler(this.toolStripMenuItemQuit_Click);
            // 
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChart";
            this.Text = "FormChart";
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).EndInit();
            this.contextMenuStripChartImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart myChart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChartImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorImageAndQuit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMajor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMajorAndImage;
    }
}