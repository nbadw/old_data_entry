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
	/// Summary description for ESAFView.
	/// </summary>
	public partial class ESAFView : System.Web.UI.Page
	{
		#region Controls
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticActivity;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected NBADWDataEntryApplication.dstblAquaticActivity objdstblAquaticActivity;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblEnvironmentalObservations;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected NBADWDataEntryApplication.dstblEnvironmentalObservations objdstblEnvironmentalObservations;
		protected System.Data.DataView dvtblEnvironmentalObservations;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblEnvironmentalSurveyFieldMeasures;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		protected NBADWDataEntryApplication.dstblEnvironmentalSurveyFieldMeasures objdstblEnvironmentalSurveyFieldMeasures;
		protected System.Data.DataView dvtblEnvironmentalSurveyFieldMeasures;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblEnvironmentalPlanning;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		protected NBADWDataEntryApplication.dstblEnvPlanning objdstblEnvPlanning;
		protected System.Data.DataView dvtblEnvironmentalPlanning;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticSite;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand5;
		protected NBADWDataEntryApplication.dstblAquaticSite objdstblAquaticSite;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticSiteAgencyUse;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand6;
		protected NBADWDataEntryApplication.dsSiteUse objdsSiteUse;
		protected System.Data.DataView dvtblAquaticSite;
		protected System.Data.DataView dvSiteUse;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand7;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_Watersheds;
		protected NBADWDataEntryApplication.dsWatersheds objdsWatersheds;
		protected System.Data.DataView dvWatersheds;
		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				//tblAquaticSite and tblAquaticSiteAgencyUse
				SetSiteIdentification();

				//tblAquaticActivity
				LoadtblAquaticActivity();
				DataRow ActivityRow = objdstblAquaticActivity.tblAquaticActivity.Rows.Find(Session["CurrentActivityID"].ToString());
				SetSurveyInfo(ActivityRow);



				//decide whether or not to show modify/delete/resume buttons
				if((bool)Session["Administrator"])
				{
					if(!(bool)ActivityRow["IncorporatedInd"])
					{
						lblHeading.Text = "VIEW Assessment Information";
						btnDelete.Visible = true;
						btnModifySiteIdentification.Visible = true;
						btnModifySurveyInfo.Visible = true;
						btnModifySiteObservations.Visible = true;
						btnModifySiteCharacteristics.Visible = true;
						btnModifyUpstreamVegetation.Visible = true;
						btnModifyFieldMeasurements.Visible = true;
						btnModifyPlanning.Visible = true;
					}
				}	



				//tblEnvironmentalObservations
				SetSiteObservations();	

				//tblEnvironmentalSurveyFieldMeasures
				LoadtblEnvironmentalSurveyFieldMeasures();
				int i = dvtblEnvironmentalSurveyFieldMeasures.Find(ActivityRow["AquaticActivityID"]);
				if(i >= 0)
				{
					SetSiteCharacteristics(i);	
					SetUpstreamVegetation(i);
					SetFieldMeasurements(i);
				}
				else
				{
					try
					{
						if((bool)Session["Administrator"])
						{
							if(!(bool)ActivityRow["IncorporatedInd"])
							{
								btnResume.Visible = true;
							}
						}
					}
					catch
					{
						//do nothing - if admin not set, we assume not an admin
					}
					btnModifySiteCharacteristics.Enabled = false;
					btnModifyUpstreamVegetation.Enabled = false;
					btnModifyFieldMeasurements.Enabled = false;
					btnModifyPlanning.Enabled = false;
				}

				//tblEnvironmentalPlanning
				SetPlanning();
			}
			else
			{
				//System.IO.StringReader sr1 = new System.IO.StringReader((string)(ViewState["dSet1"]));
				//System.IO.StringReader sr2 = new System.IO.StringReader((string)(ViewState["dSet2"]));
				
				//objdscdEnvironmentalObservations_Groups.ReadXml(sr1);
				//objdscdEnvironmentalObservations.ReadXml(sr2);
			}
		}


		#region SetValues
		public void SetSiteIdentification()
		{
			LoadtblAquaticSite();
			LoadtblAquaticSiteAgencyUse();
			LoadDE_Watersheds();

			int j = dvSiteUse.Find(Session["SelectedSiteUseID"]);
			string AquaticSiteID = dvSiteUse[j]["AquaticSiteID"].ToString();
			Session["SelectedSiteID"] = AquaticSiteID;//making sure 
			//both site and site use are set in case user wants to modify
			txtgroupsiteid.Text = dvSiteUse[j]["AgencySiteID"].ToString();

			int i = dvtblAquaticSite.Find(AquaticSiteID);
			j = dvWatersheds.Find(dvtblAquaticSite[i]["WaterBodyID"]);
			txtwaterbodyid.Text = dvWatersheds[j]["WaterBodyID"].ToString();
			txtwaterbodyname.Text = dvWatersheds[j]["WaterBodyName"].ToString();
			txtwatershed.Text = dvWatersheds[j]["DrainName"].ToString();
			txtwatershedcode.Text = dvWatersheds[j]["DrainageCd"].ToString();
            txtsitename.Text = dvtblAquaticSite[i]["AquaticSiteName"].ToString();
			txtsitedescription.Text = dvtblAquaticSite[i]["AquaticSiteDesc"].ToString();
			txtSource.Text = dvtblAquaticSite[i]["CoordinateSource"].ToString();
			txtSystem.Text = dvtblAquaticSite[i]["CoordinateSystem"].ToString();
			txtUnits.Text = dvtblAquaticSite[i]["CoordinateUnits"].ToString();
			txtX.Text = dvtblAquaticSite[i]["XCoordinate"].ToString();
			txtY.Text = dvtblAquaticSite[i]["YCoordinate"].ToString();

		}

		public void SetSurveyInfo(DataRow R)
		{
			txtdate.Text = R["AquaticActivityStartDate"].ToString();
			txtAgency.Text = R["AgencyCd"].ToString();
			txtpersonnel1.Text = R["Crew"].ToString();
		}

		public void SetSiteObservations()
		{
			LoadtblEnvironmentalObservations();
			dvtblEnvironmentalObservations.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
			dgSiteObservations.DataBind();
		}

		public void SetSiteCharacteristics(int i)
		{
			txtStreamCover.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["StreamCover"].ToString();
			txtStreamBank.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["BankStability"].ToString();
			txtStreamBankSlopeL.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["BankSlope_Lt"].ToString();
			txtStreamBankSlopeR.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["BankSlope_Rt"].ToString();
			txtStreamType.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["StreamType"].ToString();
			txtOther1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["StreamTypeSupp"].ToString();
			chkSuspendedSilt.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["SuspendedSilt"];
			chkEmbeddedSubstrate.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["EmbeddedSub"];
			chkAquaticPlantsAbundant.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["AquaticPlants"];
			chkAlgae.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["Algae"];
			chkPetroleum.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["Petroleum"];
			chkOdor.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["Odor"];
			chkFoam.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["Foam"];
			chkDeadFish.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["DeadFish"];
			chkOther.Checked = (bool)dvtblEnvironmentalSurveyFieldMeasures[i]["Other"];
			if(chkOther.Checked)
			{
				txtOther2.Visible=true;
				txtOther2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["OtherSupp"].ToString();
			}
			txtWaterClarity.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["WaterClarity"].ToString();
			txtWaterColour.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["WaterColor"].ToString();
			txtWeatherinPast48hours.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["Weather_Past"].ToString();
			txtWeatherCurrently.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["Weather_Current"].ToString();
		}

		public void SetUpstreamVegetation(int i)
		{			 
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

		public void SetFieldMeasurements(int i)
		{
			//Stream Measurements
			txtSectionLength.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["Length_m"].ToString();
			txtAverageWetStreamWidth.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["AveWidth_m"].ToString();
			txtAverageStreamDepth.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["AveDepth_m"].ToString();
			txtStreamVelocity.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["Velocity_mpers"].ToString();

			//Water Measurements
			txtTod_ST.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["ST_TimeofDay"].ToString();
			txtDo_ST.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["ST_DissOxygen"].ToString();
			txtAt_ST.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["ST_AirTemp_C"].ToString();
            txtWt_ST.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["ST_WaterTemp_C"].ToString();
			txtpH_ST.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["ST_pH"].ToString();
			txtCond_ST.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["ST_Conductivity"].ToString();
			txtFlow_ST.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["ST_Flow_cms"].ToString();
			txtField_ST.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["ST_DELGFieldNo"].ToString();

			txtTod_GW1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW1_TimeofDay"].ToString();
			txtDo_GW1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW1_DissOxygen"].ToString();
			txtAt_GW1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW1_AirTemp_C"].ToString();
			txtWt_GW1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW1_WaterTemp_C"].ToString();
			txtpH_GW1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW1_pH"].ToString();
			txtCond_GW1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW1_Conductivity"].ToString();
			txtFlow_GW1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW1_Flow_cms"].ToString();
			txtField_GW1.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW1_DELGFieldNo"].ToString();

			txtTod_GW2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW2_TimeofDay"].ToString();
			txtDo_GW2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW2_DissOxygen"].ToString();
			txtAt_GW2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW2_AirTemp_C"].ToString();
			txtWt_GW2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW2_WaterTemp_C"].ToString();
			txtpH_GW2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW2_pH"].ToString();
			txtCond_GW2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW2_Conductivity"].ToString();
			txtFlow_GW2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW2_Flow_cms"].ToString();
			txtField_GW2.Text = dvtblEnvironmentalSurveyFieldMeasures[i]["GW2_DELGFieldNo"].ToString();
		}

		public void SetPlanning()
		{
			LoadtblEnvironmentalPlanning();
			dvtblEnvironmentalPlanning.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
			dgPlanning.DataBind();
		}
		#endregion

		#region Fill & Load
		public void FilltblAquaticActivity(NBADWDataEntryApplication.dstblAquaticActivity dataSet)
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
                string select = this.oleDbdatblAquaticActivity.SelectCommand.CommandText;
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

		public void LoadtblAquaticActivity()
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
				this.FilltblAquaticActivity(objDataSetTemp);
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

		public void FilltblEnvironmentalObservations(NBADWDataEntryApplication.dstblEnvironmentalObservations dataSet)
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
				this.oleDbdatblEnvironmentalObservations.Fill(dataSet);
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

		public void LoadtblEnvironmentalObservations()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dstblEnvironmentalObservations objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dstblEnvironmentalObservations();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblEnvironmentalObservations(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblEnvironmentalObservations.Clear();
				// Merge the records into the main dataset.
				objdstblEnvironmentalObservations.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}
/*
		public void FillcdAgency(NBADWDataEntryApplication.dscdAgency dataSet)
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

		public void LoadcdAgency()
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
				this.FillcdAgency(objDataSetTemp);
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
		
		public void FillSiteObservation_dlsts(NBADWDataEntryApplication.dscdEnvironmentalObservations_Groups dataSet1, NBADWDataEntryApplication.dscdEnvironmentalObservations dataSet2)
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
				this.oleDbdacdEnvironmentalObservations_Groups.Fill(dataSet1);
				this.oleDbdacdEnvironmentalObservations.Fill(dataSet2);
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

				System.IO.StringWriter sw1 = new System.IO.StringWriter();
				System.IO.StringWriter sw2 = new System.IO.StringWriter();
				
				// Write the DataSet to the ViewState property.
				dataSet1.WriteXml(sw1);
				dataSet2.WriteXml(sw2);
				ViewState["dSet1"] = sw1.ToString();
				ViewState["dSet2"] = sw2.ToString();
			}

		}


		public void LoadSiteObservation_dlsts()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdEnvironmentalObservations_Groups objDataSetTemp1;
			NBADWDataEntryApplication.dscdEnvironmentalObservations objDataSetTemp2;
			
			objDataSetTemp1 = new NBADWDataEntryApplication.dscdEnvironmentalObservations_Groups();
			objDataSetTemp2 = new NBADWDataEntryApplication.dscdEnvironmentalObservations();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillSiteObservation_dlsts(objDataSetTemp1, objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdscdEnvironmentalObservations_Groups.Clear();
				objdscdEnvironmentalObservations.Clear();
				// Merge the records into the main dataset.
				objdscdEnvironmentalObservations_Groups.Merge(objDataSetTemp1);
				objdscdEnvironmentalObservations.Merge(objDataSetTemp2);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}
		*/

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

		public void FilltblEnvironmentalPlanning(NBADWDataEntryApplication.dstblEnvPlanning dataSet)
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
				this.oleDbdatblEnvironmentalPlanning.Fill(dataSet);
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

		public void LoadtblEnvironmentalPlanning()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dstblEnvPlanning objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dstblEnvPlanning();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblEnvironmentalPlanning(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblEnvPlanning.Clear();
				// Merge the records into the main dataset.
				objdstblEnvPlanning.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		public void FilltblAquaticSiteAgencyUse(NBADWDataEntryApplication.dsSiteUse dataSet)
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
				this.oleDbdatblAquaticSiteAgencyUse.Fill(dataSet);
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

		public void LoadtblAquaticSiteAgencyUse()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dsSiteUse objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dsSiteUse();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblAquaticSiteAgencyUse(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsSiteUse.Clear();
				// Merge the records into the main dataset.
				objdsSiteUse.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		public void FilltblAquaticSite(NBADWDataEntryApplication.dstblAquaticSite dataSet)
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
				this.oleDbdatblAquaticSite.Fill(dataSet);
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

		public void LoadtblAquaticSite()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dstblAquaticSite objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dstblAquaticSite();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblAquaticSite(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblAquaticSite.Clear();
				// Merge the records into the main dataset.
				objdstblAquaticSite.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		public void FillDE_Watersheds(NBADWDataEntryApplication.dsWatersheds dataSet)
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
				this.oleDbdaDE_Watersheds.Fill(dataSet);
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

		public void LoadDE_Watersheds()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			//NBADWDataEntryApplication.dsTemperatureSites objDataSetTemp;
			//objDataSetTemp = new NBADWDataEntryApplication.dsTemperatureSites();
			NBADWDataEntryApplication.dsWatersheds objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dsWatersheds();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDE_Watersheds(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsWatersheds.Clear();
				// Merge the records into the main dataset.
				objdsWatersheds.Merge(objDataSetTemp);
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
			this.oleDbdatblEnvironmentalObservations = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.objdstblEnvironmentalObservations = new NBADWDataEntryApplication.dstblEnvironmentalObservations();
			this.dvtblEnvironmentalObservations = new System.Data.DataView();
			this.oleDbdatblEnvironmentalSurveyFieldMeasures = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdstblEnvironmentalSurveyFieldMeasures = new NBADWDataEntryApplication.dstblEnvironmentalSurveyFieldMeasures();
			this.dvtblEnvironmentalSurveyFieldMeasures = new System.Data.DataView();
			this.oleDbdatblEnvironmentalPlanning = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.objdstblEnvPlanning = new NBADWDataEntryApplication.dstblEnvPlanning();
			this.dvtblEnvironmentalPlanning = new System.Data.DataView();
			this.oleDbdatblAquaticSite = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
			this.objdstblAquaticSite = new NBADWDataEntryApplication.dstblAquaticSite();
			this.oleDbdatblAquaticSiteAgencyUse = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand6 = new System.Data.OleDb.OleDbCommand();
			this.objdsSiteUse = new NBADWDataEntryApplication.dsSiteUse();
			this.dvtblAquaticSite = new System.Data.DataView();
			this.dvSiteUse = new System.Data.DataView();
			this.oleDbdaDE_Watersheds = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			this.objdsWatersheds = new NBADWDataEntryApplication.dsWatersheds();
			this.dvWatersheds = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvironmentalObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvironmentalSurveyFieldMeasures)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalSurveyFieldMeasures)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvPlanning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalPlanning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticSite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsSiteUse)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblAquaticSite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvSiteUse)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsWatersheds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvWatersheds)).BeginInit();
			// 
			// oleDbdatblAquaticActivity
			// 
			this.oleDbdatblAquaticActivity.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbdatblAquaticActivity.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbdatblAquaticActivity.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbdatblAquaticActivity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "tblAquaticActivity", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																									  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
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
																																																									  new System.Data.Common.DataColumnMapping("project", "project"),
																																																									  new System.Data.Common.DataColumnMapping("Siltation", "Siltation"),
																																																									  new System.Data.Common.DataColumnMapping("WaterLevel", "WaterLevel"),
																																																									  new System.Data.Common.DataColumnMapping("WaterLevel_AM_cm", "WaterLevel_AM_cm"),
																																																									  new System.Data.Common.DataColumnMapping("WaterLevel_cm", "WaterLevel_cm"),
																																																									  new System.Data.Common.DataColumnMapping("WaterLevel_PM_cm", "WaterLevel_PM_cm"),
																																																									  new System.Data.Common.DataColumnMapping("WeatherConditions", "WeatherConditions"),
																																																									  new System.Data.Common.DataColumnMapping("Year", "Year")})});
			this.oleDbdatblAquaticActivity.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblAquaticActivity WHERE (AquaticActivityID = ?) AND (Agency2Cd = ? O" +
				"R ? IS NULL AND Agency2Cd IS NULL) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd I" +
				"S NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) A" +
				"ND (AquaticActivityEndDate = ? OR ? IS NULL AND AquaticActivityEndDate IS NULL) " +
				"AND (AquaticActivityEndTime = ? OR ? IS NULL AND AquaticActivityEndTime IS NULL)" +
				" AND (AquaticActivityLeader = ? OR ? IS NULL AND AquaticActivityLeader IS NULL) " +
				"AND (AquaticActivityStartDate = ? OR ? IS NULL AND AquaticActivityStartDate IS N" +
				"ULL) AND (AquaticActivityStartTime = ? OR ? IS NULL AND AquaticActivityStartTime" +
				" IS NULL) AND (AquaticMethodCd = ? OR ? IS NULL AND AquaticMethodCd IS NULL) AND" +
				" (AquaticProgramID = ? OR ? IS NULL AND AquaticProgramID IS NULL) AND (AquaticSi" +
				"teID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (Comments = ? OR ? IS NULL " +
				"AND Comments IS NULL) AND (Crew = ? OR ? IS NULL AND Crew IS NULL) AND (DateEnte" +
				"red = ?) AND (IncorporatedInd = ?) AND (OldAquaticActivityID = ? OR ? IS NULL AN" +
				"D OldAquaticActivityID IS NULL) AND (PrimaryActivityInd = ?) AND (Siltation = ? " +
				"OR ? IS NULL AND Siltation IS NULL) AND (WaterLevel = ? OR ? IS NULL AND WaterLe" +
				"vel IS NULL) AND (WaterLevel_AM_cm = ? OR ? IS NULL AND WaterLevel_AM_cm IS NULL" +
				") AND (WaterLevel_PM_cm = ? OR ? IS NULL AND WaterLevel_PM_cm IS NULL) AND (Wate" +
				"rLevel_cm = ? OR ? IS NULL AND WaterLevel_cm IS NULL) AND (WeatherConditions = ?" +
				" OR ? IS NULL AND WeatherConditions IS NULL) AND (Year = ? OR ? IS NULL AND Year" +
				" IS NULL) AND (oldAquaticSiteID = ? OR ? IS NULL AND oldAquaticSiteID IS NULL) A" +
				"ND (project = ? OR ? IS NULL AND project IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryActivityInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_project", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "project", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_project1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "project", System.Data.DataRowVersion.Original, null));
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
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO tblAquaticActivity(Agency2Cd, AgencyCd, AquaticActivityCd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityID, AquaticActivityLeader, AquaticActivityStartDate, AquaticActivityStartTime, AquaticMethodCd, AquaticProgramID, AquaticSiteID, Comments, Crew, DateEntered, IncorporatedInd, OldAquaticActivityID, oldAquaticSiteID, PrimaryActivityInd, project, Siltation, WaterLevel, WaterLevel_AM_cm, WaterLevel_cm, WaterLevel_PM_cm, WeatherConditions, Year) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityEndDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityEndTime"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivityLeader"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticProgramID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "OldAquaticActivityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, "PrimaryActivityInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("project", System.Data.OleDb.OleDbType.VarWChar, 50, "project"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, "Siltation"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, "WaterLevel"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_AM_cm"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_cm"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_PM_cm"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, "WeatherConditions"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Year", System.Data.OleDb.OleDbType.VarWChar, 4, "Year"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT Agency2Cd, AgencyCd, AquaticActivityCd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityID, AquaticActivityLeader, AquaticActivityStartDate, AquaticActivityStartTime, AquaticMethodCd, AquaticProgramID, AquaticSiteID, Comments, Crew, DateEntered, IncorporatedInd, OldAquaticActivityID, oldAquaticSiteID, PrimaryActivityInd, project, Siltation, WaterLevel, WaterLevel_AM_cm, WaterLevel_cm, WaterLevel_PM_cm, WeatherConditions, Year FROM tblAquaticActivity";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblAquaticActivity SET Agency2Cd = ?, AgencyCd = ?, AquaticActivityCd = ?," +
				" AquaticActivityEndDate = ?, AquaticActivityEndTime = ?, AquaticActivityID = ?, " +
				"AquaticActivityLeader = ?, AquaticActivityStartDate = ?, AquaticActivityStartTim" +
				"e = ?, AquaticMethodCd = ?, AquaticProgramID = ?, AquaticSiteID = ?, Comments = " +
				"?, Crew = ?, DateEntered = ?, IncorporatedInd = ?, OldAquaticActivityID = ?, old" +
				"AquaticSiteID = ?, PrimaryActivityInd = ?, project = ?, Siltation = ?, WaterLeve" +
				"l = ?, WaterLevel_AM_cm = ?, WaterLevel_cm = ?, WaterLevel_PM_cm = ?, WeatherCon" +
				"ditions = ?, Year = ? WHERE (AquaticActivityID = ?) AND (Agency2Cd = ? OR ? IS N" +
				"ULL AND Agency2Cd IS NULL) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) " +
				"AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (Aqua" +
				"ticActivityEndDate = ? OR ? IS NULL AND AquaticActivityEndDate IS NULL) AND (Aqu" +
				"aticActivityEndTime = ? OR ? IS NULL AND AquaticActivityEndTime IS NULL) AND (Aq" +
				"uaticActivityLeader = ? OR ? IS NULL AND AquaticActivityLeader IS NULL) AND (Aqu" +
				"aticActivityStartDate = ? OR ? IS NULL AND AquaticActivityStartDate IS NULL) AND" +
				" (AquaticActivityStartTime = ? OR ? IS NULL AND AquaticActivityStartTime IS NULL" +
				") AND (AquaticMethodCd = ? OR ? IS NULL AND AquaticMethodCd IS NULL) AND (Aquati" +
				"cProgramID = ? OR ? IS NULL AND AquaticProgramID IS NULL) AND (AquaticSiteID = ?" +
				" OR ? IS NULL AND AquaticSiteID IS NULL) AND (Comments = ? OR ? IS NULL AND Comm" +
				"ents IS NULL) AND (Crew = ? OR ? IS NULL AND Crew IS NULL) AND (DateEntered = ?)" +
				" AND (IncorporatedInd = ?) AND (OldAquaticActivityID = ? OR ? IS NULL AND OldAqu" +
				"aticActivityID IS NULL) AND (PrimaryActivityInd = ?) AND (Siltation = ? OR ? IS " +
				"NULL AND Siltation IS NULL) AND (WaterLevel = ? OR ? IS NULL AND WaterLevel IS N" +
				"ULL) AND (WaterLevel_AM_cm = ? OR ? IS NULL AND WaterLevel_AM_cm IS NULL) AND (W" +
				"aterLevel_PM_cm = ? OR ? IS NULL AND WaterLevel_PM_cm IS NULL) AND (WaterLevel_c" +
				"m = ? OR ? IS NULL AND WaterLevel_cm IS NULL) AND (WeatherConditions = ? OR ? IS" +
				" NULL AND WeatherConditions IS NULL) AND (Year = ? OR ? IS NULL AND Year IS NULL" +
				") AND (oldAquaticSiteID = ? OR ? IS NULL AND oldAquaticSiteID IS NULL) AND (proj" +
				"ect = ? OR ? IS NULL AND project IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityEndDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityEndTime"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivityLeader"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticProgramID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "OldAquaticActivityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, "PrimaryActivityInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("project", System.Data.OleDb.OleDbType.VarWChar, 50, "project"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, "Siltation"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, "WaterLevel"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_AM_cm"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_cm"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_PM_cm"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, "WeatherConditions"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Year", System.Data.OleDb.OleDbType.VarWChar, 4, "Year"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryActivityInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_project", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "project", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_project1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "project", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblAquaticActivity
			// 
			this.objdstblAquaticActivity.DataSetName = "dstblAquaticActivity";
			this.objdstblAquaticActivity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdatblEnvironmentalObservations
			// 
			this.oleDbdatblEnvironmentalObservations.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbdatblEnvironmentalObservations.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdatblEnvironmentalObservations.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdatblEnvironmentalObservations.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "tblEnvironmentalObservations", new System.Data.Common.DataColumnMapping[] {
																																																														  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																														  new System.Data.Common.DataColumnMapping("EnvObservationID", "EnvObservationID"),
																																																														  new System.Data.Common.DataColumnMapping("FishPassageObstructionInd", "FishPassageObstructionInd"),
																																																														  new System.Data.Common.DataColumnMapping("Observation", "Observation"),
																																																														  new System.Data.Common.DataColumnMapping("ObservationGroup", "ObservationGroup"),
																																																														  new System.Data.Common.DataColumnMapping("ObservationSupp", "ObservationSupp"),
																																																														  new System.Data.Common.DataColumnMapping("PipeSize_cm", "PipeSize_cm")})});
			this.oleDbdatblEnvironmentalObservations.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM tblEnvironmentalObservations WHERE (EnvObservationID = ?) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FishPassageObstructionInd = ?) AND (Observation = ? OR ? IS NULL AND Observation IS NULL) AND (ObservationGroup = ? OR ? IS NULL AND ObservationGroup IS NULL) AND (ObservationSupp = ? OR ? IS NULL AND ObservationSupp IS NULL) AND (PipeSize_cm = ? OR ? IS NULL AND PipeSize_cm IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvObservationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvObservationID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishPassageObstructionInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationSupp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationSupp1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PipeSize_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PipeSize_cm1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PipeSize_cm", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tblEnvironmentalObservations(AquaticActivityID, FishPassageObstructio" +
				"nInd, Observation, ObservationGroup, ObservationSupp, PipeSize_cm) VALUES (?, ?," +
				" ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishPassageObstructionInd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Observation", System.Data.OleDb.OleDbType.VarWChar, 50, "Observation"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationGroup"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationSupp"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, "PipeSize_cm"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT AquaticActivityID, EnvObservationID, FishPassageObstructionInd, Observatio" +
				"n, ObservationGroup, ObservationSupp, PipeSize_cm FROM tblEnvironmentalObservati" +
				"ons";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE tblEnvironmentalObservations SET AquaticActivityID = ?, FishPassageObstructionInd = ?, Observation = ?, ObservationGroup = ?, ObservationSupp = ?, PipeSize_cm = ? WHERE (EnvObservationID = ?) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FishPassageObstructionInd = ?) AND (Observation = ? OR ? IS NULL AND Observation IS NULL) AND (ObservationGroup = ? OR ? IS NULL AND ObservationGroup IS NULL) AND (ObservationSupp = ? OR ? IS NULL AND ObservationSupp IS NULL) AND (PipeSize_cm = ? OR ? IS NULL AND PipeSize_cm IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishPassageObstructionInd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Observation", System.Data.OleDb.OleDbType.VarWChar, 50, "Observation"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationGroup"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationSupp"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, "PipeSize_cm"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvObservationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvObservationID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishPassageObstructionInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationSupp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationSupp1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PipeSize_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PipeSize_cm1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PipeSize_cm", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblEnvironmentalObservations
			// 
			this.objdstblEnvironmentalObservations.DataSetName = "dstblEnvironmentalObservations";
			this.objdstblEnvironmentalObservations.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblEnvironmentalObservations
			// 
			this.dvtblEnvironmentalObservations.Table = this.objdstblEnvironmentalObservations.tblEnvironmentalObservations;
			// 
			// oleDbdatblEnvironmentalSurveyFieldMeasures
			// 
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.SelectCommand = this.oleDbSelectCommand3;
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
			this.oleDbdatblEnvironmentalSurveyFieldMeasures.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM tblEnvironmentalSurveyFieldMeasures WHERE (FieldMeasureID = ?) AND (A" +
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
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FieldMeasureID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FieldMeasureID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Algae", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Algae", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticPlants", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveDepth_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWidth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWidth_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWidth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankStability", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankStability", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankStability1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankStability", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DeadFish", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EmbeddedSub", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Foam", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foam", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Odor", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Odor", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Other", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Other", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherSupp1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Petroleum", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Rt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamCover", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamCover1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamCover", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamType1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamTypeSupp", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamTypeSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamTypeSupp1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamTypeSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SuspendedSilt", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Velocity_mpers", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Velocity_mpers1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Velocity_mpers", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterClarity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterClarity1", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterClarity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterColor", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterColor1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterColor", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Current", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Current1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Current", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Past", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Past1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Past", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = @"INSERT INTO tblEnvironmentalSurveyFieldMeasures(Algae, AquaticActivityID, AquaticPlants, AveDepth_m, AveWidth_m, BankSlope_Lt, BankSlope_Rt, BankStability, DeadFish, EmbeddedSub, Foam, GW1_AirTemp_C, GW1_Conductivity, GW1_DELGFieldNo, GW1_DissOxygen, GW1_Flow_cms, GW1_pH, GW1_TimeofDay, GW1_WaterTemp_C, GW2_AirTemp_C, GW2_Conductivity, GW2_DELGFieldNo, GW2_DissOxygen, GW2_Flow_cms, GW2_pH, GW2_TimeofDay, GW2_WaterTemp_C, Length_m, Odor, Other, OtherSupp, Petroleum, RZ_Altered_Lt, RZ_Altered_Rt, RZ_ForageCrop_Lt, RZ_ForageCrop_Rt, RZ_Hardwood_Lt, RZ_Hardwood_Rt, RZ_Lawn_Lt, RZ_Lawn_Rt, RZ_Meadow_Lt, RZ_Meadow_Rt, RZ_Mixed_Lt, RZ_Mixed_Rt, RZ_RowCrop_Lt, RZ_RowCrop_Rt, RZ_Shrubs_Lt, RZ_Shrubs_Rt, RZ_Softwood_Lt, RZ_Softwood_Rt, RZ_Wetland_Lt, RZ_Wetland_Rt, ST_AirTemp_C, ST_Conductivity, ST_DELGFieldNo, ST_DissOxygen, ST_Flow_cms, ST_pH, ST_TimeofDay, ST_WaterTemp_C, StreamCover, StreamType, StreamTypeSupp, SuspendedSilt, Velocity_mpers, WaterClarity, WaterColor, Weather_Current, Weather_Past) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Algae", System.Data.OleDb.OleDbType.Boolean, 2, "Algae"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, "AquaticPlants"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, "AveDepth_m"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, "AveWidth_m"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankStability", System.Data.OleDb.OleDbType.VarWChar, 10, "BankStability"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, "DeadFish"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, "EmbeddedSub"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Foam", System.Data.OleDb.OleDbType.Boolean, 2, "Foam"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_AirTemp_C"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW1_Conductivity"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW1_DELGFieldNo"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW1_DissOxygen"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW1_Flow_cms"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_pH", System.Data.OleDb.OleDbType.Single, 0, "GW1_pH"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW1_TimeofDay"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_WaterTemp_C"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_AirTemp_C"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW2_Conductivity"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW2_DELGFieldNo"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW2_DissOxygen"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW2_Flow_cms"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_pH", System.Data.OleDb.OleDbType.Single, 0, "GW2_pH"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW2_TimeofDay"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_WaterTemp_C"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Length_m", System.Data.OleDb.OleDbType.Single, 0, "Length_m"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Odor", System.Data.OleDb.OleDbType.Boolean, 2, "Odor"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Other", System.Data.OleDb.OleDbType.Boolean, 2, "Other"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherSupp"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, "Petroleum"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Lawn_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, "RZ_Lawn_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Lt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Rt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_AirTemp_C"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "ST_Conductivity"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "ST_DELGFieldNo"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "ST_DissOxygen"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "ST_Flow_cms"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_pH", System.Data.OleDb.OleDbType.Single, 0, "ST_pH"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "ST_TimeofDay"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_WaterTemp_C"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamCover"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamType"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamTypeSupp", System.Data.OleDb.OleDbType.VarWChar, 30, "StreamTypeSupp"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, "SuspendedSilt"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, "Velocity_mpers"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, "WaterClarity"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterColor"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Current"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Past"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT Algae, AquaticActivityID, AquaticPlants, AveDepth_m, AveWidth_m, BankSlope_Lt, BankSlope_Rt, BankStability, DeadFish, EmbeddedSub, FieldMeasureID, Foam, GW1_AirTemp_C, GW1_Conductivity, GW1_DELGFieldNo, GW1_DissOxygen, GW1_Flow_cms, GW1_pH, GW1_TimeofDay, GW1_WaterTemp_C, GW2_AirTemp_C, GW2_Conductivity, GW2_DELGFieldNo, GW2_DissOxygen, GW2_Flow_cms, GW2_pH, GW2_TimeofDay, GW2_WaterTemp_C, Length_m, Odor, Other, OtherSupp, Petroleum, RZ_Altered_Lt, RZ_Altered_Rt, RZ_ForageCrop_Lt, RZ_ForageCrop_Rt, RZ_Hardwood_Lt, RZ_Hardwood_Rt, RZ_Lawn_Lt, RZ_Lawn_Rt, RZ_Meadow_Lt, RZ_Meadow_Rt, RZ_Mixed_Lt, RZ_Mixed_Rt, RZ_RowCrop_Lt, RZ_RowCrop_Rt, RZ_Shrubs_Lt, RZ_Shrubs_Rt, RZ_Softwood_Lt, RZ_Softwood_Rt, RZ_Wetland_Lt, RZ_Wetland_Rt, ST_AirTemp_C, ST_Conductivity, ST_DELGFieldNo, ST_DissOxygen, ST_Flow_cms, ST_pH, ST_TimeofDay, ST_WaterTemp_C, StreamCover, StreamType, StreamTypeSupp, SuspendedSilt, Velocity_mpers, WaterClarity, WaterColor, Weather_Current, Weather_Past FROM tblEnvironmentalSurveyFieldMeasures";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE tblEnvironmentalSurveyFieldMeasures SET Algae = ?, AquaticActivityID = ?, " +
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
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Algae", System.Data.OleDb.OleDbType.Boolean, 2, "Algae"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, "AquaticPlants"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, "AveDepth_m"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, "AveWidth_m"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "BankSlope_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("BankStability", System.Data.OleDb.OleDbType.VarWChar, 10, "BankStability"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, "DeadFish"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, "EmbeddedSub"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Foam", System.Data.OleDb.OleDbType.Boolean, 2, "Foam"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_AirTemp_C"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW1_Conductivity"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW1_DELGFieldNo"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW1_DissOxygen"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW1_Flow_cms"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_pH", System.Data.OleDb.OleDbType.Single, 0, "GW1_pH"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW1_TimeofDay"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW1_WaterTemp_C"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_AirTemp_C"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "GW2_Conductivity"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "GW2_DELGFieldNo"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "GW2_DissOxygen"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "GW2_Flow_cms"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_pH", System.Data.OleDb.OleDbType.Single, 0, "GW2_pH"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "GW2_TimeofDay"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "GW2_WaterTemp_C"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Length_m", System.Data.OleDb.OleDbType.Single, 0, "Length_m"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Odor", System.Data.OleDb.OleDbType.Boolean, 2, "Odor"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Other", System.Data.OleDb.OleDbType.Boolean, 2, "Other"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherSupp"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, "Petroleum"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Altered_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_ForageCrop_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Hardwood_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Lawn_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, "RZ_Lawn_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Meadow_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Mixed_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_RowCrop_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Shrubs_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Softwood_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Lt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, "RZ_Wetland_Rt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_AirTemp_C"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, "ST_Conductivity"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, "ST_DELGFieldNo"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, "ST_DissOxygen"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, "ST_Flow_cms"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_pH", System.Data.OleDb.OleDbType.Single, 0, "ST_pH"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "ST_TimeofDay"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "ST_WaterTemp_C"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamCover"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, "StreamType"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StreamTypeSupp", System.Data.OleDb.OleDbType.VarWChar, 30, "StreamTypeSupp"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, "SuspendedSilt"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, "Velocity_mpers"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, "WaterClarity"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterColor"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Current"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, "Weather_Past"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FieldMeasureID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FieldMeasureID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Algae", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Algae", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticPlants", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticPlants", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveDepth_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveDepth_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWidth_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWidth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWidth_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWidth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankSlope_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankSlope_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankStability", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankStability", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BankStability1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankStability", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DeadFish", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DeadFish", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EmbeddedSub", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EmbeddedSub", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Foam", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foam", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW1_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW1_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GW2_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GW2_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length_m", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length_m1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Odor", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Odor", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Other", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Other", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherSupp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherSupp1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Petroleum", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Petroleum", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Altered_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Altered_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_ForageCrop_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_ForageCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Hardwood_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Hardwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Rt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Lawn_Rt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Lawn_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Meadow_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Meadow_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Mixed_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Mixed_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_RowCrop_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_RowCrop_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Shrubs_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Shrubs_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Softwood_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Softwood_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Lt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Lt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Lt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Rt", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RZ_Wetland_Rt1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RZ_Wetland_Rt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Conductivity", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Conductivity1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Conductivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DELGFieldNo", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DELGFieldNo1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DELGFieldNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DissOxygen", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_DissOxygen1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_DissOxygen", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Flow_cms", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_Flow_cms1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_Flow_cms", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_pH", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ST_pH1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ST_pH", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamCover", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamCover", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamCover1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamCover", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamType", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamType1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamTypeSupp", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamTypeSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StreamTypeSupp1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StreamTypeSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SuspendedSilt", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SuspendedSilt", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Velocity_mpers", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Velocity_mpers", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Velocity_mpers1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Velocity_mpers", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterClarity", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterClarity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterClarity1", System.Data.OleDb.OleDbType.VarWChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterClarity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterColor", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterColor", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterColor1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterColor", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Current", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Current", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Current1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Current", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Past", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Past", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weather_Past1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Weather_Past", System.Data.DataRowVersion.Original, null));
			// 
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
			// oleDbdatblEnvironmentalPlanning
			// 
			this.oleDbdatblEnvironmentalPlanning.DeleteCommand = this.oleDbDeleteCommand4;
			this.oleDbdatblEnvironmentalPlanning.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdatblEnvironmentalPlanning.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdatblEnvironmentalPlanning.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "tblEnvironmentalPlanning", new System.Data.Common.DataColumnMapping[] {
																																																												  new System.Data.Common.DataColumnMapping("ActionCompletionDate", "ActionCompletionDate"),
																																																												  new System.Data.Common.DataColumnMapping("ActionPriority", "ActionPriority"),
																																																												  new System.Data.Common.DataColumnMapping("ActionRequired", "ActionRequired"),
																																																												  new System.Data.Common.DataColumnMapping("ActionTargetDate", "ActionTargetDate"),
																																																												  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																												  new System.Data.Common.DataColumnMapping("EnvPlanningID", "EnvPlanningID"),
																																																												  new System.Data.Common.DataColumnMapping("FollowUpCompletionDate", "FollowUpCompletionDate"),
																																																												  new System.Data.Common.DataColumnMapping("FollowUpRequired", "FollowUpRequired"),
																																																												  new System.Data.Common.DataColumnMapping("FollowUpTargetDate", "FollowUpTargetDate"),
																																																												  new System.Data.Common.DataColumnMapping("Issue", "Issue"),
																																																												  new System.Data.Common.DataColumnMapping("IssueCategory", "IssueCategory")})});
			this.oleDbdatblEnvironmentalPlanning.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = @"DELETE FROM tblEnvironmentalPlanning WHERE (EnvPlanningID = ?) AND (ActionCompletionDate = ? OR ? IS NULL AND ActionCompletionDate IS NULL) AND (ActionPriority = ? OR ? IS NULL AND ActionPriority IS NULL) AND (ActionRequired = ? OR ? IS NULL AND ActionRequired IS NULL) AND (ActionTargetDate = ? OR ? IS NULL AND ActionTargetDate IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FollowUpCompletionDate = ? OR ? IS NULL AND FollowUpCompletionDate IS NULL) AND (FollowUpRequired = ?) AND (FollowUpTargetDate = ? OR ? IS NULL AND FollowUpTargetDate IS NULL) AND (Issue = ? OR ? IS NULL AND Issue IS NULL) AND (IssueCategory = ? OR ? IS NULL AND IssueCategory IS NULL)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvPlanningID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvPlanningID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO tblEnvironmentalPlanning(ActionCompletionDate, ActionPriority, Action" +
				"Required, ActionTargetDate, AquaticActivityID, FollowUpCompletionDate, FollowUpR" +
				"equired, FollowUpTargetDate, Issue, IssueCategory) VALUES (?, ?, ?, ?, ?, ?, ?, " +
				"?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionCompletionDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, "ActionPriority"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, "ActionRequired"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionTargetDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpCompletionDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, "FollowUpRequired"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpTargetDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Issue", System.Data.OleDb.OleDbType.VarWChar, 250, "Issue"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, "IssueCategory"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT ActionCompletionDate, ActionPriority, ActionRequired, ActionTargetDate, Aq" +
				"uaticActivityID, EnvPlanningID, FollowUpCompletionDate, FollowUpRequired, Follow" +
				"UpTargetDate, Issue, IssueCategory FROM tblEnvironmentalPlanning";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = @"UPDATE tblEnvironmentalPlanning SET ActionCompletionDate = ?, ActionPriority = ?, ActionRequired = ?, ActionTargetDate = ?, AquaticActivityID = ?, FollowUpCompletionDate = ?, FollowUpRequired = ?, FollowUpTargetDate = ?, Issue = ?, IssueCategory = ? WHERE (EnvPlanningID = ?) AND (ActionCompletionDate = ? OR ? IS NULL AND ActionCompletionDate IS NULL) AND (ActionPriority = ? OR ? IS NULL AND ActionPriority IS NULL) AND (ActionRequired = ? OR ? IS NULL AND ActionRequired IS NULL) AND (ActionTargetDate = ? OR ? IS NULL AND ActionTargetDate IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FollowUpCompletionDate = ? OR ? IS NULL AND FollowUpCompletionDate IS NULL) AND (FollowUpRequired = ?) AND (FollowUpTargetDate = ? OR ? IS NULL AND FollowUpTargetDate IS NULL) AND (Issue = ? OR ? IS NULL AND Issue IS NULL) AND (IssueCategory = ? OR ? IS NULL AND IssueCategory IS NULL)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionCompletionDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, "ActionPriority"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, "ActionRequired"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionTargetDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpCompletionDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, "FollowUpRequired"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpTargetDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Issue", System.Data.OleDb.OleDbType.VarWChar, 250, "Issue"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, "IssueCategory"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvPlanningID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvPlanningID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblEnvPlanning
			// 
			this.objdstblEnvPlanning.DataSetName = "dstblEnvPlanning";
			this.objdstblEnvPlanning.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblEnvironmentalPlanning
			// 
			this.dvtblEnvironmentalPlanning.Table = this.objdstblEnvPlanning.tblEnvironmentalPlanning;
			// 
			// oleDbdatblAquaticSite
			// 
			this.oleDbdatblAquaticSite.DeleteCommand = this.oleDbDeleteCommand5;
			this.oleDbdatblAquaticSite.InsertCommand = this.oleDbInsertCommand5;
			this.oleDbdatblAquaticSite.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbdatblAquaticSite.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			this.oleDbdatblAquaticSite.UpdateCommand = this.oleDbUpdateCommand5;
			// 
			// oleDbDeleteCommand5
			// 
			this.oleDbDeleteCommand5.CommandText = @"DELETE FROM tblAquaticSite WHERE (AquaticSiteID = ?) AND (AquaticSiteDesc = ? OR ? IS NULL AND AquaticSiteDesc IS NULL) AND (AquaticSiteName = ? OR ? IS NULL AND AquaticSiteName IS NULL) AND (CoordinateSource = ? OR ? IS NULL AND CoordinateSource IS NULL) AND (CoordinateSystem = ? OR ? IS NULL AND CoordinateSystem IS NULL) AND (CoordinateUnits = ? OR ? IS NULL AND CoordinateUnits IS NULL) AND (DateEntered = ? OR ? IS NULL AND DateEntered IS NULL) AND (EndDesc = ? OR ? IS NULL AND EndDesc IS NULL) AND (EndRouteMeas = ? OR ? IS NULL AND EndRouteMeas IS NULL) AND (GeoReferencedInd = ? OR ? IS NULL AND GeoReferencedInd IS NULL) AND (HabitatDesc = ? OR ? IS NULL AND HabitatDesc IS NULL) AND (IncorporatedInd = ?) AND (ReachNo = ? OR ? IS NULL AND ReachNo IS NULL) AND (RiverSystemID = ? OR ? IS NULL AND RiverSystemID IS NULL) AND (SpecificSiteInd = ? OR ? IS NULL AND SpecificSiteInd IS NULL) AND (StartDesc = ? OR ? IS NULL AND StartDesc IS NULL) AND (StartRouteMeas = ? OR ? IS NULL AND StartRouteMeas IS NULL) AND (WaterBodyID = ? OR ? IS NULL AND WaterBodyID IS NULL) AND (WaterBodyName = ? OR ? IS NULL AND WaterBodyName IS NULL) AND (XCoordinate = ? OR ? IS NULL AND XCoordinate IS NULL) AND (YCoordinate = ? OR ? IS NULL AND YCoordinate IS NULL) AND (oldAquaticSiteID = ? OR ? IS NULL AND oldAquaticSiteID IS NULL)";
			this.oleDbDeleteCommand5.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc1", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
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
			// oleDbUpdateCommand5
			// 
			this.oleDbUpdateCommand5.CommandText = "UPDATE tblAquaticSite SET AquaticSiteDesc = ?, AquaticSiteID = ?, AquaticSiteName" +
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
			this.oleDbUpdateCommand5.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "EndDesc"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "EndRouteMeas"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, "GeoReferencedInd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReachNo", System.Data.OleDb.OleDbType.Integer, 0, "ReachNo"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, "RiverSystemID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, "SpecificSiteInd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "StartDesc"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "StartRouteMeas"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc1", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblAquaticSite
			// 
			this.objdstblAquaticSite.DataSetName = "dstblAquaticSite";
			this.objdstblAquaticSite.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdatblAquaticSiteAgencyUse
			// 
			this.oleDbdatblAquaticSiteAgencyUse.DeleteCommand = this.oleDbDeleteCommand6;
			this.oleDbdatblAquaticSiteAgencyUse.InsertCommand = this.oleDbInsertCommand6;
			this.oleDbdatblAquaticSiteAgencyUse.SelectCommand = this.oleDbSelectCommand6;
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
			this.oleDbdatblAquaticSiteAgencyUse.UpdateCommand = this.oleDbUpdateCommand6;
			// 
			// oleDbDeleteCommand6
			// 
			this.oleDbDeleteCommand6.CommandText = @"DELETE FROM tblAquaticSiteAgencyUse WHERE (AquaticSiteUseID = ?) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AgencySiteID = ? OR ? IS NULL AND AgencySiteID IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (AquaticSiteType = ? OR ? IS NULL AND AquaticSiteType IS NULL) AND (EndYear = ? OR ? IS NULL AND EndYear IS NULL) AND (IncorporatedInd = ?) AND (StartYear = ? OR ? IS NULL AND StartYear IS NULL) AND (YearsActive = ? OR ? IS NULL AND YearsActive IS NULL)";
			this.oleDbDeleteCommand6.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteUseID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteUseID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = "INSERT INTO tblAquaticSiteAgencyUse(AgencyCd, AgencySiteID, AquaticActivityCd, Aq" +
				"uaticSiteID, AquaticSiteType, EndYear, IncorporatedInd, StartYear, YearsActive) " +
				"VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticSiteType"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, "YearsActive"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivityCd, AquaticSiteID, AquaticSiteType," +
				" AquaticSiteUseID, EndYear, IncorporatedInd, StartYear, YearsActive FROM tblAqua" +
				"ticSiteAgencyUse";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand6
			// 
			this.oleDbUpdateCommand6.CommandText = @"UPDATE tblAquaticSiteAgencyUse SET AgencyCd = ?, AgencySiteID = ?, AquaticActivityCd = ?, AquaticSiteID = ?, AquaticSiteType = ?, EndYear = ?, IncorporatedInd = ?, StartYear = ?, YearsActive = ? WHERE (AquaticSiteUseID = ?) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AgencySiteID = ? OR ? IS NULL AND AgencySiteID IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (AquaticSiteType = ? OR ? IS NULL AND AquaticSiteType IS NULL) AND (EndYear = ? OR ? IS NULL AND EndYear IS NULL) AND (IncorporatedInd = ?) AND (StartYear = ? OR ? IS NULL AND StartYear IS NULL) AND (YearsActive = ? OR ? IS NULL AND YearsActive IS NULL)";
			this.oleDbUpdateCommand6.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticSiteType"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, "YearsActive"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteUseID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteUseID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			// 
			// objdsSiteUse
			// 
			this.objdsSiteUse.DataSetName = "dsSiteUse";
			this.objdsSiteUse.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblAquaticSite
			// 
			this.dvtblAquaticSite.Sort = "AquaticSiteID";
			this.dvtblAquaticSite.Table = this.objdstblAquaticSite.tblAquaticSite;
			// 
			// dvSiteUse
			// 
			this.dvSiteUse.Sort = "AquaticSiteUseID";
			this.dvSiteUse.Table = this.objdsSiteUse.tblAquaticSiteAgencyUse;
			// 
			// oleDbdaDE_Watersheds
			// 
			this.oleDbdaDE_Watersheds.InsertCommand = this.oleDbInsertCommand7;
			this.oleDbdaDE_Watersheds.SelectCommand = this.oleDbSelectCommand7;
			this.oleDbdaDE_Watersheds.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "DE-Watersheds", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																							new System.Data.Common.DataColumnMapping("DrainName", "DrainName"),
																																																							new System.Data.Common.DataColumnMapping("Level1Name", "Level1Name"),
																																																							new System.Data.Common.DataColumnMapping("Level2Name", "Level2Name"),
																																																							new System.Data.Common.DataColumnMapping("Level3Name", "Level3Name"),
																																																							new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																							new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName")})});
			// 
			// oleDbInsertCommand7
			// 
			this.oleDbInsertCommand7.CommandText = "INSERT INTO [DE-Watersheds] (DrainageCd, DrainName, Level1Name, Level2Name, Level" +
				"3Name, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand7.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainName", System.Data.OleDb.OleDbType.VarWChar, 255, "DrainName"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level1Name", System.Data.OleDb.OleDbType.VarWChar, 40, "Level1Name"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level2Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level2Name"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level3Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level3Name"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			// 
			// oleDbSelectCommand7
			// 
			this.oleDbSelectCommand7.CommandText = "SELECT DrainageCd, DrainName, Level1Name, Level2Name, Level3Name, WaterBodyID, Wa" +
				"terBodyName FROM [DE-Watersheds]";
			this.oleDbSelectCommand7.Connection = this.oleDbConnection1;
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
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvironmentalObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvironmentalSurveyFieldMeasures)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalSurveyFieldMeasures)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvPlanning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalPlanning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticSite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsSiteUse)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblAquaticSite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvSiteUse)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsWatersheds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvWatersheds)).EndInit();

		}
		#endregion

		#region Buttons
		protected void btnDone_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFList.aspx");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFList.aspx");
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string sql1 = "DELETE FROM tblAquaticSite WHERE AquaticSiteID = "+Session["SelectedSiteID"].ToString();
			string sql2 = "DELETE FROM tblAquaticSiteAgencyUse WHERE AquaticSiteUseID = "+Session["SelectedSiteUseID"].ToString();
			string sql3 = "DELETE FROM tblAquaticActivity WHERE AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			string sql4 = "DELETE FROM tblEnvironmentalObservations WHERE AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			string sql5 = "DELETE FROM tblEnvironmentalSurveyFieldMeasures WHERE AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			string sql6 = "DELETE FROM tblEnvironmentalPlanning WHERE AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			oleDbConnection1.Open();
			OleDbCommand cmd1 = new OleDbCommand(sql1, oleDbConnection1);
			OleDbCommand cmd2 = new OleDbCommand(sql2, oleDbConnection1);
			OleDbCommand cmd3 = new OleDbCommand(sql3, oleDbConnection1);
			OleDbCommand cmd4 = new OleDbCommand(sql4, oleDbConnection1);
			OleDbCommand cmd5 = new OleDbCommand(sql5, oleDbConnection1);
			OleDbCommand cmd6 = new OleDbCommand(sql6, oleDbConnection1);
			try
			{
				cmd6.ExecuteNonQuery();
				cmd5.ExecuteNonQuery();
				cmd4.ExecuteNonQuery();
				cmd3.ExecuteNonQuery();
				cmd2.ExecuteNonQuery();
				cmd1.ExecuteNonQuery();
				oleDbConnection1.Close();
				Session["List"] = "ESAFList.aspx";
				Server.Transfer("ConfirmDelete.aspx");
			}
			catch
			{
				oleDbConnection1.Close();
				//do not delete
				//do not transfer
			}
		}
		
		protected void btnModifySiteIdentification_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = true;
			Server.Transfer("ESAFSiteIdentification.aspx");
		}

		protected void btnModifySurveyInfo_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = true;
			Server.Transfer("ESAFSurveyInfo.aspx");
		}

		protected void btnModifySiteObservations_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = true;
			Server.Transfer("ESAFSiteObservations.aspx");
		}

		protected void btnModifySiteCharacteristics_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = true;
			Server.Transfer("ESAFSiteCharacteristics.aspx");
		}

		protected void btnModifyUpstreamVegetation_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = true;
			Server.Transfer("ESAFUpstreamVegetation.aspx");
		}
		
		protected void btnModifyFieldMeasurements_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = true;
			Server.Transfer("ESAFFieldMeasurements.aspx");
		}
		
		protected void btnModifyPlanning_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = true;
			Server.Transfer("ESAFPlanning.aspx");
		}
		
		protected void btnResume_Click(object sender, System.EventArgs e)
		{
			Session["Modify"] = false;
			Server.Transfer("ESAFSiteCharacteristics.aspx");
		}
		protected void btnMap_Click(object sender, System.EventArgs e)
		{
			try
			{
                //Session["XCoord"] = txtX.Text;
                //Session["YCoord"] = txtY.Text;
                //Session["Units"] = txtUnits.Text;
                //Session["CoordSys"] = txtSystem.Text;
                //Session["CoordSource"] = txtSource.Text;
                //if(!IsStartupScriptRegistered("MapWindow"))
                //{
                //    Page.RegisterStartupScript("MapWindow","<script language='javascript' id='MapWindow'>window.open('Map.aspx');</script>");
                //}

                // XXX: uggh, am i really hardcoding this url?
                //      have to do something to alleviate this later...
                //      - colin 
                string mapUrlFormat = "http://cri.nbwaters.unb.ca/map-staging/?legacy=true&x={0}&y={1}&srs={2}";
                string mapUrl = String.Format(mapUrlFormat, txtX.Text, txtY.Text, txtSystem.Text);

                if (!IsStartupScriptRegistered("MapWindow"))
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
