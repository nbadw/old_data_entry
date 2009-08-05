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
	/// Summary description for TemperatureRecordingSites_AddNew.
	/// </summary>
	public partial class ESAFSiteIdentification : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticSites;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticSiteAgencyUse;
		protected NBADWDataEntryApplication.dstblAquaticSite objdsAquaticSites;
		protected NBADWDataEntryApplication.dsSiteUse objdsSiteUse;
		protected NBADWDataEntryApplication.dsWatersheds objdsWatersheds;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaWatersheds;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
				
		//validation expressions and error messages
		private string veDMSX = "[-]\\d\\d\\s\\d\\d\\s\\d\\d([.]{1}\\d{1,6}){0,1}";//degrees minutes seconds
		private string veDMSY = "\\d\\d\\s\\d\\d\\s\\d\\d([.]{1}\\d{1,6}){0,1}";
		private string emDMSX = "Data must be of the form -## ## ##.##";
		private string emDMSY = "Data must be of the form ## ## ##.##";
		private string veDDMX = "[-]\\d\\d\\s\\d\\d[.]\\d{0,6}";//degrees decimal minutes
		private string veDDMY = "\\d\\d\\s\\d\\d[.]\\d{0,6}";//degrees decimal minutes
		private string emDDMX = "Data must be of the form -## ##.#####";
		private string emDDMY = "Data must be of the form ## ##.#####";
		private string veDDX = "[-]\\d\\d[.]\\d{0,6}";//decimal degrees
		private string veDDY = "\\d\\d[.]\\d{0,6}";//decimal degrees
		private string emDDX = "Data must be of the form -##.#####";
		private string emDDY = "Data must be of the form ##.#####";
		private string veM = "\\d{1,}[.]\\d{0,2}";
		private string emM = "Data must be of the form ##.##";

		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		protected System.Data.DataView dvWatersheds;
		protected System.Data.DataView dvSiteUse;
		protected System.Data.DataView dvtblAquaticSite;
		

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				try 
				{
					this.LoadDataSet();
					//dlstWaterBodyID.DataBind();
					//dlstWaterBodyID.SelectedIndex=-1;
					//dlstSystem.Items.Add(new ListItem(strItem, strValue)
					dlstSource.Items.Add(new ListItem("",""));
					dlstSource.Items.Add(new ListItem("GPS"));
					dlstSource.Items.Add(new ListItem("1:50,000 NTS topographic map"));
					dlstSource.Items.Add(new ListItem("GIS"));
					dlstSource.SelectedIndex = 0;
					
					/*
                    dlstSystem.Items.Add(new ListItem("NAD27","1"));
					dlstSystem.Items.Add(new ListItem("NAD83","2"));
					dlstSystem.Items.Add(new ListItem("WGS84","3"));
					dlstSystem.Items.Add(new ListItem("UTM-NAD27 ZONE 19","4"));
					dlstSystem.Items.Add(new ListItem("UTM-NAD27 ZONE 20","5"));
					dlstSystem.Items.Add(new ListItem("UTM-NAD83 ZONE 19","6"));
					dlstSystem.Items.Add(new ListItem("UTM-NAD83 ZONE 20","7"));
					dlstSystem.Items.Add(new ListItem("UTM-WGS84 ZONE 19","8"));
					dlstSystem.Items.Add(new ListItem("UTM-WGS84 ZONE 20","9"));
					dlstSystem.Items.Add(new ListItem("ATS77 NB Stereographic","10"));
					dlstSystem.Items.Add(new ListItem("NAD83 (CSRS) NB Stereographic","11"));
					
					SetCoordinateFields("");
				*/
					
				}
				catch (System.Exception eLoad) 
				{
					this.Response.Write(eLoad.Message);
				}
				
				try
				{
					if((bool)Session["Modify"])
					{
						FillFields();
						btnNext.Visible = false;
						btnCancel2.Visible = false;
						btnSave.Visible = true;
						btnCancel.Visible = true;

						//Set Labels
						lblh2.Text = "EDIT Assessment";
						lblStep.Visible = false;
					}
				}
				catch
				{
					//do nothing
					Debug.WriteLine("Error while filling fields");
				}

				try
				{
					if(Session["SelectedWaterBodyID"].ToString()!="")
					{
						//create a dataview and fill appropriate fields
						//Debug.WriteLine("waterid" +Session["SelectedWaterBodyID"].ToString());
						SetValues();
					}
				}
				catch//(Exception ex)
				{
					//Debug.WriteLine("session wasn't set" + ex.ToString());
				}
			}
		}

		public void FillFields()
		{
			LoadDataSet();

			int j = dvSiteUse.Find(Session["SelectedSiteUseID"]);
			string AquaticSiteID = dvSiteUse[j]["AquaticSiteID"].ToString();
			txtgroupsiteid.Text = dvSiteUse[j]["AgencySiteID"].ToString();

			int i = dvtblAquaticSite.Find(AquaticSiteID);
			Debug.WriteLine("Looking for waterbodyID");
			j = dvWatersheds.Find(dvtblAquaticSite[i]["WaterBodyID"]);
			Debug.WriteLine("Found the waterbodyid "+j);
			txtwaterbodyid.Text = dvWatersheds[j]["WaterBodyID"].ToString();
			txtwaterbodyname.Text = dvWatersheds[j]["WaterBodyName"].ToString();
			txtwatershed.Text = dvWatersheds[j]["DrainName"].ToString();
			txtwatershedcode.Text = dvWatersheds[j]["DrainageCd"].ToString();
			txtsitename.Text = dvtblAquaticSite[i]["AquaticSiteName"].ToString();
			txtsitedescription.Text = dvtblAquaticSite[i]["AquaticSiteDesc"].ToString();
			SetCoordinateFields(dvtblAquaticSite[i]["CoordinateSource"].ToString(), dvtblAquaticSite[i]["CoordinateSystem"].ToString(), dvtblAquaticSite[i]["CoordinateUnits"].ToString());
			SetValidationFields();
			//SetSource(dvtblAquaticSite[i]["CoordinateSource"].ToString());
			//SetCoordinateFields(dvtblAquaticSite[i]["CoordinateSystem"].ToString());
			//txtSource.Text = dvtblAquaticSite[i]["CoordinateSource"].ToString();
			//txtSystem.Text = dvtblAquaticSite[i]["CoordinateSystem"].ToString();
			//txtUnits.Text = dvtblAquaticSite[i]["CoordinateUnits"].ToString();
			txtX.Text = dvtblAquaticSite[i]["XCoordinate"].ToString();
			txtY.Text = dvtblAquaticSite[i]["YCoordinate"].ToString();
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

		#region Fill & Load
		public void FillDataSet(NBADWDataEntryApplication.dstblAquaticSite dataSet1, NBADWDataEntryApplication.dsSiteUse dataSet2, NBADWDataEntryApplication.dsWatersheds dataSet3)
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
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdatblAquaticSites.Fill(dataSet1);
				this.oleDbdatblAquaticSiteAgencyUse.Fill(dataSet2);
				this.oleDbdaWatersheds.Fill(dataSet3);
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


		public void LoadDataSet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblAquaticSite objDataSetTemp1;
			NBADWDataEntryApplication.dsSiteUse objDataSetTemp2;
			NBADWDataEntryApplication.dsWatersheds objDataSetTemp3;
			objDataSetTemp1 = new NBADWDataEntryApplication.dstblAquaticSite();
			objDataSetTemp2 = new NBADWDataEntryApplication.dsSiteUse();
			objDataSetTemp3 = new NBADWDataEntryApplication.dsWatersheds();

			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDataSet(objDataSetTemp1, objDataSetTemp2, objDataSetTemp3);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsAquaticSites.Clear();
				objdsSiteUse.Clear();
				objdsWatersheds.Clear();
				// Merge the records into the main dataset.
				objdsAquaticSites.Merge(objDataSetTemp1);
				objdsSiteUse.Merge(objDataSetTemp2);
				objdsWatersheds.Merge(objDataSetTemp3);
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
			this.oleDbdatblAquaticSites = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdatblAquaticSiteAgencyUse = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdsAquaticSites = new NBADWDataEntryApplication.dstblAquaticSite();
			this.objdsSiteUse = new NBADWDataEntryApplication.dsSiteUse();
			this.oleDbdaWatersheds = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdsWatersheds = new NBADWDataEntryApplication.dsWatersheds();
			this.dvWatersheds = new System.Data.DataView();
			this.dvSiteUse = new System.Data.DataView();
			this.dvtblAquaticSite = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.objdsAquaticSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsSiteUse)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsWatersheds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvWatersheds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvSiteUse)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblAquaticSite)).BeginInit();
			// 
			// oleDbdatblAquaticSites
			// 
			this.oleDbdatblAquaticSites.DeleteCommand = this.oleDbDeleteCommand4;
			this.oleDbdatblAquaticSites.InsertCommand = this.oleDbInsertCommand5;
			this.oleDbdatblAquaticSites.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbdatblAquaticSites.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "tblAquaticSite", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																							   new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																							   new System.Data.Common.DataColumnMapping("AquaticSiteName", "AquaticSiteName"),
																																																							   new System.Data.Common.DataColumnMapping("CoordinateSource", "CoordinateSource"),
																																																							   new System.Data.Common.DataColumnMapping("CoordinateSystem", "CoordinateSystem"),
																																																							   new System.Data.Common.DataColumnMapping("CoordinateUnits", "CoordinateUnits"),
																																																							   new System.Data.Common.DataColumnMapping("DateEntered", "DateEntered"),
																																																							   new System.Data.Common.DataColumnMapping("EndDesc", "EndDesc"),
																																																							   new System.Data.Common.DataColumnMapping("EndRouteMeas", "EndRouteMeas"),
																																																							   new System.Data.Common.DataColumnMapping("GeoReferencedInd", "GeoReferencedInd"),
																																																							   new System.Data.Common.DataColumnMapping("HabitatDesc", "HabitatDesc"),
																																																							   new System.Data.Common.DataColumnMapping("IncorporatedInd", "IncorporatedInd"),
																																																							   new System.Data.Common.DataColumnMapping("oldAquaticSiteID", "oldAquaticSiteID"),
																																																							   new System.Data.Common.DataColumnMapping("ReachNo", "ReachNo"),
																																																							   new System.Data.Common.DataColumnMapping("RiverSystemID", "RiverSystemID"),
																																																							   new System.Data.Common.DataColumnMapping("SpecificSiteInd", "SpecificSiteInd"),
																																																							   new System.Data.Common.DataColumnMapping("StartDesc", "StartDesc"),
																																																							   new System.Data.Common.DataColumnMapping("StartRouteMeas", "StartRouteMeas"),
																																																							   new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																							   new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																							   new System.Data.Common.DataColumnMapping("XCoordinate", "XCoordinate"),
																																																							   new System.Data.Common.DataColumnMapping("YCoordinate", "YCoordinate")})});
			this.oleDbdatblAquaticSites.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = @"DELETE FROM tblAquaticSite WHERE (AquaticSiteID = ?) AND (AquaticSiteDesc = ? OR ? IS NULL AND AquaticSiteDesc IS NULL) AND (AquaticSiteName = ? OR ? IS NULL AND AquaticSiteName IS NULL) AND (CoordinateSource = ? OR ? IS NULL AND CoordinateSource IS NULL) AND (CoordinateSystem = ? OR ? IS NULL AND CoordinateSystem IS NULL) AND (CoordinateUnits = ? OR ? IS NULL AND CoordinateUnits IS NULL) AND (DateEntered = ? OR ? IS NULL AND DateEntered IS NULL) AND (EndDesc = ? OR ? IS NULL AND EndDesc IS NULL) AND (EndRouteMeas = ? OR ? IS NULL AND EndRouteMeas IS NULL) AND (GeoReferencedInd = ? OR ? IS NULL AND GeoReferencedInd IS NULL) AND (HabitatDesc = ? OR ? IS NULL AND HabitatDesc IS NULL) AND (IncorporatedInd = ?) AND (ReachNo = ? OR ? IS NULL AND ReachNo IS NULL) AND (RiverSystemID = ? OR ? IS NULL AND RiverSystemID IS NULL) AND (SpecificSiteInd = ? OR ? IS NULL AND SpecificSiteInd IS NULL) AND (StartDesc = ? OR ? IS NULL AND StartDesc IS NULL) AND (StartRouteMeas = ? OR ? IS NULL AND StartRouteMeas IS NULL) AND (WaterBodyID = ? OR ? IS NULL AND WaterBodyID IS NULL) AND (WaterBodyName = ? OR ? IS NULL AND WaterBodyName IS NULL) AND (XCoordinate = ? OR ? IS NULL AND XCoordinate IS NULL) AND (YCoordinate = ? OR ? IS NULL AND YCoordinate IS NULL) AND (oldAquaticSiteID = ? OR ? IS NULL AND oldAquaticSiteID IS NULL)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc1", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
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
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = @"INSERT INTO tblAquaticSite(AquaticSiteDesc, AquaticSiteID, AquaticSiteName, CoordinateSource, CoordinateSystem, CoordinateUnits, DateEntered, EndDesc, EndRouteMeas, GeoReferencedInd, HabitatDesc, IncorporatedInd, oldAquaticSiteID, ReachNo, RiverSystemID, SpecificSiteInd, StartDesc, StartRouteMeas, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "EndDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "EndRouteMeas"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, "GeoReferencedInd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReachNo", System.Data.OleDb.OleDbType.Integer, 0, "ReachNo"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, "RiverSystemID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, "SpecificSiteInd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "StartDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "StartRouteMeas"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = @"SELECT AquaticSiteDesc, AquaticSiteID, AquaticSiteName, CoordinateSource, CoordinateSystem, CoordinateUnits, DateEntered, EndDesc, EndRouteMeas, GeoReferencedInd, HabitatDesc, IncorporatedInd, oldAquaticSiteID, ReachNo, RiverSystemID, SpecificSiteInd, StartDesc, StartRouteMeas, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate FROM tblAquaticSite";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE tblAquaticSite SET AquaticSiteDesc = ?, AquaticSiteID = ?, AquaticSiteName" +
				" = ?, CoordinateSource = ?, CoordinateSystem = ?, CoordinateUnits = ?, DateEnter" +
				"ed = ?, EndDesc = ?, EndRouteMeas = ?, GeoReferencedInd = ?, HabitatDesc = ?, In" +
				"corporatedInd = ?, oldAquaticSiteID = ?, ReachNo = ?, RiverSystemID = ?, Specifi" +
				"cSiteInd = ?, StartDesc = ?, StartRouteMeas = ?, WaterBodyID = ?, WaterBodyName " +
				"= ?, XCoordinate = ?, YCoordinate = ? WHERE (AquaticSiteID = ?) AND (AquaticSite" +
				"Desc = ? OR ? IS NULL AND AquaticSiteDesc IS NULL) AND (AquaticSiteName = ? OR ?" +
				" IS NULL AND AquaticSiteName IS NULL) AND (CoordinateSource = ? OR ? IS NULL AND" +
				" CoordinateSource IS NULL) AND (CoordinateSystem = ? OR ? IS NULL AND Coordinate" +
				"System IS NULL) AND (CoordinateUnits = ? OR ? IS NULL AND CoordinateUnits IS NUL" +
				"L) AND (DateEntered = ? OR ? IS NULL AND DateEntered IS NULL) AND (EndDesc = ? O" +
				"R ? IS NULL AND EndDesc IS NULL) AND (EndRouteMeas = ? OR ? IS NULL AND EndRoute" +
				"Meas IS NULL) AND (GeoReferencedInd = ? OR ? IS NULL AND GeoReferencedInd IS NUL" +
				"L) AND (HabitatDesc = ? OR ? IS NULL AND HabitatDesc IS NULL) AND (IncorporatedI" +
				"nd = ?) AND (ReachNo = ? OR ? IS NULL AND ReachNo IS NULL) AND (RiverSystemID = " +
				"? OR ? IS NULL AND RiverSystemID IS NULL) AND (SpecificSiteInd = ? OR ? IS NULL " +
				"AND SpecificSiteInd IS NULL) AND (StartDesc = ? OR ? IS NULL AND StartDesc IS NU" +
				"LL) AND (StartRouteMeas = ? OR ? IS NULL AND StartRouteMeas IS NULL) AND (WaterB" +
				"odyID = ? OR ? IS NULL AND WaterBodyID IS NULL) AND (WaterBodyName = ? OR ? IS N" +
				"ULL AND WaterBodyName IS NULL) AND (XCoordinate = ? OR ? IS NULL AND XCoordinate" +
				" IS NULL) AND (YCoordinate = ? OR ? IS NULL AND YCoordinate IS NULL) AND (oldAqu" +
				"aticSiteID = ? OR ? IS NULL AND oldAquaticSiteID IS NULL)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "EndDesc"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "EndRouteMeas"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, "GeoReferencedInd"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReachNo", System.Data.OleDb.OleDbType.Integer, 0, "ReachNo"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, "RiverSystemID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, "SpecificSiteInd"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "StartDesc"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "StartRouteMeas"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc1", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbdatblAquaticSiteAgencyUse
			// 
			this.oleDbdatblAquaticSiteAgencyUse.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbdatblAquaticSiteAgencyUse.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdatblAquaticSiteAgencyUse.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdatblAquaticSiteAgencyUse.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													 new System.Data.Common.DataTableMapping("Table", "tblAquaticSiteAgencyUse", new System.Data.Common.DataColumnMapping[] {
																																																												new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																												new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																												new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																												new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																												new System.Data.Common.DataColumnMapping("AquaticSiteType", "AquaticSiteType"),
																																																												new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																												new System.Data.Common.DataColumnMapping("EndYear", "EndYear"),
																																																												new System.Data.Common.DataColumnMapping("IncorporatedInd", "IncorporatedInd"),
																																																												new System.Data.Common.DataColumnMapping("StartYear", "StartYear"),
																																																												new System.Data.Common.DataColumnMapping("YearsActive", "YearsActive")})});
			this.oleDbdatblAquaticSiteAgencyUse.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = @"DELETE FROM tblAquaticSiteAgencyUse WHERE (AquaticSiteUseID = ?) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AgencySiteID = ? OR ? IS NULL AND AgencySiteID IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (AquaticSiteType = ? OR ? IS NULL AND AquaticSiteType IS NULL) AND (EndYear = ? OR ? IS NULL AND EndYear IS NULL) AND (IncorporatedInd = ?) AND (StartYear = ? OR ? IS NULL AND StartYear IS NULL) AND (YearsActive = ? OR ? IS NULL AND YearsActive IS NULL)";
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteUseID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteUseID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO tblAquaticSiteAgencyUse(AgencyCd, AgencySiteID, AquaticActivityCd, Aq" +
				"uaticSiteID, AquaticSiteType, EndYear, IncorporatedInd, StartYear, YearsActive) " +
				"VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticSiteType"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, "YearsActive"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivityCd, AquaticSiteID, AquaticSiteType," +
				" AquaticSiteUseID, EndYear, IncorporatedInd, StartYear, YearsActive FROM tblAqua" +
				"ticSiteAgencyUse";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = @"UPDATE tblAquaticSiteAgencyUse SET AgencyCd = ?, AgencySiteID = ?, AquaticActivityCd = ?, AquaticSiteID = ?, AquaticSiteType = ?, EndYear = ?, IncorporatedInd = ?, StartYear = ?, YearsActive = ? WHERE (AquaticSiteUseID = ?) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AgencySiteID = ? OR ? IS NULL AND AgencySiteID IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (AquaticSiteType = ? OR ? IS NULL AND AquaticSiteType IS NULL) AND (EndYear = ? OR ? IS NULL AND EndYear IS NULL) AND (IncorporatedInd = ?) AND (StartYear = ? OR ? IS NULL AND StartYear IS NULL) AND (YearsActive = ? OR ? IS NULL AND YearsActive IS NULL)";
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticSiteType"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, "YearsActive"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteUseID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteUseID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			// 
			// objdsAquaticSites
			// 
			this.objdsAquaticSites.DataSetName = "dsAquaticSites";
			this.objdsAquaticSites.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// objdsSiteUse
			// 
			this.objdsSiteUse.DataSetName = "dsSiteUse";
			this.objdsSiteUse.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaWatersheds
			// 
			this.oleDbdaWatersheds.InsertCommand = this.oleDbInsertCommand6;
			this.oleDbdaWatersheds.SelectCommand = this.oleDbSelectCommand6;
			this.oleDbdaWatersheds.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "DE-Watersheds", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																						 new System.Data.Common.DataColumnMapping("DrainName", "DrainName"),
																																																						 new System.Data.Common.DataColumnMapping("Level1Name", "Level1Name"),
																																																						 new System.Data.Common.DataColumnMapping("Level2Name", "Level2Name"),
																																																						 new System.Data.Common.DataColumnMapping("Level3Name", "Level3Name"),
																																																						 new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																						 new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName")})});
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = "INSERT INTO [DE-Watersheds] (DrainageCd, DrainName, Level1Name, Level2Name, Level" +
				"3Name, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainName", System.Data.OleDb.OleDbType.VarWChar, 255, "DrainName"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level1Name", System.Data.OleDb.OleDbType.VarWChar, 40, "Level1Name"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level2Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level2Name"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level3Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level3Name"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT DrainageCd, DrainName, Level1Name, Level2Name, Level3Name, WaterBodyID, Wa" +
				"terBodyName FROM [DE-Watersheds]";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			// 
			// objdsWatersheds
			// 
			this.objdsWatersheds.DataSetName = "dsWatersheds";
			this.objdsWatersheds.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvWatersheds
			// 
			this.dvWatersheds.Sort = "WaterBodyID";
			this.dvWatersheds.Table = this.objdsWatersheds._DE_Watersheds;
			// 
			// dvSiteUse
			// 
			this.dvSiteUse.Sort = "AquaticSiteUseID";
			this.dvSiteUse.Table = this.objdsSiteUse.tblAquaticSiteAgencyUse;
			// 
			// dvtblAquaticSite
			// 
			this.dvtblAquaticSite.Sort = "AquaticSiteID";
			this.dvtblAquaticSite.Table = this.objdsAquaticSites.tblAquaticSite;
			((System.ComponentModel.ISupportInitialize)(this.objdsAquaticSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsSiteUse)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsWatersheds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvWatersheds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvSiteUse)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblAquaticSite)).EndInit();

		}
		#endregion

		#region SetValues/Fields
		public void SetValues()
		{
			//set the values of the txtboxes
			//note that we need both dataviews (they could be differnt versions of the same 
			//dataset but either way, we need two, one sorted by waterbodyid and one by 
			//waterbodyname.
			DataView dvWatersheds = new DataView(objdsWatersheds.Tables["DE-Watersheds"],"","WaterBodyID", DataViewRowState.CurrentRows);
			int j = dvWatersheds.Find(Session["SelectedWaterBodyID"].ToString());
			Session["SelectedWaterBodyID"] = "";
			/*
			dvFilteredWatersheds.Sort = "WaterBodyName";
			int k = dvFilteredWatersheds.Find(dvWatersheds[j]["WaterBodyName"]);
			if(k>0)//the waterbody was found
			{
				dlstWaterBodyID.SelectedIndex = k;
			}
			else//k=-1 waterbody not found (unnamed)
			{
				k = dvFilteredWatersheds.Find("");
				if(k<0)//blank option wasn't there
				{
					dlstWaterBodyID.Items.Add(new ListItem ("","-1"));
				}
				dlstWaterBodyID.SelectedIndex = dlstWaterBodyID.Items.Count -1;
			}
			*/
			txtwaterbodyid.Text = dvWatersheds[j]["WaterBodyID"].ToString();
			txtwatershed.Text = dvWatersheds[j]["DrainName"].ToString();
			txtwatershedcode.Text = dvWatersheds[j]["DrainageCd"].ToString();
			txtwaterbodyname.Text = dvWatersheds[j]["WaterBodyName"].ToString();
		}

		private void SetCoordinateFields(string strSource, string strSystem, string strUnits)
		{
			fillSystemAndUnits(strSource);
			switch (strSource)
			{
				case "GPS":
					dlstSource.SelectedIndex=1;
					switch (strSystem)
					{
						case "NAD83":
							dlstSystem.SelectedIndex=0;
							break;
						case "WGS84":
							dlstSystem.SelectedIndex=1;
							break;
					}
					switch (strUnits)
					{
						case "Degrees Minutes Seconds":
							dlstUnits.SelectedIndex=0;
							break;
						case "Degrees Decimal Minutes":
							dlstUnits.SelectedIndex=1;
							break;
						case "Decimal Degrees":
							dlstUnits.SelectedIndex=2;
							break;
					}
					break;
				case "1:50,000 NTS topographic map":
					dlstSource.SelectedIndex=2;
					switch (strSystem)
					{
						case "UTM-NAD27 ZONE 19":
							dlstSystem.SelectedIndex=0;
							break;
						case "UTM-NAD27 ZONE 20":
							dlstSystem.SelectedIndex=1;
							break;
						case "UTM-NAD83 ZONE 19":
							dlstSystem.SelectedIndex=2;
							break;
						case "UTM-NAD83 ZONE 20":
							dlstSystem.SelectedIndex=3;
							break;
					}
					break;
				case "GIS":
					dlstSource.SelectedIndex=3;
					switch (strSystem)
					{
						case "ATS77 NB Stereographic":
							dlstSystem.SelectedIndex=0;
							break;
						case "NAD83 (CSRS) NB Stereographic":
							dlstSystem.SelectedIndex=1;
							break;
					}
					break;				
			}
		}

		/*
		private void SetCoordinateFields(string cSystem)
		{
			//set the selected index of the system list
			Debug.WriteLine("Coordinate System: "+cSystem);
			switch (cSystem)
			{
				case "NAD27":
					dlstSystem.SelectedIndex = 0;
					break;
				case "NAD83":
					dlstSystem.SelectedIndex = 1;
					break;
				case "WGS84":
					dlstSystem.SelectedIndex = 2;
					break;
				case "UTM-NAD27 ZONE 19":
					dlstSystem.SelectedIndex = 3;
					break;
				case "UTM-NAD27 ZONE 20":
					dlstSystem.SelectedIndex = 4;
					break;
				case "UTM-NAD83 ZONE 19":
					dlstSystem.SelectedIndex = 5;
					break;
				case "UTM-NAD83 ZONE 20":
					dlstSystem.SelectedIndex = 6;
					break;
				case "UTM-WGS84 ZONE 19":
					dlstSystem.SelectedIndex = 7;
					break;
				case "UTM-WGS84 ZONE 20":
					dlstSystem.SelectedIndex = 8;
					break;
				case "ATS77 NB Stereographic":
					dlstSystem.SelectedIndex = 9;
					break;
				case "NAD83 (CSRS) NB Stereographic":
					dlstSystem.SelectedIndex = 10;
					break;
				default:
					dlstSystem.SelectedIndex = 11;
					break;
			}

			int s = Convert.ToInt32(dlstSystem.SelectedValue);
			Debug.WriteLine("S = "+s);
			dlstUnits.Items.Clear();
			txtX.Enabled = true;
			txtY.Enabled = true;
			//Geographic
			if (s<4)
			{
				dlstUnits.Items.Add(new ListItem("Degrees Minutes Seconds","DMS"));
				dlstUnits.Items.Add(new ListItem("Degrees Decimal Minutes","DDM"));
				dlstUnits.Items.Add(new ListItem("Decimal Degrees","DD"));
				dlstUnits.SelectedIndex = 0;

				lblX.Text = "Longitude:";
				lblY.Text = "Latitude:";

				SetValidationFields();
			}
				//Projected
			else if (s<12)
			{
				dlstUnits.Items.Add(new ListItem("Meters","M"));
				dlstUnits.SelectedIndex = 0;

				//UTM
				if (s<10)
				{
					lblX.Text = "Easting:";
					lblY.Text = "Northing:";
				}
					//Other Projected
				else
				{
					lblX.Text = "X:";
					lblY.Text = "Y:";
				}
				SetValidationFields();
			}
			else//blank entry selected
			{
				ClearXY();
				txtX.Enabled = false;
				txtY.Enabled = false;
			}
		}
*/
		private void SetValidationFields()
		{
			ClearXY();
			string s = dlstUnits.SelectedValue;	
			if (s=="DMS")//degrees minutes seconds
			{
				revX.ErrorMessage = emDMSX;
				revX.ValidationExpression = veDMSX;
				lblFormatX.Text = emDMSX;
				revY.ErrorMessage = emDMSY;
				revY.ValidationExpression = veDMSY;
				lblFormatY.Text = emDMSY;

			}
			else if (s=="DDM")//degrees decimal minutes
			{
				revX.ErrorMessage = emDDMX;
				revX.ValidationExpression = veDDMX;
				lblFormatX.Text = emDDMX;
				revY.ErrorMessage = emDDMY;
				revY.ValidationExpression = veDDMY;
				lblFormatY.Text = emDDMY;
			}
			else if (s=="DD")//decimal degrees
			{
				revX.ErrorMessage = emDDX;
				revX.ValidationExpression = veDDX;
				lblFormatX.Text = emDDX;
				revY.ErrorMessage = emDDY;
				revY.ValidationExpression = veDDY;
				lblFormatY.Text = emDDY;
			}
			else //meters
			{
				revX.ErrorMessage = emM;
				revX.ValidationExpression = veM;
				lblFormatX.Text = emM;
				revY.ErrorMessage = emM;
				revY.ValidationExpression = veM;
				lblFormatY.Text = emM;
			}
		}

		private void ClearXY()
		{
			/*validation won't be done on text already entered so we must clear 
			fields to ensure they are validated ie. if user enters data in txtX 
			or txtY and then changes the units, validation will not be done with
			the new rules*/
			txtX.Text = "";
			txtY.Text = "";
		}

		private void SetSource(string strSource)
		{
			switch (strSource)
			{
				case "GPS":
					dlstSource.SelectedIndex = 1;
					break;
				case "1:50,000 NTS topographic map":
					dlstSource.SelectedIndex = 2;
					break;
				case "GIS":
					dlstSource.SelectedIndex = 3;
					break;
				default:
					dlstSource.SelectedIndex = 0;
					break;
			}
		}

		#endregion
        
		#region IndexChanged
		/*
		private void dlstWaterBodyID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LoadDataSet();
			DataView dvWatersheds = new DataView(objdsWatersheds.Tables["DE-Watersheds"],"","WaterBodyID", DataViewRowState.CurrentRows);
			int j = dvWatersheds.Find(dlstWaterBodyID.SelectedItem.Value);
			//if there is no record found, Find() method returns -1
			if (j>0)
			{
				txtwaterbodyid.Text = dvWatersheds[j]["WaterBodyID"].ToString();
				txtwatershed.Text = dvWatersheds[j]["DrainName"].ToString();
			}
			//rebind to remove the blank entry if there
			int k = dlstWaterBodyID.SelectedIndex;
			dlstWaterBodyID.DataBind();
			dlstWaterBodyID.SelectedIndex = k;
			
		}
		

		private void dlstSystem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Debug.WriteLine("Index has changed");
			SetCoordinateFields(dlstSystem.SelectedItem.ToString());
		}
*/
		protected void dlstUnits_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			SetValidationFields();
		}

		protected void txtwaterbodyid_TextChanged(object sender, System.EventArgs e)
		{
			lblwbMessage.Visible = false;
			//verify that the waterbodyid picked is a valid id.  If not, erase text.  \
			//if valid, set watername and watershed on form
			LoadDataSet();
			DataView dvWatersheds = new DataView(objdsWatersheds.Tables["DE-Watersheds"],"","WaterBodyID", DataViewRowState.CurrentRows);
			try//this won't work if user enters a string value
			{
				int j = dvWatersheds.Find(txtwaterbodyid.Text);
				if (j>0)
				{
					Session["SelectedWaterBodyID"] = txtwaterbodyid.Text;
					SetValues();
				}
				else//waterbody not found
				{
					txtwaterbodyid.Text = "";
					txtwatershed.Text = "";
					txtwatershedcode.Text = "";
					txtwaterbodyname.Text = "";
					lblwbMessage.Visible = true;
					//dlstWaterBodyID.SelectedIndex = -1;
				}
			}
			catch//waterbody not found
			{
				txtwaterbodyid.Text = "";
				txtwatershed.Text = "";
				txtwatershedcode.Text = "";
				txtwaterbodyname.Text = "";
				lblwbMessage.Visible = true;
				//dlstWaterBodyID.SelectedIndex = -1;
			}
		}

		protected void dlstSource_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillSystemAndUnits(dlstSource.SelectedItem.ToString());		
		}

		private void fillSystemAndUnits(string src)
		{
			dlstSystem.Items.Clear();
			dlstUnits.Items.Clear();

			switch (src)
			{
				case "GPS":
					dlstSystem.Items.Add(new ListItem("NAD83","2"));
					dlstSystem.Items.Add(new ListItem("WGS84","3"));
					dlstSystem.SelectedIndex = dlstSystem.Items.Count-1;

					dlstUnits.Items.Add(new ListItem("Degrees Minutes Seconds","DMS"));
					dlstUnits.Items.Add(new ListItem("Degrees Decimal Minutes","DDM"));
					dlstUnits.Items.Add(new ListItem("Decimal Degrees","DD"));
					dlstUnits.SelectedIndex = 0;

					lblX.Text = "Longitude:";
					lblY.Text = "Latitude:";

					SetValidationFields();
					break;
				case "1:50,000 NTS topographic map":
					dlstSystem.Items.Add(new ListItem("UTM-NAD27 ZONE 19","4"));
					dlstSystem.Items.Add(new ListItem("UTM-NAD27 ZONE 20","5"));
					dlstSystem.Items.Add(new ListItem("UTM-NAD83 ZONE 19","6"));
					dlstSystem.Items.Add(new ListItem("UTM-NAD83 ZONE 20","7"));
					dlstSystem.SelectedIndex = 0;

					dlstUnits.Items.Add(new ListItem("Meters","M"));
					dlstUnits.SelectedIndex = 0;

					lblX.Text = "Easting:";
					lblY.Text = "Northing:";

					SetValidationFields();
					break;
				case "GIS":
					dlstSystem.Items.Add(new ListItem("ATS77 NB Stereographic","10"));
					dlstSystem.Items.Add(new ListItem("NAD83 (CSRS) NB Stereographic","11"));
					dlstSystem.SelectedIndex = 1;

					dlstUnits.Items.Add(new ListItem("Meters","M"));
					dlstUnits.SelectedIndex = 0;

					lblX.Text = "X:";
					lblY.Text = "Y:";	

					SetValidationFields();
					break;
				default:
					dlstSystem.Items.Clear();
					dlstUnits.Items.Clear();
					break;
			}
		}     

		#endregion

		#region Buttons
		protected void btnSearchWaterbodyID_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "ESAFSiteIdentification.aspx";
			Server.Transfer("Waterbodies-Search.aspx");
		}

		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			this.LoadDataSet();
			DataTable tSites = objdsAquaticSites.Tables["tblAquaticSite"];
			DataTable tSiteUse = objdsSiteUse.Tables["tblAquaticSiteAgencyUse"];

			DataRow rSites = tSites.NewRow();
			DataRow rSiteUse = tSiteUse.NewRow();
			
			//DataView dvSites = new DataView(objdsAquaticSites.Tables["tblAquaticSite"],"","AquaticSiteID", DataViewRowState.CurrentRows);
			int i = FindBiggest(tSites,"AquaticSiteID");
			rSites["AquaticSiteID"] = i+1;
			Session["SelectedSiteID"] = i+1;
			rSites["WaterBodyID"] = txtwaterbodyid.Text;
			Debug.WriteLine("The string is "+txtwaterbodyname.Text.Length+" char long");
			if(txtwaterbodyname.Text.Length>0)
			{
				rSites["WaterBodyName"] = txtwaterbodyname.Text;
			}
			rSites["DateEntered"] = System.DateTime.Now;
			if(txtsitename.Text.Length>0)
			{
				rSites["AquaticSiteName"] = txtsitename.Text;
			}
			rSites["AquaticSiteDesc"] = txtsitedescription.Text;
			rSites["CoordinateSource"] = dlstSource.SelectedItem;
			rSites["CoordinateSystem"] = dlstSystem.SelectedItem;
			rSites["CoordinateUnits"] = dlstUnits.SelectedItem;
			rSites["XCoordinate"] = txtX.Text;
			rSites["YCoordinate"] = txtY.Text;	
			rSites["IncorporatedInd"] = false;

			rSiteUse["AquaticSiteID"] = i+1;
			rSiteUse["AgencyCd"] = Session["UserAgency"].ToString();
			if(txtgroupsiteid.Text.Length>0)
			{
				rSiteUse["AgencySiteID"] = txtgroupsiteid.Text;
			}
			rSiteUse["AquaticActivityCd"] = 29;
			rSiteUse["IncorporatedInd"] = false;

			tSites.Rows.Add(rSites);
			tSiteUse.Rows.Add(rSiteUse);
			
			try
			{
				//Must change autogenerated update procedure for this to work.  
				//click on elipsis ... in update property of adapter, command text field
				oleDbdatblAquaticSites.Update(objdsAquaticSites);
				oleDbdatblAquaticSiteAgencyUse.Update(objdsSiteUse);
				Server.Transfer("ESAFSurveyInfo.aspx");
			}
			catch (System.Exception eUpdate)
			{
				// Error during Update, add code to locate error, reconcile 
				// and try to update again.
				Debug.WriteLine("something went wrong with the update" + eUpdate);
			}			
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFView.aspx");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string strSiteValues = "";
			string strUseValues = "";
			strSiteValues += "WaterBodyID = "+txtwaterbodyid.Text;
			if(txtwaterbodyname.Text!="")
			{
				strSiteValues += ", WaterBodyName = '" + txtwaterbodyname.Text+"'";
			}
			if(txtsitename.Text!="")
			{
				strSiteValues += ", AquaticSiteName = '" + txtsitename.Text+"'";
			}
			strSiteValues += ", AquaticSiteDesc = '" + txtsitedescription.Text+"'";
			strSiteValues += ", CoordinateSource = '" + dlstSource.SelectedItem+"'";
			strSiteValues += ", CoordinateSystem = '" + dlstSystem.SelectedItem+"'";
			strSiteValues += ", CoordinateUnits = '" + dlstUnits.SelectedItem+"'";
			
			strSiteValues += ", XCoordinate = '" + txtX.Text+"'";
			strSiteValues += ", YCoordinate = '" + txtY.Text+"'";	
			
			if(txtgroupsiteid.Text!="")
			{
				strUseValues += "AgencySiteID = '" + txtgroupsiteid.Text+"'";
			}
			else
			{
				strUseValues+= "AgencySiteID = null";
			}
			try
			{
				string sql1 = "UPDATE tblAquaticSite SET "+strSiteValues+" WHERE AquaticSiteID = "+Session["SelectedSiteID"].ToString();
				Debug.WriteLine("SQL1 string: "+sql1);
				string sql2 = "UPDATE tblAquaticSiteAgencyUse SET "+strUseValues+" WHERE AquaticSiteUseID = "+Session["SelectedSiteUseID"].ToString();
				Debug.WriteLine("SQL2 string: "+sql2);
				oleDbConnection1.Open();
				OleDbCommand cmd1 = new OleDbCommand(sql1, oleDbConnection1);
				OleDbCommand cmd2 = new OleDbCommand(sql2, oleDbConnection1);
				cmd1.ExecuteNonQuery();
				cmd2.ExecuteNonQuery();
				Server.Transfer("ESAFView.aspx");
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Error during update: "+ex.ToString());
			}		
		}

		protected void btnCancel2_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFList.aspx");
		}
		
		protected void btnMap_Click(object sender, System.EventArgs e)
		{
			try
			{
                // XXX: uggh, am i really hardcoding this url?
                //      have to do something to alleviate this later...
                //      - colin 
                string mapUrlFormat = "http://cri.nbwaters.unb.ca/map-staging/?legacy=true&x={0}&y={1}&srs={2}";
                string mapUrl = String.Format(mapUrlFormat, txtX.Text, txtY.Text, dlstSystem.SelectedItem);

				if(!IsStartupScriptRegistered("MapWindow"))
				{
					Page.RegisterStartupScript("MapWindow", "<script language='javascript' id='MapWindow'>window.open('" + mapUrl + "');</script>");
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Error: "+ex.ToString());
			}
		}
		#endregion
		
	}
}
