using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NBADWDataEntryApplication
{
	/// <summary>
	/// Summary description for ESAFList.
	/// </summary>

	public partial class ESAFList : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_ESAFSiteList;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.DataView dvDE_ESAFSiteList;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected NBADWDataEntryApplication.dsDE_ESAFSiteList objdsDE_ESAFSiteList;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				try
				{
					LoadDataSets();					
				}
				catch//data tables are empty
				{
					//do nothing
				}
				dgSiteList.DataBind();
			}
			else//retrieve datasets
			{
				System.IO.StringReader sr1 = new System.IO.StringReader((string)(ViewState["dSet1"]));
				objdsDE_ESAFSiteList.ReadXml(sr1);
			}
			try
			{
				if((bool)Session["Administrator"])
				{
					btnAdd.Visible = true;
				}
			}
			catch
			{
				//do nothing, leave button not visible
			}
		}

		#region Fill & Load
		public void FillDataSets(NBADWDataEntryApplication.dsDE_ESAFSiteList dataSet1)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet1.EnforceConstraints = false;
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdaDE_ESAFSiteList.Fill(dataSet1);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet1.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();

				System.IO.StringWriter sw1 = new System.IO.StringWriter();
				
				// Write the DataSet to the ViewState property.
				dataSet1.WriteXml(sw1);
				ViewState["dSet1"] = sw1.ToString();
			}

		}


		public void LoadDataSets()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_ESAFSiteList objDataSetTemp1;
			
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_ESAFSiteList();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDataSets(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_ESAFSiteList.Clear();
				// Merge the records into the main dataset.
				objdsDE_ESAFSiteList.Merge(objDataSetTemp1);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.oleDbdaDE_ESAFSiteList = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dvDE_ESAFSiteList = new System.Data.DataView();
			this.objdsDE_ESAFSiteList = new NBADWDataEntryApplication.dsDE_ESAFSiteList();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ESAFSiteList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ESAFSiteList)).BeginInit();
			this.dgSiteList.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSiteList_EditCommand);
			this.dgSiteList.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgSiteList_SortCommand);
			// 
			// oleDbdaDE_ESAFSiteList
			// 
			this.oleDbdaDE_ESAFSiteList.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdaDE_ESAFSiteList.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdaDE_ESAFSiteList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "DE-ESAFSiteList", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																								new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																								new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																								new System.Data.Common.DataColumnMapping("AquaticActivityStartDate", "AquaticActivityStartDate"),
																																																								new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																								new System.Data.Common.DataColumnMapping("NumActions", "NumActions"),
																																																								new System.Data.Common.DataColumnMapping("NumCompleted", "NumCompleted"),
																																																								new System.Data.Common.DataColumnMapping("ObservationCategory", "ObservationCategory"),
																																																								new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																								new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																								new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																								new System.Data.Common.DataColumnMapping("NumFollowUp", "NumFollowUp")})});
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO [DE-ESAFSiteList] (AgencyCd, AgencySiteID, AquaticActivityID, Aquatic" +
				"ActivityStartDate, DrainageCd, NumActions, NumCompleted, ObservationCategory, Wa" +
				"terBodyID, WaterBodyName, NumFollowUp) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumActions", System.Data.OleDb.OleDbType.Integer, 0, "NumActions"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumCompleted", System.Data.OleDb.OleDbType.Integer, 0, "NumCompleted"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationCategory", System.Data.OleDb.OleDbType.VarWChar, 40, "ObservationCategory"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumFollowUp", System.Data.OleDb.OleDbType.Integer, 0, "NumFollowUp"));
			// 
			// oleDbConnection1
			// 
			try
			{
				//this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Registry Path=;Data Source=""C:\Data_Warehouse\Tabular_Data\DE-HRAA.mdb"";Jet OLEDB:System database=;Jet OLEDB:Global Bulk Transactions=1;User ID=Admin;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:SFP=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Engine Type=5;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Global Partial Bulk Ops=2;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Create System Database=False;Jet OLEDB:Database Locking Mode=1";
				this.oleDbConnection1.ConnectionString = Session["ConnectionString"].ToString();
			}
			catch(System.NullReferenceException)
			{
				Server.Transfer("Login.aspx");
			}
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivityID, AquaticActivityStartDate, Drain" +
				"ageCd, NumActions, NumCompleted, ObservationCategory, WaterBodyID, WaterBodyName" +
				", AquaticSiteUseID, NumFollowUp FROM [DE-ESAFSiteList]";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO [DE-ESAFSiteList] ([-1], AgencyCd, AgencySiteID, AquaticActivityID, A" +
				"quaticActivityStartDate, DrainageCd, NumActions, NumCompleted, ObservationCatego" +
				"ry, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("_1", System.Data.OleDb.OleDbType.Integer, 0, "-1"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumActions", System.Data.OleDb.OleDbType.Integer, 0, "NumActions"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumCompleted", System.Data.OleDb.OleDbType.Integer, 0, "NumCompleted"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationCategory", System.Data.OleDb.OleDbType.VarWChar, 40, "ObservationCategory"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT [-1], AgencyCd, AgencySiteID, AquaticActivityID, AquaticActivityStartDate," +
				" DrainageCd, NumActions, NumCompleted, ObservationCategory, WaterBodyID, WaterBo" +
				"dyName, AquaticSiteUseID FROM [DE-ESAFSiteList]";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// dvDE_ESAFSiteList
			// 
			this.dvDE_ESAFSiteList.Table = this.objdsDE_ESAFSiteList._DE_ESAFSiteList;
			// 
			// objdsDE_ESAFSiteList
			// 
			this.objdsDE_ESAFSiteList.DataSetName = "dsDE_ESAFSiteList";
			this.objdsDE_ESAFSiteList.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ESAFSiteList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ESAFSiteList)).EndInit();

		}
		#endregion

		#region Buttons
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = false;
			Server.Transfer("ESAFSiteIdentification.aspx");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFSearch.aspx");
		}

		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("MainMenu.aspx");
		}

		protected void btnDownload_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "ESAFList.aspx";
			Server.Transfer("Download.aspx");
		}
		#endregion

		#region dgSiteList
		private void dgSiteList_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i = (int)dgSiteList.DataKeys[(int) e.Item.ItemIndex];
			Session["CurrentActivityID"] = i;
			dvDE_ESAFSiteList.Sort = "AquaticActivityID";
			int j = dvDE_ESAFSiteList.Find(i);
			Session["SelectedSiteUseID"] = dvDE_ESAFSiteList[j]["AquaticSiteUseID"].ToString();
			Session["Modify"] = false;
			Server.Transfer("ESAFView.aspx");
		}

		private void dgSiteList_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LoadDataSets();
			this.dvDE_ESAFSiteList.Sort = e.SortExpression;
			dgSiteList.DataBind();
		}
		#endregion		

		

		
	}
}
