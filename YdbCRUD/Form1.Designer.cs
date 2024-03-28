namespace OnlineStore
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
            tabControl1 = new TabControl();
            ExpencePage = new TabPage();
            customerInsertButton = new Button();
            customerUpdateButton = new Button();
            label3 = new Label();
            customerDeleteButton = new Button();
            label2 = new Label();
            ExpenceNameTextBox = new TextBox();
            ExpenceSumTextBox = new TextBox();
            DepartmentPage = new TabPage();
            label4 = new Label();
            ReportPage = new TabPage();
            button1 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panel1 = new Panel();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            tabControl1.SuspendLayout();
            ExpencePage.SuspendLayout();
            DepartmentPage.SuspendLayout();
            ReportPage.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(ExpencePage);
            tabControl1.Controls.Add(DepartmentPage);
            tabControl1.Controls.Add(ReportPage);
            tabControl1.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.ItemSize = new Size(150, 25);
            tabControl1.Location = new Point(33, 121);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(795, 253);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 12;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // ExpencePage
            // 
            ExpencePage.BackColor = Color.Snow;
            ExpencePage.Controls.Add(customerInsertButton);
            ExpencePage.Controls.Add(customerUpdateButton);
            ExpencePage.Controls.Add(label3);
            ExpencePage.Controls.Add(customerDeleteButton);
            ExpencePage.Controls.Add(label2);
            ExpencePage.Controls.Add(ExpenceNameTextBox);
            ExpencePage.Controls.Add(ExpenceSumTextBox);
            ExpencePage.Location = new Point(4, 29);
            ExpencePage.Name = "ExpencePage";
            ExpencePage.Padding = new Padding(3);
            ExpencePage.Size = new Size(787, 220);
            ExpencePage.TabIndex = 0;
            ExpencePage.Text = "Статьи расходов";
            // 
            // customerInsertButton
            // 
            customerInsertButton.BackColor = Color.FromArgb(0, 192, 0);
            customerInsertButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            customerInsertButton.Location = new Point(245, 172);
            customerInsertButton.Name = "customerInsertButton";
            customerInsertButton.Size = new Size(111, 34);
            customerInsertButton.TabIndex = 2;
            customerInsertButton.Text = "Добавить";
            customerInsertButton.UseVisualStyleBackColor = false;
            customerInsertButton.Click += ExpenceInsertButton_Click;
            // 
            // customerUpdateButton
            // 
            customerUpdateButton.BackColor = Color.Yellow;
            customerUpdateButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            customerUpdateButton.Location = new Point(361, 172);
            customerUpdateButton.Name = "customerUpdateButton";
            customerUpdateButton.Size = new Size(111, 34);
            customerUpdateButton.TabIndex = 3;
            customerUpdateButton.Text = "Изменить ()";
            customerUpdateButton.UseVisualStyleBackColor = false;
            customerUpdateButton.Click += ExpenceUpdateButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(25, 74);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 10;
            label3.Text = "Выделить:";
            // 
            // customerDeleteButton
            // 
            customerDeleteButton.BackColor = Color.Red;
            customerDeleteButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            customerDeleteButton.Location = new Point(478, 172);
            customerDeleteButton.Name = "customerDeleteButton";
            customerDeleteButton.Size = new Size(111, 34);
            customerDeleteButton.TabIndex = 4;
            customerDeleteButton.Text = "Удалить ()";
            customerDeleteButton.UseVisualStyleBackColor = false;
            customerDeleteButton.Click += deleteButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(25, 31);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 9;
            label2.Text = "Статья расходов:";
            // 
            // ExpenceNameTextBox
            // 
            ExpenceNameTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ExpenceNameTextBox.Location = new Point(140, 28);
            ExpenceNameTextBox.Name = "ExpenceNameTextBox";
            ExpenceNameTextBox.Size = new Size(96, 23);
            ExpenceNameTextBox.TabIndex = 6;
            // 
            // ExpenceSumTextBox
            // 
            ExpenceSumTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ExpenceSumTextBox.Location = new Point(140, 70);
            ExpenceSumTextBox.Name = "ExpenceSumTextBox";
            ExpenceSumTextBox.Size = new Size(96, 23);
            ExpenceSumTextBox.TabIndex = 7;
            // 
            // DepartmentPage
            // 
            DepartmentPage.BackColor = Color.Snow;
            DepartmentPage.Controls.Add(label4);
            DepartmentPage.Location = new Point(4, 29);
            DepartmentPage.Name = "DepartmentPage";
            DepartmentPage.Padding = new Padding(3);
            DepartmentPage.Size = new Size(787, 220);
            DepartmentPage.TabIndex = 1;
            DepartmentPage.Text = "Отделы";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 36);
            label4.Name = "label4";
            label4.Size = new Size(768, 20);
            label4.TabIndex = 0;
            label4.Text = "Таблица Department отображает список отделов с указанием расходов по каждой статье расходов";
            // 
            // ReportPage
            // 
            ReportPage.BackColor = Color.Snow;
            ReportPage.Controls.Add(button1);
            ReportPage.Location = new Point(4, 29);
            ReportPage.Name = "ReportPage";
            ReportPage.Size = new Size(787, 220);
            ReportPage.TabIndex = 2;
            ReportPage.Text = "Отчеты";
            // 
            // button1
            // 
            button1.BackColor = Color.PeachPuff;
            button1.Location = new Point(249, 76);
            button1.Name = "button1";
            button1.Size = new Size(290, 67);
            button1.TabIndex = 0;
            button1.Text = "Сформировать\r\nОтчет по \r\nОтделам";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ReportDapartment_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 676);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(859, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ForeColor = SystemColors.Highlight;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(104, 17);
            toolStripStatusLabel1.Text = "Number of row(s):";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(859, 94);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(224, 224, 224);
            label1.Font = new Font("Lucida Fax", 22.2F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(10, 14);
            label1.Name = "label1";
            label1.Size = new Size(171, 35);
            label1.TabIndex = 0;
            label1.Text = "Предприятие";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 393);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(792, 209);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(859, 698);
            Controls.Add(tabControl1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            Text = "Предприятие";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ExpencePage.ResumeLayout(false);
            ExpencePage.PerformLayout();
            DepartmentPage.ResumeLayout(false);
            DepartmentPage.PerformLayout();
            ReportPage.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button customerInsertButton;
        private System.Windows.Forms.Button customerUpdateButton;
        private System.Windows.Forms.Button customerDeleteButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox ExpenceNameTextBox;
        private System.Windows.Forms.TextBox ExpenceSumTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ExpencePage;
        private System.Windows.Forms.TabPage DepartmentPage;
        private System.Windows.Forms.TabPage ReportPage;
        private Button button1;
        private Label label4;
    }
}

