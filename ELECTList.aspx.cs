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
	/// Summary description for ElectList.
	/// </summary>
	public partial class ElectList : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SiteInfo;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected NBADWDataEntryApplication.dsDE_SiteInfo objdsDE_SiteInfo;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_ELECTList;
		protected NBADWDataEntryApplication.dsDE_ELECTList objdsDE_ELECTList;
		protected System.Data.DataView dvDE_ELECTList;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				LoadSiteInfo();
				try 
				{
					LoadActivities();
				}
				catch (System.Data.OleDb.OleDbException err) //catches the case that the population crosstab fails due to empty table
				{ 
					Debug.WriteLine("Error: "+ err.ToString());
					dgActivities.Visible = false;
				}

				DataTable tUse = objdsDE_SiteInfo._DE_SiteInfo;
				DataRow UseRow = tUse.Rows.Find(Session["SelectedSiteUseID"]);

				txtdwsiteid.Text = UseRow["AquaticSiteID"].ToString();
				Session["SelectedSiteID"] = txtdwsiteid.Text;
				txtagencycd.Text = UseRow["AgencyCd"].ToString();
				txtgroupsiteid.Text = UseRow["AgencySiteID"].ToString();
				txtwaterbodyid.Text = UseRow["WaterBodyID"].ToString();
				txtwaterbodyname.Text = UseRow["WaterBodyName"].ToString();
				txtsitename.Text = UseRow["AquaticSiteName"].ToString();
				txtsitedescription.Text = UseRow["AquaticSiteDesc"].ToString();
				txtwatershed.Text = UseRow["DrainName"].ToString();
				txtwatershedcode.Text = UseRow["DrainageCd"].ToString();

				dvDE_ELECTList.RowFilter = "AquaticSiteID = "+txtdwsiteid.Text;
				dgActivities.DataBind();

				try
				{
					if((bool)Session["Administrator"])
					{
						btnAdd.Visible = true;
					}
				}
				catch
				{
					//do nothing, no add button available
				}
			}
		}

		#region Buttons
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["Mode"] = "Add";
			Server.Transfer("ELECTView.aspx");
		}

		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("TRSList.aspx");
		}
		#endregion

		#region Fill & Load
		public void FillSiteInfo(NBADWDataEntryApplication.dsDE_SiteInfo dataSet1)
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
				this.oleDbdaDE_SiteInfo.Fill(dataSet1);
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
			}

		}

		public void LoadSiteInfo()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_SiteInfo objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_SiteInfo();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillSiteInfo(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_SiteInfo.Clear();
				
				// Merge the records into the main dataset.
				objdsDE_SiteInfo.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillActivities(NBADWDataEntryApplication.dsDE_ELECTList dataSet1)
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
				this.oleDbdaDE_ELECTList.Fill(dataSet1);
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
			}
		}

		public void LoadActivities()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_ELECTList objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_ELECTList();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillActivities(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsDE_ELECTList.Clear();
				
				// Merge the records into the main dataset.
				this.objdsDE_ELECTList.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		
		#endregion

		#region dgActivities
		private void dgActivities_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i = (int)dgActivities.DataKeys[(int) e.Item.ItemIndex];
			Session["CurrentActivityID"] = i;
			Session["Mode"] = "View";
			Server.Transfer("ELECTView.aspx");
		}

		private void dgActivities_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LoadActivities();
			dvDE_ELECTList.Sort = e.SortExpression;
			dgActivities.DataBind();
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
			this.oleDbdaDE_SiteInfo = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_SiteInfo = new NBADWDataEntryApplication.dsDE_SiteInfo();
			this.oleDbdaDE_ELECTList = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_ELECTList = new NBADWDataEntryApplication.dsDE_ELECTList();
			this.dvDE_ELECTList = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTList)).BeginInit();
			this.dgActivities.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgActivities_EditCommand);
			this.dgActivities.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgActivities_SortCommand);
			// 
			// oleDbdaDE_SiteInfo
			// 
			this.oleDbdaDE_SiteInfo.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbdaDE_SiteInfo.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbdaDE_SiteInfo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "DE-SiteInfo", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																						new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																						new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																						new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																						new System.Data.Common.DataColumnMapping("AquaticSiteName", "AquaticSiteName"),
																																																						new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																						new System.Data.Common.DataColumnMapping("CoordinateSource", "CoordinateSource"),
																																																						new System.Data.Common.DataColumnMapping("CoordinateSystem", "CoordinateSystem"),
																																																						new System.Data.Common.DataColumnMapping("CoordinateUnits", "CoordinateUnits"),
																																																						new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																						new System.Data.Common.DataColumnMapping("DrainName", "DrainName"),
																																																						new System.Data.Common.DataColumnMapping("tblAquaticSite.IncorporatedInd", "tblAquaticSite.IncorporatedInd"),
																																																						new System.Data.Common.DataColumnMapping("tblAquaticSiteAgencyUse.IncorporatedInd", "tblAquaticSiteAgencyUse.IncorporatedInd"),
																																																						new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																						new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																						new System.Data.Common.DataColumnMapping("XCoordinate", "XCoordinate"),
																																																						new System.Data.Common.DataColumnMapping("YCoordinate", "YCoordinate")})});
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO [DE-SiteInfo] (AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, AquaticSiteName, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, DrainName, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, XCoordinate, YCoordinate) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainName", System.Data.OleDb.OleDbType.VarWChar, 255, "DrainName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSite_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSite.IncorporatedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSiteAgencyUse_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSiteAgencyUse.IncorporatedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
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
			}// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, AquaticSiteName, AquaticSiteUseID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, DrainName, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, XCoordinate, YCoordinate FROM [DE-SiteInfo]";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// objdsDE_SiteInfo
			// 
			this.objdsDE_SiteInfo.DataSetName = "dsDE_SiteInfo";
			this.objdsDE_SiteInfo.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaDE_ELECTList
			// 
			this.oleDbdaDE_ELECTList.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdaDE_ELECTList.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdaDE_ELECTList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "DE-ELECTList", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																						  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																						  new System.Data.Common.DataColumnMapping("AquaticActivityStartDate", "AquaticActivityStartDate"),
																																																						  new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																						  new System.Data.Common.DataColumnMapping("FishSpecies", "FishSpecies"),
																																																						  new System.Data.Common.DataColumnMapping("NoSweeps", "NoSweeps"),
																																																						  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																						  new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																						  new System.Data.Common.DataColumnMapping("AquaticMethod", "AquaticMethod"),
																																																						  new System.Data.Common.DataColumnMapping("Biomass", "Biomass"),
																																																						  new System.Data.Common.DataColumnMapping("Density", "Density"),
																																																						  new System.Data.Common.DataColumnMapping("PHS", "PHS")})});
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO [DE-ELECTList] (AgencyCd, AquaticActivityID, AquaticActivityStartDate" +
				", FishAgeClass, FishSpecies, NoSweeps, AquaticSiteID, AquaticActivityCd, Aquatic" +
				"Method, Biomass, Density, PHS) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClass"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoSweeps", System.Data.OleDb.OleDbType.SmallInt, 0, "NoSweeps"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethod", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticMethod"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Biomass", System.Data.OleDb.OleDbType.Double, 0, "Biomass"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Density", System.Data.OleDb.OleDbType.Double, 0, "Density"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PHS", System.Data.OleDb.OleDbType.Double, 0, "PHS"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT AgencyCd, AquaticActivityID, AquaticActivityStartDate, FishAgeClass, FishS" +
				"pecies, NoSweeps, AquaticSiteID, AquaticActivityCd, AquaticMethod, Biomass, Dens" +
				"ity, PHS FROM [DE-ELECTList]";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// objdsDE_ELECTList
			// 
			this.objdsDE_ELECTList.DataSetName = "dsDE_ELECTList";
			this.objdsDE_ELECTList.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_ELECTList
			// 
			this.dvDE_ELECTList.Table = this.objdsDE_ELECTList._DE_ELECTList;
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTList)).EndInit();

		}
		#endregion
		
	}
}
