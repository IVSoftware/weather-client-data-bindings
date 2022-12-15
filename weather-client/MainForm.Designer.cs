namespace weather_client
{
    partial class MainForm
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
        this.richTextBox = new System.Windows.Forms.RichTextBox();
        this.checkBoxRun = new System.Windows.Forms.CheckBox();
        this.progressBarTemperature = new weather_client.VerticalProgressBar();
        this.SuspendLayout();
        // 
        // richTextBox
        // 
        this.richTextBox.Location = new System.Drawing.Point(61, 12);
        this.richTextBox.Name = "richTextBox";
        this.richTextBox.ReadOnly = true;
        this.richTextBox.ShowSelectionMargin = true;
        this.richTextBox.Size = new System.Drawing.Size(91, 37);
        this.richTextBox.TabIndex = 0;
        this.richTextBox.TabStop = false;
        this.richTextBox.Text = "";
        // 
        // checkBoxRun
        // 
        this.checkBoxRun.Appearance = System.Windows.Forms.Appearance.Button;
        this.checkBoxRun.Location = new System.Drawing.Point(167, 88);
        this.checkBoxRun.Name = "checkBoxRun";
        this.checkBoxRun.Size = new System.Drawing.Size(182, 44);
        this.checkBoxRun.TabIndex = 1;
        this.checkBoxRun.Text = "Continuous Temp";
        this.checkBoxRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.checkBoxRun.UseVisualStyleBackColor = true;
        // 
        // progressBarTemperature
        // 
        this.progressBarTemperature.Location = new System.Drawing.Point(35, 12);
        this.progressBarTemperature.Name = "progressBarTemperature";
        this.progressBarTemperature.Size = new System.Drawing.Size(20, 113);
        this.progressBarTemperature.TabIndex = 2;
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(385, 144);
        this.Controls.Add(this.progressBarTemperature);
        this.Controls.Add(this.checkBoxRun);
        this.Controls.Add(this.richTextBox);
        this.Name = "MainForm";
        this.Text = "Main Form";
        this.ResumeLayout(false);

    }

        #endregion

        private RichTextBox richTextBox;
        private CheckBox checkBoxRun;
        private VerticalProgressBar progressBarTemperature;
    }
}