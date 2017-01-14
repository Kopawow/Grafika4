namespace zad4
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pasekStanu1 = new zad4.PasekStanu();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.persp1 = new zad4.Persp();
            this.ortX1 = new zad4.OrtX();
            this.ortY1 = new zad4.OrtY();
            this.ortZ1 = new zad4.OrtZ();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pasekStanu1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 605);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 100);
            this.panel1.TabIndex = 0;
            // 
            // pasekStanu1
            // 
            this.pasekStanu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pasekStanu1.Location = new System.Drawing.Point(0, 0);
            this.pasekStanu1.Name = "pasekStanu1";
            this.pasekStanu1.Size = new System.Drawing.Size(1122, 100);
            this.pasekStanu1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ortX1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ortZ1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ortY1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.persp1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1122, 605);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // persp1
            // 
            this.persp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.persp1.Location = new System.Drawing.Point(227, 3);
            this.persp1.Name = "persp1";
            this.persp1.Size = new System.Drawing.Size(330, 296);
            this.persp1.TabIndex = 0;
            // 
            // ortX1
            // 
            this.ortX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ortX1.Location = new System.Drawing.Point(563, 3);
            this.ortX1.Name = "ortX1";
            this.ortX1.Size = new System.Drawing.Size(330, 296);
            this.ortX1.TabIndex = 1;
            // 
            // ortY1
            // 
            this.ortY1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ortY1.Location = new System.Drawing.Point(227, 305);
            this.ortY1.Name = "ortY1";
            this.ortY1.Size = new System.Drawing.Size(330, 297);
            this.ortY1.TabIndex = 2;
            // 
            // ortZ1
            // 
            this.ortZ1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ortZ1.Location = new System.Drawing.Point(563, 305);
            this.ortZ1.Name = "ortZ1";
            this.ortZ1.Size = new System.Drawing.Size(330, 297);
            this.ortZ1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 705);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private PasekStanu pasekStanu1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Persp persp1;
        private OrtX ortX1;
        private OrtY ortY1;
        private OrtZ ortZ1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

