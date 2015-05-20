namespace MultiOrderWin
{
    partial class EquipmentForm
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridEquipment = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.numPair = new System.Windows.Forms.NumericUpDown();
            this.edDate = new System.Windows.Forms.DateTimePicker();
            this.pnlControls.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipment)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPair)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnRemove);
            this.pnlControls.Controls.Add(this.btnEdit);
            this.pnlControls.Controls.Add(this.btnAdd);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(350, 47);
            this.pnlControls.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(220, 9);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(84, 29);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(108, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 29);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 29);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 44);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(134, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridEquipment
            // 
            this.gridEquipment.AllowUserToAddRows = false;
            this.gridEquipment.AllowUserToDeleteRows = false;
            this.gridEquipment.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEquipment.Location = new System.Drawing.Point(0, 47);
            this.gridEquipment.Name = "gridEquipment";
            this.gridEquipment.ReadOnly = true;
            this.gridEquipment.Size = new System.Drawing.Size(350, 223);
            this.gridEquipment.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.edDate);
            this.panel4.Controls.Add(this.numPair);
            this.panel4.Controls.Add(this.chkAvailable);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 270);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(350, 30);
            this.panel4.TabIndex = 1;
            // 
            // chkAvailable
            // 
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.Location = new System.Drawing.Point(12, 6);
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.Size = new System.Drawing.Size(97, 18);
            this.chkAvailable.TabIndex = 0;
            this.chkAvailable.Text = "Доступно на";
            this.chkAvailable.UseVisualStyleBackColor = true;
            this.chkAvailable.CheckedChanged += new System.EventHandler(this.chkAvailable_CheckedChanged);
            // 
            // numPair
            // 
            this.numPair.Location = new System.Drawing.Point(108, 4);
            this.numPair.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPair.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPair.Name = "numPair";
            this.numPair.Size = new System.Drawing.Size(62, 22);
            this.numPair.TabIndex = 1;
            this.numPair.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPair.ValueChanged += new System.EventHandler(this.numPair_ValueChanged);
            // 
            // edDate
            // 
            this.edDate.Location = new System.Drawing.Point(177, 4);
            this.edDate.Name = "edDate";
            this.edDate.Size = new System.Drawing.Size(165, 22);
            this.edDate.TabIndex = 2;
            this.edDate.ValueChanged += new System.EventHandler(this.numPair_ValueChanged);
            // 
            // EquipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 344);
            this.Controls.Add(this.gridEquipment);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlControls);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EquipmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оборудование";
            this.pnlControls.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipment)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPair)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridEquipment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.DateTimePicker edDate;
        private System.Windows.Forms.NumericUpDown numPair;
        private System.Windows.Forms.Panel pnlControls;
    }
}