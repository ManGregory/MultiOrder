namespace MultiOrderWin
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
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miRef = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlData = new System.Windows.Forms.Panel();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miCatalogs,
            this.miHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(905, 24);
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
            this.miRef.Size = new System.Drawing.Size(149, 22);
            this.miRef.Text = "Справка";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 6);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(149, 22);
            this.miAbout.Text = "О программе";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlData);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(905, 370);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.gridOrders);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(905, 270);
            this.pnlData.TabIndex = 2;
            // 
            // gridOrders
            // 
            this.gridOrders.AllowUserToAddRows = false;
            this.gridOrders.AllowUserToDeleteRows = false;
            this.gridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOrders.Location = new System.Drawing.Point(0, 0);
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.ReadOnly = true;
            this.gridOrders.Size = new System.Drawing.Size(905, 270);
            this.gridOrders.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 270);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(905, 100);
            this.pnlBottom.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 394);
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
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).EndInit();
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
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.DataGridView gridOrders;
        private System.Windows.Forms.Panel pnlBottom;
    }
}

