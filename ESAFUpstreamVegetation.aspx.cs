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
	/// Summary description for ESAFUpstreamVegetation.
	/// </summary>
	public partial class ESAFUpstreamVegetation : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected NBADWDataEntryApplication.dstblEnvironmentalSurveyFieldMeasures objdstblEnvironmentalSurveyFieldMeasures;
		protected System.Data.DataView dvtblEnvironmentalSurveyFieldMeasures;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblEnvironmentalSurveyFieldMeasures;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				try
				{
					if((bool)Session["Modify"])
					{
						SetValues();
						btnNext.Visible = false;
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
				}
			}
		}

		public void SetValues()
		{
			LoadtblEnvironmentalSurveyFieldMeasures();
			int i = dvtblEnvironmentalSurveyFieldMeasures.Find(Session["CurrentActivityID"].ToString());
			txtLawnL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Lawn_Lt"].ToString();
			txtRowCropL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_RowCrop_Lt"].ToString();
			txtForageL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_ForageCrop_Lt"].ToString();
			txtShrubsL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Shrubs_Lt"].ToString();
			txtHardwoodL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Hardwood_Lt"].ToString();
			txtSoftwoodL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Softwood_Lt"].ToString();
			txtMixedL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Mixed_Lt"].ToString();
			txtMeadowL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Meadow_Lt"].ToString();
			txtWetlandL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Wetland_Lt"].ToString();
			txtAlteredL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Altered_Lt"].ToString();

			txtLawnR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Lawn_Rt"].ToString();
			txtRowCropR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_RowCrop_Rt"].ToString();
			txtForageR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_ForageCrop_Rt"].ToString();
			txtShrubsR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Shrubs_Rt"].ToString();
			txtHardwoodR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Hardwood_Rt"].ToString();
			txtSoftwoodR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Softwood_Rt"].ToString();
			txtMixedR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Mixed_Rt"].ToString();
			txtMeadowR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Meadow_Rt"].ToString();
			txtWetlandR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Wetland_Rt"].ToString();
			txtAlteredR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["RZ_Altered_Rt"].ToString();
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
			this.objdstblEnvironmentalSurveyFieldMeasures = new NBADWDataEntryApplication.dstblEnvironmentalSurveyFieldMeasures();
			this.dvtblEnvironmentalSurveyFieldMeasures = new System.Data.DataView();
			this.oleDbdatblEnvironmentalSurveyFieldMeasures = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvironmentalSurveyFieldMeasures)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalSurveyFieldMeasures)).BeginInit();
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
			// objdstblEnvironmentalSurveyFieldMeasures
			// 
			this.objdstblEnvironmentalSurveyFieldMeasures.DataSetName = "dstblEnvironmentalSurveyFieldMeasures";
			this.objdstblEnvironmentalSurveyFieldMeasures.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblEnvironmentalSurveyFieldMeasures
			// 
			this.dvtblEnvironmentalSurveyFieldMeasures.Sort = "AquaticActivityID";
			this.dvtblEnvironmentalSurveyFieldMeasures.Table = this.objdstblEnvironmentalSurveyFieldMeasures.tblEnvironmentalSurveyFieldMeasures;
			// 
			// oleDbdatblEnvironmentalSurveyFieldMeasures
			// 
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																 new System.Data.Common.DataTableMapping("Table", "tblEnvironmentalSurveyFieldMeasures", new System.Data.Common.DataColumnMapping[] {
																																																																		new System.Data.Common.DataColumnMapping("Algae", "Algae"),
																																																																		new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																																		new System.Data.Common.DataColumnMapping("AquaticPlants", "AquaticPlants"),
																																																																		new System.Data.Common.DataColumnMapping("AveDepth_m", "AveDepth_m"),
																																																																		new System.Data.Common.DataColumnMapping("AveWidth_m", "AveWidth_m"),
																																																																		new System.Data.Common.DataColumnMapping("BankSlope_Lt", "BankSlope_Lt"),
																																																																		new System.Data.Common.DataColumnMapping("BankSlope_Rt", "BankSlope_Rt"),
																																																																		new System.Data.Common.DataColumnMapping("BankStability", "BankStability"),
																																																																		new System.Data.Common.DataColumnMapping("DeadFish", "DeadFish"),
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
																																																																		new System.Data.Common.DataColumnMapping("StreamTypeSupp", "StreamTypeSupp"),
																																																																		new System.Data.Common.DataColumnMapping("SuspendedSilt", "SuspendedSilt"),
																																																																		new System.Data.Common.DataColumnMapping("Velocity_mpers", "Velocity_mpers"),
																																																																		new System.Data.Common.DataColumnMapping("WaterClarity", "WaterClarity"),
																																																																		new System.Data.Common.DataColumnMapping("WaterColor", "WaterColor"),
																																																																		new System.Data.Common.DataColumnMapping("Weather_Current", "Weather_Current"),
																																																																		new System.Data.Common.DataColumnMapping("Weather_Past", "Weather_Past")})});
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblEnvironmentalSurveyFieldMeasures WHERE (FieldMeasureID = ?) AND (A" +
				"lgae = ?) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL)" +
				" AND (AquaticPlants = ?) AND (AveDepth_m = ? OR ? IS NULL AND AveDepth_m IS NULL" +
				") AND (AveWidth_m = ? OR ? IS NULL AND AveWidth_m IS NULL) AND (BankSlope_Lt = ?" +
				" OR ? IS NULL AND BankSlope_Lt IS NULL) AND (BankSlope_Rt = ? OR ? IS NULL AND B" +
				"ankSlope_Rt IS NULL) AND (BankStability = ? OR ? IS NULL AND BankStability IS NU" +
				"LL) AND (DeadFish = ?) AND (EmbeddedSub = ?) AND (Foam = ?) AND (GW1_AirTemp_C =" +
				" ? OR ? IS NULL AND GW1_AirTemp_C IS NULL) AND (GW1_Conductivity = ? OR ? IS NUL" +
				"L AND GW1_Conductivity IS NULL) AND (GW1_DELGFieldNo = ? OR ? IS NULL AND GW1_DE" +
				"LGFieldNo IS NULL) AND (GW1_DissOxygen = ? OR ? IS NULL AND GW1_DissOxygen IS NU" +
				"LL) AND (GW1_Flow_cms = ? OR ? IS NULL AND GW1_Flow_cms IS NULL) AND (GW1_Timeof" +
				"Day = ? OR ? IS NULL AND GW1_TimeofDay IS NULL) AND (GW1_WaterTemp_C = ? OR ? IS" +
				" NULL AND GW1_WaterTemp_C IS NULL) AND (GW1_pH = ? OR ? IS NULL AND GW1_pH IS NU" +
				"LL) AND (GW2_AirTemp_C = ? OR ? IS NULL AND GW2_AirTemp_C IS NULL) AND (GW2_Cond" +
				"uctivity = ? OR ? IS NULL AND GW2_Conductivity IS NULL) AND (GW2_DELGFieldNo = ?" +
				" OR ? IS NULL AND GW2_DELGFieldNo IS NULL) AND (GW2_DissOxygen = ? OR ? IS NULL " +
				"AND GW2_DissOxygen IS NULL) AND (GW2_Flow_cms = ? OR ? IS NULL AND GW2_Flow_cms " +
				"IS NULL) AND (GW2_TimeofDay = ? OR ? IS NULL AND GW2_TimeofDay IS NULL) AND (GW2" +
				"_WaterTemp_C = ? OR ? IS NULL AND GW2_WaterTemp_C IS NULL) AND (GW2_pH = ? OR ? " +
				"IS NULL AND GW2_pH IS NULL) AND (Length_m = ? OR ? IS NULL AND Length_m IS NULL)" +
				" AND (Odor = ?) AND (Other = ?) AND (OtherSupp = ? OR ? IS NULL AND OtherSupp IS" +
				" NULL) AND (Petroleum = ?) AND (RZ_Altered_Lt = ? OR ? IS NULL AND RZ_Altered_Lt" +
				" IS NULL) AND (RZ_Altered_Rt = ? OR ? IS NULL AND RZ_Altered_Rt IS NULL) AND (RZ" +
				"_ForageCrop_Lt = ? OR ? IS NULL AND RZ_ForageCrop_Lt IS NULL) AND (RZ_ForageCrop" +
				"_Rt = ? OR ? IS NULL AND RZ_ForageCrop_Rt IS NULL) AND (RZ_Hardwood_Lt = ? OR ? " +
				"IS NULL AND RZ_Hardwood_Lt IS NULL) AND (RZ_Hardwood_Rt = ? OR ? IS NULL AND RZ_" +
				"Hardwood_Rt IS NULL) AND (RZ_Lawn_Lt = ? OR ? IS NULL AND RZ_Lawn_Lt IS NULL) AN" +
				"D (RZ_Lawn_Rt = ? OR ? IS NULL AND RZ_Lawn_Rt IS NULL) AND (RZ_Meadow_Lt = ? OR " +
				"? IS NULL AND RZ_Meadow_Lt IS NULL) AND (RZ_Meadow_Rt = ? OR ? IS NULL AND RZ_Me" +
				"adow_Rt IS NULL) AND (RZ_Mixed_Lt = ? OR ? IS NULL AND RZ_Mixed_Lt IS NULL) AND " +
				"(RZ_Mixed_Rt = ? OR ? IS NULL AND RZ_Mixed_Rt IS NULL) AND (RZ_RowCrop_Lt = ? OR" +
				" ? IS NULL AND RZ_RowCrop_Lt IS NULL) AND (RZ_RowCrop_Rt = ? OR ? IS NULL AND RZ" +
				"_RowCrop_Rt IS NULL) AND (RZ_Shrubs_Lt = ? OR ? IS NULL AND RZ_Shrubs_Lt IS NULL" +
				") AND (RZ_Shrubs_Rt = ? OR ? IS NULL AND RZ_Shrubs_Rt IS NULL) AND (RZ_Softwood_" +
				"Lt = ? OR ? IS NULL AND RZ_Softwood_Lt IS NULL) AND (RZ_Softwood_Rt = ? OR ? IS " +
				"NULL AND RZ_Softwood_Rt IS NULL) AND (RZ_Wetland_Lt = ? OR ? IS NULL AND RZ_Wetl" +
				"and_Lt IS NULL) AND (RZ_Wetland_Rt = ? OR ? IS NULL AND RZ_Wetland_Rt IS NULL) A" +
				"ND (ST_AirTemp_C = ? OR ? IS NULL AND ST_AirTemp_C IS NULL) AND (ST_Conductivity" +
				" = ? OR ? IS NULL AND ST_Conductivity IS NULL) AND (ST_DELGFieldNo = ? OR ? IS N" +
				"ULL AND ST_DELGFieldNo IS NULL) AND (ST_DissOxygen = ? OR ? IS NULL AND ST_DissO" +
				"xygen IS NULL) AND (ST_Flow_cms = ? OR ? IS NULL AND ST_Flow_cms IS NULL) AND (S" +
				"T_TimeofDay = ? OR ? IS NULL AND ST_TimeofDay IS NULL) AND (ST_WaterTemp_C = ? O" +
				"R ? IS NULL AND ST_WaterTemp_C IS NULL) AND (ST_pH = ? OR ? IS NULL AND ST_pH IS" +
				" NULL) AND (StreamCover = ? OR ? IS NULL AND StreamCover IS NULL) AND (StreamTyp" +
				"e = ? OR ? IS NULL AND StreamType IS NULL) AND (StreamTypeSupp = ? OR ? IS NULL " +
				"AND StreamTypeSupp IS NULL) AND (SuspendedSilt = ?) AND (Velocity_mpers = ? OR ?" +
				" IS NULL AND Velocity_mpers IS NULL) AND (WaterClarity = ? OR ? IS NULL AND Wate" +
				"rClarity IS NULL) AND (WaterColor = ? OR ? IS NULL AND WaterColor IS NULL) AND (" +
				"Weather_Current = ? OR ? IS NULL AND Weather_Current IS NULL) AND (Weather_Past " +
				"= ? OR ? IS NULL AND Weather_Past IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FieldMeasureID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FieldMeasureID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Algae", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Algae", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticPlants", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveDepth_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWidth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWidth_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWidth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankStability", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankStability", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankStability1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankStability", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DeadFish", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EmbeddedSub", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Foam", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foam", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Odor", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Odor", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Other", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Other", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherSupp1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Petroleum", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Rt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamCover", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamCover1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamCover", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamType1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamTypeSupp", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamTypeSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamTypeSupp1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamTypeSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SuspendedSilt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Velocity_mpers", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Velocity_mpers1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Velocity_mpers", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterClarity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterClarity1", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterClarity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterColor", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterColor1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterColor", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Current", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Current1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Current", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Past", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Past1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Past", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO tblEnvironmentalSurveyFieldMeasures(Algae, AquaticActivityID, AquaticPlants, AveDepth_m, AveWidth_m, BankSlope_Lt, BankSlope_Rt, BankStability, DeadFish, EmbeddedSub, Foam, GW1_AirTemp_C, GW1_Conductivity, GW1_DELGFieldNo, GW1_DissOxygen, GW1_Flow_cms, GW1_pH, GW1_TimeofDay, GW1_WaterTemp_C, GW2_AirTemp_C, GW2_Conductivity, GW2_DELGFieldNo, GW2_DissOxygen, GW2_Flow_cms, GW2_pH, GW2_TimeofDay, GW2_WaterTemp_C, Length_m, Odor, Other, OtherSupp, Petroleum, RZ_Altered_Lt, RZ_Altered_Rt, RZ_ForageCrop_Lt, RZ_ForageCrop_Rt, RZ_Hardwood_Lt, RZ_Hardwood_Rt, RZ_Lawn_Lt, RZ_Lawn_Rt, RZ_Meadow_Lt, RZ_Meadow_Rt, RZ_Mixed_Lt, RZ_Mixed_Rt, RZ_RowCrop_Lt, RZ_RowCrop_Rt, RZ_Shrubs_Lt, RZ_Shrubs_Rt, RZ_Softwood_Lt, RZ_Softwood_Rt, RZ_Wetland_Lt, RZ_Wetland_Rt, ST_AirTemp_C, ST_Conductivity, ST_DELGFieldNo, ST_DissOxygen, ST_Flow_cms, ST_pH, ST_TimeofDay, ST_WaterTemp_C, StreamCover, StreamType, StreamTypeSupp, SuspendedSilt, Velocity_mpers, WaterClarity, WaterColor, Weather_Current, Weather_Past) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Algae", System.Data.OleDb.OleDbType.Boolean, 2, "Algae"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, "AquaticPlants"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, "AveDepth_m"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, "AveWidth_m"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankStability", System.Data.OleDb.OleDbType.VarWChar, 10, "BankStability"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, "DeadFish"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, "EmbeddedSub"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Foam", System.Data.OleDb.OleDbType.Boolean, 2, "Foam"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_AirTemp_C"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW1_Conductivity"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW1_DELGFieldNo"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW1_DissOxygen"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW1_Flow_cms"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_pH", System.Data.OleDb.OleDbType.Single, 0, "GW1_pH"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW1_TimeofDay"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_WaterTemp_C"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_AirTemp_C"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW2_Conductivity"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW2_DELGFieldNo"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW2_DissOxygen"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW2_Flow_cms"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_pH", System.Data.OleDb.OleDbType.Single, 0, "GW2_pH"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW2_TimeofDay"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_WaterTemp_C"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Length_m", System.Data.OleDb.OleDbType.Single, 0, "Length_m"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Odor", System.Data.OleDb.OleDbType.Boolean, 2, "Odor"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Other", System.Data.OleDb.OleDbType.Boolean, 2, "Other"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherSupp"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, "Petroleum"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Lawn_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, "RZ_Lawn_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Lt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Rt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_AirTemp_C"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "ST_Conductivity"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "ST_DELGFieldNo"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "ST_DissOxygen"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "ST_Flow_cms"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_pH", System.Data.OleDb.OleDbType.Single, 0, "ST_pH"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "ST_TimeofDay"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_WaterTemp_C"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamCover"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamType"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamTypeSupp", System.Data.OleDb.OleDbType.VarWChar, 30, "StreamTypeSupp"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, "SuspendedSilt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, "Velocity_mpers"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, "WaterClarity"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterColor"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Current"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Past"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT Algae, AquaticActivityID, AquaticPlants, AveDepth_m, AveWidth_m, BankSlope_Lt, BankSlope_Rt, BankStability, DeadFish, EmbeddedSub, FieldMeasureID, Foam, GW1_AirTemp_C, GW1_Conductivity, GW1_DELGFieldNo, GW1_DissOxygen, GW1_Flow_cms, GW1_pH, GW1_TimeofDay, GW1_WaterTemp_C, GW2_AirTemp_C, GW2_Conductivity, GW2_DELGFieldNo, GW2_DissOxygen, GW2_Flow_cms, GW2_pH, GW2_TimeofDay, GW2_WaterTemp_C, Length_m, Odor, Other, OtherSupp, Petroleum, RZ_Altered_Lt, RZ_Altered_Rt, RZ_ForageCrop_Lt, RZ_ForageCrop_Rt, RZ_Hardwood_Lt, RZ_Hardwood_Rt, RZ_Lawn_Lt, RZ_Lawn_Rt, RZ_Meadow_Lt, RZ_Meadow_Rt, RZ_Mixed_Lt, RZ_Mixed_Rt, RZ_RowCrop_Lt, RZ_RowCrop_Rt, RZ_Shrubs_Lt, RZ_Shrubs_Rt, RZ_Softwood_Lt, RZ_Softwood_Rt, RZ_Wetland_Lt, RZ_Wetland_Rt, ST_AirTemp_C, ST_Conductivity, ST_DELGFieldNo, ST_DissOxygen, ST_Flow_cms, ST_pH, ST_TimeofDay, ST_WaterTemp_C, StreamCover, StreamType, StreamTypeSupp, SuspendedSilt, Velocity_mpers, WaterClarity, WaterColor, Weather_Current, Weather_Past FROM tblEnvironmentalSurveyFieldMeasures";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblEnvironmentalSurveyFieldMeasures SET Algae = ?, AquaticActivityID = ?, " +
				"AquaticPlants = ?, AveDepth_m = ?, AveWidth_m = ?, BankSlope_Lt = ?, BankSlope_R" +
				"t = ?, BankStability = ?, DeadFish = ?, EmbeddedSub = ?, Foam = ?, GW1_AirTemp_C" +
				" = ?, GW1_Conductivity = ?, GW1_DELGFieldNo = ?, GW1_DissOxygen = ?, GW1_Flow_cm" +
				"s = ?, GW1_pH = ?, GW1_TimeofDay = ?, GW1_WaterTemp_C = ?, GW2_AirTemp_C = ?, GW" +
				"2_Conductivity = ?, GW2_DELGFieldNo = ?, GW2_DissOxygen = ?, GW2_Flow_cms = ?, G" +
				"W2_pH = ?, GW2_TimeofDay = ?, GW2_WaterTemp_C = ?, Length_m = ?, Odor = ?, Other" +
				" = ?, OtherSupp = ?, Petroleum = ?, RZ_Altered_Lt = ?, RZ_Altered_Rt = ?, RZ_For" +
				"ageCrop_Lt = ?, RZ_ForageCrop_Rt = ?, RZ_Hardwood_Lt = ?, RZ_Hardwood_Rt = ?, RZ" +
				"_Lawn_Lt = ?, RZ_Lawn_Rt = ?, RZ_Meadow_Lt = ?, RZ_Meadow_Rt = ?, RZ_Mixed_Lt = " +
				"?, RZ_Mixed_Rt = ?, RZ_RowCrop_Lt = ?, RZ_RowCrop_Rt = ?, RZ_Shrubs_Lt = ?, RZ_S" +
				"hrubs_Rt = ?, RZ_Softwood_Lt = ?, RZ_Softwood_Rt = ?, RZ_Wetland_Lt = ?, RZ_Wetl" +
				"and_Rt = ?, ST_AirTemp_C = ?, ST_Conductivity = ?, ST_DELGFieldNo = ?, ST_DissOx" +
				"ygen = ?, ST_Flow_cms = ?, ST_pH = ?, ST_TimeofDay = ?, ST_WaterTemp_C = ?, Stre" +
				"amCover = ?, StreamType = ?, StreamTypeSupp = ?, SuspendedSilt = ?, Velocity_mpe" +
				"rs = ?, WaterClarity = ?, WaterColor = ?, Weather_Current = ?, Weather_Past = ? " +
				"WHERE (FieldMeasureID = ?) AND (Algae = ?) AND (AquaticActivityID = ? OR ? IS NU" +
				"LL AND AquaticActivityID IS NULL) AND (AquaticPlants = ?) AND (AveDepth_m = ? OR" +
				" ? IS NULL AND AveDepth_m IS NULL) AND (AveWidth_m = ? OR ? IS NULL AND AveWidth" +
				"_m IS NULL) AND (BankSlope_Lt = ? OR ? IS NULL AND BankSlope_Lt IS NULL) AND (Ba" +
				"nkSlope_Rt = ? OR ? IS NULL AND BankSlope_Rt IS NULL) AND (BankStability = ? OR " +
				"? IS NULL AND BankStability IS NULL) AND (DeadFish = ?) AND (EmbeddedSub = ?) AN" +
				"D (Foam = ?) AND (GW1_AirTemp_C = ? OR ? IS NULL AND GW1_AirTemp_C IS NULL) AND " +
				"(GW1_Conductivity = ? OR ? IS NULL AND GW1_Conductivity IS NULL) AND (GW1_DELGFi" +
				"eldNo = ? OR ? IS NULL AND GW1_DELGFieldNo IS NULL) AND (GW1_DissOxygen = ? OR ?" +
				" IS NULL AND GW1_DissOxygen IS NULL) AND (GW1_Flow_cms = ? OR ? IS NULL AND GW1_" +
				"Flow_cms IS NULL) AND (GW1_TimeofDay = ? OR ? IS NULL AND GW1_TimeofDay IS NULL)" +
				" AND (GW1_WaterTemp_C = ? OR ? IS NULL AND GW1_WaterTemp_C IS NULL) AND (GW1_pH " +
				"= ? OR ? IS NULL AND GW1_pH IS NULL) AND (GW2_AirTemp_C = ? OR ? IS NULL AND GW2" +
				"_AirTemp_C IS NULL) AND (GW2_Conductivity = ? OR ? IS NULL AND GW2_Conductivity " +
				"IS NULL) AND (GW2_DELGFieldNo = ? OR ? IS NULL AND GW2_DELGFieldNo IS NULL) AND " +
				"(GW2_DissOxygen = ? OR ? IS NULL AND GW2_DissOxygen IS NULL) AND (GW2_Flow_cms =" +
				" ? OR ? IS NULL AND GW2_Flow_cms IS NULL) AND (GW2_TimeofDay = ? OR ? IS NULL AN" +
				"D GW2_TimeofDay IS NULL) AND (GW2_WaterTemp_C = ? OR ? IS NULL AND GW2_WaterTemp" +
				"_C IS NULL) AND (GW2_pH = ? OR ? IS NULL AND GW2_pH IS NULL) AND (Length_m = ? O" +
				"R ? IS NULL AND Length_m IS NULL) AND (Odor = ?) AND (Other = ?) AND (OtherSupp " +
				"= ? OR ? IS NULL AND OtherSupp IS NULL) AND (Petroleum = ?) AND (RZ_Altered_Lt =" +
				" ? OR ? IS NULL AND RZ_Altered_Lt IS NULL) AND (RZ_Altered_Rt = ? OR ? IS NULL A" +
				"ND RZ_Altered_Rt IS NULL) AND (RZ_ForageCrop_Lt = ? OR ? IS NULL AND RZ_ForageCr" +
				"op_Lt IS NULL) AND (RZ_ForageCrop_Rt = ? OR ? IS NULL AND RZ_ForageCrop_Rt IS NU" +
				"LL) AND (RZ_Hardwood_Lt = ? OR ? IS NULL AND RZ_Hardwood_Lt IS NULL) AND (RZ_Har" +
				"dwood_Rt = ? OR ? IS NULL AND RZ_Hardwood_Rt IS NULL) AND (RZ_Lawn_Lt = ? OR ? I" +
				"S NULL AND RZ_Lawn_Lt IS NULL) AND (RZ_Lawn_Rt = ? OR ? IS NULL AND RZ_Lawn_Rt I" +
				"S NULL) AND (RZ_Meadow_Lt = ? OR ? IS NULL AND RZ_Meadow_Lt IS NULL) AND (RZ_Mea" +
				"dow_Rt = ? OR ? IS NULL AND RZ_Meadow_Rt IS NULL) AND (RZ_Mixed_Lt = ? OR ? IS N" +
				"ULL AND RZ_Mixed_Lt IS NULL) AND (RZ_Mixed_Rt = ? OR ? IS NULL AND RZ_Mixed_Rt I" +
				"S NULL) AND (RZ_RowCrop_Lt = ? OR ? IS NULL AND RZ_RowCrop_Lt IS NULL) AND (RZ_R" +
				"owCrop_Rt = ? OR ? IS NULL AND RZ_RowCrop_Rt IS NULL) AND (RZ_Shrubs_Lt = ? OR ?" +
				" IS NULL AND RZ_Shrubs_Lt IS NULL) AND (RZ_Shrubs_Rt = ? OR ? IS NULL AND RZ_Shr" +
				"ubs_Rt IS NULL) AND (RZ_Softwood_Lt = ? OR ? IS NULL AND RZ_Softwood_Lt IS NULL)" +
				" AND (RZ_Softwood_Rt = ? OR ? IS NULL AND RZ_Softwood_Rt IS NULL) AND (RZ_Wetlan" +
				"d_Lt = ? OR ? IS NULL AND RZ_Wetland_Lt IS NULL) AND (RZ_Wetland_Rt = ? OR ? IS " +
				"NULL AND RZ_Wetland_Rt IS NULL) AND (ST_AirTemp_C = ? OR ? IS NULL AND ST_AirTem" +
				"p_C IS NULL) AND (ST_Conductivity = ? OR ? IS NULL AND ST_Conductivity IS NULL) " +
				"AND (ST_DELGFieldNo = ? OR ? IS NULL AND ST_DELGFieldNo IS NULL) AND (ST_DissOxy" +
				"gen = ? OR ? IS NULL AND ST_DissOxygen IS NULL) AND (ST_Flow_cms = ? OR ? IS NUL" +
				"L AND ST_Flow_cms IS NULL) AND (ST_TimeofDay = ? OR ? IS NULL AND ST_TimeofDay I" +
				"S NULL) AND (ST_WaterTemp_C = ? OR ? IS NULL AND ST_WaterTemp_C IS NULL) AND (ST" +
				"_pH = ? OR ? IS NULL AND ST_pH IS NULL) AND (StreamCover = ? OR ? IS NULL AND St" +
				"reamCover IS NULL) AND (StreamType = ? OR ? IS NULL AND StreamType IS NULL) AND " +
				"(StreamTypeSupp = ? OR ? IS NULL AND StreamTypeSupp IS NULL) AND (SuspendedSilt " +
				"= ?) AND (Velocity_mpers = ? OR ? IS NULL AND Velocity_mpers IS NULL) AND (Water" +
				"Clarity = ? OR ? IS NULL AND WaterClarity IS NULL) AND (WaterColor = ? OR ? IS N" +
				"ULL AND WaterColor IS NULL) AND (Weather_Current = ? OR ? IS NULL AND Weather_Cu" +
				"rrent IS NULL) AND (Weather_Past = ? OR ? IS NULL AND Weather_Past IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Algae", System.Data.OleDb.OleDbType.Boolean, 2, "Algae"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, "AquaticPlants"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, "AveDepth_m"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, "AveWidth_m"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankStability", System.Data.OleDb.OleDbType.VarWChar, 10, "BankStability"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, "DeadFish"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, "EmbeddedSub"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Foam", System.Data.OleDb.OleDbType.Boolean, 2, "Foam"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_AirTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW1_Conductivity"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW1_DELGFieldNo"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW1_DissOxygen"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW1_Flow_cms"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_pH", System.Data.OleDb.OleDbType.Single, 0, "GW1_pH"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW1_TimeofDay"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_WaterTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_AirTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW2_Conductivity"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW2_DELGFieldNo"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW2_DissOxygen"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW2_Flow_cms"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_pH", System.Data.OleDb.OleDbType.Single, 0, "GW2_pH"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW2_TimeofDay"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_WaterTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Length_m", System.Data.OleDb.OleDbType.Single, 0, "Length_m"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Odor", System.Data.OleDb.OleDbType.Boolean, 2, "Odor"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Other", System.Data.OleDb.OleDbType.Boolean, 2, "Other"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherSupp"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, "Petroleum"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Lawn_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, "RZ_Lawn_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Lt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Rt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_AirTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "ST_Conductivity"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "ST_DELGFieldNo"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "ST_DissOxygen"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "ST_Flow_cms"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_pH", System.Data.OleDb.OleDbType.Single, 0, "ST_pH"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "ST_TimeofDay"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_WaterTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamCover"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamTypeSupp", System.Data.OleDb.OleDbType.VarWChar, 30, "StreamTypeSupp"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, "SuspendedSilt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, "Velocity_mpers"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, "WaterClarity"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterColor"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Current"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Past"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FieldMeasureID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FieldMeasureID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Algae", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Algae", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticPlants", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveDepth_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWidth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWidth_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWidth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankStability", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankStability", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankStability1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankStability", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DeadFish", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EmbeddedSub", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Foam", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foam", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Odor", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Odor", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Other", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Other", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherSupp1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Petroleum", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Rt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamCover", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamCover1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamCover", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamType1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamTypeSupp", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamTypeSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamTypeSupp1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamTypeSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SuspendedSilt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Velocity_mpers", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Velocity_mpers1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Velocity_mpers", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterClarity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterClarity1", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterClarity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterColor", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterColor1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterColor", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Current", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Current1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Current", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Past", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Past1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Past", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvironmentalSurveyFieldMeasures)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalSurveyFieldMeasures)).EndInit();

		}
		#endregion		

		#region Buttons
		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			/*DataTable tESFM = objdstblEnvironmentalSurveyFieldMeasures.tblEnvironmentalSurveyFieldMeasures;
			DataRow rESFM = tESFM.NewRow();

			rESFM["AquaticActivityID"] = Session["CurrentActivityID"].ToString();
			rESFM["RZ_Lawn_Lt"] = txtLawnL.Text;
			rESFM["RZ_RowCrop_Lt"] = txtRowCropL.Text;
			rESFM["RZ_ForageCrop_Lt"] = txtForageL.Text;
			rESFM["RZ_Shrubs_Lt"] = txtShrubsL.Text;
			rESFM["RZ_Hardwood_Lt"] = txtHardwoodL.Text;
			rESFM["RZ_Softwood_Lt"] = txtSoftwoodL.Text;
			rESFM["RZ_Mixed_Lt"] = txtMixedL.Text;
			rESFM["RZ_Meadow_Lt"] = txtMeadowL.Text;
			rESFM["RZ_Wetland_Lt"] = txtWetlandL.Text;
			rESFM["RZ_Altered_Lt"] = txtAlteredL.Text;

			rESFM["RZ_Lawn_Rt"] = txtLawnR.Text;
			rESFM["RZ_RowCrop_Rt"] = txtRowCropR.Text;
			rESFM["RZ_ForageCrop_Rt"] = txtForageR.Text;
			rESFM["RZ_Shrubs_Rt"] = txtShrubsR.Text;
			rESFM["RZ_Hardwood_Rt"] = txtHardwoodR.Text;
			rESFM["RZ_Softwood_Rt"] = txtSoftwoodR.Text;
			rESFM["RZ_Mixed_Rt"] = txtMixedR.Text;
			rESFM["RZ_Meadow_Rt"] = txtMeadowR.Text;
			rESFM["RZ_Wetland_Rt"] = txtWetlandR.Text;
			rESFM["RZ_Altered_Rt"] = txtAlteredR.Text;

			tESFM.Rows.Add(rESFM);
			*/
			//string strValues = "AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			string strValues = "";
			//LawnL
			if(txtLawnL.Text!="")
			{
				strValues += "RZ_Lawn_Lt = " + txtLawnL.Text;
			}
			else
			{
				strValues += "RZ_Lawn_Lt = null";
			}
			//LawnR
			if(txtLawnR.Text!="")
			{
				strValues += ", RZ_Lawn_Rt = " + txtLawnR.Text;
			}
			else
			{
				strValues += ",RZ_Lawn_Rt = null";
			}
			//RowCropL
			if(txtRowCropL.Text!="")
			{
				strValues += ", RZ_RowCrop_Lt = " + txtRowCropL.Text;
			}
			else
			{
				strValues += ",RZ_RowCrop_Lt = null";
			}
			//RowCropR
			if(txtRowCropR.Text!="")
			{
				strValues += ", RZ_RowCrop_Rt = " + txtRowCropR.Text;
			}
			else
			{
				strValues += ",RZ_RowCrop_Rt = null";
			}
			
			//ForageL
			if(txtForageL.Text!="")
			{
				strValues += ", RZ_ForageCrop_Lt = " + txtForageL.Text;
			}
			else
			{
				strValues += ",RZ_ForageCrop_Lt = null";
			}
			
			//ForageR
			if(txtForageR.Text!="")
			{
				strValues += ", RZ_ForageCrop_Rt = " + txtForageR.Text;
			}
			else
			{
				strValues += ",RZ_ForageCrop_Rt = null";
			}
			
			//ShrubsL
			if(txtShrubsL.Text!="")
			{
				strValues += ", RZ_Shrubs_Lt = " + txtShrubsL.Text;
			}
			else
			{
				strValues += ",RZ_Shrubs_Lt = null";
			}
			//ShrubsR
			if(txtShrubsR.Text!="")
			{
				strValues += ", RZ_Shrubs_Rt = " + txtShrubsR.Text;
			}
			else
			{
				strValues += ",RZ_Shrubs_Rt = null";
			}
			//HardwoodL
			if(txtHardwoodL.Text!="")
			{
				strValues += ", RZ_Hardwood_Lt = " + txtHardwoodL.Text;
			}
			else
			{
				strValues += ",RZ_Hardwood_Lt = null";
			}
			//HardwoodR
			if(txtHardwoodR.Text!="")
			{
				strValues += ", RZ_Hardwood_Rt = " + txtHardwoodR.Text;
			}
			else
			{
				strValues += ",RZ_Hardwood_Rt = null";
			}
			//SoftwoodL
			if(txtSoftwoodL.Text!="")
			{
				strValues += ", RZ_Softwood_Lt = " + txtSoftwoodL.Text;
			}
			else
			{
				strValues += ",RZ_Softwood_Lt = null";
			}
			//SoftwoodR
			if(txtSoftwoodR.Text!="")
			{
				strValues += ", RZ_Softwood_Rt = " + txtSoftwoodR.Text;
			}
			else
			{
				strValues += ",RZ_Softwood_Rt = null";
			}
			//MixedL
			if(txtMixedL.Text!="")
			{
				strValues += ", RZ_Mixed_Lt = " + txtMixedL.Text;
			}
			else
			{
				strValues += ",RZ_Mixed_Lt = null";
			}
			//MixedR
			if(txtMixedR.Text!="")
			{
				strValues += ", RZ_Mixed_Rt = " + txtMixedR.Text;
			}
			else
			{
				strValues += ",RZ_Mixed_Rt = null";
			}
			//MeadowL
			if(txtMeadowL.Text!="")
			{
				strValues += ", RZ_Meadow_Lt = " + txtMeadowL.Text;
			}
			else
			{
				strValues += ",RZ_Meadow_Lt = null";
			}
			//MeadowR
			if(txtMeadowR.Text!="")
			{
				strValues += ", RZ_Meadow_Rt = " + txtMeadowR.Text;
			}
			else
			{
				strValues += ",RZ_Meadow_Rt = null";
			}
			//WetlandL
			if(txtWetlandL.Text!="")
			{
				strValues += ", RZ_Wetland_Lt = " + txtWetlandL.Text;
			}
			else
			{
				strValues += ",RZ_Wetland_Lt = null";
			}
			//WetlandR
			if(txtWetlandR.Text!="")
			{
				strValues += ", RZ_Wetland_Rt = " + txtWetlandR.Text;
			}
			else
			{
				strValues += ",RZ_Wetland_Rt = null";
			}
			//AlteredL
			if(txtAlteredL.Text!="")
			{
				strValues += ", RZ_Altered_Lt = " + txtAlteredL.Text;
			}
			else
			{
				strValues += ",RZ_Altered_Lt = null";
			}
			//AlteredR
			if(txtAlteredR.Text!="")
			{
				strValues += ", RZ_Altered_Rt = " + txtAlteredR.Text;
			}
			else
			{
				strValues += ",RZ_Altered_Rt = null";
			}

			try
			{
				string sql = "UPDATE tblEnvironmentalSurveyFieldMeasures SET "+strValues+" WHERE AquaticActivityID = "+Session["CurrentActivityID"].ToString();
				oleDbConnection1.Open();
				OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
				cmd.ExecuteNonQuery();
				try
				{
					if((bool)Session["Modify"])
					{
						Server.Transfer("ESAFView.aspx");
					}
					else
					{
						Server.Transfer("ESAFFieldMeasurements.aspx");
					}
				}
				catch(System.NullReferenceException)
				{
					Server.Transfer("ESAFFieldMeasurements.aspx");
				}
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

		#region Fill & Load
		public void FilltblEnvironmentalSurveyFieldMeasures(NBADWDataEntryApplication.dstblEnvironmentalSurveyFieldMeasures dataSet)
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
				this.oleDbdatblEnvironmentalSurveyFieldMeasures.Fill(dataSet);
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

		public void LoadtblEnvironmentalSurveyFieldMeasures()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dstblEnvironmentalSurveyFieldMeasures objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dstblEnvironmentalSurveyFieldMeasures();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblEnvironmentalSurveyFieldMeasures(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblEnvironmentalSurveyFieldMeasures.Clear();
				// Merge the records into the main dataset.
				objdstblEnvironmentalSurveyFieldMeasures.Merge(objDataSetTemp);
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
