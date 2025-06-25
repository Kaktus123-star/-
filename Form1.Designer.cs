namespace КУРСАЧ
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
            this.textBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGroupBy = new System.Windows.Forms.ComboBox();
            this.listViewPhotos = new System.Windows.Forms.ListView();
            this.Имяфайла = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Датасъемки = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Формат = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBoxGroupBy2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSourceFolder
            // 
            this.textBoxSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceFolder.Location = new System.Drawing.Point(15, 45);
            this.textBoxSourceFolder.Name = "textBoxSourceFolder";
            this.textBoxSourceFolder.ReadOnly = true;
            this.textBoxSourceFolder.Size = new System.Drawing.Size(563, 20);
            this.textBoxSourceFolder.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonBrowse.Location = new System.Drawing.Point(592, 45);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Старт";
            this.buttonBrowse.UseVisualStyleBackColor = false;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Группировать по:";
            // 
            // comboBoxGroupBy
            // 
            this.comboBoxGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroupBy.FormattingEnabled = true;
            this.comboBoxGroupBy.Location = new System.Drawing.Point(109, 76);
            this.comboBoxGroupBy.Name = "comboBoxGroupBy";
            this.comboBoxGroupBy.Size = new System.Drawing.Size(120, 21);
            this.comboBoxGroupBy.TabIndex = 3;
            // 
            // listViewPhotos
            // 
            this.listViewPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPhotos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.listViewPhotos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Имяфайла,
            this.Датасъемки,
            this.Формат});
            this.listViewPhotos.FullRowSelect = true;
            this.listViewPhotos.GridLines = true;
            this.listViewPhotos.HideSelection = false;
            this.listViewPhotos.Location = new System.Drawing.Point(12, 103);
            this.listViewPhotos.MultiSelect = false;
            this.listViewPhotos.Name = "listViewPhotos";
            this.listViewPhotos.Size = new System.Drawing.Size(504, 482);
            this.listViewPhotos.TabIndex = 6;
            this.listViewPhotos.UseCompatibleStateImageBehavior = false;
            this.listViewPhotos.View = System.Windows.Forms.View.Details;
            this.listViewPhotos.DoubleClick += new System.EventHandler(this.listViewPhotos_DoubleClick);
            this.listViewPhotos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewPhotos_MouseClick);
            // 
            // Имяфайла
            // 
            this.Имяфайла.Text = "Имя файла";
            this.Имяфайла.Width = 200;
            // 
            // Датасъемки
            // 
            this.Датасъемки.Text = "Дата съемки";
            this.Датасъемки.Width = 150;
            // 
            // Формат
            // 
            this.Формат.Text = "Формат";
            this.Формат.Width = 150;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(15, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(703, 23);
            this.progressBar.TabIndex = 7;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 615);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(757, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // comboBoxGroupBy2
            // 
            this.comboBoxGroupBy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroupBy2.FormattingEnabled = true;
            this.comboBoxGroupBy2.Location = new System.Drawing.Point(372, 76);
            this.comboBoxGroupBy2.Name = "comboBoxGroupBy2";
            this.comboBoxGroupBy2.Size = new System.Drawing.Size(120, 21);
            this.comboBoxGroupBy2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Группировать по:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(757, 637);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxGroupBy2);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listViewPhotos);
            this.Controls.Add(this.comboBoxGroupBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxSourceFolder);
            this.Name = "Form1";
            this.Text = "Классификатор фотографий по EXIF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSourceFolder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGroupBy;
        private System.Windows.Forms.ListView listViewPhotos;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ColumnHeader Имяфайла;
        private System.Windows.Forms.ColumnHeader Датасъемки;
        private System.Windows.Forms.ColumnHeader Формат;
        private System.Windows.Forms.ComboBox comboBoxGroupBy2;
        private System.Windows.Forms.Label label2;
    }
}

