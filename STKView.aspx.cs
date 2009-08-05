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
	/// Summary description for STKView.
	/// </summary>
	/// 
	
	public partial class STKView : System.Web.UI.Page
	{
		#region Controls
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SiteInfo;
		protected NBADWDataEntryApplication.dsDE_SiteInfo objdsDE_SiteInfo;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblStockedFish;
		protected NBADWDataEntryApplication.dstblStockedFish objdstblStockedFish;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdFishSpecies;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected NBADWDataEntryApplication.dscdFishSpecies objdscdFishSpecies;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_Hatcheries;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected NBADWDataEntryApplication.dsDE_Hatcheries objdsDE_Hatcheries;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdFishAgeClass;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		          public NBADWDataEntryApplication.dscdFishAgeClass objdscdFishAgeClass;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdFishMark;
		protected NBADWDataEntryApplication.dscdFishMark objdscdFishMark;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		protected System.Data.DataView dvcdFishSpecies;
		protected System.Data.DataView dvDE_Hatcheries;
		protected System.Data.DataView dvcdFishMark;
		protected System.Data.DataView dvcdFishAgeClass;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_FishStock;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand7;
		protected NBADWDataEntryApplication.dsDE_FishStock objdsDE_FishStock;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticActivity;
		protected NBADWDataEntryApplication.dstblAquaticActivity objdstblAquaticActivity;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand8;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand8;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand9;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand9;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand10;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand10;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand7;
		protected System.Data.OleDb.OleDbConnection oleDbConnection2;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand11;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand11;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand8;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand8;
		protected System.Data.DataView dvDE_FishStock;
		#endregion
        	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				SetSiteFields();
				SetPageMode();
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
		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("STKList.aspx");
		}

		protected void btnModify_Click(object sender, System.EventArgs e)
		{	
			Session["Mode"] = "Modify";
			SetPageMode();		
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string sql1 = "DELETE FROM tblAquaticActivity WHERE AquaticActivityID = "+txtAquaticActivityID.Text;
			string sql2 = "DELETE FROM tblStockedFish WHERE FishStockingID = "+Session["CurrentActivityID"].ToString();
			oleDbConnection1.Open();
			OleDbCommand cmd1 = new OleDbCommand(sql1, oleDbConnection1);
			OleDbCommand cmd2 = new OleDbCommand(sql2, oleDbConnection1);
			try
			{
				cmd2.ExecuteNonQuery();
				cmd1.ExecuteNonQuery();
				oleDbConnection1.Close();
				Server.Transfer("STKList.aspx");
			}
			catch (System.Data.OleDb.OleDbException er)
			{
				Debug.WriteLine("Error: "+er.ToString());
				oleDbConnection1.Close();
			}		
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string strValues = "";
			string strFields = "";

			switch(Session["Mode"].ToString())
			{
				#region Add
				case "Add":
				{
					LoadtblAquaticActivity();
					DataTable tActivity = objdstblAquaticActivity.tblAquaticActivity;
					DataRow rActivity = tActivity.NewRow();

					int i = FindBiggest(tActivity,"AquaticActivityID");
					rActivity["AquaticActivityID"] = i+1;
					Session["CurrentActivityID"] = rActivity["AquaticActivityID"];
					rActivity["AquaticActivityCd"] = 5;
					rActivity["AquaticSiteID"] = txtdwsiteid.Text;
					rActivity["AquaticActivityStartDate"] = txtDate2.Text;
					rActivity["AgencyCd"] = txtagencycd.Text;
					if(txtWaterTemperature2.Text!="")
					{
						rActivity["WaterTemp_C"] = txtWaterTemperature2.Text;
					}
					if(txtAirTemperature2.Text!="")
					{
						rActivity["AirTemp_C"] = txtAirTemperature2.Text;
					}
					if(txtTimeofDay2.Text!="")
					{
						rActivity["AquaticActivityStartTime"] = txtTimeofDay2.Text;
					}
					if(txtWaterLevel2.Text!="")
					{
						rActivity["WaterLevel_cm"] = txtWaterLevel2.Text;
					}
					//zero length comments are allowed
					rActivity["Comments"] = txtComments2.Text;
					rActivity["DateEntered"]=System.DateTime.Now.ToShortDateString();
					rActivity["IncorporatedInd"] = false;

					tActivity.Rows.Add(rActivity);

					strFields = "AquaticActivityID";
					strValues = Session["CurrentActivityID"].ToString();

					strFields += ", SatelliteRearedInd";
					strValues += ", "+chkSatelliteReared2.Checked;

					if(dlstHatchery2.SelectedValue!="Other")
					{
						strFields += ", FishFacilityID";
						strValues += ", "+dlstHatchery2.SelectedValue;
					}

					strFields += ", OtherFishFacility";
					strValues += ", '"+txtOtherHatchery2.Text+"'";

					strFields += ", FishSpeciesCd";
					strValues += ", '"+dlstSpecies2.SelectedValue+ "'";

					if(dlstStock2.SelectedValue!="Other")
					{
						strFields += ", FishStockID";
						strValues += ", "+dlstStock2.SelectedValue;
					}

					strFields += ", OtherStock";
					strValues += ", '"+txtOtherStock2.Text+"'";

					strFields += ", FishAgeClass";
					strValues += ", '"+dlstAgeClass2.SelectedValue+"'";

					if(dlstAgeClass2.SelectedItem.ToString()=="Adult")
					{
						if(txtAge2.Text!="")
						{
							strFields += ", FishAge";
							strValues += ", '"+txtAge2.Text+"'";

							strFields += ", AgeUnitOfMeasure";
							strValues += ", '"+dlstAgeUnits2.SelectedValue+"'";
						}
						
						strFields += ", BroodstockInd";
						strValues += ", "+chkBroodstock2.Checked;
					}

					strFields += ", NoFish";
					if(txtNumberofFish2.Text!="")
					{
						strValues += ", "+txtNumberofFish2.Text;
					}
					else
					{
						strValues += ", Null";
					}

					strFields += ", AveLength_cm";
					if(txtAverageLength2.Text!="")
					{
						strValues += ", "+txtAverageLength2.Text;
					}
					else
					{
						strValues += ", Null";
					}

					strFields += ", AveWeight_gm";
					if(txtAverageWeight2.Text!="")
					{
						strValues += ", "+txtAverageWeight2.Text;
					}
					else
					{
						strValues += ", Null";
					}

					strFields += ", NoFishMeasured";
					if(txtNumberofFishMeasured2.Text!="")
					{
						strValues += ", "+txtNumberofFishMeasured2.Text;
					}
					else
					{
						strValues += ", Null";
					}

					if(dlstMarkApplied2.SelectedValue!="")
					{
						strFields += ", AppliedMarkCd";
						strValues += ", "+dlstMarkApplied2.SelectedValue;                   
					}

					try
					{
						oleDbdatblAquaticActivity.Update(objdstblAquaticActivity);
						Debug.WriteLine("Activity Created");
						string sql = "INSERT INTO tblStockedFish ("+strFields+") VALUES ("+strValues+")";
						Debug.WriteLine("SQL string: "+sql);
						oleDbConnection1.Open();
						OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
						cmd.ExecuteNonQuery();
						Debug.WriteLine("stocking Created");
						oleDbConnection1.Close();
						Server.Transfer("STKList.aspx"); 
					}
					catch(System.Data.OleDb.OleDbException ex)
					{
						oleDbConnection1.Close();
						Debug.WriteLine("Error during add: "+ex.ToString());
					}
					break;
				}
				#endregion

				#region Modify
				case "Modify":
				{
					//tblAquaticActivity
					strValues = "AquaticActivityID = "+txtAquaticActivityID.Text;
					strValues += ", AquaticActivityStartDate = '"+txtDate2.Text+"'";
					
					if(txtWaterTemperature2.Text!="")
					{
						strValues += ", WaterTemp_C = "+ txtWaterTemperature2.Text;
					}
					else
					{
						strValues += ", WaterTemp_C = Null";
					}

					if(txtAirTemperature2.Text!="")
					{
						strValues +=", AirTemp_C = "+txtAirTemperature2.Text;
					}
					else
					{
						strValues +=", AirTemp_C = Null";
					}

					if(txtTimeofDay2.Text!="")
					{
						strValues +=", AquaticActivityStartTime = '"+txtTimeofDay2.Text+"'";
					}
					else
					{
						strValues +=", AquaticActivityStartTime = Null";
					}

					if(txtWaterLevel2.Text!="")
					{
						strValues +=", WaterLevel_cm ='"+ txtWaterLevel2.Text+"'";
					}
					else
					{
						strValues +=", WaterLevel_cm = Null";
					}

					if(txtComments2.Text!="")
					{
						strValues +=", Comments = '"+ txtComments2.Text+"'";
					}
					else
					{
						strValues +=", Comments = Null";
					}

					//tblStockedFish
					strFields += "SatelliteRearedInd = "+chkSatelliteReared2.Checked;
					strFields += ", FishFacilityID = "+dlstHatchery2.SelectedValue;
					strFields += ", OtherFishFacility = '"+txtOtherHatchery2.Text+"'";
					strFields += ", FishSpeciesCd = '"+dlstSpecies2.SelectedValue+ "'";
					
					if(dlstStock2.SelectedItem.ToString()!="Unknown" & dlstStock2.SelectedItem.ToString()!="Other")
					{
						strFields += ", FishStockID = "+dlstStock2.SelectedValue;;
					}
					else
					{
						strFields += ", FishStockID = Null";
					}
					
					strFields += ", OtherStock = '"+txtOtherStock2.Text+"'";
					strFields += ", FishAgeClass = '"+dlstAgeClass2.SelectedValue+"'";
					
					if(dlstAgeClass2.SelectedItem.ToString()=="Adult")
					{
						if(txtAge2.Text!="")
						{
							strFields += ", FishAge = '"+txtAge2.Text+"'";
							strFields += ", AgeUnitOfMeasure = '"+dlstAgeUnits2.SelectedValue+"'";
						}
						
						strFields += ", BroodstockInd = "+chkBroodstock2.Checked;
					}
					else//clear what may have been there
					{
						strFields += ", FishAge = Null";
						strFields += ", AgeUnitOfMeasure = Null";
						//strFields += ", BroodstockInd = Null";
					}
					
					if(txtNumberofFish2.Text!="")
					{
						strFields += ", NoFish = "+txtNumberofFish2.Text;
					}
					else
					{
						strFields += ", NoFish = Null";
					}

					if(txtAverageLength2.Text!="")
					{
						strFields += ", AveLength_cm = "+txtAverageLength2.Text;
					}
					else
					{
						strFields += ", AveLength_cm = Null";
					}

					if(txtAverageWeight2.Text!="")
					{
						strFields += ", AveWeight_gm = "+txtAverageWeight2.Text;
					}
					else
					{
						strFields += ", AveWeight_gm = Null";
					}

					if(txtNumberofFishMeasured2.Text!="")
					{
						strFields += ", NoFishMeasured = "+txtNumberofFishMeasured2.Text;
					}
					else
					{
						strFields += ", NoFishMeasured = Null";
					}

					if(dlstMarkApplied2.SelectedItem.ToString()!="")
					{
						strFields += ", AppliedMarkCd = "+dlstMarkApplied2.SelectedValue;                   
					}
					else
					{
						strFields += ", AppliedMarkCd = Null";
					}

					try
					{
						string sql1 = "UPDATE tblAquaticActivity SET "+strValues+" WHERE AquaticActivityID = " +txtAquaticActivityID.Text;
						string sql2 = "UPDATE tblStockedFish SET "+strFields+" WHERE FishStockingID = "+Session["CurrentActivityID"].ToString();
						Debug.WriteLine("SQL1 string: "+sql1);
						Debug.WriteLine("SQL2 string: "+sql2);
						
						oleDbConnection1.Open();
						OleDbCommand cmd1 = new OleDbCommand(sql1, oleDbConnection1);
						OleDbCommand cmd2 = new OleDbCommand(sql2, oleDbConnection1);
						cmd1.ExecuteNonQuery();
						cmd2.ExecuteNonQuery();
						Debug.WriteLine("Updates Complete");
						oleDbConnection1.Close();
						Server.Transfer("STKList.aspx"); 
					}
					catch(System.Data.OleDb.OleDbException ex)
					{
						oleDbConnection1.Close();
						Debug.WriteLine("Error during modify: "+ex.ToString());
					}
					break;
				}
				#endregion

				#region ModifySite
				case "ModifySite":
				{
					try
					{
						string sql = "UPDATE tblAquaticActivity SET AquaticSiteID = "+this.txtdwsiteid.Text+" WHERE AquaticActivityID = " +txtAquaticActivityID.Text;
						oleDbConnection1.Open();
						OleDbCommand cmd1 = new OleDbCommand(sql, oleDbConnection1);
						cmd1.ExecuteNonQuery();
						Debug.WriteLine("Updates Complete");
						oleDbConnection1.Close();
						Server.Transfer("STKList.aspx"); 	
					}
					catch(System.Data.OleDb.OleDbException ex)
					{
						oleDbConnection1.Close();
						Debug.WriteLine("Error during modify: "+ex.ToString());
					}
					break;
				}
				#endregion
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			switch (Session["Mode"].ToString())
			{
				case "ModifySite":
				{
					Session["SelectedSiteUseID"] = Session["OldSelectedSiteUseID"].ToString();
					Session["OldSelectedSiteUseID"] = null;
					SetSiteFields();
					goto case "Modify";
				}
				case "Modify":
				{
					Session["Mode"] = "View";
					
					lblh2.Text = "VIEW Stocking";
					ShowDisabledFields();
					HideEnabledFields();
					HideInstructions();

					//buttons
					btnChangeSite.Visible = false;
					btnModify.Visible = true;		
					btnDelete.Visible = true;		
					btnReturn.Visible = true;
					btnSave.Visible = false;
					btnCancel.Visible = false;

					break;
				}
				case "Add":
				{
					Server.Transfer("STKList.aspx");
					break;
				}				
			}
		}

		protected void btnChangeSite_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "STKView.aspx";
			Session["Mode"] = "ModifySite";
			Server.Transfer("SelectSite.aspx");
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

		public void FillCodeDataSets(NBADWDataEntryApplication.dsDE_Hatcheries dataSet1, NBADWDataEntryApplication.dscdFishSpecies dataSet2, /*NBADWDataEntryApplication.dsDE_FishStock dataSet3, */NBADWDataEntryApplication.dscdFishAgeClass dataSet4, NBADWDataEntryApplication.dscdFishMark dataSet5)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			try
			{
				dataSet1.EnforceConstraints = false;
				dataSet2.EnforceConstraints = false;
				//dataSet3.EnforceConstraints = false;
				dataSet4.EnforceConstraints = false;
				dataSet5.EnforceConstraints = false;
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
		
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();

				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdaDE_Hatcheries.Fill(dataSet1);
				this.oleDbdacdFishSpecies.Fill(dataSet2);
				//this.oleDbdaDE_FishStock.Fill(dataSet3);
				this.oleDbdacdFishAgeClass.Fill(dataSet4);
				this.oleDbdacdFishMark.Fill(dataSet5);
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
				//dataSet3.EnforceConstraints = true;
				dataSet4.EnforceConstraints = true;
				dataSet5.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}		
		}

		public void LoadCodeDataSets()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_Hatcheries objDataSetTemp1;
			NBADWDataEntryApplication.dscdFishSpecies objDataSetTemp2;
			//NBADWDataEntryApplication.dsDE_FishStock objDataSetTemp3;
			NBADWDataEntryApplication.dscdFishAgeClass objDataSetTemp4;
			NBADWDataEntryApplication.dscdFishMark objDataSetTemp5;

			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_Hatcheries();
			objDataSetTemp2 = new NBADWDataEntryApplication.dscdFishSpecies();
			//objDataSetTemp3 = new NBADWDataEntryApplication.dsDE_FishStock();
			objDataSetTemp4 = new NBADWDataEntryApplication.dscdFishAgeClass();
			objDataSetTemp5 = new NBADWDataEntryApplication.dscdFishMark();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillCodeDataSets(objDataSetTemp1, objDataSetTemp2, /*objDataSetTemp3, */objDataSetTemp4, objDataSetTemp5);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsDE_Hatcheries.Clear();
				this.objdscdFishSpecies.Clear();
				//this.objdsDE_FishStock.Clear();
				this.objdscdFishAgeClass.Clear();
				this.objdscdFishMark.Clear();
				
				// Merge the records into the main dataset.
				this.objdsDE_Hatcheries.Merge(objDataSetTemp1);
				this.objdscdFishSpecies.Merge(objDataSetTemp2);
				//this.objdsDE_FishStock.Merge(objDataSetTemp3);
				this.objdscdFishAgeClass.Merge(objDataSetTemp4);
				this.objdscdFishMark.Merge(objDataSetTemp5);				
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillFishStock(NBADWDataEntryApplication.dsDE_FishStock dataSet3)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet3.EnforceConstraints = false;
						
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();

				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdaDE_FishStock.Fill(dataSet3);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet3.EnforceConstraints = true;
				
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}

		}

		public void LoadFishStock()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_FishStock objDataSetTemp3;
			objDataSetTemp3 = new NBADWDataEntryApplication.dsDE_FishStock();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillFishStock(objDataSetTemp3);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdsDE_FishStock.Clear();
								
				// Merge the records into the main dataset.
				this.objdsDE_FishStock.Merge(objDataSetTemp3);			
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

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
				this.objdstblAquaticActivity.Clear();
								
				// Merge the records into the main dataset.
				this.objdstblAquaticActivity.Merge(objDataSetTemp);			
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FilltblStockedFish(NBADWDataEntryApplication.dstblStockedFish dataSet)
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
				this.oleDbdatblStockedFish.Fill(dataSet);
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

		public void LoadtblStockedFish()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblStockedFish objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dstblStockedFish();
			
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FilltblStockedFish(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				this.objdstblStockedFish.Clear();
								
				// Merge the records into the main dataset.
				this.objdstblStockedFish.Merge(objDataSetTemp);			
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		#endregion

		#region Index Changed
		protected void dlstSpecies2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadFishStock();
			dvDE_FishStock.RowFilter = "FishSpeciesCd = '"+dlstSpecies2.SelectedValue.ToString()+"'";
			dlstStock2.DataBind();
			dlstStock2.Items.Add(new ListItem("Unknown", "0" ));
			dlstStock2.SelectedIndex = dlstStock2.Items.Count-1;
		}

		protected void dlstAgeClass2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(dlstAgeClass2.SelectedItem.ToString() == "Adult")
			{
				pnlAdult.Visible = true;
				txtAge2.Visible = true;
				dlstAgeUnits2.Visible = true;
				if(dlstAgeUnits2.Items.Count==0)
				{
					dlstAgeUnits2.Items.Add(new ListItem("Years","Years"));
					dlstAgeUnits2.Items.Add(new ListItem("Weeks","Weeks"));
					dlstAgeUnits2.Items.Add(new ListItem("Months","Months"));
				}
				chkBroodstock2.Visible = true;
				lblAge.Visible = true;
				lblAgeUnits.Visible = true;
				lblBroodstock.Visible = true;
			}
			else
			{
				pnlAdult.Visible = false;
				txtAge2.Visible = false;
				dlstAgeUnits2.Visible = false;
				chkBroodstock2.Visible = false;
				lblAge.Visible = false;
				lblAgeUnits.Visible = false;
				lblBroodstock.Visible = false;
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
							{
								lblh2.Text = "ADD New Stocking";
								ShowEnabledFields();
								HideDisabledFields();
								HideInstructions();

								pnlAddInstructions.Visible = true;

								//fill drop down lists
								LoadCodeDataSets();

								dlstHatchery2.DataBind();
								dlstHatchery2.Items.Add(new ListItem("Other","Other"));
								dlstSpecies2.DataBind();
								dlstStock2.Items.Add(new ListItem("Other","Other"));
								dlstAgeClass2.DataBind();
								dlstAgeClass2.SelectedIndex = dlstAgeClass2.Items.Count-1;
								dlstMarkApplied2.DataBind();	
								dlstMarkApplied2.Items.Add(new ListItem("",""));
								dlstMarkApplied2.SelectedIndex = dlstMarkApplied2.Items.Count-1;
							
								//buttons
								btnChangeSite.Visible = false;
								btnModify.Visible = false;
								btnDelete.Visible = false;
								btnReturn.Visible = false;
								btnSave.Visible = true;
								btnCancel.Visible = true;
								break;
							}
							case "Modify":
							{
								lblh2.Text = "EDIT Stocking";
								ShowEnabledFields();
								HideDisabledFields();
								HideInstructions();
								pnlEditInstructions.Visible = true;

								//buttons
								btnChangeSite.Visible = true;
								btnModify.Visible = false;
								btnDelete.Visible = false;
								btnReturn.Visible = false;
								btnSave.Visible = true;
								btnCancel.Visible = true;

								//fill fields
								SetDuplicateFields();
								break;
							}
							case "ModifySite":
							{
								lblh2.Text = "EDIT Stocking";
								ShowDisabledFields();
								HideEnabledFields();
								HideInstructions();
								pnlEditInstructions.Visible = true;

								//fill fields
								int i = SetStockingInfoFields();
								if(i>0)
								{
									SetActivityFields(i);
								}
								
								//buttons
								btnChangeSite.Visible = true;
								btnModify.Visible = false;
								btnDelete.Visible = false;
								btnReturn.Visible = false;
								btnSave.Visible = true;
								btnCancel.Visible = true;

								break;
							}
							case "View":
							{
								lblh2.Text = "VIEW Stocking";
								ShowDisabledFields();
								HideEnabledFields();
								HideInstructions();

								//buttons
								btnChangeSite.Visible = false;
								btnModify.Visible = false;		//if not incorporated, these two values will 
								btnDelete.Visible = false;		//be set to true when the fields are filled
								btnReturn.Visible = true;
								btnSave.Visible = false;
								btnCancel.Visible = false;

								//fill fields
								int i = SetStockingInfoFields();
								if(i>0)
								{
									SetActivityFields(i);
								}
								break;
							}
							default:
							{
								ShowDisabledFields();
								HideEnabledFields();
								HideInstructions();

								//buttons
								btnChangeSite.Visible = false;
								btnModify.Visible = false;
								btnDelete.Visible = false;
								btnReturn.Visible = true;
								btnSave.Visible = false;
								btnCancel.Visible = false;
								break;
							}
						}
					}
					catch(Exception e)
					{
						Debug.WriteLine("Error: "+e.ToString());
						ShowDisabledFields();
						HideEnabledFields();
						HideInstructions();

						//buttons
						btnChangeSite.Visible = false;
						btnModify.Visible = false;
						btnDelete.Visible = false;
						btnReturn.Visible = true;
						btnSave.Visible = false;
						btnCancel.Visible = false;
					}
				}
				else
				{
					ShowDisabledFields();
					HideEnabledFields();
					HideInstructions();

					//buttons
					btnChangeSite.Visible = false;
					btnModify.Visible = false;
					btnDelete.Visible = false;
					btnReturn.Visible = true;
					btnSave.Visible = false;
					btnCancel.Visible = false;
				}
			}
			catch
			{
			}
		}
        
        /// <summary>
        /// Useful for Debugging Only...
        /// </summary>
        /// <param name="text"></param>
        private void PrintMsg(string text)
        {
            txtComments1.Text += text + "\n";
        }
		#endregion

		#region Set Fields
		private void SetSiteFields()
		{
			LoadSiteInfo();

			DataTable tUse = objdsDE_SiteInfo._DE_SiteInfo;
			DataRow UseRow = tUse.Rows.Find(Session["SelectedSiteUseID"]);

			txtdwsiteid.Text = UseRow["AquaticSiteID"].ToString();
			//Agency displayed should be user agency if adding, otherwise activity agency
			//use user agency here, then in SetActivityFields(), value is overwritten
			//txtagencycd.Text = UseRow["AgencyCd"].ToString();
			txtagencycd.Text = Session["UserAgency"].ToString();
			txtgroupsiteid.Text = UseRow["AgencySiteID"].ToString();
			txtwaterbodyid.Text = UseRow["WaterBodyID"].ToString();
			txtwaterbodyname.Text = UseRow["WaterBodyName"].ToString();
			txtsitename.Text = UseRow["AquaticSiteName"].ToString();
			txtsitedescription.Text = UseRow["AquaticSiteDesc"].ToString();
			txtwatershed.Text = UseRow["DrainName"].ToString();
			txtwatershedcode.Text = UseRow["DrainageCd"].ToString();
		}

		private void SetActivityFields(int i)
		{
			LoadtblAquaticActivity();

			DataTable tActivity = objdstblAquaticActivity.tblAquaticActivity;
			DataRow rActivity = tActivity.Rows.Find(i);
				
			txtagencycd.Text = rActivity["AgencyCd"].ToString();

			txtDate1.Text = rActivity["AquaticActivityStartDate"].ToString();

			txtWaterTemperature1.Text = rActivity["WaterTemp_C"].ToString();
			txtAirTemperature1.Text = rActivity["AirTemp_C"].ToString();
			txtTimeofDay1.Text = rActivity["AquaticActivityStartTime"].ToString();
			txtWaterLevel1.Text = rActivity["WaterLevel_cm"].ToString();

			txtComments1.Text = rActivity["Comments"].ToString();

			//buttons
			if(!(bool)rActivity["IncorporatedInd"])
			{
				btnModify.Visible = true;
				btnDelete.Visible = true;
			}
		}

		private int SetStockingInfoFields()
		{
			try
			{
				//returns the activityid
				LoadtblStockedFish();
				LoadCodeDataSets();

				DataTable tStockedFish = objdstblStockedFish.tblStockedFish;
				DataRow rStockedFish = tStockedFish.Rows.Find(Session["CurrentActivityID"]);

				DataTable tHatcheries = objdsDE_Hatcheries._DE_Hatcheries;
				DataRow rHatcheries = tHatcheries.Rows.Find(rStockedFish["FishFacilityID"].ToString());
				txtHatcheryValue.Text = rStockedFish["FishFacilityID"].ToString();

				DataTable tSpecies = objdscdFishSpecies.cdFishSpecies;
				DataRow rSpecies = tSpecies.Rows.Find(rStockedFish["FishSpeciesCd"].ToString());
				txtSpeciesValue.Text = rStockedFish["FishSpeciesCd"].ToString();

				DataTable tMark = objdscdFishMark.cdFishMark;
				DataRow rMark = tMark.Rows.Find(rStockedFish["AppliedMarkCd"]);
				txtMarkAppliedValue.Text = rStockedFish["AppliedMarkCd"].ToString();
			
				chkSatelliteReared1.Checked = (bool)rStockedFish["SatelliteRearedInd"];
				txtHatchery1.Text = rHatcheries["FishFacilityName"].ToString();
				txtOtherHatchery1.Text = rStockedFish["OtherFishFacility"].ToString();
				txtSpecies1.Text = rSpecies["FishSpecies"].ToString();

				if(rStockedFish["FishStockID"].ToString()!="" & rStockedFish["FishStockID"].ToString()!="0")//if a stock was even recorded
				{
					LoadFishStock();
					DataTable tStock = this.objdsDE_FishStock._DE_FishStock;
					DataRow rStock = tStock.Rows.Find(rStockedFish["FishStockID"].ToString());
					txtStockValue.Text = rStockedFish["FishStockID"].ToString();

					txtStock1.Text = rStock["Name"].ToString();
				}

				txtOtherStock1.Text = rStockedFish["OtherStock"].ToString();
				txtAgeClass1.Text = rStockedFish["FishAgeClass"].ToString();
				if(txtAgeClass1.Text=="Adult")
				{
					pnlAdult.Visible = true;

					txtAge1.Visible = true;
					txtAgeUnits1.Visible = true;
					chkBroodstock1.Visible = true;

					lblAge.Visible = true;
					lblAgeUnits.Visible = true;
					lblBroodstock.Visible = true;

					txtAge1.Text = rStockedFish["FishAge"].ToString();
					txtAgeUnits1.Text = rStockedFish["AgeUnitOfMeasure"].ToString();
					chkBroodstock1.Checked = (bool)rStockedFish["BroodstockInd"];
				}
				txtNumberofFish1.Text = rStockedFish["NoFish"].ToString();
				txtAverageLength1.Text = rStockedFish["AveLength_cm"].ToString();
				txtAverageWeight1.Text = rStockedFish["AveWeight_gm"].ToString();
				txtNumberofFishMeasured1.Text = rStockedFish["NoFishMeasured"].ToString();
				if(rStockedFish["AppliedMarkCd"].ToString()!=""&rStockedFish["AppliedMarkCd"].ToString()!="0")
				{
					txtMarkApplied1.Text = rMark["FishMark"].ToString();
				}


				//bind the drop down lists now since we already have the data sets available
				dlstHatchery2.DataBind();
				dlstHatchery2.Items.Add(new ListItem("Other","Other"));

				dlstSpecies2.DataBind();

				dlstStock2.DataBind();
				dlstStock2.Items.Add(new ListItem("Other","Other"));

				dlstAgeClass2.DataBind();
				dlstAgeClass2.SelectedIndex = dlstAgeClass2.Items.Count-1;

				dlstMarkApplied2.DataBind();	
				dlstMarkApplied2.Items.Add(new ListItem("",""));
				dlstMarkApplied2.SelectedIndex = dlstMarkApplied2.Items.Count-1;

				txtAquaticActivityID.Text = rStockedFish["AquaticActivityID"].ToString();
				return (int)rStockedFish["AquaticActivityID"];				
			}
			catch(Exception e)
			{
				Debug.WriteLine("Error occured: "+e.ToString());
				return -1;
			}			
		}

		private void SetDuplicateFields()
		{
			txtDate2.Text = txtDate1.Text;
			chkSatelliteReared2.Checked = chkSatelliteReared1.Checked;

			if(txtHatcheryValue.Text!="")
			{
				dlstHatchery2.SelectedValue = txtHatcheryValue.Text;
			}
			else
			{
				dlstHatchery2.SelectedIndex = dlstHatchery2.Items.Count-1;
			}

			txtOtherHatchery2.Text = txtOtherHatchery1.Text;

			if(txtSpeciesValue.Text!="")
			{
				dlstSpecies2.SelectedValue = txtSpeciesValue.Text;
			}

			LoadFishStock();
			dvDE_FishStock.RowFilter = "FishSpeciesCd = '"+dlstSpecies2.SelectedValue.ToString()+"'";
			dlstStock2.DataBind();
			dlstStock2.Items.Add(new ListItem("Other", "Other" ));

			if(txtStockValue.Text!="")
			{				
				try
				{
					dlstStock2.SelectedValue = txtStockValue.Text;
				}
				catch(System.ArgumentOutOfRangeException e)
				{
					Debug.WriteLine("Error: "+e.ToString());
					dlstStock2.SelectedIndex = dlstStock2.Items.Count-1;
				}
			}
			else
			{
				dlstStock2.SelectedIndex = dlstStock2.Items.Count-1;
			}

			txtOtherStock2.Text = txtOtherStock1.Text;

			if(txtAgeClass1.Text!="")
			{
				dlstAgeClass2.SelectedValue = txtAgeClass1.Text;
			}
			else//select "unknown"
			{
				dlstAgeClass2.SelectedIndex = dlstAgeClass2.Items.Count-1;
			}

			if(txtAgeClass1.Text=="Adult")
			{

				txtAge2.Text = txtAge1.Text;

				if(dlstAgeUnits2.Items.Count==0)
				{
					dlstAgeUnits2.Items.Add(new ListItem("Years","Years"));
					dlstAgeUnits2.Items.Add(new ListItem("Weeks","Weeks"));
					dlstAgeUnits2.Items.Add(new ListItem("Months","Months"));
				}

				if(txtAgeUnits1.Text!="")
				{
					
					dlstAgeUnits2.SelectedValue = txtAgeUnits1.Text;
				}

				chkBroodstock2.Checked = chkBroodstock1.Checked;
				
				//show the fields
				txtAge2.Visible = true;
				dlstAgeUnits2.Visible = true;
				chkBroodstock2.Visible = true;
			}
			txtNumberofFish2.Text = txtNumberofFish1.Text;
			txtAverageLength2.Text = txtAverageLength1.Text;
			txtAverageWeight2.Text = txtAverageWeight1.Text;
			txtNumberofFishMeasured2.Text = txtNumberofFishMeasured1.Text;

			if(txtMarkAppliedValue.Text!="")
			{
				try
				{
					dlstMarkApplied2.SelectedValue = txtMarkAppliedValue.Text;
				}
				catch(System.ArgumentOutOfRangeException e)
				{
					Debug.WriteLine("Error: "+e.ToString());
					dlstMarkApplied2.SelectedIndex = dlstMarkApplied2.Items.Count-1;
				}
			}
			
			txtWaterTemperature2.Text = txtWaterTemperature1.Text;
			txtAirTemperature2.Text = txtAirTemperature1.Text;
			txtTimeofDay2.Text = txtTimeofDay1.Text;
			txtWaterLevel2.Text = txtWaterLevel1.Text;

			txtComments2.Text = txtComments1.Text;
		}
		#endregion

		#region Show Hide
		private void HideDisabledFields()
		{
			//Stocking Info
			txtDate1.Visible = false;
			chkSatelliteReared1.Visible = false;
			txtHatchery1.Visible = false;
			txtOtherHatchery1.Visible = false;
			txtSpecies1.Visible = false;
			txtStock1.Visible = false;
			txtOtherStock1.Visible = false;
			txtAgeClass1.Visible = false;
			txtAge1.Visible = false;
			txtAgeUnits1.Visible = false;
			chkBroodstock1.Visible = false;
			txtNumberofFish1.Visible = false;
			txtAverageLength1.Visible = false;
			txtAverageWeight1.Visible = false;
			txtNumberofFishMeasured1.Visible = false;
			txtMarkApplied1.Visible = false;

			//Water Measurements
			txtWaterTemperature1.Visible = false;
			txtAirTemperature1.Visible = false;
			txtTimeofDay1.Visible = false;
			txtWaterLevel1.Visible = false;

			//Comments
			txtComments1.Visible = false;
		}

		private void ShowDisabledFields()
		{
			//Stocking Info
			txtDate1.Visible = true;
			chkSatelliteReared1.Visible = true;
			txtHatchery1.Visible = true;
			txtOtherHatchery1.Visible = true;
			txtSpecies1.Visible = true;
			txtStock1.Visible = true;
			txtOtherStock1.Visible = true;
			txtAgeClass1.Visible = true;
			if(txtAgeClass1.Text=="Adult")
			{
				txtAge1.Visible = true;
				txtAgeUnits1.Visible = true;
				chkBroodstock1.Visible = true;
			}
			txtNumberofFish1.Visible = true;
			txtAverageLength1.Visible = true;
			txtAverageWeight1.Visible = true;
			txtNumberofFishMeasured1.Visible = true;
			txtMarkApplied1.Visible = true;

			//Water Measurements
			txtWaterTemperature1.Visible = true;
			txtAirTemperature1.Visible = true;
			txtTimeofDay1.Visible = true;
			txtWaterLevel1.Visible = true;

			//Comments
			txtComments1.Visible = true;
		}

		private void HideEnabledFields()
		{
			//Stocking Info
			txtDate2.Visible = false;
			chkSatelliteReared2.Visible = false;
			dlstHatchery2.Visible = false;
			txtOtherHatchery2.Visible = false;
			dlstSpecies2.Visible = false;
			dlstStock2.Visible = false;
			txtOtherStock2.Visible = false;
			dlstAgeClass2.Visible = false;
			txtAge2.Visible = false;
			dlstAgeUnits2.Visible = false;
			chkBroodstock2.Visible = false;
			txtNumberofFish2.Visible = false;
			txtAverageLength2.Visible = false;
			txtAverageWeight2.Visible = false;
			txtNumberofFishMeasured2.Visible = false;
			dlstMarkApplied2.Visible = false;

			//Water Measurements
			txtWaterTemperature2.Visible = false;
			txtAirTemperature2.Visible = false;
			txtTimeofDay2.Visible = false;
			txtWaterLevel2.Visible = false;

			//Comments
			txtComments2.Visible = false;
		}

		private void ShowEnabledFields()
		{
			//Stocking Info
			txtDate2.Visible = true;
			chkSatelliteReared2.Visible = true;
			dlstHatchery2.Visible = true;
			txtOtherHatchery2.Visible = true;
			dlstSpecies2.Visible = true;
			dlstStock2.Visible = true;
			txtOtherStock2.Visible = true;
			dlstAgeClass2.Visible = true;
			if(txtAgeClass1.Text=="Adult")
			{
				txtAge2.Visible = true;
				dlstAgeUnits2.Visible = true;
				chkBroodstock2.Visible = true;
			}
			txtNumberofFish2.Visible = true;
			txtAverageLength2.Visible = true;
			txtAverageWeight2.Visible = true;
			txtNumberofFishMeasured2.Visible = true;
			dlstMarkApplied2.Visible = true;

			//Water Measurements
			txtWaterTemperature2.Visible = true;
			txtAirTemperature2.Visible = true;
			txtTimeofDay2.Visible = true;
			txtWaterLevel2.Visible = true;

			//Comments
			txtComments2.Visible = true;
		}

		private void HideInstructions()
		{
			pnlAddInstructions.Visible = false;
			pnlEditInstructions.Visible = false;
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
			this.oleDbdatblStockedFish = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdstblStockedFish = new NBADWDataEntryApplication.dstblStockedFish();
			this.oleDbdacdFishSpecies = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand9 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand9 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.objdscdFishSpecies = new NBADWDataEntryApplication.dscdFishSpecies();
			this.oleDbdaDE_Hatcheries = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_Hatcheries = new NBADWDataEntryApplication.dsDE_Hatcheries();
			this.oleDbdacdFishAgeClass = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand10 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand10 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdscdFishAgeClass = new NBADWDataEntryApplication.dscdFishAgeClass();
			this.oleDbdacdFishMark = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.objdscdFishMark = new NBADWDataEntryApplication.dscdFishMark();
			this.dvcdFishSpecies = new System.Data.DataView();
			this.dvDE_Hatcheries = new System.Data.DataView();
			this.dvcdFishMark = new System.Data.DataView();
			this.dvcdFishAgeClass = new System.Data.DataView();
			this.oleDbdaDE_FishStock = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_FishStock = new NBADWDataEntryApplication.dsDE_FishStock();
			this.dvDE_FishStock = new System.Data.DataView();
			this.oleDbdatblAquaticActivity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
			this.objdstblAquaticActivity = new NBADWDataEntryApplication.dstblAquaticActivity();
			this.oleDbSelectCommand11 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand11 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand8 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblStockedFish)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishSpecies)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_Hatcheries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishAgeClass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishMark)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishSpecies)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_Hatcheries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishMark)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishAgeClass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_FishStock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_FishStock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).BeginInit();
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
				//this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Data_Warehouse\Tabular_Data\DE-HRAA.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
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
			// oleDbdatblStockedFish
			// 
			this.oleDbdatblStockedFish.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbdatblStockedFish.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdatblStockedFish.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdatblStockedFish.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "tblStockedFish", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("AgeUnitOfMeasure", "AgeUnitOfMeasure"),
																																																							  new System.Data.Common.DataColumnMapping("AppliedMarkCd", "AppliedMarkCd"),
																																																							  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																							  new System.Data.Common.DataColumnMapping("AveLength_cm", "AveLength_cm"),
																																																							  new System.Data.Common.DataColumnMapping("AveWeight_gm", "AveWeight_gm"),
																																																							  new System.Data.Common.DataColumnMapping("FishAge", "FishAge"),
																																																							  new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																							  new System.Data.Common.DataColumnMapping("FishFacilityID", "FishFacilityID"),
																																																							  new System.Data.Common.DataColumnMapping("FishLengthType", "FishLengthType"),
																																																							  new System.Data.Common.DataColumnMapping("FishMatingID", "FishMatingID"),
																																																							  new System.Data.Common.DataColumnMapping("FishSpeciesCd", "FishSpeciesCd"),
																																																							  new System.Data.Common.DataColumnMapping("FishStockID", "FishStockID"),
																																																							  new System.Data.Common.DataColumnMapping("FishStockingID", "FishStockingID"),
																																																							  new System.Data.Common.DataColumnMapping("FishStrainCd", "FishStrainCd"),
																																																							  new System.Data.Common.DataColumnMapping("FishTankNo", "FishTankNo"),
																																																							  new System.Data.Common.DataColumnMapping("LengthRange_cm", "LengthRange_cm"),
																																																							  new System.Data.Common.DataColumnMapping("NoFish", "NoFish"),
																																																							  new System.Data.Common.DataColumnMapping("NoFishMeasured", "NoFishMeasured"),
																																																							  new System.Data.Common.DataColumnMapping("oldAquaticActivityID", "oldAquaticActivityID"),
																																																							  new System.Data.Common.DataColumnMapping("SatelliteRearedInd", "SatelliteRearedInd"),
																																																							  new System.Data.Common.DataColumnMapping("siteuseid", "siteuseid"),
																																																							  new System.Data.Common.DataColumnMapping("Source", "Source"),
																																																							  new System.Data.Common.DataColumnMapping("WeightRange_gm", "WeightRange_gm"),
																																																							  new System.Data.Common.DataColumnMapping("OtherFishFacility", "OtherFishFacility"),
																																																							  new System.Data.Common.DataColumnMapping("OtherStock", "OtherStock"),
																																																							  new System.Data.Common.DataColumnMapping("BroodstockInd", "BroodstockInd")})});
			this.oleDbdatblStockedFish.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblStockedFish WHERE (FishStockingID = ?) AND (AgeUnitOfMeasure = ? O" +
				"R ? IS NULL AND AgeUnitOfMeasure IS NULL) AND (AppliedMarkCd = ? OR ? IS NULL AN" +
				"D AppliedMarkCd IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActi" +
				"vityID IS NULL) AND (AveLength_cm = ? OR ? IS NULL AND AveLength_cm IS NULL) AND" +
				" (AveWeight_gm = ? OR ? IS NULL AND AveWeight_gm IS NULL) AND (BroodstockInd = ?" +
				") AND (FishAge = ? OR ? IS NULL AND FishAge IS NULL) AND (FishAgeClass = ? OR ? " +
				"IS NULL AND FishAgeClass IS NULL) AND (FishFacilityID = ? OR ? IS NULL AND FishF" +
				"acilityID IS NULL) AND (FishLengthType = ? OR ? IS NULL AND FishLengthType IS NU" +
				"LL) AND (FishMatingID = ? OR ? IS NULL AND FishMatingID IS NULL) AND (FishSpecie" +
				"sCd = ? OR ? IS NULL AND FishSpeciesCd IS NULL) AND (FishStockID = ? OR ? IS NUL" +
				"L AND FishStockID IS NULL) AND (FishStrainCd = ? OR ? IS NULL AND FishStrainCd I" +
				"S NULL) AND (FishTankNo = ? OR ? IS NULL AND FishTankNo IS NULL) AND (LengthRang" +
				"e_cm = ? OR ? IS NULL AND LengthRange_cm IS NULL) AND (NoFish = ? OR ? IS NULL A" +
				"ND NoFish IS NULL) AND (NoFishMeasured = ? OR ? IS NULL AND NoFishMeasured IS NU" +
				"LL) AND (OtherFishFacility = ? OR ? IS NULL AND OtherFishFacility IS NULL) AND (" +
				"OtherStock = ? OR ? IS NULL AND OtherStock IS NULL) AND (SatelliteRearedInd = ?)" +
				" AND (Source = ? OR ? IS NULL AND Source IS NULL) AND (WeightRange_gm = ? OR ? I" +
				"S NULL AND WeightRange_gm IS NULL) AND (oldAquaticActivityID = ? OR ? IS NULL AN" +
				"D oldAquaticActivityID IS NULL) AND (siteuseid = ? OR ? IS NULL AND siteuseid IS" +
				" NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStockingID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStockingID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgeUnitOfMeasure", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgeUnitOfMeasure", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgeUnitOfMeasure1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgeUnitOfMeasure", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AppliedMarkCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AppliedMarkCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AppliedMarkCd1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AppliedMarkCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveLength_cm", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveLength_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveLength_cm1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveLength_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWeight_gm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWeight_gm1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWeight_gm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BroodstockInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BroodstockInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAge", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAge", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAge1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAge", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishFacilityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishFacilityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishFacilityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishFacilityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishLengthType", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishLengthType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishLengthType1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishLengthType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMatingID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMatingID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMatingID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMatingID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd1", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStockID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStockID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStockID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStockID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStrainCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStrainCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStrainCd1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStrainCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishTankNo", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishTankNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishTankNo1", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishTankNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LengthRange_cm", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LengthRange_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LengthRange_cm1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LengthRange_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoFish", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoFish", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoFish1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoFish", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoFishMeasured", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoFishMeasured", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoFishMeasured1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoFishMeasured", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherFishFacility", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherFishFacility", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherFishFacility1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherFishFacility", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherStock", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherStock", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherStock1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherStock", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SatelliteRearedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SatelliteRearedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Source", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Source", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Source1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Source", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeightRange_gm", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeightRange_gm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeightRange_gm1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeightRange_gm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_siteuseid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "siteuseid", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_siteuseid1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "siteuseid", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = @"INSERT INTO tblStockedFish(AgeUnitOfMeasure, AppliedMarkCd, AquaticActivityID, AveLength_cm, AveWeight_gm, FishAge, FishAgeClass, FishFacilityID, FishLengthType, FishMatingID, FishSpeciesCd, FishStockID, FishStrainCd, FishTankNo, LengthRange_cm, NoFish, NoFishMeasured, oldAquaticActivityID, SatelliteRearedInd, siteuseid, Source, WeightRange_gm, OtherFishFacility, OtherStock, BroodstockInd) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgeUnitOfMeasure", System.Data.OleDb.OleDbType.VarWChar, 10, "AgeUnitOfMeasure"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AppliedMarkCd", System.Data.OleDb.OleDbType.Integer, 0, "AppliedMarkCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveLength_cm"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAge", System.Data.OleDb.OleDbType.VarWChar, 10, "FishAge"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClass"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishFacilityID", System.Data.OleDb.OleDbType.Integer, 0, "FishFacilityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishLengthType", System.Data.OleDb.OleDbType.VarWChar, 10, "FishLengthType"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMatingID", System.Data.OleDb.OleDbType.Integer, 0, "FishMatingID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishStockID", System.Data.OleDb.OleDbType.Integer, 0, "FishStockID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishStrainCd", System.Data.OleDb.OleDbType.Integer, 0, "FishStrainCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishTankNo", System.Data.OleDb.OleDbType.VarWChar, 2, "FishTankNo"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LengthRange_cm", System.Data.OleDb.OleDbType.VarWChar, 20, "LengthRange_cm"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoFish", System.Data.OleDb.OleDbType.Integer, 0, "NoFish"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoFishMeasured", System.Data.OleDb.OleDbType.Integer, 0, "NoFishMeasured"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticActivityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SatelliteRearedInd", System.Data.OleDb.OleDbType.Boolean, 2, "SatelliteRearedInd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("siteuseid", System.Data.OleDb.OleDbType.Integer, 0, "siteuseid"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Source", System.Data.OleDb.OleDbType.VarWChar, 50, "Source"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeightRange_gm", System.Data.OleDb.OleDbType.VarWChar, 20, "WeightRange_gm"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherFishFacility", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherFishFacility"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherStock", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherStock"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("BroodstockInd", System.Data.OleDb.OleDbType.Boolean, 2, "BroodstockInd"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT AgeUnitOfMeasure, AppliedMarkCd, AquaticActivityID, AveLength_cm, AveWeight_gm, FishAge, FishAgeClass, FishFacilityID, FishLengthType, FishMatingID, FishSpeciesCd, FishStockID, FishStockingID, FishStrainCd, FishTankNo, LengthRange_cm, NoFish, NoFishMeasured, oldAquaticActivityID, SatelliteRearedInd, siteuseid, Source, WeightRange_gm, OtherFishFacility, OtherStock, BroodstockInd FROM tblStockedFish";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblStockedFish SET AgeUnitOfMeasure = ?, AppliedMarkCd = ?, AquaticActivit" +
				"yID = ?, AveLength_cm = ?, AveWeight_gm = ?, FishAge = ?, FishAgeClass = ?, Fish" +
				"FacilityID = ?, FishLengthType = ?, FishMatingID = ?, FishSpeciesCd = ?, FishSto" +
				"ckID = ?, FishStrainCd = ?, FishTankNo = ?, LengthRange_cm = ?, NoFish = ?, NoFi" +
				"shMeasured = ?, oldAquaticActivityID = ?, SatelliteRearedInd = ?, siteuseid = ?," +
				" Source = ?, WeightRange_gm = ?, OtherFishFacility = ?, OtherStock = ?, Broodsto" +
				"ckInd = ? WHERE (FishStockingID = ?) AND (AgeUnitOfMeasure = ? OR ? IS NULL AND " +
				"AgeUnitOfMeasure IS NULL) AND (AppliedMarkCd = ? OR ? IS NULL AND AppliedMarkCd " +
				"IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) " +
				"AND (AveLength_cm = ? OR ? IS NULL AND AveLength_cm IS NULL) AND (AveWeight_gm =" +
				" ? OR ? IS NULL AND AveWeight_gm IS NULL) AND (BroodstockInd = ?) AND (FishAge =" +
				" ? OR ? IS NULL AND FishAge IS NULL) AND (FishAgeClass = ? OR ? IS NULL AND Fish" +
				"AgeClass IS NULL) AND (FishFacilityID = ? OR ? IS NULL AND FishFacilityID IS NUL" +
				"L) AND (FishLengthType = ? OR ? IS NULL AND FishLengthType IS NULL) AND (FishMat" +
				"ingID = ? OR ? IS NULL AND FishMatingID IS NULL) AND (FishSpeciesCd = ? OR ? IS " +
				"NULL AND FishSpeciesCd IS NULL) AND (FishStockID = ? OR ? IS NULL AND FishStockI" +
				"D IS NULL) AND (FishStrainCd = ? OR ? IS NULL AND FishStrainCd IS NULL) AND (Fis" +
				"hTankNo = ? OR ? IS NULL AND FishTankNo IS NULL) AND (LengthRange_cm = ? OR ? IS" +
				" NULL AND LengthRange_cm IS NULL) AND (NoFish = ? OR ? IS NULL AND NoFish IS NUL" +
				"L) AND (NoFishMeasured = ? OR ? IS NULL AND NoFishMeasured IS NULL) AND (OtherFi" +
				"shFacility = ? OR ? IS NULL AND OtherFishFacility IS NULL) AND (OtherStock = ? O" +
				"R ? IS NULL AND OtherStock IS NULL) AND (SatelliteRearedInd = ?) AND (Source = ?" +
				" OR ? IS NULL AND Source IS NULL) AND (WeightRange_gm = ? OR ? IS NULL AND Weigh" +
				"tRange_gm IS NULL) AND (oldAquaticActivityID = ? OR ? IS NULL AND oldAquaticActi" +
				"vityID IS NULL) AND (siteuseid = ? OR ? IS NULL AND siteuseid IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgeUnitOfMeasure", System.Data.OleDb.OleDbType.VarWChar, 10, "AgeUnitOfMeasure"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AppliedMarkCd", System.Data.OleDb.OleDbType.Integer, 0, "AppliedMarkCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveLength_cm", System.Data.OleDb.OleDbType.Double, 0, "AveLength_cm"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, "AveWeight_gm"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAge", System.Data.OleDb.OleDbType.VarWChar, 10, "FishAge"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClass"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishFacilityID", System.Data.OleDb.OleDbType.Integer, 0, "FishFacilityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishLengthType", System.Data.OleDb.OleDbType.VarWChar, 10, "FishLengthType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMatingID", System.Data.OleDb.OleDbType.Integer, 0, "FishMatingID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishStockID", System.Data.OleDb.OleDbType.Integer, 0, "FishStockID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishStrainCd", System.Data.OleDb.OleDbType.Integer, 0, "FishStrainCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishTankNo", System.Data.OleDb.OleDbType.VarWChar, 2, "FishTankNo"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LengthRange_cm", System.Data.OleDb.OleDbType.VarWChar, 20, "LengthRange_cm"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoFish", System.Data.OleDb.OleDbType.Integer, 0, "NoFish"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoFishMeasured", System.Data.OleDb.OleDbType.Integer, 0, "NoFishMeasured"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticActivityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SatelliteRearedInd", System.Data.OleDb.OleDbType.Boolean, 2, "SatelliteRearedInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("siteuseid", System.Data.OleDb.OleDbType.Integer, 0, "siteuseid"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Source", System.Data.OleDb.OleDbType.VarWChar, 50, "Source"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeightRange_gm", System.Data.OleDb.OleDbType.VarWChar, 20, "WeightRange_gm"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherFishFacility", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherFishFacility"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OtherStock", System.Data.OleDb.OleDbType.VarWChar, 50, "OtherStock"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BroodstockInd", System.Data.OleDb.OleDbType.Boolean, 2, "BroodstockInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStockingID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStockingID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgeUnitOfMeasure", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgeUnitOfMeasure", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgeUnitOfMeasure1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgeUnitOfMeasure", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AppliedMarkCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AppliedMarkCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AppliedMarkCd1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AppliedMarkCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveLength_cm", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveLength_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveLength_cm1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveLength_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWeight_gm", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWeight_gm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AveWeight_gm1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AveWeight_gm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BroodstockInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BroodstockInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAge", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAge", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAge1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAge", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishFacilityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishFacilityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishFacilityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishFacilityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishLengthType", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishLengthType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishLengthType1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishLengthType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMatingID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMatingID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMatingID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMatingID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd1", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStockID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStockID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStockID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStockID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStrainCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStrainCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishStrainCd1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishStrainCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishTankNo", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishTankNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishTankNo1", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishTankNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LengthRange_cm", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LengthRange_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LengthRange_cm1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LengthRange_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoFish", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoFish", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoFish1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoFish", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoFishMeasured", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoFishMeasured", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoFishMeasured1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoFishMeasured", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherFishFacility", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherFishFacility", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherFishFacility1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherFishFacility", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherStock", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherStock", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OtherStock1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OtherStock", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SatelliteRearedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SatelliteRearedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Source", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Source", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Source1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Source", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeightRange_gm", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeightRange_gm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeightRange_gm1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeightRange_gm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_siteuseid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "siteuseid", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_siteuseid1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "siteuseid", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblStockedFish
			// 
			this.objdstblStockedFish.DataSetName = "dstblStockedFish";
			this.objdstblStockedFish.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdacdFishSpecies
			// 
			this.oleDbdacdFishSpecies.DeleteCommand = this.oleDbDeleteCommand6;
			this.oleDbdacdFishSpecies.InsertCommand = this.oleDbInsertCommand9;
			this.oleDbdacdFishSpecies.SelectCommand = this.oleDbSelectCommand9;
			this.oleDbdacdFishSpecies.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "cdFishSpecies", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("FishSpecies", "FishSpecies"),
																																																							new System.Data.Common.DataColumnMapping("FishSpeciesCd", "FishSpeciesCd"),
																																																							new System.Data.Common.DataColumnMapping("StockedInd", "StockedInd"),
																																																							new System.Data.Common.DataColumnMapping("ElectrofishInd", "ElectrofishInd")})});
			this.oleDbdacdFishSpecies.UpdateCommand = this.oleDbUpdateCommand6;
			// 
			// oleDbDeleteCommand6
			// 
			this.oleDbDeleteCommand6.CommandText = "DELETE FROM cdFishSpecies WHERE (FishSpeciesCd = ?) AND (ElectrofishInd = ?) AND " +
				"(FishSpecies = ? OR ? IS NULL AND FishSpecies IS NULL) AND (StockedInd = ?)";
			this.oleDbDeleteCommand6.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ElectrofishInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StockedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StockedInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand9
			// 
			this.oleDbInsertCommand9.CommandText = "INSERT INTO cdFishSpecies(FishSpecies, FishSpeciesCd, StockedInd, ElectrofishInd)" +
				" VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand9.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("StockedInd", System.Data.OleDb.OleDbType.Boolean, 2, "StockedInd"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, "ElectrofishInd"));
			// 
			// oleDbSelectCommand9
			// 
			this.oleDbSelectCommand9.CommandText = "SELECT FishSpecies, FishSpeciesCd, StockedInd, ElectrofishInd FROM cdFishSpecies";
			this.oleDbSelectCommand9.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand6
			// 
			this.oleDbUpdateCommand6.CommandText = "UPDATE cdFishSpecies SET FishSpecies = ?, FishSpeciesCd = ?, StockedInd = ?, Elec" +
				"trofishInd = ? WHERE (FishSpeciesCd = ?) AND (ElectrofishInd = ?) AND (FishSpeci" +
				"es = ? OR ? IS NULL AND FishSpecies IS NULL) AND (StockedInd = ?)";
			this.oleDbUpdateCommand6.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("StockedInd", System.Data.OleDb.OleDbType.Boolean, 2, "StockedInd"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, "ElectrofishInd"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ElectrofishInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StockedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StockedInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM cdFishSpecies WHERE (FishSpeciesCd = ?) AND (FishSpecies = ? OR ? IS " +
				"NULL AND FishSpecies IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO cdFishSpecies(FishSpecies, FishSpeciesCd) VALUES (?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT FishSpecies, FishSpeciesCd FROM cdFishSpecies";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE cdFishSpecies SET FishSpecies = ?, FishSpeciesCd = ? WHERE (FishSpeciesCd " +
				"= ?) AND (FishSpecies = ? OR ? IS NULL AND FishSpecies IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, "FishSpecies"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpeciesCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishSpecies1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishSpecies", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdFishSpecies
			// 
			this.objdscdFishSpecies.DataSetName = "dscdFishSpecies";
			this.objdscdFishSpecies.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaDE_Hatcheries
			// 
			this.oleDbdaDE_Hatcheries.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdaDE_Hatcheries.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdaDE_Hatcheries.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "DE-Hatcheries", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("ActiveInd", "ActiveInd"),
																																																							new System.Data.Common.DataColumnMapping("FishFacilityID", "FishFacilityID"),
																																																							new System.Data.Common.DataColumnMapping("FishFacilityName", "FishFacilityName"),
																																																							new System.Data.Common.DataColumnMapping("FishFacilityType", "FishFacilityType")})});
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO [DE-Hatcheries] (ActiveInd, FishFacilityID, FishFacilityName, FishFac" +
				"ilityType) VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActiveInd", System.Data.OleDb.OleDbType.VarWChar, 15, "ActiveInd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishFacilityID", System.Data.OleDb.OleDbType.Integer, 0, "FishFacilityID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishFacilityName", System.Data.OleDb.OleDbType.VarWChar, 50, "FishFacilityName"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishFacilityType", System.Data.OleDb.OleDbType.VarWChar, 20, "FishFacilityType"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT ActiveInd, FishFacilityID, FishFacilityName, FishFacilityType FROM [DE-Hat" +
				"cheries]";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// objdsDE_Hatcheries
			// 
			this.objdsDE_Hatcheries.DataSetName = "dsDE_Hatcheries";
			this.objdsDE_Hatcheries.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdacdFishAgeClass
			// 
			this.oleDbdacdFishAgeClass.DeleteCommand = this.oleDbDeleteCommand7;
			this.oleDbdacdFishAgeClass.InsertCommand = this.oleDbInsertCommand10;
			this.oleDbdacdFishAgeClass.SelectCommand = this.oleDbSelectCommand10;
			this.oleDbdacdFishAgeClass.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "cdFishAgeClass", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("FishAgeClass", "FishAgeClass"),
																																																							  new System.Data.Common.DataColumnMapping("FishAgeClassCategory", "FishAgeClassCategory"),
																																																							  new System.Data.Common.DataColumnMapping("ElectrofishInd", "ElectrofishInd"),
																																																							  new System.Data.Common.DataColumnMapping("FishCountInd", "FishCountInd"),
																																																							  new System.Data.Common.DataColumnMapping("StockingInd", "StockingInd")})});
			this.oleDbdacdFishAgeClass.UpdateCommand = this.oleDbUpdateCommand7;
			// 
			// oleDbDeleteCommand7
			// 
			this.oleDbDeleteCommand7.CommandText = "DELETE FROM cdFishAgeClass WHERE (FishAgeClass = ?) AND (ElectrofishInd = ?) AND " +
				"(FishAgeClassCategory = ? OR ? IS NULL AND FishAgeClassCategory IS NULL) AND (Fi" +
				"shCountInd = ?) AND (StockingInd = ?)";
			this.oleDbDeleteCommand7.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ElectrofishInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishCountInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishCountInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StockingInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StockingInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection2
			// 
			//this.oleDbConnection2.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Data_Warehouse\Tabular_Data\DE-HRAA.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
            this.oleDbConnection2.ConnectionString = Session["ConnectionString"].ToString(); 
			// 
			// oleDbInsertCommand10
			// 
			this.oleDbInsertCommand10.CommandText = "INSERT INTO cdFishAgeClass(FishAgeClass, FishAgeClassCategory, ElectrofishInd, Fi" +
				"shCountInd, StockingInd) VALUES (?, ?, ?, ?, ?)";
			this.oleDbInsertCommand10.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, "FishAgeClass"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClassCategory"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, "ElectrofishInd"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishCountInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishCountInd"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("StockingInd", System.Data.OleDb.OleDbType.Boolean, 2, "StockingInd"));
			// 
			// oleDbSelectCommand10
			// 
			this.oleDbSelectCommand10.CommandText = "SELECT FishAgeClass, FishAgeClassCategory, ElectrofishInd, FishCountInd, Stocking" +
				"Ind FROM cdFishAgeClass";
			this.oleDbSelectCommand10.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand7
			// 
			this.oleDbUpdateCommand7.CommandText = @"UPDATE cdFishAgeClass SET FishAgeClass = ?, FishAgeClassCategory = ?, ElectrofishInd = ?, FishCountInd = ?, StockingInd = ? WHERE (FishAgeClass = ?) AND (ElectrofishInd = ?) AND (FishAgeClassCategory = ? OR ? IS NULL AND FishAgeClassCategory IS NULL) AND (FishCountInd = ?) AND (StockingInd = ?)";
			this.oleDbUpdateCommand7.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, "FishAgeClass"));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClassCategory"));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, "ElectrofishInd"));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishCountInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishCountInd"));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("StockingInd", System.Data.OleDb.OleDbType.Boolean, 2, "StockingInd"));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ElectrofishInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ElectrofishInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishCountInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishCountInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StockingInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StockingInd", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM cdFishAgeClass WHERE (FishAgeClass = ?) AND (FishAgeClassCategory = ?" +
				" OR ? IS NULL AND FishAgeClassCategory IS NULL)";
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = "INSERT INTO cdFishAgeClass(FishAgeClass, FishAgeClassCategory) VALUES (?, ?)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, "FishAgeClass"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClassCategory"));
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT FishAgeClass, FishAgeClassCategory FROM cdFishAgeClass";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE cdFishAgeClass SET FishAgeClass = ?, FishAgeClassCategory = ? WHERE (FishA" +
				"geClass = ?) AND (FishAgeClassCategory = ? OR ? IS NULL AND FishAgeClassCategory" +
				" IS NULL)";
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, "FishAgeClass"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, "FishAgeClassCategory"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClass", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishAgeClassCategory1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishAgeClassCategory", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdFishAgeClass
			// 
			this.objdscdFishAgeClass.DataSetName = "dscdFishAgeClass";
			this.objdscdFishAgeClass.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdacdFishMark
			// 
			this.oleDbdacdFishMark.DeleteCommand = this.oleDbDeleteCommand8;
			this.oleDbdacdFishMark.InsertCommand = this.oleDbInsertCommand11;
			this.oleDbdacdFishMark.SelectCommand = this.oleDbSelectCommand11;
			this.oleDbdacdFishMark.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "cdFishMark", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("FishMark", "FishMark"),
																																																					  new System.Data.Common.DataColumnMapping("FishMarkCd", "FishMarkCd")})});
			this.oleDbdacdFishMark.UpdateCommand = this.oleDbUpdateCommand8;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM cdFishMark WHERE (FishMarkCd = ?) AND (FishMark = ? OR ? IS NULL AND " +
				"FishMark IS NULL)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMarkCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMarkCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMark", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMark1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMark", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = "INSERT INTO cdFishMark(FishMark, FishMarkCd) VALUES (?, ?)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, "FishMark"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMarkCd", System.Data.OleDb.OleDbType.Integer, 0, "FishMarkCd"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT FishMark, FishMarkCd FROM cdFishMark";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE cdFishMark SET FishMark = ?, FishMarkCd = ? WHERE (FishMarkCd = ?) AND (Fi" +
				"shMark = ? OR ? IS NULL AND FishMark IS NULL)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, "FishMark"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMarkCd", System.Data.OleDb.OleDbType.Integer, 0, "FishMarkCd"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMarkCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMarkCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMark", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMark1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMark", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdFishMark
			// 
			this.objdscdFishMark.DataSetName = "dscdFishMark";
			this.objdscdFishMark.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvcdFishSpecies
			// 
			this.dvcdFishSpecies.RowFilter = "StockedInd";
			this.dvcdFishSpecies.Sort = "FishSpecies";
			this.dvcdFishSpecies.Table = this.objdscdFishSpecies.cdFishSpecies;
			// 
			// dvDE_Hatcheries
			// 
			this.dvDE_Hatcheries.Sort = "FishFacilityName";
			this.dvDE_Hatcheries.Table = this.objdsDE_Hatcheries._DE_Hatcheries;
			// 
			// dvcdFishMark
			// 
			this.dvcdFishMark.Sort = "FishMark";
			this.dvcdFishMark.Table = this.objdscdFishMark.cdFishMark;
			// 
			// dvcdFishAgeClass
			// 
			this.dvcdFishAgeClass.RowFilter = "StockingInd";
			this.dvcdFishAgeClass.Sort = "FishAgeClass";
			this.dvcdFishAgeClass.Table = this.objdscdFishAgeClass.cdFishAgeClass;
			// 
			// oleDbdaDE_FishStock
			// 
			this.oleDbdaDE_FishStock.InsertCommand = this.oleDbInsertCommand7;
			this.oleDbdaDE_FishStock.SelectCommand = this.oleDbSelectCommand7;
			this.oleDbdaDE_FishStock.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "DE-FishStock", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("FishSpeciesCd", "FishSpeciesCd"),
																																																						  new System.Data.Common.DataColumnMapping("FishStockID", "FishStockID"),
																																																						  new System.Data.Common.DataColumnMapping("Name", "Name")})});
			// 
			// oleDbInsertCommand7
			// 
			this.oleDbInsertCommand7.CommandText = "INSERT INTO [DE-FishStock] (FishSpeciesCd, FishStockID, Name) VALUES (?, ?, ?)";
			this.oleDbInsertCommand7.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishSpeciesCd", System.Data.OleDb.OleDbType.VarWChar, 2, "FishSpeciesCd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishStockID", System.Data.OleDb.OleDbType.Integer, 0, "FishStockID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 255, "Name"));
			// 
			// oleDbSelectCommand7
			// 
			this.oleDbSelectCommand7.CommandText = "SELECT FishSpeciesCd, FishStockID, Name FROM [DE-FishStock]";
			this.oleDbSelectCommand7.Connection = this.oleDbConnection1;
			// 
			// objdsDE_FishStock
			// 
			this.objdsDE_FishStock.DataSetName = "dsDE_FishStock";
			this.objdsDE_FishStock.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDE_FishStock
			// 
			this.dvDE_FishStock.Sort = "Name";
			this.dvDE_FishStock.Table = this.objdsDE_FishStock._DE_FishStock;
			// 
			// oleDbdatblAquaticActivity
			// 
			this.oleDbdatblAquaticActivity.DeleteCommand = this.oleDbDeleteCommand5;
			this.oleDbdatblAquaticActivity.InsertCommand = this.oleDbInsertCommand8;
			this.oleDbdatblAquaticActivity.SelectCommand = this.oleDbSelectCommand8;
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
																																																									  new System.Data.Common.DataColumnMapping("Year", "Year")})});
			this.oleDbdatblAquaticActivity.UpdateCommand = this.oleDbUpdateCommand5;
			// 
			// oleDbDeleteCommand5
			// 
			this.oleDbDeleteCommand5.CommandText = "DELETE FROM tblAquaticActivity WHERE (AquaticActivityID = ?) AND (Agency2Cd = ? O" +
				"R ? IS NULL AND Agency2Cd IS NULL) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd I" +
				"S NULL) AND (AirTemp_C = ? OR ? IS NULL AND AirTemp_C IS NULL) AND (AquaticActiv" +
				"ityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticActivityEndDat" +
				"e = ? OR ? IS NULL AND AquaticActivityEndDate IS NULL) AND (AquaticActivityEndTi" +
				"me = ? OR ? IS NULL AND AquaticActivityEndTime IS NULL) AND (AquaticActivityLead" +
				"er = ? OR ? IS NULL AND AquaticActivityLeader IS NULL) AND (AquaticActivityStart" +
				"Date = ? OR ? IS NULL AND AquaticActivityStartDate IS NULL) AND (AquaticActivity" +
				"StartTime = ? OR ? IS NULL AND AquaticActivityStartTime IS NULL) AND (AquaticMet" +
				"hodCd = ? OR ? IS NULL AND AquaticMethodCd IS NULL) AND (AquaticProgramID = ? OR" +
				" ? IS NULL AND AquaticProgramID IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND" +
				" AquaticSiteID IS NULL) AND (Comments = ? OR ? IS NULL AND Comments IS NULL) AND" +
				" (Crew = ? OR ? IS NULL AND Crew IS NULL) AND (DateEntered = ? OR ? IS NULL AND " +
				"DateEntered IS NULL) AND (IncorporatedInd = ?) AND (OldAquaticActivityID = ? OR " +
				"? IS NULL AND OldAquaticActivityID IS NULL) AND (PrimaryActivityInd = ?) AND (Pr" +
				"oject = ? OR ? IS NULL AND Project IS NULL) AND (Siltation = ? OR ? IS NULL AND " +
				"Siltation IS NULL) AND (WaterLevel = ? OR ? IS NULL AND WaterLevel IS NULL) AND " +
				"(WaterLevel_AM_cm = ? OR ? IS NULL AND WaterLevel_AM_cm IS NULL) AND (WaterLevel" +
				"_PM_cm = ? OR ? IS NULL AND WaterLevel_PM_cm IS NULL) AND (WaterLevel_cm = ? OR " +
				"? IS NULL AND WaterLevel_cm IS NULL) AND (WaterTemp_C = ? OR ? IS NULL AND Water" +
				"Temp_C IS NULL) AND (WeatherConditions = ? OR ? IS NULL AND WeatherConditions IS" +
				" NULL) AND (Year = ? OR ? IS NULL AND Year IS NULL) AND (oldAquaticSiteID = ? OR" +
				" ? IS NULL AND oldAquaticSiteID IS NULL)";
			this.oleDbDeleteCommand5.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryActivityInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Project", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Project", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Project1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Project", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand8
			// 
			this.oleDbInsertCommand8.CommandText = @"INSERT INTO tblAquaticActivity (AgencyCd, AirTemp_C, AquaticActivityCd, AquaticActivityStartDate, AquaticActivityStartTime, AquaticSiteID, Comments, DateEntered, IncorporatedInd, WaterLevel_cm, WaterTemp_C, AquaticActivityID) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand8.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "AirTemp_C"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_cm"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "WaterTemp_C"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			// 
			// oleDbSelectCommand8
			// 
			this.oleDbSelectCommand8.CommandText = @"SELECT Agency2Cd, AgencyCd, AirTemp_C, AquaticActivityCd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityID, AquaticActivityLeader, AquaticActivityStartDate, AquaticActivityStartTime, AquaticMethodCd, AquaticProgramID, AquaticSiteID, Comments, Crew, DateEntered, IncorporatedInd, OldAquaticActivityID, oldAquaticSiteID, PrimaryActivityInd, Project, Siltation, WaterLevel, WaterLevel_AM_cm, WaterLevel_cm, WaterLevel_PM_cm, WaterTemp_C, WeatherConditions, Year FROM tblAquaticActivity";
			this.oleDbSelectCommand8.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand5
			// 
			this.oleDbUpdateCommand5.CommandText = "UPDATE tblAquaticActivity SET Agency2Cd = ?, AgencyCd = ?, AirTemp_C = ?, Aquatic" +
				"ActivityCd = ?, AquaticActivityEndDate = ?, AquaticActivityEndTime = ?, AquaticA" +
				"ctivityID = ?, AquaticActivityLeader = ?, AquaticActivityStartDate = ?, AquaticA" +
				"ctivityStartTime = ?, AquaticMethodCd = ?, AquaticProgramID = ?, AquaticSiteID =" +
				" ?, Comments = ?, Crew = ?, DateEntered = ?, IncorporatedInd = ?, OldAquaticActi" +
				"vityID = ?, oldAquaticSiteID = ?, PrimaryActivityInd = ?, Project = ?, Siltation" +
				" = ?, WaterLevel = ?, WaterLevel_AM_cm = ?, WaterLevel_cm = ?, WaterLevel_PM_cm " +
				"= ?, WaterTemp_C = ?, WeatherConditions = ?, Year = ? WHERE (AquaticActivityID =" +
				" ?) AND (Agency2Cd = ? OR ? IS NULL AND Agency2Cd IS NULL) AND (AgencyCd = ? OR " +
				"? IS NULL AND AgencyCd IS NULL) AND (AirTemp_C = ? OR ? IS NULL AND AirTemp_C IS" +
				" NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AN" +
				"D (AquaticActivityEndDate = ? OR ? IS NULL AND AquaticActivityEndDate IS NULL) A" +
				"ND (AquaticActivityEndTime = ? OR ? IS NULL AND AquaticActivityEndTime IS NULL) " +
				"AND (AquaticActivityLeader = ? OR ? IS NULL AND AquaticActivityLeader IS NULL) A" +
				"ND (AquaticActivityStartDate = ? OR ? IS NULL AND AquaticActivityStartDate IS NU" +
				"LL) AND (AquaticActivityStartTime = ? OR ? IS NULL AND AquaticActivityStartTime " +
				"IS NULL) AND (AquaticMethodCd = ? OR ? IS NULL AND AquaticMethodCd IS NULL) AND " +
				"(AquaticProgramID = ? OR ? IS NULL AND AquaticProgramID IS NULL) AND (AquaticSit" +
				"eID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (Comments = ? OR ? IS NULL A" +
				"ND Comments IS NULL) AND (Crew = ? OR ? IS NULL AND Crew IS NULL) AND (DateEnter" +
				"ed = ? OR ? IS NULL AND DateEntered IS NULL) AND (IncorporatedInd = ?) AND (OldA" +
				"quaticActivityID = ? OR ? IS NULL AND OldAquaticActivityID IS NULL) AND (Primary" +
				"ActivityInd = ?) AND (Project = ? OR ? IS NULL AND Project IS NULL) AND (Siltati" +
				"on = ? OR ? IS NULL AND Siltation IS NULL) AND (WaterLevel = ? OR ? IS NULL AND " +
				"WaterLevel IS NULL) AND (WaterLevel_AM_cm = ? OR ? IS NULL AND WaterLevel_AM_cm " +
				"IS NULL) AND (WaterLevel_PM_cm = ? OR ? IS NULL AND WaterLevel_PM_cm IS NULL) AN" +
				"D (WaterLevel_cm = ? OR ? IS NULL AND WaterLevel_cm IS NULL) AND (WaterTemp_C = " +
				"? OR ? IS NULL AND WaterTemp_C IS NULL) AND (WeatherConditions = ? OR ? IS NULL " +
				"AND WeatherConditions IS NULL) AND (Year = ? OR ? IS NULL AND Year IS NULL) AND " +
				"(oldAquaticSiteID = ? OR ? IS NULL AND oldAquaticSiteID IS NULL)";
			this.oleDbUpdateCommand5.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, "AirTemp_C"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityEndDate"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityEndTime"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivityLeader"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticProgramID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "OldAquaticActivityID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, "PrimaryActivityInd"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Project", System.Data.OleDb.OleDbType.VarWChar, 100, "Project"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, "Siltation"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, "WaterLevel"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_AM_cm"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_cm"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_PM_cm"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, "WaterTemp_C"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, "WeatherConditions"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Year", System.Data.OleDb.OleDbType.VarWChar, 4, "Year"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AirTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AirTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AirTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryActivityInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Project", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Project", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Project1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Project", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterTemp_C", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterTemp_C1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterTemp_C", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblAquaticActivity
			// 
			this.objdstblAquaticActivity.DataSetName = "dstblAquaticActivity";
			this.objdstblAquaticActivity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbSelectCommand11
			// 
			this.oleDbSelectCommand11.CommandText = "SELECT FishMark, FishMarkCd FROM cdFishMark";
			this.oleDbSelectCommand11.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand11
			// 
			this.oleDbInsertCommand11.CommandText = "INSERT INTO cdFishMark(FishMark, FishMarkCd) VALUES (?, ?)";
			this.oleDbInsertCommand11.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, "FishMark"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMarkCd", System.Data.OleDb.OleDbType.Integer, 0, "FishMarkCd"));
			// 
			// oleDbUpdateCommand8
			// 
			this.oleDbUpdateCommand8.CommandText = "UPDATE cdFishMark SET FishMark = ?, FishMarkCd = ? WHERE (FishMarkCd = ?) AND (Fi" +
				"shMark = ? OR ? IS NULL AND FishMark IS NULL)";
			this.oleDbUpdateCommand8.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, "FishMark"));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishMarkCd", System.Data.OleDb.OleDbType.Integer, 0, "FishMarkCd"));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMarkCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMarkCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMark", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMark1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMark", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand8
			// 
			this.oleDbDeleteCommand8.CommandText = "DELETE FROM cdFishMark WHERE (FishMarkCd = ?) AND (FishMark = ? OR ? IS NULL AND " +
				"FishMark IS NULL)";
			this.oleDbDeleteCommand8.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMarkCd", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMarkCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMark", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMark", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishMark1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishMark", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SiteInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblStockedFish)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishSpecies)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_Hatcheries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishAgeClass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdFishMark)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishSpecies)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_Hatcheries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishMark)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdFishAgeClass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_FishStock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_FishStock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).EndInit();

		}
		#endregion				
		
	}
}
