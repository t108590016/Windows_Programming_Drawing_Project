
namespace DrawingForm
{
    partial class CheckSaveForm
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
            this._label = new System.Windows.Forms.Label();
            this._button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.AutoSize = true;
            this._label.Location = new System.Drawing.Point(53, 67);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(137, 12);
            this._label.TabIndex = 0;
            this._label.Text = "確定要儲存現在的圖形？";
            // 
            // _button
            // 
            this._button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._button.Location = new System.Drawing.Point(81, 118);
            this._button.Name = "_button";
            this._button.Size = new System.Drawing.Size(75, 23);
            this._button.TabIndex = 1;
            this._button.Text = "OK";
            this._button.UseVisualStyleBackColor = true;
            // 
            // CheckSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 192);
            this.Controls.Add(this._button);
            this.Controls.Add(this._label);
            this.Name = "CheckSaveForm";
            this.Text = "CheckSaveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label;
        private System.Windows.Forms.Button _button;
    }
}