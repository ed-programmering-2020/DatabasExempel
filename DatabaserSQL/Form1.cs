using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaserSQL
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void edlcompanyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.edlcompanyBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.edlunchDataSet1);

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'edlunchDataSet1.edlpurchase' table. You can move, or remove it, as needed.
			this.edlpurchaseTableAdapter.Fill(this.edlunchDataSet1.edlpurchase);
			// TODO: This line of code loads data into the 'edlunchDataSet1.edluser' table. You can move, or remove it, as needed.
			this.edluserTableAdapter.Fill(this.edlunchDataSet1.edluser);
			// TODO: This line of code loads data into the 'edlunchDataSet1.edlcompany' table. You can move, or remove it, as needed.
			this.edlcompanyTableAdapter.Fill(this.edlunchDataSet1.edlcompany);

		}
	}
}
