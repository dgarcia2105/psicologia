namespace MM.CAAM.Admin.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            richTextBox1 = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            richEditControl2 = new DevExpress.XtraRichEdit.RichEditControl();
            dataGridView1 = new DataGridView();
            richEditControl3 = new DevExpress.XtraRichEdit.RichEditControl();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // richEditControl1
            // 
            richEditControl1.Location = new Point(0, 0);
            richEditControl1.Name = "richEditControl1";
            richEditControl1.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            richEditControl1.TabIndex = 0;
            richEditControl1.Text = "algo";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(3, 2);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(103, 43);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(richTextBox1, 0, 0);
            tableLayoutPanel1.Location = new Point(172, 37);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(219, 94);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // richEditControl2
            // 
            richEditControl2.Location = new Point(0, 0);
            richEditControl2.Name = "richEditControl2";
            richEditControl2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 136);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 2;
            // 
            // richEditControl3
            // 
            richEditControl3.Location = new Point(0, 0);
            richEditControl3.Name = "richEditControl3";
            richEditControl3.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(dataGridView1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private RichTextBox richTextBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl2;
        private DataGridView dataGridView1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl3;
    }
}