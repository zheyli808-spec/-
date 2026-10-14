namespace Doog.WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblWeight = new System.Windows.Forms.Label();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.chkVaccinated = new System.Windows.Forms.CheckBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFindId = new System.Windows.Forms.Button();
            this.btnFindColor = new System.Windows.Forms.Button();
            this.btnVaccinated = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.dgvMice = new System.Windows.Forms.DataGridView();
            this.btnAverageWeight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(31, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(33, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Имя";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(34, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(127, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(34, 96);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(39, 16);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Цвет";
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(34, 115);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(127, 24);
            this.cmbColor.TabIndex = 3;
            this.cmbColor.Text = "DropDownStyle = DropDownList";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(183, 96);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(62, 16);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "Возраст";
            this.lblAge.Click += new System.EventHandler(this.lblAge_Click);
            // 
            // numAge
            // 
            this.numAge.Location = new System.Drawing.Point(186, 117);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(127, 22);
            this.numAge.TabIndex = 5;
            this.numAge.Tag = "Minimum = 0";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(34, 159);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(31, 16);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Вес";
            // 
            // numWeight
            // 
            this.numWeight.Location = new System.Drawing.Point(34, 178);
            this.numWeight.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(127, 22);
            this.numWeight.TabIndex = 7;
            this.numWeight.Tag = "DecimalPlaces = 2, Minimum = 0, Increment = 0.01";
            this.numWeight.ValueChanged += new System.EventHandler(this.numWeight_ValueChanged);
            // 
            // chkVaccinated
            // 
            this.chkVaccinated.AutoSize = true;
            this.chkVaccinated.Location = new System.Drawing.Point(186, 180);
            this.chkVaccinated.Name = "chkVaccinated";
            this.chkVaccinated.Size = new System.Drawing.Size(86, 20);
            this.chkVaccinated.TabIndex = 8;
            this.chkVaccinated.Text = "Привита";
            this.chkVaccinated.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(183, 27);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(65, 16);
            this.lblId.TabIndex = 9;
            this.lblId.Text = "ID мышки";
            this.lblId.Click += new System.EventHandler(this.lblId_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(186, 47);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(127, 22);
            this.txtId.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(37, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 28);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(37, 330);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 32);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(37, 384);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 29);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(37, 436);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 30);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnFindId
            // 
            this.btnFindId.Location = new System.Drawing.Point(152, 281);
            this.btnFindId.Name = "btnFindId";
            this.btnFindId.Size = new System.Drawing.Size(93, 43);
            this.btnFindId.TabIndex = 15;
            this.btnFindId.Text = "Найти по ID";
            this.btnFindId.UseVisualStyleBackColor = true;
            // 
            // btnFindColor
            // 
            this.btnFindColor.Location = new System.Drawing.Point(152, 344);
            this.btnFindColor.Name = "btnFindColor";
            this.btnFindColor.Size = new System.Drawing.Size(96, 48);
            this.btnFindColor.TabIndex = 16;
            this.btnFindColor.Text = "Поиск по цвету";
            this.btnFindColor.UseVisualStyleBackColor = true;
            // 
            // btnVaccinated
            // 
            this.btnVaccinated.Location = new System.Drawing.Point(37, 483);
            this.btnVaccinated.Name = "btnVaccinated";
            this.btnVaccinated.Size = new System.Drawing.Size(95, 42);
            this.btnVaccinated.TabIndex = 17;
            this.btnVaccinated.Text = "Привитые мышки";
            this.btnVaccinated.UseVisualStyleBackColor = true;
            this.btnVaccinated.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(152, 415);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(93, 44);
            this.btnShowAll.TabIndex = 18;
            this.btnShowAll.Text = "Показать всех";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click_1);
            // 
            // dgvMice
            // 
            this.dgvMice.AllowUserToAddRows = false;
            this.dgvMice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMice.Location = new System.Drawing.Point(360, 47);
            this.dgvMice.MultiSelect = false;
            this.dgvMice.Name = "dgvMice";
            this.dgvMice.ReadOnly = true;
            this.dgvMice.RowHeadersWidth = 51;
            this.dgvMice.RowTemplate.Height = 24;
            this.dgvMice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMice.Size = new System.Drawing.Size(672, 511);
            this.dgvMice.TabIndex = 19;
            this.dgvMice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMice_CellContentClick);
            // 
            // btnAverageWeight
            // 
            this.btnAverageWeight.Location = new System.Drawing.Point(152, 483);
            this.btnAverageWeight.Name = "btnAverageWeight";
            this.btnAverageWeight.Size = new System.Drawing.Size(93, 42);
            this.btnAverageWeight.TabIndex = 20;
            this.btnAverageWeight.Text = "Средний вес мышек";
            this.btnAverageWeight.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 603);
            this.Controls.Add(this.btnAverageWeight);
            this.Controls.Add(this.dgvMice);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnVaccinated);
            this.Controls.Add(this.btnFindColor);
            this.Controls.Add(this.btnFindId);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.chkVaccinated);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление мышками";
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.CheckBox chkVaccinated;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFindId;
        private System.Windows.Forms.Button btnFindColor;
        private System.Windows.Forms.Button btnVaccinated;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView dgvMice;
        private System.Windows.Forms.Button btnAverageWeight;
    }
}

