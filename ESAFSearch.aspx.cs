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
	/// Summary description for ESAFSearch.
	/// </summary>
	
	public partial class ESAFSearch : System.Web.UI.Page
	{
		protected NBADWDataEntryApplication.dsDE_ESAFSiteList objdsDE_ESAFSiteList;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_ESAFSiteList;
		protected System.Data.DataView dvDE_ESAFSiteList;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_Agencies;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected NBADWDataEntryApplication.dscdAgency objdscdAgency;
		protected NBADWDataEntryApplication.dsDE_Agencies objdsDE_Agencies;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				LoadcdAgency();
				dlstAgencyCd.DataBind();
				dlstAgencyCd.Items.Add(new ListItem("All","All"));
				dlstAgencyCd.SelectedIndex = dlstAgencyCd.Items.Count-1;
			}
			else
			{
				//System.IO.StringReader sr1 = new System.IO.StringReader((string)(ViewState["dSet1"]));
				//objdscdAgency.ReadXml(sr1);
			}
		}

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
			this.objdsDE_ESAFSiteList = new NBADWDataEntryApplication.dsDE_ESAFSiteList();
			this.oleDbdaDE_ESAFSiteList = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dvDE_ESAFSiteList = new System.Data.DataView();
			this.oleDbdaDE_Agencies = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.objdscdAgency = new NBADWDataEntryApplication.dscdAgency();
			this.objdsDE_Agencies = new NBADWDataEntryApplication.dsDE_Agencies();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ESAFSiteList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ESAFSiteList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_Agencies)).BeginInit();
			this.dgResults.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgResults_EditCommand);
			this.dgResults.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgResults_SortCommand);
			// 
			// objdsDE_ESAFSiteList
			// 
			this.objdsDE_ESAFSiteList.DataSetName = "dsDE_ESAFSiteList";
			this.objdsDE_ESAFSiteList.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaDE_ESAFSiteList
			// 
			this.oleDbdaDE_ESAFSiteList.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdaDE_ESAFSiteList.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdaDE_ESAFSiteList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "DE-ESAFSiteList", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("NumFollowUp", "NumFollowUp"),
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
																																																								new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID")})});
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO [DE-ESAFSiteList] (NumFollowUp, AgencyCd, AgencySiteID, AquaticActivi" +
				"tyID, AquaticActivityStartDate, DrainageCd, NumActions, NumCompleted, Observatio" +
				"nCategory, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumFollowUp", System.Data.OleDb.OleDbType.Integer, 0, "NumFollowUp"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 16, "AgencySiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumActions", System.Data.OleDb.OleDbType.Integer, 0, "NumActions"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumCompleted", System.Data.OleDb.OleDbType.Integer, 0, "NumCompleted"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationCategory", System.Data.OleDb.OleDbType.VarWChar, 40, "ObservationCategory"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			// 
			// oleDbConnection1
			// 
			try
			{
				//this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Registry Path=;Data Source=""C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb"";Jet OLEDB:System database=;Jet OLEDB:Global Bulk Transactions=1;User ID=Admin;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:SFP=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Engine Type=5;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Global Partial Bulk Ops=2;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Create System Database=False;Jet OLEDB:Database Locking Mode=1";
				this.oleDbConnection1.ConnectionString = Session["ConnectionString"].ToString();
			}
			catch(System.NullReferenceException)
			{
				Server.Transfer("Login.aspx");
			}

			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT NumFollowUp, AgencyCd, AgencySiteID, AquaticActivityID, AquaticActivitySta" +
				"rtDate, DrainageCd, NumActions, NumCompleted, ObservationCategory, WaterBodyID, " +
				"WaterBodyName, AquaticSiteUseID FROM [DE-ESAFSiteList]";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
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
			this.dvDE_ESAFSiteList.Sort = "AquaticActivityID";
			this.dvDE_ESAFSiteList.Table = this.objdsDE_ESAFSiteList._DE_ESAFSiteList;
			// 
			// oleDbdaDE_Agencies
			// 
			this.oleDbdaDE_Agencies.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdaDE_Agencies.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdaDE_Agencies.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "DE-Agencies", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("Agency", "Agency"),
																																																						new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd")})});
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM cdAgency WHERE (AgencyCd = ?) AND (Agency = ? OR ? IS NULL AND Agency" +
				" IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO cdAgency(Agency, AgencyCd) VALUES (?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT Agency, AgencyCd FROM cdAgency";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE cdAgency SET Agency = ?, AgencyCd = ? WHERE (AgencyCd = ?) AND (Agency = ?" +
				" OR ? IS NULL AND Agency IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT Agency, AgencyCd FROM [DE-Agencies]";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO [DE-Agencies] (Agency, AgencyCd) VALUES (?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			// 
			// objdscdAgency
			// 
			this.objdscdAgency.DataSetName = "dscdAgency";
			this.objdscdAgency.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// objdsDE_Agencies
			// 
			this.objdsDE_Agencies.DataSetName = "dsDE_Agencies";
			this.objdsDE_Agencies.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ESAFSiteList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ESAFSiteList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_Agencies)).EndInit();

		}
		#endregion

		#region Buttons
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFList.aspx");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			string filterstring = "(AquaticActivityID >0)";
			
			//get rest of query string
			if(dlstAgencyCd.SelectedValue!="All")
			{
				filterstring += "AND AgencyCd = '"+dlstAgencyCd.SelectedValue+"'";
			}
			if(txtWaterBodyID.Text!="")
			{
				//this handles the possibility of the user entering a string
				//into a field that expects and int
				try
				{
					filterstring += "AND WaterBodyID = " +Convert.ToInt32(txtWaterBodyID.Text);
				}
				catch
				{
					filterstring += "AND WaterBodyID = 0";
				}
				//filterstring += " AND  = '"+txtwaterbodyid.Text+"'";
			}
			if(txtWaterBodyName.Text!="")
			{
				filterstring += " AND WaterBodyName LIKE '"+txtWaterBodyName.Text+"'";
			}
			if(txtWatershedCode.Text!="")
			{
				filterstring += " AND DrainageCd LIKE '"+txtWatershedCode.Text+"'";
			}

			Debug.WriteLine("filter: "+filterstring.ToString());
			//Save filterstring for subsequent posts
			Session["filterstring"]=filterstring;
			dvDE_ESAFSiteList.RowFilter = filterstring;
			
			try 
			{
				LoadSiteList();
			}
			catch(System.Exception eLoad) 
			{
				//this.Response.Write(eLoad.Message);
				Debug.WriteLine("Error: "+eLoad.ToString());
				dgResults.DataBind();
			}
			
			if(dvDE_ESAFSiteList.Count == 0)
			{
				lblMessage.Text = "There were no sites found matching your search criteria.  Please try again.";
				dgResults.DataBind();
			}
			else
			{
				lblMessage.Text = "";
				dgResults.DataBind();
				
			}
		}
