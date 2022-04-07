namespace ONLINEFLOW.UI
{

    partial class PluginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
            this.pnOnlineFlow = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnectToTwitch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTwtchChannel = new System.Windows.Forms.TextBox();
            this.pnTimeFlow = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbOnlineFlow = new System.Windows.Forms.TextBox();
            this.pnOptions = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTotalControl = new System.Windows.Forms.RadioButton();
            this.rbEngineControl = new System.Windows.Forms.RadioButton();
            this.rbBlastControl = new System.Windows.Forms.RadioButton();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnOnlineFlow.SuspendLayout();
            this.pnTimeFlow.SuspendLayout();
            this.pnOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnOnlineFlow
            // 
            this.pnOnlineFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnOnlineFlow.Controls.Add(this.label1);
            this.pnOnlineFlow.Controls.Add(this.label3);
            this.pnOnlineFlow.Controls.Add(this.btnConnectToTwitch);
            this.pnOnlineFlow.Controls.Add(this.label4);
            this.pnOnlineFlow.Controls.Add(this.tbTwtchChannel);
            this.pnOnlineFlow.Location = new System.Drawing.Point(0, 0);
            this.pnOnlineFlow.Name = "pnOnlineFlow";
            this.pnOnlineFlow.Size = new System.Drawing.Size(150, 118);
            this.pnOnlineFlow.TabIndex = 0;
            this.pnOnlineFlow.Tag = "color:dark2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = " Online Flow";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = global::ONLINEFLOW.Properties.Resources.db_icon_16;
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnectToTwitch
            // 
            this.btnConnectToTwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnConnectToTwitch.FlatAppearance.BorderSize = 0;
            this.btnConnectToTwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectToTwitch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConnectToTwitch.ForeColor = System.Drawing.Color.White;
            this.btnConnectToTwitch.Location = new System.Drawing.Point(52, 82);
            this.btnConnectToTwitch.Name = "btnConnectToTwitch";
            this.btnConnectToTwitch.Size = new System.Drawing.Size(88, 27);
            this.btnConnectToTwitch.TabIndex = 13;
            this.btnConnectToTwitch.Tag = "color:dark3";
            this.btnConnectToTwitch.Text = "Connect";
            this.btnConnectToTwitch.UseVisualStyleBackColor = false;
            this.btnConnectToTwitch.Click += new System.EventHandler(this.btnConnectToTwitch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Twitch Channel";
            // 
            // tbTwtchChannel
            // 
            this.tbTwtchChannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbTwtchChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTwtchChannel.ForeColor = System.Drawing.Color.White;
            this.tbTwtchChannel.Location = new System.Drawing.Point(8, 56);
            this.tbTwtchChannel.Name = "tbTwtchChannel";
            this.tbTwtchChannel.Size = new System.Drawing.Size(132, 20);
            this.tbTwtchChannel.TabIndex = 11;
            this.tbTwtchChannel.Tag = "color:dark3";
            // 
            // pnTimeFlow
            // 
            this.pnTimeFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnTimeFlow.Controls.Add(this.btnOptions);
            this.pnTimeFlow.Controls.Add(this.btnStop);
            this.pnTimeFlow.Controls.Add(this.tbOnlineFlow);
            this.pnTimeFlow.Location = new System.Drawing.Point(0, 252);
            this.pnTimeFlow.Name = "pnTimeFlow";
            this.pnTimeFlow.Size = new System.Drawing.Size(150, 118);
            this.pnTimeFlow.TabIndex = 18;
            this.pnTimeFlow.Tag = "color:dark2";
            this.pnTimeFlow.Visible = false;
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Font = new System.Drawing.Font("Candara", 8.25F);
            this.btnOptions.ForeColor = System.Drawing.Color.White;
            this.btnOptions.Location = new System.Drawing.Point(3, 2);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(0);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(76, 24);
            this.btnOptions.TabIndex = 20;
            this.btnOptions.Tag = "color:dark3";
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Candara", 8.25F);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(77, 2);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(70, 24);
            this.btnStop.TabIndex = 21;
            this.btnStop.Tag = "color:dark3";
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbOnlineFlow
            // 
            this.tbOnlineFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbOnlineFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOnlineFlow.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOnlineFlow.ForeColor = System.Drawing.Color.White;
            this.tbOnlineFlow.Location = new System.Drawing.Point(3, 27);
            this.tbOnlineFlow.Multiline = true;
            this.tbOnlineFlow.Name = "tbOnlineFlow";
            this.tbOnlineFlow.Size = new System.Drawing.Size(144, 90);
            this.tbOnlineFlow.TabIndex = 20;
            this.tbOnlineFlow.Tag = "color:dark3";
            // 
            // pnOptions
            // 
            this.pnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnOptions.Controls.Add(this.btnHelp);
            this.pnOptions.Controls.Add(this.groupBox1);
            this.pnOptions.Controls.Add(this.btnBack);
            this.pnOptions.Location = new System.Drawing.Point(0, 126);
            this.pnOptions.Name = "pnOptions";
            this.pnOptions.Size = new System.Drawing.Size(150, 118);
            this.pnOptions.TabIndex = 20;
            this.pnOptions.Tag = "color:dark2";
            this.pnOptions.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Candara", 8.25F);
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(124, 2);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(0);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 24);
            this.btnHelp.TabIndex = 23;
            this.btnHelp.Tag = "color:dark3";
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTotalControl);
            this.groupBox1.Controls.Add(this.rbEngineControl);
            this.groupBox1.Controls.Add(this.rbBlastControl);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 86);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Level";
            // 
            // rbTotalControl
            // 
            this.rbTotalControl.AutoSize = true;
            this.rbTotalControl.Location = new System.Drawing.Point(6, 59);
            this.rbTotalControl.Name = "rbTotalControl";
            this.rbTotalControl.Size = new System.Drawing.Size(106, 17);
            this.rbTotalControl.TabIndex = 2;
            this.rbTotalControl.Text = "L3 : Total Control";
            this.rbTotalControl.UseVisualStyleBackColor = true;
            // 
            // rbEngineControl
            // 
            this.rbEngineControl.AutoSize = true;
            this.rbEngineControl.Location = new System.Drawing.Point(6, 39);
            this.rbEngineControl.Name = "rbEngineControl";
            this.rbEngineControl.Size = new System.Drawing.Size(115, 17);
            this.rbEngineControl.TabIndex = 1;
            this.rbEngineControl.Text = "L2 : Engine Control";
            this.rbEngineControl.UseVisualStyleBackColor = true;
            // 
            // rbBlastControl
            // 
            this.rbBlastControl.AutoSize = true;
            this.rbBlastControl.Checked = true;
            this.rbBlastControl.Location = new System.Drawing.Point(6, 19);
            this.rbBlastControl.Name = "rbBlastControl";
            this.rbBlastControl.Size = new System.Drawing.Size(93, 17);
            this.rbBlastControl.TabIndex = 0;
            this.rbBlastControl.TabStop = true;
            this.rbBlastControl.Text = "L1 : Blast Only";
            this.rbBlastControl.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Candara", 8.25F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(3, 2);
            this.btnBack.Margin = new System.Windows.Forms.Padding(0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(76, 24);
            this.btnBack.TabIndex = 21;
            this.btnBack.Tag = "color:dark3";
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(150, 383);
            this.Controls.Add(this.pnOptions);
            this.Controls.Add(this.pnTimeFlow);
            this.Controls.Add(this.pnOnlineFlow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "color:dark3";
            this.Text = "Plugin Form";
            this.Load += new System.EventHandler(this.PluginForm_Load);
            this.pnOnlineFlow.ResumeLayout(false);
            this.pnOnlineFlow.PerformLayout();
            this.pnTimeFlow.ResumeLayout(false);
            this.pnTimeFlow.PerformLayout();
            this.pnOptions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnOnlineFlow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTwtchChannel;
        private System.Windows.Forms.Button btnConnectToTwitch;
        private System.Windows.Forms.Panel pnTimeFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbOnlineFlow;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel pnOptions;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.RadioButton rbTotalControl;
        public System.Windows.Forms.RadioButton rbEngineControl;
        public System.Windows.Forms.RadioButton rbBlastControl;
    }
}
