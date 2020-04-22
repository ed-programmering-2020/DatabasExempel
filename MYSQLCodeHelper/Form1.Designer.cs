namespace MYSQLCodeHelper
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
			this.tbxConnectString = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.lstbTables = new System.Windows.Forms.ListBox();
			this.tbxResult = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxNamespace = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbxConnectString
			// 
			this.tbxConnectString.Location = new System.Drawing.Point(166, 15);
			this.tbxConnectString.Name = "tbxConnectString";
			this.tbxConnectString.Size = new System.Drawing.Size(404, 20);
			this.tbxConnectString.TabIndex = 0;
			this.tbxConnectString.Text = "SERVER=localhost;DATABASE=programmering2;UID=elev;PASSWORD=jordgubb;";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mysql Connection String";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(614, 11);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(162, 24);
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "Ta kontakt med DB";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// lstbTables
			// 
			this.lstbTables.FormattingEnabled = true;
			this.lstbTables.Location = new System.Drawing.Point(38, 58);
			this.lstbTables.Name = "lstbTables";
			this.lstbTables.Size = new System.Drawing.Size(160, 95);
			this.lstbTables.TabIndex = 3;
			this.lstbTables.SelectedIndexChanged += new System.EventHandler(this.lstbTables_SelectedIndexChanged);
			// 
			// tbxResult
			// 
			this.tbxResult.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxResult.Location = new System.Drawing.Point(217, 58);
			this.tbxResult.Multiline = true;
			this.tbxResult.Name = "tbxResult";
			this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbxResult.Size = new System.Drawing.Size(559, 323);
			this.tbxResult.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(38, 191);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Ange Namespace";
			// 
			// tbxNamespace
			// 
			this.tbxNamespace.Location = new System.Drawing.Point(38, 222);
			this.tbxNamespace.Name = "tbxNamespace";
			this.tbxNamespace.Size = new System.Drawing.Size(160, 20);
			this.tbxNamespace.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 302);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbxNamespace);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbxResult);
			this.Controls.Add(this.lstbTables);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbxConnectString);
			this.Name = "Form1";
			this.Text = "MySQLHelper";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbxConnectString;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.ListBox lstbTables;
		private System.Windows.Forms.TextBox tbxResult;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxNamespace;
		private System.Windows.Forms.Button button1;
	}
}

