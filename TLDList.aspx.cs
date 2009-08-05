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
	/// Summary description for TLDList.
	/// </summary>
		
	public partial class TLDList : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SiteInfo;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected NBADWDataEntryApplication.dsDE_SiteInfo objdsDE_SiteInfo;
		protected NBADWDataEntryApplication.dsDE_Loggers objdsDE_Loggers;
		protected System.Data.DataView dvDE_Loggers;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_Loggers;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				LoadSiteInfo();
				LoadLoggers();

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

				dvDE_Loggers.RowFilter = "AquaticSiteID = "+txtdwsiteid.Text;
				dgLoggers.DataBind();
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

		public void FillLoggers(NBADWDataEntryApplication.dsDE_Loggers dataSet1)
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
				this.oleDbdaDE_Loggers.Fill(dataSet1);
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

		public void LoadLoggers()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_Loggers objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_Loggers();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillLoggers(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_Loggers.Clear();
				
				// Merge the records into the main dataset.
				objdsDE_Loggers.Merge(objDataSetTemp1);
				
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
			this.oleDbdaDE_SiteInfo = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_SiteInfo = new NBADWDataEntryApplication.dsDE_SiteInfo();
			this.objdsDE_Loggers = new NBADWDataEntryApplication.dsDE_Loggers();
			this.dvDE_Loggers = new System.Data.DataView();
			this.oleDbdaDE_Loggers = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_Loggers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_Loggers)).BeginInit();
			this.dgLoggers.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgLoggers_EditCommand);
			// 
			// oleDbdaDE_SiteInfo
			// 
			this.oleDbdaDE_SiteInfo.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdaDE_SiteInfo.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdaDE_SiteInfo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "DE-SiteInfo", new System.Data.Common.DataColumnMapping[] {
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
																																																						new System.Data.Common.DataColumnMapping("YCoordinate", "YCoordinate"),
																																																						new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																						new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd")})});
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = @"INSERT INTO [DE-SiteInfo] (AquaticSiteDesc, AquaticSiteID, AquaticSiteName, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, DrainName, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, AgencySiteID, AgencyCd) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainName", System.Data.OleDb.OleDbType.VarWChar, 255, "DrainName"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSite_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSite.IncorporatedInd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSiteAgencyUse_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSiteAgencyUse.IncorporatedInd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
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
			this.oleDbSelectCommand3.CommandText = @"SELECT AquaticSiteDesc, AquaticSiteID, AquaticSiteName, AquaticSiteUseID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, DrainName, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, AgencySiteID, AgencyCd FROM [DE-SiteInfo]";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO [DE-SiteInfo] (AquaticSiteDesc, AquaticSiteID, AquaticSiteName, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, DrainName, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, AgencySiteID) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
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
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT AquaticSiteDesc, AquaticSiteID, AquaticSiteName, AquaticSiteUseID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, DrainName, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, AgencySiteID FROM [DE-SiteInfo]";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// objdsDE_SiteInfo
			// 
			this.objdsDE_SiteInfo.DataSetName = "dsDE_SiteInfo";
			this.objdsDE_SiteInfo.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// objdsDE_Loggers
			// 
			this.objdsDE_Loggers.DataSetName = "dsDE_Loggers";
			this.objdsDE_Loggers.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_Loggers
			// 
			this.dvDE_Loggers.Sort = "AquaticSiteID";
			this.dvDE_Loggers.Table = this.objdsDE_Loggers._DE_Loggers;
			// 
			// oleDbdaDE_Loggers
			// 
			this.oleDbdaDE_Loggers.InsertCommand = this.oleDbInsertCommand5;
			this.oleDbdaDE_Loggers.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbdaDE_Loggers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "DE-Loggers", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("Accuracy", "Accuracy"),
																																																					  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																					  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																					  new System.Data.Common.DataColumnMapping("BrandName", "BrandName"),
																																																					  new System.Data.Common.DataColumnMapping("DataFileName", "DataFileName"),
																																																					  new System.Data.Common.DataColumnMapping("DistanceFromLeftBank_m", "DistanceFromLeftBank_m"),
																																																					  new System.Data.Common.DataColumnMapping("DistanceFromRightBank_m", "DistanceFromRightBank_m"),
																																																					  new System.Data.Common.DataColumnMapping("Install_AirTemp_C", "Install_AirTemp_C"),
																																																					  new System.Data.Common.DataColumnMapping("Install_TimeofDay", "Install_TimeofDay"),
																																																					  new System.Data.Common.DataColumnMapping("Install_WaterTemp_C", "Install_WaterTemp_C"),
																																																					  new System.Data.Common.DataColumnMapping("InstallationDate", "InstallationDate"),
																																																					  new System.Data.Common.DataColumnMapping("LoggerNo", "LoggerNo"),
																																																					  new System.Data.Common.DataColumnMapping("Model", "Model"),
																																																					  new System.Data.Common.DataColumnMapping("RecordingEndDate", "RecordingEndDate"),
																																																					  new System.Data.Common.DataColumnMapping("RecordingStartDate", "RecordingStartDate"),
																																																					  new System.Data.Common.DataColumnMapping("Removal_AirTemp_C", "Removal_AirTemp_C"),
																																																					  new System.Data.Common.DataColumnMapping("Removal_TimeofDay", "Removal_TimeofDay"),
																																																					  new System.Data.Common.DataColumnMapping("Removal_WaterTemp_C", "Removal_WaterTemp_C"),
																																																					  new System.Data.Common.DataColumnMapping("RemovalDate", "RemovalDate"),
																																																					  new System.Data.Common.DataColumnMapping("Resolution", "Resolution"),
																																																					  new System.Data.Common.DataColumnMapping("SampleInterval_min", "SampleInterval_min"),
																																																					  new System.Data.Common.DataColumnMapping("TemperatureLoggerID", "TemperatureLoggerID"),
																																																					  new System.Data.Common.DataColumnMapping("TempRange_From", "TempRange_From"),
																																																					  new System.Data.Common.DataColumnMapping("TempRange_To", "TempRange_To"),
																																																					  new System.Data.Common.DataColumnMapping("WaterDepth_cm", "WaterDepth_cm"),
																																																					  new System.Data.Common.DataColumnMapping("WaterLevel_Install", "WaterLevel_Install"),
																																																					  new System.Data.Common.DataColumnMapping("WaterLevel_Removal", "WaterLevel_Removal"),
																																																					  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd")})});
			// 
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = @"INSERT INTO [DE-Loggers] (Accuracy, AquaticActivityID, AquaticSiteID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerNo, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TempRange_From, TempRange_To, WaterDepth_cm, WaterLevel_Install, WaterLevel_Removal, AgencyCd) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerNo", System.Data.OleDb.OleDbType.VarWChar, 20, "LoggerNo"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_cm", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_cm"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = @"SELECT Accuracy, AquaticActivityID, AquaticSiteID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerNo, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TemperatureLoggerID, TempRange_From, TempRange_To, WaterDepth_cm, WaterLevel_Install, WaterLevel_Removal, AgencyCd FROM [DE-Loggers]";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = @"INSERT INTO [DE-Loggers] (Accuracy, AquaticActivityID, AquaticSiteID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerID, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TempRange_From, TempRange_To, WaterDepth_m, WaterLevel_Install, WaterLevel_Removal, AgencyCd) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerID", System.Data.OleDb.OleDbType.VarWChar, 20, "LoggerID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_m"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = @"SELECT Accuracy, AquaticActivityID, AquaticSiteID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerID, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TemperatureLoggerID, TempRange_From, TempRange_To, WaterDepth_m, WaterLevel_Install, WaterLevel_Removal, AgencyCd FROM [DE-Loggers]";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = @"INSERT INTO [DE-Loggers] (Accuracy, AquaticActivityID, AquaticSiteID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerID, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TempRange_From, TempRange_To, WaterDepth_m, WaterLevel_Install, WaterLevel_Removal) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerID", System.Data.OleDb.OleDbType.VarWChar, 10, "LoggerID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_m"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT Accuracy, AquaticActivityID, AquaticSiteID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerID, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TemperatureLoggerID, TempRange_From, TempRange_To, WaterDepth_m, WaterLevel_Install, WaterLevel_Removal FROM [DE-Loggers]";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_Loggers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_Loggers)).EndInit();

		}
		#endregion

		#region Buttons
		protected void Button2_Click(object sender, System.EventArgs e)
		{
			/*try
			{
				Server.Transfer(Session["PreviousPage"].ToString());
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Error in transfer: "+ex.ToString());
				Server.Transfer("TemperatureRecordingSites-List.aspx");
			}
			*/
			Server.Transfer("TRSList.aspx");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["Mode"] = "Add";
			Server.Transfer("TLDView.aspx");
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Session["Mode"] = "View";
			Server.Transfer("TLDView.aspx");
		}
		#endregion

		#region dgLoggers
		private void dgLoggers_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i = (int)dgLoggers.DataKeys[(int) e.Item.ItemIndex];
			Session["SelectedTempID"] = i;
			Session["Mode"] = "View";
			Server.Transfer("TLDView.aspx");
		}
		#endregion        		
	}
}
