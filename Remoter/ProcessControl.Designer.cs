/*
 * Created by SharpDevelop.
 * User: joreg
 * Date: 29.08.2009
 * Time: 21:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace VVVV.Nodes
{
    partial class ProcessControl
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ArgumentsEdit = new System.Windows.Forms.TextBox();
            this.ProcessEdit = new System.Windows.Forms.TextBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ArgumentsEdit, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProcessEdit, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RemoveButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 25);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ArgumentsEdit
            // 
            this.ArgumentsEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArgumentsEdit.Location = new System.Drawing.Point(220, 3);
            this.ArgumentsEdit.Name = "ArgumentsEdit";
            this.ArgumentsEdit.Size = new System.Drawing.Size(186, 20);
            this.ArgumentsEdit.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ArgumentsEdit, "When using arguments starting with -- they need to be escaped using double quotes" +
        ", like:\r\n --package-repositories c:\\vl-libs\r\nneeds to be specified as:\r\n \"--pack" +
        "age-repositories\" c:\\vl-libs");
            this.ArgumentsEdit.TextChanged += new System.EventHandler(this.ArgumentsEditTextChanged);
            this.ArgumentsEdit.MouseEnter += new System.EventHandler(this.ArgumentsEdit_MouseEnter);
            // 
            // ProcessEdit
            // 
            this.ProcessEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessEdit.Location = new System.Drawing.Point(28, 3);
            this.ProcessEdit.Name = "ProcessEdit";
            this.ProcessEdit.Size = new System.Drawing.Size(186, 20);
            this.ProcessEdit.TabIndex = 4;
            this.ProcessEdit.TextChanged += new System.EventHandler(this.ProcessEditTextChanged);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.RemoveButton.Location = new System.Drawing.Point(3, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(19, 19);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "X";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 96;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // ProcessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProcessControl";
            this.Size = new System.Drawing.Size(409, 25);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox ArgumentsEdit;
        private System.Windows.Forms.TextBox ProcessEdit;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
