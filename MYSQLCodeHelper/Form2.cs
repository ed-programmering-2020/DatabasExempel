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

namespace MYSQLCodeHelper {

	public class Form2 : Form {
		private Boolean isBrowsable(PropertyInfo info) {
			return info.GetCustomAttributes(typeof(BrowsableAttribute), false).Length > -1;
		}
		public Form2() {
			InitializeComponent();
		}
		public Form2(Boolean showCheckBoxes) {
			InitializeComponent();
			_showCheckBoxes = showCheckBoxes;
		}

		private List<String> _ReadOnlyProps;
		private Boolean _showCheckBoxes;
		private Object _reflection;
		private TableLayoutPanel _table = new TableLayoutPanel { Dock = DockStyle.Fill, CellBorderStyle = TableLayoutPanelCellBorderStyle.None };

		public Object SelectedObject {
			get {
				return _reflection;
			}
			set {
				//clear all controls from the table
				_table.Controls.Clear();
				_reflection = value;

				foreach (var property in _reflection.GetType().GetProperties()) {
					
					if (isBrowsable(property)) {
						if ((property.PropertyType == typeof(int)) || (property.PropertyType == typeof(string))) {
							var textField = new TextBox { Dock = DockStyle.Fill, AutoSize = true };
							textField.DataBindings.Add("Text", _reflection, property.Name);

							bool readOnly = false;
							if (_ReadOnlyProps.Contains(property.Name)) {
								textField.ReadOnly = true;
								textField.BackColor = Color.DarkGray;
								readOnly = true; 
							}

							_table.Controls.Add(textField, 2, _table.RowCount += 1);

							var propertyLabel = new Label {
								Text = property.Name,
								Dock = DockStyle.Fill,
								TextAlign = ContentAlignment.MiddleLeft
							};
							if (readOnly) propertyLabel.ForeColor = Color.DarkRed;
								_table.Controls.Add(propertyLabel, 1, _table.RowCount);

							if (_showCheckBoxes) {
								var checkBox = new CheckBox {
									AutoSize = true,
									Name = property.Name,
									Dock = DockStyle.Left,
									CheckAlign = ContentAlignment.TopLeft
								};
								
								_table.Controls.Add(checkBox, 0, _table.RowCount);
							}
						}
					}
				} // end of foreach all Properties Controls
				  //add one extra row to finish alignment
				Button btnOK = new Button { Dock = DockStyle.Fill, AutoSize = true, Text = "OK" };
				Button btnCancel = new Button { Dock = DockStyle.Fill, AutoSize = true, Text = "Avbryt" };
				_table.Controls.Add(btnOK, 1, _table.RowCount += 1);
				_table.Controls.Add(btnCancel, 2, _table.RowCount );
				this.AcceptButton = btnOK;
				this.CancelButton = btnCancel; 
				

				var panel = new Panel { AutoSize = true };
				_table.Controls.Add(panel, 2, _table.RowCount += 1);
				_table.Controls.Add(panel, 1, _table.RowCount);
				if (_showCheckBoxes) {
					_table.Controls.Add(panel, 0, _table.RowCount);
				}
				Controls.Add(_table);


				if (!Controls.Contains(_table))
					Controls.Add(_table);
				this.Height = _table.RowCount * 30;
			}

		}

		public List<string> ReadOnlyProps {
			get {
				return _ReadOnlyProps;
			}

			set {
				_ReadOnlyProps = value;
			}
		}

		public Boolean Execute(Object reflection) {
			SelectedObject = reflection;
			return ShowDialog() == DialogResult.OK;
		}

		private void InitializeComponent() {
			this.SuspendLayout();
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 249);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);

		}
	}
}