#endregion

		#region Fill & Load
		public void FillcdAgency(NBADWDataEntryApplication.dsDE_Agencies dataSet1)
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
				this.oleDbdaDE_Agencies.Fill(dataSet1);
				//this.oleDbdacdAquaticActivity.Fill(dataSet2);
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

		public void LoadcdAgency()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_Agencies objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_Agencies();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillcdAgency(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_Agencies.Clear();
				//objdscdAquaticActivity.Clear();
				// Merge the records into the main dataset.
				objdsDE_Agencies.Merge(objDataSetTemp1);
				//objdscdAquaticActivity.Merge(objDataSetTemp2);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillSiteList(NBADWDataEntryApplication.dsDE_ESAFSiteList dataSet1)
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


		public void LoadSiteList()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_ESAFSiteList objDataSetTemp1;
			
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_ESAFSiteList();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillSiteList(objDataSetTemp1);
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

		#region dgResults
		private void dgResults_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LoadSiteList();
			dvDE_ESAFSiteList.RowFilter = Session["filterstring"].ToString();
			dgResults.DataBind();
		}

		private void dgResults_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			LoadSiteList();
			int i = (int)dgResults.DataKeys[(int) e.Item.ItemIndex];
			Session["CurrentActivityID"] = i;
			int j = dvDE_ESAFSiteList.Find(i);
			Session["SelectedSiteUseID"] = dvDE_ESAFSiteList[j]["AquaticSiteUseID"].ToString();
			Server.Transfer("ESAFView.aspx");
		}
		#endregion
	}
}
