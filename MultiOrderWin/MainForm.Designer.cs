﻿namespace MultiOrderWin
{
    partial class MainForm
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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.miCatalogs = new System.Windows.Forms.ToolStripMenuItem();
            this.miEquipment = new System.Windows.Forms.ToolStripMenuItem();
            this.miClassrooms = new System.Windows.Forms.ToolStripMenuItem();
            this.miSemesters = new System.Windows.Forms.ToolStripMenuItem();
            this.miUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.miReports = new System.Windows.Forms.ToolStripMenuItem();
            this.miOrderUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.miChartMulti = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miRef = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.gridEquipment = new System.Windows.Forms.DataGridView();
            this.EquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.msMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipment)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miCatalogs,
            this.miReports,
            this.miHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(1099, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClose});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(48, 20);
            this.miFile.Text = "Файл";
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(108, 22);
            this.miClose.Text = "Выход";
            this.miClose.Click += new System.EventHandler(this.miClose_Click);
            // 
            // miCatalogs
            // 
            this.miCatalogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEquipment,
            this.miClassrooms,
            this.miSemesters,
            this.miUsers});
            this.miCatalogs.Name = "miCatalogs";
            this.miCatalogs.Size = new System.Drawing.Size(94, 20);
            this.miCatalogs.Text = "Справочники";
            // 
            // miEquipment
            // 
            this.miEquipment.Name = "miEquipment";
            this.miEquipment.Size = new System.Drawing.Size(155, 22);
            this.miEquipment.Text = "Оборудование";
            this.miEquipment.Click += new System.EventHandler(this.miEquipment_Click);
            // 
            // miClassrooms
            // 
            this.miClassrooms.Name = "miClassrooms";
            this.miClassrooms.Size = new System.Drawing.Size(155, 22);
            this.miClassrooms.Text = "Аудитории";
            this.miClassrooms.Click += new System.EventHandler(this.miClassrooms_Click);
            // 
            // miSemesters
            // 
            this.miSemesters.Name = "miSemesters";
            this.miSemesters.Size = new System.Drawing.Size(155, 22);
            this.miSemesters.Text = "Семестры";
            this.miSemesters.Click += new System.EventHandler(this.miSemesters_Click);
            // 
            // miUsers
            // 
            this.miUsers.Name = "miUsers";
            this.miUsers.Size = new System.Drawing.Size(155, 22);
            this.miUsers.Text = "Пользователи";
            this.miUsers.Click += new System.EventHandler(this.miUsers_Click);
            // 
            // miReports
            // 
            this.miReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOrderUsers,
            this.miChartMulti});
            this.miReports.Name = "miReports";
            this.miReports.Size = new System.Drawing.Size(60, 20);
            this.miReports.Text = "Отчеты";
            // 
            // miOrderUsers
            // 
            this.miOrderUsers.Name = "miOrderUsers";
            this.miOrderUsers.Size = new System.Drawing.Size(366, 22);
            this.miOrderUsers.Text = "Количество заявок пользователей в разрезе месяцев";
            this.miOrderUsers.Click += new System.EventHandler(this.miOrderUsers_Click);
            // 
            // miChartMulti
            // 
            this.miChartMulti.Name = "miChartMulti";
            this.miChartMulti.Size = new System.Drawing.Size(366, 22);
            this.miChartMulti.Text = "График мультимедиа заявок";
            this.miChartMulti.Click += new System.EventHandler(this.miChartMulti_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRef,
            this.toolStripMenuItem2,
            this.miAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(68, 20);
            this.miHelp.Text = "Помощь";
            // 
            // miRef
            // 
            this.miRef.Name = "miRef";
            this.miRef.Size = new System.Drawing.Size(152, 22);
            this.miRef.Text = "Справка";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(152, 22);
            this.miAbout.Text = "О программе";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1099, 370);
            this.pnlMain.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1099, 312);
            this.panel2.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridOrders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridEquipment);
            this.splitContainer1.Size = new System.Drawing.Size(1099, 312);
            this.splitContainer1.SplitterDistance = 859;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridOrders
            // 
            this.gridOrders.AllowUserToAddRows = false;
            this.gridOrders.AllowUserToDeleteRows = false;
            this.gridOrders.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOrders.Location = new System.Drawing.Point(0, 0);
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.ReadOnly = true;
            this.gridOrders.Size = new System.Drawing.Size(859, 312);
            this.gridOrders.TabIndex = 0;
            this.gridOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridOrders_CellFormatting);
            this.gridOrders.SelectionChanged += new System.EventHandler(this.gridOrders_SelectionChanged);
            // 
            // gridEquipment
            // 
            this.gridEquipment.AllowUserToAddRows = false;
            this.gridEquipment.AllowUserToDeleteRows = false;
            this.gridEquipment.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EquipmentName,
            this.Amount});
            this.gridEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEquipment.Location = new System.Drawing.Point(0, 0);
            this.gridEquipment.Name = "gridEquipment";
            this.gridEquipment.ReadOnly = true;
            this.gridEquipment.Size = new System.Drawing.Size(236, 312);
            this.gridEquipment.TabIndex = 0;
            // 
            // EquipmentName
            // 
            this.EquipmentName.HeaderText = "Оборудование";
            this.EquipmentName.Name = "EquipmentName";
            this.EquipmentName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Количество";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnSign);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1099, 58);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "- Новые заявки";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(533, 18);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 19);
            this.panel4.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(707, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "- Утвержденные заявки";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGreen;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(681, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 19);
            this.panel3.TabIndex = 5;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(106, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 39);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "Просмотр";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(414, 8);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(100, 39);
            this.btnSign.TabIndex = 3;
            this.btnSign.Text = "Утвердить";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(320, 8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(88, 39);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(200, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 39);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 39);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 394);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.msMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заявки на мультимедиа оборудование";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipment)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem miCatalogs;
        private System.Windows.Forms.ToolStripMenuItem miEquipment;
        private System.Windows.Forms.ToolStripMenuItem miClassrooms;
        private System.Windows.Forms.ToolStripMenuItem miSemesters;
        private System.Windows.Forms.ToolStripMenuItem miUsers;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miRef;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridOrders;
        private System.Windows.Forms.DataGridView gridEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ToolStripMenuItem miReports;
        private System.Windows.Forms.ToolStripMenuItem miOrderUsers;
        private System.Windows.Forms.ToolStripMenuItem miChartMulti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}

