namespace Gotocommic
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Pasta_Arquivos = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnVolume = new System.Windows.Forms.Button();
            this.BtnChapter = new System.Windows.Forms.Button();
            this.BtnOrderFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BtnOrder = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // BtnVolume
            // 
            this.BtnVolume.BackColor = System.Drawing.SystemColors.WindowText;
            this.BtnVolume.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnVolume.FlatAppearance.BorderSize = 0;
            this.BtnVolume.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
            this.BtnVolume.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnVolume.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnVolume.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolume.ForeColor = System.Drawing.Color.LightYellow;
            this.BtnVolume.Location = new System.Drawing.Point(47, 88);
            this.BtnVolume.Name = "BtnVolume";
            this.BtnVolume.Size = new System.Drawing.Size(110, 46);
            this.BtnVolume.TabIndex = 8;
            this.BtnVolume.Text = "Volume";
            this.BtnVolume.UseVisualStyleBackColor = false;
            this.BtnVolume.Click += new System.EventHandler(this.BtnVolume_Click);
            this.BtnVolume.MouseEnter += new System.EventHandler(this.BtnVolume_MouseEnter);
            this.BtnVolume.MouseLeave += new System.EventHandler(this.BtnVolume_MouseLeave);
            this.BtnVolume.MouseHover += new System.EventHandler(this.BtnVolume_MouseHover);
            // 
            // BtnChapter
            // 
            this.BtnChapter.BackColor = System.Drawing.SystemColors.WindowText;
            this.BtnChapter.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnChapter.FlatAppearance.BorderSize = 0;
            this.BtnChapter.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
            this.BtnChapter.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnChapter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnChapter.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChapter.ForeColor = System.Drawing.Color.LightYellow;
            this.BtnChapter.Location = new System.Drawing.Point(47, 36);
            this.BtnChapter.Name = "BtnChapter";
            this.BtnChapter.Size = new System.Drawing.Size(110, 46);
            this.BtnChapter.TabIndex = 8;
            this.BtnChapter.Text = "Chapter";
            this.BtnChapter.UseVisualStyleBackColor = false;
            this.BtnChapter.Click += new System.EventHandler(this.BtnChapter_Click);
            this.BtnChapter.MouseEnter += new System.EventHandler(this.BtnChapter_MouseEnter);
            this.BtnChapter.MouseLeave += new System.EventHandler(this.BtnChapter_MouseLeave);
            this.BtnChapter.MouseHover += new System.EventHandler(this.BtnChapter_MouseHover);
            // 
            // BtnOrderFile
            // 
            this.BtnOrderFile.BackColor = System.Drawing.SystemColors.WindowText;
            this.BtnOrderFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnOrderFile.FlatAppearance.BorderSize = 0;
            this.BtnOrderFile.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
            this.BtnOrderFile.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnOrderFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOrderFile.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrderFile.ForeColor = System.Drawing.Color.LightYellow;
            this.BtnOrderFile.Location = new System.Drawing.Point(162, 88);
            this.BtnOrderFile.Name = "BtnOrderFile";
            this.BtnOrderFile.Size = new System.Drawing.Size(110, 46);
            this.BtnOrderFile.TabIndex = 8;
            this.BtnOrderFile.Text = "Order by file";
            this.BtnOrderFile.UseVisualStyleBackColor = false;
            this.BtnOrderFile.Click += new System.EventHandler(this.BtnOrderFile_Click);
            this.BtnOrderFile.MouseEnter += new System.EventHandler(this.BtnOrderFile_MouseEnter);
            this.BtnOrderFile.MouseLeave += new System.EventHandler(this.BtnOrderFile_MouseLeave);
            this.BtnOrderFile.MouseHover += new System.EventHandler(this.BtnOrderFile_MouseHover);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(47, 146);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(225, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // BtnOrder
            // 
            this.BtnOrder.BackColor = System.Drawing.SystemColors.WindowText;
            this.BtnOrder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnOrder.FlatAppearance.BorderSize = 0;
            this.BtnOrder.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
            this.BtnOrder.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOrder.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrder.ForeColor = System.Drawing.Color.LightYellow;
            this.BtnOrder.Location = new System.Drawing.Point(162, 36);
            this.BtnOrder.Name = "BtnOrder";
            this.BtnOrder.Size = new System.Drawing.Size(110, 46);
            this.BtnOrder.TabIndex = 8;
            this.BtnOrder.Text = "Order";
            this.BtnOrder.UseVisualStyleBackColor = false;
            this.BtnOrder.Click += new System.EventHandler(this.BtnOrder_Click);
            this.BtnOrder.MouseEnter += new System.EventHandler(this.BtnOrder_MouseEnter);
            this.BtnOrder.MouseLeave += new System.EventHandler(this.BtnOrder_MouseLeave);
            this.BtnOrder.MouseHover += new System.EventHandler(this.BtnOrder_MouseHover);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.Info;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::GoToCommic.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(323, 179);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnChapter);
            this.Controls.Add(this.BtnOrder);
            this.Controls.Add(this.BtnOrderFile);
            this.Controls.Add(this.BtnVolume);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoToCommic";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog Pasta_Arquivos;
        private System.Windows.Forms.Button BtnVolume;
        private System.Windows.Forms.Button BtnChapter;
        private System.Windows.Forms.Button BtnOrderFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnOrder;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

