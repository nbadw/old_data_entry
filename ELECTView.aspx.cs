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
	/// Summary description for ELECTView.
	/// </summary>
	public partial class ELECTView : System.Web.UI.Page
	{
		#region controls
		#endregion
		
		#region Adapters, Datasets, Dataviews
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SiteInfo;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;

		protected NBADWDataEntryApplication.dsDE_SiteInfo objdsDE_SiteInfo;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdAgency;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdFishSpecies;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdFishAgeClass;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdAquaticActivityMethod;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_ELECTSweepData;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_ELECTPopEstimates;
		
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticActivity;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand9;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand9;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblElectrofishingMethodDetail;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand10;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand10;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_ELECTSiteMeasurement;		

		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdOandM;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand12;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand12;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand6;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblPhotos;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand14;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand14;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand8;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand8;

		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_ELECTWaterMeasurement;		
				
		protected NBADWDataEntryApplication.dscdAgency objdscdAgency;
		protected NBADWDataEntryApplication.dscdFishSpecies objdscdFishSpecies;
		protected NBADWDataEntryApplication.dscdFishAgeClass objdscdFishAgeClass;
		protected NBADWDataEntryApplication.dsDE_ELECTSweepData objdsDE_ELECTSweepData;
		protected NBADWDataEntryApplication.dsDE_ELECTPopEstimates objdsDE_ELECTPopEstimates;
		protected NBADWDataEntryApplication.dscdAquaticActivityMethod objdscdAquaticActivityMethod;
		protected NBADWDataEntryApplication.dstblAquaticActivity objdstblAquaticActivity;
		protected NBADWDataEntryApplication.dstblElectrofishingMethodDetail objdstblElectrofishingMethodDetail;
		protected NBADWDataEntryApplication.dsDE_ELECTSiteMeasurement objdsDE_ELECTSiteMeasurement;
		protected NBADWDataEntryApplication.dscdOandM objdscdOandM;
		protected NBADWDataEntryApplication.dstblPhotos objdstblPhotos;
		protected NBADWDataEntryApplication.dsDE_ELECTWaterMeasurement objdsDE_ELECTWaterMeasurement;
		
				
		
		protected System.Data.DataView dvDE_ELECTSweepData;
		protected System.Data.DataView dvDE_ELECTPopEstimates;		
		protected System.Data.DataView dvcdAquaticActivityMethod;
		protected System.Data.DataView dvtblElectrofishingMethodDetail;
		protected System.Data.DataView dvDE_ELECTSiteMeasurement;
		protected System.Data.DataView dvcdOandM;
		protected System.Data.DataView dvtblPhotos;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdOandMValues;
		protected NBADWDataEntryApplication.dscdOandMValues objdscdOandMValues;
		protected System.Data.DataView dvcdOandMValues;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_ELECTObservations;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand17;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand17;
		protected NBADWDataEntryApplication.dsDE_ELECTObservations objdsDE_ELECTObservations;
		protected System.Data.DataView dvDE_ELECTObservations;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_OandM_Category;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand19;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand19;
		protected NBADWDataEntryApplication.dsDE_OandM_Category objdsDE_OandM_Category;
		protected System.Data.DataView dvDE_OandM_Category;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand15;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand15;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected System.Data.DataView dvcdFishSpecies;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdFishPopulationParameter;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand18;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand18;
		protected NBADWDataEntryApplication.dscdFishPopulationParameter objdscdFishPopulationParameter;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_OandM_UnitofMeasure;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand13;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand13;
		protected NBADWDataEntryApplication.dsDE_OandM_UnitofMeasure objdsDE_OandM_UnitofMeasure;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_OandM_Instrument;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand8;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand8;
		protected System.Data.DataView dvDE_OandM_Instrument;
		protected System.Data.DataView dvDE_OandM_UnitofMeasure;
		protected NBADWDataEntryApplication.dsDE_OandM_Instrument objdsDE_OandM_Instrument;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand11;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand11;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand16;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand16;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		protected System.Data.DataView dvcdFishAgeClass;
		protected System.Data.DataView dvDE_ELECTWaterMeasurement;			
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				SetPageMode();
				
				FillSiteInfoFields();				
			}
		}


		#region Buttons
		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ELECTList.aspx");
		}

		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			string strValues;
			string sql, tempS;
			btnAdd.Visible = false;
			
			#region Activity and Method
			if(pnlActivityDetails.Visible)//step1
			{
				//Session["CurrentActivityID"] = "116068";
				
				LoadtblAquaticActivity();

				//find biggest activity
				DataTable tActivity = objdstblAquaticActivity.tblAquaticActivity;
				int i = FindBiggest(tActivity,"AquaticActivityID")+1;
				Session["CurrentActivityID"] = i;

				//create activity record
				strValues = i + ", 2, " + txtdwsiteid.Text + ", '" + txtagencycd.Text +"'";
				strValues += ", " + dlstElectrofishingMethod2.SelectedValue;
				strValues += ", '" + txtFishCollectionPermit2.Text + "'";
				strValues += ", '" + txtDate2.Text + "'";
				strValues += ", '" + txtPersonnel2.Text + "'";
				strValues += ", '" + dlstSecondAgency2.SelectedValue + "'";
				strValues += ", '" + txtSecondAgencyContact2.Text + "'";

				sql = "INSERT INTO tblAquaticActivity (AquaticActivityID, AquaticActivityCd, AquaticSiteID, AgencyCd, AquaticMethodCd, PermitNo, AquaticActivityStartDate, Crew, Agency2Cd, Agency2Contact) VALUES (" + strValues + ")";
				ExecuteSQL(sql);
				
				//create method record
				strValues = "";
				strValues = i.ToString();
				strValues += ", '" + dlstSiteSetup2.SelectedValue + "'";
				if(txtNoSweeps2.Text!="")
				{
					strValues += ", " + txtNoSweeps2.Text;
				}
				else
				{
					strValues += ", Null";
				}
				strValues += ", '" + dlstGearUsed2.SelectedValue + "'";
				if(txtVoltage2.Text!="")
				{
					strValues += ", " + txtVoltage2.Text;
				}
				else
				{
					strValues += ", Null";
				}
				if(txtFrequency2.Text!="")
				{
					strValues += ", " + txtFrequency2.Text;
				}
				else
				{
					strValues += ", Null";
				}
				if(txtDutyCycle2.Text!="")
				{
					strValues += ", " + txtDutyCycle2.Text;
				}
				else
				{
					strValues += ", Null";
				}
				if(txtPOWSetting2.Text!="")
				{
					strValues += ", " + txtPOWSetting2.Text;
				}
				else
				{
					strValues += ", Null";
				}

				sql = "INSERT INTO tblElectrofishingMethodDetail (AquaticActivityID, SiteSetup, NoSweeps, Device, Voltage, Frequency_Hz, DutyCycle, POWSetting) VALUES (" + strValues + ")";
				ExecuteSQL(sql);
								
				HidePanels();
				HideInstructions();
				pnlSiteDetails.Visible = true;
				pnlInstructions2.Visible = true;
				btnCancel.Visible = false;//only visible during first step
			}
			#endregion

			#region SiteDetails
			else if(pnlSiteDetails.Visible)//step2
			{
				sql = "INSERT INTO tblSiteMeasurement (AquaticActivityID, OandMCd, InstrumentCd, Measurement, UnitofMeasureCd) VALUES (" + Session["CurrentActivityID"].ToString();
				
				if(txtStreamLength2.Text!="")
				{
					tempS = sql + ", 58 , " + dlstStreamLength2.SelectedValue + ", " + txtStreamLength2.Text + ", 8)";
					ExecuteSQL(tempS);
					tempS = "";
				}
				
				if(txtWetWidth2.Text!="")
				{
					tempS = sql + ", 59 , " + dlstWetWidth2.SelectedValue + ", " + txtWetWidth2.Text + ", 8)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtBankWidth2.Text!="")
				{
					tempS = sql + ", 60 , " + dlstBankWidth2.SelectedValue + ", " + txtBankWidth2.Text + ", 8)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtAverageDepth2.Text!="")
				{
					tempS = sql + ", 61 , " + dlstAverageDepth2.SelectedValue + ", " + txtAverageDepth2.Text + ", 7)";
					ExecuteSQL(tempS);
					tempS = "";
				}
				

				//Stream Type
				//sql = "INSERT INTO tblSiteMeasurement (AquaticActivityID, OandMCd, Measurement, UnitofMeasureCd) VALUES (" + Session["CurrentActivityID"].ToString();
				if(txtRiffle2.Text!="")
				{
					tempS = sql + ", 62 , 8, " + txtRiffle2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtRun2.Text!="")
				{
					tempS = sql + ", 63 , 8, " + txtRun2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtPool2.Text!="")
				{
					tempS = sql + ", 64 , 8, " + txtPool2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtRapid2.Text!="")
				{
					tempS = sql + ", 65 , 8, " + txtRapid2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtOther2.Text!="")
				{
					tempS = sql + ", 66 , 8, " + txtOther2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				//Substrate Type
				if(txtBedrock2.Text!="")
				{
					tempS = sql + ", 67 , 8, " + txtBedrock2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtBoulder2.Text!="")
				{
					tempS = sql + ", 68 , 8, " + txtBoulder2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtRock2.Text!="")
				{
					tempS = sql + ", 69 , 8, " + txtRock2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtRubble2.Text!="")
				{
					tempS = sql + ", 70 , 8, " + txtRubble2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtGravel2.Text!="")
				{
					tempS = sql + ", 71 , 8, " + txtGravel2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtSand2.Text!="")
				{
					tempS = sql + ", 72 , 8, " + txtSand2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtFines2.Text!="")
				{
					tempS = sql + ", 73 , 8, " + txtFines2.Text + ", 17)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtLargeWoodyDebris2.Text!="")
				{
					tempS = sql + ", 76 , 8, " + txtLargeWoodyDebris2.Text + ", 8)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				//Overhanging and Undercut
				sql = "INSERT INTO tblSiteMeasurement (AquaticActivityID, OandMCd, InstrumentCd, Measurement, UnitofMeasureCd, Bank) VALUES (" + Session["CurrentActivityID"].ToString();
				if(txtLeftBankOverhangingVegetation2.Text!="")
				{
					tempS = sql + ", 74 , 8, " + txtLeftBankOverhangingVegetation2.Text + ", 17, 'Left')";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtRightBankOverhangingVegetation2.Text!="")
				{
					tempS = sql + ", 74 , 8, " + txtRightBankOverhangingVegetation2.Text + ", 17, 'Right')";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtLeftBankUndercutBank2.Text!="")
				{
					tempS = sql + ", 75 , 8, " + txtLeftBankUndercutBank2.Text + ", 17, 'Left')";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtRightBankUndercutBank2.Text!="")
				{
					tempS = sql + ", 75 , 8, " + txtRightBankUndercutBank2.Text + ", 17, 'Right')";
					ExecuteSQL(tempS);
					tempS = "";
				}				

				HidePanels();
				HideInstructions();
				pnlPhotos.Visible = true;
				pnlInstructions3.Visible = true;
				btnAdd.Visible = true;
			}
			#endregion

			#region Photos
			else if(pnlPhotos.Visible)//step3
			{
				HidePanels();
				HideInstructions();
				pnlWaterMeasurements.Visible = true;
				pnlInstructions4.Visible = true;
			}
				#endregion

			#region WaterMeasurements
			else if(pnlWaterMeasurements.Visible)//step 4
			{
				sql = "INSERT INTO tblWaterMeasurement (AquaticActivityID, OandMCd, TimeofDay, InstrumentCd, Measurement, UnitofMeasureCd) VALUES (" + Session["CurrentActivityID"].ToString();
				
				if(txtStartWaterTemperatureMeasurement2.Text!="")
				{
					tempS = sql + ", 77 , '" + txtStartWaterTemperatureTimeofDay2.Text + "', '" + dlstStartWaterTemperatureInstrument2.SelectedValue + "', " + txtStartWaterTemperatureMeasurement2.Text + ", 1)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtEndWaterTemperatureMeasurement2.Text!="")
				{
					tempS = sql + ", 77 , '" + txtEndWaterTemperatureTimeofDay2.Text + "', '" + dlstEndWaterTemperatureInstrument2.SelectedValue + "', " + txtEndWaterTemperatureMeasurement2.Text + ", 1)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtStartAirTemperatureMeasurement2.Text!="")
				{
					tempS = sql + ", 78 , '" + txtStartAirTemperatureTimeofDay2.Text + "', '" + dlstStartAirTemperatureInstrument2.SelectedValue + "', " + txtStartAirTemperatureMeasurement2.Text + ", 1)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtEndAirTemperatureMeasurement2.Text!="")
				{
					tempS = sql + ", 78 , '" + txtEndAirTemperatureTimeofDay2.Text + "', '" + dlstEndAirTemperatureInstrument2.SelectedValue + "', " + txtEndAirTemperatureMeasurement2.Text + ", 1)";
					ExecuteSQL(tempS);
					tempS = "";
				}


				sql = "INSERT INTO tblWaterMeasurement (AquaticActivityID, OandMCd, InstrumentCd, Measurement, UnitofMeasureCd) VALUES (" + Session["CurrentActivityID"].ToString();
				if(txtWaterVelocityMeasurement2.Text!="")
				{
					tempS = sql + ", 79, '" + dlstWaterVelocityInstrument2.SelectedValue + "', " + txtWaterVelocityMeasurement2.Text + ", 18)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtWaterFlowMeasurement2.Text!="")
				{
					tempS = sql + ", 80, '" + dlstWaterFlowInstrument2.SelectedValue + "', " + txtWaterFlowMeasurement2.Text + ", 19)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtAmbientWaterConductivityMeasurement2.Text!="")
				{
					tempS = sql + ", 81, '" + dlstAmbientWaterConductivityInstrument2.SelectedValue + "', " + txtAmbientWaterConductivityMeasurement2.Text + ", 20)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				if(txtSpecificWaterConductivityMeasurement2.Text!="")
				{
					tempS = sql + ", 82, '" + dlstSpecificWaterConductivityInstrument2.SelectedValue + "', " + txtSpecificWaterConductivityMeasurement2.Text + ", 20)";
					ExecuteSQL(tempS);
					tempS = "";
				}

				sql = "INSERT INTO tblObservations (AquaticActivityID, OandMCd, OandMValuesCd) VALUES (" + Session["CurrentActivityID"].ToString();
				if(dlstWaterClarityMeasurement2.SelectedValue!="")
				{
					tempS = sql + ", 83 , " + dlstWaterClarityMeasurement2.SelectedValue + ")";
					ExecuteSQL(tempS);
					tempS = "";
				}
								
				HidePanels();
				HideInstructions();
				//pnlChoice.Visible = true;
				btnAdd.Visible = true;
				btnNext.Visible = false;
				btnDone.Visible = true;
				pnlSweepData.Visible = true;
				pnlInstructions6a.Visible = true;
			}
			#endregion

			#region SweepData
			else if(pnlSweepData.Visible)//step 5
			{
				/*
				HidePanels();
				HideInstructions();
				pnlPopulationEstimates.Visible = true;
				pnlInstructions7a.Visible = true;
				HideButtons();
				btnNext.Visible = false;
				btnDone.Visible = true;
				*/

				Server.Transfer("ELECTList.aspx");
			}
				#endregion

			#region Population Estimates
			else //step 6
			{
				//HidePanels();
				Server.Transfer("ELECTList.aspx");
			}
			#endregion
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			string sql, strValues;

			#region SiteDetails
			if(pnlSiteDetails.Visible)
			{
				sql = "INSERT INTO tblSiteMeasurement (AquaticActivityID, OandMCd, InstrumentCd, Measurement, UnitofMeasureCd, Bank) VALUES (" 
					+ Session["CurrentActivityID"].ToString()
					+ ", " + dlstValueMeasured2_SiteDetails.SelectedValue 
					+ ", " + dlstInstrument2_SiteDetails.SelectedValue 
					+ ", " + txtMeasurement2_SiteDetails.Text  
					+ ", " + dlstUnitofMeasure2_SiteDetails.SelectedValue
					+ ", '" + rblBank.SelectedValue + "')";
				ExecuteSQL(sql);
				FillSiteDetailsFields();
				ClearSiteDetailsFields();
			}
				#endregion

			#region Photos
			else if(pnlPhotos.Visible)
			{
				sql = "INSERT INTO tblPhotos (AquaticActivityID, Path, FileName) VALUES (" 
					+ Session["CurrentActivityID"].ToString() 
					+ ", '" + txtPath2.Text 
					+ "', '" + txtFileName2.Text + "')";
				ExecuteSQL(sql);
				FillPhotosFields();
				ClearPhotoFields();				
			}
				#endregion

			#region WaterMeasurements
			else if(pnlWaterMeasurements.Visible)
			{
				sql = "INSERT INTO tblWaterMeasurement (AquaticActivityID, OandMCd, InstrumentCd, Measurement, UnitofMeasureCd, TimeofDay) VALUES (" 
					+ Session["CurrentActivityID"].ToString()
					+ ", " + dlstValueMeasured2_WaterMeasurements.SelectedValue 
					+ ", " + dlstInstrument2_WaterMeasurements.SelectedValue 
					+ ", " + txtMeasurement2_WaterMeasurements.Text  
					+ ", " + dlstUnitofMeasure2_WaterMeasurements.SelectedValue
					+ ", '" + txtTimeofDay2.Text + "')";
				ExecuteSQL(sql);
				FillWaterMeasurementsFields();
				ClearWaterMeasurementsFields();
			}
				#endregion

			#region SweepData
			else if(pnlSweepData.Visible)
			{
				//check if estimates have changed
				if(PopEstimateCalculation()& txtDensity1.Visible)
				{
					Page.RegisterStartupScript("Values Changed","<script language='javascript' id='Values Changed'>alert('WARNING:  The population estimates have been recalculated and do not match the currently displayed estimates. It is assumed the sweep data was edited and the estimates were not cleared and recalculated. The new calculations will be added instead. If necessary, you may edit the data after it is placed in the Sweep Data List.');</script>");
				}                			
				
				sql = "INSERT INTO tblElectrofishingData (AquaticActivityID, FishSpeciesCd, FishAgeClass, AveWeight_gm, AveForkLength_cm, AveTotalLength_cm, PercentClipped, Sweep1NoFish, Sweep1Time_s, Sweep2NoFish, Sweep2Time_s, Sweep3NoFish, Sweep3Time_s, Sweep4NoFish, Sweep4Time_s, Sweep5NoFish, Sweep5Time_s, Sweep6NoFish, Sweep6Time_s, TotalNoFish) VALUES (" + Session["CurrentActivityID"].ToString();

				int autoindex = 0;				

				double T = 0;
				strValues = ""; 

				strValues += ", '" + dlstSpecies2.SelectedValue + "'";
				strValues += ", '" + dlstAgeClass2.SelectedValue+ "'";

				if(txtAverageWeight2.Text!="")
				{
					strValues += ", " + txtAverageWeight2.Text;
				}
				else
				{
					strValues += ", Null";
				}

				if(txtAverageForkLength2.Text!="")
				{
					strValues += ", " + txtAverageForkLength2.Text;
				}
				else
				{
					strValues += ", Null";
				}

				if(txtAverageTotalLength2.Text!="") strValues += ", " + txtAverageTotalLength2.Text;
				else strValues += ", Null";
				
				if(txtPercentClipped2.Text!="") strValues += ", " + txtPercentClipped2.Text;
				else strValues += ", Null";

				if(txtSweep1No2.Text!="")
				{
					strValues += ", " + txtSweep1No2.Text;
					T += System.Convert.ToDouble(txtSweep1No2.Text);
				}
				else strValues += ", Null";
				if(txtSweep1Time2.Text!="") strValues += ", " + txtSweep1Time2.Text;
				else strValues += ", Null";

				if(txtSweep2No2.Text!="")
				{
					strValues += ", " + txtSweep2No2.Text; 
					T += System.Convert.ToDouble(txtSweep2No2.Text);
				}
				else strValues += ", Null";
				if(txtSweep2Time2.Text!="") strValues += ", " + txtSweep2Time2.Text;
				else strValues += ", Null";

				if(txtSweep3No2.Text!="")
				{
					strValues += ", " + txtSweep3No2.Text;
					T += System.Convert.ToDouble(txtSweep3No2.Text);
				}
				else strValues += ", Null";
				if(txtSweep3Time2.Text!="") strValues += ", " + txtSweep3Time2.Text;
				else strValues += ", Null";

				if(txtSweep4No2.Text!="")
				{
					strValues += ", " + txtSweep4No2.Text;
					T += System.Convert.ToDouble(txtSweep4No2.Text);
				}
				else strValues += ", Null";
				if(txtSweep4Time2.Text!="") strValues += ", " + txtSweep4Time2.Text;
				else strValues += ", Null";

				if(txtSweep5No2.Text!="")
				{
					strValues += ", " + txtSweep5No2.Text;
					T += System.Convert.ToDouble(txtSweep5No2.Text);
				}
				else strValues += ", Null";
				if(txtSweep5Time2.Text!="") strValues += ", " + txtSweep5Time2.Text;
				else strValues += ", Null";
				
				if(txtSweep6No2.Text!="")
				{
					strValues += ", " + txtSweep6No2.Text;
					T += System.Convert.ToDouble(txtSweep6No2.Text);
				}
				else strValues += ", Null";
				if(txtSweep6Time2.Text!="") strValues += ", " + txtSweep6Time2.Text;
				else strValues += ", Null";

				if(T>0)	strValues += ", " + T;
				else strValues += ", Null";

				autoindex = ExecuteSQL(sql + strValues +")");
				Debug.WriteLine("autoindex = "+autoindex.ToString());

				AddPopulationEstimates(autoindex);				
				
				FillSweepDataFields();
				ClearSweepDataFields();

				HideEnabledPopEstimateFields();
				ShowDisabledPopEstimateFields();

				ClearPopEstimateFields();
			}
				#endregion

			#region PopulationEstimates
				/*
			else if (pnlPopulationEstimates.Visible)
			{
				sql = "INSERT INTO tblElectrofishingPopulationEstimate (AquaticActivityID, FishSpeciesCd, FishAgeClass, AveForkLength_cm, AveWeight_gm, PopulationParameter, PopulationEstimate, Comments) VALUES ("+Session["CurrentActivityID"].ToString();
				sql += ", '" + dlstSpecies2_Population.SelectedValue + "'";
				sql += ", '" + dlstAgeClass2_Population.SelectedValue + "'";

				if(txtAverageForkLength_Population.Text!="") sql += ", " + txtAverageForkLength_Population.Text;
				else sql += ", Null";
				 
				if(txtAverageWeight_Population.Text!="") sql += ", " + txtAverageWeight_Population.Text;
				else sql += ", Null";

				sql += ", '" + dlstPopulationParameter2.SelectedItem + "'";
				sql += ", " + txtPopulationEstimate.Text;
				
				if(txtComments.Text!="") sql += ", '" + txtComments.Text + "')";
				else sql += ", Null)";

				ExecuteSQL(sql);

				FillPopulationEstimatesFields();
				ClearPopulationEstimatesFields();
			}
			*/
			#endregion
		}

		protected void btnChangeSite_Click(object sender, System.EventArgs e)
		{
			Session["Mode"] = "ModifySite";
			Session["PreviousPage"] = "ELECTView.aspx";
			Server.Transfer("SelectSite.aspx");
		}
		protected void btnModifyActivityDetails_Click(object sender, System.EventArgs e)
		{
			Modify(1);
		}
		protected void btnModifyMethodDetails_Click(object sender, System.EventArgs e)
		{
			Modify(1);
		}

		protected void btnModifySiteDetails_Click(object sender, System.EventArgs e)
		{
			Modify(2);
		}

		protected void btnModifyPhotos_Click(object sender, System.EventArgs e)
		{
			Modify(3);
		}

		protected void btnModifyWaterMeasurements_Click(object sender, System.EventArgs e)
		{
			Modify(4);	
		}

		protected void btnModifySiteObservations_Click(object sender, System.EventArgs e)
		{
			Modify(5);
		}

		protected void btnModifySweepData_Click(object sender, System.EventArgs e)
		{
			Modify(6);
		}

		private void btnModifyPopulationEstimates_Click(object sender, System.EventArgs e)
		{
			Modify(7);
		}

		protected void btnDone_Click(object sender, System.EventArgs e)
		{
			string strValues, sql;

			if(pnlSiteDetails.Visible)
			{
				//check that there is exactly one length and width measurement
				LoadSiteMeasurement();
				dvDE_ELECTSiteMeasurement.RowFilter = "AquaticActivityID = "+Session["CurrentActivityID"].ToString() + " AND OandMCd = 58";
				int i = dvDE_ELECTSiteMeasurement.Count;
				dvDE_ELECTSiteMeasurement.RowFilter = "AquaticActivityID = "+Session["CurrentActivityID"].ToString() + " AND OandMCd = 59";
				int j = dvDE_ELECTSiteMeasurement.Count;

				Debug.WriteLine("Length : "+i.ToString()+" Width: " + j.ToString());
				if(i!=1 || j!=1)
				{					
					Page.RegisterStartupScript("Required Fields","<script language='javascript' id='Required Fields'>alert('You must have exactly one Length measurement and exactly one Wet Width measurement');</script>");				
				}
				else
				{
					Debug.WriteLine("Recalculating");

					//variables
					double t, T, Tx, x, x2, k;
					double P,N,D,B,PHS;
											
					//get de-electsweep 
					LoadSweepData();

					//filter dv for activity and autocal ind
					this.dvDE_ELECTSweepData.RowFilter = "AquaticActivityID = " + Session["CurrentActivityID"].ToString() + " AND AutoCalculatedInd = True";
					Debug.WriteLine("Must recalculate "+dvDE_ELECTSweepData.Count.ToString()+" values");
					
					

					//for each efdataid found:
					foreach(DataRowView drv in dvDE_ELECTSweepData)
					{
						Debug.WriteLine("recalculate for "+drv["EFDataID"].ToString());
						
						//delete old estimates based on efdataid
						sql = "DELETE EFDataID from tblElectrofishingPopulationEstimate WHERE EFDataID = " + drv["EFDataID"].ToString();
						ExecuteSQL(sql);

						//recalculate pop estimates
						t = 0;//value entered for particular sweep
						T = 0;//running total of fish
						Tx = 0;
						x = 0;
						x2 = 0;
						k = 0;//number of sweeps

						P = 0;//probability of recapture
						N = 0;//
						D = 0;//Density
						B = 0;//Biomass
						PHS = 0;//Percent Habitat Saturation

						if(drv["Sweep1NoFish"].ToString()!="")
						{
							T += System.Convert.ToInt32(drv["Sweep1NoFish"].ToString());
							k++;
					
						}
						if(drv["Sweep2NoFish"].ToString()!="")
						{
							x  = T;
							x2 += T*T;
							t = System.Convert.ToInt32(drv["Sweep2NoFish"].ToString()); 
							Tx += T*t;
							T += t;
							k++;                    
						}
						if(drv["Sweep3NoFish"].ToString()!="")
						{
							x += T;
							x2 += T*T;
							t = System.Convert.ToInt32(drv["Sweep3NoFish"].ToString()); 
							Tx += T*t;
							T += t;
							k++;
						}
						if(drv["Sweep4NoFish"].ToString()!="")
						{
							x += T;
							x2 += T*T;
							t = System.Convert.ToInt32(drv["Sweep4NoFish"].ToString()); 
							Tx += T*t;
							T += t;
							k++;
						}
						if(drv["Sweep5NoFish"].ToString()!="")
						{
							x += T;
							x2 += T*T;
							t = System.Convert.ToInt32(drv["Sweep5NoFish"].ToString()); 
							Tx += T*t;
							T += t;
							k++;
						}
						if(drv["Sweep6NoFish"].ToString()!="")
						{
							x += T;
							x2 += T*T;
							t = System.Convert.ToInt32(drv["Sweep6NoFish"].ToString()); 
							Tx += T*t;
							T += t;
							k++;
						}
					
						if(txtStreamLength2.Text!="" && txtWetWidth2.Text!="")
						{
							Debug.WriteLine("recalculating Values");
							P = -(k*Tx-T*x)/(k*x2-x*x);
							N = (T+P*x)/(k*P);
							//the text boxes used below are filled in the FillSiteDetailsFields() 
							//method if the mode is modify. If the mode is add, the boxes should 
							//be filled during the add process
							D = 100*N/(System.Convert.ToDouble(txtStreamLength2.Text)*System.Convert.ToDouble(txtWetWidth2.Text));								
							Debug.WriteLine("P = "+P.ToString());
							Debug.WriteLine("N = "+N.ToString());
							Debug.WriteLine("D = "+D.ToString());

							sql = "INSERT INTO tblElectrofishingPopulationEstimate (PopulationParameter, AutoCalculatedInd, Formula, AquaticActivityID, EFDataID,  PopulationEstimate, FishSpeciesCd, FishAgeClass, AveForkLength_cm, AveWeight_gm) VALUES ('Density', True, 'Zippin', "+Session["CurrentActivityID"].ToString()+", "+drv["EFDataID"].ToString()+", "+D.ToString()+", '"+drv["FishSpeciesCd"].ToString()+"'";
							if(drv["FishAgeClass"].ToString()!="")sql += ", '"+drv["FishAgeClass"].ToString()+"'";
							else sql += ", Null";
							if(drv["AveForkLength_cm"].ToString()!="")sql+= ", "+drv["AveForkLength_cm"].ToString();
							else sql += ", Null";
							if(drv["AveWeight_gm"].ToString()!="")sql += ", "+drv["AveWeight_gm"].ToString();
							else sql += ", Null";
							sql +=")";

							ExecuteSQL(sql);
						}

						//Biomass
						if(drv["AveWeight_gm"].ToString()!="")
						{
							B = T*System.Convert.ToDouble(drv["AveWeight_gm"].ToString())*100/(System.Convert.ToDouble(txtStreamLength2.Text)*System.Convert.ToDouble(txtWetWidth2.Text));									
							Debug.WriteLine("B = "+B.ToString());
						}

						//PHS
						if(drv["AveForkLength_cm"].ToString()!="")
						{
							//Note that density is /100m^2 and should be /m^2 so must divide by 100 which cancels 100 in formula: 100*D*T*1.19
							PHS = D*1.19*Math.Pow(System.Convert.ToDouble(drv["AveForkLength_cm"].ToString()),2.61)*Math.Pow(10,-2.83);					
							Debug.WriteLine("PHS = "+PHS.ToString());
						}
					} 

					//go back to view page
					btnDone.Visible = false;
					btnCancel.Visible = false;
					btnAdd.Visible = false;
					Session["Mode"] = "View";
					SetPageMode();
				}
			}

			else
			{

				if(pnlActivityDetails.Visible)
				{

					//create activity record
					strValues = "AquaticMethodCd = " + dlstElectrofishingMethod2.SelectedValue;
					strValues += ", PermitNo = '" + txtFishCollectionPermit2.Text + "'";
					strValues += ", AquaticActivityStartDate = '" + txtDate2.Text + "'";
					strValues += ", Crew = '" + txtPersonnel2.Text + "'";
					strValues += ", Agency2Cd = '" + dlstSecondAgency2.SelectedValue + "'";
					strValues += ", Agency2Contact = '" + txtSecondAgencyContact2.Text + "'";

					sql = "UPDATE tblAquaticActivity SET " + strValues + " WHERE AquaticActivityID = " + Session["CurrentActivityID"].ToString();
					ExecuteSQL(sql);
				
					//create method record
					strValues = "";
					strValues += "SiteSetup = '" + dlstSiteSetup2.SelectedValue + "'";
					if(txtNoSweeps2.Text!="")
					{
						strValues += ",NoSweeps = " + txtNoSweeps2.Text;
					}
					else
					{
						strValues += ",NoSweeps = Null";
					}
					strValues += ",Device = '" + dlstGearUsed2.SelectedValue + "'";
					if(txtVoltage2.Text!="")
					{
						strValues += ",Voltage = " + txtVoltage2.Text;
					}
					else
					{
						strValues += ",Voltage = Null";
					}
					if(txtFrequency2.Text!="")
					{
						strValues += ",Frequency_Hz = " + txtFrequency2.Text;
					}
					else
					{
						strValues += ",Frequency_Hz = Null";
					}
					if(txtDutyCycle2.Text!="")
					{
						strValues += ",DutyCycle = " + txtDutyCycle2.Text;
					}
					else
					{
						strValues += ",DutyCycle = Null";
					}
					if(txtPOWSetting2.Text!="")
					{
						strValues += ",POWSetting = " + txtPOWSetting2.Text;
					}
					else
					{
						strValues += ",POWSetting = Null";
					}

					sql = "UPDATE tblElectrofishingMethodDetail SET " + strValues + " WHERE AquaticActivityID = " +Session["CurrentActivityID"].ToString();
					ExecuteSQL(sql);

				}

					/*
						else if(pnlSiteDetails.Visible)
						{
							//don't have to do anything, just transfer (code at bottom)
						}

						else if(pnlPhotos.Visible)
						{
							//don't have to do anything, just transfer (code at bottom)
						}

						else if(pnlWaterMeasurements.Visible)
						{
							//don't have to do anything, just transfer (code at bottom)
						}
						*/

				else if(pnlObservations.Visible)
				{
					if(dlstWaterClarity2.SelectedValue!="")
					{
						if(txtWaterClarityCd.Text!="") sql = "UPDATE tblObservations SET OandMValuesCd = " + dlstWaterClarity2.SelectedValue + " WHERE (AquaticActivityID = " + Session["CurrentActivityID"].ToString() + " AND OandMCd = 83)";
						else sql = sql = "INSERT INTO tblObservations (AquaticActivityID, OandMCd, OandMValuesCd) VALUES (" + Session["CurrentActivityID"].ToString() + ", 83, " + dlstWaterClarity2.SelectedValue + ")";
					}

					else sql = "DELETE ObservationID FROM tblObservations WHERE (AquaticActivityID = " + Session["CurrentActivityID"].ToString() + " AND OandMCd = 83)";
					ExecuteSQL(sql);
				}

				else if(pnlSweepData.Visible && Session["Mode"].ToString()=="Add")
				{
					Server.Transfer("ELECTList.aspx");
				}			
			
				btnDone.Visible = false;
				btnCancel.Visible = false;
				btnAdd.Visible = false;
				Session["Mode"] = "View";
				SetPageMode();
			}
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string sql;
			string ID = Session["CurrentActivityID"].ToString();
			//tblElectrofishingPopulationEstimate
			sql = "DELETE AquaticActivityID FROM tblElectrofishingPopulationEstimate WHERE AquaticActivityID = " + ID;
			ExecuteSQL(sql);

			//tblElectrofishingData
			sql = "DELETE AquaticActivityID FROM tblElectrofishingData WHERE AquaticActivityID = " + ID;
			ExecuteSQL(sql);

			//tblObservations
			sql = "DELETE AquaticActivityID FROM tblObservations WHERE AquaticActivityID = " + ID;
			ExecuteSQL(sql);

			//tblWaterMeasurement
			sql = "DELETE AquaticActivityID FROM tblWaterMeasurement WHERE AquaticActivityID = " + ID;
			ExecuteSQL(sql);

			//tblPhotos
			sql = "DELETE AquaticActivityID FROM tblPhotos WHERE AquaticActivityID = " + ID;
			ExecuteSQL(sql);

			//tblSiteMeasurement
			sql = "DELETE AquaticActivityID FROM tblSiteMeasurement WHERE AquaticActivityID = " + ID;
			ExecuteSQL(sql);

			//tblElectrofishingMethodDetail
			sql = "DELETE AquaticActivityID FROM tblElectrofishingMethodDetail WHERE AquaticActivityID = " + ID;
			ExecuteSQL(sql);

			//tblAquaticActivity
			sql = "DELETE AquaticActivityID FROM tblAquaticActivity WHERE AquaticActivityID = " + ID;
			ExecuteSQL(sql);			
			
			Server.Transfer("ELECTList.aspx");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{	
			switch(Session["Mode"].ToString())
			{
				case "ModifySite":
				{
					Session["SelectedSiteUseID"] = Session["OldSelectedSiteUseID"].ToString();
					Session["OldSelectedSiteUseID"] = null;
					FillSiteInfoFields();
					btnDone.Visible = false;
					btnCancel.Visible = false;
					btnAdd.Visible = false;
					Session["Mode"] = "View";
					SetPageMode();
					break;
				}
				case "Modify":
				{
					if(pnlSweepData.Visible)//editing a record of the sweep table
					{
						pnlSweepList.Visible = true;
						HideAllButtons();
						ClearSweepDataFields();
						ClearPopEstimateFields();
						ShowDisabledPopEstimateFields();
						HideEnabledPopEstimateFields();	
						ClearPopEstimateFields();					
						btnAdd.Visible = true;
						btnDone.Visible = true;
					}
					else
					{
						btnDone.Visible = false;
						btnCancel.Visible = false;
						btnAdd.Visible = false;
						Session["Mode"] = "View";
						SetPageMode();
					}
					break;
				}
				case "Add":
				{
					Server.Transfer("ELECTList.aspx");
					break;
				}
				default:
				{
					Server.Transfer("ELECTList.aspx");
					break;
				}	
			}
		}
		
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			switch(Session["Mode"].ToString())
			{
				case "ModifySite":
				{
					string sql = "UPDATE tblAquaticActivity SET AquaticSiteID = " + txtdwsiteid.Text + " WHERE AquaticActivityID = " + Session["CurrentActivityID"].ToString();
					ExecuteSQL(sql);
					Server.Transfer("ELECTList.aspx");
					break;
				}
				case "Modify"://save button is only visible when modifying activity/method section or sweep data
				{
					if(pnlActivityDetails.Visible)
					{
						btnDone_Click(sender,e);
					}
					else//modifying a sweep data record
					{
						//check if estimates have changed
						if(PopEstimateCalculation()& txtDensity1.Visible)
						{
							Page.RegisterStartupScript("Values Changed","<script language='javascript' id='Values Changed'>alert('WARNING:  The population estimates have been recalculated and do not match the currently displayed estimates. It is assumed the sweep data was edited and the estimates were not cleared and recalculated. The new calculations will be added instead. If necessary, you may edit the data after it is placed in the Sweep Data List.');</script>");
						} 

						//update sweep table
						double T = 0;
						string sql = "UPDATE tblElectrofishingData SET ";

						sql += "FishSpeciesCd = '" + dlstSpecies2.SelectedValue + "'";
						sql += ",FishAgeClass = '" + dlstAgeClass2.SelectedValue+ "'";

						if(txtAverageWeight2.Text!="")
						{
							sql += ", AveWeight_gm = " + txtAverageWeight2.Text;
						}
						else
						{
							sql += ", AveWeight_gm =  Null";
						}

						if(txtAverageForkLength2.Text!="")
						{
							sql += ", AveForkLength_cm = " + txtAverageForkLength2.Text;
						}
						else
						{
							sql += ", AveForkLength_cm = Null";
						}

						if(txtAverageTotalLength2.Text!="") sql += ", AveTotalLength_cm = " + txtAverageTotalLength2.Text;
						else sql += ", AveTotalLength_cm = Null";
				
						if(txtPercentClipped2.Text!="") sql += ", PercentClipped = " + txtPercentClipped2.Text;
						else sql += ", PercentClipped = Null";

						if(txtSweep1No2.Text!="")
						{
							sql += ", Sweep1NoFish = " + txtSweep1No2.Text;
							T += System.Convert.ToDouble(txtSweep1No2.Text);
						}
						else sql += ", Sweep1NoFish = Null";
						if(txtSweep1Time2.Text!="") sql += ", Sweep1Time_s = " + txtSweep1Time2.Text;
						else sql += ", Sweep1Time_s = Null";

						if(txtSweep2No2.Text!="")
						{
							sql += ", Sweep2NoFish = " + txtSweep2No2.Text; 
							T += System.Convert.ToDouble(txtSweep2No2.Text);
						}
						else sql += ", Sweep2NoFish = Null";
						if(txtSweep2Time2.Text!="") sql += ", Sweep2Time_s = " + txtSweep2Time2.Text;
						else sql += ", Sweep2Time_s = Null";

						if(txtSweep3No2.Text!="")
						{
							sql += ", Sweep3NoFish = " + txtSweep3No2.Text;
							T += System.Convert.ToDouble(txtSweep3No2.Text);
						}
						else sql += ", Sweep3NoFish = Null";
						if(txtSweep3Time2.Text!="") sql += ", Sweep3Time_s = " + txtSweep3Time2.Text;
						else sql += ", Sweep3Time_s = Null";

						if(txtSweep4No2.Text!="")
						{
							sql += ", Sweep4NoFish = " + txtSweep4No2.Text;
							T += System.Convert.ToDouble(txtSweep4No2.Text);
						}
						else sql += ", Sweep4NoFish = Null";
						if(txtSweep4Time2.Text!="") sql += ", Sweep4Time_s = " + txtSweep4Time2.Text;
						else sql += ", Sweep4Time_s = Null";

						if(txtSweep5No2.Text!="")
						{
							sql += ", Sweep5NoFish = " + txtSweep5No2.Text;
							T += System.Convert.ToDouble(txtSweep5No2.Text);
						}
						else sql += ", Sweep5NoFish = Null";
						if(txtSweep5Time2.Text!="") sql += ", Sweep5Time_s = " + txtSweep5Time2.Text;
						else sql += ", Sweep5Time_s = Null";
				
						if(txtSweep6No2.Text!="")
						{
							sql += ", Sweep6NoFish = " + txtSweep6No2.Text;
							T += System.Convert.ToDouble(txtSweep6No2.Text);
						}
						else sql += ", Sweep6NoFish = Null";
						if(txtSweep6Time2.Text!="") sql += ", Sweep6Time_s = " + txtSweep6Time2.Text;
						else sql += ", Sweep6Time_s = Null";

						if(T>0)	sql += ", TotalNoFish = " + T;
						else sql += ", TotalNoFish = Null";

						sql += " WHERE EFDataID = " + Session["SelectedDataID"].ToString();
						ExecuteSQL(sql);

						//delete pop estimates
						sql = "DELETE EFDataID FROM tblElectrofishingPopulationEstimate where EFDataID = " + Session["SelectedDataID"].ToString();
						ExecuteSQL(sql);

						//add new estimates
						AddPopulationEstimates(System.Convert.ToInt32(Session["SelectedDataID"].ToString()));

						FillSweepDataFields();
						ClearSweepDataFields();

						HideEnabledPopEstimateFields();
						ShowDisabledPopEstimateFields();

						ClearPopEstimateFields();

						pnlSweepList.Visible = true;
						HideAllButtons();
						btnAdd.Visible = true;
						btnDone.Visible = true;
					}
					break;
				}
			}		
		}

		protected void btnCalculatePopEstimates_Click(object sender, System.EventArgs e)
		{
			HideEnabledPopEstimateFields();
			ShowDisabledPopEstimateFields();
			rblFormula.SelectedValue = "Zippin";

			PopEstimateCalculation();
		}

		protected void btnEnterEstimates_Click(object sender, System.EventArgs e)
		{
			HideDisabledPopEstimateFields();
			ShowEnabledPopEstimateFields();	
			ClearPopEstimateFields();
		}	
		#endregion

		#region DataGrid Modify Delete
		private void dgSiteDetails2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string sql = "DELETE SiteMeasurementID FROM tblSiteMeasurement where SiteMeasurementID = " + (int)dgSiteDetails2.DataKeys[(int) e.Item.ItemIndex];
			ExecuteSQL(sql);
			FillSiteDetailsFields();
		}

		private void dgPhotos2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string sql = "DELETE PhotoID FROM tblPhotos where PhotoID = " + (int)dgPhotos2.DataKeys[(int) e.Item.ItemIndex];
			ExecuteSQL(sql);
			FillPhotosFields();
		}

		private void dgWaterMeasurements2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	
			string sql = "DELETE WaterMeasurementID FROM tblWaterMeasurement where WaterMeasurementID = " + (int)dgWaterMeasurements2.DataKeys[(int) e.Item.ItemIndex];
			ExecuteSQL(sql);
			FillWaterMeasurementsFields();
		}

		private void dgSweepData2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string sql = "DELETE EFPopulationEstimateID FROM tblElectrofishingPopulationEstimate where EFDataID = " + (int)dgSweepData2.DataKeys[(int) e.Item.ItemIndex];
			ExecuteSQL(sql);
			//FillPopulationEstimatesFields();

			sql = "DELETE EFDataID FROM tblElectrofishingData where EFDataID = " + (int)dgSweepData2.DataKeys[(int) e.Item.ItemIndex];
			ExecuteSQL(sql);
			FillSweepDataFields();			
		}

		/*
		private void dgPopulationEstimates2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string sql = "DELETE EFPopulationEstimateID FROM tblElectrofishingPopulationEstimate where EFPopulationEstimateID = " + (int)dgPopulationEstimates2.DataKeys[(int) e.Item.ItemIndex];
			ExecuteSQL(sql);
			this.FillPopulationEstimatesFields();
		}
		*/
		protected void dgSweepData2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["SelectedDataID"] = ((Label)(dgSweepData2.SelectedItem.FindControl("EFDataID"))).Text;
			Debug.WriteLine("EFDataID = "+Session["SelectedDataID"].ToString());

			pnlSweepList.Visible = false;
			HideAllButtons();
			btnSave.Visible = true;
			btnCancel.Visible = true;

			dlstSpecies2.SelectedValue = ((Label)(dgSweepData2.SelectedItem.FindControl("lblFishSpeciesCd"))).Text;
			dlstAgeClass2.SelectedValue =  ((Label)(dgSweepData2.SelectedItem.FindControl("lblFishAgeClass"))).Text;
			txtAverageWeight2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblAverageWeight"))).Text;
			txtAverageForkLength2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblAverageForkLength"))).Text;
			txtAverageTotalLength2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblAverageTotalLength"))).Text;
			txtPercentClipped2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblPercentClipped"))).Text;
			txtSweep1No2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep1Number"))).Text;
			txtSweep1Time2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep1Time"))).Text;
			txtSweep2No2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep2Number"))).Text;
			txtSweep2Time2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep2Time"))).Text;
			txtSweep3No2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep3Number"))).Text;
			txtSweep3Time2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep3Time"))).Text;
			txtSweep4No2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep4Number"))).Text;
			txtSweep4Time2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep4Time"))).Text;
			txtSweep5No2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep5Number"))).Text;
			txtSweep5Time2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep5Time"))).Text;
			txtSweep6No2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep6Number"))).Text;
			txtSweep6Time2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblSweep6Time"))).Text;
			

			if(((Label)(dgSweepData2.SelectedItem.FindControl("lblAutoCalculated"))).Text == "True")
			{
				HideEnabledPopEstimateFields();
				ShowDisabledPopEstimateFields();

				txtDensity1.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblDensity"))).Text;
				txtBiomass1.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblBiomass"))).Text;
				txtPHS1.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblPHS"))).Text;
			}
			else
			{
				HideDisabledPopEstimateFields();
				ShowEnabledPopEstimateFields();

				txtDensity2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblDensity"))).Text;
				txtBiomass2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblBiomass"))).Text;
				txtPHS2.Text = ((Label)(dgSweepData2.SelectedItem.FindControl("lblPHS"))).Text;
			}

			if(((Label)(dgSweepData2.SelectedItem.FindControl("lblFormula"))).Text != "")
			{
				rblFormula.SelectedValue = ((Label)(dgSweepData2.SelectedItem.FindControl("lblFormula"))).Text;
			}
			else
			{
				rblFormula.SelectedValue = "Zippin";
			}
		}
		#endregion

		#region Fill/Clear Fields and Lists
		//Fill Fields
		private void FillSiteInfoFields()
		{
			LoadSiteInfo();
				
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
		}

		private string FillActivityDetailsFields()
		{
			LoadtblAquaticActivity();
			DataTable tActivity = objdstblAquaticActivity.tblAquaticActivity;
			DataRow rActivity = tActivity.Rows.Find(Session["CurrentActivityID"]);

			txtFishCollectionPermit1.Text = rActivity["PermitNo"].ToString();//no field yet
			txtDate1.Text = rActivity["AquaticActivityStartDate"].ToString();
			txtPersonnel1.Text = rActivity["Crew"].ToString();

			txtSecondAgencyCd.Text = rActivity["Agency2Cd"].ToString();
			if(txtSecondAgencyCd.Text!="")
			{
				LoadAgencies();
				DataTable tAgency = objdscdAgency.cdAgency;
				DataRow rAgency = tAgency.Rows.Find(rActivity["Agency2Cd"]);
				txtSecondAgency1.Text = rAgency["Agency"].ToString();
			}

			txtSecondAgencyContact1.Text = rActivity["Agency2Contact"].ToString();

			if((bool)rActivity["IncorporatedInd"])
			{
				HideButtons();
			}
			return rActivity["AquaticMethodCd"].ToString();
		}

		private void FillMethodDetailsFields(string methodCd)
		{
			if(methodCd!="")
			{
				LoadMethodCodes();
				DataTable tMethod = objdscdAquaticActivityMethod.cdAquaticActivityMethod;
				DataRow rMethod = tMethod.Rows.Find(methodCd);

				txtElectrofishingMethodCd.Text = methodCd;
				txtElectrofishingMethod1.Text = rMethod["AquaticMethod"].ToString();
			}


			LoadtblElectrofishingMethodDetail();
			int i = dvtblElectrofishingMethodDetail.Find(Session["CurrentActivityID"].ToString());
			if(i>-1)
			{
				txtSiteSetup1.Text = dvtblElectrofishingMethodDetail[i]["SiteSetup"].ToString();
				txtNoSweeps1.Text = dvtblElectrofishingMethodDetail[i]["NoSweeps"].ToString();
				txtGearUsed1.Text = dvtblElectrofishingMethodDetail[i]["Device"].ToString();
				txtVoltage1.Text = dvtblElectrofishingMethodDetail[i]["Voltage"].ToString();
				txtFrequency1.Text = dvtblElectrofishingMethodDetail[i]["Frequency_Hz"].ToString();
				txtDutyCycle1.Text = dvtblElectrofishingMethodDetail[i]["DutyCycle"].ToString();
				txtPOWSetting1.Text = dvtblElectrofishingMethodDetail[i]["POWSetting"].ToString();
			}
		}

		private void FillDuplicateActivityDetailsFields()
		{
			txtFishCollectionPermit2.Text = txtFishCollectionPermit1.Text;
			txtDate2.Text = txtDate1.Text;
			txtPersonnel2.Text = txtPersonnel1.Text;
			dlstSecondAgency2.SelectedValue = txtSecondAgencyCd.Text;
			txtSecondAgencyContact2.Text = txtSecondAgencyContact1.Text;
		}

		private void FillDuplicateMethodDetailsFields()
		{	
			dlstElectrofishingMethod2.SelectedValue = txtElectrofishingMethodCd.Text;
			dlstSiteSetup2.SelectedValue = txtSiteSetup1.Text;
			txtNoSweeps2.Text = txtNoSweeps1.Text;
			dlstGearUsed2.SelectedValue = txtGearUsed1.Text;
			txtVoltage2.Text = txtVoltage1.Text;
			txtFrequency2.Text = txtFrequency1.Text;
			txtDutyCycle2.Text = txtDutyCycle1.Text;
			txtPOWSetting2.Text = txtPOWSetting1.Text;			
		}

		private void FillSiteDetailsFields()
		{
			LoadSiteMeasurement();
			dvDE_ELECTSiteMeasurement.RowFilter = "AquaticActivityID = "+Session["CurrentActivityID"].ToString();

			dgSiteDetails1.DataBind();
			dgSiteDetails2.DataBind();

			dvDE_ELECTSiteMeasurement.Sort = "OandMCd";
			int i = dvDE_ELECTSiteMeasurement.Find("58");//length
			int j = dvDE_ELECTSiteMeasurement.Find("59");//wet width
			
			if(i>-1 & j>-1)
			{
				txtStreamLength2.Text  = dvDE_ELECTSiteMeasurement[i]["Measurement"].ToString();
				txtWetWidth2.Text = dvDE_ELECTSiteMeasurement[j]["Measurement"].ToString();
			}
		}

		private void FillPhotosFields()
		{
			LoadtblPhotos();

			dvtblPhotos.RowFilter = "AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			dgPhotos1.DataBind();
			dgPhotos2.DataBind();
		}

		private void FillWaterMeasurementsFields()
		{
			LoadWaterMeasurement();
			dvDE_ELECTWaterMeasurement.RowFilter = "AquaticActivityID = "+Session["CurrentActivityID"].ToString();

			dgWaterMeasurements1.DataBind();
			dgWaterMeasurements2.DataBind();
		}

		private void FillObservationFields()
		{
			LoadObservations();
			dvDE_ELECTObservations.RowFilter = "AquaticActivityID = " + Session["CurrentActivityID"].ToString();
			dvDE_ELECTObservations.Sort = "OandMCd";
			int i = dvDE_ELECTObservations.Find(83);//find water clarity
			if(i>-1)
			{
				txtWaterClarity1.Text = dvDE_ELECTObservations[i]["Value"].ToString();
				txtWaterClarityCd.Text = dvDE_ELECTObservations[i]["OandMValuesCd"].ToString();
			}
			else
			{
				txtWaterClarity1.Text = "";
				txtWaterClarityCd.Text = "";
			}
		}

		private void FillDuplicateObservationFields()
		{
			dlstWaterClarity2.SelectedValue = txtWaterClarityCd.Text;
		}

		private void FillSweepDataFields()
		{
			LoadSweepData();
			dvDE_ELECTSweepData.RowFilter = "AquaticActivityID = "+Session["CurrentActivityID"].ToString();

			dgSweepData1.DataBind();
			dgSweepData2.DataBind();			
		}
		
		/*
		private void FillPopulationEstimatesFields()
		{
			LoadPopulationEstimates();
			dvDE_ELECTPopEstimates.RowFilter = "AquaticActivityID = "+Session["CurrentActivityID"].ToString();

			dgPopulationEstimates1.DataBind();
			dgPopulationEstimates2.DataBind();
		}
		*/


		//Fill Lists		
		private void FillActivityAndMethodLists()
		{
			LoadAgencies();
			dlstSecondAgency2.DataBind();
			dlstSecondAgency2.Items.Add(new ListItem("",""));
			dlstSecondAgency2.SelectedIndex = dlstSecondAgency2.Items.Count-1;

			LoadMethodCodes();
			dlstElectrofishingMethod2.DataBind();

			if(dlstSiteSetup2.Items.Count==0)
			{
				dlstSiteSetup2.Items.Add(new ListItem("Open","Open"));
				dlstSiteSetup2.Items.Add(new ListItem("Closed","Closed"));
			}

			if(dlstGearUsed2.Items.Count==0)
			{
				dlstGearUsed2.Items.Add(new ListItem("Backpack","Backpack"));
				dlstGearUsed2.Items.Add(new ListItem("Boat","Boat"));
				dlstGearUsed2.Items.Add(new ListItem("Shore-based","Shore-based"));
			}
		}

		private void FillAddMeasureInstrumentLists()
		{
			LoadMeasurementInstrumentCodes();

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 58";
			dlstStreamLength2.DataBind();
			dlstStreamLength2.SelectedValue = "11";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 59";
			dlstWetWidth2.DataBind();
			dlstWetWidth2.SelectedValue = "11";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 60";
			dlstBankWidth2.DataBind();
			dlstBankWidth2.SelectedValue = "11";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 61";
			dlstAverageDepth2.DataBind();


			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 77";
			dlstStartWaterTemperatureInstrument2.DataBind();
			dlstStartWaterTemperatureInstrument2.SelectedValue = "5";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 78";
			dlstStartAirTemperatureInstrument2.DataBind();
			dlstStartAirTemperatureInstrument2.SelectedValue = "5";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 77";
			dlstEndWaterTemperatureInstrument2.DataBind();
			dlstEndWaterTemperatureInstrument2.SelectedValue = "5";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 78";
			dlstEndAirTemperatureInstrument2.DataBind();
			dlstEndAirTemperatureInstrument2.SelectedValue = "5";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 79";
			dlstWaterVelocityInstrument2.DataBind();
			dlstWaterVelocityInstrument2.SelectedValue = "9";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 80";
			dlstWaterFlowInstrument2.DataBind();
			dlstWaterFlowInstrument2.SelectedValue = "9";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 81";
			dlstAmbientWaterConductivityInstrument2.DataBind();
			dlstAmbientWaterConductivityInstrument2.SelectedValue = "7";

			this.dvDE_OandM_Instrument.RowFilter = "OandMCd = 82";
			dlstSpecificWaterConductivityInstrument2.DataBind();
			dlstSpecificWaterConductivityInstrument2.SelectedValue = "7";
		}

		private void FillModifyMeasurementInstrumentLists(string s)
		{
			LoadMeasurementInstrumentCodes();

			if(s == "Site")
			{
				dlstInstrument2_SiteDetails.Items.Clear();
				this.dvDE_OandM_Instrument.RowFilter = "OandMCd = "+dlstValueMeasured2_SiteDetails.SelectedValue.ToString();
				dlstInstrument2_SiteDetails.DataBind();
			}
			else if (s == "Water")
			{
				dlstInstrument2_WaterMeasurements.Items.Clear();
				this.dvDE_OandM_Instrument.RowFilter = "OandMCd = "+dlstValueMeasured2_WaterMeasurements.SelectedValue.ToString();
				dlstInstrument2_WaterMeasurements.DataBind();
			}
		}

		private void FillSiteandWaterDetailsLists()
		{
			LoadOandM_Category();
			dvDE_OandM_Category.RowFilter = "OandM_Category = 'Site' OR OandM_Category = 'Aquatic Characteristic'";
			dlstGroup2.DataBind();
			dlstGroup2.SelectedIndex = 0;
			
			LoadcdOandM();

			dvcdOandM.RowFilter = "(OandM_Category = 'Site' OR OandM_Category = 'Aquatic Characteristic') AND OandM_Group = '" + dlstGroup2.SelectedValue.ToString() + "'";
			dlstValueMeasured2_SiteDetails.DataBind();
			dlstValueMeasured2_SiteDetails.SelectedIndex = 0;

			dvcdOandM.RowFilter = "OandM_Category = 'Water'";
			dlstValueMeasured2_WaterMeasurements.DataBind();
			dlstValueMeasured2_WaterMeasurements.SelectedIndex = 0;

			FillModifyMeasurementInstrumentLists("Site");
			FillModifyMeasurementInstrumentLists("Water");

			FillUnitofMeasureLists("Site");
			FillUnitofMeasureLists("Water");
		}	 
  
		private void FillUnitofMeasureLists(string s)
		{
			LoadcdUnitofMeasure();

			if(s == "Site")
			{
				dlstUnitofMeasure2_SiteDetails.Items.Clear();
				this.dvDE_OandM_UnitofMeasure.RowFilter = "OandMCd = "+dlstValueMeasured2_SiteDetails.SelectedValue.ToString();
				dlstUnitofMeasure2_SiteDetails.DataBind();
			}
			else if (s == "Water")
			{
				dlstUnitofMeasure2_WaterMeasurements.Items.Clear();
				dvDE_OandM_UnitofMeasure.RowFilter = "OandMCd = "+dlstValueMeasured2_WaterMeasurements.SelectedValue.ToString();
				dlstUnitofMeasure2_WaterMeasurements.DataBind();
			}
		}

		private void FillOandMCdList()
		{
			LoadcdOandM();

			dvcdOandM.RowFilter = "(OandM_Category = 'Site' OR OandM_Category = 'Aquatic Characteristic') AND OandM_Group = '" + dlstGroup2.SelectedValue.ToString() + "'";
			dlstValueMeasured2_SiteDetails.DataBind();
			dlstValueMeasured2_SiteDetails.SelectedIndex = 0;

			FillModifyMeasurementInstrumentLists("Site");
			FillUnitofMeasureLists("Site");
		}
	    
		private void FillObservationLists()
		{
			LoadcdOandMValues();

			dvcdOandMValues.RowFilter = "OandMCd = 83";
			dlstWaterClarityMeasurement2.DataBind();
			dlstWaterClarityMeasurement2.Items.Add(new ListItem("",""));
			dlstWaterClarityMeasurement2.SelectedValue = "";
			dlstWaterClarity2.DataBind();
			dlstWaterClarity2.Items.Add(new ListItem("",""));
			dlstWaterClarity2.SelectedValue = "";
		}

		private void FillSweepandPopulationLists()
		{			
			LoadSweepCodes();

			dlstSpecies2.Items.Clear();
			dlstSpecies2.DataBind();
			dlstAgeClass2.Items.Clear();
			dlstAgeClass2.DataBind();
			dlstAgeClass2.Items.Add(new ListItem("",""));
			dlstAgeClass2.SelectedIndex = dlstAgeClass2.Items.Count-1;

			/*
			dlstSpecies2_Population.DataBind();
			dlstAgeClass2_Population.DataBind();
			dlstAgeClass2_Population.Items.Add(new ListItem("",""));
			dlstAgeClass2_Population.SelectedIndex = dlstAgeClass2.Items.Count-1;

			LoadcdFishPopulationParameter();

			dlstPopulationParameter2.DataBind();
			*/
		}

		
		//Clear Fields	
		private void ClearSiteDetailsFields()
		{
			dlstValueMeasured2_SiteDetails.SelectedIndex = -1;
			dlstInstrument2_SiteDetails.SelectedIndex = -1;
			dlstUnitofMeasure2_SiteDetails.SelectedIndex = -1;
			txtMeasurement2_SiteDetails.Text = "";
			rblBank.SelectedValue = "";
		}

		private void ClearPhotoFields()
		{
			//txtPath2.Text = "";
			txtFileName2.Text = "";
		}

		private void ClearWaterMeasurementsFields()
		{
			dlstValueMeasured2_WaterMeasurements.SelectedIndex = -1;
			dlstInstrument2_WaterMeasurements.SelectedIndex = -1;
			dlstUnitofMeasure2_WaterMeasurements.SelectedIndex = -1;
			txtMeasurement2_WaterMeasurements.Text = "";
			txtTimeofDay2.Text = "";
		}

		private void ClearSweepDataFields()
		{
			dlstSpecies2.SelectedIndex = -1;
			dlstAgeClass2.SelectedIndex = -1;
			txtAverageWeight2.Text = "";
			txtAverageForkLength2.Text = "";
			txtAverageTotalLength2.Text = "";
			txtPercentClipped2.Text = "";
			txtSweep1No2.Text = "";
			txtSweep1Time2.Text = "";
			txtSweep2No2.Text = "";
			txtSweep2Time2.Text = "";
			txtSweep3No2.Text = "";
			txtSweep3Time2.Text = "";
			txtSweep4No2.Text = "";
			txtSweep4Time2.Text = "";
			txtSweep5No2.Text = "";
			txtSweep5Time2.Text = "";
			txtSweep6No2.Text = "";
			txtSweep6Time2.Text = "";
		}
		private void ClearPopEstimateFields()
		{
			txtDensity1.Text = "";
			txtBiomass1.Text = "";
			txtPHS1.Text = "";
			txtDensity2.Text = "";
			txtBiomass2.Text = "";
			txtPHS2.Text = "";
			rblFormula.SelectedValue = "Zippin";
		}
		#endregion

		#region Fill & Load
		public void FillAgencies(NBADWDataEntryApplication.dscdAgency dataSet1)
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

		public void LoadAgencies()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdAgency objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dscdAgency();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillAgencies(objDataSetTemp1);
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

		public void FillMethodCodes(NBADWDataEntryApplication.dscdAquaticActivityMethod dataSet1)
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
				this.oleDbdacdAquaticActivityMethod.Fill(dataSet1);
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

		public void LoadMethodCodes()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdAquaticActivityMethod objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dscdAquaticActivityMethod();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillMethodCodes(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdscdAquaticActivityMethod.Clear();
				
				// Merge the records into the main dataset.
				this.objdscdAquaticActivityMethod.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillMeasurementInstrumentCodes(NBADWDataEntryApplication.dsDE_OandM_Instrument dataSet1, NBADWDataEntryApplication.dscdOandM dataSet2)
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
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdaDE_OandM_Instrument.Fill(dataSet1);
				this.oleDbdacdOandM.Fill(dataSet2);
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

		public void LoadMeasurementInstrumentCodes()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_OandM_Instrument objDataSetTemp1;
			NBADWDataEntryApplication.dscdOandM objDataSetTemp2;

			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_OandM_Instrument();
			objDataSetTemp2 = new NBADWDataEntryApplication.dscdOandM();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillMeasurementInstrumentCodes(objDataSetTemp1, objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsDE_OandM_Instrument.Clear();
				this.objdscdOandM.Clear();
				
				// Merge the records into the main dataset.
				this.objdsDE_OandM_Instrument.Merge(objDataSetTemp1);
				this.objdscdOandM.Merge(objDataSetTemp2);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		public void FillSweepCodes(NBADWDataEntryApplication.dscdFishSpecies dataSet1, NBADWDataEntryApplication.dscdFishAgeClass dataSet2)
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
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdacdFishSpecies.Fill(dataSet1);
				this.oleDbdacdFishAgeClass.Fill(dataSet2);
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

		public void LoadSweepCodes()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdFishSpecies objDataSetTemp1;
			NBADWDataEntryApplication.dscdFishAgeClass objDataSetTemp2;

			objDataSetTemp1 = new NBADWDataEntryApplication.dscdFishSpecies();
			objDataSetTemp2 = new NBADWDataEntryApplication.dscdFishAgeClass();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillSweepCodes(objDataSetTemp1,objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdscdFishSpecies.Clear();
				this.objdscdFishAgeClass.Clear();
				
				// Merge the records into the main dataset.
				this.objdscdFishSpecies.Merge(objDataSetTemp1);
				this.objdscdFishAgeClass.Merge(objDataSetTemp2);				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		
		public void FillcdFishPopulationParameter(NBADWDataEntryApplication.dscdFishPopulationParameter dataSet2)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet2.EnforceConstraints = false;
			
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdacdFishPopulationParameter.Fill(dataSet2);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet2.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadcdFishPopulationParameter()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdFishPopulationParameter objDataSetTemp2;

			objDataSetTemp2 = new NBADWDataEntryApplication.dscdFishPopulationParameter();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillcdFishPopulationParameter(objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdscdFishPopulationParameter.Clear();
				
				// Merge the records into the main dataset.
				this.objdscdFishPopulationParameter.Merge(objDataSetTemp2);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		
		public void FillcdOandM(NBADWDataEntryApplication.dscdOandM dataSet2)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet2.EnforceConstraints = false;
			
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdacdOandM.Fill(dataSet2);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet2.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadcdOandM()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdOandM objDataSetTemp2;

			objDataSetTemp2 = new NBADWDataEntryApplication.dscdOandM();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillcdOandM(objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdscdOandM.Clear();
				
				// Merge the records into the main dataset.
				this.objdscdOandM.Merge(objDataSetTemp2);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		
		public void FillcdUnitofMeasure(NBADWDataEntryApplication.dsDE_OandM_UnitofMeasure dataSet2)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet2.EnforceConstraints = false;
			
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdaDE_OandM_UnitofMeasure.Fill(dataSet2);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet2.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadcdUnitofMeasure()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_OandM_UnitofMeasure objDataSetTemp2;

			objDataSetTemp2 = new NBADWDataEntryApplication.dsDE_OandM_UnitofMeasure();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillcdUnitofMeasure(objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsDE_OandM_UnitofMeasure.Clear();
				
				// Merge the records into the main dataset.
				this.objdsDE_OandM_UnitofMeasure.Merge(objDataSetTemp2);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		
		public void FillcdOandMValues(NBADWDataEntryApplication.dscdOandMValues dataSet2)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet2.EnforceConstraints = false;
			
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdacdOandMValues.Fill(dataSet2);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet2.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadcdOandMValues()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdOandMValues objDataSetTemp2;

			objDataSetTemp2 = new NBADWDataEntryApplication.dscdOandMValues();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillcdOandMValues(objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdscdOandMValues.Clear();
				
				// Merge the records into the main dataset.
				this.objdscdOandMValues.Merge(objDataSetTemp2);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		
		public void FillOandM_Category(NBADWDataEntryApplication.dsDE_OandM_Category dataSet2)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet2.EnforceConstraints = false;
			
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdaDE_OandM_Category.Fill(dataSet2);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet2.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}
		}

		public void LoadOandM_Category()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_OandM_Category objDataSetTemp2;

			objDataSetTemp2 = new NBADWDataEntryApplication.dsDE_OandM_Category();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillOandM_Category(objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsDE_OandM_Category.Clear();
				
				// Merge the records into the main dataset.
				this.objdsDE_OandM_Category.Merge(objDataSetTemp2);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		

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

		public void FilltblAquaticActivity(NBADWDataEntryApplication.dstblAquaticActivity dataSet1)
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
				this.oleDbdatblAquaticActivity.Fill(dataSet1);
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

		public void LoadtblAquaticActivity()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblAquaticActivity objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dstblAquaticActivity();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblAquaticActivity(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdstblAquaticActivity.Clear();
				
				// Merge the records into the main dataset.
				this.objdstblAquaticActivity.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FilltblElectrofishingMethodDetail(NBADWDataEntryApplication.dstblElectrofishingMethodDetail dataSet1)
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
				this.oleDbdatblElectrofishingMethodDetail.Fill(dataSet1);
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

		public void LoadtblElectrofishingMethodDetail()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblElectrofishingMethodDetail objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dstblElectrofishingMethodDetail();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblElectrofishingMethodDetail(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdstblElectrofishingMethodDetail.Clear();
				
				// Merge the records into the main dataset.
				this.objdstblElectrofishingMethodDetail.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillSiteMeasurement(NBADWDataEntryApplication.dsDE_ELECTSiteMeasurement dataSet1)
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
				this.oleDbdaDE_ELECTSiteMeasurement.Fill(dataSet1);
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

		public void LoadSiteMeasurement()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_ELECTSiteMeasurement objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_ELECTSiteMeasurement();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillSiteMeasurement(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_ELECTSiteMeasurement.Clear();
				
				// Merge the records into the main dataset.
				objdsDE_ELECTSiteMeasurement.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FilltblPhotos(NBADWDataEntryApplication.dstblPhotos dataSet1)
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
				this.oleDbdatblPhotos.Fill(dataSet1);
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

		public void LoadtblPhotos()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblPhotos objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dstblPhotos();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblPhotos(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblPhotos.Clear();
				
				// Merge the records into the main dataset.
				objdstblPhotos.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillWaterMeasurement(NBADWDataEntryApplication.dsDE_ELECTWaterMeasurement dataSet1)
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
				this.oleDbdaDE_ELECTWaterMeasurement.Fill(dataSet1);
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

		public void LoadWaterMeasurement()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_ELECTWaterMeasurement objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_ELECTWaterMeasurement();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillWaterMeasurement(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_ELECTWaterMeasurement.Clear();
				
				// Merge the records into the main dataset.
				objdsDE_ELECTWaterMeasurement.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillObservations(NBADWDataEntryApplication.dsDE_ELECTObservations dataSet1)
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
				this.oleDbdaDE_ELECTObservations.Fill(dataSet1);
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

		public void LoadObservations()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_ELECTObservations objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_ELECTObservations();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillObservations(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_ELECTObservations.Clear();
				
				// Merge the records into the main dataset.
				objdsDE_ELECTObservations.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillSweepData(NBADWDataEntryApplication.dsDE_ELECTSweepData dataSet1)
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
				this.oleDbdaDE_ELECTSweepData.Fill(dataSet1);
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

		public void LoadSweepData()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_ELECTSweepData objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_ELECTSweepData();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillSweepData(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_ELECTSweepData.Clear();
				
				// Merge the records into the main dataset.
				objdsDE_ELECTSweepData.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillPopulationEstimates(NBADWDataEntryApplication.dsDE_ELECTPopEstimates dataSet1)
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
				this.oleDbdaDE_ELECTPopEstimates.Fill(dataSet1);
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

		public void LoadPopulationEstimates()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_ELECTPopEstimates objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_ELECTPopEstimates();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillPopulationEstimates(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_ELECTPopEstimates.Clear();
				
				// Merge the records into the main dataset.
				objdsDE_ELECTPopEstimates.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		/*
				public void FillActivities(NBADWDataEntryApplication.dsDE_StockedFish dataSet1)
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
						this.oleDbdaDE_StockedFish.Fill(dataSet1);
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
					NBADWDataEntryApplication.dsDE_StockedFish objDataSetTemp1;
					objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_StockedFish();
			
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
						objdsDE_StockedFish.Clear();
				
						// Merge the records into the main dataset.
						objdsDE_StockedFish.Merge(objDataSetTemp1);
				
					}
					catch (System.Exception eLoadMerge) 
					{
						// Add your error handling code here.
						throw eLoadMerge;
					}
				}
				*/
		#endregion

		#region Show Hide
		private void HideButtons()
		{
			btnChangeSite.Visible = false;
			btnModifyActivityDetails.Visible = false;
			btnModifyMethodDetails.Visible = false;
			btnModifySiteDetails.Visible = false;
			btnModifyPhotos.Visible = false;
			btnModifyWaterMeasurements.Visible = false;
			btnModifySiteObservations.Visible = false;
			btnModifySweepData.Visible = false;
			//btnModifyPopulationEstimates.Visible = false;
			btnDelete.Visible = false;
			btnAdd.Visible = false;
			btnSave.Visible = false;
		}

		private void ShowButtons()
		{
			btnChangeSite.Visible = true;
			btnModifyActivityDetails.Visible = true;
			btnModifyMethodDetails.Visible = true;
			btnModifySiteDetails.Visible = true;
			btnModifyPhotos.Visible = true;
			btnModifyWaterMeasurements.Visible = true;
			btnModifySiteObservations.Visible = true;
			btnModifySweepData.Visible = true;
			//btnModifyPopulationEstimates.Visible = true;
			btnDelete.Visible = true;
		}

		private void HideAllButtons()
		{
			HideButtons();
			btnNext.Visible = false;
			btnDone.Visible = false;
			btnSave.Visible = false;
			btnCancel.Visible = false;
			btnReturn.Visible = false;
		}

		private void HidePanels()
		{
			pnlSiteInfo.Visible = false;
			pnlActivityDetails.Visible = false;
			pnlMethodDetails.Visible = false;
			pnlSiteDetails.Visible = false;
			pnlPhotos.Visible = false;
			pnlWaterMeasurements.Visible = false;
			pnlObservations.Visible = false;
			pnlSweepData.Visible = false;
		}

		private void ShowPanels()
		{
			pnlSiteInfo.Visible = true;
			pnlActivityDetails.Visible = true;
			pnlMethodDetails.Visible = true;
			pnlSiteDetails.Visible = true;
			pnlPhotos.Visible = true;
			pnlWaterMeasurements.Visible = true;
			pnlObservations.Visible = true;
			pnlSweepData.Visible = true;		
		}

		private void ShowEnabledFields(string Mode)
		{
			//Activity Details
			txtFishCollectionPermit2.Visible = true;
			txtDate2.Visible = true;
			txtPersonnel2.Visible = true;
			dlstSecondAgency2.Visible = true;
			txtSecondAgencyContact2.Visible = true;
			

			//Method Details
			dlstElectrofishingMethod2.Visible = true;
			dlstSiteSetup2.Visible = true;
			txtNoSweeps2.Visible = true;
			dlstGearUsed2.Visible = true;
			txtVoltage2.Visible = true;
			txtFrequency2.Visible = true;
			txtDutyCycle2.Visible = true;
			txtPOWSetting2.Visible = true;

			//Site Details
			switch (Mode)
			{
				case "Modify":
					pnlSiteDetailsModify.Visible = true;
					break;
				case "Add":
					pnlSiteDetailsAdd.Visible = true;
					break;
			}
			
			//Photos
			pnlPhotosAddModify.Visible = true;

			//Water Measurements
			switch (Mode)
			{
				case "Modify":
					pnlWaterMeasurementsModify.Visible = true;
					break;
				case "Add":
					pnlWaterMeasurementsAdd.Visible = true;
					break;
			}
			/*
			txtStartWaterTemp2.Visible = true;
			txtStartAirTemp2.Visible = true;
			txtStartTimeofDay2.Visible = true;
			txtEndWaterTemp2.Visible = true;
			txtEndAirTemp2.Visible = true;
			txtEndTimeofDay2.Visible = true;

			txtAmbientWaterConductivity2.Visible = true;
			txtSpecificWaterConductivity2.Visible = true;
			txtWaterVelocity2.Visible = true;
			txtWaterFlow2.Visible = true;
			txtWaterVisibility2.Visible = true;		
			*/

			//Observations
			dlstWaterClarity2.Visible = true;

            //SweepData
			pnlSweepDataAddModify.Visible = true;
			/*
			ShowSweepLabels();
			dgSweepData2.Visible = true;
			dlstSpecies2.Visible = true;
			dlstAgeClass2.Visible = true;
			txtAverageWeight2.Visible = true;
			txtAverageForkLength2.Visible = true;
			txtAverageTotalLength2.Visible = true;
			txtPercentClipped2.Visible = true;

			txtSweep1No2.Visible = true;
			txtSweep1Time2.Visible = true;
			txtSweep2No2.Visible = true;
			txtSweep2Time2.Visible = true;
			txtSweep3No2.Visible = true;
			txtSweep3Time2.Visible = true;
			txtSweep4No2.Visible = true;
			txtSweep4Time2.Visible = true;
			txtSweep5No2.Visible = true;
			txtSweep5Time2.Visible = true;
			txtSweep6No2.Visible = true;
			txtSweep6Time2.Visible = true;
			*/

			//Population Estimates
			//pnlPopulationEstimatesFields.Visible = true;
			
		}

		private void HideEnabledFields()
		{
			//Activity Details
			txtFishCollectionPermit2.Visible = false;
			txtDate2.Visible = false;
			txtPersonnel2.Visible = false;
			dlstSecondAgency2.Visible = false;
			txtSecondAgencyContact2.Visible = false;
			

			//Method Details
			dlstElectrofishingMethod2.Visible = false;
			dlstSiteSetup2.Visible = false;
			txtNoSweeps2.Visible = false;
			dlstGearUsed2.Visible = false;
			txtVoltage2.Visible = false;
			txtFrequency2.Visible = false;
			txtDutyCycle2.Visible = false;
			txtPOWSetting2.Visible = false;

			//Site Details
			pnlSiteDetailsModify.Visible = false;
			pnlSiteDetailsAdd.Visible = false;

			//Photos
			pnlPhotosAddModify.Visible = false;

			//Water Measurements
			pnlWaterMeasurementsModify.Visible = false;
			pnlWaterMeasurementsAdd.Visible = false;
			
			//Observations
			dlstWaterClarity2.Visible = false;
			
			//SweepData
			pnlSweepDataAddModify.Visible = false;			
		}

		private void ShowDisabledFields()
		{
			//Activity Details
			txtFishCollectionPermit1.Visible = true;
			txtDate1.Visible = true;
			txtPersonnel1.Visible = true;
			txtSecondAgency1.Visible = true;
			txtSecondAgencyContact1.Visible = true;
			

			//Method Details
			txtElectrofishingMethod1.Visible = true;
			txtSiteSetup1.Visible = true;
			txtNoSweeps1.Visible = true;
			txtGearUsed1.Visible = true;
			txtVoltage1.Visible = true;
			txtFrequency1.Visible = true;
			txtDutyCycle1.Visible = true;
			txtPOWSetting1.Visible = true;

			//Site Details
			pnlSiteDetailsView.Visible = true;
			
			//Photos
			pnlPhotosView.Visible = true;
			
			//Water Measurements
			pnlWaterMeasurementsView.Visible = true;
			
			//Observations
			txtWaterClarity1.Visible = true;
			
			//SweepData
			pnlSweepDataView.Visible = true;
		}

		private void HideDisabledFields()
		{
			//Activity Details
			txtFishCollectionPermit1.Visible = false;
			txtDate1.Visible = false;
			txtPersonnel1.Visible = false;
			txtSecondAgency1.Visible = false;
			txtSecondAgencyContact1.Visible = false;
			

			//Method Details
			txtElectrofishingMethod1.Visible = false;
			txtSiteSetup1.Visible = false;
			txtNoSweeps1.Visible = false;
			txtGearUsed1.Visible = false;
			txtVoltage1.Visible = false;
			txtFrequency1.Visible = false;
			txtDutyCycle1.Visible = false;
			txtPOWSetting1.Visible = false;

			//Site Details
			pnlSiteDetailsView.Visible = false;
			
			//Photos
			pnlPhotosView.Visible = false;
			
			//Water Measurements
			pnlWaterMeasurementsView.Visible = false;
			
			//Observations
			txtWaterClarity1.Visible = false;
	
			//SweepData
			pnlSweepDataView.Visible = false;	
		}

		private void ShowEnabledPopEstimateFields()
		{
			txtDensity2.Visible = true;
			txtBiomass2.Visible = true;
			txtPHS2.Visible = true;
		}
		private void HideEnabledPopEstimateFields()
		{
			txtDensity2.Visible = false;
			txtBiomass2.Visible = false;
			txtPHS2.Visible = false;
		}
		private void ShowDisabledPopEstimateFields()
		{
			txtDensity1.Visible = true;
			txtBiomass1.Visible = true;
			txtPHS1.Visible = true;
			rblFormula.Enabled = false;
		}
		private void HideDisabledPopEstimateFields()
		{
			txtDensity1.Visible = false;
			txtBiomass1.Visible = false;
			txtPHS1.Visible = false;
			rblFormula.Enabled = true;
		}
		private void HideInstructions()
		{
			pnlInstructions1.Visible = false;
			pnlInstructions2.Visible = false;
			pnlInstructions3.Visible = false;
			pnlInstructions4.Visible = false;
			pnlInstructions6a.Visible = false;			
			pnlInstructionsSiteMeasurementsModify.Visible = false;
			pnlInstructionsSitePhotosModify.Visible = false;
			pnlInstructionsWaterMeasurementsModify.Visible = false;
			pnlInstructionsSweepDataModify.Visible = false;
			pnlInstructionsChangeSite.Visible = false;
			pnlInstructionsView.Visible = false;
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
			this.oleDbdacdAgency = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdscdAgency = new NBADWDataEntryApplication.dscdAgency();
			this.oleDbdacdFishSpecies = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.objdscdFishSpecies = new NBADWDataEntryApplication.dscdFishSpecies();
			this.oleDbdacdFishAgeClass = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdscdFishAgeClass = new NBADWDataEntryApplication.dscdFishAgeClass();
			this.oleDbdaDE_ELECTSweepData = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_ELECTSweepData = new NBADWDataEntryApplication.dsDE_ELECTSweepData();
			this.dvDE_ELECTSweepData = new System.Data.DataView();
			this.oleDbdaDE_ELECTPopEstimates = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_ELECTPopEstimates = new NBADWDataEntryApplication.dsDE_ELECTPopEstimates();
			this.dvDE_ELECTPopEstimates = new System.Data.DataView();
			this.oleDbdacdAquaticActivityMethod = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.objdscdAquaticActivityMethod = new NBADWDataEntryApplication.dscdAquaticActivityMethod();
			this.dvcdAquaticActivityMethod = new System.Data.DataView();
			this.oleDbdatblAquaticActivity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand9 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand9 = new System.Data.OleDb.OleDbCommand();
			this.objdstblAquaticActivity = new NBADWDataEntryApplication.dstblAquaticActivity();
			this.oleDbdatblElectrofishingMethodDetail = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand10 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand10 = new System.Data.OleDb.OleDbCommand();
			this.objdstblElectrofishingMethodDetail = new NBADWDataEntryApplication.dstblElectrofishingMethodDetail();
			this.dvtblElectrofishingMethodDetail = new System.Data.DataView();
			this.oleDbdaDE_ELECTSiteMeasurement = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand11 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand11 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_ELECTSiteMeasurement = new NBADWDataEntryApplication.dsDE_ELECTSiteMeasurement();
			this.dvDE_ELECTSiteMeasurement = new System.Data.DataView();
			this.oleDbdacdOandM = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand12 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand12 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand6 = new System.Data.OleDb.OleDbCommand();
			this.objdscdOandM = new NBADWDataEntryApplication.dscdOandM();
			this.dvcdOandM = new System.Data.DataView();
			this.oleDbdaDE_OandM_UnitofMeasure = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand13 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand13 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdatblPhotos = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand14 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand14 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand8 = new System.Data.OleDb.OleDbCommand();
			this.objdstblPhotos = new NBADWDataEntryApplication.dstblPhotos();
			this.dvtblPhotos = new System.Data.DataView();
			this.oleDbdaDE_ELECTWaterMeasurement = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand15 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand15 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_ELECTWaterMeasurement = new NBADWDataEntryApplication.dsDE_ELECTWaterMeasurement();
			this.dvDE_ELECTWaterMeasurement = new System.Data.DataView();
			this.oleDbdacdOandMValues = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand16 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand16 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
			this.objdscdOandMValues = new NBADWDataEntryApplication.dscdOandMValues();
			this.dvcdOandMValues = new System.Data.DataView();
			this.oleDbdaDE_ELECTObservations = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand17 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand17 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_ELECTObservations = new NBADWDataEntryApplication.dsDE_ELECTObservations();
			this.dvDE_ELECTObservations = new System.Data.DataView();
			this.oleDbdaDE_OandM_Category = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand19 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand19 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_OandM_Category = new NBADWDataEntryApplication.dsDE_OandM_Category();
			this.dvDE_OandM_Category = new System.Data.DataView();
			this.dvcdFishSpecies = new System.Data.DataView();
			this.oleDbdacdFishPopulationParameter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand18 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand18 = new System.Data.OleDb.OleDbCommand();
			this.objdscdFishPopulationParameter = new NBADWDataEntryApplication.dscdFishPopulationParameter();
			this.objdsDE_OandM_UnitofMeasure = new NBADWDataEntryApplication.dsDE_OandM_UnitofMeasure();
			this.oleDbdaDE_OandM_Instrument = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand8 = new System.Data.OleDb.OleDbCommand();
			this.dvDE_OandM_Instrument = new System.Data.DataView();
			this.objdsDE_OandM_Instrument = new NBADWDataEntryApplication.dsDE_OandM_Instrument();
			this.dvDE_OandM_UnitofMeasure = new System.Data.DataView();
			this.dvcdFishAgeClass = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishSpecies)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishAgeClass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTSweepData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTSweepData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTPopEstimates)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTPopEstimates)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAquaticActivityMethod)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdAquaticActivityMethod)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblElectrofishingMethodDetail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblElectrofishingMethodDetail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTSiteMeasurement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTSiteMeasurement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdOandM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdOandM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblPhotos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblPhotos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTWaterMeasurement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTWaterMeasurement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdOandMValues)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdOandMValues)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_OandM_Category)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_OandM_Category)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishSpecies)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishPopulationParameter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_OandM_UnitofMeasure)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_OandM_Instrument)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_OandM_Instrument)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_OandM_UnitofMeasure)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishAgeClass)).BeginInit();
			this.dgSiteDetails2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSiteDetails2_DeleteCommand);
			this.dgWaterMeasurements2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgWaterMeasurements2_DeleteCommand);
			this.dgPhotos2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgPhotos2_DeleteCommand);
			this.dgSweepData2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSweepData2_DeleteCommand);
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
			}
			// 
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
			// oleDbdacdFishSpecies
			// 
			this.oleDbdacdFishSpecies.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbdacdFishSpecies.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdacdFishSpecies.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdacdFishSpecies.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "cdFishSpecies", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("FishSpecies", "FishSpecies"),
																																																							new System.Data.Common.DataColumnMapping("FishSpeciesCd", "FishSpeciesCd"),
																																																							new System.Data.Common.DataColumnMapping("StockedInd", "StockedInd"),
																																																							new System.Data.Common.DataColumnMapping("ElectrofishInd", "ElectrofishInd")})});
			this.oleDbdacdFishSpecies.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM cdFishSpecies WHERE (FishSpeciesCd = ?) AND (ElectrofishInd = ?) AND " +
				"(FishSpecies = ? OR ? IS NULL AND FishSpecies IS NULL) AND (StockedInd = ?)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ElectrofishInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StockedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StockedInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO cdFishSpecies(FishSpecies, FishSpeciesCd, StockedInd, ElectrofishInd)" +
				" VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StockedInd", System.Data.OleDb.OleDbType.Boolean, 2, "StockedInd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, "ElectrofishInd"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT FishSpecies, FishSpeciesCd, StockedInd, ElectrofishInd FROM cdFishSpecies";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE cdFishSpecies SET FishSpecies = ?, FishSpeciesCd = ?, StockedInd = ?, Elec" +
				"trofishInd = ? WHERE (FishSpeciesCd = ?) AND (ElectrofishInd = ?) AND (FishSpeci" +
				"es = ? OR ? IS NULL AND FishSpecies IS NULL) AND (StockedInd = ?)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StockedInd", System.Data.OleDb.OleDbType.Boolean, 2, "StockedInd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, "ElectrofishInd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ElectrofishInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StockedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StockedInd", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdFishSpecies
			// 
			this.objdscdFishSpecies.DataSetName = "dscdFishSpecies";
			this.objdscdFishSpecies.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdacdFishAgeClass
			// 
			this.oleDbdacdFishAgeClass.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbdacdFishAgeClass.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdacdFishAgeClass.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdacdFishAgeClass.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "cdFishAgeClass", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																							  new System.Data.Common.DataColumnMapping("FishAgeClassCategory", "FishAgeClassCategory"),
																																																							  new System.Data.Common.DataColumnMapping("ElectrofishInd", "ElectrofishInd"),
																																																							  new System.Data.Common.DataColumnMapping("FishCountInd", "FishCountInd"),
																																																							  new System.Data.Common.DataColumnMapping("StockingInd", "StockingInd")})});
			this.oleDbdacdFishAgeClass.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM cdFishAgeClass WHERE (FishAgeClass = ?) AND (ElectrofishInd = ?) AND " +
				"(FishAgeClassCategory = ? OR ? IS NULL AND FishAgeClassCategory IS NULL) AND (Fi" +
				"shCountInd = ?) AND (StockingInd = ?)";
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ElectrofishInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishCountInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishCountInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StockingInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StockingInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO cdFishAgeClass(FishAgeClass, FishAgeClassCategory, ElectrofishInd, Fi" +
				"shCountInd, StockingInd) VALUES (?, ?, ?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, "FishAgeClass"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClassCategory"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, "ElectrofishInd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishCountInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishCountInd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("StockingInd", System.Data.OleDb.OleDbType.Boolean, 2, "StockingInd"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT FishAgeClass, FishAgeClassCategory, ElectrofishInd, FishCountInd, Stocking" +
				"Ind FROM cdFishAgeClass";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = @"UPDATE cdFishAgeClass SET FishAgeClass = ?, FishAgeClassCategory = ?, ElectrofishInd = ?, FishCountInd = ?, StockingInd = ? WHERE (FishAgeClass = ?) AND (ElectrofishInd = ?) AND (FishAgeClassCategory = ? OR ? IS NULL AND FishAgeClassCategory IS NULL) AND (FishCountInd = ?) AND (StockingInd = ?)";
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, "FishAgeClass"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClassCategory"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, "ElectrofishInd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishCountInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishCountInd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StockingInd", System.Data.OleDb.OleDbType.Boolean, 2, "StockingInd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ElectrofishInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishCountInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishCountInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StockingInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StockingInd", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdFishAgeClass
			// 
			this.objdscdFishAgeClass.DataSetName = "dscdFishAgeClass";
			this.objdscdFishAgeClass.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaDE_ELECTSweepData
			// 
			this.oleDbdaDE_ELECTSweepData.InsertCommand = this.oleDbInsertCommand5;
			this.oleDbdaDE_ELECTSweepData.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbdaDE_ELECTSweepData.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "DE-ELECTSweepData", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																									new System.Data.Common.DataColumnMapping("AveForkLength_cm", "AveForkLength_cm"),
																																																									new System.Data.Common.DataColumnMapping("AveTotalLength_cm", "AveTotalLength_cm"),
																																																									new System.Data.Common.DataColumnMapping("AveWeight_gm", "AveWeight_gm"),
																																																									new System.Data.Common.DataColumnMapping("EFDataID", "EFDataID"),
																																																									new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																									new System.Data.Common.DataColumnMapping("FishSpecies", "FishSpecies"),
																																																									new System.Data.Common.DataColumnMapping("PercentClipped", "PercentClipped"),
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
																																																									new System.Data.Common.DataColumnMapping("Biomass", "Biomass"),
																																																									new System.Data.Common.DataColumnMapping("Density", "Density"),
																																																									new System.Data.Common.DataColumnMapping("PHS", "PHS"),
																																																									new System.Data.Common.DataColumnMapping("AutoCalculatedInd", "AutoCalculatedInd"),
																																																									new System.Data.Common.DataColumnMapping("FishSpeciesCd", "FishSpeciesCd"),
																																																									new System.Data.Common.DataColumnMapping("Formula", "Formula")})});
			// 
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = @"INSERT INTO [DE-ELECTSweepData] (AquaticActivityID, AveForkLength_cm, AveTotalLength_cm, AveWeight_gm, FishAgeClass, FishSpecies, PercentClipped, Sweep1NoFish, Sweep1Time_s, Sweep2NoFish, Sweep2Time_s, Sweep3NoFish, Sweep3Time_s, Sweep4NoFish, Sweep4Time_s, Sweep5NoFish, Sweep5Time_s, Sweep6NoFish, Sweep6Time_s, TotalNoFish, Biomass, Density, PHS, AutoCalculatedInd, FishSpeciesCd, Formula) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveForkLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveForkLength_cm"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveTotalLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveTotalLength_cm"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClass"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("PercentClipped", System.Data.OleDb.OleDbType.Double, 0, "PercentClipped"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep1NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep1NoFish"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep1Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep1Time_s"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep2NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep2NoFish"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep2Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep2Time_s"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep3NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep3NoFish"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep3Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep3Time_s"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep4NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep4NoFish"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep4Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep4Time_s"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep5NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep5NoFish"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep5Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep5Time_s"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep6NoFish", System.Data.OleDb.OleDbType.Double, 0, "Sweep6NoFish"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Sweep6Time_s", System.Data.OleDb.OleDbType.Double, 0, "Sweep6Time_s"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("TotalNoFish", System.Data.OleDb.OleDbType.Double, 0, "TotalNoFish"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Biomass", System.Data.OleDb.OleDbType.Double, 0, "Biomass"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Density", System.Data.OleDb.OleDbType.Double, 0, "Density"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("PHS", System.Data.OleDb.OleDbType.Double, 0, "PHS"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AutoCalculatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "AutoCalculatedInd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Formula", System.Data.OleDb.OleDbType.VarWChar, 10, "Formula"));
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = @"SELECT AquaticActivityID, AveForkLength_cm, AveTotalLength_cm, AveWeight_gm, EFDataID, FishAgeClass, FishSpecies, PercentClipped, Sweep1NoFish, Sweep1Time_s, Sweep2NoFish, Sweep2Time_s, Sweep3NoFish, Sweep3Time_s, Sweep4NoFish, Sweep4Time_s, Sweep5NoFish, Sweep5Time_s, Sweep6NoFish, Sweep6Time_s, TotalNoFish, Biomass, Density, PHS, AutoCalculatedInd, FishSpeciesCd, Formula FROM [DE-ELECTSweepData]";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// objdsDE_ELECTSweepData
			// 
			this.objdsDE_ELECTSweepData.DataSetName = "dsDE_ELECTSweepData";
			this.objdsDE_ELECTSweepData.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_ELECTSweepData
			// 
			this.dvDE_ELECTSweepData.Table = this.objdsDE_ELECTSweepData._DE_ELECTSweepData;
			// 
			// oleDbdaDE_ELECTPopEstimates
			// 
			this.oleDbdaDE_ELECTPopEstimates.InsertCommand = this.oleDbInsertCommand6;
			this.oleDbdaDE_ELECTPopEstimates.SelectCommand = this.oleDbSelectCommand6;
			this.oleDbdaDE_ELECTPopEstimates.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "DE-ELECTPopEstimates", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																										  new System.Data.Common.DataColumnMapping("AveForkLength_cm", "AveForkLength_cm"),
																																																										  new System.Data.Common.DataColumnMapping("AveWeight_gm", "AveWeight_gm"),
																																																										  new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																										  new System.Data.Common.DataColumnMapping("FishSpecies", "FishSpecies"),
																																																										  new System.Data.Common.DataColumnMapping("PopulationEstimate", "PopulationEstimate"),
																																																										  new System.Data.Common.DataColumnMapping("PopulationParameter", "PopulationParameter"),
																																																										  new System.Data.Common.DataColumnMapping("RelativeSizeClass", "RelativeSizeClass"),
																																																										  new System.Data.Common.DataColumnMapping("EFDataID", "EFDataID"),
																																																										  new System.Data.Common.DataColumnMapping("EFPopulationEstimateID", "EFPopulationEstimateID")})});
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = "INSERT INTO [DE-ELECTPopEstimates] (AquaticActivityID, AveForkLength_cm, AveWeigh" +
				"t_gm, FishAgeClass, FishSpecies, PopulationEstimate, PopulationParameter, Relati" +
				"veSizeClass, EFDataID) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveForkLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveForkLength_cm"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 10, "FishAgeClass"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("PopulationEstimate", System.Data.OleDb.OleDbType.Double, 0, "PopulationEstimate"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("PopulationParameter", System.Data.OleDb.OleDbType.VarWChar, 20, "PopulationParameter"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("RelativeSizeClass", System.Data.OleDb.OleDbType.VarWChar, 10, "RelativeSizeClass"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("EFDataID", System.Data.OleDb.OleDbType.Double, 0, "EFDataID"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT AquaticActivityID, AveForkLength_cm, AveWeight_gm, FishAgeClass, FishSpeci" +
				"es, PopulationEstimate, PopulationParameter, RelativeSizeClass, EFDataID, EFPopu" +
				"lationEstimateID FROM [DE-ELECTPopEstimates]";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			// 
			// objdsDE_ELECTPopEstimates
			// 
			this.objdsDE_ELECTPopEstimates.DataSetName = "dsDE_ELECTPopEstimates";
			this.objdsDE_ELECTPopEstimates.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_ELECTPopEstimates
			// 
			this.dvDE_ELECTPopEstimates.Table = this.objdsDE_ELECTPopEstimates._DE_ELECTPopEstimates;
			// 
			// oleDbdacdAquaticActivityMethod
			// 
			this.oleDbdacdAquaticActivityMethod.DeleteCommand = this.oleDbDeleteCommand4;
			this.oleDbdacdAquaticActivityMethod.InsertCommand = this.oleDbInsertCommand7;
			this.oleDbdacdAquaticActivityMethod.SelectCommand = this.oleDbSelectCommand7;
			this.oleDbdacdAquaticActivityMethod.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													 new System.Data.Common.DataTableMapping("Table", "cdAquaticActivityMethod", new System.Data.Common.DataColumnMapping[] {
																																																												new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																												new System.Data.Common.DataColumnMapping("AquaticMethod", "AquaticMethod"),
																																																												new System.Data.Common.DataColumnMapping("AquaticMethodCd", "AquaticMethodCd")})});
			this.oleDbdacdAquaticActivityMethod.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM cdAquaticActivityMethod WHERE (AquaticMethodCd = ?) AND (AquaticActiv" +
				"ityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticMethod = ? OR " +
				"? IS NULL AND AquaticMethod IS NULL)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethod", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethod", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethod1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethod", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand7
			// 
			this.oleDbInsertCommand7.CommandText = "INSERT INTO cdAquaticActivityMethod(AquaticActivityCd, AquaticMethod, AquaticMeth" +
				"odCd) VALUES (?, ?, ?)";
			this.oleDbInsertCommand7.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethod", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticMethod"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			// 
			// oleDbSelectCommand7
			// 
			this.oleDbSelectCommand7.CommandText = "SELECT AquaticActivityCd, AquaticMethod, AquaticMethodCd FROM cdAquaticActivityMe" +
				"thod";
			this.oleDbSelectCommand7.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = @"UPDATE cdAquaticActivityMethod SET AquaticActivityCd = ?, AquaticMethod = ?, AquaticMethodCd = ? WHERE (AquaticMethodCd = ?) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticMethod = ? OR ? IS NULL AND AquaticMethod IS NULL)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethod", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticMethod"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethod", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethod", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethod1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethod", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdAquaticActivityMethod
			// 
			this.objdscdAquaticActivityMethod.DataSetName = "dscdAquaticActivityMethod";
			this.objdscdAquaticActivityMethod.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvcdAquaticActivityMethod
			// 
			this.dvcdAquaticActivityMethod.RowFilter = "AquaticActivityCd=2";
			this.dvcdAquaticActivityMethod.Table = this.objdscdAquaticActivityMethod.cdAquaticActivityMethod;
			// 
			// oleDbdatblAquaticActivity
			// 
			this.oleDbdatblAquaticActivity.InsertCommand = this.oleDbInsertCommand9;
			this.oleDbdatblAquaticActivity.SelectCommand = this.oleDbSelectCommand9;
			this.oleDbdatblAquaticActivity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "tblAquaticActivity", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																									  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																									  new System.Data.Common.DataColumnMapping("AirTemp_C", "AirTemp_C"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityEndDate", "AquaticActivityEndDate"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityEndTime", "AquaticActivityEndTime"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityLeader", "AquaticActivityLeader"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityStartDate", "AquaticActivityStartDate"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityStartTime", "AquaticActivityStartTime"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticMethodCd", "AquaticMethodCd"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticProgramID", "AquaticProgramID"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																									  new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																									  new System.Data.Common.DataColumnMapping("Crew", "Crew"),
																																																									  new System.Data.Common.DataColumnMapping("DateEntered", "DateEntered"),
																																																									  new System.Data.Common.DataColumnMapping("IncorporatedInd", "IncorporatedInd"),
																																																									  new System.Data.Common.DataColumnMapping("OldAquaticActivityID", "OldAquaticActivityID"),
																																																									  new System.Data.Common.DataColumnMapping("oldAquaticSiteID", "oldAquaticSiteID"),
																																																									  new System.Data.Common.DataColumnMapping("PrimaryActivityInd", "PrimaryActivityInd"),
																																																									  new System.Data.Common.DataColumnMapping("Project", "Project"),
																																																									  new System.Data.Common.DataColumnMapping("Siltation", "Siltation"),
																																																									  new System.Data.Common.DataColumnMapping("WaterLevel", "WaterLevel"),
																																																									  new System.Data.Common.DataColumnMapping("WaterLevel_AM_cm", "WaterLevel_AM_cm"),
																																																									  new System.Data.Common.DataColumnMapping("WaterLevel_cm", "WaterLevel_cm"),
																																																									  new System.Data.Common.DataColumnMapping("WaterLevel_PM_cm", "WaterLevel_PM_cm"),
																																																									  new System.Data.Common.DataColumnMapping("WaterTemp_C", "WaterTemp_C"),
																																																									  new System.Data.Common.DataColumnMapping("WeatherConditions", "WeatherConditions"),
																																																									  new System.Data.Common.DataColumnMapping("Year", "Year"),
																																																									  new System.Data.Common.DataColumnMapping("PermitNo", "PermitNo"),
																																																									  new System.Data.Common.DataColumnMapping("Agency2Contact", "Agency2Contact")})});
			// 
			// oleDbInsertCommand9
			// 
			this.oleDbInsertCommand9.CommandText = @"INSERT INTO tblAquaticActivity(Agency2Cd, AgencyCd, AirTemp_C, AquaticActivityCd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityID, AquaticActivityLeader, AquaticActivityStartDate, AquaticActivityStartTime, AquaticMethodCd, AquaticProgramID, AquaticSiteID, Comments, Crew, DateEntered, IncorporatedInd, OldAquaticActivityID, oldAquaticSiteID, PrimaryActivityInd, Project, Siltation, WaterLevel, WaterLevel_AM_cm, WaterLevel_cm, WaterLevel_PM_cm, WaterTemp_C, WeatherConditions, Year, PermitNo, Agency2Contact) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand9.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "AirTemp_C"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityEndDate"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityEndTime"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivityLeader"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticProgramID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "OldAquaticActivityID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, "PrimaryActivityInd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Project", System.Data.OleDb.OleDbType.VarWChar, 100, "Project"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, "Siltation"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, "WaterLevel"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_AM_cm"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_cm"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_PM_cm"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "WaterTemp_C"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, "WeatherConditions"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Year", System.Data.OleDb.OleDbType.VarWChar, 4, "Year"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermitNo", System.Data.OleDb.OleDbType.VarChar, 20, "PermitNo"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Contact", System.Data.OleDb.OleDbType.VarChar, 50, "Agency2Contact"));
			// 
			// oleDbSelectCommand9
			// 
			this.oleDbSelectCommand9.CommandText = @"SELECT Agency2Cd, AgencyCd, AirTemp_C, AquaticActivityCd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityID, AquaticActivityLeader, AquaticActivityStartDate, AquaticActivityStartTime, AquaticMethodCd, AquaticProgramID, AquaticSiteID, Comments, Crew, DateEntered, IncorporatedInd, OldAquaticActivityID, oldAquaticSiteID, PrimaryActivityInd, Project, Siltation, WaterLevel, WaterLevel_AM_cm, WaterLevel_cm, WaterLevel_PM_cm, WaterTemp_C, WeatherConditions, Year, PermitNo, Agency2Contact FROM tblAquaticActivity";
			this.oleDbSelectCommand9.Connection = this.oleDbConnection1;
			// 
			// objdstblAquaticActivity
			// 
			this.objdstblAquaticActivity.DataSetName = "dstblAquaticActivity";
			this.objdstblAquaticActivity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdatblElectrofishingMethodDetail
			// 
			this.oleDbdatblElectrofishingMethodDetail.InsertCommand = this.oleDbInsertCommand10;
			this.oleDbdatblElectrofishingMethodDetail.SelectCommand = this.oleDbSelectCommand10;
			this.oleDbdatblElectrofishingMethodDetail.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														   new System.Data.Common.DataTableMapping("Table", "tblElectrofishingMethodDetail", new System.Data.Common.DataColumnMapping[] {
																																																															new System.Data.Common.DataColumnMapping("AquaticActivityDetailID", "AquaticActivityDetailID"),
																																																															new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																															new System.Data.Common.DataColumnMapping("Area_m2", "Area_m2"),
																																																															new System.Data.Common.DataColumnMapping("Device", "Device"),
																																																															new System.Data.Common.DataColumnMapping("NoSweeps", "NoSweeps"),
																																																															new System.Data.Common.DataColumnMapping("oldAquaticActivityID", "oldAquaticActivityID"),
																																																															new System.Data.Common.DataColumnMapping("SiteSetup", "SiteSetup"),
																																																															new System.Data.Common.DataColumnMapping("StreamLength_m", "StreamLength_m"),
																																																															new System.Data.Common.DataColumnMapping("DutyCycle", "DutyCycle"),
																																																															new System.Data.Common.DataColumnMapping("Frequency_Hz", "Frequency_Hz"),
																																																															new System.Data.Common.DataColumnMapping("POWSetting", "POWSetting"),
																																																															new System.Data.Common.DataColumnMapping("Voltage", "Voltage")})});
			// 
			// oleDbInsertCommand10
			// 
			this.oleDbInsertCommand10.CommandText = "INSERT INTO tblElectrofishingMethodDetail(AquaticActivityID, Area_m2, Device, NoS" +
				"weeps, oldAquaticActivityID, SiteSetup, StreamLength_m, DutyCycle, Frequency_Hz," +
				" POWSetting, Voltage) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand10.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Area_m2", System.Data.OleDb.OleDbType.Single, 0, "Area_m2"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Device", System.Data.OleDb.OleDbType.VarWChar, 10, "Device"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoSweeps", System.Data.OleDb.OleDbType.SmallInt, 0, "NoSweeps"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticActivityID"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("SiteSetup", System.Data.OleDb.OleDbType.VarWChar, 6, "SiteSetup"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamLength_m", System.Data.OleDb.OleDbType.Single, 0, "StreamLength_m"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("DutyCycle", System.Data.OleDb.OleDbType.Double, 0, "DutyCycle"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Frequency_Hz", System.Data.OleDb.OleDbType.Double, 0, "Frequency_Hz"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("POWSetting", System.Data.OleDb.OleDbType.Double, 0, "POWSetting"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Voltage", System.Data.OleDb.OleDbType.Double, 0, "Voltage"));
			// 
			// oleDbSelectCommand10
			// 
			this.oleDbSelectCommand10.CommandText = "SELECT AquaticActivityDetailID, AquaticActivityID, Area_m2, Device, NoSweeps, old" +
				"AquaticActivityID, SiteSetup, StreamLength_m, DutyCycle, Frequency_Hz, POWSettin" +
				"g, Voltage FROM tblElectrofishingMethodDetail";
			this.oleDbSelectCommand10.Connection = this.oleDbConnection1;
			// 
			// objdstblElectrofishingMethodDetail
			// 
			this.objdstblElectrofishingMethodDetail.DataSetName = "dstblElectrofishingMethodDetail";
			this.objdstblElectrofishingMethodDetail.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblElectrofishingMethodDetail
			// 
			this.dvtblElectrofishingMethodDetail.Sort = "AquaticActivityID";
			this.dvtblElectrofishingMethodDetail.Table = this.objdstblElectrofishingMethodDetail.tblElectrofishingMethodDetail;
			// 
			// oleDbdaDE_ELECTSiteMeasurement
			// 
			this.oleDbdaDE_ELECTSiteMeasurement.InsertCommand = this.oleDbInsertCommand11;
			this.oleDbdaDE_ELECTSiteMeasurement.SelectCommand = this.oleDbSelectCommand11;
			this.oleDbdaDE_ELECTSiteMeasurement.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													 new System.Data.Common.DataTableMapping("Table", "DE-ELECTSiteMeasurement", new System.Data.Common.DataColumnMapping[] {
																																																												new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																												new System.Data.Common.DataColumnMapping("Instrument", "Instrument"),
																																																												new System.Data.Common.DataColumnMapping("Measurement", "Measurement"),
																																																												new System.Data.Common.DataColumnMapping("OandM_Parameter", "OandM_Parameter"),
																																																												new System.Data.Common.DataColumnMapping("SiteMeasurementID", "SiteMeasurementID"),
																																																												new System.Data.Common.DataColumnMapping("UnitofMeasure", "UnitofMeasure"),
																																																												new System.Data.Common.DataColumnMapping("Bank", "Bank"),
																																																												new System.Data.Common.DataColumnMapping("OandM_Group", "OandM_Group"),
																																																												new System.Data.Common.DataColumnMapping("UnitofMeasureAbv", "UnitofMeasureAbv"),
																																																												new System.Data.Common.DataColumnMapping("OandMCd", "OandMCd")})});
			// 
			// oleDbInsertCommand11
			// 
			this.oleDbInsertCommand11.CommandText = "INSERT INTO [DE-ELECTSiteMeasurement] (AquaticActivityID, Instrument, Measurement" +
				", OandM_Parameter, UnitofMeasure, Bank, OandM_Group, UnitofMeasureAbv, OandMCd) " +
				"VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand11.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Instrument", System.Data.OleDb.OleDbType.VarChar, 50, "Instrument"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Measurement", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "Measurement", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Parameter", System.Data.OleDb.OleDbType.VarChar, 50, "OandM_Parameter"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitofMeasure", System.Data.OleDb.OleDbType.VarChar, 50, "UnitofMeasure"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Bank", System.Data.OleDb.OleDbType.VarChar, 10, "Bank"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Group", System.Data.OleDb.OleDbType.VarChar, 50, "OandM_Group"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitofMeasureAbv", System.Data.OleDb.OleDbType.VarChar, 10, "UnitofMeasureAbv"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandMCd", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "OandMCd", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbSelectCommand11
			// 
			this.oleDbSelectCommand11.CommandText = "SELECT AquaticActivityID, Instrument, Measurement, OandM_Parameter, SiteMeasureme" +
				"ntID, UnitofMeasure, Bank, OandM_Group, UnitofMeasureAbv, OandMCd FROM [DE-ELECT" +
				"SiteMeasurement]";
			this.oleDbSelectCommand11.Connection = this.oleDbConnection1;
			// 
			// objdsDE_ELECTSiteMeasurement
			// 
			this.objdsDE_ELECTSiteMeasurement.DataSetName = "dsDE_ELECTSiteMeasurement";
			this.objdsDE_ELECTSiteMeasurement.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_ELECTSiteMeasurement
			// 
			this.dvDE_ELECTSiteMeasurement.Sort = "AquaticActivityID";
			this.dvDE_ELECTSiteMeasurement.Table = this.objdsDE_ELECTSiteMeasurement._DE_ELECTSiteMeasurement;
			// 
			// oleDbdacdOandM
			// 
			this.oleDbdacdOandM.DeleteCommand = this.oleDbDeleteCommand6;
			this.oleDbdacdOandM.InsertCommand = this.oleDbInsertCommand12;
			this.oleDbdacdOandM.SelectCommand = this.oleDbSelectCommand12;
			this.oleDbdacdOandM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "cdOandM", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("OandM_Category", "OandM_Category"),
																																																				new System.Data.Common.DataColumnMapping("OandM_Group", "OandM_Group"),
																																																				new System.Data.Common.DataColumnMapping("OandM_Parameter", "OandM_Parameter"),
																																																				new System.Data.Common.DataColumnMapping("OandM_Type", "OandM_Type"),
																																																				new System.Data.Common.DataColumnMapping("OandM_ValuesInd", "OandM_ValuesInd"),
																																																				new System.Data.Common.DataColumnMapping("OandMCd", "OandMCd")})});
			this.oleDbdacdOandM.UpdateCommand = this.oleDbUpdateCommand6;
			// 
			// oleDbDeleteCommand6
			// 
			this.oleDbDeleteCommand6.CommandText = @"DELETE FROM cdOandM WHERE (OandMCd = ?) AND (OandM_Category = ? OR ? IS NULL AND OandM_Category IS NULL) AND (OandM_Group = ? OR ? IS NULL AND OandM_Group IS NULL) AND (OandM_Parameter = ? OR ? IS NULL AND OandM_Parameter IS NULL) AND (OandM_Type = ? OR ? IS NULL AND OandM_Type IS NULL) AND (OandM_ValuesInd = ?)";
			this.oleDbDeleteCommand6.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandMCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandMCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Category", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Category", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Category1", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Category", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Group", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Group", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Group1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Group", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Parameter", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Parameter", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Parameter1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Parameter", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Type", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Type", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Type1", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Type", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_ValuesInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_ValuesInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand12
			// 
			this.oleDbInsertCommand12.CommandText = "INSERT INTO cdOandM(OandM_Category, OandM_Group, OandM_Parameter, OandM_Type, Oan" +
				"dM_ValuesInd) VALUES (?, ?, ?, ?, ?)";
			this.oleDbInsertCommand12.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Category", System.Data.OleDb.OleDbType.VarWChar, 40, "OandM_Category"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Group", System.Data.OleDb.OleDbType.VarWChar, 50, "OandM_Group"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Parameter", System.Data.OleDb.OleDbType.VarWChar, 50, "OandM_Parameter"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Type", System.Data.OleDb.OleDbType.VarWChar, 16, "OandM_Type"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_ValuesInd", System.Data.OleDb.OleDbType.Boolean, 2, "OandM_ValuesInd"));
			// 
			// oleDbSelectCommand12
			// 
			this.oleDbSelectCommand12.CommandText = "SELECT OandM_Category, OandM_Group, OandM_Parameter, OandM_Type, OandM_ValuesInd," +
				" OandMCd FROM cdOandM";
			this.oleDbSelectCommand12.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand6
			// 
			this.oleDbUpdateCommand6.CommandText = @"UPDATE cdOandM SET OandM_Category = ?, OandM_Group = ?, OandM_Parameter = ?, OandM_Type = ?, OandM_ValuesInd = ? WHERE (OandMCd = ?) AND (OandM_Category = ? OR ? IS NULL AND OandM_Category IS NULL) AND (OandM_Group = ? OR ? IS NULL AND OandM_Group IS NULL) AND (OandM_Parameter = ? OR ? IS NULL AND OandM_Parameter IS NULL) AND (OandM_Type = ? OR ? IS NULL AND OandM_Type IS NULL) AND (OandM_ValuesInd = ?)";
			this.oleDbUpdateCommand6.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Category", System.Data.OleDb.OleDbType.VarWChar, 40, "OandM_Category"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Group", System.Data.OleDb.OleDbType.VarWChar, 50, "OandM_Group"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Parameter", System.Data.OleDb.OleDbType.VarWChar, 50, "OandM_Parameter"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Type", System.Data.OleDb.OleDbType.VarWChar, 16, "OandM_Type"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_ValuesInd", System.Data.OleDb.OleDbType.Boolean, 2, "OandM_ValuesInd"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandMCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandMCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Category", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Category", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Category1", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Category", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Group", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Group", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Group1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Group", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Parameter", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Parameter", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Parameter1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Parameter", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Type", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Type", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_Type1", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_Type", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandM_ValuesInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandM_ValuesInd", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdOandM
			// 
			this.objdscdOandM.DataSetName = "dscdOandM";
			this.objdscdOandM.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvcdOandM
			// 
			this.dvcdOandM.Table = this.objdscdOandM.cdOandM;
			// 
			// oleDbdaDE_OandM_UnitofMeasure
			// 
			this.oleDbdaDE_OandM_UnitofMeasure.InsertCommand = this.oleDbInsertCommand13;
			this.oleDbdaDE_OandM_UnitofMeasure.SelectCommand = this.oleDbSelectCommand13;
			this.oleDbdaDE_OandM_UnitofMeasure.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "DE-OandM_UnitofMeasure", new System.Data.Common.DataColumnMapping[] {
																																																											  new System.Data.Common.DataColumnMapping("OandMCd", "OandMCd"),
																																																											  new System.Data.Common.DataColumnMapping("UnitofMeasure", "UnitofMeasure"),
																																																											  new System.Data.Common.DataColumnMapping("UnitofMeasureCd", "UnitofMeasureCd")})});
			// 
			// oleDbInsertCommand13
			// 
			this.oleDbInsertCommand13.CommandText = "INSERT INTO [DE-OandM_UnitofMeasure] (UnitofMeasure, UnitofMeasureCd) VALUES (?, " +
				"?)";
			this.oleDbInsertCommand13.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitofMeasure", System.Data.OleDb.OleDbType.VarWChar, 50, "UnitofMeasure"));
			this.oleDbInsertCommand13.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitofMeasureCd", System.Data.OleDb.OleDbType.Integer, 0, "UnitofMeasureCd"));
			// 
			// oleDbSelectCommand13
			// 
			this.oleDbSelectCommand13.CommandText = "SELECT OandMCd, UnitofMeasure, UnitofMeasureCd FROM [DE-OandM_UnitofMeasure]";
			this.oleDbSelectCommand13.Connection = this.oleDbConnection1;
			// 
			// oleDbdatblPhotos
			// 
			this.oleDbdatblPhotos.DeleteCommand = this.oleDbDeleteCommand8;
			this.oleDbdatblPhotos.InsertCommand = this.oleDbInsertCommand14;
			this.oleDbdatblPhotos.SelectCommand = this.oleDbSelectCommand14;
			this.oleDbdatblPhotos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "tblPhotos", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																					new System.Data.Common.DataColumnMapping("FileName", "FileName"),
																																																					new System.Data.Common.DataColumnMapping("Path", "Path"),
																																																					new System.Data.Common.DataColumnMapping("PhotoID", "PhotoID")})});
			this.oleDbdatblPhotos.UpdateCommand = this.oleDbUpdateCommand8;
			// 
			// oleDbDeleteCommand8
			// 
			this.oleDbDeleteCommand8.CommandText = "DELETE FROM tblPhotos WHERE (PhotoID = ?) AND (AquaticActivityID = ? OR ? IS NULL" +
				" AND AquaticActivityID IS NULL) AND (FileName = ? OR ? IS NULL AND FileName IS N" +
				"ULL) AND (Path = ? OR ? IS NULL AND Path IS NULL)";
			this.oleDbDeleteCommand8.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhotoID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhotoID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Path", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Path", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Path1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Path", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand14
			// 
			this.oleDbInsertCommand14.CommandText = "INSERT INTO tblPhotos(AquaticActivityID, FileName, Path) VALUES (?, ?, ?)";
			this.oleDbInsertCommand14.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileName", System.Data.OleDb.OleDbType.VarWChar, 50, "FileName"));
			this.oleDbInsertCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("Path", System.Data.OleDb.OleDbType.VarWChar, 50, "Path"));
			// 
			// oleDbSelectCommand14
			// 
			this.oleDbSelectCommand14.CommandText = "SELECT AquaticActivityID, FileName, Path, PhotoID FROM tblPhotos";
			this.oleDbSelectCommand14.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand8
			// 
			this.oleDbUpdateCommand8.CommandText = "UPDATE tblPhotos SET AquaticActivityID = ?, FileName = ?, Path = ? WHERE (PhotoID" +
				" = ?) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND" +
				" (FileName = ? OR ? IS NULL AND FileName IS NULL) AND (Path = ? OR ? IS NULL AND" +
				" Path IS NULL)";
			this.oleDbUpdateCommand8.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileName", System.Data.OleDb.OleDbType.VarWChar, 50, "FileName"));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Path", System.Data.OleDb.OleDbType.VarWChar, 50, "Path"));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhotoID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhotoID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Path", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Path", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Path1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Path", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblPhotos
			// 
			this.objdstblPhotos.DataSetName = "dstblPhotos";
			this.objdstblPhotos.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblPhotos
			// 
			this.dvtblPhotos.Table = this.objdstblPhotos.tblPhotos;
			// 
			// oleDbdaDE_ELECTWaterMeasurement
			// 
			this.oleDbdaDE_ELECTWaterMeasurement.InsertCommand = this.oleDbInsertCommand15;
			this.oleDbdaDE_ELECTWaterMeasurement.SelectCommand = this.oleDbSelectCommand15;
			this.oleDbdaDE_ELECTWaterMeasurement.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "DE-ELECTWaterMeasurement", new System.Data.Common.DataColumnMapping[] {
																																																												  new System.Data.Common.DataColumnMapping("Instrument", "Instrument"),
																																																												  new System.Data.Common.DataColumnMapping("Measurement", "Measurement"),
																																																												  new System.Data.Common.DataColumnMapping("OandM_Parameter", "OandM_Parameter"),
																																																												  new System.Data.Common.DataColumnMapping("TimeofDay", "TimeofDay"),
																																																												  new System.Data.Common.DataColumnMapping("UnitofMeasure", "UnitofMeasure"),
																																																												  new System.Data.Common.DataColumnMapping("WaterDepth_m", "WaterDepth_m"),
																																																												  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																												  new System.Data.Common.DataColumnMapping("WaterMeasurementID", "WaterMeasurementID"),
																																																												  new System.Data.Common.DataColumnMapping("UnitofMeasureAbv", "UnitofMeasureAbv")})});
			// 
			// oleDbInsertCommand15
			// 
			this.oleDbInsertCommand15.CommandText = "INSERT INTO [DE-ELECTWaterMeasurement] (Instrument, Measurement, OandM_Parameter," +
				" TimeofDay, UnitofMeasure, WaterDepth_m, AquaticActivityID, UnitofMeasureAbv) VA" +
				"LUES (?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand15.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("Instrument", System.Data.OleDb.OleDbType.VarWChar, 50, "Instrument"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("Measurement", System.Data.OleDb.OleDbType.Single, 0, "Measurement"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Parameter", System.Data.OleDb.OleDbType.VarWChar, 50, "OandM_Parameter"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "TimeofDay"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitofMeasure", System.Data.OleDb.OleDbType.VarWChar, 50, "UnitofMeasure"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_m", System.Data.OleDb.OleDbType.Single, 0, "WaterDepth_m"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitofMeasureAbv", System.Data.OleDb.OleDbType.VarWChar, 10, "UnitofMeasureAbv"));
			// 
			// oleDbSelectCommand15
			// 
			this.oleDbSelectCommand15.CommandText = "SELECT Instrument, Measurement, OandM_Parameter, TimeofDay, UnitofMeasure, WaterD" +
				"epth_m, AquaticActivityID, WaterMeasurementID, UnitofMeasureAbv FROM [DE-ELECTWa" +
				"terMeasurement]";
			this.oleDbSelectCommand15.Connection = this.oleDbConnection1;
			// 
			// objdsDE_ELECTWaterMeasurement
			// 
			this.objdsDE_ELECTWaterMeasurement.DataSetName = "dsDE_ELECTWaterMeasurement";
			this.objdsDE_ELECTWaterMeasurement.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_ELECTWaterMeasurement
			// 
			this.dvDE_ELECTWaterMeasurement.Table = this.objdsDE_ELECTWaterMeasurement._DE_ELECTWaterMeasurement;
			// 
			// oleDbdacdOandMValues
			// 
			this.oleDbdacdOandMValues.DeleteCommand = this.oleDbDeleteCommand5;
			this.oleDbdacdOandMValues.InsertCommand = this.oleDbInsertCommand16;
			this.oleDbdacdOandMValues.SelectCommand = this.oleDbSelectCommand16;
			this.oleDbdacdOandMValues.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "cdOandMValues", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("OandMCd", "OandMCd"),
																																																							new System.Data.Common.DataColumnMapping("OandMValuesCd", "OandMValuesCd"),
																																																							new System.Data.Common.DataColumnMapping("Value", "Value")})});
			this.oleDbdacdOandMValues.UpdateCommand = this.oleDbUpdateCommand5;
			// 
			// oleDbDeleteCommand5
			// 
			this.oleDbDeleteCommand5.CommandText = "DELETE FROM cdOandMValues WHERE (OandMValuesCd = ?) AND (OandMCd = ? OR ? IS NULL" +
				" AND OandMCd IS NULL) AND (Value = ? OR ? IS NULL AND Value IS NULL)";
			this.oleDbDeleteCommand5.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandMValuesCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandMValuesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandMCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandMCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandMCd1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandMCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Value", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Value", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Value1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Value", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand16
			// 
			this.oleDbInsertCommand16.CommandText = "INSERT INTO cdOandMValues(OandMCd, Value) VALUES (?, ?)";
			this.oleDbInsertCommand16.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandMCd", System.Data.OleDb.OleDbType.Integer, 0, "OandMCd"));
			this.oleDbInsertCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("Value", System.Data.OleDb.OleDbType.VarWChar, 20, "Value"));
			// 
			// oleDbSelectCommand16
			// 
			this.oleDbSelectCommand16.CommandText = "SELECT OandMCd, OandMValuesCd, Value FROM cdOandMValues";
			this.oleDbSelectCommand16.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand5
			// 
			this.oleDbUpdateCommand5.CommandText = "UPDATE cdOandMValues SET OandMCd = ?, Value = ? WHERE (OandMValuesCd = ?) AND (Oa" +
				"ndMCd = ? OR ? IS NULL AND OandMCd IS NULL) AND (Value = ? OR ? IS NULL AND Valu" +
				"e IS NULL)";
			this.oleDbUpdateCommand5.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandMCd", System.Data.OleDb.OleDbType.Integer, 0, "OandMCd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Value", System.Data.OleDb.OleDbType.VarWChar, 20, "Value"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandMValuesCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandMValuesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandMCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandMCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OandMCd1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OandMCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Value", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Value", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Value1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Value", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdOandMValues
			// 
			this.objdscdOandMValues.DataSetName = "dscdOandMValues";
			this.objdscdOandMValues.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvcdOandMValues
			// 
			this.dvcdOandMValues.Table = this.objdscdOandMValues.cdOandMValues;
			// 
			// oleDbdaDE_ELECTObservations
			// 
			this.oleDbdaDE_ELECTObservations.InsertCommand = this.oleDbInsertCommand17;
			this.oleDbdaDE_ELECTObservations.SelectCommand = this.oleDbSelectCommand17;
			this.oleDbdaDE_ELECTObservations.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "DE-ELECTObservations", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																										  new System.Data.Common.DataColumnMapping("FishPassageObstructionInd", "FishPassageObstructionInd"),
																																																										  new System.Data.Common.DataColumnMapping("OandM_Other", "OandM_Other"),
																																																										  new System.Data.Common.DataColumnMapping("OandM_Parameter", "OandM_Parameter"),
																																																										  new System.Data.Common.DataColumnMapping("OandMCd", "OandMCd"),
																																																										  new System.Data.Common.DataColumnMapping("OandMValuesCd", "OandMValuesCd"),
																																																										  new System.Data.Common.DataColumnMapping("ObservationID", "ObservationID"),
																																																										  new System.Data.Common.DataColumnMapping("PipeSize_cm", "PipeSize_cm"),
																																																										  new System.Data.Common.DataColumnMapping("Value", "Value")})});
			// 
			// oleDbInsertCommand17
			// 
			this.oleDbInsertCommand17.CommandText = "INSERT INTO [DE-ELECTObservations] (AquaticActivityID, FishPassageObstructionInd," +
				" OandM_Other, OandM_Parameter, OandMCd, OandMValuesCd, PipeSize_cm, Value) VALUE" +
				"S (?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand17.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishPassageObstructionInd"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Other", System.Data.OleDb.OleDbType.VarWChar, 50, "OandM_Other"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Parameter", System.Data.OleDb.OleDbType.VarWChar, 50, "OandM_Parameter"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandMCd", System.Data.OleDb.OleDbType.Integer, 0, "OandMCd"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandMValuesCd", System.Data.OleDb.OleDbType.Integer, 0, "OandMValuesCd"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, "PipeSize_cm"));
			this.oleDbInsertCommand17.Parameters.Add(new System.Data.OleDb.OleDbParameter("Value", System.Data.OleDb.OleDbType.VarWChar, 20, "Value"));
			// 
			// oleDbSelectCommand17
			// 
			this.oleDbSelectCommand17.CommandText = "SELECT AquaticActivityID, FishPassageObstructionInd, OandM_Other, OandM_Parameter" +
				", OandMCd, OandMValuesCd, ObservationID, PipeSize_cm, Value FROM [DE-ELECTObserv" +
				"ations]";
			this.oleDbSelectCommand17.Connection = this.oleDbConnection1;
			// 
			// objdsDE_ELECTObservations
			// 
			this.objdsDE_ELECTObservations.DataSetName = "dsDE_ELECTObservations";
			this.objdsDE_ELECTObservations.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_ELECTObservations
			// 
			this.dvDE_ELECTObservations.Table = this.objdsDE_ELECTObservations._DE_ELECTObservations;
			// 
			// oleDbdaDE_OandM_Category
			// 
			this.oleDbdaDE_OandM_Category.InsertCommand = this.oleDbInsertCommand19;
			this.oleDbdaDE_OandM_Category.SelectCommand = this.oleDbSelectCommand19;
			this.oleDbdaDE_OandM_Category.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "DE-OandM_Category", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("OandM_Category", "OandM_Category"),
																																																									new System.Data.Common.DataColumnMapping("OandM_Group", "OandM_Group")})});
			// 
			// oleDbInsertCommand19
			// 
			this.oleDbInsertCommand19.CommandText = "INSERT INTO [DE-OandM_Category] (OandM_Category, OandM_Group) VALUES (?, ?)";
			this.oleDbInsertCommand19.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Category", System.Data.OleDb.OleDbType.VarWChar, 40, "OandM_Category"));
			this.oleDbInsertCommand19.Parameters.Add(new System.Data.OleDb.OleDbParameter("OandM_Group", System.Data.OleDb.OleDbType.VarWChar, 50, "OandM_Group"));
			// 
			// oleDbSelectCommand19
			// 
			this.oleDbSelectCommand19.CommandText = "SELECT OandM_Category, OandM_Group FROM [DE-OandM_Category]";
			this.oleDbSelectCommand19.Connection = this.oleDbConnection1;
			// 
			// objdsDE_OandM_Category
			// 
			this.objdsDE_OandM_Category.DataSetName = "dsDE_OandM_Category";
			this.objdsDE_OandM_Category.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_OandM_Category
			// 
			this.dvDE_OandM_Category.Table = this.objdsDE_OandM_Category._DE_OandM_Category;
			// 
			// dvcdFishSpecies
			// 
			this.dvcdFishSpecies.RowFilter = "ElectrofishInd";
			this.dvcdFishSpecies.Table = this.objdscdFishSpecies.cdFishSpecies;
			// 
			// oleDbdacdFishPopulationParameter
			// 
			this.oleDbdacdFishPopulationParameter.InsertCommand = this.oleDbInsertCommand18;
			this.oleDbdacdFishPopulationParameter.SelectCommand = this.oleDbSelectCommand18;
			this.oleDbdacdFishPopulationParameter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "cdFishPopulationParameter", new System.Data.Common.DataColumnMapping[] {
																																																													new System.Data.Common.DataColumnMapping("PopulationParameter", "PopulationParameter")})});
			// 
			// oleDbInsertCommand18
			// 
			this.oleDbInsertCommand18.CommandText = "INSERT INTO cdFishPopulationParameter(PopulationParameter) VALUES (?)";
			this.oleDbInsertCommand18.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("PopulationParameter", System.Data.OleDb.OleDbType.VarWChar, 20, "PopulationParameter"));
			// 
			// oleDbSelectCommand18
			// 
			this.oleDbSelectCommand18.CommandText = "SELECT PopulationParameter FROM cdFishPopulationParameter";
			this.oleDbSelectCommand18.Connection = this.oleDbConnection1;
			// 
			// objdscdFishPopulationParameter
			// 
			this.objdscdFishPopulationParameter.DataSetName = "dscdFishPopulationParameter";
			this.objdscdFishPopulationParameter.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// objdsDE_OandM_UnitofMeasure
			// 
			this.objdsDE_OandM_UnitofMeasure.DataSetName = "dsDE_OandM_UnitofMeasure";
			this.objdsDE_OandM_UnitofMeasure.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaDE_OandM_Instrument
			// 
			this.oleDbdaDE_OandM_Instrument.InsertCommand = this.oleDbInsertCommand8;
			this.oleDbdaDE_OandM_Instrument.SelectCommand = this.oleDbSelectCommand8;
			this.oleDbdaDE_OandM_Instrument.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "DE-OandM_Instrument", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("Instrument", "Instrument"),
																																																										new System.Data.Common.DataColumnMapping("InstrumentCd", "InstrumentCd"),
																																																										new System.Data.Common.DataColumnMapping("OandMCd", "OandMCd")})});
			// 
			// oleDbInsertCommand8
			// 
			this.oleDbInsertCommand8.CommandText = "INSERT INTO [DE-OandM_Instrument] (Instrument) VALUES (?)";
			this.oleDbInsertCommand8.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Instrument", System.Data.OleDb.OleDbType.VarWChar, 50, "Instrument"));
			// 
			// oleDbSelectCommand8
			// 
			this.oleDbSelectCommand8.CommandText = "SELECT Instrument, InstrumentCd, OandMCd FROM [DE-OandM_Instrument]";
			this.oleDbSelectCommand8.Connection = this.oleDbConnection1;
			// 
			// dvDE_OandM_Instrument
			// 
			this.dvDE_OandM_Instrument.Table = this.objdsDE_OandM_Instrument._DE_OandM_Instrument;
			// 
			// objdsDE_OandM_Instrument
			// 
			this.objdsDE_OandM_Instrument.DataSetName = "dsDE_OandM_Instrument";
			this.objdsDE_OandM_Instrument.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_OandM_UnitofMeasure
			// 
			this.dvDE_OandM_UnitofMeasure.Table = this.objdsDE_OandM_UnitofMeasure._DE_OandM_UnitofMeasure;
			// 
			// dvcdFishAgeClass
			// 
			this.dvcdFishAgeClass.RowFilter = "ElectrofishInd";
			this.dvcdFishAgeClass.Table = this.objdscdFishAgeClass.cdFishAgeClass;
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishSpecies)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishAgeClass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTSweepData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTSweepData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTPopEstimates)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTPopEstimates)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAquaticActivityMethod)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdAquaticActivityMethod)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblElectrofishingMethodDetail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblElectrofishingMethodDetail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTSiteMeasurement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTSiteMeasurement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdOandM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdOandM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblPhotos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblPhotos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTWaterMeasurement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTWaterMeasurement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdOandMValues)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdOandMValues)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_ELECTObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_ELECTObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_OandM_Category)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_OandM_Category)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishSpecies)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishPopulationParameter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_OandM_UnitofMeasure)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_OandM_Instrument)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_OandM_Instrument)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_OandM_UnitofMeasure)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishAgeClass)).EndInit();

		}
		#endregion

		private void SetPageMode()
		{
			switch(Session["Mode"].ToString())
			{
				case "Add":
					lblh2.Text = "ADD Electrofishing Data";
					HideInstructions();
					HideButtons();
					HidePanels();
					HideDisabledFields();
					ShowEnabledFields("Add");	
					pnlInstructions1.Visible = true;
					pnlSiteInfo.Visible = true;
					pnlActivityDetails.Visible = true;
					pnlMethodDetails.Visible = true;					
					btnNext.Visible = true;
					btnCancel.Visible = true;
					btnReturn.Visible = false;

					FillActivityAndMethodLists();
					FillAddMeasureInstrumentLists();
					FillObservationLists();
					FillSweepandPopulationLists();
					
					dgPhotos2.DataBind();
					dgSweepData2.DataBind();
					break;
				case "View":
					HideInstructions();
					HideButtons();
					if((bool)Session["Administrator"])
					{
						pnlInstructionsView.Visible = true;
						ShowButtons();						
					}
					lblh2.Text = "VIEW Electrofishing";
					ShowPanels();
					ShowDisabledFields();
					HideEnabledFields();
					btnReturn.Visible = true;
					btnNext.Visible = false;

					//get data
					string s = FillActivityDetailsFields();
					FillMethodDetailsFields(s);
					FillSiteDetailsFields();
					FillPhotosFields();
					FillWaterMeasurementsFields();
					FillObservationFields();
					FillSweepDataFields();					
					break;
				case "Modify":
					lblh2.Text = "EDIT Electrofishing";
					HideInstructions();
					HideDisabledFields();
					ShowEnabledFields("Modify");
					btnReturn.Visible = false;
					btnNext.Visible = false;
					break;
				case "ModifySite":
					lblh2.Text = "EDIT Electrofishing";
					HideInstructions();
					pnlInstructionsChangeSite.Visible = true;
					HideButtons();	
					btnSave.Visible = true;
					btnCancel.Visible = true;
					btnReturn.Visible = false;
					ShowPanels();
					ShowDisabledFields();
					HideEnabledFields();

					s = FillActivityDetailsFields();
					FillMethodDetailsFields(s);
					FillSiteDetailsFields();
					FillPhotosFields();
					FillWaterMeasurementsFields();
					FillObservationFields();
					FillSweepDataFields();
					break;
			}
		}
		
		private void Modify(int i)
		{
			Session["Mode"] = "Modify";
			SetPageMode();
			HidePanels();
			HideButtons();
			btnDone.Visible = true;			

			switch (i)
			{
				case 1:
					//lblh2.Text = "MODIFY Activity & Method Details";
					pnlActivityDetails.Visible = true;
					pnlMethodDetails.Visible = true;
					btnDone.Visible = false;
					btnSave.Visible = true;
					btnCancel.Visible = true;
					FillActivityAndMethodLists();
					FillDuplicateActivityDetailsFields();
					FillDuplicateMethodDetailsFields();
					break;
				case 2:
					//lblh2.Text = "MODIFY Site Details";
					pnlInstructionsSiteMeasurementsModify.Visible = true;
					pnlSiteDetails.Visible = true;
					btnAdd.Visible = true;
					if(dlstInstrument2_SiteDetails.Items.Count==0)
					{
						FillSiteandWaterDetailsLists();
					}
					break;
				case 3:
					//lblh2.Text = "MODIFY Photos";
					pnlInstructionsSitePhotosModify.Visible = true;
					pnlPhotos.Visible = true;
					btnAdd.Visible = true;
					break;
				case 4:
					//lblh2.Text = "MODIFY Water Measurements";
					pnlInstructionsWaterMeasurementsModify.Visible = true;
					pnlWaterMeasurements.Visible = true;
					btnAdd.Visible = true;
					if(dlstInstrument2_WaterMeasurements.Items.Count==0)
					{
						FillSiteandWaterDetailsLists();
					}
					break;
				case 5:
					//lblh2.Text = "Modify Site Observations";
					pnlObservations.Visible = true;
					
					FillObservationLists();
					FillDuplicateObservationFields();
					break;
				case 6:
					//lblh2.Text = "MODIFY Sweep Data";
					pnlInstructionsSweepDataModify.Visible = true;
					pnlSweepData.Visible = true;
					btnAdd.Visible = true;

					FillSweepandPopulationLists();
					break;				
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

		private int ExecuteSQL(string s)
		{
			
			Debug.WriteLine("SQL: "+s);
			int i = 0;
			try
			{
				oleDbConnection1.Open();
				OleDbCommand cmd = new OleDbCommand(s, oleDbConnection1);
				cmd.ExecuteNonQuery();
				OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", oleDbConnection1);
				i = (int)idCMD.ExecuteScalar();			
				
				oleDbConnection1.Close();
			}
			catch(Exception err)
			{
				Debug.WriteLine("Error during database command: "+err.ToString());
				oleDbConnection1.Close();
			}

			return i;
		}

		protected void dlstGroup2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillOandMCdList();		
		}

		protected void dlstValueMeasured2_SiteDetails_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillModifyMeasurementInstrumentLists("Site");
			FillUnitofMeasureLists("Site");		
		}

		protected void dlstValueMeasured2_WaterMeasurements_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillModifyMeasurementInstrumentLists("Water");
			FillUnitofMeasureLists("Water");	
		}

		private void AddPopulationEstimates(int autoindex)
		{
			string sql = "INSERT INTO tblElectrofishingPopulationEstimate (AquaticActivityID, EFDataID, PopulationParameter, PopulationEstimate, AutoCalculatedInd, FishSpeciesCd, FishAgeClass, AveForkLength_cm, AveWeight_gm, Formula) VALUES ("+Session["CurrentActivityID"].ToString()+", "+autoindex.ToString();
			string strValues = "";		
			if((txtDensity1.Visible && txtDensity1.Text!="") || (txtDensity2.Visible &&txtDensity2.Text!=""))
			{
				strValues =", 'Density', ";
				if(txtDensity1.Visible) strValues += txtDensity1.Text + ", True";
				else strValues += txtDensity2.Text + ", False";

				strValues += ", '" + dlstSpecies2.SelectedValue + "', '" + dlstAgeClass2.SelectedValue+ "'";
				if(txtAverageForkLength2.Text!="")
				{
					strValues += ", " + txtAverageForkLength2.Text;
				}
				else
				{
					strValues += ", Null";
				}
				if(txtAverageWeight2.Text!="")
				{
					strValues += ", " + txtAverageWeight2.Text;
				}
				else
				{
					strValues += ", Null";
				}

				strValues += ", '" +rblFormula.SelectedValue.ToString()+"'";
				strValues+=")";
				ExecuteSQL(sql+strValues);					
			}

			//Biomass
			if((txtBiomass1.Visible && txtBiomass1.Text!="0") || (txtBiomass2.Visible && txtBiomass2.Text!=""))
			{
				strValues =", 'Biomass', ";
					
				if(txtBiomass1.Visible) strValues += txtBiomass1.Text + ", True";
				else strValues += txtBiomass2.Text + ", False";

				strValues += ", '" + dlstSpecies2.SelectedValue + "', '" + dlstAgeClass2.SelectedValue+ "'";
										
				if(txtAverageForkLength2.Text!="")
				{
					strValues += ", " + txtAverageForkLength2.Text;
				}
				else
				{
					strValues += ", Null";
				}
				if(txtAverageWeight2.Text!="")
				{
					strValues += ", " + txtAverageWeight2.Text;
				}
				else
				{
					strValues += ", Null";
				}

				strValues += ", '" +rblFormula.SelectedValue.ToString()+"'";
				strValues+=")";
				ExecuteSQL(sql+strValues);						
			}

			//PHS
			if((txtPHS1.Visible && txtPHS1.Text!="0") || (txtPHS2.Visible &&txtPHS2.Text!=""))
			{
				strValues =", 'PHS', ";

				if(txtPHS1.Visible) strValues += txtPHS1.Text + ", True";
				else strValues += txtPHS2.Text + ", False";
					
				strValues += ", '" + dlstSpecies2.SelectedValue + "', '" + dlstAgeClass2.SelectedValue+ "'";
					
				if(txtAverageForkLength2.Text!="")
				{
					strValues += ", " + txtAverageForkLength2.Text;
				}
				else
				{
					strValues += ", Null";
				}
				if(txtAverageWeight2.Text!="")
				{
					strValues += ", " + txtAverageWeight2.Text;
				}
				else
				{
					strValues += ", Null";
				}

				strValues += ", '" +rblFormula.SelectedValue.ToString()+"'";
				strValues+=")";
				ExecuteSQL(sql+strValues);						
			}
		}
										
		private bool PopEstimateCalculation()
		{
			double t, T, Tx, x, x2, k;
			double P,N,D,B,PHS;
			bool changedD, changedB, changedPHS;//false = no change, true = value has been changed
			
			t = 0;//value entered for particular sweep
			T = 0;//running total of fish
			Tx = 0;
			x = 0;
			x2 = 0;
			k = 0;

			P = 0;//probability of recapture
			N = 0;//number of sweeps
			D = 0;//Density
			B = 0;//Biomass
			PHS = 0;//Percent Habitat Saturation

			changedD = false;
			changedB = false;
			changedPHS = false;

				
			if(txtSweep1No2.Text!="")
			{
				T += System.Convert.ToInt32(txtSweep1No2.Text);
				k++;
					
			}
			if(txtSweep2No2.Text!="")
			{
				x  = T;
				x2 += T*T;
				t = System.Convert.ToInt32(txtSweep2No2.Text); 
				Tx += T*t;
				T += t;
				k++;                    
			}
			if(txtSweep3No2.Text!="")
			{
				x += T;
				x2 += T*T;
				t = System.Convert.ToInt32(txtSweep3No2.Text); 
				Tx += T*t;
				T += t;
				k++;
			}
			if(txtSweep4No2.Text!="")
			{
				x += T;
				x2 += T*T;
				t = System.Convert.ToInt32(txtSweep4No2.Text); 
				Tx += T*t;
				T += t;
				k++;
			}
			if(txtSweep5No2.Text!="")
			{
				x += T;
				x2 += T*T;
				t = System.Convert.ToInt32(txtSweep5No2.Text); 
				Tx += T*t;
				T += t;
				k++;
			}
			if(txtSweep6No2.Text!="")
			{
				x += T;
				x2 += T*T;
				t = System.Convert.ToInt32(txtSweep6No2.Text); 
				Tx += T*t;
				T += t;
				k++;
			}
			
			if(txtStreamLength2.Text!="" && txtWetWidth2.Text!="")
			{
				Debug.WriteLine("Calculating Values");
				P = -(k*Tx-T*x)/(k*x2-x*x);
				N = (T+P*x)/(k*P);
				//the text boxes used below are filled in the FillSiteDetailsFields() 
				//method if the mode is modify. If the mode is add, the boxes should 
				//be filled during the add process
				D = 100*N/(System.Convert.ToDouble(txtStreamLength2.Text)*System.Convert.ToDouble(txtWetWidth2.Text));								
				Debug.WriteLine("P = "+P.ToString());
				Debug.WriteLine("N = "+N.ToString());
				Debug.WriteLine("D = "+D.ToString());
			}

			//Biomass
			if(txtAverageWeight2.Text!="")
			{
				B = T*System.Convert.ToDouble(txtAverageWeight2.Text)*100/(System.Convert.ToDouble(txtStreamLength2.Text)*System.Convert.ToDouble(txtWetWidth2.Text));									
				Debug.WriteLine("B = "+B.ToString());
			}

			//PHS
			if(this.txtAverageForkLength2.Text!="")
			{
				//Note that density is /100m^2 and should be /m^2 so must divide by 100 which cancels 100 in formula: 100*D*T*1.19
				PHS = D*1.19*Math.Pow(System.Convert.ToDouble(txtAverageForkLength2.Text),2.61)*Math.Pow(10,-2.83);					
				Debug.WriteLine("PHS = "+PHS.ToString());
			}

			if(D.ToString() != txtDensity1.Text)changedD = true;
			if(D.ToString()!="NaN") txtDensity1.Text = D.ToString();
			else txtDensity1.Text = "0";

			if(B.ToString() != txtBiomass1.Text)changedB = true;
			if(B.ToString()!="NaN") txtBiomass1.Text = B.ToString();
			else txtBiomass1.Text = "0";

			if(PHS.ToString() != txtPHS1.Text)changedPHS = true;
			if(PHS.ToString()!="NaN") txtPHS1.Text = PHS.ToString();
			else txtPHS1.Text = "0";

			if(changedD || changedB || changedPHS) return true;
			else return false;
		}

	}
}
