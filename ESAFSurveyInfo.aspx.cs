using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
	/// Summary description for ESAFSurveyInfo.
	/// </summary>
	public partial class ESAFSurveyInfo : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticActivity;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected NBADWDataEntryApplication.dstblAquaticActivity objdstblAquaticActivity;
		protected System.Web.UI.WebControls.TextBox txtpersonnel2;
		protected System.Web.UI.WebControls.TextBox txtpersonnel3;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdAgency;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected NBADWDataEntryApplication.dscdAgency objdscdAgency;
		protected System.Data.DataView dvcdAgency;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				//LoadAgencySet();
				//dlstAgency.DataBind();
				txtAgency.Text = Session["UserAgency"].ToString();
				try
				{
					if((bool)Session["Modify"])
					{
						//set values
						btnSave.Visible = true;
						btnCancel.Visible = true;
						btnNext.Visible = false;

						SetValues();

						//Set Labels
						lblh2.Text = "EDIT Assessment";
						lblStep.Visible = false;
					}
				}
				catch
				{
					//do nothing
				}
			}
		}

		public int FindBiggest(DataTable t,string field)
		{
			//method to find the biggest value in an integer field of a datatable
			int biggest = 0;
			DataRow[] currentrows = t.Select(null, null, DataViewRowState.CurrentRows);
			foreach( DataRow myrow in currentrows)
			{
				if( (int)myrow[field]> biggest)
				{
					biggest = (int)myrow[field];
				}
			}
			return biggest;
		}

		public void SetValues()
		{
			LoadActivitySet();
			DataTable ct = objdstblAquaticActivity.tblAquaticActivity;
			DataRow cr = ct.Rows.Find(Session["CurrentActivityID"]);

			txtdate.Text = cr["AquaticActivityStartDate"].ToString();
			txtpersonnel1.Text = cr["Crew"].ToString();

			txtAgency.Text = Session["UserAgency"].ToString();
			//int i = dvcdAgency.Find(cr["AgencyCd"].ToString());
			//dlstAgency.SelectedIndex = i;
		}

		#region Fill & Load
		public void FillActivitySet(NBADWDataEntryApplication.dstblAquaticActivity dataSet)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet.EnforceConstraints = false;
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdatblAquaticActivity.Fill(dataSet);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}

		}

		public void LoadActivitySet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dstblAquaticActivity objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dstblAquaticActivity();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillActivitySet(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblAquaticActivity.Clear();
				// Merge the records into the main dataset.
				objdstblAquaticActivity.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		public void FillAgencySet(NBADWDataEntryApplication.dscdAgency dataSet)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet.EnforceConstraints = false;
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdacdAgency.Fill(dataSet);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}

		}

		public void LoadAgencySet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dscdAgency objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dscdAgency();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillAgencySet(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdscdAgency.Clear();
				// Merge the records into the main dataset.
				objdscdAgency.Merge(objDataSetTemp);
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
			this.oleDbdatblAquaticActivity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdstblAquaticActivity = new NBADWDataEntryApplication.dstblAquaticActivity();
			this.oleDbdacdAgency = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.objdscdAgency = new NBADWDataEntryApplication.dscdAgency();
			this.dvcdAgency = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdAgency)).BeginInit();
			// 
			// oleDbdatblAquaticActivity
			// 
			this.oleDbdatblAquaticActivity.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbdatblAquaticActivity.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbdatblAquaticActivity.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbdatblAquaticActivity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "tblAquaticActivity", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityStartDate", "AquaticActivityStartDate"),
																																																									  new System.Data.Common.DataColumnMapping("Crew", "Crew"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																									  new System.Data.Common.DataColumnMapping("IncorporatedInd", "IncorporatedInd"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																									  new System.Data.Common.DataColumnMapping("DateEntered", "DateEntered")})});
			this.oleDbdatblAquaticActivity.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM tblAquaticActivity WHERE (AquaticActivityID = ?) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticActivityStartDate = ? OR ? IS NULL AND AquaticActivityStartDate IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (Crew = ? OR ? IS NULL AND Crew IS NULL) AND (DateEntered = ?) AND (IncorporatedInd = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
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
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tblAquaticActivity(AgencyCd, AquaticActivityStartDate, Crew, AquaticA" +
				"ctivityID, AquaticSiteID, IncorporatedInd, AquaticActivityCd, DateEntered) VALUE" +
				"S (?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT AgencyCd, AquaticActivityStartDate, Crew, AquaticActivityID, AquaticSiteID" +
				", IncorporatedInd, AquaticActivityCd, DateEntered FROM tblAquaticActivity";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE tblAquaticActivity SET AgencyCd = ?, AquaticActivityStartDate = ?, Crew = ?, AquaticActivityID = ?, AquaticSiteID = ?, IncorporatedInd = ?, AquaticActivityCd = ?, DateEntered = ? WHERE (AquaticActivityID = ?) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticActivityStartDate = ? OR ? IS NULL AND AquaticActivityStartDate IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (Crew = ? OR ? IS NULL AND Crew IS NULL) AND (DateEntered = ?) AND (IncorporatedInd = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblAquaticActivity
			// 
			this.objdstblAquaticActivity.DataSetName = "dstblAquaticActivity";
			this.objdstblAquaticActivity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdacdAgency
			// 
			this.oleDbdacdAgency.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbdacdAgency.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdacdAgency.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdacdAgency.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cdAgency", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("Agency", "Agency"),
																																																				  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd")})});
			this.oleDbdacdAgency.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM cdAgency WHERE (AgencyCd = ?) AND (Agency = ? OR ? IS NULL AND Agency" +
				" IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
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
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE cdAgency SET Agency = ?, AgencyCd = ? WHERE (AgencyCd = ?) AND (Agency = ?" +
				" OR ? IS NULL AND Agency IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdAgency
			// 
			this.objdscdAgency.DataSetName = "dscdAgency";
			this.objdscdAgency.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvcdAgency
			// 
			this.dvcdAgency.Sort = "AgencyCd";
			this.dvcdAgency.Table = this.objdscdAgency.cdAgency;
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdAgency)).EndInit();

		}
		#endregion

		#region Buttons
		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			//need to load activity dataset to get next index to use
			//if this were auto number, I don't think this would be necessary
			
			LoadActivitySet();
			DataTable tActivity = objdstblAquaticActivity.tblAquaticActivity;
			DataRow rActivity = tActivity.NewRow();

			int i = FindBiggest(tActivity,"AquaticActivityID");
			string strPersonnel = "";
			if(txtpersonnel1.Text!="")
			{
				strPersonnel +=txtpersonnel1.Text;
			}
						
			rActivity["AquaticActivityID"] = i+1;
			Session["CurrentActivityID"] = rActivity["AquaticActivityID"];
			//hard code this in later
			rActivity["AquaticActivityCd"] = 29;
			rActivity["AquaticSiteID"] = Session["SelectedSiteID"].ToString();
			rActivity["AquaticActivityStartDate"] = txtdate.Text;
			//Debug.WriteLine("Selection is " +dlstAgency.SelectedItem);
			//rActivity["AgencyCd"] = dlstAgency.SelectedValue;
			rActivity["AgencyCd"] = txtAgency.Text;
			if(strPersonnel!="")
			{
				rActivity["Crew"] = strPersonnel;
			}
			rActivity["DateEntered"]=System.DateTime.Now;
			rActivity["IncorporatedInd"] = false;

			tActivity.Rows.Add(rActivity);

			try
			{
				oleDbdatblAquaticActivity.Update(objdstblAquaticActivity);
				Server.Transfer("ESAFSiteObservations.aspx");
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error during update: "+ex.ToString());
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string strValues = "AquaticActivityCd = 29";
			strValues += ", AquaticActivityStartDate = '"+txtdate.Text+"'";
			//strValues += ", AgencyCd = '"+dlstAgency.SelectedValue+"'";
			strValues += ", AgencyCd = '"+txtAgency.Text+"'";

			if(txtpersonnel1.Text!="")
			{
				strValues += ", Crew = '"+txtpersonnel1.Text+"'";
			}
			else 
			{
				strValues += ", Crew = null";
			}
			
			try
			{
				string sql = "UPDATE tblAquaticActivity SET "+strValues+" WHERE AquaticActivityID = "+Session["CurrentActivityID"].ToString();
				oleDbConnection1.Open();
				OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
				cmd.ExecuteNonQuery();
				Server.Transfer("ESAFView.aspx");
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Error during update: "+ex.ToString());
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFView.aspx");
		}
		#endregion		
		
	}
}
