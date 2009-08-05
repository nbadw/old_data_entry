//Version 1 = Temperature Data Site
//Version 2 = Stocking Data Site
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
//using System.Windows.Forms;

namespace NBADWDataEntryApplication 
{
	/// <summary>
	/// Summary description for TemperatureRecordingSites.
	/// </summary> System.Web.UI.Page
	/// 
	/*

	try
			{
				//this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Registry Path=;Data Source=""C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb"";Jet OLEDB:System database=;Jet OLEDB:Global Bulk Transactions=1;User ID=Admin;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:SFP=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Engine Type=5;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Global Partial Bulk Ops=2;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Create System Database=False;Jet OLEDB:Database Locking Mode=1";
				this.oleDbConnection1.ConnectionString = Session["ConnectionString"].ToString();
			}
			catch(System.NullReferenceException)
			{
				Server.Transfer("Login.aspx");
			}
		*/

	public partial class TemperatureRecordingSites : System.Web.UI.Page
	{
		protected System.Data.DataView dvSortedSites;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaSiteList;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected NBADWDataEntryApplication.dsDE_SiteList objdsDE_SiteList;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				try 
				{
					this.LoadSiteList();
					switch ((int)Session["Version"])
					{
						case 20://thermistor
							dvSortedSites.RowFilter = "AquaticActivityCd = 20";
							lblHeading1.Text = "WATER TEMPERATURES";
							lblType1.Text = "temperature";
                            lblType2.Text = "temperature logger";
							break;
						case 5://stocking
							dvSortedSites.RowFilter = "AquaticActivityCd = 5";
							lblHeading1.Text = "FISH STOCKING";
							lblType1.Text = "stocking";
							lblType2.Text = "stocking";							
							break;
						case 2://electrofishing
							dvSortedSites.RowFilter = "AquaticActivityCd = 2";
							lblHeading1.Text = "ELECTROFISHING";
							lblType1.Text = "electrofishing";
							lblType2.Text = "electrofishing";
							break;
					}
					this.masterDataGrid.SelectedIndex = -1;
					this.masterDataGrid.DataBind();					
				}
				catch (System.Exception eLoad) 
				{
					this.Response.Write(eLoad.Message);
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
					//do nothing
				}
			}
		}


		#region masterDataGrid
		private void masterDataGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//set current page of datagrid to selected page
			masterDataGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadSiteList();
			masterDataGrid.DataBind();
		}

		private void masterDataGrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//Save the AquaticSiteUseID of the selected record
			//for this to work, the datakey of the datagrid must be set to 
			//AquaticSiteUseID
			int i = (int)masterDataGrid.DataKeys[(int) e.Item.ItemIndex];
			Session["SelectedSiteUseID"] = i;
			Session["Mode"] = "View";
			Server.Transfer("TRSView.aspx");			
		}

		private void masterDataGrid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LoadSiteList();
			dvSortedSites.RowFilter = "AquaticActivityCd = "+Session["Version"];
			this.masterDataGrid.SelectedIndex = -1;
			dvSortedSites.Sort = e.SortExpression;
			masterDataGrid.DataBind();
		}
		#endregion

		#region Buttons
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "TRSList.aspx";
			Server.Transfer("wfSiteType.aspx");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "TRSList.aspx";
			Server.Transfer("TRSSearch.aspx");
		}

		protected void btnDownload_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "TRSList.aspx";
			Server.Transfer("Download.aspx");
		}
		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("MainMenu.aspx");
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
			this.dvSortedSites = new System.Data.DataView();
			this.objdsDE_SiteList = new NBADWDataEntryApplication.dsDE_SiteList();
			this.oleDbdaSiteList = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dvSortedSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteList)).BeginInit();
			this.masterDataGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.masterDataGrid_PageIndexChanged);
			this.masterDataGrid.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.masterDataGrid_EditCommand);
			this.masterDataGrid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.masterDataGrid_SortCommand);
			// 
			// dvSortedSites
			// 
			this.dvSortedSites.Table = this.objdsDE_SiteList._DE_SiteList;
			// 
			// objdsDE_SiteList
			// 
			this.objdsDE_SiteList.DataSetName = "dsDE_SiteList";
			this.objdsDE_SiteList.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaSiteList
			// 
			this.oleDbdaSiteList.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbdaSiteList.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbdaSiteList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "DE-SiteList", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																					 new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																					 new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																					 new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																					 new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																					 new System.Data.Common.DataColumnMapping("AquaticSiteName", "AquaticSiteName"),
																																																					 new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																					 new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																					 new System.Data.Common.DataColumnMapping("tblAquaticSite.IncorporatedInd", "tblAquaticSite.IncorporatedInd"),
																																																					 new System.Data.Common.DataColumnMapping("tblAquaticSiteAgencyUse.IncorporatedInd", "tblAquaticSiteAgencyUse.IncorporatedInd"),
																																																					 new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																					 new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																					 new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO [DE-SiteList] (AgencyCd, AgencySiteID, AquaticActivityCd, AquaticSiteDesc, AquaticSiteID, AquaticSiteName, DrainageCd, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, WaterBodyName_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSite_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSite.IncorporatedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSiteAgencyUse_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSiteAgencyUse.IncorporatedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
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
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT AgencyCd, AgencySiteID, AquaticActivityCd, AquaticSiteDesc, AquaticSiteID, AquaticSiteName, AquaticSiteUseID, DrainageCd, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, WaterBodyName_Abrev FROM [DE-SiteList]";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = @"INSERT INTO [DE-SiteList] (AgencyCd, AgencySiteID, AquaticActivityCd, AquaticSiteDesc, AquaticSiteID, AquaticSiteName, DrainageCd, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSite_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSite.IncorporatedInd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSiteAgencyUse_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSiteAgencyUse.IncorporatedInd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivityCd, AquaticSiteDesc, AquaticSiteID," +
				" AquaticSiteName, AquaticSiteUseID, DrainageCd, [tblAquaticSite.IncorporatedInd]" +
				", [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName FROM [DE" +
				"-SiteList]";
			((System.ComponentModel.ISupportInitialize)(this.dvSortedSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteList)).EndInit();

		}
		#endregion

		#region Fill & Load
		/*
		public void FillThermistorSites(NBADWDataEntryApplication.dsThermistorSites dataSet)
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
				this.oleDbdaThermistorSites.Fill(dataSet);
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

		public void LoadThermistorSites()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dsThermistorSites objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dsThermistorSites();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillThermistorSites(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsThermistorSites.Clear();
				// Merge the records into the main dataset.
				objdsThermistorSites.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillStockingSites(NBADWDataEntryApplication.dsDE_StockingSites dataSet)
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
				this.oleDbdaStockingSites.Fill(dataSet);
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

		public void LoadStockingSites()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dsDE_StockingSites objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dsDE_StockingSites();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillStockingSites(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_StockingSites.Clear();
				// Merge the records into the main dataset.
				objdsDE_StockingSites.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
*/
		public void FillSiteList(NBADWDataEntryApplication.dsDE_SiteList dataSet)
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
				this.oleDbdaSiteList.Fill(dataSet);
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

		public void LoadSiteList()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dsDE_SiteList objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dsDE_SiteList();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillSiteList(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_SiteList.Clear();
				// Merge the records into the main dataset.
				objdsDE_SiteList.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}
		#endregion		

		
	}
}
