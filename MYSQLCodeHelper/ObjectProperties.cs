using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSQLCodeHelper
{
	public partial class ObjectProperties<T> : Form
	{

	
		public ObjectProperties(T obj)
		{

			InitializeComponent();
			ConstructorInfo ctrI =  obj.GetType().GetConstructor(Type.EmptyTypes);
			if (obj == null) obj = (T) ctrI.Invoke(null); 
			PropertyInfo[] probs=  obj.GetType().GetProperties();

			
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			Form2 f2 = new Form2();
			f2.SelectedObject = new kunder();
			f2.ShowDialog();
		}
	}
}
