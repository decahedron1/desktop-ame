
namespace Desktop_Ame {
	partial class DesktopAme {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesktopAme));
			this.ame = new System.Windows.Forms.PictureBox();
			this.notifIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeBtn = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.ame)).BeginInit();
			this.notifMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// ame
			// 
			this.ame.Image = global::Desktop_Ame.Properties.Resources.minimize;
			this.ame.Location = new System.Drawing.Point(0, -1);
			this.ame.Name = "ame";
			this.ame.Size = new System.Drawing.Size(144, 164);
			this.ame.TabIndex = 0;
			this.ame.TabStop = false;
			this.ame.Visible = false;
			this.ame.WaitOnLoad = true;
			// 
			// notifIcon
			// 
			this.notifIcon.BalloonTipTitle = "Desktop Ame";
			this.notifIcon.ContextMenuStrip = this.notifMenu;
			this.notifIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifIcon.Icon")));
			this.notifIcon.Text = "Desktop Ame";
			this.notifIcon.Visible = true;
			// 
			// notifMenu
			// 
			this.notifMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeBtn});
			this.notifMenu.Name = "notifMenu";
			this.notifMenu.Size = new System.Drawing.Size(181, 48);
			// 
			// closeBtn
			// 
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(180, 22);
			this.closeBtn.Text = "Stop Desktop Ame";
			// 
			// DesktopAme
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(144, 163);
			this.ControlBox = false;
			this.Controls.Add(this.ame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DesktopAme";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Desktop Ame";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.SystemColors.Control;
			((System.ComponentModel.ISupportInitialize)(this.ame)).EndInit();
			this.notifMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox ame;
		private System.Windows.Forms.NotifyIcon notifIcon;
		private System.Windows.Forms.ContextMenuStrip notifMenu;
		private System.Windows.Forms.ToolStripMenuItem closeBtn;
	}
}

