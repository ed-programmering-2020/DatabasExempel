namespace DatabaserSQL
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.edlcompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.edlpurchaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.edlpurchaseTableAdapter = new DatabaserSQL.edlunchDataSetTableAdapters.edlpurchaseTableAdapter();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.edlunchDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edlcompanyBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edluserBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edlpurchaseBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// edlunchDataSet1
			// 
			this.edlunchDataSet1.DataSetName = "edlunchDataSet";
			this.edlunchDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// edlcompanyBindingSource
			// 
			this.edlcompanyBindingSource.DataMember = "edlcompany";
			this.edlcompanyBindingSource.DataSource = this.edlunchDataSet1;
			// 
			// edlcompanyTableAdapter
			// 
			this.edlcompanyTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.edlcompanyTableAdapter = this.edlcompanyTableAdapter;
			this.tableAdapterManager.edlpurchaseTableAdapter = this.edlpurchaseTableAdapter;
			this.tableAdapterManager.edltagTableAdapter = null;
			this.tableAdapterManager.edluserTableAdapter = this.edluserTableAdapter;
			this.tableAdapterManager.sequenceTableAdapter = null;
			this.tableAdapterManager.UpdateOrder = DatabaserSQL.edlunchDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// edluserBindingSource
			// 
			this.edluserBindingSource.DataMember = "edluser";
			this.edluserBindingSource.DataSource = this.edlunchDataSet1;
			// 
			// edluserTableAdapter
			// 
			this.edluserTableAdapter.ClearBeforeFill = true;
			// 
			// edlpurchaseBindingSource
			// 
			this.edlpurchaseBindingSource.DataMember = "edlpurchase";
			this.edlpurchaseBindingSource.DataSource = this.edlunchDataSet1;
			// 
			// edlpurchaseTableAdapter
			// 
			this.edlpurchaseTableAdapter.ClearBeforeFill = true;
			// 
			// textBox1
			// 
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.edluserBindingSource, "ID", true));
			this.textBox1.Location = new System.Drawing.Point(237, 100);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 549);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.edlunchDataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edlcompanyBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edluserBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edlpurchaseBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		
		private System.Windows.Forms.BindingSource edlcompanyBindingSource;
		private System.Windows.Forms.BindingSource edluserBindingSource;
		private System.Windows.Forms.BindingSource edlpurchaseBindingSource;
		private System.Windows.Forms.TextBox textBox1;
	}
}

