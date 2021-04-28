using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Desktop_Ame {
	[StructLayout(LayoutKind.Sequential)]
	struct RECT {
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
	}

	enum DWMWINDOWATTRIBUTE {
		DWMWA_NCRENDERING_ENABLED = 1,
		DWMWA_NCRENDERING_POLICY,
		DWMWA_TRANSITIONS_FORCEDISABLED,
		DWMWA_ALLOW_NCPAINT,
		DWMWA_CAPTION_BUTTON_BOUNDS,
		DWMWA_NONCLIENT_RTL_LAYOUT,
		DWMWA_FORCE_ICONIC_REPRESENTATION,
		DWMWA_FLIP3D_POLICY,
		DWMWA_EXTENDED_FRAME_BOUNDS,
		DWMWA_HAS_ICONIC_BITMAP,
		DWMWA_DISALLOW_PEEK,
		DWMWA_EXCLUDED_FROM_PEEK,
		DWMWA_CLOAK,
		DWMWA_CLOAKED,
		DWMWA_FREEZE_REPRESENTATION,
		DWMWA_LAST
	}

	partial class DesktopAme : Form {
		public DesktopAme() {
			InitializeComponent();
			var updateThread = new Thread(this.update);
			updateThread.Start();
			this.closeBtn.Click += (object sender, EventArgs e) => {
				this.Close();
				updateThread.Abort();
				Application.Exit();
			};
		}

		void update() {
			while (true) {
				List<IntPtr> targetProcesses = new List<IntPtr>();
				foreach (Process proc in Process.GetProcesses()) {
					if (proc.MainWindowTitle != "") {
						IntPtr handle = proc.MainWindowHandle;
						IntPtr cloaked;
						if ((uint) DwmGetWindowAttribute(handle, (int) DWMWINDOWATTRIBUTE.DWMWA_CLOAKED, out cloaked, 4 /* sizeof int32_t */) == 0)
							if (cloaked.ToInt32() == 0 /* not cloaked */ && IsWindowVisible(handle))
								targetProcesses.Add(handle);
					}
				}

			pickProcess:
				if (targetProcesses.Count != 0) {
					Random rand = new Random();
					IntPtr handle = targetProcesses[rand.Next(0, targetProcesses.Count)];
					RECT lpRect;
					GetWindowRect(handle, out lpRect);
					if (lpRect.Top == -8 /* fullscreen */) {
						targetProcesses.Remove(handle);
						goto pickProcess;
					}

					this.Invoke((MethodInvoker) delegate {
						this.Location = new Point(lpRect.Right - this.ame.Width, lpRect.Top - (this.ame.Height - 48));
						this.ame.Visible = true;
					});

					Thread.Sleep(875);

					ShowWindow(handle, 6);
					this.Invoke((MethodInvoker) delegate {
						this.ame.Visible = false;
					});

					rand = null;
				}

				targetProcesses = null;

				Thread.Sleep(new Random().Next(3500, 60000));
			}
		}

		[DllImport("user32.dll")]
		static extern bool IsWindowVisible(IntPtr hwnd);
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("dwmapi.dll")]
		static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out IntPtr pvAttribute, int cbAttribute);
	}
}
