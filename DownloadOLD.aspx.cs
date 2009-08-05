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
	/// Summary description for Download.
	/// </summary>
	/// 
	/*
	 * 	
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
	
	public partial class Download : System.Web.UI.Page
	{
		#region Controls
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdAgency;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected NBADWDataEntryApplication.dscdAgency objdscdAgency;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryElectrofishingDataPlusEstimates;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected NBADWDataEntryApplication.dsqryElectrofishingDataPlusEstimates objdsqryElectrofishingDataPlusEstimates;
		protected System.Data.DataView dvqryElectrofishingDataPlusEstimates;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryElectrofishingMethodDetails;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected NBADWDataEntryApplication.dsqryElectrofishingMethodDetails objdsqryElectrofishingMethodDetails;
		protected System.Data.DataView dvqryElectrofishingMethodDetails;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryElectrofishingSiteMeasurements;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected NBADWDataEntryApplication.dsqryElectrofishingSiteMeasurements objdsqryElectrofishingSiteMeasurements;
		protected System.Data.DataView dvqryElectrofishingSiteMeasurements;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryElectrofishingSites;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		protected NBADWDataEntryApplication.dsqryElectrofishingSites objdsqryElectrofishingSites;
		protected System.Data.DataView dvqryElectrofishingSites;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryElectrofishingWaterMeasurements;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		protected NBADWDataEntryApplication.dsqryElectrofishingWaterMeasurements objdsqryElectrofishingWaterMeasurements;
		protected System.Data.DataView dvqryElectrofishingWaterMeasurements;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryESAObservations;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand7;
		protected NBADWDataEntryApplication.dsqryESAObservations objdsqryESAObservations;
		protected System.Data.DataView dvqryESAObservations;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryESAPlanning;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand8;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand8;
		protected NBADWDataEntryApplication.dsqryESAPlanning objdsqryESAPlanning;
		protected System.Data.DataView dvqryESAPlanning;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryESASiteMeasurements;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand9;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand9;
		protected NBADWDataEntryApplication.dsqryESASiteMeasurements objdsqryESASiteMeasurements;
		protected System.Data.DataView dvqryESASiteMeasurements;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryESASites;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand10;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand10;
		protected NBADWDataEntryApplication.dsqryESASites objdsqryESASites;
		protected System.Data.DataView dvqryESASites;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryFishStocking;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand11;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand11;
		protected NBADWDataEntryApplication.dsqryFishStocking objdsqryFishStocking;
		protected System.Data.DataView dvqryFishStocking;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryFishStockingSites;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand12;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand12;
		protected NBADWDataEntryApplication.dsqryFishStockingSites objdsqryFishStockingSites;
		protected System.Data.DataView dvqryFishStockingSites;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryWaterTemperatureLoggerDetails;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand13;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand13;
		protected NBADWDataEntryApplication.dsqryWaterTemperatureLoggerDetails objdsqryWaterTemperatureLoggerDetails;
		protected System.Data.DataView dvqryWaterTemperatureLoggerDetails;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryWaterTemperatureLoggerMeasurements;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand14;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand14;
		protected NBADWDataEntryApplication.dsqryWaterTemperatureLoggerMeasurements objdsqryWaterTemperatureLoggerMeasurements;
		protected System.Data.DataView dvqryWaterTemperatureLoggerMeasurements;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryWaterTemperatureLoggerSites;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand15;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand15;
		protected NBADWDataEntryApplication.dsqryWaterTemperatureLoggerSites objdsqryWaterTemperatureLoggerSites;
		protected System.Data.DataView dvqryWaterTemperatureLoggerSites;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaqryElectrofishingMarkRecaptureDataPlusEstimates;
		protected NBADWDataEntryApplication.dsqryElectrofishingMarkRecaptureDataPlusEstimates objdsqryElectrofishingMarkRecaptureDataPlusEstimates;
		protected System.Data.DataView dvqryElectrofishingMarkRecaptureDataPlusEstimates;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand16;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand16;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand17;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand17;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand20;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand20;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand18;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand18;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand21;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand21;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand19;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand19;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand22;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand22;

		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				LoadCodeDataSet();
				dlstAgencyCode.DataBind();
				dlstAgencyCode.Items.Add(new ListItem("All", "All"));
				dlstAgencyCode.SelectedIndex = dlstAgencyCode.Items.Count-1;
				/*dgTemperatureLoggerSites.DataBind();
				dgTemperatureLoggerDetails.DataBind();
				dgDailyTemperatures.DataBind();
				*/

				switch ((int)Session["Version"])
				{
					case 20://thermistor
						lblh1.Text = "WATER TEMPERATURES";
						break;
					case 5://stocking
						lblh1.Text = "FISH STOCKING";
						break;
					case 2://electrofishing
						lblh1.Text = "ELECTROFISHING";
						break;
					case 29://ESA
						lblh1.Text = "ENVIRONMENTAL STREAM ASSESSMENT";
						break;
				}
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
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbdacdAgency = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdscdAgency = new NBADWDataEntryApplication.dscdAgency();
			this.oleDbdaqryElectrofishingDataPlusEstimates = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand20 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand20 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryElectrofishingDataPlusEstimates = new NBADWDataEntryApplication.dsqryElectrofishingDataPlusEstimates();
			this.dvqryElectrofishingDataPlusEstimates = new System.Data.DataView();
			this.oleDbdaqryElectrofishingMethodDetails = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryElectrofishingMethodDetails = new NBADWDataEntryApplication.dsqryElectrofishingMethodDetails();
			this.dvqryElectrofishingMethodDetails = new System.Data.DataView();
			this.oleDbdaqryElectrofishingSiteMeasurements = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryElectrofishingSiteMeasurements = new NBADWDataEntryApplication.dsqryElectrofishingSiteMeasurements();
			this.dvqryElectrofishingSiteMeasurements = new System.Data.DataView();
			this.oleDbdaqryElectrofishingSites = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand18 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand18 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryElectrofishingSites = new NBADWDataEntryApplication.dsqryElectrofishingSites();
			this.dvqryElectrofishingSites = new System.Data.DataView();
			this.oleDbdaqryElectrofishingWaterMeasurements = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryElectrofishingWaterMeasurements = new NBADWDataEntryApplication.dsqryElectrofishingWaterMeasurements();
			this.dvqryElectrofishingWaterMeasurements = new System.Data.DataView();
			this.oleDbdaqryESAObservations = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryESAObservations = new NBADWDataEntryApplication.dsqryESAObservations();
			this.dvqryESAObservations = new System.Data.DataView();
			this.oleDbdaqryESAPlanning = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand8 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryESAPlanning = new NBADWDataEntryApplication.dsqryESAPlanning();
			this.dvqryESAPlanning = new System.Data.DataView();
			this.oleDbdaqryESASiteMeasurements = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand9 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand9 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryESASiteMeasurements = new NBADWDataEntryApplication.dsqryESASiteMeasurements();
			this.dvqryESASiteMeasurements = new System.Data.DataView();
			this.oleDbdaqryESASites = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand21 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand21 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand10 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand10 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryESASites = new NBADWDataEntryApplication.dsqryESASites();
			this.dvqryESASites = new System.Data.DataView();
			this.oleDbdaqryFishStocking = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand11 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand11 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryFishStocking = new NBADWDataEntryApplication.dsqryFishStocking();
			this.dvqryFishStocking = new System.Data.DataView();
			this.oleDbdaqryFishStockingSites = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand19 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand19 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand12 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand12 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryFishStockingSites = new NBADWDataEntryApplication.dsqryFishStockingSites();
			this.dvqryFishStockingSites = new System.Data.DataView();
			this.oleDbdaqryWaterTemperatureLoggerDetails = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand13 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand13 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryWaterTemperatureLoggerDetails = new NBADWDataEntryApplication.dsqryWaterTemperatureLoggerDetails();
			this.dvqryWaterTemperatureLoggerDetails = new System.Data.DataView();
			this.oleDbdaqryWaterTemperatureLoggerMeasurements = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand14 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand14 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryWaterTemperatureLoggerMeasurements = new NBADWDataEntryApplication.dsqryWaterTemperatureLoggerMeasurements();
			this.dvqryWaterTemperatureLoggerMeasurements = new System.Data.DataView();
			this.oleDbdaqryWaterTemperatureLoggerSites = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand22 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand22 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand15 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand15 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryWaterTemperatureLoggerSites = new NBADWDataEntryApplication.dsqryWaterTemperatureLoggerSites();
			this.dvqryWaterTemperatureLoggerSites = new System.Data.DataView();
			this.oleDbdaqryElectrofishingMarkRecaptureDataPlusEstimates = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand17 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand17 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand16 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand16 = new System.Data.OleDb.OleDbCommand();
			this.objdsqryElectrofishingMarkRecaptureDataPlusEstimates = new NBADWDataEntryApplication.dsqryElectrofishingMarkRecaptureDataPlusEstimates();
			this.dvqryElectrofishingMarkRecaptureDataPlusEstimates = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingDataPlusEstimates)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingDataPlusEstimates)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingMethodDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingMethodDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingSiteMeasurements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingSiteMeasurements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingWaterMeasurements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingWaterMeasurements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryESAObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryESAObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryESAPlanning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryESAPlanning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryESASiteMeasurements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryESASiteMeasurements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryESASites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryESASites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryFishStocking)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryFishStocking)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryFishStockingSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryFishStockingSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryWaterTemperatureLoggerDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryWaterTemperatureLoggerDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryWaterTemperatureLoggerMeasurements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryWaterTemperatureLoggerMeasurements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryWaterTemperatureLoggerSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryWaterTemperatureLoggerSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingMarkRecaptureDataPlusEstimates)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingMarkRecaptureDataPlusEstimates)).BeginInit();
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Registry Path=;Data Source=""C:\Data_Warehouse\Tabular_Data\DE-HRAA.mdb"";Jet OLEDB:System database=;Jet OLEDB:Global Bulk Transactions=1;User ID=Admin;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:SFP=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Engine Type=5;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Global Partial Bulk Ops=2;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Create System Database=False;Jet OLEDB:Database Locking Mode=1";
			// 
			// oleDbdacdAgency
			// 
			this.oleDbdacdAgency.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbdacdAgency.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdacdAgency.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdacdAgency.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cdAgency", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("Agency", "Agency"),
																																																				  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																				  new System.Data.Common.DataColumnMapping("DataRulesInd", "DataRulesInd")})});
			this.oleDbdacdAgency.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM cdAgency WHERE (AgencyCd = ?) AND (Agency = ? OR ? IS NULL AND Agency" +
				" IS NULL) AND (DataRulesInd = ? OR ? IS NULL AND DataRulesInd IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataRulesInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataRulesInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataRulesInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataRulesInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO cdAgency(Agency, AgencyCd, DataRulesInd) VALUES (?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataRulesInd", System.Data.OleDb.OleDbType.VarWChar, 1, "DataRulesInd"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT Agency, AgencyCd, DataRulesInd FROM cdAgency";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE cdAgency SET Agency = ?, AgencyCd = ?, DataRulesInd = ? WHERE (AgencyCd = " +
				"?) AND (Agency = ? OR ? IS NULL AND Agency IS NULL) AND (DataRulesInd = ? OR ? I" +
				"S NULL AND DataRulesInd IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataRulesInd", System.Data.OleDb.OleDbType.VarWChar, 1, "DataRulesInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataRulesInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataRulesInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataRulesInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataRulesInd", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdAgency
			// 
			this.objdscdAgency.DataSetName = "dscdAgency";
			this.objdscdAgency.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaqryElectrofishingDataPlusEstimates
			// 
			this.oleDbdaqryElectrofishingDataPlusEstimates.InsertCommand = this.oleDbInsertCommand20;
			this.oleDbdaqryElectrofishingDataPlusEstimates.SelectCommand = this.oleDbSelectCommand20;
			this.oleDbdaqryElectrofishingDataPlusEstimates.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																new System.Data.Common.DataTableMapping("Table", "qryElectrofishingDataPlusEstimates", new System.Data.Common.DataColumnMapping[] {
																																																																	  new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																																	  new System.Data.Common.DataColumnMapping("Agency2Contact", "Agency2Contact"),
																																																																	  new System.Data.Common.DataColumnMapping("Agency2SiteID", "Agency2SiteID"),
																																																																	  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																																	  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																																	  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																																	  new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																																	  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																																	  new System.Data.Common.DataColumnMapping("Area_m2", "Area_m2"),
																																																																	  new System.Data.Common.DataColumnMapping("AutoCalculatedInd", "AutoCalculatedInd"),
																																																																	  new System.Data.Common.DataColumnMapping("AveForkLength_cm", "AveForkLength_cm"),
																																																																	  new System.Data.Common.DataColumnMapping("AveTotalLength_cm", "AveTotalLength_cm"),
																																																																	  new System.Data.Common.DataColumnMapping("AveWeight_gm", "AveWeight_gm"),
																																																																	  new System.Data.Common.DataColumnMapping("Biomass", "Biomass"),
																																																																	  new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																																	  new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																																	  new System.Data.Common.DataColumnMapping("Density", "Density"),
																																																																	  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																																	  new System.Data.Common.DataColumnMapping("EFDataID", "EFDataID"),
																																																																	  new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																																	  new System.Data.Common.DataColumnMapping("FishSpecies", "FishSpecies"),
																																																																	  new System.Data.Common.DataColumnMapping("FishSpeciesCd", "FishSpeciesCd"),
																																																																	  new System.Data.Common.DataColumnMapping("Formula", "Formula"),
																																																																	  new System.Data.Common.DataColumnMapping("HabitatDesc", "HabitatDesc"),
																																																																	  new System.Data.Common.DataColumnMapping("Method", "Method"),
																																																																	  new System.Data.Common.DataColumnMapping("NoSweeps", "NoSweeps"),
																																																																	  new System.Data.Common.DataColumnMapping("PercentClipped", "PercentClipped"),
																																																																	  new System.Data.Common.DataColumnMapping("PermitNo", "PermitNo"),
																																																																	  new System.Data.Common.DataColumnMapping("PHS", "PHS"),
																																																																	  new System.Data.Common.DataColumnMapping("RelativeSizeClass", "RelativeSizeClass"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep1NoFish", "Sweep1NoFish"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep1Time_s", "Sweep1Time_s"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep2NoFish", "Sweep2NoFish"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep2Time_s", "Sweep2Time_s"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep3NoFish", "Sweep3NoFish"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep3Time_s", "Sweep3Time_s"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep4NoFish", "Sweep4NoFish"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep4Time_s", "Sweep4Time_s"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep5NoFish", "Sweep5NoFish"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep5Time_s", "Sweep5Time_s"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep6NoFish", "Sweep6NoFish"),
																																																																	  new System.Data.Common.DataColumnMapping("Sweep6Time_s", "Sweep6Time_s"),
																																																																	  new System.Data.Common.DataColumnMapping("TotalNoFish", "TotalNoFish"),
																																																																	  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																																	  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName")})});
			// 
			// oleDbInsertCommand20
			// 
			this.oleDbInsertCommand20.CommandText = @"INSERT INTO qryElectrofishingDataPlusEstimates(Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteDesc, AquaticSiteID, Area_m2, AutoCalculatedInd, AveForkLength_cm, AveTotalLength_cm, AveWeight_gm, Biomass, Comments, [Date], Density, DrainageCd, FishAgeClass, FishSpecies, FishSpeciesCd, Formula, HabitatDesc, Method, NoSweeps, PercentClipped, PermitNo, PHS, RelativeSizeClass, Sweep1NoFish, Sweep1Time_s, Sweep2NoFish, Sweep2Time_s, Sweep3NoFish, Sweep3Time_s, Sweep4NoFish, Sweep4Time_s, Sweep5NoFish, Sweep5Time_s, Sweep6NoFish, Sweep6Time_s, TotalNoFish, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand20.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarWChar, 50, "Agency2Contact"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2SiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "Agency2SiteID"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Area_m2", System.Data.OleDb.OleDbType.Single, 0, "Area_m2"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AutoCalculatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "AutoCalculatedInd"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveForkLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveForkLength_cm"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveTotalLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveTotalLength_cm"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Biomass", System.Data.OleDb.OleDbType.Double, 0, "Biomass"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 100, "Comments"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Density", System.Data.OleDb.OleDbType.Double, 0, "Density"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, "FishAgeClass"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Formula", System.Data.OleDb.OleDbType.VarWChar, 50, "Formula"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Method", System.Data.OleDb.OleDbType.VarWChar, 30, "Method"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoSweeps", System.Data.OleDb.OleDbType.SmallInt, 0, "NoSweeps"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("PercentClipped", System.Data.OleDb.OleDbType.Double, 0, "PercentClipped"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermitNo", System.Data.OleDb.OleDbType.VarWChar, 20, "PermitNo"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("PHS", System.Data.OleDb.OleDbType.Double, 0, "PHS"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("RelativeSizeClass", System.Data.OleDb.OleDbType.VarWChar, 10, "RelativeSizeClass"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep1NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep1NoFish"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep1Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep1Time_s"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep2NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep2NoFish"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep2Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep2Time_s"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep3NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep3NoFish"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep3Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep3Time_s"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep4NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep4NoFish"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep4Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep4Time_s"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep5NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep5NoFish"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep5Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep5Time_s"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep6NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep6NoFish"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep6Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep6Time_s"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("TotalNoFish", System.Data.OleDb.OleDbType.Double, 0, "TotalNoFish"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand20
			// 
			this.oleDbSelectCommand20.CommandText = @"SELECT Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteDesc, AquaticSiteID, Area_m2, AutoCalculatedInd, AveForkLength_cm, AveTotalLength_cm, AveWeight_gm, Biomass, Comments, [Date], Density, DrainageCd, EFDataID, FishAgeClass, FishSpecies, FishSpeciesCd, Formula, HabitatDesc, Method, NoSweeps, PercentClipped, PermitNo, PHS, RelativeSizeClass, Sweep1NoFish, Sweep1Time_s, Sweep2NoFish, Sweep2Time_s, Sweep3NoFish, Sweep3Time_s, Sweep4NoFish, Sweep4Time_s, Sweep5NoFish, Sweep5Time_s, Sweep6NoFish, Sweep6Time_s, TotalNoFish, WaterBodyID, WaterBodyName FROM qryElectrofishingDataPlusEstimates";
			this.oleDbSelectCommand20.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO qryElectrofishingDataPlusEstimates(Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteDesc, AquaticSiteID, Area_m2, AutoCalculatedInd, AveForkLength_cm, AveTotalLength_cm, AveWeight_gm, Biomass, Comments, CPUE, [Date], Density, DrainageCd, FishAgeClass, FishSpecies, FishSpeciesCd, Formula, HabitatDesc, Method, NoSweeps, PercentClipped, PermitNo, PHS, RelativeSizeClass, Sweep1NoFish, Sweep1Time_s, Sweep2NoFish, Sweep2Time_s, Sweep3NoFish, Sweep3Time_s, Sweep4NoFish, Sweep4Time_s, Sweep5NoFish, Sweep5Time_s, Sweep6NoFish, Sweep6Time_s, TotalNoFish, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarWChar, 50, "Agency2Contact"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2SiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "Agency2SiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Area_m2", System.Data.OleDb.OleDbType.Single, 0, "Area_m2"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AutoCalculatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "AutoCalculatedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveForkLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveForkLength_cm"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveTotalLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveTotalLength_cm"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Biomass", System.Data.OleDb.OleDbType.Double, 0, "Biomass"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 100, "Comments"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CPUE", System.Data.OleDb.OleDbType.Double, 0, "CPUE"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Density", System.Data.OleDb.OleDbType.Double, 0, "Density"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, "FishAgeClass"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Formula", System.Data.OleDb.OleDbType.VarWChar, 50, "Formula"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Method", System.Data.OleDb.OleDbType.VarWChar, 30, "Method"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoSweeps", System.Data.OleDb.OleDbType.SmallInt, 0, "NoSweeps"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PercentClipped", System.Data.OleDb.OleDbType.Double, 0, "PercentClipped"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermitNo", System.Data.OleDb.OleDbType.VarWChar, 20, "PermitNo"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PHS", System.Data.OleDb.OleDbType.Double, 0, "PHS"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RelativeSizeClass", System.Data.OleDb.OleDbType.VarWChar, 10, "RelativeSizeClass"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep1NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep1NoFish"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep1Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep1Time_s"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep2NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep2NoFish"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep2Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep2Time_s"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep3NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep3NoFish"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep3Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep3Time_s"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep4NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep4NoFish"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep4Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep4Time_s"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep5NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep5NoFish"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep5Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep5Time_s"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep6NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep6NoFish"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep6Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep6Time_s"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TotalNoFish", System.Data.OleDb.OleDbType.Double, 0, "TotalNoFish"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteDesc, AquaticSiteID, Area_m2, AutoCalculatedInd, AveForkLength_cm, AveTotalLength_cm, AveWeight_gm, Biomass, Comments, CPUE, [Date], Density, DrainageCd, EFDataID, FishAgeClass, FishSpecies, FishSpeciesCd, Formula, HabitatDesc, Method, NoSweeps, PercentClipped, PermitNo, PHS, RelativeSizeClass, Sweep1NoFish, Sweep1Time_s, Sweep2NoFish, Sweep2Time_s, Sweep3NoFish, Sweep3Time_s, Sweep4NoFish, Sweep4Time_s, Sweep5NoFish, Sweep5Time_s, Sweep6NoFish, Sweep6Time_s, TotalNoFish, WaterBodyID, WaterBodyName FROM qryElectrofishingDataPlusEstimates";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// objdsqryElectrofishingDataPlusEstimates
			// 
			this.objdsqryElectrofishingDataPlusEstimates.DataSetName = "dsqryElectrofishingDataPlusEstimates";
			this.objdsqryElectrofishingDataPlusEstimates.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryElectrofishingDataPlusEstimates
			// 
			this.dvqryElectrofishingDataPlusEstimates.Table = this.objdsqryElectrofishingDataPlusEstimates.qryElectrofishingDataPlusEstimates;
			// 
			// oleDbdaqryElectrofishingMethodDetails
			// 
			this.oleDbdaqryElectrofishingMethodDetails.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdaqryElectrofishingMethodDetails.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdaqryElectrofishingMethodDetails.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															new System.Data.Common.DataTableMapping("Table", "qryElectrofishingMethodDetails", new System.Data.Common.DataColumnMapping[] {
																																																															  new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																															  new System.Data.Common.DataColumnMapping("Agency2Contact", "Agency2Contact"),
																																																															  new System.Data.Common.DataColumnMapping("Agency2SiteID", "Agency2SiteID"),
																																																															  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																															  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																															  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																															  new System.Data.Common.DataColumnMapping("AquaticMethod", "AquaticMethod"),
																																																															  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																															  new System.Data.Common.DataColumnMapping("Area_m2", "Area_m2"),
																																																															  new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																															  new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																															  new System.Data.Common.DataColumnMapping("Device", "Device"),
																																																															  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																															  new System.Data.Common.DataColumnMapping("DutyCycle", "DutyCycle"),
																																																															  new System.Data.Common.DataColumnMapping("Frequency_Hz", "Frequency_Hz"),
																																																															  new System.Data.Common.DataColumnMapping("HabitatDesc", "HabitatDesc"),
																																																															  new System.Data.Common.DataColumnMapping("NoSweeps", "NoSweeps"),
																																																															  new System.Data.Common.DataColumnMapping("POWSetting", "POWSetting"),
																																																															  new System.Data.Common.DataColumnMapping("SiteSetup", "SiteSetup"),
																																																															  new System.Data.Common.DataColumnMapping("StreamLength_m", "StreamLength_m"),
																																																															  new System.Data.Common.DataColumnMapping("Time", "Time"),
																																																															  new System.Data.Common.DataColumnMapping("Voltage", "Voltage"),
																																																															  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																															  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName")})});
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = @"INSERT INTO qryElectrofishingMethodDetails(Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticMethod, AquaticSiteID, Area_m2, Comments, [Date], Device, DrainageCd, DutyCycle, Frequency_Hz, HabitatDesc, NoSweeps, POWSetting, SiteSetup, StreamLength_m, [Time], Voltage, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarWChar, 50, "Agency2Contact"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2SiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "Agency2SiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethod", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticMethod"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Area_m2", System.Data.OleDb.OleDbType.Single, 0, "Area_m2"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Device", System.Data.OleDb.OleDbType.VarWChar, 15, "Device"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DutyCycle", System.Data.OleDb.OleDbType.Double, 0, "DutyCycle"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Frequency_Hz", System.Data.OleDb.OleDbType.Double, 0, "Frequency_Hz"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoSweeps", System.Data.OleDb.OleDbType.SmallInt, 0, "NoSweeps"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("POWSetting", System.Data.OleDb.OleDbType.Double, 0, "POWSetting"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("SiteSetup", System.Data.OleDb.OleDbType.VarWChar, 6, "SiteSetup"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamLength_m", System.Data.OleDb.OleDbType.Single, 0, "StreamLength_m"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Time", System.Data.OleDb.OleDbType.VarWChar, 6, "Time"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Voltage", System.Data.OleDb.OleDbType.Double, 0, "Voltage"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticMethod, AquaticSiteID, Area_m2, Comments, [Date], Device, DrainageCd, DutyCycle, Frequency_Hz, HabitatDesc, NoSweeps, POWSetting, SiteSetup, StreamLength_m, [Time], Voltage, WaterBodyID, WaterBodyName FROM qryElectrofishingMethodDetails";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// objdsqryElectrofishingMethodDetails
			// 
			this.objdsqryElectrofishingMethodDetails.DataSetName = "dsqryElectrofishingMethodDetails";
			this.objdsqryElectrofishingMethodDetails.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryElectrofishingMethodDetails
			// 
			this.dvqryElectrofishingMethodDetails.Table = this.objdsqryElectrofishingMethodDetails.qryElectrofishingMethodDetails;
			// 
			// oleDbdaqryElectrofishingSiteMeasurements
			// 
			this.oleDbdaqryElectrofishingSiteMeasurements.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdaqryElectrofishingSiteMeasurements.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdaqryElectrofishingSiteMeasurements.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															   new System.Data.Common.DataTableMapping("Table", "qryElectrofishingSiteMeasurements", new System.Data.Common.DataColumnMapping[] {
																																																																	new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																																	new System.Data.Common.DataColumnMapping("Agency2Contact", "Agency2Contact"),
																																																																	new System.Data.Common.DataColumnMapping("Agency2SiteID", "Agency2SiteID"),
																																																																	new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																																	new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																																	new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																																	new System.Data.Common.DataColumnMapping("AquaticMethod", "AquaticMethod"),
																																																																	new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																																	new System.Data.Common.DataColumnMapping("Bank", "Bank"),
																																																																	new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																																	new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																																	new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																																	new System.Data.Common.DataColumnMapping("Instrument", "Instrument"),
																																																																	new System.Data.Common.DataColumnMapping("Measure", "Measure"),
																																																																	new System.Data.Common.DataColumnMapping("Measurement", "Measurement"),
																																																																	new System.Data.Common.DataColumnMapping("OtherMeasure", "OtherMeasure"),
																																																																	new System.Data.Common.DataColumnMapping("SiteMeasurementID", "SiteMeasurementID"),
																																																																	new System.Data.Common.DataColumnMapping("Time", "Time"),
																																																																	new System.Data.Common.DataColumnMapping("UnitOfMeasure", "UnitOfMeasure"),
																																																																	new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																																	new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName")})});
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = @"INSERT INTO qryElectrofishingSiteMeasurements(Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticMethod, AquaticSiteID, Bank, Comments, [Date], DrainageCd, Instrument, Measure, Measurement, OtherMeasure, [Time], UnitOfMeasure, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarWChar, 50, "Agency2Contact"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2SiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "Agency2SiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethod", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticMethod"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Bank", System.Data.OleDb.OleDbType.VarWChar, 10, "Bank"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Instrument", System.Data.OleDb.OleDbType.VarWChar, 50, "Instrument"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Measure", System.Data.OleDb.OleDbType.VarWChar, 50, "Measure"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Measurement", System.Data.OleDb.OleDbType.Double, 0, "Measurement"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherMeasure", System.Data.OleDb.OleDbType.VarWChar, 20, "OtherMeasure"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Time", System.Data.OleDb.OleDbType.VarWChar, 6, "Time"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitOfMeasure", System.Data.OleDb.OleDbType.VarWChar, 10, "UnitOfMeasure"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = @"SELECT Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticMethod, AquaticSiteID, Bank, Comments, [Date], DrainageCd, Instrument, Measure, Measurement, OtherMeasure, SiteMeasurementID, [Time], UnitOfMeasure, WaterBodyID, WaterBodyName FROM qryElectrofishingSiteMeasurements";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// objdsqryElectrofishingSiteMeasurements
			// 
			this.objdsqryElectrofishingSiteMeasurements.DataSetName = "dsqryElectrofishingSiteMeasurements";
			this.objdsqryElectrofishingSiteMeasurements.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryElectrofishingSiteMeasurements
			// 
			this.dvqryElectrofishingSiteMeasurements.Table = this.objdsqryElectrofishingSiteMeasurements.qryElectrofishingSiteMeasurements;
			// 
			// oleDbdaqryElectrofishingSites
			// 
			this.oleDbdaqryElectrofishingSites.InsertCommand = this.oleDbInsertCommand18;
			this.oleDbdaqryElectrofishingSites.SelectCommand = this.oleDbSelectCommand18;
			this.oleDbdaqryElectrofishingSites.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "qryElectrofishingSites", new System.Data.Common.DataColumnMapping[] {
																																																											  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																											  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																											  new System.Data.Common.DataColumnMapping("CoordinateSource", "CoordinateSource"),
																																																											  new System.Data.Common.DataColumnMapping("CoordinateSystem", "CoordinateSystem"),
																																																											  new System.Data.Common.DataColumnMapping("CoordinateUnits", "CoordinateUnits"),
																																																											  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																											  new System.Data.Common.DataColumnMapping("HabitatDesc", "HabitatDesc"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																											  new System.Data.Common.DataColumnMapping("XCoordinate", "XCoordinate"),
																																																											  new System.Data.Common.DataColumnMapping("YCoordinate", "YCoordinate"),
																																																											  new System.Data.Common.DataColumnMapping("DataBegins", "DataBegins"),
																																																											  new System.Data.Common.DataColumnMapping("DataEnds", "DataEnds")})});
			// 
			// oleDbInsertCommand18
			// 
			this.oleDbInsertCommand18.CommandText = @"INSERT INTO qryElectrofishingSites(AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, HabitatDesc, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, DataBegins, DataEnds) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand18.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataBegins", System.Data.OleDb.OleDbType.VarChar, 255, "DataBegins"));
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataEnds", System.Data.OleDb.OleDbType.VarChar, 255, "DataEnds"));
			// 
			// oleDbSelectCommand18
			// 
			this.oleDbSelectCommand18.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, " +
				"CoordinateSystem, CoordinateUnits, DrainageCd, HabitatDesc, WaterBodyID, WaterBo" +
				"dyName, XCoordinate, YCoordinate, DataBegins, DataEnds FROM qryElectrofishingSit" +
				"es";
			this.oleDbSelectCommand18.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = @"INSERT INTO qryElectrofishingSites(AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, EndYear, HabitatDesc, StartYear, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, " +
				"CoordinateSystem, CoordinateUnits, DrainageCd, EndYear, HabitatDesc, StartYear, " +
				"WaterBodyID, WaterBodyName, XCoordinate, YCoordinate FROM qryElectrofishingSites" +
				"";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// objdsqryElectrofishingSites
			// 
			this.objdsqryElectrofishingSites.DataSetName = "dsqryElectrofishingSites";
			this.objdsqryElectrofishingSites.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryElectrofishingSites
			// 
			this.dvqryElectrofishingSites.Table = this.objdsqryElectrofishingSites.qryElectrofishingSites;
			// 
			// oleDbdaqryElectrofishingWaterMeasurements
			// 
			this.oleDbdaqryElectrofishingWaterMeasurements.InsertCommand = this.oleDbInsertCommand6;
			this.oleDbdaqryElectrofishingWaterMeasurements.SelectCommand = this.oleDbSelectCommand6;
			this.oleDbdaqryElectrofishingWaterMeasurements.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																new System.Data.Common.DataTableMapping("Table", "qryElectrofishingWaterMeasurements", new System.Data.Common.DataColumnMapping[] {
																																																																	  new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																																	  new System.Data.Common.DataColumnMapping("Agency2Contact", "Agency2Contact"),
																																																																	  new System.Data.Common.DataColumnMapping("Agency2SiteID", "Agency2SiteID"),
																																																																	  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																																	  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																																	  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																																	  new System.Data.Common.DataColumnMapping("AquaticMethod", "AquaticMethod"),
																																																																	  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																																	  new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																																	  new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																																	  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																																	  new System.Data.Common.DataColumnMapping("Instrument", "Instrument"),
																																																																	  new System.Data.Common.DataColumnMapping("Measure", "Measure"),
																																																																	  new System.Data.Common.DataColumnMapping("TimeofDay", "TimeofDay"),
																																																																	  new System.Data.Common.DataColumnMapping("UnitOfMeasure", "UnitOfMeasure"),
																																																																	  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																																	  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																																	  new System.Data.Common.DataColumnMapping("WaterMeasurementID", "WaterMeasurementID")})});
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = @"INSERT INTO qryElectrofishingWaterMeasurements(Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticMethod, AquaticSiteID, Comments, [Date], DrainageCd, Instrument, Measure, TimeofDay, UnitOfMeasure, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarWChar, 50, "Agency2Contact"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2SiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "Agency2SiteID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethod", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticMethod"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Instrument", System.Data.OleDb.OleDbType.VarWChar, 50, "Instrument"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Measure", System.Data.OleDb.OleDbType.VarWChar, 50, "Measure"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "TimeofDay"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitOfMeasure", System.Data.OleDb.OleDbType.VarWChar, 10, "UnitOfMeasure"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = @"SELECT Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticMethod, AquaticSiteID, Comments, [Date], DrainageCd, Instrument, Measure, TimeofDay, UnitOfMeasure, WaterBodyID, WaterBodyName, WaterMeasurementID FROM qryElectrofishingWaterMeasurements";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			// 
			// objdsqryElectrofishingWaterMeasurements
			// 
			this.objdsqryElectrofishingWaterMeasurements.DataSetName = "dsqryElectrofishingWaterMeasurements";
			this.objdsqryElectrofishingWaterMeasurements.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryElectrofishingWaterMeasurements
			// 
			this.dvqryElectrofishingWaterMeasurements.Table = this.objdsqryElectrofishingWaterMeasurements.qryElectrofishingWaterMeasurements;
			// 
			// oleDbdaqryESAObservations
			// 
			this.oleDbdaqryESAObservations.InsertCommand = this.oleDbInsertCommand7;
			this.oleDbdaqryESAObservations.SelectCommand = this.oleDbSelectCommand7;
			this.oleDbdaqryESAObservations.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "qryESAObservations", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																									  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																									  new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																									  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																									  new System.Data.Common.DataColumnMapping("EnvObservationID", "EnvObservationID"),
																																																									  new System.Data.Common.DataColumnMapping("FishPassageObstructionInd", "FishPassageObstructionInd"),
																																																									  new System.Data.Common.DataColumnMapping("Observation", "Observation"),
																																																									  new System.Data.Common.DataColumnMapping("ObservationGroup", "ObservationGroup"),
																																																									  new System.Data.Common.DataColumnMapping("OtherObservation", "OtherObservation"),
																																																									  new System.Data.Common.DataColumnMapping("PipeSize_cm", "PipeSize_cm"),
																																																									  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																									  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName")})});
			// 
			// oleDbInsertCommand7
			// 
			this.oleDbInsertCommand7.CommandText = @"INSERT INTO qryESAObservations(AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, [Date], DrainageCd, FishPassageObstructionInd, Observation, ObservationGroup, OtherObservation, PipeSize_cm, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand7.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishPassageObstructionInd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Observation", System.Data.OleDb.OleDbType.VarWChar, 50, "Observation"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationGroup"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherObservation", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherObservation"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, "PipeSize_cm"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand7
			// 
			this.oleDbSelectCommand7.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, [Date], Drainage" +
				"Cd, EnvObservationID, FishPassageObstructionInd, Observation, ObservationGroup, " +
				"OtherObservation, PipeSize_cm, WaterBodyID, WaterBodyName FROM qryESAObservation" +
				"s";
			this.oleDbSelectCommand7.Connection = this.oleDbConnection1;
			// 
			// objdsqryESAObservations
			// 
			this.objdsqryESAObservations.DataSetName = "dsqryESAObservations";
			this.objdsqryESAObservations.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryESAObservations
			// 
			this.dvqryESAObservations.Table = this.objdsqryESAObservations.qryESAObservations;
			// 
			// oleDbdaqryESAPlanning
			// 
			this.oleDbdaqryESAPlanning.InsertCommand = this.oleDbInsertCommand8;
			this.oleDbdaqryESAPlanning.SelectCommand = this.oleDbSelectCommand8;
			this.oleDbdaqryESAPlanning.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "qryESAPlanning", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("ActionCompletionDate", "ActionCompletionDate"),
																																																							  new System.Data.Common.DataColumnMapping("ActionPriority", "ActionPriority"),
																																																							  new System.Data.Common.DataColumnMapping("ActionRequired", "ActionRequired"),
																																																							  new System.Data.Common.DataColumnMapping("ActionTargetDate", "ActionTargetDate"),
																																																							  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																							  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																							  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																							  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																							  new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																							  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																							  new System.Data.Common.DataColumnMapping("EnvPlanningID", "EnvPlanningID"),
																																																							  new System.Data.Common.DataColumnMapping("FollowUpCompletionDate", "FollowUpCompletionDate"),
																																																							  new System.Data.Common.DataColumnMapping("FollowUpRequired", "FollowUpRequired"),
																																																							  new System.Data.Common.DataColumnMapping("FollowUpTargetDate", "FollowUpTargetDate"),
																																																							  new System.Data.Common.DataColumnMapping("Issue", "Issue"),
																																																							  new System.Data.Common.DataColumnMapping("IssueCategory", "IssueCategory"),
																																																							  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																							  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName")})});
			// 
			// oleDbInsertCommand8
			// 
			this.oleDbInsertCommand8.CommandText = @"INSERT INTO qryESAPlanning(ActionCompletionDate, ActionPriority, ActionRequired, ActionTargetDate, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, [Date], DrainageCd, FollowUpCompletionDate, FollowUpRequired, FollowUpTargetDate, Issue, IssueCategory, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand8.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionCompletionDate"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, "ActionPriority"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, "ActionRequired"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionTargetDate"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpCompletionDate"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, "FollowUpRequired"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpTargetDate"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Issue", System.Data.OleDb.OleDbType.VarWChar, 250, "Issue"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, "IssueCategory"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand8
			// 
			this.oleDbSelectCommand8.CommandText = @"SELECT ActionCompletionDate, ActionPriority, ActionRequired, ActionTargetDate, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, [Date], DrainageCd, EnvPlanningID, FollowUpCompletionDate, FollowUpRequired, FollowUpTargetDate, Issue, IssueCategory, WaterBodyID, WaterBodyName FROM qryESAPlanning";
			this.oleDbSelectCommand8.Connection = this.oleDbConnection1;
			// 
			// objdsqryESAPlanning
			// 
			this.objdsqryESAPlanning.DataSetName = "dsqryESAPlanning";
			this.objdsqryESAPlanning.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryESAPlanning
			// 
			this.dvqryESAPlanning.Table = this.objdsqryESAPlanning.qryESAPlanning;
			// 
			// oleDbdaqryESASiteMeasurements
			// 
			this.oleDbdaqryESASiteMeasurements.InsertCommand = this.oleDbInsertCommand9;
			this.oleDbdaqryESASiteMeasurements.SelectCommand = this.oleDbSelectCommand9;
			this.oleDbdaqryESASiteMeasurements.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "qryESASiteMeasurements", new System.Data.Common.DataColumnMapping[] {
																																																											  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																											  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																											  new System.Data.Common.DataColumnMapping("Algae", "Algae"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticPlants", "AquaticPlants"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																											  new System.Data.Common.DataColumnMapping("AveDepth_m", "AveDepth_m"),
																																																											  new System.Data.Common.DataColumnMapping("AveWidth_m", "AveWidth_m"),
																																																											  new System.Data.Common.DataColumnMapping("BankSlope_Lt", "BankSlope_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("BankSlope_Rt", "BankSlope_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("BankStability", "BankStability"),
																																																											  new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																											  new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																											  new System.Data.Common.DataColumnMapping("DeadFish", "DeadFish"),
																																																											  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																											  new System.Data.Common.DataColumnMapping("EmbeddedSub", "EmbeddedSub"),
																																																											  new System.Data.Common.DataColumnMapping("FieldMeasureID", "FieldMeasureID"),
																																																											  new System.Data.Common.DataColumnMapping("Foam", "Foam"),
																																																											  new System.Data.Common.DataColumnMapping("GW1_AirTemp_C", "GW1_AirTemp_C"),
																																																											  new System.Data.Common.DataColumnMapping("GW1_Conductivity", "GW1_Conductivity"),
																																																											  new System.Data.Common.DataColumnMapping("GW1_DELGFieldNo", "GW1_DELGFieldNo"),
																																																											  new System.Data.Common.DataColumnMapping("GW1_DissOxygen", "GW1_DissOxygen"),
																																																											  new System.Data.Common.DataColumnMapping("GW1_Flow_cms", "GW1_Flow_cms"),
																																																											  new System.Data.Common.DataColumnMapping("GW1_pH", "GW1_pH"),
																																																											  new System.Data.Common.DataColumnMapping("GW1_TimeofDay", "GW1_TimeofDay"),
																																																											  new System.Data.Common.DataColumnMapping("GW1_WaterTemp_C", "GW1_WaterTemp_C"),
																																																											  new System.Data.Common.DataColumnMapping("GW2_AirTemp_C", "GW2_AirTemp_C"),
																																																											  new System.Data.Common.DataColumnMapping("GW2_Conductivity", "GW2_Conductivity"),
																																																											  new System.Data.Common.DataColumnMapping("GW2_DELGFieldNo", "GW2_DELGFieldNo"),
																																																											  new System.Data.Common.DataColumnMapping("GW2_DissOxygen", "GW2_DissOxygen"),
																																																											  new System.Data.Common.DataColumnMapping("GW2_Flow_cms", "GW2_Flow_cms"),
																																																											  new System.Data.Common.DataColumnMapping("GW2_pH", "GW2_pH"),
																																																											  new System.Data.Common.DataColumnMapping("GW2_TimeofDay", "GW2_TimeofDay"),
																																																											  new System.Data.Common.DataColumnMapping("GW2_WaterTemp_C", "GW2_WaterTemp_C"),
																																																											  new System.Data.Common.DataColumnMapping("Length_m", "Length_m"),
																																																											  new System.Data.Common.DataColumnMapping("Odor", "Odor"),
																																																											  new System.Data.Common.DataColumnMapping("Other", "Other"),
																																																											  new System.Data.Common.DataColumnMapping("OtherStreamType", "OtherStreamType"),
																																																											  new System.Data.Common.DataColumnMapping("OtherSupp", "OtherSupp"),
																																																											  new System.Data.Common.DataColumnMapping("Petroleum", "Petroleum"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Altered_Lt", "RZ_Altered_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Altered_Rt", "RZ_Altered_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_ForageCrop_Lt", "RZ_ForageCrop_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_ForageCrop_Rt", "RZ_ForageCrop_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Hardwood_Lt", "RZ_Hardwood_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Hardwood_Rt", "RZ_Hardwood_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Lawn_Lt", "RZ_Lawn_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Lawn_Rt", "RZ_Lawn_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Meadow_Lt", "RZ_Meadow_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Meadow_Rt", "RZ_Meadow_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Mixed_Lt", "RZ_Mixed_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Mixed_Rt", "RZ_Mixed_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_RowCrop_Lt", "RZ_RowCrop_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_RowCrop_Rt", "RZ_RowCrop_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Shrubs_Lt", "RZ_Shrubs_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Shrubs_Rt", "RZ_Shrubs_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Softwood_Lt", "RZ_Softwood_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Softwood_Rt", "RZ_Softwood_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Wetland_Lt", "RZ_Wetland_Lt"),
																																																											  new System.Data.Common.DataColumnMapping("RZ_Wetland_Rt", "RZ_Wetland_Rt"),
																																																											  new System.Data.Common.DataColumnMapping("ST_AirTemp_C", "ST_AirTemp_C"),
																																																											  new System.Data.Common.DataColumnMapping("ST_Conductivity", "ST_Conductivity"),
																																																											  new System.Data.Common.DataColumnMapping("ST_DELGFieldNo", "ST_DELGFieldNo"),
																																																											  new System.Data.Common.DataColumnMapping("ST_DissOxygen", "ST_DissOxygen"),
																																																											  new System.Data.Common.DataColumnMapping("ST_Flow_cms", "ST_Flow_cms"),
																																																											  new System.Data.Common.DataColumnMapping("ST_pH", "ST_pH"),
																																																											  new System.Data.Common.DataColumnMapping("ST_TimeofDay", "ST_TimeofDay"),
																																																											  new System.Data.Common.DataColumnMapping("ST_WaterTemp_C", "ST_WaterTemp_C"),
																																																											  new System.Data.Common.DataColumnMapping("StreamCover", "StreamCover"),
																																																											  new System.Data.Common.DataColumnMapping("StreamType", "StreamType"),
																																																											  new System.Data.Common.DataColumnMapping("SuspendedSilt", "SuspendedSilt"),
																																																											  new System.Data.Common.DataColumnMapping("Velocity_mpers", "Velocity_mpers"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																											  new System.Data.Common.DataColumnMapping("WaterClarity", "WaterClarity"),
																																																											  new System.Data.Common.DataColumnMapping("WaterColor", "WaterColor"),
																																																											  new System.Data.Common.DataColumnMapping("Weather_Current", "Weather_Current"),
																																																											  new System.Data.Common.DataColumnMapping("Weather_Past", "Weather_Past")})});
			// 
			// oleDbInsertCommand9
			// 
			this.oleDbInsertCommand9.CommandText = @"INSERT INTO qryESASiteMeasurements(AgencyCd, AgencySiteID, Algae, AquaticActivityID, AquaticPlants, AquaticSiteID, AveDepth_m, AveWidth_m, BankSlope_Lt, BankSlope_Rt, BankStability, Comments, [Date], DeadFish, DrainageCd, EmbeddedSub, Foam, GW1_AirTemp_C, GW1_Conductivity, GW1_DELGFieldNo, GW1_DissOxygen, GW1_Flow_cms, GW1_pH, GW1_TimeofDay, GW1_WaterTemp_C, GW2_AirTemp_C, GW2_Conductivity, GW2_DELGFieldNo, GW2_DissOxygen, GW2_Flow_cms, GW2_pH, GW2_TimeofDay, GW2_WaterTemp_C, Length_m, Odor, Other, OtherStreamType, OtherSupp, Petroleum, RZ_Altered_Lt, RZ_Altered_Rt, RZ_ForageCrop_Lt, RZ_ForageCrop_Rt, RZ_Hardwood_Lt, RZ_Hardwood_Rt, RZ_Lawn_Lt, RZ_Lawn_Rt, RZ_Meadow_Lt, RZ_Meadow_Rt, RZ_Mixed_Lt, RZ_Mixed_Rt, RZ_RowCrop_Lt, RZ_RowCrop_Rt, RZ_Shrubs_Lt, RZ_Shrubs_Rt, RZ_Softwood_Lt, RZ_Softwood_Rt, RZ_Wetland_Lt, RZ_Wetland_Rt, ST_AirTemp_C, ST_Conductivity, ST_DELGFieldNo, ST_DissOxygen, ST_Flow_cms, ST_pH, ST_TimeofDay, ST_WaterTemp_C, StreamCover, StreamType, SuspendedSilt, Velocity_mpers, WaterBodyID, WaterBodyName, WaterClarity, WaterColor, Weather_Current, Weather_Past) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand9.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Algae", System.Data.OleDb.OleDbType.Boolean, 2, "Algae"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, "AquaticPlants"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, "AveDepth_m"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, "AveWidth_m"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankStability", System.Data.OleDb.OleDbType.VarWChar, 20, "BankStability"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, "DeadFish"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, "EmbeddedSub"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Foam", System.Data.OleDb.OleDbType.Boolean, 2, "Foam"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_AirTemp_C"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW1_Conductivity"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW1_DELGFieldNo"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW1_DissOxygen"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW1_Flow_cms"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_pH", System.Data.OleDb.OleDbType.Single, 0, "GW1_pH"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW1_TimeofDay"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_WaterTemp_C"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_AirTemp_C"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW2_Conductivity"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW2_DELGFieldNo"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW2_DissOxygen"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW2_Flow_cms"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_pH", System.Data.OleDb.OleDbType.Single, 0, "GW2_pH"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW2_TimeofDay"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_WaterTemp_C"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Length_m", System.Data.OleDb.OleDbType.Single, 0, "Length_m"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Odor", System.Data.OleDb.OleDbType.Boolean, 2, "Odor"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Other", System.Data.OleDb.OleDbType.Boolean, 2, "Other"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherStreamType", System.Data.OleDb.OleDbType.VarWChar, 30, "OtherStreamType"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherSupp"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, "Petroleum"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Lawn_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, "RZ_Lawn_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Lt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Rt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_AirTemp_C"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "ST_Conductivity"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "ST_DELGFieldNo"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "ST_DissOxygen"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "ST_Flow_cms"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_pH", System.Data.OleDb.OleDbType.Single, 0, "ST_pH"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "ST_TimeofDay"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_WaterTemp_C"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamCover"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamType"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, "SuspendedSilt"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, "Velocity_mpers"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, "WaterClarity"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterColor"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Current"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Past"));
			// 
			// oleDbSelectCommand9
			// 
			this.oleDbSelectCommand9.CommandText = @"SELECT AgencyCd, AgencySiteID, Algae, AquaticActivityID, AquaticPlants, AquaticSiteID, AveDepth_m, AveWidth_m, BankSlope_Lt, BankSlope_Rt, BankStability, Comments, [Date], DeadFish, DrainageCd, EmbeddedSub, FieldMeasureID, Foam, GW1_AirTemp_C, GW1_Conductivity, GW1_DELGFieldNo, GW1_DissOxygen, GW1_Flow_cms, GW1_pH, GW1_TimeofDay, GW1_WaterTemp_C, GW2_AirTemp_C, GW2_Conductivity, GW2_DELGFieldNo, GW2_DissOxygen, GW2_Flow_cms, GW2_pH, GW2_TimeofDay, GW2_WaterTemp_C, Length_m, Odor, Other, OtherStreamType, OtherSupp, Petroleum, RZ_Altered_Lt, RZ_Altered_Rt, RZ_ForageCrop_Lt, RZ_ForageCrop_Rt, RZ_Hardwood_Lt, RZ_Hardwood_Rt, RZ_Lawn_Lt, RZ_Lawn_Rt, RZ_Meadow_Lt, RZ_Meadow_Rt, RZ_Mixed_Lt, RZ_Mixed_Rt, RZ_RowCrop_Lt, RZ_RowCrop_Rt, RZ_Shrubs_Lt, RZ_Shrubs_Rt, RZ_Softwood_Lt, RZ_Softwood_Rt, RZ_Wetland_Lt, RZ_Wetland_Rt, ST_AirTemp_C, ST_Conductivity, ST_DELGFieldNo, ST_DissOxygen, ST_Flow_cms, ST_pH, ST_TimeofDay, ST_WaterTemp_C, StreamCover, StreamType, SuspendedSilt, Velocity_mpers, WaterBodyID, WaterBodyName, WaterClarity, WaterColor, Weather_Current, Weather_Past FROM qryESASiteMeasurements";
			this.oleDbSelectCommand9.Connection = this.oleDbConnection1;
			// 
			// objdsqryESASiteMeasurements
			// 
			this.objdsqryESASiteMeasurements.DataSetName = "dsqryESASiteMeasurements";
			this.objdsqryESASiteMeasurements.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryESASiteMeasurements
			// 
			this.dvqryESASiteMeasurements.Table = this.objdsqryESASiteMeasurements.qryESASiteMeasurements;
			// 
			// oleDbdaqryESASites
			// 
			this.oleDbdaqryESASites.InsertCommand = this.oleDbInsertCommand21;
			this.oleDbdaqryESASites.SelectCommand = this.oleDbSelectCommand21;
			this.oleDbdaqryESASites.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "qryESASites", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																						new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																						new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																						new System.Data.Common.DataColumnMapping("CoordinateSource", "CoordinateSource"),
																																																						new System.Data.Common.DataColumnMapping("CoordinateSystem", "CoordinateSystem"),
																																																						new System.Data.Common.DataColumnMapping("CoordinateUnits", "CoordinateUnits"),
																																																						new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																						new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																						new System.Data.Common.DataColumnMapping("NoActionItems", "NoActionItems"),
																																																						new System.Data.Common.DataColumnMapping("NoCompleted", "NoCompleted"),
																																																						new System.Data.Common.DataColumnMapping("NoFollowUp", "NoFollowUp"),
																																																						new System.Data.Common.DataColumnMapping("SiteType", "SiteType"),
																																																						new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																						new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																						new System.Data.Common.DataColumnMapping("XCoordinate", "XCoordinate"),
																																																						new System.Data.Common.DataColumnMapping("YCoordinate", "YCoordinate"),
																																																						new System.Data.Common.DataColumnMapping("DataBegins", "DataBegins"),
																																																						new System.Data.Common.DataColumnMapping("DataEnds", "DataEnds")})});
			// 
			// oleDbInsertCommand21
			// 
			this.oleDbInsertCommand21.CommandText = @"INSERT INTO qryESASites(AgencyCd, AgencySiteID, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, [Date], DrainageCd, NoActionItems, NoCompleted, NoFollowUp, SiteType, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, DataBegins, DataEnds) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand21.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoActionItems", System.Data.OleDb.OleDbType.Integer, 0, "NoActionItems"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoCompleted", System.Data.OleDb.OleDbType.Integer, 0, "NoCompleted"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoFollowUp", System.Data.OleDb.OleDbType.Integer, 0, "NoFollowUp"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("SiteType", System.Data.OleDb.OleDbType.VarWChar, 40, "SiteType"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataBegins", System.Data.OleDb.OleDbType.VarWChar, 255, "DataBegins"));
			this.oleDbInsertCommand21.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataEnds", System.Data.OleDb.OleDbType.VarWChar, 255, "DataEnds"));
			// 
			// oleDbSelectCommand21
			// 
			this.oleDbSelectCommand21.CommandText = @"SELECT AgencyCd, AgencySiteID, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, [Date], DrainageCd, NoActionItems, NoCompleted, NoFollowUp, SiteType, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, DataBegins, DataEnds FROM qryESASites";
			this.oleDbSelectCommand21.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand10
			// 
			this.oleDbInsertCommand10.CommandText = @"INSERT INTO qryESASites(AgencyCd, AgencySiteID, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, [Date], DrainageCd, NoActionItems, NoCompleted, NoFollowUp, SiteType, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand10.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoActionItems", System.Data.OleDb.OleDbType.Integer, 0, "NoActionItems"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoCompleted", System.Data.OleDb.OleDbType.Integer, 0, "NoCompleted"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoFollowUp", System.Data.OleDb.OleDbType.Integer, 0, "NoFollowUp"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("SiteType", System.Data.OleDb.OleDbType.VarWChar, 40, "SiteType"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			// 
			// oleDbSelectCommand10
			// 
			this.oleDbSelectCommand10.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticSiteID, CoordinateSource, CoordinateSystem," +
				" CoordinateUnits, [Date], DrainageCd, NoActionItems, NoCompleted, NoFollowUp, Si" +
				"teType, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate FROM qryESASites";
			this.oleDbSelectCommand10.Connection = this.oleDbConnection1;
			// 
			// objdsqryESASites
			// 
			this.objdsqryESASites.DataSetName = "dsqryESASites";
			this.objdsqryESASites.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryESASites
			// 
			this.dvqryESASites.Table = this.objdsqryESASites.qryESASites;
			// 
			// oleDbdaqryFishStocking
			// 
			this.oleDbdaqryFishStocking.InsertCommand = this.oleDbInsertCommand11;
			this.oleDbdaqryFishStocking.SelectCommand = this.oleDbSelectCommand11;
			this.oleDbdaqryFishStocking.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "qryFishStocking", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																								new System.Data.Common.DataColumnMapping("Agency2Contact", "Agency2Contact"),
																																																								new System.Data.Common.DataColumnMapping("Agency2SiteID", "Agency2SiteID"),
																																																								new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																								new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																								new System.Data.Common.DataColumnMapping("AgeUnitOfMeasure", "AgeUnitOfMeasure"),
																																																								new System.Data.Common.DataColumnMapping("AirTemp_C", "AirTemp_C"),
																																																								new System.Data.Common.DataColumnMapping("AppliedMarkCd", "AppliedMarkCd"),
																																																								new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																								new System.Data.Common.DataColumnMapping("AveLength_cm", "AveLength_cm"),
																																																								new System.Data.Common.DataColumnMapping("AveWeight_gm", "AveWeight_gm"),
																																																								new System.Data.Common.DataColumnMapping("BroodstockInd", "BroodstockInd"),
																																																								new System.Data.Common.DataColumnMapping("Crew", "Crew"),
																																																								new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																								new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																								new System.Data.Common.DataColumnMapping("FishAge", "FishAge"),
																																																								new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																								new System.Data.Common.DataColumnMapping("FishMark", "FishMark"),
																																																								new System.Data.Common.DataColumnMapping("FishSpecies", "FishSpecies"),
																																																								new System.Data.Common.DataColumnMapping("FishSpeciesCd", "FishSpeciesCd"),
																																																								new System.Data.Common.DataColumnMapping("FishStockingID", "FishStockingID"),
																																																								new System.Data.Common.DataColumnMapping("FishStockName", "FishStockName"),
																																																								new System.Data.Common.DataColumnMapping("FishTankNo", "FishTankNo"),
																																																								new System.Data.Common.DataColumnMapping("LengthRange_cm", "LengthRange_cm"),
																																																								new System.Data.Common.DataColumnMapping("Location", "Location"),
																																																								new System.Data.Common.DataColumnMapping("NoFish", "NoFish"),
																																																								new System.Data.Common.DataColumnMapping("PermitNo", "PermitNo"),
																																																								new System.Data.Common.DataColumnMapping("SatelliteRearedInd", "SatelliteRearedInd"),
																																																								new System.Data.Common.DataColumnMapping("Source", "Source"),
																																																								new System.Data.Common.DataColumnMapping("TimeofDay", "TimeofDay"),
																																																								new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																								new System.Data.Common.DataColumnMapping("WaterLevel", "WaterLevel"),
																																																								new System.Data.Common.DataColumnMapping("WaterTemp_C", "WaterTemp_C"),
																																																								new System.Data.Common.DataColumnMapping("WeightRange_gm", "WeightRange_gm")})});
			// 
			// oleDbInsertCommand11
			// 
			this.oleDbInsertCommand11.CommandText = @"INSERT INTO qryFishStocking(Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AgeUnitOfMeasure, AirTemp_C, AppliedMarkCd, AquaticSiteID, AveLength_cm, AveWeight_gm, BroodstockInd, Crew, [Date], DrainageCd, FishAge, FishAgeClass, FishMark, FishSpecies, FishSpeciesCd, FishStockName, FishTankNo, LengthRange_cm, Location, NoFish, PermitNo, SatelliteRearedInd, Source, TimeofDay, WaterBodyID, WaterLevel, WaterTemp_C, WeightRange_gm) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand11.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarWChar, 50, "Agency2Contact"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2SiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "Agency2SiteID"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgeUnitOfMeasure", System.Data.OleDb.OleDbType.VarWChar, 10, "AgeUnitOfMeasure"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "AirTemp_C"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AppliedMarkCd", System.Data.OleDb.OleDbType.Integer, 0, "AppliedMarkCd"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveLength_cm"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("BroodstockInd", System.Data.OleDb.OleDbType.Boolean, 2, "BroodstockInd"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAge", System.Data.OleDb.OleDbType.VarWChar, 10, "FishAge"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClass"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, "FishMark"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishStockName", System.Data.OleDb.OleDbType.VarWChar, 150, "FishStockName"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishTankNo", System.Data.OleDb.OleDbType.VarWChar, 2, "FishTankNo"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("LengthRange_cm", System.Data.OleDb.OleDbType.VarWChar, 20, "LengthRange_cm"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 100, "Location"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoFish", System.Data.OleDb.OleDbType.Integer, 0, "NoFish"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermitNo", System.Data.OleDb.OleDbType.VarWChar, 20, "PermitNo"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("SatelliteRearedInd", System.Data.OleDb.OleDbType.Boolean, 2, "SatelliteRearedInd"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Source", System.Data.OleDb.OleDbType.VarWChar, 50, "Source"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 6, "TimeofDay"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, "WaterLevel"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "WaterTemp_C"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeightRange_gm", System.Data.OleDb.OleDbType.VarWChar, 20, "WeightRange_gm"));
			// 
			// oleDbSelectCommand11
			// 
			this.oleDbSelectCommand11.CommandText = @"SELECT Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AgeUnitOfMeasure, AirTemp_C, AppliedMarkCd, AquaticSiteID, AveLength_cm, AveWeight_gm, BroodstockInd, Crew, [Date], DrainageCd, FishAge, FishAgeClass, FishMark, FishSpecies, FishSpeciesCd, FishStockingID, FishStockName, FishTankNo, LengthRange_cm, Location, NoFish, PermitNo, SatelliteRearedInd, Source, TimeofDay, WaterBodyID, WaterLevel, WaterTemp_C, WeightRange_gm FROM qryFishStocking";
			this.oleDbSelectCommand11.Connection = this.oleDbConnection1;
			// 
			// objdsqryFishStocking
			// 
			this.objdsqryFishStocking.DataSetName = "dsqryFishStocking";
			this.objdsqryFishStocking.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryFishStocking
			// 
			this.dvqryFishStocking.Table = this.objdsqryFishStocking.qryFishStocking;
			// 
			// oleDbdaqryFishStockingSites
			// 
			this.oleDbdaqryFishStockingSites.InsertCommand = this.oleDbInsertCommand19;
			this.oleDbdaqryFishStockingSites.SelectCommand = this.oleDbSelectCommand19;
			this.oleDbdaqryFishStockingSites.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "qryFishStockingSites", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																										  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																										  new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																										  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																										  new System.Data.Common.DataColumnMapping("CoordinateSource", "CoordinateSource"),
																																																										  new System.Data.Common.DataColumnMapping("CoordinateSystem", "CoordinateSystem"),
																																																										  new System.Data.Common.DataColumnMapping("CoordinateUnits", "CoordinateUnits"),
																																																										  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																										  new System.Data.Common.DataColumnMapping("HabitatDesc", "HabitatDesc"),
																																																										  new System.Data.Common.DataColumnMapping("Location", "Location"),
																																																										  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																										  new System.Data.Common.DataColumnMapping("XCoordinate", "XCoordinate"),
																																																										  new System.Data.Common.DataColumnMapping("YCoordinate", "YCoordinate"),
																																																										  new System.Data.Common.DataColumnMapping("DataBegins", "DataBegins"),
																																																										  new System.Data.Common.DataColumnMapping("DataEnds", "DataEnds")})});
			// 
			// oleDbInsertCommand19
			// 
			this.oleDbInsertCommand19.CommandText = @"INSERT INTO qryFishStockingSites(AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, HabitatDesc, Location, WaterBodyID, XCoordinate, YCoordinate, DataBegins, DataEnds) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand19.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 100, "Location"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataBegins", System.Data.OleDb.OleDbType.VarChar, 255, "DataBegins"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataEnds", System.Data.OleDb.OleDbType.VarChar, 255, "DataEnds"));
			// 
			// oleDbSelectCommand19
			// 
			this.oleDbSelectCommand19.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, " +
				"CoordinateSystem, CoordinateUnits, DrainageCd, HabitatDesc, Location, WaterBodyI" +
				"D, XCoordinate, YCoordinate, DataBegins, DataEnds FROM qryFishStockingSites";
			this.oleDbSelectCommand19.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand12
			// 
			this.oleDbInsertCommand12.CommandText = @"INSERT INTO qryFishStockingSites(AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, EndYear, HabitatDesc, Location, StartYear, WaterBodyID, XCoordinate, YCoordinate) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand12.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Location", System.Data.OleDb.OleDbType.VarWChar, 100, "Location"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			// 
			// oleDbSelectCommand12
			// 
			this.oleDbSelectCommand12.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, " +
				"CoordinateSystem, CoordinateUnits, DrainageCd, EndYear, HabitatDesc, Location, S" +
				"tartYear, WaterBodyID, XCoordinate, YCoordinate FROM qryFishStockingSites";
			this.oleDbSelectCommand12.Connection = this.oleDbConnection1;
			// 
			// objdsqryFishStockingSites
			// 
			this.objdsqryFishStockingSites.DataSetName = "dsqryFishStockingSites";
			this.objdsqryFishStockingSites.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryFishStockingSites
			// 
			this.dvqryFishStockingSites.Table = this.objdsqryFishStockingSites.qryFishStockingSites;
			// 
			// oleDbdaqryWaterTemperatureLoggerDetails
			// 
			this.oleDbdaqryWaterTemperatureLoggerDetails.InsertCommand = this.oleDbInsertCommand13;
			this.oleDbdaqryWaterTemperatureLoggerDetails.SelectCommand = this.oleDbSelectCommand13;
			this.oleDbdaqryWaterTemperatureLoggerDetails.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															  new System.Data.Common.DataTableMapping("Table", "qryWaterTemperatureLoggerDetails", new System.Data.Common.DataColumnMapping[] {
																																																																  new System.Data.Common.DataColumnMapping("Accuracy", "Accuracy"),
																																																																  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																																  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																																  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																																  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																																  new System.Data.Common.DataColumnMapping("AquaticSiteName", "AquaticSiteName"),
																																																																  new System.Data.Common.DataColumnMapping("BrandName", "BrandName"),
																																																																  new System.Data.Common.DataColumnMapping("DataFileName", "DataFileName"),
																																																																  new System.Data.Common.DataColumnMapping("DistanceFromLeftBank_m", "DistanceFromLeftBank_m"),
																																																																  new System.Data.Common.DataColumnMapping("DistanceFromRightBank_m", "DistanceFromRightBank_m"),
																																																																  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																																  new System.Data.Common.DataColumnMapping("HabitatDesc", "HabitatDesc"),
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
																																																																  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																																  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																																  new System.Data.Common.DataColumnMapping("WaterDepth_cm", "WaterDepth_cm"),
																																																																  new System.Data.Common.DataColumnMapping("WaterLevel_Install", "WaterLevel_Install"),
																																																																  new System.Data.Common.DataColumnMapping("WaterLevel_Removal", "WaterLevel_Removal")})});
			// 
			// oleDbInsertCommand13
			// 
			this.oleDbInsertCommand13.CommandText = @"INSERT INTO qryWaterTemperatureLoggerDetails(Accuracy, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, AquaticSiteName, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, DrainageCd, HabitatDesc, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerNo, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TempRange_From, TempRange_To, WaterBodyID, WaterBodyName, WaterDepth_cm, WaterLevel_Install, WaterLevel_Removal) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand13.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerNo", System.Data.OleDb.OleDbType.VarWChar, 20, "LoggerNo"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_cm", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_cm"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			// 
			// oleDbSelectCommand13
			// 
			this.oleDbSelectCommand13.CommandText = @"SELECT Accuracy, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, AquaticSiteName, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, DrainageCd, HabitatDesc, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerNo, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TemperatureLoggerID, TempRange_From, TempRange_To, WaterBodyID, WaterBodyName, WaterDepth_cm, WaterLevel_Install, WaterLevel_Removal FROM qryWaterTemperatureLoggerDetails";
			this.oleDbSelectCommand13.Connection = this.oleDbConnection1;
			// 
			// objdsqryWaterTemperatureLoggerDetails
			// 
			this.objdsqryWaterTemperatureLoggerDetails.DataSetName = "dsqryWaterTemperatureLoggerDetails";
			this.objdsqryWaterTemperatureLoggerDetails.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryWaterTemperatureLoggerDetails
			// 
			this.dvqryWaterTemperatureLoggerDetails.Table = this.objdsqryWaterTemperatureLoggerDetails.qryWaterTemperatureLoggerDetails;
			// 
			// oleDbdaqryWaterTemperatureLoggerMeasurements
			// 
			this.oleDbdaqryWaterTemperatureLoggerMeasurements.InsertCommand = this.oleDbInsertCommand14;
			this.oleDbdaqryWaterTemperatureLoggerMeasurements.SelectCommand = this.oleDbSelectCommand14;
			this.oleDbdaqryWaterTemperatureLoggerMeasurements.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																   new System.Data.Common.DataTableMapping("Table", "qryWaterTemperatureLoggerMeasurements", new System.Data.Common.DataColumnMapping[] {
																																																																			new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																																			new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																																			new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																																			new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																																			new System.Data.Common.DataColumnMapping("AquaticSiteName", "AquaticSiteName"),
																																																																			new System.Data.Common.DataColumnMapping("AveTemp_C", "AveTemp_C"),
																																																																			new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																																			new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																																			new System.Data.Common.DataColumnMapping("MaxTemp_C", "MaxTemp_C"),
																																																																			new System.Data.Common.DataColumnMapping("MinTemp_C", "MinTemp_C"),
																																																																			new System.Data.Common.DataColumnMapping("TemperatureLoggerID", "TemperatureLoggerID"),
																																																																			new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																																			new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName")})});
			// 
			// oleDbInsertCommand14
			// 
			this.oleDbInsertCommand14.CommandText = @"INSERT INTO qryWaterTemperatureLoggerMeasurements(AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, AquaticSiteName, AveTemp_C, [Date], DrainageCd, MaxTemp_C, MinTemp_C, TemperatureLoggerID, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand14.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveTemp_C", System.Data.OleDb.OleDbType.Single, 0, "AveTemp_C"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("MaxTemp_C", System.Data.OleDb.OleDbType.Single, 0, "MaxTemp_C"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("MinTemp_C", System.Data.OleDb.OleDbType.Single, 0, "MinTemp_C"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("TemperatureLoggerID", System.Data.OleDb.OleDbType.Integer, 0, "TemperatureLoggerID"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand14
			// 
			this.oleDbSelectCommand14.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, AquaticSiteName," +
				" AveTemp_C, [Date], DrainageCd, MaxTemp_C, MinTemp_C, TemperatureLoggerID, Water" +
				"BodyID, WaterBodyName FROM qryWaterTemperatureLoggerMeasurements";
			this.oleDbSelectCommand14.Connection = this.oleDbConnection1;
			// 
			// objdsqryWaterTemperatureLoggerMeasurements
			// 
			this.objdsqryWaterTemperatureLoggerMeasurements.DataSetName = "dsqryWaterTemperatureLoggerMeasurements";
			this.objdsqryWaterTemperatureLoggerMeasurements.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryWaterTemperatureLoggerMeasurements
			// 
			this.dvqryWaterTemperatureLoggerMeasurements.Table = this.objdsqryWaterTemperatureLoggerMeasurements.qryWaterTemperatureLoggerMeasurements;
			// 
			// oleDbdaqryWaterTemperatureLoggerSites
			// 
			this.oleDbdaqryWaterTemperatureLoggerSites.InsertCommand = this.oleDbInsertCommand22;
			this.oleDbdaqryWaterTemperatureLoggerSites.SelectCommand = this.oleDbSelectCommand22;
			this.oleDbdaqryWaterTemperatureLoggerSites.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															new System.Data.Common.DataTableMapping("Table", "qryWaterTemperatureLoggerSites", new System.Data.Common.DataColumnMapping[] {
																																																															  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																															  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																															  new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																															  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																															  new System.Data.Common.DataColumnMapping("CoordinateSource", "CoordinateSource"),
																																																															  new System.Data.Common.DataColumnMapping("CoordinateSystem", "CoordinateSystem"),
																																																															  new System.Data.Common.DataColumnMapping("CoordinateUnits", "CoordinateUnits"),
																																																															  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																															  new System.Data.Common.DataColumnMapping("HabitatDesc", "HabitatDesc"),
																																																															  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																															  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																															  new System.Data.Common.DataColumnMapping("XCoordinate", "XCoordinate"),
																																																															  new System.Data.Common.DataColumnMapping("YCoordinate", "YCoordinate"),
																																																															  new System.Data.Common.DataColumnMapping("DataBegins", "DataBegins"),
																																																															  new System.Data.Common.DataColumnMapping("DataEnds", "DataEnds")})});
			// 
			// oleDbInsertCommand22
			// 
			this.oleDbInsertCommand22.CommandText = @"INSERT INTO qryWaterTemperatureLoggerSites(AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, HabitatDesc, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, DataBegins, DataEnds) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand22.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataBegins", System.Data.OleDb.OleDbType.VarWChar, 255, "DataBegins"));
			this.oleDbInsertCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataEnds", System.Data.OleDb.OleDbType.VarWChar, 255, "DataEnds"));
			// 
			// oleDbSelectCommand22
			// 
			this.oleDbSelectCommand22.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, " +
				"CoordinateSystem, CoordinateUnits, DrainageCd, HabitatDesc, WaterBodyID, WaterBo" +
				"dyName, XCoordinate, YCoordinate, DataBegins, DataEnds FROM qryWaterTemperatureL" +
				"oggerSites";
			this.oleDbSelectCommand22.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand15
			// 
			this.oleDbInsertCommand15.CommandText = @"INSERT INTO qryWaterTemperatureLoggerSites(AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, EndYear, HabitatDesc, StartYear, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand15.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			// 
			// oleDbSelectCommand15
			// 
			this.oleDbSelectCommand15.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticSiteDesc, AquaticSiteID, CoordinateSource, " +
				"CoordinateSystem, CoordinateUnits, DrainageCd, EndYear, HabitatDesc, StartYear, " +
				"WaterBodyID, WaterBodyName, XCoordinate, YCoordinate FROM qryWaterTemperatureLog" +
				"gerSites";
			this.oleDbSelectCommand15.Connection = this.oleDbConnection1;
			// 
			// objdsqryWaterTemperatureLoggerSites
			// 
			this.objdsqryWaterTemperatureLoggerSites.DataSetName = "dsqryWaterTemperatureLoggerSites";
			this.objdsqryWaterTemperatureLoggerSites.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryWaterTemperatureLoggerSites
			// 
			this.dvqryWaterTemperatureLoggerSites.Table = this.objdsqryWaterTemperatureLoggerSites.qryWaterTemperatureLoggerSites;
			// 
			// oleDbdaqryElectrofishingMarkRecaptureDataPlusEstimates
			// 
			this.oleDbdaqryElectrofishingMarkRecaptureDataPlusEstimates.InsertCommand = this.oleDbInsertCommand17;
			this.oleDbdaqryElectrofishingMarkRecaptureDataPlusEstimates.SelectCommand = this.oleDbSelectCommand17;
			this.oleDbdaqryElectrofishingMarkRecaptureDataPlusEstimates.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																			 new System.Data.Common.DataTableMapping("Table", "qryElectrofishingMarkRecaptureDataPlusEstimates", new System.Data.Common.DataColumnMapping[] {
																																																																								new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																																								new System.Data.Common.DataColumnMapping("Agency2Contact", "Agency2Contact"),
																																																																								new System.Data.Common.DataColumnMapping("Agency2SiteID", "Agency2SiteID"),
																																																																								new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																																								new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																																								new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																																								new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																																								new System.Data.Common.DataColumnMapping("Area_m2", "Area_m2"),
																																																																								new System.Data.Common.DataColumnMapping("AutoCalculatedInd", "AutoCalculatedInd"),
																																																																								new System.Data.Common.DataColumnMapping("AveForkLength_cm", "AveForkLength_cm"),
																																																																								new System.Data.Common.DataColumnMapping("AveTotalLenght_cm", "AveTotalLenght_cm"),
																																																																								new System.Data.Common.DataColumnMapping("AveWeight_gm", "AveWeight_gm"),
																																																																								new System.Data.Common.DataColumnMapping("Biomass", "Biomass"),
																																																																								new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																																								new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																																								new System.Data.Common.DataColumnMapping("Density", "Density"),
																																																																								new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																																								new System.Data.Common.DataColumnMapping("EFMRDataID", "EFMRDataID"),
																																																																								new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																																								new System.Data.Common.DataColumnMapping("FishSpecies", "FishSpecies"),
																																																																								new System.Data.Common.DataColumnMapping("Formula", "Formula"),
																																																																								new System.Data.Common.DataColumnMapping("HabitatDesc", "HabitatDesc"),
																																																																								new System.Data.Common.DataColumnMapping("MarkCount", "MarkCount"),
																																																																								new System.Data.Common.DataColumnMapping("MarkEfficiency", "MarkEfficiency"),
																																																																								new System.Data.Common.DataColumnMapping("MarkMarked", "MarkMarked"),
																																																																								new System.Data.Common.DataColumnMapping("MarkMorts", "MarkMorts"),
																																																																								new System.Data.Common.DataColumnMapping("Method", "Method"),
																																																																								new System.Data.Common.DataColumnMapping("PHS", "PHS"),
																																																																								new System.Data.Common.DataColumnMapping("RecaptureCount", "RecaptureCount"),
																																																																								new System.Data.Common.DataColumnMapping("RecaptureMarked", "RecaptureMarked"),
																																																																								new System.Data.Common.DataColumnMapping("RecaptureMorts", "RecaptureMorts"),
																																																																								new System.Data.Common.DataColumnMapping("RecaptureTime", "RecaptureTime"),
																																																																								new System.Data.Common.DataColumnMapping("RecaptureUnmarked", "RecaptureUnmarked"),
																																																																								new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																																								new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																																								new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																																								new System.Data.Common.DataColumnMapping("FishSpeciesCd", "FishSpeciesCd")})});
			// 
			// oleDbInsertCommand17
			// 
			this.oleDbInsertCommand17.CommandText = @"INSERT INTO qryElectrofishingMarkRecaptureDataPlusEstimates(Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, Area_m2, AutoCalculatedInd, AveForkLength_cm, AveTotalLenght_cm, AveWeight_gm, Biomass, Comments, [Date], Density, DrainageCd, FishAgeClass, FishSpecies, Formula, HabitatDesc, MarkCount, MarkEfficiency, MarkMarked, MarkMorts, Method, PHS, RecaptureCount, RecaptureMarked, RecaptureMorts, RecaptureTime, RecaptureUnmarked, WaterBodyID, WaterBodyName, AquaticSiteDesc, FishSpeciesCd) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand17.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarWChar, 50, "Agency2Contact"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2SiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "Agency2SiteID"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Area_m2", System.Data.OleDb.OleDbType.Single, 0, "Area_m2"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AutoCalculatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "AutoCalculatedInd"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveForkLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveForkLength_cm"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveTotalLenght_cm", System.Data.OleDb.OleDbType.Double, 0, "AveTotalLenght_cm"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Biomass", System.Data.OleDb.OleDbType.Double, 0, "Biomass"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 100, "Comments"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Density", System.Data.OleDb.OleDbType.Double, 0, "Density"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 10, "FishAgeClass"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Formula", System.Data.OleDb.OleDbType.VarWChar, 50, "Formula"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("MarkCount", System.Data.OleDb.OleDbType.Double, 0, "MarkCount"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("MarkEfficiency", System.Data.OleDb.OleDbType.Double, 0, "MarkEfficiency"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("MarkMarked", System.Data.OleDb.OleDbType.Double, 0, "MarkMarked"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("MarkMorts", System.Data.OleDb.OleDbType.Double, 0, "MarkMorts"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Method", System.Data.OleDb.OleDbType.VarWChar, 30, "Method"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("PHS", System.Data.OleDb.OleDbType.Double, 0, "PHS"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureCount", System.Data.OleDb.OleDbType.Double, 0, "RecaptureCount"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureMarked", System.Data.OleDb.OleDbType.Double, 0, "RecaptureMarked"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureMorts", System.Data.OleDb.OleDbType.Double, 0, "RecaptureMorts"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureTime", System.Data.OleDb.OleDbType.SmallInt, 0, "RecaptureTime"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureUnmarked", System.Data.OleDb.OleDbType.Double, 0, "RecaptureUnmarked"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			// 
			// oleDbSelectCommand17
			// 
			this.oleDbSelectCommand17.CommandText = @"SELECT Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, Area_m2, AutoCalculatedInd, AveForkLength_cm, AveTotalLenght_cm, AveWeight_gm, Biomass, Comments, [Date], Density, DrainageCd, EFMRDataID, FishAgeClass, FishSpecies, Formula, HabitatDesc, MarkCount, MarkEfficiency, MarkMarked, MarkMorts, Method, PHS, RecaptureCount, RecaptureMarked, RecaptureMorts, RecaptureTime, RecaptureUnmarked, WaterBodyID, WaterBodyName, AquaticSiteDesc, FishSpeciesCd FROM qryElectrofishingMarkRecaptureDataPlusEstimates";
			this.oleDbSelectCommand17.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand16
			// 
			this.oleDbInsertCommand16.CommandText = @"INSERT INTO qryElectrofishingMarkRecaptureDataPlusEstimates(Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, Area_m2, AutoCalculatedInd, AveForkLength_cm, AveTotalLenght_cm, AveWeight_gm, Biomass, Comments, [Date], Density, DrainageCd, FishAgeClass, FishSpecies, Formula, HabitatDesc, MarkCount, MarkEfficiency, MarkMarked, MarkMorts, Method, PHS, RecaptureCount, RecaptureMarked, RecaptureMorts, RecaptureTime, RecaptureUnmarked, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand16.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarWChar, 50, "Agency2Contact"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2SiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "Agency2SiteID"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Area_m2", System.Data.OleDb.OleDbType.Single, 0, "Area_m2"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("AutoCalculatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "AutoCalculatedInd"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveForkLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveForkLength_cm"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveTotalLenght_cm", System.Data.OleDb.OleDbType.Double, 0, "AveTotalLenght_cm"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Biomass", System.Data.OleDb.OleDbType.Double, 0, "Biomass"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 100, "Comments"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 10, "Date"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Density", System.Data.OleDb.OleDbType.Double, 0, "Density"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 10, "FishAgeClass"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Formula", System.Data.OleDb.OleDbType.VarWChar, 50, "Formula"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("MarkCount", System.Data.OleDb.OleDbType.Double, 0, "MarkCount"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("MarkEfficiency", System.Data.OleDb.OleDbType.Double, 0, "MarkEfficiency"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("MarkMarked", System.Data.OleDb.OleDbType.Double, 0, "MarkMarked"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("MarkMorts", System.Data.OleDb.OleDbType.Double, 0, "MarkMorts"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Method", System.Data.OleDb.OleDbType.VarWChar, 30, "Method"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("PHS", System.Data.OleDb.OleDbType.Double, 0, "PHS"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureCount", System.Data.OleDb.OleDbType.Double, 0, "RecaptureCount"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureMarked", System.Data.OleDb.OleDbType.Double, 0, "RecaptureMarked"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureMorts", System.Data.OleDb.OleDbType.Double, 0, "RecaptureMorts"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureTime", System.Data.OleDb.OleDbType.SmallInt, 0, "RecaptureTime"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecaptureUnmarked", System.Data.OleDb.OleDbType.Double, 0, "RecaptureUnmarked"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName"));
			// 
			// oleDbSelectCommand16
			// 
			this.oleDbSelectCommand16.CommandText = @"SELECT Agency2Cd, Agency2Contact, Agency2SiteID, AgencyCd, AgencySiteID, AquaticActivityID, AquaticSiteID, Area_m2, AutoCalculatedInd, AveForkLength_cm, AveTotalLenght_cm, AveWeight_gm, Biomass, Comments, [Date], Density, DrainageCd, EFMRDataID, FishAgeClass, FishSpecies, Formula, HabitatDesc, MarkCount, MarkEfficiency, MarkMarked, MarkMorts, Method, PHS, RecaptureCount, RecaptureMarked, RecaptureMorts, RecaptureTime, RecaptureUnmarked, WaterBodyID, WaterBodyName FROM qryElectrofishingMarkRecaptureDataPlusEstimates";
			this.oleDbSelectCommand16.Connection = this.oleDbConnection1;
			// 
			// objdsqryElectrofishingMarkRecaptureDataPlusEstimates
			// 
			this.objdsqryElectrofishingMarkRecaptureDataPlusEstimates.DataSetName = "dsqryElectrofishingMarkRecaptureDataPlusEstimates";
			this.objdsqryElectrofishingMarkRecaptureDataPlusEstimates.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvqryElectrofishingMarkRecaptureDataPlusEstimates
			// 
			this.dvqryElectrofishingMarkRecaptureDataPlusEstimates.Table = this.objdsqryElectrofishingMarkRecaptureDataPlusEstimates.qryElectrofishingMarkRecaptureDataPlusEstimates;
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingDataPlusEstimates)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingDataPlusEstimates)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingMethodDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingMethodDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingSiteMeasurements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingSiteMeasurements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingWaterMeasurements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingWaterMeasurements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryESAObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryESAObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryESAPlanning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryESAPlanning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryESASiteMeasurements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryESASiteMeasurements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryESASites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryESASites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryFishStocking)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryFishStocking)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryFishStockingSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryFishStockingSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryWaterTemperatureLoggerDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryWaterTemperatureLoggerDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryWaterTemperatureLoggerMeasurements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryWaterTemperatureLoggerMeasurements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryWaterTemperatureLoggerSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryWaterTemperatureLoggerSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsqryElectrofishingMarkRecaptureDataPlusEstimates)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvqryElectrofishingMarkRecaptureDataPlusEstimates)).EndInit();

		}
		#endregion

		#region Fill & Load
		public void FillCodeDataSet(NBADWDataEntryApplication.dscdAgency dataSet1)
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
				this.oleDbdacdAgency.Fill(dataSet1);
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

		public void LoadCodeDataSet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdAgency objDataSetTemp1;
			
			objDataSetTemp1 = new NBADWDataEntryApplication.dscdAgency();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillCodeDataSet(objDataSetTemp1);
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
				objdscdAgency.Merge(objDataSetTemp1);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillElectrofishing(NBADWDataEntryApplication.dsqryElectrofishingDataPlusEstimates dataSet1, NBADWDataEntryApplication.dsqryElectrofishingMarkRecaptureDataPlusEstimates dataSet2, NBADWDataEntryApplication.dsqryElectrofishingMethodDetails dataSet3, NBADWDataEntryApplication.dsqryElectrofishingSiteMeasurements dataSet4, NBADWDataEntryApplication.dsqryElectrofishingSites dataSet5, NBADWDataEntryApplication.dsqryElectrofishingWaterMeasurements dataSet6)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet1.EnforceConstraints = false;
			dataSet2.EnforceConstraints = false;
			dataSet3.EnforceConstraints = false;
			dataSet4.EnforceConstraints = false;
			dataSet5.EnforceConstraints = false;
			dataSet6.EnforceConstraints = false;

			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();

				this.oleDbdaqryElectrofishingDataPlusEstimates.Fill(dataSet1);
				this.oleDbdaqryElectrofishingMarkRecaptureDataPlusEstimates.Fill(dataSet2);
				this.oleDbdaqryElectrofishingMethodDetails.Fill(dataSet3);
				this.oleDbdaqryElectrofishingSiteMeasurements.Fill(dataSet4);
				this.oleDbdaqryElectrofishingSites.Fill(dataSet5);
				this.oleDbdaqryElectrofishingWaterMeasurements.Fill(dataSet6);
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
				dataSet2.EnforceConstraints = true;
				dataSet3.EnforceConstraints = true;
				dataSet4.EnforceConstraints = true;
				dataSet5.EnforceConstraints = true;
				dataSet6.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadElectrofishing()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.

			NBADWDataEntryApplication.dsqryElectrofishingDataPlusEstimates objDataSetTemp1;
			NBADWDataEntryApplication.dsqryElectrofishingMarkRecaptureDataPlusEstimates objDataSetTemp2;
			NBADWDataEntryApplication.dsqryElectrofishingMethodDetails objDataSetTemp3;
			NBADWDataEntryApplication.dsqryElectrofishingSiteMeasurements objDataSetTemp4;
			NBADWDataEntryApplication.dsqryElectrofishingSites objDataSetTemp5;
			NBADWDataEntryApplication.dsqryElectrofishingWaterMeasurements objDataSetTemp6;
			
			objDataSetTemp1 = new NBADWDataEntryApplication.dsqryElectrofishingDataPlusEstimates();
			objDataSetTemp2 = new NBADWDataEntryApplication.dsqryElectrofishingMarkRecaptureDataPlusEstimates();
			objDataSetTemp3 = new NBADWDataEntryApplication.dsqryElectrofishingMethodDetails();
			objDataSetTemp4 = new NBADWDataEntryApplication.dsqryElectrofishingSiteMeasurements();
			objDataSetTemp5 = new NBADWDataEntryApplication.dsqryElectrofishingSites();
			objDataSetTemp6 = new NBADWDataEntryApplication.dsqryElectrofishingWaterMeasurements();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillElectrofishing(objDataSetTemp1,objDataSetTemp2, objDataSetTemp3, objDataSetTemp4, objDataSetTemp5, objDataSetTemp6);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsqryElectrofishingDataPlusEstimates.Clear();
				this.objdsqryElectrofishingMarkRecaptureDataPlusEstimates.Clear();
				this.objdsqryElectrofishingMethodDetails.Clear();
				this.objdsqryElectrofishingSiteMeasurements.Clear();
				this.objdsqryElectrofishingSites.Clear();
				this.objdsqryElectrofishingWaterMeasurements.Clear();

				// Merge the records into the main dataset.
				this.objdsqryElectrofishingDataPlusEstimates.Merge(objDataSetTemp1);
				this.objdsqryElectrofishingMarkRecaptureDataPlusEstimates.Merge(objDataSetTemp2);
				this.objdsqryElectrofishingMethodDetails.Merge(objDataSetTemp3);
				this.objdsqryElectrofishingSiteMeasurements.Merge(objDataSetTemp4);
				this.objdsqryElectrofishingSites.Merge(objDataSetTemp5);
				this.objdsqryElectrofishingWaterMeasurements.Merge(objDataSetTemp6);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		
		public void FillESA(NBADWDataEntryApplication.dsqryESAObservations dataSet1, NBADWDataEntryApplication.dsqryESAPlanning dataSet2, NBADWDataEntryApplication.dsqryESASiteMeasurements dataSet3, NBADWDataEntryApplication.dsqryESASites dataSet4)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet1.EnforceConstraints = false;
			dataSet2.EnforceConstraints = false;
			dataSet3.EnforceConstraints = false;
			dataSet4.EnforceConstraints = false;
			
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();

				this.oleDbdaqryESAObservations.Fill(dataSet1);
				this.oleDbdaqryESAPlanning.Fill(dataSet2);
				this.oleDbdaqryESASiteMeasurements.Fill(dataSet3);
				this.oleDbdaqryESASites.Fill(dataSet4);
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
				dataSet2.EnforceConstraints = true;
				dataSet3.EnforceConstraints = true;
				dataSet4.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadESA()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.

			NBADWDataEntryApplication.dsqryESAObservations objDataSetTemp1;
			NBADWDataEntryApplication.dsqryESAPlanning objDataSetTemp2;
			NBADWDataEntryApplication.dsqryESASiteMeasurements objDataSetTemp3;
			NBADWDataEntryApplication.dsqryESASites objDataSetTemp4;
			
			objDataSetTemp1 = new NBADWDataEntryApplication.dsqryESAObservations();
			objDataSetTemp2 = new NBADWDataEntryApplication.dsqryESAPlanning();
			objDataSetTemp3 = new NBADWDataEntryApplication.dsqryESASiteMeasurements();
			objDataSetTemp4 = new NBADWDataEntryApplication.dsqryESASites();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillESA(objDataSetTemp1,objDataSetTemp2, objDataSetTemp3, objDataSetTemp4);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsqryESAObservations.Clear();
				this.objdsqryESAPlanning.Clear();
				this.objdsqryESASiteMeasurements.Clear();
				this.objdsqryESASites.Clear();

				// Merge the records into the main dataset.
				this.objdsqryESAObservations.Merge(objDataSetTemp1);
				this.objdsqryESAPlanning.Merge(objDataSetTemp2);
				this.objdsqryESASiteMeasurements.Merge(objDataSetTemp3);
				this.objdsqryESASites.Merge(objDataSetTemp4);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		public void FillFishStocking(NBADWDataEntryApplication.dsqryFishStocking dataSet1, NBADWDataEntryApplication.dsqryFishStockingSites dataSet2)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet1.EnforceConstraints = false;
			dataSet2.EnforceConstraints = false;

			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();

				this.oleDbdaqryFishStocking.Fill(dataSet1);
				this.oleDbdaqryFishStockingSites.Fill(dataSet2);
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
				dataSet2.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadFishStocking()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.

			NBADWDataEntryApplication.dsqryFishStocking objDataSetTemp1;
			NBADWDataEntryApplication.dsqryFishStockingSites objDataSetTemp2;
			
			objDataSetTemp1 = new NBADWDataEntryApplication.dsqryFishStocking();
			objDataSetTemp2 = new NBADWDataEntryApplication.dsqryFishStockingSites();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillFishStocking(objDataSetTemp1,objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsqryFishStocking.Clear();
				this.objdsqryFishStockingSites.Clear();
				
				// Merge the records into the main dataset.
				this.objdsqryFishStocking.Merge(objDataSetTemp1);
				this.objdsqryFishStockingSites.Merge(objDataSetTemp2);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		
		public void FillWaterTemperatureLogger(NBADWDataEntryApplication.dsqryWaterTemperatureLoggerDetails dataSet1, NBADWDataEntryApplication.dsqryWaterTemperatureLoggerMeasurements dataSet2, NBADWDataEntryApplication.dsqryWaterTemperatureLoggerSites dataSet3)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet1.EnforceConstraints = false;
			dataSet2.EnforceConstraints = false;
			dataSet3.EnforceConstraints = false;

			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();

				this.oleDbdaqryWaterTemperatureLoggerDetails.Fill(dataSet1);
				this.oleDbdaqryWaterTemperatureLoggerMeasurements.Fill(dataSet2);
				this.oleDbdaqryWaterTemperatureLoggerSites.Fill(dataSet3);
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
				dataSet2.EnforceConstraints = true;
				dataSet3.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadWaterTemperatureLogger()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.

			NBADWDataEntryApplication.dsqryWaterTemperatureLoggerDetails objDataSetTemp1;
			NBADWDataEntryApplication.dsqryWaterTemperatureLoggerMeasurements objDataSetTemp2;
			NBADWDataEntryApplication.dsqryWaterTemperatureLoggerSites objDataSetTemp3;
			
			objDataSetTemp1 = new NBADWDataEntryApplication.dsqryWaterTemperatureLoggerDetails();
			objDataSetTemp2 = new NBADWDataEntryApplication.dsqryWaterTemperatureLoggerMeasurements();
			objDataSetTemp3 = new NBADWDataEntryApplication.dsqryWaterTemperatureLoggerSites();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillWaterTemperatureLogger(objDataSetTemp1,objDataSetTemp2, objDataSetTemp3);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsqryWaterTemperatureLoggerDetails.Clear();
				this.objdsqryWaterTemperatureLoggerMeasurements.Clear();
				this.objdsqryWaterTemperatureLoggerSites.Clear();

				// Merge the records into the main dataset.
				this.objdsqryWaterTemperatureLoggerDetails.Merge(objDataSetTemp1);
				this.objdsqryWaterTemperatureLoggerMeasurements.Merge(objDataSetTemp2);
				this.objdsqryWaterTemperatureLoggerSites.Merge(objDataSetTemp3);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}		
		#endregion

		#region Buttons
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			#region Filter
			string filterstring = "";
			string filterstringy1 = "";
			string filterstringy2 = "";
			if(dlstAgencyCode.SelectedValue=="All")
			{
				filterstring = "AgencyCd LIKE '*'";
			}
			else
			{
				filterstring = "AgencyCd = '"+dlstAgencyCode.SelectedValue+"')";
			}

			if(txtdwsiteid.Text!="")
			{
				//this handles the possibility of the user entering a string
				//into a field that expects and int
				try
				{
					filterstring += " AND AquaticSiteID = " +Convert.ToInt32(txtdwsiteid.Text);
				}
				catch
				{
					filterstring += " AND AquaticSiteID = 0";
				}
			}				
			if(txtgroupsiteid.Text!="")
			{
				filterstring += " AND AgencySiteID LIKE '"+txtgroupsiteid.Text+"'";
			}
			if(txtwaterbodyid.Text!="")
			{
				//this handles the possibility of the user entering a string
				//into a field that expects and int
				try
				{
					filterstring += " AND WaterBodyID = " +Convert.ToInt32(txtwaterbodyid.Text);
				}
				catch
				{
					filterstring += " AND WaterBodyID = 0";
				}
				//filterstring += " AND  = '"+txtwaterbodyid.Text+"'";
			}
			if(txtwaterbodyname.Text!="")
			{
				filterstring += " AND WaterBodyName LIKE '"+txtwaterbodyname.Text+"'";
			}
			if(txtwatershed.Text!="")
			{
				filterstring += " AND DrainageCd LIKE '"+txtwatershed.Text+"'";
			}
			
			if(txtyear.Text.Length!=0)
			{
				if(txtyear.Text.Length==4)//just one year specified
				{
					filterstringy1 += " AND Mid([DataBegins],1,4) <= '"+txtyear.Text+"' AND Mid([DataEnds],1,4) >= '"+txtyear.Text+"'";
					filterstringy2 += " AND Mid([Date],1,4)= '"+txtyear.Text+"'";
				}
				else if(txtyear.Text.Length==9)//range specified
				{
					string strDataBegins,strDataEnds;
					strDataBegins = txtyear.Text.Substring(0,4);
					strDataEnds = txtyear.Text.Substring(5);
					//						//		selected date range completely covers site date range		//				at least one end of the selected range is within the site range
					filterstringy1 += " AND ((Mid([DataBegins],1,4) >= "+strDataBegins+" AND Mid([DataEnds],1,4) <= "+strDataEnds+") OR (Mid([DataBegins],1,4) <= "+strDataEnds+" AND Mid([DataEnds],1,4) >= "+strDataEnds+") OR (Mid([DataBegins],1,4) <= "+strDataBegins+" AND Mid([DataEnds],1,4) >= "+strDataBegins+"))";
					filterstringy2 += " AND ((Mid([Date],1,4) >= "+strDataBegins+" AND (Mid([Date],1,4) <= "+strDataEnds+")";
					//filterstringy1 += " AND ((DataBegins <= "+strDataBegins+" AND DataEnds >= "+strDataBegins+") OR (DataBegins <= "+strDataEnds+" AND DataEnds >= "+strDataEnds+") OR (DataBegins >= "+strDataBegins+" AND DataEnds <= "+strDataEnds+"))";
				}
			}
			#endregion
			
			Debug.WriteLine("filter: "+filterstring);
			Debug.WriteLine("filtery1: "+filterstring+filterstringy1);
			Debug.WriteLine("filtery2: "+filterstring+filterstringy2);

			Session["Filterstring"] = filterstringy1;
			Session["Filterstring2"] = filterstringy2;
			
			HideDataGrids();
			switch ((int)Session["Version"])
			{
				case 20://thermistor
					//set filters
					//Debug.WriteLine("site filter: "+dvqryWaterTemperatureLoggerSites.RowFilter.ToString());
					dvqryWaterTemperatureLoggerDetails.RowFilter = filterstringy2;
					dvqryWaterTemperatureLoggerMeasurements.RowFilter = filterstringy2;

					//get the data
					LoadWaterTemperatureLogger();

					//set grid columns and sources and headings
					qryWaterTemperatureLoggerSitesColumns(dg1);
					dvqryWaterTemperatureLoggerSites.RowFilter = filterstringy1;
					dg1.DataSource = dvqryWaterTemperatureLoggerSites;
					lbldg1Heading.Text = "Water Temperature Logger Sites";
					
					qryWaterTempertureLoggerDetailsColumns(dg2);
					dg2.DataSource = dvqryWaterTemperatureLoggerDetails;
					lbldg2Heading.Text = "Water Temperature Logger Details";

					qryWaterTempertureLoggerMeasurementsColumns(dg3);
					dg3.DataSource = dvqryWaterTemperatureLoggerMeasurements;
					lbldg3Heading.Text = "Water Temperature Logger Measurements";
										
					dg1.DataBind();
					dg2.DataBind();
					dg3.DataBind();
					
					pnldg1.Visible = true;
					pnldg2.Visible = true;
					pnldg3.Visible = true;
					break;
				case 5://stocking
					//get the data
					LoadFishStocking();

					//set grid columns and sources and headings
					qryFishStockingSitesColumns(dg1);
					dg1.DataSource = dvqryFishStockingSites;
					lbldg1Heading.Text = "Fish Stocking Sites";

					qryFishStockingColumns(dg2);
					dg2.DataSource = dvqryFishStocking;
					lbldg2Heading.Text = "Fish Stocking";

					dg1.DataBind();
					dg2.DataBind();
					
					pnldg1.Visible = true;
					pnldg2.Visible = true;
					break;
				case 2://electrofishing
					//get the data
					LoadElectrofishing();

					//set grid columns and sources and headings
					qryElectrofishingSitesColumns(dg1);
					dg1.DataSource = dvqryElectrofishingSites;
					lbldg1Heading.Text = "Electrofishing Sites";

					qryElectrofishingMethodDetailsColumns(dg2);
					dg2.DataSource = dvqryElectrofishingMethodDetails;
					lbldg2Heading.Text = "Electrofishing Method Details";

					qryElectrofishingSiteMeasurementsColumns(dg3);
					dg3.DataSource = dvqryElectrofishingSiteMeasurements;
					lbldg3Heading.Text = "Electrofishing Site Measurements";
					
					qryElectrofishingWaterMeasurementsColumns(dg4);
					dg4.DataSource = dvqryElectrofishingWaterMeasurements;
					lbldg4Heading.Text = "Electrofishing Water Measurements";

					qryElectrofishingDataPlusEstimatesColumns(dg5);
					dg5.DataSource = dvqryElectrofishingDataPlusEstimates;
					lbldg5Heading.Text = "Electrofishing Data Plus Estimates";

					qryElectrofishingMarkRecaptureDataPlusEstimatesColumns(dg6);
					dg6.DataSource = dvqryElectrofishingMarkRecaptureDataPlusEstimates;
					lbldg6Heading.Text = "Electrofishing Mark Recapture Data Plus Estimates";

					dg1.DataBind();
					dg2.DataBind();
					dg3.DataBind();
					dg4.DataBind();
					dg5.DataBind();
					dg6.DataBind();

					pnldg1.Visible = true;
					pnldg2.Visible = true;
					pnldg3.Visible = true;
					pnldg4.Visible = true;
					pnldg5.Visible = true;
					pnldg6.Visible = true;
					break;
				case 29://ESA
					//get the data
					LoadESA();

					//set grid columns and sources and headings
					qryESASitesColumns(dg1);
					dg1.DataSource = dvqryESASites;
					lbldg1Heading.Text = "Environmental Stream Assessment Sites";

					qryESASiteMeasurementsColumns(dg2);
					dg2.DataSource = dvqryESASiteMeasurements;
					lbldg2Heading.Text = "Environmental Stream Assessment Site Measurements";

					qryESAObservationsColumns(dg3);
					dg3.DataSource = dvqryESAObservations;
					lbldg3Heading.Text = "Environmental Stream Assessment Observations";
					
					qryESAPlanningColumns(dg4);
					dg4.DataSource = dvqryESAPlanning;
					lbldg4Heading.Text = "Environmental Stream Assessment Planning";					

					dg1.DataBind();
					dg2.DataBind();
					dg3.DataBind();
					dg4.DataBind();
					
					pnldg1.Visible = true;
					pnldg2.Visible = true;
					pnldg3.Visible = true;
					pnldg4.Visible = true;

					break;
			}		
		}

		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer(Session["PreviousPage"].ToString());
		}

		protected void btndg1Download_Click(object sender, System.EventArgs e)
		{
			//must refresh datagrid since it's columns are written at runtime
			switch ((int)Session["Version"])
			{
				case 20://thermistor
					LoadWaterTemperatureLogger();
					//qryWaterTemperatureLoggerSitesColumns(dg1);
					dg1.DataSource = dvqryWaterTemperatureLoggerSites;
					break;
				case 5://stocking
					LoadFishStocking();
					qryFishStockingSitesColumns(dg1);
					dg1.DataSource = dvqryFishStockingSites;
					break;
				case 2://electrofishing
					LoadElectrofishing();
					qryElectrofishingSitesColumns(dg1);
					dg1.DataSource = dvqryElectrofishingSites;
					break;
				case 29://ESA
					LoadESA();
					qryESASitesColumns(dg1);
					dg1.DataSource = dvqryESASites;
					break;
			}
			dg1.DataBind();
			ExportToExcel(dg1);		
		}

		protected void btndg2Download_Click(object sender, System.EventArgs e)
		{
			switch ((int)Session["Version"])
			{
				case 20://thermistor
					LoadWaterTemperatureLogger();
					qryWaterTempertureLoggerDetailsColumns(dg2);
					dg2.DataSource = dvqryWaterTemperatureLoggerDetails;
					break;
				case 5://stocking
					LoadFishStocking();
					qryFishStockingColumns(dg2);
					dg2.DataSource = dvqryFishStocking;
					break;
				case 2://electrofishing
					LoadElectrofishing();
					qryElectrofishingSitesColumns(dg1);
					dg1.DataSource = dvqryElectrofishingSites;
					break;
				case 29://ESA
					LoadESA();
					qryESASitesColumns(dg1);
					dg1.DataSource = dvqryESASites;
					break;
			}
			dg2.DataBind();
			ExportToExcel(dg2);			
		}

		protected void btndg3Download_Click(object sender, System.EventArgs e)
		{
			switch ((int)Session["Version"])
			{
				case 20://thermistor
					LoadWaterTemperatureLogger();
					qryWaterTempertureLoggerMeasurementsColumns(dg3);
					dg3.DataSource = dvqryWaterTemperatureLoggerMeasurements;
					break;
				case 5://stocking
					break;
				case 2://electrofishing
					LoadElectrofishing();
					qryElectrofishingSiteMeasurementsColumns(dg3);
					dg3.DataSource = dvqryElectrofishingSiteMeasurements;
					break;
				case 29://ESA
					LoadESA();
					qryESAObservationsColumns(dg3);
					dg3.DataSource = dvqryESAObservations;
					break;
			}
			dg3.DataBind();
			ExportToExcel(dg3);	
		}		
		protected void btndg4Download_Click(object sender, System.EventArgs e)
		{
			switch ((int)Session["Version"])
			{
				case 20://thermistor
					break;
				case 5://stocking
					break;
				case 2://electrofishing
					LoadElectrofishing();
					qryElectrofishingWaterMeasurementsColumns(dg4);
					dg4.DataSource = dvqryElectrofishingWaterMeasurements;
					break;
				case 29://ESA
					LoadESA();
					qryESAPlanningColumns(dg4);
					dg4.DataSource = dvqryESAPlanning;
					break;
			}
			dg4.DataBind();
			ExportToExcel(dg4);
		}

		protected void btndg5Download_Click(object sender, System.EventArgs e)
		{
			switch ((int)Session["Version"])
			{
				case 20://thermistor
					break;
				case 5://stocking
					break;
				case 2://electrofishing
					LoadElectrofishing();
					qryElectrofishingDataPlusEstimatesColumns(dg5);
					dg5.DataSource = dvqryElectrofishingDataPlusEstimates;
					break;
				case 29://ESA
					break;
			}
			dg5.DataBind();
			ExportToExcel(dg5);
		}
		private void btndg6Download_Click(object sender, System.EventArgs e)
		{
			switch ((int)Session["Version"])
			{
				case 20://thermistor
					break;
				case 5://stocking
					break;
				case 2://electrofishing
					LoadElectrofishing();
					qryElectrofishingMarkRecaptureDataPlusEstimatesColumns(dg6);
					dg6.DataSource = dvqryElectrofishingMarkRecaptureDataPlusEstimates;
					break;
				case 29://ESA
					break;
			}
			dg6.DataBind();
			ExportToExcel(dg6);
		}
		#endregion	
	
		private void HideDataGrids()
		{
			pnldg1.Visible = false;
			pnldg2.Visible = false;
			pnldg3.Visible = false;
			pnldg4.Visible = false;
			pnldg5.Visible = false;
			pnldg6.Visible = false;
		}


		#region Grid Columns
		private void qryElectrofishingDataPlusEstimatesColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="EFDataID"; 
			col.DataField="EFDataID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="PermitNo"; 
			col.DataField="PermitNo";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Agency2Cd"; 
			col.DataField="Agency2Cd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Agency2Contact"; 
			col.DataField="Agency2Contact";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteDesc"; 
			col.DataField="AquaticSiteDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="HabitatDesc"; 
			col.DataField="HabitatDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Method"; 
			col.DataField="Method";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Area_m2"; 
			col.DataField="Area_m2";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="NoSweeps"; 
			col.DataField="NoSweeps";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="FishSpeciesCd"; 
			col.DataField="FishSpeciesCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="FishSpecies"; 
			col.DataField="FishSpecies";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="FishAgeClass"; 
			col.DataField="FishAgeClass";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="RelativeSizeClass"; 
			col.DataField="RelativeSizeClass";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AveWeight_gm"; 
			col.DataField="AveWeight_gm";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="AveForkLength_cm"; 
			col.DataField="AveForkLength_cm";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AveTotalLength_cm"; 
			col.DataField="AveTotalLength_cm";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Sweep1NoFish"; 
			col.DataField="Sweep1NoFish";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Sweep1Time_s"; 
			col.DataField="Sweep1Time_s";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Sweep2NoFish"; 
			col.DataField="Sweep2NoFish";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Sweep2Time_s"; 
			col.DataField="Sweep2Time_s";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Sweep3NoFish"; 
			col.DataField="Sweep3NoFish";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Sweep3Time_s"; 
			col.DataField="Sweep3Time_s";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Sweep4NoFish"; 
			col.DataField="Sweep4NoFish";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Sweep4Time_s"; 
			col.DataField="Sweep4Time_s";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Sweep5NoFish"; 
			col.DataField="Sweep5NoFish";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Sweep5Time_s"; 
			col.DataField="Sweep5Time_s";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Sweep6NoFish"; 
			col.DataField="Sweep6NoFish";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Sweep6Time_s"; 
			col.DataField="Sweep6Time_s";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="TotalNoFish"; 
			col.DataField="TotalNoFish";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="PercentClipped"; 
			col.DataField="PercentClipped";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AutoCalculatedInd"; 
			col.DataField="AutoCalculatedInd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Formula"; 
			col.DataField="Formula";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Density"; 
			col.DataField="Density";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="PHS"; 
			col.DataField="PHS";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Biomass"; 
			col.DataField="Biomass";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Comments"; 
			col.DataField="Comments";
			dg.Columns.Add(col); 

		}
		private void qryElectrofishingMarkRecaptureDataPlusEstimatesColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="EFMRDataID"; 
			col.DataField="EFMRDataID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Agency2Cd"; 
			col.DataField="Agency2Cd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Agency2Contact"; 
			col.DataField="Agency2Contact";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="Agency2SiteID"; 
			col.DataField="Agency2SiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="HabitatDesc"; 
			col.DataField="HabitatDesc";
			dg.Columns.Add(col); 
						
			col = new BoundColumn();
			col.HeaderText="Method"; 
			col.DataField="Method";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Area_m2"; 
			col.DataField="Area_m2";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="RecaptureTime"; 
			col.DataField="RecaptureTime";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="FishSpeciesCd"; 
			col.DataField="FishSpeciesCd";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="FishSpecies"; 
			col.DataField="FishSpecies";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="FishAgeClass"; 
			col.DataField="FishAgeClass";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AveWeight_gm"; 
			col.DataField="AveWeight_gm";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="AveForkLength_cm"; 
			col.DataField="AveForkLength_cm";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AveTotalLength_cm"; 
			col.DataField="AveTotalLength_cm";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="MarkCount"; 
			col.DataField="MarkCount";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="MarkMarked"; 
			col.DataField="MarkMarked";
			dg.Columns.Add(col); 	

			col = new BoundColumn();
			col.HeaderText="MarkMorts"; 
			col.DataField="MarkMorts";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="RecaptureCount"; 
			col.DataField="RecaptureCount";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="RecaptureUnmarked"; 
			col.DataField="RecaptureUnmarked";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="RecaptureMarked"; 
			col.DataField="RecaptureMarked";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="RecaptureMorts"; 
			col.DataField="RecaptureMorts";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="MarkEfficiency"; 
			col.DataField="MarkEfficiency";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="AutoCalculatedInd"; 
			col.DataField="AutoCalculatedInd";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="Formula"; 
			col.DataField="Formula";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="Density"; 
			col.DataField="Density";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="PHS"; 
			col.DataField="PHS";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="Biomass"; 
			col.DataField="Biomass";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="Comments"; 
			col.DataField="Comments";
			dg.Columns.Add(col); 
		}
		
		private void qryElectrofishingMethodDetailsColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Agency2Cd"; 
			col.DataField="Agency2Cd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Agency2Contact"; 
			col.DataField="Agency2Contact";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Agency2SiteID"; 
			col.DataField="Agency2SiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Time"; 
			col.DataField="Time";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="HabitatDesc"; 
			col.DataField="HabitatDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticMethod"; 
			col.DataField="AquaticMethod";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Device"; 
			col.DataField="Device";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="SiteSetup"; 
			col.DataField="SiteSetup";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="StreamLength_m"; 
			col.DataField="StreamLength_m";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Area_m2"; 
			col.DataField="Area_m2";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="NoSweeps"; 
			col.DataField="NoSweeps";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Voltage"; 
			col.DataField="Voltage";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Frequency_Hz"; 
			col.DataField="Frequency_Hz";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DutyCycle"; 
			col.DataField="DutyCycle";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="POWSetting"; 
			col.DataField="POWSetting";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Comments"; 
			col.DataField="Comments";
			dg.Columns.Add(col); 
		}
		private void qryElectrofishingSiteMeasurementsColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="SiteMeasurementID"; 
			col.DataField="SiteMeasurementID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Agency2Cd"; 
			col.DataField="Agency2Cd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Agency2Contact"; 
			col.DataField="Agency2Contact";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Agency2SiteID"; 
			col.DataField="Agency2SiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Time"; 
			col.DataField="Time";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticMethod"; 
			col.DataField="AquaticMethod";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Measure"; 
			col.DataField="Measure";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="OtherMeasure"; 
			col.DataField="OtherMeasure";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Bank"; 
			col.DataField="Bank";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Instrument"; 
			col.DataField="Instrument";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Measurement"; 
			col.DataField="Measurement";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="UnitOfMeasure"; 
			col.DataField="UnitOfMeasure";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Comments"; 
			col.DataField="Comments";
			dg.Columns.Add(col);
		}

		private void qryElectrofishingSitesColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteDesc"; 
			col.DataField="AquaticSiteDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="HabitatDesc"; 
			col.DataField="HabitatDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateSource"; 
			col.DataField="CoordinateSource";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateSystem"; 
			col.DataField="CoordinateSystem";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="XCoordinate"; 
			col.DataField="XCoordinate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="YCoordinate"; 
			col.DataField="YCoordinate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateUnits"; 
			col.DataField="CoordinateUnits";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataBegins"; 
			col.DataField="DataBegins";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataEnds"; 
			col.DataField="DataEnds";
			dg.Columns.Add(col); 
		}
		
		private void qryElectrofishingWaterMeasurementsColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="WaterMeasurementID"; 
			col.DataField="WaterMeasurementID";
			dg.Columns.Add(col);

			
			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Agency2Contact"; 
			col.DataField="Agency2Contact";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Agency2SiteID"; 
			col.DataField="Agency2SiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="TimeofDay"; 
			col.DataField="TimeofDay";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticMethod"; 
			col.DataField="AquaticMethod";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Measure"; 
			col.DataField="Measure";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Instrument"; 
			col.DataField="Instrument";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="UnitOfMeasure"; 
			col.DataField="UnitOfMeasure";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Comments"; 
			col.DataField="Comments";
			dg.Columns.Add(col);
		}
		private void qryESAObservationsColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="EnvObservationID"; 
			col.DataField="EnvObservationID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col);

			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ObservationGroup"; 
			col.DataField="ObservationGroup";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Observation"; 
			col.DataField="Observation";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="OtherObservation"; 
			col.DataField="OtherObservation";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="PipeSize_cm"; 
			col.DataField="PipeSize_cm";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FishPassageObstructionInd"; 
			col.DataField="FishPassageObstructionInd";
			dg.Columns.Add(col);
		}
		private void qryESAPlanningColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="EnvPlanningID"; 
			col.DataField="EnvPlanningID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="IssueCategory"; 
			col.DataField="IssueCategory";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Issue"; 
			col.DataField="Issue";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ActionRequired"; 
			col.DataField="ActionRequired";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ActionTargetDate"; 
			col.DataField="ActionTargetDate";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ActionPriority"; 
			col.DataField="ActionPriority";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ActionCompletionDate"; 
			col.DataField="ActionCompletionDate";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FollowUpRequired"; 
			col.DataField="FollowUpRequired";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="FollowUpCompletionDate"; 
			col.DataField="FollowUpCompletionDate";
			dg.Columns.Add(col);
		}
		private void qryESASiteMeasurementsColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="FieldMeasureID"; 
			col.DataField="FieldMeasureID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col);
							
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="StreamCover"; 
			col.DataField="StreamCover";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="BankStability"; 
			col.DataField="BankStability";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="BankSlope_Rt"; 
			col.DataField="BankSlope_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="BankSlope_Lt"; 
			col.DataField="BankSlope_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="StreamType"; 
			col.DataField="StreamType";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="OtherStreamType"; 
			col.DataField="OtherStreamType";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="SuspendedSilt"; 
			col.DataField="SuspendedSilt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="EmbeddedSub"; 
			col.DataField="EmbeddedSub";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticPlants"; 
			col.DataField="AquaticPlants";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Algae"; 
			col.DataField="Algae";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Petroleum"; 
			col.DataField="Petroleum";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Odor"; 
			col.DataField="Odor";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Foam"; 
			col.DataField="Foam";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="DeadFish"; 
			col.DataField="DeadFish";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Other"; 
			col.DataField="Other";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="OtherSupp"; 
			col.DataField="OtherSupp";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Length_m"; 
			col.DataField="Length_m";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AveWidth_m"; 
			col.DataField="AveWidth_m";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AveDepth_m"; 
			col.DataField="AveDepth_m";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Velocity_mpers"; 
			col.DataField="Velocity_mpers";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterClarity"; 
			col.DataField="WaterClarity";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterColor"; 
			col.DataField="WaterColor";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Weather_Past"; 
			col.DataField="Weather_Past";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="Weather_Current"; 
			col.DataField="Weather_Current";
			dg.Columns.Add(col);

			
			col = new BoundColumn();
			col.HeaderText="RZ_Lawn_Lt"; 
			col.DataField="RZ_Lawn_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Lawn_Rt"; 
			col.DataField="RZ_Lawn_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_RowCrop_Lt"; 
			col.DataField="RZ_RowCrop_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_RowCrop_Rt"; 
			col.DataField="RZ_RowCrop_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_ForageCrop_Lt"; 
			col.DataField="RZ_ForageCrop_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_ForageCrop_Rt"; 
			col.DataField="RZ_ForageCrop_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Shrubs_Lt"; 
			col.DataField="RZ_Shrubs_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Shrubs_Rt"; 
			col.DataField="RZ_Shrubs_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Hardwood_Lt"; 
			col.DataField="RZ_Hardwood_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Hardwood_Rt"; 
			col.DataField="RZ_Hardwood_Rt";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="RZ_Softwood_Lt"; 
			col.DataField="RZ_Softwood_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Softwood_Rt"; 
			col.DataField="RZ_Softwood_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Mixed_Lt"; 
			col.DataField="RZ_Mixed_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Mixed_Rt"; 
			col.DataField="RZ_Mixed_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Meadow_Lt"; 
			col.DataField="RZ_Meadow_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Meadow_Rt"; 
			col.DataField="RZ_Meadow_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Wetland_Lt"; 
			col.DataField="RZ_Wetland_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Wetland_Rt"; 
			col.DataField="RZ_Wetland_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Altered_Lt"; 
			col.DataField="RZ_Altered_Lt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="RZ_Altered_Rt"; 
			col.DataField="RZ_Altered_Rt";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ST_TimeofDay"; 
			col.DataField="ST_TimeofDay";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ST_DissOxygen"; 
			col.DataField="ST_DissOxygen";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ST_AirTemp_C"; 
			col.DataField="ST_AirTemp_C";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ST_WaterTemp_C"; 
			col.DataField="ST_WaterTemp_C";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="ST_pH"; 
			col.DataField="ST_pH";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ST_Conductivity"; 
			col.DataField="ST_Conductivity";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ST_Flow_cms"; 
			col.DataField="ST_Flow_cms";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="ST_DELGFieldNo"; 
			col.DataField="ST_DELGFieldNo";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW1_TimeofDay"; 
			col.DataField="GW1_TimeofDay";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW1_DissOxygen"; 
			col.DataField="GW1_DissOxygen";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW1_AirTemp_C"; 
			col.DataField="GW1_AirTemp_C";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW1_WaterTemp_C"; 
			col.DataField="GW1_WaterTemp_C";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW1_pH"; 
			col.DataField="GW1_pH";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW1_Conductivity"; 
			col.DataField="GW1_Conductivity";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW1_Flow_cms"; 
			col.DataField="GW1_Flow_cms";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW1_DELGFieldNo"; 
			col.DataField="GW1_DELGFieldNo";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="GW2_TimeofDay"; 
			col.DataField="GW2_TimeofDay";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW2_DissOxygen"; 
			col.DataField="GW2_DissOxygen";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW2_AirTemp_C"; 
			col.DataField="GW2_AirTemp_C";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW2_WaterTemp_C"; 
			col.DataField="GW2_WaterTemp_C";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW2_pH"; 
			col.DataField="GW2_pH";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW2_Conductivity"; 
			col.DataField="GW2_Conductivity";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW2_Flow_cms"; 
			col.DataField="GW2_Flow_cms";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="GW2_DELGFieldNo"; 
			col.DataField="GW2_DELGFieldNo";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Comments"; 
			col.DataField="Comments";
			dg.Columns.Add(col);
		}

		private void qryESASitesColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col); 
			
			
			col = new BoundColumn();
			col.HeaderText="SiteType"; 
			col.DataField="SiteType";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="NoActionItems"; 
			col.DataField="NoActionItems";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="NoCompleted"; 
			col.DataField="NoCompleted";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="NoFollowUp"; 
			col.DataField="NoFollowUp";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateSource"; 
			col.DataField="CoordinateSource";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateSystem"; 
			col.DataField="CoordinateSystem";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="XCoordinate"; 
			col.DataField="XCoordinate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="YCoordinate"; 
			col.DataField="YCoordinate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateUnits"; 
			col.DataField="CoordinateUnits";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataBegins"; 
			col.DataField="DataBegins";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataEnds"; 
			col.DataField="DataEnds";
			dg.Columns.Add(col); 
		}		
		
		private void qryFishStockingColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="FishStockingID"; 
			col.DataField="FishStockingID";
			dg.Columns.Add(col);

			
			col = new BoundColumn();
			col.HeaderText="PermitNo"; 
			col.DataField="PermitNo";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Location"; 
			col.DataField="Location";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Agency2Cd"; 
			col.DataField="Agency2Cd";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="Agency2Contact"; 
			col.DataField="Agency2Contact";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Agency2SiteID"; 
			col.DataField="Agency2SiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Crew"; 
			col.DataField="Crew";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="TimeofDay"; 
			col.DataField="TimeofDay";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WaterTemp_C"; 
			col.DataField="WaterTemp_C";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AirTemp_C"; 
			col.DataField="AirTemp_C";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="WaterLevel"; 
			col.DataField="WaterLevel";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FishSpeciesCd"; 
			col.DataField="FishSpeciesCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FishSpecies"; 
			col.DataField="FishSpecies";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FishStockName"; 
			col.DataField="FishStockName";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FishAge"; 
			col.DataField="FishAge";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AgeUnitOfMeasure"; 
			col.DataField="AgeUnitOfMeasure";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FishAgeClass"; 
			col.DataField="FishAgeClass";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="BroodstockInd"; 
			col.DataField="BroodstockInd";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="NoFish"; 
			col.DataField="NoFish";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AveLength_cm"; 
			col.DataField="AveLength_cm";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="LengthRange_cm"; 
			col.DataField="LengthRange_cm";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AveWeight_gm"; 
			col.DataField="AveWeight_gm";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="WeightRange_gm"; 
			col.DataField="WeightRange_gm";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="AppliedMarkCd"; 
			col.DataField="AppliedMarkCd";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FishMark"; 
			col.DataField="FishMark";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="SatelliteRearedInd"; 
			col.DataField="SatelliteRearedInd";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="Source"; 
			col.DataField="Source";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="FishTankNo"; 
			col.DataField="FishTankNo";
			dg.Columns.Add(col);
		}
		private void qryFishStockingSitesColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="Location"; 
			col.DataField="Location";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteDesc"; 
			col.DataField="AquaticSiteDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="HabitatDesc"; 
			col.DataField="HabitatDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateSource"; 
			col.DataField="CoordinateSource";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateSystem"; 
			col.DataField="CoordinateSystem";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="XCoordinate"; 
			col.DataField="XCoordinate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="YCoordinate"; 
			col.DataField="YCoordinate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateUnits"; 
			col.DataField="CoordinateUnits";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataBegins"; 
			col.DataField="DataBegins";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataEnds"; 
			col.DataField="DataEnds";
			dg.Columns.Add(col); 
		}
		
		private void qryWaterTempertureLoggerDetailsColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="TemperatureLoggerID"; 
			col.DataField="TemperatureLoggerID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteName"; 
			col.DataField="AquaticSiteName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			
			col = new BoundColumn();
			col.HeaderText="HabitatDesc"; 
			col.DataField="HabitatDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DistanceFromLeftBank_m"; 
			col.DataField="DistanceFromLeftBank_m";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DistanceFromRightBank_m"; 
			col.DataField="DistanceFromRightBank_m";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterDepth_cm"; 
			col.DataField="WaterDepth_cm";
			dg.Columns.Add(col); 
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="LoggerNo"; 
			col.DataField="LoggerNo";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="BrandName"; 
			col.DataField="BrandName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Model"; 
			col.DataField="Model";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Resolution"; 
			col.DataField="Resolution";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Accuracy"; 
			col.DataField="Accuracy";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="TempRange_From"; 
			col.DataField="TempRange_From";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="TempRange_To"; 
			col.DataField="TempRange_To";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataFileName"; 
			col.DataField="DataFileName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="InstallationDate"; 
			col.DataField="InstallationDate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="RemovalDate"; 
			col.DataField="RemovalDate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="RecordingStartDate"; 
			col.DataField="RecordingStartDate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="RecordingEndDate"; 
			col.DataField="RecordingEndDate";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="SampleInterval_min"; 
			col.DataField="SampleInterval_min";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Install_WaterTemp_C"; 
			col.DataField="Install_WaterTemp_C";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Install_AirTemp_C"; 
			col.DataField="Install_AirTemp_C";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Install_TimeofDay"; 
			col.DataField="Install_TimeofDay";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Removal_WaterTemp_C"; 
			col.DataField="Removal_WaterTemp_C";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Removal_AirTemp_C"; 
			col.DataField="Removal_AirTemp_C";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="Removal_TimeofDay"; 
			col.DataField="Removal_TimeofDay";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterLevel_Install"; 
			col.DataField="WaterLevel_Install";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterLevel_Removal"; 
			col.DataField="WaterLevel_Removal";
			dg.Columns.Add(col); 
		}

		private void qryWaterTempertureLoggerMeasurementsColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="TemperatureLoggerID"; 
			col.DataField="TemperatureLoggerID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="AquaticActivityID"; 
			col.DataField="AquaticActivityID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteName"; 
			col.DataField="AquaticSiteName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="Date"; 
			col.DataField="Date";
			dg.Columns.Add(col);

			col = new BoundColumn();
			col.HeaderText="AveTemp_C"; 
			col.DataField="AveTemp_C";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="MinTemp_C"; 
			col.DataField="";
			dg.Columns.Add(col);
			
			col = new BoundColumn();
			col.HeaderText="MaxTemp_C"; 
			col.DataField="MaxTemp_C";
			dg.Columns.Add(col);
		}

		private void qryWaterTemperatureLoggerSitesColumns(System.Web.UI.WebControls.DataGrid dg)
		{
			dg.Columns.Clear();

			BoundColumn col;

			col = new BoundColumn();
			col.HeaderText="AquaticSiteID"; 
			col.DataField="AquaticSiteID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="WaterBodyID"; 
			col.DataField="WaterBodyID";
			dg.Columns.Add(col); 

			col = new BoundColumn();
			col.HeaderText="WaterBodyName"; 
			col.DataField="WaterBodyName";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DrainageCd"; 
			col.DataField="DrainageCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencyCd"; 
			col.DataField="AgencyCd";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AgencySiteID"; 
			col.DataField="AgencySiteID";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="AquaticSiteDesc"; 
			col.DataField="AquaticSiteDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="HabitatDesc"; 
			col.DataField="HabitatDesc";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateSource"; 
			col.DataField="CoordinateSource";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateSystem"; 
			col.DataField="CoordinateSystem";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="XCoordinate"; 
			col.DataField="XCoordinate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="YCoordinate"; 
			col.DataField="YCoordinate";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="CoordinateUnits"; 
			col.DataField="CoordinateUnits";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataBegins"; 
			col.DataField="DataBegins";
			dg.Columns.Add(col); 
			
			col = new BoundColumn();
			col.HeaderText="DataEnds"; 
			col.DataField="DataEnds";
			dg.Columns.Add(col); 
		}		
		#endregion

		private void ClearControls(Control control)
		{
			//http://www.c-sharpcorner.com/Code/2003/Sept/ExportASPNetDataGridToExcel.asp
		

			/*
			 * There's just one thing to take care of. A run-time error occurs if the 
			 * DataGrid contains any controls other than the LiteralControl. This means 
			 * that enabling Sorting, Paging or adding Template Columnns or Button columns 
			 * to the datagrid can cause an error. There are several approaches to 
			 * workaround this limitation. We will remove all the non-Literal controls in 
			 * the DataGrid and replace the controls with a text representation , where 
			 * possible. To do so, we will make use of Reflection. instead of querying each 
			 * type of control and working out a replacement.
			 * 
			 * For all controls that have a SelectedItem property, we replace the control 
			 * with the literal value of the SelectedItem property of the control. This 
			 * covers most lists. For all controls that have a Text property, we replace 
			 * the control with the literal value of the Text property of the control. This 
			 * covers TextBox, Buttons, Button Columns, TemplateColumns. We make an exception 
			 * only for TableCell controls. This takes care of most of the cases and you can 
			 * add more checks and balances as required. The only drawback for this 
			 * generalised formula is the order of the controls within a single cell could 
			 * get changed.
			*/
			
			for (int i=control.Controls.Count -1; i>=0; i--)
			{
				ClearControls(control.Controls[i]);
			}

			if (!(control is TableCell))
			{
				if (control.GetType().GetProperty("SelectedItem") != null)
				{
					LiteralControl literal = new LiteralControl();
					control.Parent.Controls.Add(literal);
					try
					{
						literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control,null);
					}
					catch
					{
					}
					control.Parent.Controls.Remove(control);
				}
				else
					if (control.GetType().GetProperty("Text") != null)
				{
					LiteralControl literal = new LiteralControl();
					control.Parent.Controls.Add(literal);
					literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control,null);
					control.Parent.Controls.Remove(control);
				}
			}
			return;
		}


		private void ExportToExcel(System.Web.UI.WebControls.DataGrid dg)
		{
			//export to excel

			Debug.WriteLine("trying to export");

			try
			{
				Response.Clear();
				Response.Buffer= true;
				Response.ContentType = "application/vnd.ms-excel";
				Response.Charset = "";
				this.EnableViewState = false;

				System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
				System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
	
				dg.RenderControl(oHtmlTextWriter);

				Response.Write(oStringWriter.ToString());

				Response.End();		
			}
			catch(Exception e)
			{	
				Debug.WriteLine("ERROR: "+e.ToString());
			}

			//export to excel

			/*
			Response.Clear();
			Response.Buffer= true;
			//Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
			Response.ContentType = "application/vnd.ms-excel";
			Response.Charset = "";
			this.EnableViewState = false;

			System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);

			//System.IO.StringWriter oStringWriter2 = new System.IO.StringWriter();
			//System.Web.UI.HtmlTextWriter oHtmlTextWriter2 = new System.Web.UI.HtmlTextWriter(oStringWriter2);

			//this.ClearControls(dgTemperatureLoggerSites);
			//oStringWriter1.GetStringBuilder().Append("<meta name='Excel Workbook Frameset'><meta http-equiv=Content-Type content='text/html; charset=windows-1252'><meta name=ProgId content=Excel.Sheet><meta name=Generator content='Microsoft Excel 9'><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>NewSheet1</x:Name>");
			
			dgTemperatureLoggerSites.RenderControl(oHtmlTextWriter1);
			//oStringWriter1.GetStringBuilder().Append("</x:ExcelWorksheet><x:ExcelWorksheet><x:Name>NewSheet2</x:Name>");
			dgTemperatureLoggerDetails.RenderControl(oHtmlTextWriter1);	
			//oStringWriter1.GetStringBuilder().Append("</x:ExcelWorkSheet></x:ExcelWorksheets></x:ExcelWorkbook></xml>");
			
			//Debug.WriteLine(oStringWriter1.ToString());
			Response.Write(oStringWriter1.ToString());
			//Response.Write(oStringWriter1.ToString());
			Response.End();	
			*/
		}		
	}
}
