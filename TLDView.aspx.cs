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
	/// Summary description for TLDView.
	/// </summary>
	///

	public partial class TLDView : System.Web.UI.Page
	{
		#region Controls
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SiteInfo;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected NBADWDataEntryApplication.dsDE_SiteInfo objdsDE_SiteInfo;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblWaterTemperatureLoggerDetails;
		protected NBADWDataEntryApplication.dstblWaterTemperatureLoggerDetails objdstblWaterTemperatureLoggerDetails;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticActivity;
		protected NBADWDataEntryApplication.dstblAquaticActivity objdstblAquaticActivity;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdAgency;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		protected NBADWDataEntryApplication.dscdAgency objdscdAgency;
		protected System.Data.DataView dvcdAgency;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand5;
		#endregion
        	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				SetPageMode();
				SetSiteFields();
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


		#region Buttons
		protected void btnModify_Click(object sender, System.EventArgs e)
		{
			Session["Mode"] = "Modify";
			SetPageMode();
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string sql1 = "DELETE FROM tblAquaticActivity WHERE AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			string sql2 = "DELETE FROM tblWaterTemperatureLoggerDetails WHERE AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			oleDbConnection1.Open();
			OleDbCommand cmd1 = new OleDbCommand(sql1, oleDbConnection1);
			OleDbCommand cmd2 = new OleDbCommand(sql2, oleDbConnection1);
			try
			{
				cmd2.ExecuteNonQuery();
				cmd1.ExecuteNonQuery();
				oleDbConnection1.Close();
				Server.Transfer("TLDList.aspx");
			}
			catch (System.Data.OleDb.OleDbException er)
			{
				Debug.WriteLine("Error: "+er.ToString());
				oleDbConnection1.Close();
				//Session["List"] = "TLDList.aspx";
				//Server.Transfer("ConfirmDeleteNo.aspx");
				//Server.Transfer("TLDList.aspx");
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string strValues = "";
			string strFields = "";
			switch (Session["Mode"].ToString())
			{
				#region Add
				case "Add":
					Debug.WriteLine("Adding records");
					//get new activity
					LoadActivitySet();
					DataTable tActivity = objdstblAquaticActivity.tblAquaticActivity;
					DataRow rActivity = tActivity.NewRow();

					int i = FindBiggest(tActivity,"AquaticActivityID");
					rActivity["AquaticActivityID"] = i+1;
					Session["CurrentActivityID"] = rActivity["AquaticActivityID"];
					rActivity["AquaticActivityCd"] = 20;
					rActivity["AquaticMethodCd"] = 9;
					//rActivity["AquaticSiteID"] = Session["SelectedSiteID"].ToString();
					rActivity["AquaticSiteID"] = txtdwsiteid.Text;
					rActivity["AquaticActivityStartDate"] = txtRecordingStartDate.Text;
					rActivity["AquaticActivityEndDate"] = txtRecordingEndDate.Text;
					//rActivity["AgencyCd"] = dlstAgency1.SelectedValue;
					rActivity["AgencyCd"] = txtagencycd.Text;
					if(dlstAgency2.SelectedValue!="")
					{
						rActivity["Agency2Cd"] = dlstAgency2.SelectedValue;
					}
					if(txtPersonnel.Text.Length!=0)
					{
						rActivity["Crew"] = txtPersonnel.Text;
					}
					rActivity["DateEntered"]=System.DateTime.Now.ToShortDateString();
					rActivity["IncorporatedInd"] = false;

					tActivity.Rows.Add(rActivity);

					try
					{
						//oleDbdatblAquaticActivity.Update(objdstblAquaticActivity);
						//Debug.WriteLine("Activity Created");
					}
					catch (Exception ex)
					{
						Debug.WriteLine("Error during Add: "+ex.ToString());
					}

					//create record in datalogger table
					//create record in datalogger table
					strFields = "AquaticActivityID";
					strValues = Session["CurrentActivityID"].ToString();

					strFields += ", LoggerNo";
					strValues += ", '" + txtDataLoggerID.Text + "'";

					strFields += ", BrandName";
					strValues += ", '" + txtBrandName.Text + "'";

					strFields += ", Model";
					strValues += ", '" + txtModel.Text + "'";

					strFields += ", Resolution";
					strValues += ", '" + txtResolution.Text + "'";

					strFields += ", Accuracy";
					strValues += ", '" + txtAccuracy.Text + "'";

					if(txtRangeFrom.Text!="")
					{
						strFields += ", TempRange_From";
						strValues += ", '" + txtRangeFrom.Text + "'";
					}

					if(txtRangeTo.Text!="")
					{
						strFields += ", TempRange_To";
						strValues += ", '" + txtRangeTo.Text + "'";
					}

					strFields += ", DataFileName";
					strValues += ", '" + txtDataFileName.Text + "'";

					if(txtInstallationDate.Text!="")
					{
						strFields += ", InstallationDate";
						strValues += ", '" + txtInstallationDate.Text + "'";
					}

					if(txtRemovalDate.Text!="")
					{
						strFields += ", RemovalDate";
						strValues += ", '" + txtRemovalDate.Text + "'";
					}

					strFields += ", RecordingStartDate";
					strValues += ", '" + txtRecordingStartDate.Text + "'";

					strFields += ", RecordingEndDate";
					strValues += ", '" + txtRecordingEndDate.Text + "'";

					strFields += ", OutofWaterReadingsOccurred";
					strValues += ", "+chkOutofWaterReadingsOccurred.Checked;

					strFields += ", OutofWaterReadingsRemoved";
					strValues += ", "+chkOutofWaterReadingsRemoved.Checked;

					if(txtTrueLeftBank.Text!="")
					{
						strFields += ", DistanceFromLeftBank_m";
						strValues += ", '" + txtTrueLeftBank.Text + "'";
					}

					if(txtTrueRightBank.Text!="")
					{
						strFields += ", DistanceFromRightBank_m";
						strValues += ", '" + txtTrueRightBank.Text + "'";
					}

					if(txtWaterDepth.Text!="")
					{
						strFields += ", WaterDepth_cm";
						strValues += ", '" + txtWaterDepth.Text + "'";
					}

					if(txtSampleInterval.Text!="")
					{
						strFields += ", SampleInterval_min";
						strValues += ", '" + txtSampleInterval.Text + "'";
					}

					if(txtInstallWaterTemp.Text!="")
					{
						strFields += ", Install_WaterTemp_C";
						strValues += ", '" + txtInstallWaterTemp.Text + "'";
					}

					if(txtInstallAirTemp.Text!="")
					{
						strFields += ", Install_AirTemp_C";
						strValues += ", '" + txtInstallAirTemp.Text + "'";
					}

					strFields += ", Install_TimeofDay";
					strValues += ", '" + txtInstallTimeofDay.Text + "'";

					if(txtRemoveWaterTemp.Text!="")
					{
						strFields += ", Removal_WaterTemp_C";
						strValues += ", '" + txtRemoveWaterTemp.Text + "'";
					}

					if(txtRemoveAirTemp.Text!="")
					{
						strFields += ", Removal_AirTemp_C";
						strValues += ", '" + txtRemoveAirTemp.Text + "'";
					}

					strFields += ", Removal_TimeofDay";
					strValues += ", '" + txtRemoveTimeofDay.Text + "'";

					if(dlstInstallWaterLevel.SelectedValue!="")
					{
						strFields += ", WaterLevel_Install";
						strValues += ", '" + dlstInstallWaterLevel.SelectedValue + "'";
					}

					if(dlstRemoveWaterLevel.SelectedValue!="")
					{
						strFields += ", WaterLevel_Removal";
						strValues += ", '" + dlstRemoveWaterLevel.SelectedValue + "'";
					}

					try
					{
						oleDbdatblAquaticActivity.Update(objdstblAquaticActivity);
						Debug.WriteLine("Activity Created");
						string sql = "INSERT INTO tblWaterTemperatureLoggerDetails ("+strFields+") VALUES ("+strValues+")";
						Debug.WriteLine("SQL string: "+sql);
						oleDbConnection1.Open();
						OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
						cmd.ExecuteNonQuery();
						Debug.WriteLine("Logger Created");
						oleDbConnection1.Close();
						Server.Transfer("TLDList.aspx"); 
					}
					catch(Exception ex)
					{
						Debug.WriteLine("Error during update: "+ex.ToString());
					}
					break;

					#endregion

				#region Modify
				case "Modify":
					strValues = "AquaticActivityID = "+Session["CurrentActivityID"].ToString();
					strValues += ", AquaticActivityStartDate = '"+txtRecordingStartDate.Text+"'";
					strValues += ", AquaticActivityEndDate = '"+txtRecordingEndDate.Text+"'";
					//strValues += ", AgencyCd = '"+dlstAgency1.SelectedValue+"'";
					strValues += ", AgencyCd = '"+txtagencycd.Text+"'";
					if(dlstAgency2.SelectedValue!="")
					{
						strValues += ", Agency2Cd = '"+dlstAgency2.SelectedValue+"'";
					}
					strValues += ", Crew = '"+txtPersonnel.Text+"'";
					
                    
					try
					{
						string sql = "UPDATE tblAquaticActivity SET "+strValues+" WHERE AquaticActivityID = " +Session["CurrentActivityID"].ToString();
						Debug.WriteLine("SQL string: "+sql);
						oleDbConnection1.Open();
						OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
						cmd.ExecuteNonQuery();
						Debug.WriteLine("Activity Updated");
						oleDbConnection1.Close();
					}
					catch(Exception ex)
					{
						Debug.WriteLine("Error during update: "+ex.ToString());
					}

					strValues = "AquaticActivityID = "+Session["CurrentActivityID"].ToString();
					strValues += ", LoggerNo = '" + txtDataLoggerID.Text + "'";
					strValues += ", BrandName = '" + txtBrandName.Text + "'";
					strValues += ", Model = '" + txtModel.Text + "'";
					strValues += ", Resolution = '" + txtResolution.Text + "'";
					strValues += ", Accuracy = '" + txtAccuracy.Text + "'";

					if(txtRangeFrom.Text!="")
					{
						strValues += ", TempRange_From = '" + txtRangeFrom.Text + "'";
					}
					else
					{
						strValues += ", TempRange_From = Null";
					}
                    
					if(txtRangeTo.Text!="")
					{
						strValues += ", TempRange_To = '" + txtRangeTo.Text + "'";
					}
					else
					{
						strValues += ", TempRange_To = Null";
					}

					strValues += ", DataFileName = '" + txtDataFileName.Text + "'";
					strValues += ", InstallationDate = '" + txtInstallationDate.Text + "'";
					strValues += ", RemovalDate = '" + txtRemovalDate.Text + "'";
					strValues += ", RecordingStartDate = '" + txtRecordingStartDate.Text + "'";
					strValues += ", RecordingEndDate = '" + txtRecordingEndDate.Text + "'";
					strValues += ", OutofWaterReadingsOccurred = "+chkOutofWaterReadingsOccurred.Checked;
					strValues += ", OutofWaterReadingsRemoved = "+chkOutofWaterReadingsRemoved.Checked;

					if(txtTrueLeftBank.Text!="")
					{
						strValues += ", DistanceFromLeftBank_m = '" + txtTrueLeftBank.Text + "'";
					}
					else
					{
						strValues += ", DistanceFromLeftBank_m = Null";
					}

					if(txtTrueRightBank.Text!="")
					{
						strValues += ", DistanceFromRightBank_m = '" + txtTrueRightBank.Text + "'";
					}
					else
					{
						strValues += ", DistanceFromRightBank_m = Null";
					}

					if(txtWaterDepth.Text!="")
					{
						strValues += ", WaterDepth_cm = '" + txtWaterDepth.Text + "'";
					}
					else
					{
						strValues += ", WaterDepth_cm = Null";
					}

					if(txtSampleInterval.Text!="")
					{
						strValues += ", SampleInterval_min = '" + txtSampleInterval.Text + "'";
					}
					else
					{
						strValues += ", SampleInterval_min = Null";
					}

					if(txtInstallWaterTemp.Text!="")
					{
						strValues += ", Install_WaterTemp_C = '" + txtInstallWaterTemp.Text + "'";
					}
					else
					{
						strValues += ", Install_WaterTemp_C = Null";
					}

					if(txtInstallAirTemp.Text!="")
					{
						strValues += ", Install_AirTemp_C = '" + txtInstallAirTemp.Text + "'";
					}
					else
					{
						strValues += ", Install_AirTemp_C = Null";
					}

					if(txtRemoveWaterTemp.Text!="")
					{
						strValues += ", Removal_WaterTemp_C = '" + txtRemoveWaterTemp.Text + "'";
					}
					else
					{
						strValues += ", Removal_WaterTemp_C = Null";
					}

					if(txtRemoveAirTemp.Text!="")
					{
						strValues += ", Removal_AirTemp_C = '" + txtRemoveAirTemp.Text + "'";
					}
					else
					{
						strValues += ", Removal_AirTemp_C = Null";
					}

					strValues += ", Install_TimeofDay = '" + txtInstallTimeofDay.Text + "'";
					strValues += ", Removal_TimeofDay = '" + txtRemoveTimeofDay.Text + "'";
					
					strValues += ", WaterLevel_Install = '" + dlstInstallWaterLevel.SelectedValue + "'";
					strValues += ", WaterLevel_Removal = '" + dlstRemoveWaterLevel.SelectedValue + "'";
					
					try
					{
						string sql = "UPDATE tblWaterTemperatureLoggerDetails SET "+strValues+" WHERE AquaticActivityID = " +Session["CurrentActivityID"].ToString();
						Debug.WriteLine("SQL string: "+sql);
						oleDbConnection1.Open();
						OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
						cmd.ExecuteNonQuery();
						Debug.WriteLine("Logger Updated");
						oleDbConnection1.Close();
						Server.Transfer("TLDList.aspx");
					}
					catch(Exception ex)
					{
						Debug.WriteLine("Error during update: "+ex.ToString());
					}
					break;
					#endregion

				#region Modify Site
				case "ModifySite":
					try
					{
						string sql = "UPDATE tblAquaticActivity SET AquaticSiteID = "+txtdwsiteid.Text+" WHERE AquaticActivityID = " +Session["CurrentActivityID"].ToString();
						Debug.WriteLine("SQL string: "+sql);
						oleDbConnection1.Open();
						OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
						cmd.ExecuteNonQuery();
						Debug.WriteLine("Activity Updated");
						oleDbConnection1.Close();
						Server.Transfer("TLDList.aspx");
					}
					catch(Exception ex)
					{
						Debug.WriteLine("Error during update: "+ex.ToString());
					}
					break;
					#endregion
			}			
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			//return to view state
			if(btnChangeSite.Visible)
			{
				try
				{
					Session["SelectedSiteUseID"] = Session["OldSelectedSiteUseID"].ToString();
					Session["OldSelectedSiteUseID"] = null;
					SetSiteFields();
				}
				catch
				{
					//do nothing, must not have chosen a new site yet.
				}
				Session["Mode"] = "View";
				SetPageMode();
			}
			else//must be in add mode
			{
				Server.Transfer("TLDList.aspx");
			}
		}

		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			try
			{
				Debug.WriteLine("SiteUse is "+Session["SelectedSiteUseID"].ToString());
			}
			catch
			{
				Debug.WriteLine("Don't have a site use");
			}
			Server.Transfer("TLDList.aspx");
		}
		
		protected void btnChangeSite_Click(object sender, System.EventArgs e)
		{
			Session["Mode"] = "ModifySite";
			Session["PreviousPage"] = "TLDView.aspx";
			Server.Transfer("SelectSite.aspx");
		}

		protected void btnLookUp_Click(object sender, System.EventArgs e)
		{
			Session["Mode"] = "ModifySite";
			Session["PreviousPage"] = "TLDView.aspx";
			//Server.Transfer("BUMP.aspx");
			Server.Transfer("TRSSearch.aspx");
		}
		protected void btnData_Click(object sender, System.EventArgs e)
		{
			//Session["PreviousPage"] = "TLDList.aspx";
			//Server.Transfer("TEMPView.aspx");
			string strScript = "<script language='javascript' id='TempDataWindow'>window.open('TEMPERATURESView.aspx','" + System.DateTime.Now.Millisecond.ToString() + "','height=600,width=695,status=yes,toolbar=no,menubar=no,location=no, scrollbars=yes, resizable = yes');</script>";
			Debug.WriteLine("Script : " + strScript);
			Page.RegisterStartupScript("TempDataWindow",strScript.ToString());
			
		}
		#endregion

		#region Enable Disable
		private void EnableDataLoggerFields()
		{
			/*
			txtAgency1.Enabled = true;
			txtAgency2.Enabled = true;
			*/
			txtPersonnel.Enabled = true;		
			
			txtDataLoggerID.Enabled = true;
			txtBrandName.Enabled = true;
			txtModel.Enabled = true;
			txtResolution.Enabled = true;
			txtAccuracy.Enabled = true;
			txtRangeFrom.Enabled = true;
			txtRangeTo.Enabled = true;
			txtDataFileName.Enabled = true;
			txtInstallationDate.Enabled = true;
			txtRemovalDate.Enabled = true;
			txtRecordingStartDate.Enabled = true;
			txtRecordingEndDate.Enabled = true;
			txtTrueLeftBank.Enabled = true;
			txtTrueRightBank.Enabled = true;
			txtWaterDepth.Enabled = true;
			txtSampleInterval.Enabled = true;
			txtInstallWaterTemp.Enabled = true;
			txtInstallAirTemp.Enabled = true;
			txtInstallTimeofDay.Enabled = true;
			txtRemoveWaterTemp.Enabled = true;
			txtRemoveAirTemp.Enabled = true;
			txtRemoveTimeofDay.Enabled = true;
			txtInstallWaterLevel.Enabled = true;
			txtRemoveWaterLevel.Enabled = true;

			chkOutofWaterReadingsOccurred.Enabled = true;
			chkOutofWaterReadingsRemoved.Enabled = true;

			/*
			txtAgency1.BackColor = Color.White;
			txtAgency2.BackColor = Color.White;
			*/
			txtPersonnel.BackColor = Color.White;

			txtDataLoggerID.BackColor = Color.White;
			txtBrandName.BackColor = Color.White;
			txtModel.BackColor = Color.White;
			txtResolution.BackColor = Color.White;
			txtAccuracy.BackColor = Color.White;
			txtRangeFrom.BackColor = Color.White;
			txtRangeTo.BackColor = Color.White;
			txtDataFileName.BackColor = Color.White;
			txtInstallationDate.BackColor = Color.White;
			txtRemovalDate.BackColor = Color.White;
			txtRecordingStartDate.BackColor = Color.White;
			txtRecordingEndDate.BackColor = Color.White;
			txtTrueLeftBank.BackColor = Color.White;
			txtTrueRightBank.BackColor = Color.White;
			txtWaterDepth.BackColor = Color.White;
			txtSampleInterval.BackColor = Color.White;
			txtInstallWaterTemp.BackColor = Color.White;
			txtInstallAirTemp.BackColor = Color.White;
			txtInstallTimeofDay.BackColor = Color.White;
			txtRemoveWaterTemp.BackColor = Color.White;
			txtRemoveAirTemp.BackColor = Color.White;
			txtRemoveTimeofDay.BackColor = Color.White;
			txtInstallWaterLevel.BackColor = Color.White;
			txtRemoveWaterLevel.BackColor = Color.White;
		}

		private void DisableDataLoggerFields()
		{
			/*
			txtAgency1.Enabled = false;
			txtAgency2.Enabled = false;
			*/
			txtPersonnel.Enabled = false;
			
			txtDataLoggerID.Enabled = false;
			txtBrandName.Enabled = false;
			txtModel.Enabled = false;
			txtResolution.Enabled = false;
			txtAccuracy.Enabled = false;
			txtRangeFrom.Enabled = false;
			txtRangeTo.Enabled = false;
			txtDataFileName.Enabled = false;
			txtInstallationDate.Enabled = false;
			txtRemovalDate.Enabled = false;
			txtRecordingStartDate.Enabled = false;
			txtRecordingEndDate.Enabled = false;
			txtTrueLeftBank.Enabled = false;
			txtTrueRightBank.Enabled = false;
			txtWaterDepth.Enabled = false;
			txtSampleInterval.Enabled = false;
			txtInstallWaterTemp.Enabled = false;
			txtInstallAirTemp.Enabled = false;
			txtInstallTimeofDay.Enabled = false;
			txtRemoveWaterTemp.Enabled = false;
			txtRemoveAirTemp.Enabled = false;
			txtRemoveTimeofDay.Enabled = false;
			txtInstallWaterLevel.Enabled = false;
			txtRemoveWaterLevel.Enabled = false;

			chkOutofWaterReadingsOccurred.Enabled = false;
			chkOutofWaterReadingsRemoved.Enabled = false;

			/*
			txtAgency1.BackColor = Color.WhiteSmoke;
			txtAgency2.BackColor = Color.WhiteSmoke;
			*/
			txtPersonnel.BackColor = Color.WhiteSmoke;
			
			txtDataLoggerID.BackColor = Color.WhiteSmoke;
			txtBrandName.BackColor = Color.WhiteSmoke;
			txtModel.BackColor = Color.WhiteSmoke;
			txtResolution.BackColor = Color.WhiteSmoke;
			txtAccuracy.BackColor = Color.WhiteSmoke;
			txtRangeFrom.BackColor = Color.WhiteSmoke;
			txtRangeTo.BackColor = Color.WhiteSmoke;
			txtDataFileName.BackColor = Color.WhiteSmoke;
			txtInstallationDate.BackColor = Color.WhiteSmoke;
			txtRemovalDate.BackColor = Color.WhiteSmoke;
			txtRecordingStartDate.BackColor = Color.WhiteSmoke;
			txtRecordingEndDate.BackColor = Color.WhiteSmoke;
			txtTrueLeftBank.BackColor = Color.WhiteSmoke;
			txtTrueRightBank.BackColor = Color.WhiteSmoke;
			txtWaterDepth.BackColor = Color.WhiteSmoke;
			txtSampleInterval.BackColor = Color.WhiteSmoke;
			txtInstallWaterTemp.BackColor = Color.WhiteSmoke;
			txtInstallAirTemp.BackColor = Color.WhiteSmoke;
			txtInstallTimeofDay.BackColor = Color.WhiteSmoke;
			txtRemoveWaterTemp.BackColor = Color.WhiteSmoke;
			txtRemoveAirTemp.BackColor = Color.WhiteSmoke;
			txtRemoveTimeofDay.BackColor = Color.WhiteSmoke;
			txtInstallWaterLevel.BackColor = Color.WhiteSmoke;
			txtRemoveWaterLevel.BackColor = Color.WhiteSmoke;
		}

		private void EnableSaveCancel()
		{
			btnSave.Visible = true;
			btnCancel.Visible = true;
		}

		private void DisableSaveCancel()
		{
			btnSave.Visible = false;
			btnCancel.Visible = false;
		}

		private void EnableModifyDelete()
		{
			btnModify.Visible = true;
			btnDelete.Visible = true;
		}

		private void DisableModifyDelete()
		{
			btnModify.Visible = false;
			btnDelete.Visible = false;
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

		public void FilltblWaterTemperatureLoggerDetails(NBADWDataEntryApplication.dstblWaterTemperatureLoggerDetails dataSet1)
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
				this.oleDbdatblWaterTemperatureLoggerDetails.Fill(dataSet1);
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

		public void LoadtblWaterTemperatureLoggerDetails()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblWaterTemperatureLoggerDetails objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dstblWaterTemperatureLoggerDetails();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblWaterTemperatureLoggerDetails(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblWaterTemperatureLoggerDetails.Clear();
				
				// Merge the records into the main dataset.
				objdstblWaterTemperatureLoggerDetails.Merge(objDataSetTemp1);
				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

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

		public void FillcdAgency(NBADWDataEntryApplication.dscdAgency dataSet1)
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

		public void LoadcdAgency()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdAgency objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dscdAgency();
			
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
		#endregion

		#region PageMode
		private void SetPageMode()
		{
			try
			{
				if((bool)Session["Administrator"])
				{
					try
					{
						switch (Session["Mode"].ToString())
						{
							case "Add":
								Debug.WriteLine("Mode is Add");
								pnlAdd.Visible=true;
								pnlEdit.Visible = false;
								EnableDataLoggerFields();
								EnableSaveCancel();
								DisableModifyDelete();
								btnChangeSite.Visible= false;
								btnLookUp.Visible=false;
								btnReturn.Visible = false;
								btnData.Visible = false;
								//txtAgency1.Visible = false;
								txtAgency2.Visible = false;
								//dlstAgency1.Visible = true;
								dlstAgency2.Visible = true;
								lblh2.Text = "ADD New Logger";

								LoadcdAgency();
								//dlstAgency1.DataBind();
								dlstAgency2.DataBind();
								dlstAgency2.Items.Add(new ListItem("",""));
								dlstAgency2.SelectedIndex = dlstAgency2.Items.Count-1;

								txtInstallWaterLevel.Visible = false;
								txtRemoveWaterLevel.Visible = false;
								dlstInstallWaterLevel.Visible = true;
								dlstRemoveWaterLevel.Visible = true;

								dlstInstallWaterLevel.Items.Add(new ListItem("",""));
								dlstInstallWaterLevel.Items.Add(new ListItem("Very High","Very High"));
								dlstInstallWaterLevel.Items.Add(new ListItem("High","High"));
								dlstInstallWaterLevel.Items.Add(new ListItem("Normal","Normal"));
								dlstInstallWaterLevel.Items.Add(new ListItem("Low","Low"));
								dlstInstallWaterLevel.Items.Add(new ListItem("Very Low","Very Low"));
								dlstInstallWaterLevel.SelectedIndex = 0;

								dlstRemoveWaterLevel.Items.Add(new ListItem("",""));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Very High","Very High"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("High","High"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Normal","Normal"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Low","Low"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Very Low","Very Low"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Dry","Dry"));
								dlstRemoveWaterLevel.SelectedIndex = 0;

								break;
							case "Modify":
								Debug.WriteLine("Mode is Modify");
								pnlAdd.Visible=false;
								pnlEdit.Visible = true;
								EnableDataLoggerFields();
								EnableSaveCancel();
								DisableModifyDelete();
								btnChangeSite.Visible = true;
								btnLookUp.Visible = false;
								btnReturn.Visible = false;
								btnData.Visible = false;
								btnData.Visible = false;
								txtAgency2.Visible = false;
								dlstAgency2.Visible = true;
								lblh2.Text = "EDIT Logger";

								LoadcdAgency();
								dlstAgency2.DataBind();
								dlstAgency2.Items.Add(new ListItem("",""));
								SetdlstAgency();

								txtInstallWaterLevel.Visible = false;
								txtRemoveWaterLevel.Visible = false;
								dlstInstallWaterLevel.Visible = true;
								dlstRemoveWaterLevel.Visible = true;

								dlstInstallWaterLevel.Items.Add(new ListItem("",""));
								dlstInstallWaterLevel.Items.Add(new ListItem("Very High","Very High"));
								dlstInstallWaterLevel.Items.Add(new ListItem("High","High"));
								dlstInstallWaterLevel.Items.Add(new ListItem("Normal","Normal"));
								dlstInstallWaterLevel.Items.Add(new ListItem("Low","Low"));
								dlstInstallWaterLevel.Items.Add(new ListItem("Very Low","Very Low"));
								
								dlstRemoveWaterLevel.Items.Add(new ListItem("",""));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Very High","Very High"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("High","High"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Normal","Normal"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Low","Low"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Very Low","Very Low"));
								dlstRemoveWaterLevel.Items.Add(new ListItem("Dry","Dry"));
								
								SetdlstWaterLevel();
								break;
							case "ModifySite":
								Debug.WriteLine("Mode is ModifySite");
								pnlAdd.Visible = false;
								pnlEdit.Visible = true;
								DisableDataLoggerFields();
								EnableSaveCancel();
								DisableModifyDelete();

								btnChangeSite.Visible = true;
								btnLookUp.Visible=false;
								btnReturn.Visible = false;
								btnData.Visible = false;
								txtAgency2.Visible = true;
								dlstAgency2.Visible = false;
								txtInstallWaterLevel.Visible = true;
								txtRemoveWaterLevel.Visible = true;
								dlstInstallWaterLevel.Visible = false;
								dlstRemoveWaterLevel.Visible = false;
								lblh2.Text = "EDIT Logger";

								if(!Page.IsPostBack)
								{
									SetLoggerFields();
									SetAgencyFields();
								}
								break;
							case "View":
								Debug.WriteLine("Mode is View");
								pnlAdd.Visible= false;
								pnlEdit.Visible = false;
								DisableDataLoggerFields();
								DisableSaveCancel();
								//Admin priv
								EnableModifyDelete();
								btnChangeSite.Visible = false;
								btnLookUp.Visible= false;
								btnReturn.Visible = true;
								btnData.Visible = true;
								//txtAgency1.Visible = true;
								txtAgency2.Visible = true;
								//dlstAgency1.Visible = false;
								dlstAgency2.Visible = false;
								txtInstallWaterLevel.Visible = true;
								txtRemoveWaterLevel.Visible = true;
								dlstInstallWaterLevel.Visible = false;
								dlstRemoveWaterLevel.Visible = false;
								
								lblh2.Text = "VIEW Logger";
								//fill fields
								SetLoggerFields();
								if(SetAgencyFields())
								{
									DisableModifyDelete();
									btnData.Visible = true;
								}
								break;
							default:
								//set up as view page wout Admin priv
								Debug.WriteLine("Mode is Default");
								pnlAdd.Visible=false;
								DisableDataLoggerFields();
								DisableSaveCancel();
								DisableModifyDelete();
								btnChangeSite.Visible = false;
								btnLookUp.Visible=false;
								btnReturn.Visible = true;
								btnData.Visible = true;
								//txtAgency1.Visible = true;
								txtAgency2.Visible = true;
								//dlstAgency1.Visible = false;
								dlstAgency2.Visible = false;
								txtInstallWaterLevel.Visible = true;
								txtRemoveWaterLevel.Visible = true;
								dlstInstallWaterLevel.Visible = false;
								dlstRemoveWaterLevel.Visible = false;
								
								lblh2.Text = "VIEW Logger";
								SetLoggerFields();
								SetAgencyFields();
								break;
						}
					}
					catch
					{
						//set up as view page wout Admin priv
						Debug.WriteLine("Mode is not set");
						pnlAdd.Visible=false;
						DisableDataLoggerFields();
						DisableSaveCancel();
						DisableModifyDelete();
						btnChangeSite.Visible = false;
						btnLookUp.Visible=false;
						btnReturn.Visible = true;
						btnData.Visible = true;
						//txtAgency1.Visible = true;
						txtAgency2.Visible = true;
						//dlstAgency1.Visible = false;
						dlstAgency2.Visible = false;
						txtInstallWaterLevel.Visible = true;
						txtRemoveWaterLevel.Visible = true;
						dlstInstallWaterLevel.Visible = false;
						dlstRemoveWaterLevel.Visible = false;
								
						lblh2.Text = "VIEW Logger";
						SetLoggerFields();
						SetAgencyFields();
					}
				}
				else
				{
					//set up as view page wout Admin priv
					Debug.WriteLine("Not Administrator");
					pnlAdd.Visible=false;
					DisableDataLoggerFields();
					DisableSaveCancel();
					DisableModifyDelete();
					btnChangeSite.Visible = false;
					btnLookUp.Visible = false;
					btnReturn.Visible = true;
					btnData.Visible = true;
					//txtAgency1.Visible = true;
					txtAgency2.Visible = true;
					//dlstAgency1.Visible = false;
					dlstAgency2.Visible = false;
					txtInstallWaterLevel.Visible = true;
					txtRemoveWaterLevel.Visible = true;
					dlstInstallWaterLevel.Visible = false;
					dlstRemoveWaterLevel.Visible = false;
								
					lblh2.Text = "VIEW Logger";
					SetLoggerFields();
				}
			}
			catch
			{
				//set up as view page
				Debug.WriteLine("Administrator not set");
				pnlAdd.Visible=false;
				DisableDataLoggerFields();
				DisableSaveCancel();
				EnableModifyDelete();
				btnChangeSite.Visible = false;
				btnLookUp.Visible=false;
				btnReturn.Visible = true;
				btnData.Visible = true;
				//txtAgency1.Visible = true;
				txtAgency2.Visible = true;
				//dlstAgency1.Visible = false;
				dlstAgency2.Visible = false;
				txtInstallWaterLevel.Visible = true;
				txtRemoveWaterLevel.Visible = true;
				dlstInstallWaterLevel.Visible = false;
				dlstRemoveWaterLevel.Visible = false;
								
				lblh2.Text = "VIEW Logger";
				SetLoggerFields();
			}
		}
		#endregion

		#region Set Fields
		private void SetSiteFields()
		{
			LoadSiteInfo();

			DataTable tUse = objdsDE_SiteInfo._DE_SiteInfo;
			DataRow UseRow = tUse.Rows.Find(Session["SelectedSiteUseID"]);

			txtdwsiteid.Text = UseRow["AquaticSiteID"].ToString();
			txtagencycd.Text = UseRow["AgencyCd"].ToString();
			txtgroupsiteid.Text = UseRow["AgencySiteID"].ToString();
			txtwaterbodyid.Text = UseRow["WaterBodyID"].ToString();
			txtwaterbodyname.Text = UseRow["WaterBodyName"].ToString();
			txtsitename.Text = UseRow["AquaticSiteName"].ToString();
			txtsitedescription.Text = UseRow["AquaticSiteDesc"].ToString();
			txtwatershed.Text = UseRow["DrainName"].ToString();
			txtwatershedcode.Text = UseRow["DrainageCd"].ToString();
		}

		private void SetLoggerFields()
		{
			LoadtblWaterTemperatureLoggerDetails();

			Debug.WriteLine("TempID "+Session["SelectedTempID"].ToString());
			DataTable tUse = objdstblWaterTemperatureLoggerDetails.tblWaterTemperatureLoggerDetails;
			DataRow UseRow = tUse.Rows.Find(Session["SelectedTempID"]);
			Session["CurrentActivityID"] = UseRow["AquaticActivityID"];

			txtDataLoggerID.Text = UseRow["LoggerNo"].ToString();
			txtBrandName.Text = UseRow["BrandName"].ToString();
			txtModel.Text = UseRow["Model"].ToString();
			txtResolution.Text = UseRow["Resolution"].ToString();
			txtAccuracy.Text = UseRow["Accuracy"].ToString();
			txtRangeFrom.Text = UseRow["TempRange_From"].ToString();
			txtRangeTo.Text = UseRow["TempRange_To"].ToString();
			txtDataFileName.Text = UseRow["DataFileName"].ToString();
			txtInstallationDate.Text = UseRow["InstallationDate"].ToString();
			txtRemovalDate.Text = UseRow["RemovalDate"].ToString();
			txtRecordingStartDate.Text = UseRow["RecordingStartDate"].ToString();
			txtRecordingEndDate.Text = UseRow["RecordingEndDate"].ToString();
			chkOutofWaterReadingsOccurred.Checked = (bool)UseRow["OutofWaterReadingsOccurred"];
			chkOutofWaterReadingsRemoved.Checked = (bool)UseRow["OutofWaterReadingsRemoved"];
			txtTrueLeftBank.Text = UseRow["DistanceFromLeftBank_m"].ToString();
			txtTrueRightBank.Text = UseRow["DistanceFromRightBank_m"].ToString();
			txtWaterDepth.Text = UseRow["WaterDepth_cm"].ToString();
			txtSampleInterval.Text = UseRow["SampleInterval_min"].ToString();
			txtInstallWaterTemp.Text = UseRow["Install_WaterTemp_C"].ToString();
			txtInstallAirTemp.Text = UseRow["Install_AirTemp_C"].ToString();
			txtInstallTimeofDay.Text = UseRow["Install_TimeofDay"].ToString();
			txtRemoveWaterTemp.Text = UseRow["Removal_WaterTemp_C"].ToString();
			txtRemoveAirTemp.Text = UseRow["Removal_AirTemp_C"].ToString();
			txtRemoveTimeofDay.Text = UseRow["Removal_TimeofDay"].ToString();
			txtInstallWaterLevel.Text = UseRow["WaterLevel_Install"].ToString();
			txtRemoveWaterLevel.Text = UseRow["WaterLevel_Removal"].ToString();
		}

		private bool SetAgencyFields()
		{
			LoadActivitySet();

			Debug.WriteLine("TempID "+Session["SelectedTempID"].ToString());
			DataTable tUse = objdstblAquaticActivity.tblAquaticActivity;
			DataRow UseRow = tUse.Rows.Find(Session["CurrentActivityID"]);

			txtUNCHANGEDdwsiteid.Text = UseRow["AquaticSiteID"].ToString();
			txtAgency1.Text = UseRow["AgencyCd"].ToString();
			txtAgency2.Text = UseRow["Agency2Cd"].ToString();
			txtPersonnel.Text = UseRow["Crew"].ToString();
			return (bool)UseRow["IncorporatedInd"];
		}

		private void SetdlstAgency()
		{
			//int i = dvcdAgency.Find(txtAgency1.Text);
			//dlstAgency1.SelectedIndex = i;
			int j = dvcdAgency.Find(txtAgency2.Text);
			if(j>0)
			{
				dlstAgency2.SelectedIndex = j;
			}
			else
			{
				dlstAgency2.SelectedIndex = dlstAgency2.Items.Count-1;
			}
		}

		private void SetdlstWaterLevel()
		{
			switch (txtInstallWaterLevel.Text)
			{
				case "Very High":
					dlstInstallWaterLevel.SelectedIndex = 1;
					break;
				case "High":
					dlstInstallWaterLevel.SelectedIndex = 2;
					break;
				case "Normal":
					dlstInstallWaterLevel.SelectedIndex = 3;
					break;
				case "Low":
					dlstInstallWaterLevel.SelectedIndex = 4;
					break;
				case "Very Low":
					dlstInstallWaterLevel.SelectedIndex = 5;
					break;
				default:
					dlstInstallWaterLevel.SelectedIndex = 0;
					break;
			}

			switch (txtRemoveWaterLevel.Text)
			{
				case "Very High":
					dlstRemoveWaterLevel.SelectedIndex = 1;
					break;
				case "High":
					dlstRemoveWaterLevel.SelectedIndex = 2;
					break;
				case "Normal":
					dlstRemoveWaterLevel.SelectedIndex = 3;
					break;
				case "Low":
					dlstRemoveWaterLevel.SelectedIndex = 4;
					break;
				case "Very Low":
					dlstRemoveWaterLevel.SelectedIndex = 5;
					break;
				case "Dry":
					dlstRemoveWaterLevel.SelectedIndex = 6;
					break;
				default:
					dlstRemoveWaterLevel.SelectedIndex = 0;
					break;
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
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_SiteInfo = new NBADWDataEntryApplication.dsDE_SiteInfo();
			this.oleDbdatblWaterTemperatureLoggerDetails = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdstblWaterTemperatureLoggerDetails = new NBADWDataEntryApplication.dstblWaterTemperatureLoggerDetails();
			this.oleDbdatblAquaticActivity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.objdstblAquaticActivity = new NBADWDataEntryApplication.dstblAquaticActivity();
			this.oleDbdacdAgency = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdscdAgency = new NBADWDataEntryApplication.dscdAgency();
			this.dvcdAgency = new System.Data.DataView();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblWaterTemperatureLoggerDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdAgency)).BeginInit();
			// 
			// oleDbdaDE_SiteInfo
			// 
			this.oleDbdaDE_SiteInfo.InsertCommand = this.oleDbInsertCommand5;
			this.oleDbdaDE_SiteInfo.SelectCommand = this.oleDbSelectCommand5;
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
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = @"INSERT INTO [DE-SiteInfo] (AquaticSiteDesc, AquaticSiteID, AquaticSiteName, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, DrainName, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, AgencySiteID, AgencyCd) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainName", System.Data.OleDb.OleDbType.VarWChar, 255, "DrainName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSite_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSite.IncorporatedInd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("tblAquaticSiteAgencyUse_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "tblAquaticSiteAgencyUse.IncorporatedInd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			// 
			// oleDbConnection1
			// 
			try
			{
				//this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Registry Path=;Data Source=""C:\Data_Warehouse\Tabular_Data\DE-HRAA.mdb"";Jet OLEDB:System database=;Jet OLEDB:Global Bulk Transactions=1;User ID=Admin;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:SFP=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Engine Type=5;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Global Partial Bulk Ops=2;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Create System Database=False;Jet OLEDB:Database Locking Mode=1";
				this.oleDbConnection1.ConnectionString = Session["ConnectionString"].ToString();
			}
			catch(System.NullReferenceException)
			{
				Server.Transfer("Login.aspx");
			}
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = @"SELECT AquaticSiteDesc, AquaticSiteID, AquaticSiteName, AquaticSiteUseID, CoordinateSource, CoordinateSystem, CoordinateUnits, DrainageCd, DrainName, [tblAquaticSite.IncorporatedInd], [tblAquaticSiteAgencyUse.IncorporatedInd], WaterBodyID, WaterBodyName, XCoordinate, YCoordinate, AgencySiteID, AgencyCd FROM [DE-SiteInfo]";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
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
			// oleDbdatblWaterTemperatureLoggerDetails
			// 
			this.oleDbdatblWaterTemperatureLoggerDetails.DeleteCommand = this.oleDbDeleteCommand5;
			this.oleDbdatblWaterTemperatureLoggerDetails.InsertCommand = this.oleDbInsertCommand7;
			this.oleDbdatblWaterTemperatureLoggerDetails.SelectCommand = this.oleDbSelectCommand7;
			this.oleDbdatblWaterTemperatureLoggerDetails.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															  new System.Data.Common.DataTableMapping("Table", "tblWaterTemperatureLoggerDetails", new System.Data.Common.DataColumnMapping[] {
																																																																  new System.Data.Common.DataColumnMapping("Accuracy", "Accuracy"),
																																																																  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																																  new System.Data.Common.DataColumnMapping("BrandName", "BrandName"),
																																																																  new System.Data.Common.DataColumnMapping("DataFileName", "DataFileName"),
																																																																  new System.Data.Common.DataColumnMapping("DistanceFromLeftBank_m", "DistanceFromLeftBank_m"),
																																																																  new System.Data.Common.DataColumnMapping("DistanceFromRightBank_m", "DistanceFromRightBank_m"),
																																																																  new System.Data.Common.DataColumnMapping("Install_AirTemp_C", "Install_AirTemp_C"),
																																																																  new System.Data.Common.DataColumnMapping("Install_TimeofDay", "Install_TimeofDay"),
																																																																  new System.Data.Common.DataColumnMapping("Install_WaterTemp_C", "Install_WaterTemp_C"),
																																																																  new System.Data.Common.DataColumnMapping("InstallationDate", "InstallationDate"),
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
																																																																  new System.Data.Common.DataColumnMapping("WaterLevel_Install", "WaterLevel_Install"),
																																																																  new System.Data.Common.DataColumnMapping("WaterLevel_Removal", "WaterLevel_Removal"),
																																																																  new System.Data.Common.DataColumnMapping("OutofWaterReadingsOccurred", "OutofWaterReadingsOccurred"),
																																																																  new System.Data.Common.DataColumnMapping("OutofWaterReadingsRemoved", "OutofWaterReadingsRemoved"),
																																																																  new System.Data.Common.DataColumnMapping("LoggerNo", "LoggerNo"),
																																																																  new System.Data.Common.DataColumnMapping("WaterDepth_cm", "WaterDepth_cm")})});
			this.oleDbdatblWaterTemperatureLoggerDetails.UpdateCommand = this.oleDbUpdateCommand5;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM tblWaterTemperatureLoggerDetails WHERE (TemperatureLoggerID = ?) AND " +
				"(Accuracy = ? OR ? IS NULL AND Accuracy IS NULL) AND (AquaticActivityID = ? OR ?" +
				" IS NULL AND AquaticActivityID IS NULL) AND (BrandName = ? OR ? IS NULL AND Bran" +
				"dName IS NULL) AND (DataFileName = ? OR ? IS NULL AND DataFileName IS NULL) AND " +
				"(DistanceFromLeftBank_m = ? OR ? IS NULL AND DistanceFromLeftBank_m IS NULL) AND" +
				" (DistanceFromRightBank_m = ? OR ? IS NULL AND DistanceFromRightBank_m IS NULL) " +
				"AND (Install_AirTemp_C = ? OR ? IS NULL AND Install_AirTemp_C IS NULL) AND (Inst" +
				"all_TimeofDay = ? OR ? IS NULL AND Install_TimeofDay IS NULL) AND (Install_Water" +
				"Temp_C = ? OR ? IS NULL AND Install_WaterTemp_C IS NULL) AND (InstallationDate =" +
				" ? OR ? IS NULL AND InstallationDate IS NULL) AND (LoggerID = ? OR ? IS NULL AND" +
				" LoggerID IS NULL) AND (Model = ? OR ? IS NULL AND Model IS NULL) AND (OutofWate" +
				"rReadingsOccurred = ?) AND (OutofWaterReadingsRemoved = ?) AND (RecordingEndDate" +
				" = ? OR ? IS NULL AND RecordingEndDate IS NULL) AND (RecordingStartDate = ? OR ?" +
				" IS NULL AND RecordingStartDate IS NULL) AND (RemovalDate = ? OR ? IS NULL AND R" +
				"emovalDate IS NULL) AND (Removal_AirTemp_C = ? OR ? IS NULL AND Removal_AirTemp_" +
				"C IS NULL) AND (Removal_TimeofDay = ? OR ? IS NULL AND Removal_TimeofDay IS NULL" +
				") AND (Removal_WaterTemp_C = ? OR ? IS NULL AND Removal_WaterTemp_C IS NULL) AND" +
				" (Resolution = ? OR ? IS NULL AND Resolution IS NULL) AND (SampleInterval_min = " +
				"? OR ? IS NULL AND SampleInterval_min IS NULL) AND (TempRange_From = ? OR ? IS N" +
				"ULL AND TempRange_From IS NULL) AND (TempRange_To = ? OR ? IS NULL AND TempRange" +
				"_To IS NULL) AND (WaterDepth_m = ? OR ? IS NULL AND WaterDepth_m IS NULL) AND (W" +
				"aterLevel_Install = ? OR ? IS NULL AND WaterLevel_Install IS NULL) AND (WaterLev" +
				"el_Removal = ? OR ? IS NULL AND WaterLevel_Removal IS NULL)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TemperatureLoggerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TemperatureLoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerID", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerID1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutofWaterReadingsOccurred", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutofWaterReadingsOccurred", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutofWaterReadingsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutofWaterReadingsRemoved", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = @"INSERT INTO tblWaterTemperatureLoggerDetails(Accuracy, AquaticActivityID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerID, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TempRange_From, TempRange_To, WaterDepth_m, WaterLevel_Install, WaterLevel_Removal, OutofWaterReadingsOccurred, OutofWaterReadingsRemoved) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerID", System.Data.OleDb.OleDbType.VarWChar, 20, "LoggerID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_m"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutofWaterReadingsOccurred", System.Data.OleDb.OleDbType.Boolean, 2, "OutofWaterReadingsOccurred"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutofWaterReadingsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, "OutofWaterReadingsRemoved"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = @"SELECT Accuracy, AquaticActivityID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerID, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TemperatureLoggerID, TempRange_From, TempRange_To, WaterDepth_m, WaterLevel_Install, WaterLevel_Removal, OutofWaterReadingsOccurred, OutofWaterReadingsRemoved FROM tblWaterTemperatureLoggerDetails";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE tblWaterTemperatureLoggerDetails SET Accuracy = ?, AquaticActivityID = ?, " +
				"BrandName = ?, DataFileName = ?, DistanceFromLeftBank_m = ?, DistanceFromRightBa" +
				"nk_m = ?, Install_AirTemp_C = ?, Install_TimeofDay = ?, Install_WaterTemp_C = ?," +
				" InstallationDate = ?, LoggerID = ?, Model = ?, RecordingEndDate = ?, RecordingS" +
				"tartDate = ?, Removal_AirTemp_C = ?, Removal_TimeofDay = ?, Removal_WaterTemp_C " +
				"= ?, RemovalDate = ?, Resolution = ?, SampleInterval_min = ?, TempRange_From = ?" +
				", TempRange_To = ?, WaterDepth_m = ?, WaterLevel_Install = ?, WaterLevel_Removal" +
				" = ?, OutofWaterReadingsOccurred = ?, OutofWaterReadingsRemoved = ? WHERE (Tempe" +
				"ratureLoggerID = ?) AND (Accuracy = ? OR ? IS NULL AND Accuracy IS NULL) AND (Aq" +
				"uaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (BrandName =" +
				" ? OR ? IS NULL AND BrandName IS NULL) AND (DataFileName = ? OR ? IS NULL AND Da" +
				"taFileName IS NULL) AND (DistanceFromLeftBank_m = ? OR ? IS NULL AND DistanceFro" +
				"mLeftBank_m IS NULL) AND (DistanceFromRightBank_m = ? OR ? IS NULL AND DistanceF" +
				"romRightBank_m IS NULL) AND (Install_AirTemp_C = ? OR ? IS NULL AND Install_AirT" +
				"emp_C IS NULL) AND (Install_TimeofDay = ? OR ? IS NULL AND Install_TimeofDay IS " +
				"NULL) AND (Install_WaterTemp_C = ? OR ? IS NULL AND Install_WaterTemp_C IS NULL)" +
				" AND (InstallationDate = ? OR ? IS NULL AND InstallationDate IS NULL) AND (Logge" +
				"rID = ? OR ? IS NULL AND LoggerID IS NULL) AND (Model = ? OR ? IS NULL AND Model" +
				" IS NULL) AND (OutofWaterReadingsOccurred = ?) AND (OutofWaterReadingsRemoved = " +
				"?) AND (RecordingEndDate = ? OR ? IS NULL AND RecordingEndDate IS NULL) AND (Rec" +
				"ordingStartDate = ? OR ? IS NULL AND RecordingStartDate IS NULL) AND (RemovalDat" +
				"e = ? OR ? IS NULL AND RemovalDate IS NULL) AND (Removal_AirTemp_C = ? OR ? IS N" +
				"ULL AND Removal_AirTemp_C IS NULL) AND (Removal_TimeofDay = ? OR ? IS NULL AND R" +
				"emoval_TimeofDay IS NULL) AND (Removal_WaterTemp_C = ? OR ? IS NULL AND Removal_" +
				"WaterTemp_C IS NULL) AND (Resolution = ? OR ? IS NULL AND Resolution IS NULL) AN" +
				"D (SampleInterval_min = ? OR ? IS NULL AND SampleInterval_min IS NULL) AND (Temp" +
				"Range_From = ? OR ? IS NULL AND TempRange_From IS NULL) AND (TempRange_To = ? OR" +
				" ? IS NULL AND TempRange_To IS NULL) AND (WaterDepth_m = ? OR ? IS NULL AND Wate" +
				"rDepth_m IS NULL) AND (WaterLevel_Install = ? OR ? IS NULL AND WaterLevel_Instal" +
				"l IS NULL) AND (WaterLevel_Removal = ? OR ? IS NULL AND WaterLevel_Removal IS NU" +
				"LL)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerID", System.Data.OleDb.OleDbType.VarWChar, 20, "LoggerID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_m"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutofWaterReadingsOccurred", System.Data.OleDb.OleDbType.Boolean, 2, "OutofWaterReadingsOccurred"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutofWaterReadingsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, "OutofWaterReadingsRemoved"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TemperatureLoggerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TemperatureLoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerID", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerID1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutofWaterReadingsOccurred", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutofWaterReadingsOccurred", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutofWaterReadingsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutofWaterReadingsRemoved", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblWaterTemperatureLoggerDetails WHERE (TemperatureLoggerID = ?) AND " +
				"(Accuracy = ? OR ? IS NULL AND Accuracy IS NULL) AND (AquaticActivityID = ? OR ?" +
				" IS NULL AND AquaticActivityID IS NULL) AND (BrandName = ? OR ? IS NULL AND Bran" +
				"dName IS NULL) AND (DataFileName = ? OR ? IS NULL AND DataFileName IS NULL) AND " +
				"(DistanceFromLeftBank_m = ? OR ? IS NULL AND DistanceFromLeftBank_m IS NULL) AND" +
				" (DistanceFromRightBank_m = ? OR ? IS NULL AND DistanceFromRightBank_m IS NULL) " +
				"AND (Install_AirTemp_C = ? OR ? IS NULL AND Install_AirTemp_C IS NULL) AND (Inst" +
				"all_TimeofDay = ? OR ? IS NULL AND Install_TimeofDay IS NULL) AND (Install_Water" +
				"Temp_C = ? OR ? IS NULL AND Install_WaterTemp_C IS NULL) AND (InstallationDate =" +
				" ? OR ? IS NULL AND InstallationDate IS NULL) AND (LoggerID = ? OR ? IS NULL AND" +
				" LoggerID IS NULL) AND (Model = ? OR ? IS NULL AND Model IS NULL) AND (Recording" +
				"EndDate = ? OR ? IS NULL AND RecordingEndDate IS NULL) AND (RecordingStartDate =" +
				" ? OR ? IS NULL AND RecordingStartDate IS NULL) AND (RemovalDate = ? OR ? IS NUL" +
				"L AND RemovalDate IS NULL) AND (Removal_AirTemp_C = ? OR ? IS NULL AND Removal_A" +
				"irTemp_C IS NULL) AND (Removal_TimeofDay = ? OR ? IS NULL AND Removal_TimeofDay " +
				"IS NULL) AND (Removal_WaterTemp_C = ? OR ? IS NULL AND Removal_WaterTemp_C IS NU" +
				"LL) AND (Resolution = ? OR ? IS NULL AND Resolution IS NULL) AND (SampleInterval" +
				"_min = ? OR ? IS NULL AND SampleInterval_min IS NULL) AND (TempRange_From = ? OR" +
				" ? IS NULL AND TempRange_From IS NULL) AND (TempRange_To = ? OR ? IS NULL AND Te" +
				"mpRange_To IS NULL) AND (WaterDepth_m = ? OR ? IS NULL AND WaterDepth_m IS NULL)" +
				" AND (WaterLevel_Install = ? OR ? IS NULL AND WaterLevel_Install IS NULL) AND (W" +
				"aterLevel_Removal = ? OR ? IS NULL AND WaterLevel_Removal IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TemperatureLoggerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TemperatureLoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerID", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerID1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = @"INSERT INTO tblWaterTemperatureLoggerDetails(Accuracy, AquaticActivityID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerID, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TempRange_From, TempRange_To, WaterDepth_m, WaterLevel_Install, WaterLevel_Removal) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
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
			this.oleDbSelectCommand2.CommandText = @"SELECT Accuracy, AquaticActivityID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, LoggerID, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TemperatureLoggerID, TempRange_From, TempRange_To, WaterDepth_m, WaterLevel_Install, WaterLevel_Removal FROM tblWaterTemperatureLoggerDetails";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblWaterTemperatureLoggerDetails SET Accuracy = ?, AquaticActivityID = ?, " +
				"BrandName = ?, DataFileName = ?, DistanceFromLeftBank_m = ?, DistanceFromRightBa" +
				"nk_m = ?, Install_AirTemp_C = ?, Install_TimeofDay = ?, Install_WaterTemp_C = ?," +
				" InstallationDate = ?, LoggerID = ?, Model = ?, RecordingEndDate = ?, RecordingS" +
				"tartDate = ?, Removal_AirTemp_C = ?, Removal_TimeofDay = ?, Removal_WaterTemp_C " +
				"= ?, RemovalDate = ?, Resolution = ?, SampleInterval_min = ?, TempRange_From = ?" +
				", TempRange_To = ?, WaterDepth_m = ?, WaterLevel_Install = ?, WaterLevel_Removal" +
				" = ? WHERE (TemperatureLoggerID = ?) AND (Accuracy = ? OR ? IS NULL AND Accuracy" +
				" IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL)" +
				" AND (BrandName = ? OR ? IS NULL AND BrandName IS NULL) AND (DataFileName = ? OR" +
				" ? IS NULL AND DataFileName IS NULL) AND (DistanceFromLeftBank_m = ? OR ? IS NUL" +
				"L AND DistanceFromLeftBank_m IS NULL) AND (DistanceFromRightBank_m = ? OR ? IS N" +
				"ULL AND DistanceFromRightBank_m IS NULL) AND (Install_AirTemp_C = ? OR ? IS NULL" +
				" AND Install_AirTemp_C IS NULL) AND (Install_TimeofDay = ? OR ? IS NULL AND Inst" +
				"all_TimeofDay IS NULL) AND (Install_WaterTemp_C = ? OR ? IS NULL AND Install_Wat" +
				"erTemp_C IS NULL) AND (InstallationDate = ? OR ? IS NULL AND InstallationDate IS" +
				" NULL) AND (LoggerID = ? OR ? IS NULL AND LoggerID IS NULL) AND (Model = ? OR ? " +
				"IS NULL AND Model IS NULL) AND (RecordingEndDate = ? OR ? IS NULL AND RecordingE" +
				"ndDate IS NULL) AND (RecordingStartDate = ? OR ? IS NULL AND RecordingStartDate " +
				"IS NULL) AND (RemovalDate = ? OR ? IS NULL AND RemovalDate IS NULL) AND (Removal" +
				"_AirTemp_C = ? OR ? IS NULL AND Removal_AirTemp_C IS NULL) AND (Removal_TimeofDa" +
				"y = ? OR ? IS NULL AND Removal_TimeofDay IS NULL) AND (Removal_WaterTemp_C = ? O" +
				"R ? IS NULL AND Removal_WaterTemp_C IS NULL) AND (Resolution = ? OR ? IS NULL AN" +
				"D Resolution IS NULL) AND (SampleInterval_min = ? OR ? IS NULL AND SampleInterva" +
				"l_min IS NULL) AND (TempRange_From = ? OR ? IS NULL AND TempRange_From IS NULL) " +
				"AND (TempRange_To = ? OR ? IS NULL AND TempRange_To IS NULL) AND (WaterDepth_m =" +
				" ? OR ? IS NULL AND WaterDepth_m IS NULL) AND (WaterLevel_Install = ? OR ? IS NU" +
				"LL AND WaterLevel_Install IS NULL) AND (WaterLevel_Removal = ? OR ? IS NULL AND " +
				"WaterLevel_Removal IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerID", System.Data.OleDb.OleDbType.VarWChar, 10, "LoggerID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_m"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TemperatureLoggerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TemperatureLoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerID", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerID1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblWaterTemperatureLoggerDetails
			// 
			this.objdstblWaterTemperatureLoggerDetails.DataSetName = "dstblWaterTemperatureLoggerDetails";
			this.objdstblWaterTemperatureLoggerDetails.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdatblAquaticActivity
			// 
			this.oleDbdatblAquaticActivity.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbdatblAquaticActivity.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdatblAquaticActivity.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdatblAquaticActivity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "tblAquaticActivity", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityStartDate", "AquaticActivityStartDate"),
																																																									  new System.Data.Common.DataColumnMapping("Crew", "Crew"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																									  new System.Data.Common.DataColumnMapping("IncorporatedInd", "IncorporatedInd"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																									  new System.Data.Common.DataColumnMapping("DateEntered", "DateEntered"),
																																																									  new System.Data.Common.DataColumnMapping("Agency2Cd", "Agency2Cd"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityEndDate", "AquaticActivityEndDate"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityEndTime", "AquaticActivityEndTime"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticActivityStartTime", "AquaticActivityStartTime"),
																																																									  new System.Data.Common.DataColumnMapping("AquaticMethodCd", "AquaticMethodCd")})});
			this.oleDbdatblAquaticActivity.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM tblAquaticActivity WHERE (AquaticActivityID = ?) AND (Agency2Cd = ? OR ? IS NULL AND Agency2Cd IS NULL) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticActivityEndDate = ? OR ? IS NULL AND AquaticActivityEndDate IS NULL) AND (AquaticActivityEndTime = ? OR ? IS NULL AND AquaticActivityEndTime IS NULL) AND (AquaticActivityStartDate = ? OR ? IS NULL AND AquaticActivityStartDate IS NULL) AND (AquaticActivityStartTime = ? OR ? IS NULL AND AquaticActivityStartTime IS NULL) AND (AquaticMethodCd = ? OR ? IS NULL AND AquaticMethodCd IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (Crew = ? OR ? IS NULL AND Crew IS NULL) AND (DateEntered = ?) AND (IncorporatedInd = ?)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = @"INSERT INTO tblAquaticActivity(AgencyCd, AquaticActivityStartDate, Crew, AquaticActivityID, AquaticSiteID, IncorporatedInd, AquaticActivityCd, DateEntered, Agency2Cd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityStartTime, AquaticMethodCd) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityEndDate"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityEndTime"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT AgencyCd, AquaticActivityStartDate, Crew, AquaticActivityID, AquaticSiteID, IncorporatedInd, AquaticActivityCd, DateEntered, Agency2Cd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityStartTime, AquaticMethodCd FROM tblAquaticActivity";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE tblAquaticActivity SET AgencyCd = ?, AquaticActivityStartDate = ?, Crew = ?, AquaticActivityID = ?, AquaticSiteID = ?, IncorporatedInd = ?, AquaticActivityCd = ?, DateEntered = ?, Agency2Cd = ?, AquaticActivityEndDate = ?, AquaticActivityEndTime = ?, AquaticActivityStartTime = ?, AquaticMethodCd = ? WHERE (AquaticActivityID = ?) AND (Agency2Cd = ? OR ? IS NULL AND Agency2Cd IS NULL) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticActivityEndDate = ? OR ? IS NULL AND AquaticActivityEndDate IS NULL) AND (AquaticActivityEndTime = ? OR ? IS NULL AND AquaticActivityEndTime IS NULL) AND (AquaticActivityStartDate = ? OR ? IS NULL AND AquaticActivityStartDate IS NULL) AND (AquaticActivityStartTime = ? OR ? IS NULL AND AquaticActivityStartTime IS NULL) AND (AquaticMethodCd = ? OR ? IS NULL AND AquaticMethodCd IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (Crew = ? OR ? IS NULL AND Crew IS NULL) AND (DateEntered = ?) AND (IncorporatedInd = ?)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityEndDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityEndTime"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblAquaticActivity
			// 
			this.objdstblAquaticActivity.DataSetName = "dstblAquaticActivity";
			this.objdstblAquaticActivity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdacdAgency
			// 
			this.oleDbdacdAgency.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbdacdAgency.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdacdAgency.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdacdAgency.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cdAgency", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("Agency", "Agency"),
																																																				  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																				  new System.Data.Common.DataColumnMapping("DataRulesInd", "DataRulesInd")})});
			this.oleDbdacdAgency.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM cdAgency WHERE (AgencyCd = ?) AND (Agency = ? OR ? IS NULL AND Agency" +
				" IS NULL) AND (DataRulesInd = ? OR ? IS NULL AND DataRulesInd IS NULL)";
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataRulesInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataRulesInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataRulesInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataRulesInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO cdAgency(Agency, AgencyCd, DataRulesInd) VALUES (?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataRulesInd", System.Data.OleDb.OleDbType.VarWChar, 1, "DataRulesInd"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT Agency, AgencyCd, DataRulesInd FROM cdAgency";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE cdAgency SET Agency = ?, AgencyCd = ?, DataRulesInd = ? WHERE (AgencyCd = " +
				"?) AND (Agency = ? OR ? IS NULL AND Agency IS NULL) AND (DataRulesInd = ? OR ? I" +
				"S NULL AND DataRulesInd IS NULL)";
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataRulesInd", System.Data.OleDb.OleDbType.VarWChar, 1, "DataRulesInd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataRulesInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataRulesInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataRulesInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataRulesInd", System.Data.DataRowVersion.Original, null));
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
			// 
			// oleDbSelectCommand7
			// 
			this.oleDbSelectCommand7.CommandText = @"SELECT Accuracy, AquaticActivityID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TemperatureLoggerID, TempRange_From, TempRange_To, WaterLevel_Install, WaterLevel_Removal, OutofWaterReadingsOccurred, OutofWaterReadingsRemoved, LoggerNo, WaterDepth_cm FROM tblWaterTemperatureLoggerDetails";
			this.oleDbSelectCommand7.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand7
			// 
			this.oleDbInsertCommand7.CommandText = @"INSERT INTO tblWaterTemperatureLoggerDetails(Accuracy, AquaticActivityID, BrandName, DataFileName, DistanceFromLeftBank_m, DistanceFromRightBank_m, Install_AirTemp_C, Install_TimeofDay, Install_WaterTemp_C, InstallationDate, Model, RecordingEndDate, RecordingStartDate, Removal_AirTemp_C, Removal_TimeofDay, Removal_WaterTemp_C, RemovalDate, Resolution, SampleInterval_min, TempRange_From, TempRange_To, WaterLevel_Install, WaterLevel_Removal, OutofWaterReadingsOccurred, OutofWaterReadingsRemoved, LoggerNo, WaterDepth_cm) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand7.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutofWaterReadingsOccurred", System.Data.OleDb.OleDbType.Boolean, 2, "OutofWaterReadingsOccurred"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutofWaterReadingsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, "OutofWaterReadingsRemoved"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerNo", System.Data.OleDb.OleDbType.VarWChar, 20, "LoggerNo"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_cm", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_cm"));
			// 
			// oleDbUpdateCommand5
			// 
			this.oleDbUpdateCommand5.CommandText = "UPDATE tblWaterTemperatureLoggerDetails SET Accuracy = ?, AquaticActivityID = ?, " +
				"BrandName = ?, DataFileName = ?, DistanceFromLeftBank_m = ?, DistanceFromRightBa" +
				"nk_m = ?, Install_AirTemp_C = ?, Install_TimeofDay = ?, Install_WaterTemp_C = ?," +
				" InstallationDate = ?, Model = ?, RecordingEndDate = ?, RecordingStartDate = ?, " +
				"Removal_AirTemp_C = ?, Removal_TimeofDay = ?, Removal_WaterTemp_C = ?, RemovalDa" +
				"te = ?, Resolution = ?, SampleInterval_min = ?, TempRange_From = ?, TempRange_To" +
				" = ?, WaterLevel_Install = ?, WaterLevel_Removal = ?, OutofWaterReadingsOccurred" +
				" = ?, OutofWaterReadingsRemoved = ?, LoggerNo = ?, WaterDepth_cm = ? WHERE (Temp" +
				"eratureLoggerID = ?) AND (Accuracy = ? OR ? IS NULL AND Accuracy IS NULL) AND (A" +
				"quaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (BrandName " +
				"= ? OR ? IS NULL AND BrandName IS NULL) AND (DataFileName = ? OR ? IS NULL AND D" +
				"ataFileName IS NULL) AND (DistanceFromLeftBank_m = ? OR ? IS NULL AND DistanceFr" +
				"omLeftBank_m IS NULL) AND (DistanceFromRightBank_m = ? OR ? IS NULL AND Distance" +
				"FromRightBank_m IS NULL) AND (Install_AirTemp_C = ? OR ? IS NULL AND Install_Air" +
				"Temp_C IS NULL) AND (Install_TimeofDay = ? OR ? IS NULL AND Install_TimeofDay IS" +
				" NULL) AND (Install_WaterTemp_C = ? OR ? IS NULL AND Install_WaterTemp_C IS NULL" +
				") AND (InstallationDate = ? OR ? IS NULL AND InstallationDate IS NULL) AND (Logg" +
				"erNo = ? OR ? IS NULL AND LoggerNo IS NULL) AND (Model = ? OR ? IS NULL AND Mode" +
				"l IS NULL) AND (OutofWaterReadingsOccurred = ?) AND (OutofWaterReadingsRemoved =" +
				" ?) AND (RecordingEndDate = ? OR ? IS NULL AND RecordingEndDate IS NULL) AND (Re" +
				"cordingStartDate = ? OR ? IS NULL AND RecordingStartDate IS NULL) AND (RemovalDa" +
				"te = ? OR ? IS NULL AND RemovalDate IS NULL) AND (Removal_AirTemp_C = ? OR ? IS " +
				"NULL AND Removal_AirTemp_C IS NULL) AND (Removal_TimeofDay = ? OR ? IS NULL AND " +
				"Removal_TimeofDay IS NULL) AND (Removal_WaterTemp_C = ? OR ? IS NULL AND Removal" +
				"_WaterTemp_C IS NULL) AND (Resolution = ? OR ? IS NULL AND Resolution IS NULL) A" +
				"ND (SampleInterval_min = ? OR ? IS NULL AND SampleInterval_min IS NULL) AND (Tem" +
				"pRange_From = ? OR ? IS NULL AND TempRange_From IS NULL) AND (TempRange_To = ? O" +
				"R ? IS NULL AND TempRange_To IS NULL) AND (WaterDepth_cm = ? OR ? IS NULL AND Wa" +
				"terDepth_cm IS NULL) AND (WaterLevel_Install = ? OR ? IS NULL AND WaterLevel_Ins" +
				"tall IS NULL) AND (WaterLevel_Removal = ? OR ? IS NULL AND WaterLevel_Removal IS" +
				" NULL)";
			this.oleDbUpdateCommand5.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, "Accuracy"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, "BrandName"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, "DataFileName"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromLeftBank_m"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, "DistanceFromRightBank_m"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_AirTemp_C"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Install_TimeofDay"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Install_WaterTemp_C"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, "InstallationDate"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Model", System.Data.OleDb.OleDbType.VarWChar, 20, "Model"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingEndDate"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RecordingStartDate"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_AirTemp_C"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, "Removal_TimeofDay"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "Removal_WaterTemp_C"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, "RemovalDate"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, "Resolution"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, "SampleInterval_min"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_From"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, "TempRange_To"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Install"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, "WaterLevel_Removal"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutofWaterReadingsOccurred", System.Data.OleDb.OleDbType.Boolean, 2, "OutofWaterReadingsOccurred"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutofWaterReadingsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, "OutofWaterReadingsRemoved"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("LoggerNo", System.Data.OleDb.OleDbType.VarWChar, 20, "LoggerNo"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterDepth_cm", System.Data.OleDb.OleDbType.Integer, 0, "WaterDepth_cm"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TemperatureLoggerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TemperatureLoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerNo", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerNo1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutofWaterReadingsOccurred", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutofWaterReadingsOccurred", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutofWaterReadingsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutofWaterReadingsRemoved", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_cm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_cm1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand5
			// 
			this.oleDbDeleteCommand5.CommandText = "DELETE FROM tblWaterTemperatureLoggerDetails WHERE (TemperatureLoggerID = ?) AND " +
				"(Accuracy = ? OR ? IS NULL AND Accuracy IS NULL) AND (AquaticActivityID = ? OR ?" +
				" IS NULL AND AquaticActivityID IS NULL) AND (BrandName = ? OR ? IS NULL AND Bran" +
				"dName IS NULL) AND (DataFileName = ? OR ? IS NULL AND DataFileName IS NULL) AND " +
				"(DistanceFromLeftBank_m = ? OR ? IS NULL AND DistanceFromLeftBank_m IS NULL) AND" +
				" (DistanceFromRightBank_m = ? OR ? IS NULL AND DistanceFromRightBank_m IS NULL) " +
				"AND (Install_AirTemp_C = ? OR ? IS NULL AND Install_AirTemp_C IS NULL) AND (Inst" +
				"all_TimeofDay = ? OR ? IS NULL AND Install_TimeofDay IS NULL) AND (Install_Water" +
				"Temp_C = ? OR ? IS NULL AND Install_WaterTemp_C IS NULL) AND (InstallationDate =" +
				" ? OR ? IS NULL AND InstallationDate IS NULL) AND (LoggerNo = ? OR ? IS NULL AND" +
				" LoggerNo IS NULL) AND (Model = ? OR ? IS NULL AND Model IS NULL) AND (OutofWate" +
				"rReadingsOccurred = ?) AND (OutofWaterReadingsRemoved = ?) AND (RecordingEndDate" +
				" = ? OR ? IS NULL AND RecordingEndDate IS NULL) AND (RecordingStartDate = ? OR ?" +
				" IS NULL AND RecordingStartDate IS NULL) AND (RemovalDate = ? OR ? IS NULL AND R" +
				"emovalDate IS NULL) AND (Removal_AirTemp_C = ? OR ? IS NULL AND Removal_AirTemp_" +
				"C IS NULL) AND (Removal_TimeofDay = ? OR ? IS NULL AND Removal_TimeofDay IS NULL" +
				") AND (Removal_WaterTemp_C = ? OR ? IS NULL AND Removal_WaterTemp_C IS NULL) AND" +
				" (Resolution = ? OR ? IS NULL AND Resolution IS NULL) AND (SampleInterval_min = " +
				"? OR ? IS NULL AND SampleInterval_min IS NULL) AND (TempRange_From = ? OR ? IS N" +
				"ULL AND TempRange_From IS NULL) AND (TempRange_To = ? OR ? IS NULL AND TempRange" +
				"_To IS NULL) AND (WaterDepth_cm = ? OR ? IS NULL AND WaterDepth_cm IS NULL) AND " +
				"(WaterLevel_Install = ? OR ? IS NULL AND WaterLevel_Install IS NULL) AND (WaterL" +
				"evel_Removal = ? OR ? IS NULL AND WaterLevel_Removal IS NULL)";
			this.oleDbDeleteCommand5.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TemperatureLoggerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TemperatureLoggerID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Accuracy1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Accuracy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BrandName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BrandName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DataFileName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DataFileName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromLeftBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromLeftBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DistanceFromRightBank_m1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromRightBank_m", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Install_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Install_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InstallationDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallationDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerNo", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LoggerNo1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LoggerNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Model1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Model", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutofWaterReadingsOccurred", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutofWaterReadingsOccurred", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutofWaterReadingsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutofWaterReadingsRemoved", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RecordingStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RecordingStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RemovalDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RemovalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_TimeofDay1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_TimeofDay", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Removal_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Removal_WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Resolution1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Resolution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SampleInterval_min1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SampleInterval_min", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_From1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_From", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TempRange_To1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TempRange_To", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_cm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterDepth_cm1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterDepth_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Install1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Install", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_Removal1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_Removal", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblWaterTemperatureLoggerDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAgency)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdAgency)).EndInit();

		}
		#endregion		
		
	}
}
