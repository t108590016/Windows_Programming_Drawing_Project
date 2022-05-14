
namespace DrawingForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._rectangle = new System.Windows.Forms.Button();
            this._ellipse = new System.Windows.Forms.Button();
            this._clear = new System.Windows.Forms.Button();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._line = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._load = new System.Windows.Forms.Button();
            this._selectedDetail = new System.Windows.Forms.Label();
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rectangle
            // 
            this._rectangle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._rectangle.AutoSize = true;
            this._rectangle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._rectangle.Location = new System.Drawing.Point(81, 5);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(61, 22);
            this._rectangle.TabIndex = 0;
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            // 
            // _ellipse
            // 
            this._ellipse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._ellipse.AutoSize = true;
            this._ellipse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._ellipse.Location = new System.Drawing.Point(537, 5);
            this._ellipse.Name = "_ellipse";
            this._ellipse.Size = new System.Drawing.Size(46, 22);
            this._ellipse.TabIndex = 1;
            this._ellipse.Text = "Ellipse";
            this._ellipse.UseVisualStyleBackColor = true;
            // 
            // _clear
            // 
            this._clear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._clear.AutoSize = true;
            this._clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._clear.Location = new System.Drawing.Point(764, 5);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(40, 22);
            this._clear.TabIndex = 2;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 6;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.675F));
            this._tableLayoutPanel.Controls.Add(this._clear, 3, 0);
            this._tableLayoutPanel.Controls.Add(this._ellipse, 2, 0);
            this._tableLayoutPanel.Controls.Add(this._rectangle, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._line, 1, 0);
            this._tableLayoutPanel.Controls.Add(this._saveButton, 4, 0);
            this._tableLayoutPanel.Controls.Add(this._load, 5, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 1;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(1350, 33);
            this._tableLayoutPanel.TabIndex = 3;
            // 
            // _line
            // 
            this._line.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._line.Location = new System.Drawing.Point(298, 5);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(75, 23);
            this._line.TabIndex = 3;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _saveButton
            // 
            this._saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._saveButton.Location = new System.Drawing.Point(970, 5);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 4;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.ClickSaveButtonAsync);
            // 
            // _load
            // 
            this._load.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._load.Location = new System.Drawing.Point(1197, 5);
            this._load.Name = "_load";
            this._load.Size = new System.Drawing.Size(75, 23);
            this._load.TabIndex = 5;
            this._load.Text = "Load";
            this._load.UseVisualStyleBackColor = true;
            this._load.Click += new System.EventHandler(this.ClickLoadButton);
            // 
            // _selectedDetail
            // 
            this._selectedDetail.AutoSize = true;
            this._selectedDetail.Location = new System.Drawing.Point(1128, 675);
            this._selectedDetail.Name = "_selectedDetail";
            this._selectedDetail.Size = new System.Drawing.Size(0, 12);
            this._selectedDetail.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this._selectedDetail);
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _rectangle;
        private System.Windows.Forms.Button _ellipse;
        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Label _selectedDetail;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _load;
    }
}

