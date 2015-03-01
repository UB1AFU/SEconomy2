using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEconomy2Plugin.Forms {
	public partial class CSEconomySetupWnd : Form {
		public CSEconomySetupWnd()
		{
			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
