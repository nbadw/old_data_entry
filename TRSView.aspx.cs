//Version 1 = Temperature Data Site
//Version 2 = Stocking Data Site

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NBADWDataEntryApplication
{
	/// <summary>
	/// Summary description for TRSView.
	/// </summary>
	public partial class TRSView : System.Web.UI.Page
	{
		#region Controls
		//validation expressions and error messages
		//private string veDMSX = "[-]\\d\\d\\s\\d\\d\\s\\d\\d";//degrees minutes seconds
		//private string veDMSY = "\\d\\d\\s\\d\\d\\s\\d\\d";
		private string veDMSX = "[-]\\d\\d\\s\\d\\d\\s\\d\\d([.]{1}\\d{1,6}){0,1}";//degrees minutes seconds
		private string veDMSY = "\\d\\d\\s\\d\\d\\s\\d\\d([.]{1}\\d{1,6}){0,1}";//degrees minutes seconds
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
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected NBADWDataEntryApplication.dstblAquaticSite objdstblAquaticSite;
		protected NBADWDataEntryApplication.dstblAquaticSiteAgencyUse objdstblAquaticSiteAgencyUse;
		protected NBADWDataEntryApplication.dsWatersheds objdsWatersheds;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticSite;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticSiteAgencyUse;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaWatersheds;
		protected System.Data.DataView dvtblAquaticActivity;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblAquaticActivity;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		protected NBADWDataEntryApplication.dstblAquaticActivity objdstblAquaticActivity;
		protected System.Data.DataView dvtblAquaticSiteAgencyUse;
		#endregion
        			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				//dlstSystem.Items.Add(new ListItem(strItem, strValue)
				dlstsource.Items.Add(new ListItem("",""));
				dlstsource.Items.Add(new ListItem("GPS"));
				dlstsource.Items.Add(new ListItem("1:50,000 NTS topographic map"));
				dlstsource.Items.Add(new ListItem("GIS"));
				dlstsource.SelectedIndex = 0;
				/*
				dlstsystem.Items.Add(new ListItem("","12"));
				dlstsystem.Items.Add(new ListItem("NAD27","1"));
				dlstsystem.Items.Add(new ListItem("NAD83","2"));
				dlstsystem.Items.Add(new ListItem("WGS84","3"));
				dlstsystem.Items.Add(new ListItem("UTM-NAD27 ZONE 19","4"));
				dlstsystem.Items.Add(new ListItem("UTM-NAD27 ZONE20","5"));
				dlstsystem.Items.Add(new ListItem("UTM-NAD83 ZONE19","6"));
				dlstsystem.Items.Add(new ListItem("UTM-NAD83 ZONE20","7"));
				dlstsystem.Items.Add(new ListItem("UTM-WGS84 ZONE19","8"));
				dlstsystem.Items.Add(new ListItem("UTM-WGS84 ZONE20","9"));
				dlstsystem.Items.Add(new ListItem("ATS77 NB Stereographic","10"));
				dlstsystem.Items.Add(new ListItem("NAD83 (CSRS) NB Stereographic","11"));
				*/

				try
				{
					//Page Version
					switch ((int)Session["Version"])
					{
						case 20://temperature data site
						{
							lblMainHeading.Text = "WATER TEMPERATURES";
							lblType.Text = "temperature";
							lblDetails.Text = "Press the <b>Logger Details</b> button to view the list of loggers installed at this site.";
							lblTypeView.Text = "logger";
							btnLoggerDetails.Text = "Logger Details";
							break;
						}
						case 5://stocking data site
						{
							lblMainHeading.Text = "FISH STOCKING";
							lblType.Text = "stocking";
							lblDetails.Text = "Press the <b>Stocking Details</b> button to view the list of stocked fish at this site.";
							lblTypeView.Text = "stocking";
							btnLoggerDetails.Text = "Stocking Details";
							break;
						}
						case 2://electrofishing data site
						{
							lblMainHeading.Text = "ELECTROFISHING";
							lblType.Text = "electrofishing";
							lblDetails.Text = "Press the <b>Electrofishing Details</b> button to view a list of electrofishings at this site.";
							lblTypeView.Text = "electrofishing";
							btnLoggerDetails.Text = "Electrofishing Details";
							break;
						}
						default://unknown page format
						{
							lblMainHeading.Text = "UNKNOWN";
							break;
						}
					}
				}
				catch
				{
					Debug.WriteLine("Error with main heading");
				}
                
				try
				{
					#region View
					if(Session["Mode"].ToString()=="View")
					{
						//get site and populate fields
						LoadDataSet();
						DataTable tUse = objdstblAquaticSiteAgencyUse.tblAquaticSiteAgencyUse;
						DataRow UseRow = tUse.Rows.Find(Session["SelectedSiteUseID"]);
						Session["SelectedSiteID"] = UseRow["AquaticSiteID"];
						DataTable tSite = objdstblAquaticSite.Tables["tblAquaticSite"];
						DataRow SiteRow = tSite.Rows.Find(UseRow["AquaticSiteID"]);
						DataTable tWatersheds = objdsWatersheds._DE_Watersheds;
						DataRow WaterRow = tWatersheds.Rows.Find(SiteRow["WaterBodyID"]);
						SetValues(UseRow, SiteRow, WaterRow);
						if(!(bool)SiteRow["IncorporatedInd"])//site not incorporated
						{
							Session["SiteType"] = "New Site";
						}
						else if(!(bool)UseRow["IncorporatedInd"])//use not incorporated
						{
							Session["SiteType"] = "New Use";
						}
						else
						{
							Session["SiteType"] = "Existing";
						}
						Debug.WriteLine("From Load Site type is: "+Session["SiteType"].ToString());
						if(txtX.Text == "")//no x coordinate
						{
							btnMap.Visible = false;
						}
						try
						{
							if((bool)Session["Administrator"])
							{
								if(Session["SiteType"].ToString()!="Existing")
								{
									btnModify.Visible = true;
									btnDelete.Visible = true;
								}
							}
							else
							{
								//do nothing
							}
						}
						catch
						{
							//do nothing
						}
					}
					#endregion

					#region Modify
					if(Session["Mode"].ToString()=="Modify")
					{
						LoadDataSet();
						DataTable tUse = objdstblAquaticSiteAgencyUse.tblAquaticSiteAgencyUse;
						DataRow UseRow = tUse.Rows.Find(Session["SelectedSiteUseID"]);
						Session["SelectedSiteID"] = UseRow["AquaticSiteID"];
						DataTable tSite = objdstblAquaticSite.Tables["tblAquaticSite"];
						DataRow SiteRow = tSite.Rows.Find(UseRow["AquaticSiteID"]);
						DataTable tWatersheds = objdsWatersheds._DE_Watersheds;
						DataRow WaterRow = tWatersheds.Rows.Find(SiteRow["WaterBodyID"]);
						SetValues(UseRow, SiteRow, WaterRow);

						pnlInstructions.Visible = true;
						pnlViewBtns.Visible = false;
						pnlModifyBtns.Visible = true;
						btnSwitchSiteID.Visible=false;
						lblIndicator.Visible = true;
						lblLegend.Text = "Instructions";
						lblFormatX.Visible=true;
						lblFormatY.Visible=true;

						if(Session["SiteType"].ToString()=="New Site")
						{
							lblHeading.Text = "EDIT New Site";
							pnlView.Visible = false;
							pnlModifyNew.Visible = true;
							//site info
							btnSearchWaterbodyID.Visible=true;
							txtgroupsiteid.Visible=false;
							txtgroupsiteid2.Visible=true;
							txtwaterbodyid.Visible=false;
							txtwaterbodyid2.Visible=true;
							txtwaterbodyname.Visible=false;
							txtwaterbodyname2.Visible=true;
							txtwatershed.Visible=false;
							txtwatershed2.Visible=true;
							txtwatershedcode.Visible=false;
							txtwatershedcode2.Visible=true;
							txtsitename.Visible=false;
							txtsitename2.Visible=true;
							txtsitedescription.Visible=false;
							txtsitedescription2.Visible=true;

							txtgroupsiteid2.Text = txtgroupsiteid.Text;
							try
							{
								txtwaterbodyid2.Text = Session["SelectedWaterBodyID"].ToString();
								WaterRow = tWatersheds.Rows.Find(Session["SelectedWaterBodyID"].ToString());
								txtwaterbodyname2.Text = WaterRow["WaterBodyName"].ToString();
								txtwatershed2.Text = WaterRow["DrainName"].ToString();
								txtwatershedcode2.Text = WaterRow["DrainageCd"].ToString();
								Session["SelectedWaterBodyID"] = "";
							}
							catch(Exception ex/*System.NullReferenceException*/)
							{
								Debug.WriteLine("Error setting watervalues: "+ ex.ToString());
								txtwaterbodyid2.Text = txtwaterbodyid.Text;
								txtwaterbodyname2.Text = txtwaterbodyname.Text;
								txtwatershed2.Text = txtwatershed.Text;
								txtwatershedcode2.Text = txtwatershedcode.Text;
							}
								
							txtsitename2.Text = txtsitename.Text;
							txtsitedescription2.Text = txtsitedescription.Text;
				
							//coordinate
							txtsource.Visible=false;
							txtsystem.Visible=false;
							txtunits.Visible=false;
							dlstsource.Visible=true;
							dlstsystem.Visible=true;
							dlstunits.Visible=true;
							txtX.Visible=false;
							txtY.Visible=false;
							txtX2.Visible=true;
							txtY2.Visible=true;

							//SetCoordinateSource(txtsource.Text);
							SetCoordinateFields(txtsource.Text, txtsystem.Text, txtunits.Text);
							SetValidationFields();
							txtX2.Text=txtX.Text;
							txtY2.Text=txtY.Text;
						}
						else//new use
						{
							lblHeading.Text = "EDIT Site";
							pnlView.Visible = false;
							pnlModifyExisting.Visible = true;

							txtgroupsiteid.Visible=false;
							txtgroupsiteid2.Visible=true;

							txtgroupsiteid2.Text = txtgroupsiteid.Text;
						}
					}
					#endregion						

					#region Add New
					if(Session["Mode"].ToString()=="Add New")
					{
						Debug.WriteLine("Add New Mode");
						SetAddNewSettings();
						try
						{
							txtwaterbodyid2.Text = Session["SelectedWaterBodyID"].ToString();
							LoadDataSet();
							DataTable tWatersheds = objdsWatersheds._DE_Watersheds;
							DataRow WaterRow = tWatersheds.Rows.Find(Session["SelectedWaterBodyID"].ToString());
							txtwaterbodyname2.Text = WaterRow["WaterBodyName"].ToString();
							txtwatershed2.Text = WaterRow["DrainName"].ToString();
							txtwatershedcode2.Text = WaterRow["DrainageCd"].ToString();
						}
						catch(System.NullReferenceException)
						{
							txtwaterbodyid2.Text = txtwaterbodyid.Text;
							txtwaterbodyname2.Text = txtwaterbodyname.Text;
							txtwatershed2.Text = txtwatershed.Text;
							txtwatershedcode2.Text = txtwatershedcode.Text;
						}
					}
					#endregion

					#region Add Existing
					if(Session["Mode"].ToString()=="Add Existing")
					{
						Debug.WriteLine("Add Existing Mode");
						SetAddExistingSettings();

						//get site and populate fields
						LoadDataSet();
						DataTable tSite = objdstblAquaticSite.Tables["tblAquaticSite"];
						DataRow SiteRow = tSite.Rows.Find(Session["SelectedSiteID"]);
						Debug.WriteLine("Site  = "+SiteRow["AquaticSiteID"].ToString());
						DataTable tWatersheds = objdsWatersheds._DE_Watersheds;
						DataRow WaterRow = tWatersheds.Rows.Find(SiteRow["WaterBodyID"]);
						SetValues(SiteRow, SiteRow, WaterRow);
						if(txtX.Text == "")//no x coordinate
						{
							btnMap.Visible = false;
						}
					}				
					#endregion
				}
				catch (Exception ex)
				{
					Debug.WriteLine("No Mode: "+ex.ToString());
					//do nothing
					//page will display as View page with no data in fields
				}
			}

            btnMap.Visible = false;
		}


		#region Buttons
		protected void btnModify_Click(object sender, System.EventArgs e)
		{
			Session["Mode"]="Modify";
			pnlInstructions.Visible = true;
			pnlViewBtns.Visible = false;
			pnlModifyBtns.Visible = true;
			btnSwitchSiteID.Visible=false;
			lblLegend.Text = "Instructions";
			//btnMap.Visible = true;
			lblFormatX.Visible=true;
			lblFormatY.Visible=true;

			if(Session["SiteType"].ToString()=="New Site")
			{
				lblHeading.Text = "EDIT New Site";
				pnlView.Visible = false;
				pnlModifyNew.Visible = true;
				lblIndicator.Visible=true;
				//site info
				btnSearchWaterbodyID.Visible=true;
				txtgroupsiteid.Visible=false;
				txtgroupsiteid2.Visible=true;
				txtwaterbodyid.Visible=false;
				txtwaterbodyid2.Visible=true;
				txtwaterbodyname.Visible=false;
				txtwaterbodyname2.Visible=true;
				txtwatershed.Visible=false;
				txtwatershed2.Visible=true;
				txtwatershedcode.Visible=false;
				txtwatershedcode2.Visible=true;
				txtsitename.Visible=false;
				txtsitename2.Visible=true;
				txtsitedescription.Visible=false;
				txtsitedescription2.Visible=true;

				txtgroupsiteid2.Text = txtgroupsiteid.Text;
				txtwaterbodyid2.Text = txtwaterbodyid.Text;
				txtwaterbodyname2.Text = txtwaterbodyname.Text;
				txtwatershed2.Text = txtwatershed.Text;
				txtwatershedcode2.Text = txtwatershedcode.Text;
				txtsitename2.Text = txtsitename.Text;
				txtsitedescription2.Text = txtsitedescription.Text;
				
				//coordinate
				txtsource.Visible=false;
				txtsystem.Visible=false;
				txtunits.Visible=false;
				dlstsource.Visible=true;
				dlstsystem.Visible=true;
				dlstunits.Visible=true;
				txtX.Visible=false;
				txtY.Visible=false;
				txtX2.Visible=true;
				txtY2.Visible=true;

				//SetCoordinateSource(txtsource.Text);
				SetCoordinateFields(txtsource.Text, txtsystem.Text, txtunits.Text);
				SetValidationFields();

				txtX2.Text=txtX.Text;
				txtY2.Text=txtY.Text;
			}
			else//new use
			{
				lblHeading.Text = "EDIT Existing Site";
				pnlView.Visible = false;
				pnlModifyExisting.Visible = true;

				txtgroupsiteid.Visible=false;
				txtgroupsiteid2.Visible=true;

				txtgroupsiteid2.Text = txtgroupsiteid.Text;
			}

			//
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Session["Mode"].ToString()=="View" || Session["Mode"].ToString()=="Modify")
				{
					SetViewSettings();
				}
				else
				{
					Server.Transfer("TRSList.aspx");
				}
			}
			catch(System.NullReferenceException)
			{
				Server.Transfer("TRSList.aspx");
			}
		}

		protected void btnSearchSiteID_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "TRSView.aspx";
			Server.Transfer("TRSSearch.aspx");
		}

		protected void btnSwitchSiteID_Click(object sender, System.EventArgs e)
		{
			Session["SiteOnly"] = true;
			Session["PreviousPage"] = "TRSView.aspx";
			//Server.Transfer("TemperatureRecordingSites-Search.aspx");
			//Server.Transfer("BUMP.aspx");						
		}

		protected void btnMap_Click(object sender, System.EventArgs e)
		{
			if(txtsource.Visible)
			{
				try
				{
                    //Session["XCoord"] = txtX.Text;
                    //Session["YCoord"] = txtY.Text;
                    //Session["Units"] = txtunits.Text;
                    //Session["CoordSys"] = txtsystem.Text;
                    //Session["CoordSource"] = txtsource.Text;
                    ////Server.Transfer("Map.aspx");
                    //if(!IsStartupScriptRegistered("MapWindow"))
                    //{
                    //    Page.RegisterStartupScript("MapWindow","<script language='javascript' id='MapWindow'>window.open('Map.aspx');</script>");
                    //}
                    // XXX: uggh, am i really hardcoding this url?
                    //      have to do something to alleviate this later...
                    //      - colin 
                    string mapUrlFormat = "http://cri.nbwaters.unb.ca/map-staging/?legacy=true&x={0}&y={1}&srs={2}";
                    string mapUrl = String.Format(mapUrlFormat, txtX.Text, txtY.Text, txtsystem.Text);

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
			else
			{
				try
				{
                    //Session["XCoord"] = txtX2.Text;
                    //Session["YCoord"] = txtY2.Text;
                    //Session["Units"] = dlstunits.SelectedItem;
                    //Session["CoordSys"] = dlstsystem.SelectedItem;
                    //Session["CoordSource"] = dlstsource.SelectedItem;
                    ////Server.Transfer("Map.aspx");
                    //if(!IsStartupScriptRegistered("MapWindow"))
                    //{
                    //    Page.RegisterStartupScript("MapWindow","<script language='javascript' id='MapWindow'>window.open('Map.aspx');</script>");
                    //}

                    // XXX: uggh, am i really hardcoding this url?
                    //      have to do something to alleviate this later...
                    //      - colin 
                    string mapUrlFormat = "http://cri.nbwaters.unb.ca/map-staging/?legacy=true&x={0}&y={1}&srs={2}";
                    string mapUrl = String.Format(mapUrlFormat, txtX2.Text, txtY2.Text, dlstsystem.SelectedItem);

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
		}

		protected void btnLoggerDetails_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "TRSView.aspx";
			switch((int)Session["Version"])
			{
				case 20://thermistor
					Server.Transfer("TLDList.aspx");
					break;
				case 5://stocking
					Server.Transfer("STKList.aspx");
					break;
				case 2://electrofishing
					Server.Transfer("ELECTList.aspx");
					break;
			}
		}

		protected void btnClose_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("TRSList.aspx");
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			LoadActivityandUse();
			dvtblAquaticActivity.RowFilter="IncorporatedInd = false AND AquaticSiteID = "+txtdwsiteid.Text+" AND AquaticActivityCd = "+txtAquaticActivityCd.Text;
			Session["List"] = "TRSList.aspx";

			string sql;
			OleDbCommand cmd;

			try
			{
				if(dvtblAquaticActivity.Count==0)//no activities linked to this site
				{
					//use can be deleted
					sql = "DELETE FROM tblAquaticSiteAgencyUse WHERE AquaticSiteUseID = "+Session["SelectedSiteUseID"].ToString();
					oleDbConnection1.Open();
					cmd = new OleDbCommand(sql, oleDbConnection1);
					cmd.ExecuteNonQuery();
					oleDbConnection1.Close();										
				}
				else
				{
					Server.Transfer("ConfirmDeleteNo.aspx");
				}

				dvtblAquaticSiteAgencyUse.RowFilter = "AquaticSiteID = "+txtdwsiteid.Text;
				if(dvtblAquaticSiteAgencyUse.Count==1)//no other uses attached to this site
				//I check for 1 not 0 because I didn't reload dataset so this one still has 
				//at least the one record that we just deleted in the above procedure.
				{
					Debug.WriteLine("No other uses, delete site");
					sql = "DELETE FROM tblAquaticSite WHERE AquaticSiteID = "+txtdwsiteid.Text+" AND IncorporatedInd = false";
					oleDbConnection1.Open();
					cmd = new OleDbCommand(sql, oleDbConnection1);
					cmd.ExecuteNonQuery();
					oleDbConnection1.Close();	
					Session["DeleteMessage"] = "Site has been deleted";
					Server.Transfer("ConfirmDelete.aspx");
				}				
				else
				{
					Session["DeleteMessage"] = "Site is not longer set up for "+lblType.Text+" data";;
					Server.Transfer("ConfirmDelete.aspx");
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Error Deleting: "+ex.ToString());
				oleDbConnection1.Close();
				//Session["List"] = "TRSView.aspx";
				//Server.Transfer("ConfirmDeleteNo.aspx");
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				#region View / Modify
				if(Session["Mode"].ToString()=="View" || Session["Mode"].ToString() == "Modify")//Mode is View
				{
					//check what kind of site
					string strValues = "";
					if(txtgroupsiteid2.Text!="")
					{
						strValues += "AgencySiteID = '"+ txtgroupsiteid2.Text+"'";
					}
					else
					{
						strValues += "AgencySiteID = Null";
					}

					try
					{
						string sql = "UPDATE tblAquaticSiteAgencyUse SET "+strValues+" WHERE AquaticSiteUseID = "+Session["SelectedSiteUseID"].ToString();
						oleDbConnection1.Open();
						OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
						cmd.ExecuteNonQuery();
						oleDbConnection1.Close();
					}
					catch(System.Data.OleDb.OleDbException ex)
					{
						oleDbConnection1.Close();
						Debug.WriteLine("Error during site use update: "+ex.ToString());
					}

					if(Session["SiteType"].ToString()=="New Site")
					{
						//new site 
						strValues = "";
						strValues += "WaterBodyID = "+ txtwaterbodyid2.Text;
						if(txtwaterbodyname2.Text.Length!=0)
						{
							strValues += ", WaterBodyName = '"+ txtwaterbodyname2.Text+"'";
						}
						else
						{
							strValues += ", WaterBodyName = Null";
						}
						if(txtsitename2.Text!="")
						{
							strValues += ", AquaticSiteName = '"+ txtsitename2.Text+"'";
						}
						strValues += ", AquaticSiteDesc = '"+ txtsitedescription2.Text+"'";
						if(dlstsource.SelectedValue!="")
						{
							strValues += ", CoordinateSource = '" + dlstsource.SelectedItem+"'";
						}
						else
						{
							strValues+= ", CoordinateSource = null";
						}
						if(dlstsystem.SelectedValue!="12")
						{
							strValues += ", CoordinateSystem = '" + dlstsystem.SelectedItem+"'";
							strValues += ", CoordinateUnits = '" + dlstunits.SelectedItem+"'";
							strValues += ", XCoordinate = '" + txtX2.Text+"'";
							strValues += ", YCoordinate = '" + txtY2.Text+"'";
						}
						else
						{
							strValues += ", CoordinateSystem = null";
							strValues += ", CoordinateUnits = null";
							strValues += ", XCoordinate = null";
							strValues += ", YCoordinate = null";
						}
						
						try
						{
							Debug.WriteLine("String: "+strValues);
							string sql = "UPDATE tblAquaticSite SET "+strValues+" WHERE AquaticSiteID = "+Session["SelectedSiteID"].ToString();
							oleDbConnection1.Open();
							OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
							cmd.ExecuteNonQuery();
							oleDbConnection1.Close();
						}
						catch(System.Data.OleDb.OleDbException ex)
						{
							Debug.WriteLine("Error during site update: "+ex.ToString());
						}
					}
					Session["List"] = "TRSList.aspx";
					Server.Transfer("TRSList.aspx");
				}
				#endregion

				#region Add 
				else
				{
					try
					{
						if(Session["Mode"].ToString()=="Add New")
						{
							LoadDataSet();
							DataTable tSites = objdstblAquaticSite.Tables["tblAquaticSite"];
							DataRow rSites = tSites.NewRow();
						
							Debug.WriteLine("going to find biggest");
							int i = FindBiggest(tSites,"AquaticSiteID");
							Debug.WriteLine("int i:"+i);
							rSites["AquaticSiteID"] = i+1;
							txtdwsiteid.Text = rSites["AquaticSiteID"].ToString();
							rSites["WaterBodyID"] = txtwaterbodyid2.Text;
							rSites["WaterBodyName"] = txtwaterbodyname2.Text;
							rSites["DateEntered"] = System.DateTime.Now.ToShortDateString();
							if(txtsitename2.Text!="")
							{
								rSites["AquaticSiteName"] = txtsitename2.Text;
							}
							rSites["AquaticSiteDesc"] = txtsitedescription2.Text;
							if(dlstsource.SelectedValue!="")
							{
								rSites["CoordinateSource"] = dlstsource.SelectedItem;
							}
							if(dlstsystem.SelectedValue!="12")
							{
								rSites["CoordinateSystem"] = dlstsystem.SelectedItem;
								rSites["CoordinateUnits"] = dlstunits.SelectedItem;
								rSites["XCoordinate"] = txtX2.Text;
								rSites["YCoordinate"] = txtY2.Text;	
							}

							rSites["IncorporatedInd"] = false;

							tSites.Rows.Add(rSites);
									
							try
							{
								oleDbdatblAquaticSite.Update(objdstblAquaticSite);
							}
							catch (System.Data.OleDb.OleDbException eUpdate)
							{
								// Error during Update, add code to locate error, reconcile 
								// and try to update again.
								Debug.WriteLine("error updating site table:" + eUpdate);
							}
						}
					
						DataTable tSiteUse = objdstblAquaticSiteAgencyUse.Tables["tblAquaticSiteAgencyUse"];
						DataRow rSiteUse = tSiteUse.NewRow();
			
						rSiteUse["AquaticSiteID"] = txtdwsiteid.Text;
						rSiteUse["AgencyCd"] = txtagencycd.Text;
						if(txtgroupsiteid2.Text!="")
						{
							rSiteUse["AgencySiteID"] = txtgroupsiteid2.Text;
						}
						rSiteUse["AquaticActivityCd"] = Session["Version"].ToString();
						
						rSiteUse["IncorporatedInd"] = false;

						tSiteUse.Rows.Add(rSiteUse);
			
						try
						{
							oleDbConnection1.Open();
							oleDbdatblAquaticSiteAgencyUse.Update(objdstblAquaticSiteAgencyUse);
							OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", oleDbConnection1);
							Session["SelectedSiteUseID"] = idCMD.ExecuteScalar();
							oleDbConnection1.Close();
							Debug.WriteLine("New Use ID: "+Session["SelectedSiteUseID"].ToString());
							Session["Saved"] = true;
							Session["List"] = "TRSList.aspx";
							Server.Transfer("ConfirmSave.aspx");
						}
						catch (System.Data.OleDb.OleDbException eUpdate)
						{
							Debug.WriteLine("error creating new use:" + eUpdate);
						}
					}
					catch(Exception unknown)
					{
						Debug.WriteLine("Unknown Error: "+unknown.ToString());
					}
				}
				#endregion

				#region SiteID
				/*
				else//mode is siteid
				{
					try
					{
						string sql1 = "UPDATE tblAquaticSiteAgencyUse SET AquaticSiteID = "+txtdwsiteid.Text+" WHERE AquaticSiteUseID = "+Session["SelectedSiteUseID"].ToString();
						string sql2 = "UPDATE tblAquaticActivity SET AquaticSiteID = "+txtdwsiteid.Text+" WHERE AquaticSiteID = "+Session["SelectedSiteID"].ToString()+" and IncorporatedInd = false";
						oleDbConnection1.Open();
						OleDbCommand cmd1 = new OleDbCommand(sql1, oleDbConnection1);
						OleDbCommand cmd2 = new OleDbCommand(sql2, oleDbConnection1);
						cmd1.ExecuteNonQuery();
						cmd2.ExecuteNonQuery();
						oleDbConnection1.Close();
					}
					catch
					{
						Debug.WriteLine("Error during siteid change");
					}
				}*/
				#endregion
				
				//Server.Transfer("TRSList.aspx");
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Error in updates: "+ex.ToString());
				//Server.Transfer("TRSList.aspx");
			}
		}

		protected void btnSearchWaterbodyID_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "TRSView.aspx";	
			Server.Transfer("Waterbodies-Search.aspx");
		}
		#endregion

		#region Dropdown Lists & Text Changed
		protected void dlstunits_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetValidationFields();
		}

		protected void txtwaterbodyid2_TextChanged(object sender, System.EventArgs e)
		{
			try//this is just in case user leaves text box blank or enters a string
			{
				lblwbMessage.Visible=false;

				LoadDataSet();

				DataTable tWatersheds = objdsWatersheds._DE_Watersheds;
				DataRow WaterRow = tWatersheds.Rows.Find(txtwaterbodyid2.Text);
			
				
				if(WaterRow!=null)
				{
					txtwaterbodyname2.Text = WaterRow["WaterBodyName"].ToString();
					txtwatershed2.Text = WaterRow["DrainName"].ToString();
					txtwatershedcode2.Text = WaterRow["DrainageCd"].ToString();
				}
				else
				{
					lblwbMessage.Visible=true;
					txtwaterbodyid2.Text=txtwaterbodyid.Text;
				}
			}
			catch
			{
				lblwbMessage.Visible=true;
				txtwaterbodyid2.Text=txtwaterbodyid.Text;
			}
		}

		protected void dlstSource_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillSystemAndUnits(dlstsource.SelectedItem.ToString());		
		}

		private void fillSystemAndUnits(string src)
		{
			dlstsystem.Items.Clear();
			dlstunits.Items.Clear();

			switch (src)
			{
				case "GPS":
					dlstsystem.Items.Add(new ListItem("NAD83","2"));
					dlstsystem.Items.Add(new ListItem("WGS84","3"));
					dlstsystem.SelectedIndex = dlstsystem.Items.Count-1;

					dlstunits.Items.Add(new ListItem("Degrees Minutes Seconds","DMS"));
					dlstunits.Items.Add(new ListItem("Degrees Decimal Minutes","DDM"));
					dlstunits.Items.Add(new ListItem("Decimal Degrees","DD"));
					dlstunits.SelectedIndex = 0;

					lblX.Text = "Longitude:";
					lblY.Text = "Latitude:";

					SetValidationFields();
					break;
				case "1:50,000 NTS topographic map":
					dlstsystem.Items.Add(new ListItem("UTM-NAD27 ZONE 19","4"));
					dlstsystem.Items.Add(new ListItem("UTM-NAD27 ZONE 20","5"));
					dlstsystem.Items.Add(new ListItem("UTM-NAD83 ZONE 19","6"));
					dlstsystem.Items.Add(new ListItem("UTM-NAD83 ZONE 20","7"));
					dlstsystem.SelectedIndex = 0;

					dlstunits.Items.Add(new ListItem("Meters","M"));
					dlstunits.SelectedIndex = 0;

					lblX.Text = "Easting:";
					lblY.Text = "Northing:";

					SetValidationFields();
					break;
				case "GIS":
					dlstsystem.Items.Add(new ListItem("ATS77 NB Stereographic","10"));
					dlstsystem.Items.Add(new ListItem("NAD83 (CSRS) NB Stereographic","11"));
					dlstsystem.SelectedIndex = 1;

					dlstunits.Items.Add(new ListItem("Meters","M"));
					dlstunits.SelectedIndex = 0;

					lblX.Text = "X:";
					lblY.Text = "Y:";	

					SetValidationFields();
					break;
				default:
					dlstsystem.Items.Clear();
					dlstunits.Items.Clear();
					break;
			}
		}     

		#endregion

		#region Fill & Load
		public void FillDataSet(NBADWDataEntryApplication.dstblAquaticSite dataSet1, NBADWDataEntryApplication.dstblAquaticSiteAgencyUse dataSet2, NBADWDataEntryApplication.dsWatersheds dataSet3)
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
				this.oleDbdatblAquaticSite.Fill(dataSet1);
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
			NBADWDataEntryApplication.dstblAquaticSiteAgencyUse objDataSetTemp2;
			NBADWDataEntryApplication.dsWatersheds objDataSetTemp3;
			objDataSetTemp1 = new NBADWDataEntryApplication.dstblAquaticSite();
			objDataSetTemp2 = new NBADWDataEntryApplication.dstblAquaticSiteAgencyUse();
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
				objdstblAquaticSite.Clear();
				objdstblAquaticSiteAgencyUse.Clear();
				objdsWatersheds.Clear();

				// Merge the records into the main dataset.
				objdstblAquaticSite.Merge(objDataSetTemp1);
				objdstblAquaticSiteAgencyUse.Merge(objDataSetTemp2);
				objdsWatersheds.Merge(objDataSetTemp3);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void FillActivityandUse(NBADWDataEntryApplication.dstblAquaticSiteAgencyUse dataSet1, NBADWDataEntryApplication.dstblAquaticActivity dataSet2)
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
				this.oleDbdatblAquaticSiteAgencyUse.Fill(dataSet1);
				this.oleDbdatblAquaticActivity.Fill(dataSet2);
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

		public void LoadActivityandUse()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblAquaticSiteAgencyUse objDataSetTemp1;
			NBADWDataEntryApplication.dstblAquaticActivity objDataSetTemp2;
			objDataSetTemp1 = new NBADWDataEntryApplication.dstblAquaticSiteAgencyUse();
			objDataSetTemp2 = new NBADWDataEntryApplication.dstblAquaticActivity();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillActivityandUse(objDataSetTemp1, objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblAquaticSiteAgencyUse.Clear();
				objdstblAquaticActivity.Clear();

				// Merge the records into the main dataset.
				objdstblAquaticSiteAgencyUse.Merge(objDataSetTemp1);
				objdstblAquaticActivity.Merge(objDataSetTemp2);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		#endregion       	

		#region Set Coordinate Information
		/*		private void SetCoordinateSource(string cSource)
				{
					switch (cSource)
					{
						case "GPS":
							dlstsource.SelectedIndex = 1;
							break;
						case "1:50,000 NTS topographic map":
							dlstsource.SelectedIndex = 2;
							break;
						case "GIS":
							dlstsource.SelectedIndex = 3;
							break;
						default:
							dlstsource.SelectedIndex = 0;
							break;
					}
				}

				private void SetCoordinateFields(string cSystem)
				{
					//set the selected index of the system list
					switch (cSystem)
					{
						case "NAD27":
							dlstsystem.SelectedIndex = 1;
							break;
						case "NAD83":
							dlstsystem.SelectedIndex = 2;
							break;
						case "WGS84":
							dlstsystem.SelectedIndex = 3;
							break;
						case "UTM-NAD27 ZONE 19":
							dlstsystem.SelectedIndex = 4;
							break;
						case "UTM-NAD27 ZONE20":
							dlstsystem.SelectedIndex = 5;
							break;
						case "UTM-NAD83 ZONE19":
							dlstsystem.SelectedIndex = 6;
							break;
						case "UTM-NAD83 ZONE20":
							dlstsystem.SelectedIndex = 7;
							break;
						case "UTM-WGS84 ZONE19":
							dlstsystem.SelectedIndex = 8;
							break;
						case "UTM-WGS84 ZONE20":
							dlstsystem.SelectedIndex = 9;
							break;
						case "ATS77 NB Stereographic":
							dlstsystem.SelectedIndex = 10;
							break;
						case "NAD83 (CSRS) NB Stereographic":
							dlstsystem.SelectedIndex = 11;
							break;
						default:
							dlstsystem.SelectedIndex = 0;
							break;
					}

					int s = Convert.ToInt32(dlstsystem.SelectedValue);
					dlstunits.Items.Clear();
			
					//Geographic
					if (s<4)
					{
						dlstunits.Items.Add(new ListItem("Degrees Minutes Seconds","DMS"));
						dlstunits.Items.Add(new ListItem("Degrees Decimal Minutes","DDM"));
						dlstunits.Items.Add(new ListItem("Decimal Degrees","DD"));
						dlstunits.SelectedIndex = 0;

						lblX.Text = "Longitude:";
						lblY.Text = "Latitude:";

						SetValidationFields();
					}
					//Projected
					else if (s<12)
					{
						dlstunits.Items.Add(new ListItem("Meters","M"));
						dlstunits.SelectedIndex = 0;

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

		private void SetCoordinateFields(string strSource, string strSystem, string strUnits)
		{
			fillSystemAndUnits(strSource);
			switch (strSource)
			{
				case "GPS":
					dlstsource.SelectedIndex=1;
				switch (strSystem)
				{
					case "NAD83":
						dlstsystem.SelectedIndex=0;
						break;
					case "WGS84":
						dlstsystem.SelectedIndex=1;
						break;
				}
				switch (strUnits)
				{
					case "Degrees Minutes Seconds":
						dlstunits.SelectedIndex=0;
						break;
					case "Degrees Decimal Minutes":
						dlstunits.SelectedIndex=1;
						break;
					case "Decimal Degrees":
						dlstunits.SelectedIndex=2;
						break;
				}
					break;
				case "1:50,000 NTS topographic map":
					dlstsource.SelectedIndex=2;
				switch (strSystem)
				{
					case "UTM-NAD27 ZONE 19":
						dlstsystem.SelectedIndex=0;
						break;
					case "UTM-NAD27 ZONE 20":
						dlstsystem.SelectedIndex=1;
						break;
					case "UTM-NAD83 ZONE 19":
						dlstsystem.SelectedIndex=2;
						break;
					case "UTM-NAD83 ZONE 20":
						dlstsystem.SelectedIndex=3;
						break;
				}
					break;
				case "GIS":
					dlstsource.SelectedIndex=3;
				switch (strSystem)
				{
					case "ATS77 NB Stereographic":
						dlstsystem.SelectedIndex=0;
						break;
					case "NAD83 (CSRS) NB Stereographic":
						dlstsystem.SelectedIndex=1;
						break;
				}
					break;				
			}
		}

		private void SetValidationFields()
		{
			ClearXY();
			string s = dlstunits.SelectedValue;	
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
				lblFormatX.Text=emM;
				revY.ErrorMessage = emM;
				revY.ValidationExpression = veM;
				lblFormatY.Text=emM;
			}
		}
		

		private void ClearXY()
		{
			/*validation won't be done on text already entered so we must clear 
			fields to ensure they are validated ie. if user enters data in txtX 
			or txtY and then changes the units, validation will not be done with
			the new rules*/
			txtX2.Text = "";
			txtY2.Text = "";
		}
		#endregion

		#region Set Page Mode
		private void SetViewSettings()
		{
			//Heading
			if((bool)(Session["Administrator"]))
			{
				switch(Session["SiteType"].ToString())
				{
					case "New Site":
						lblHeading.Text = "VIEW New Site";
						break;
					case "New Use":
						lblHeading.Text = "VIEW Existing Site";
						break;
					default:
						lblHeading.Text = "VIEW Site";
						break;
				}
			}
			else
			{
				lblHeading.Text = "VIEW Site";
			}
			
			//Instruction
			lblLegend.Text="Instructions";
			//Remove top panels
			lblIndicator.Visible=false;
			pnlReplace.Visible=false;
			pnlInstructions.Visible=true;
			pnlView.Visible = true;
			pnlAddExisting.Visible=false;
			pnlAddNew.Visible=false;
			pnlModifyExisting.Visible=false;
			pnlModifyNew.Visible=false;
			//site info
			btnSearchSiteID.Visible=false;
			btnSearchWaterbodyID.Visible=false;
			txtdwsiteid.Visible=true;
			txtdwsiteid2.Visible=false;			
			txtgroupsiteid.Visible=true;
			txtgroupsiteid2.Visible=false;
			txtwaterbodyid.Visible=true;
			txtwaterbodyid2.Visible=false;
			txtwaterbodyname.Visible=true;
			txtwaterbodyname2.Visible=false;
			txtwatershed.Visible=true;
			txtwatershed2.Visible=false;
			txtwatershedcode.Visible=true;
			txtwatershedcode2.Visible=false;
			txtsitename.Visible=true;
			txtsitename2.Visible=false;
			txtsitedescription.Visible=true;
			txtsitedescription2.Visible=false;

			//coordinates
			if(txtX.Text == "")//no x coordinate
			{
				btnMap.Visible = false;
			}
			dlstsource.Visible=false;
			dlstsystem.Visible=false;
			dlstunits.Visible=false;
			txtsource.Visible=true;
			txtsystem.Visible=true;
			txtunits.Visible=true;
			txtX.Visible=true;
			txtY.Visible=true;
			txtX2.Visible=false;
			txtY2.Visible=false;
			lblFormatX.Visible=false;
			lblFormatY.Visible=false;
			//bottom buttons
			pnlModifyBtns.Visible=false;
			pnlViewBtns.Visible=true;
		}

		private void SetSiteIDSettings()
		{
			//Heading
			lblHeading.Text="EDIT SITE - Change Site ID";
			//top panels
			pnlReplace.Visible=true;
			pnlInstructions.Visible=false;
			pnlView.Visible = false;
			pnlAddExisting.Visible=false;
			pnlAddNew.Visible=false;
			pnlModifyExisting.Visible=false;
			pnlModifyNew.Visible=false;
			//site info
			btnSearchSiteID.Visible=true;
			btnSwitchSiteID.Visible=false;
			btnSearchWaterbodyID.Visible=false;
			txtdwsiteid.Visible=true;
			txtdwsiteid2.Visible=false;			
			txtgroupsiteid.Visible=true;
			txtgroupsiteid2.Visible=false;
			txtwaterbodyid.Visible=true;
			txtwaterbodyid2.Visible=false;
			txtwaterbodyname.Visible=true;
			txtwaterbodyname2.Visible=false;
			txtwatershed.Visible=true;
			txtwatershed2.Visible=false;
			txtwatershedcode.Visible=true;
			txtwatershedcode2.Visible=false;
			txtsitename.Visible=true;
			txtsitename2.Visible=false;
			txtsitedescription.Visible=true;
			txtsitedescription2.Visible=false;
			//coordinates
			dlstsource.Visible=false;
			dlstsystem.Visible=false;
			dlstunits.Visible=false;
			txtsource.Visible=true;
			txtsystem.Visible=true;
			txtunits.Visible=true;
			txtX.Visible=true;
			txtY.Visible=true;
			txtX2.Visible=false;
			txtY2.Visible=false;
			lblFormatX.Visible=false;
			lblFormatY.Visible=false;
			//bottom buttons
			pnlModifyBtns.Visible=true;
			pnlViewBtns.Visible=false;
		}

		private void SetAddNewSettings()
		{
			//Heading
			lblHeading.Text="ADD New Site";
			//Instruction
			lblLegend.Text="Instructions";
			//Remove top panels
			lblIndicator.Visible=true;
			pnlReplace.Visible=false;
			pnlInstructions.Visible=true;
			pnlView.Visible = false;
			pnlAddExisting.Visible=false;
			pnlAddNew.Visible=true;
			pnlModifyExisting.Visible=false;
			pnlModifyNew.Visible=false;
			//site info
			btnSearchSiteID.Visible=false;
			btnSwitchSiteID.Visible=false;
			btnSearchWaterbodyID.Visible=true;

			lbldwsiteid.Visible=false;

			txtdwsiteid.Visible=false;
			txtdwsiteid2.Visible=false;			
			txtgroupsiteid.Visible=false;
			txtgroupsiteid2.Visible=true;
			txtwaterbodyid.Visible=false;
			txtwaterbodyid2.Visible=true;
			txtwaterbodyname.Visible=false;
			txtwaterbodyname2.Visible=true;
			txtwatershed.Visible=false;
			txtwatershed2.Visible=true;
			txtwatershedcode.Visible=false;
			txtwatershedcode2.Visible=true;
			txtsitename.Visible=false;
			txtsitename2.Visible=true;
			txtsitedescription.Visible=false;
			txtsitedescription2.Visible=true;

			//coordinates
			btnMap.Visible = true;
			dlstsource.Visible=true;
			dlstsystem.Visible=true;
			dlstunits.Visible=true;
			txtsource.Visible=false;
			txtsystem.Visible=false;
			txtunits.Visible=false;
			txtX.Visible=false;
			txtY.Visible=false;
			txtX2.Visible=true;
			txtY2.Visible=true;
			lblFormatX.Visible=true;
			lblFormatY.Visible=true;
			//bottom buttons
			pnlModifyBtns.Visible=true;
			pnlViewBtns.Visible=false;

			txtagencycd.Text = Session["UserAgency"].ToString();
		}

		private void SetAddExistingSettings()
		{
			//Heading
			lblHeading.Text="ADD New Data to Existing Site";
			//Instruction
			lblLegend.Text="Instructions";
			//Remove top panels
			lblIndicator.Visible=false;
			pnlReplace.Visible=false;
			pnlInstructions.Visible=true;
			pnlView.Visible = false;
			pnlAddExisting.Visible=true;
			pnlAddNew.Visible=false;
			pnlModifyExisting.Visible=false;
			pnlModifyNew.Visible=false;
			//site info
			btnSearchSiteID.Visible=false;
			btnSwitchSiteID.Visible=false;
			btnSearchWaterbodyID.Visible=false;
			btnSearchWaterbodyID.Visible=false;
			txtdwsiteid.Visible=true;
			txtdwsiteid2.Visible=false;			
			txtgroupsiteid.Visible=false;
			txtgroupsiteid2.Visible=true;
			txtwaterbodyid.Visible=true;
			txtwaterbodyid2.Visible=false;
			txtwaterbodyname.Visible=true;
			txtwaterbodyname2.Visible=false;
			txtwatershed.Visible=true;
			txtwatershed2.Visible=false;
			txtwatershedcode.Visible=true;
			txtwatershedcode2.Visible=false;
			txtsitename.Visible=true;
			txtsitename2.Visible=false;
			txtsitedescription.Visible=true;
			txtsitedescription2.Visible=false;

			//coordinates
			btnMap.Visible = true;
			dlstsource.Visible=false;
			dlstsystem.Visible=false;
			dlstunits.Visible=false;
			txtsource.Visible=true;
			txtsystem.Visible=true;
			txtunits.Visible=true;
			txtX.Visible=true;
			txtY.Visible=true;
			txtX2.Visible=false;
			txtY2.Visible=false;
			lblFormatX.Visible=false;
			lblFormatY.Visible=false;
			//bottom buttons
			pnlModifyBtns.Visible=true;
			pnlViewBtns.Visible=false;
		}

		#endregion

		#region Set Values
		public void SetValues(DataRow UseRow, DataRow SiteRow, DataRow WaterRow)
		{			
			txtdwsiteid.Text = SiteRow["AquaticSiteID"].ToString();
			
			if(!(Session["Mode"].ToString()== "Add Existing"))//mode is view /modify
			{
				txtAquaticActivityCd.Text = UseRow["AquaticActivityCd"].ToString();
				txtgroupsiteid.Text = UseRow["AgencySiteID"].ToString();
				txtagencycd.Text = UseRow["AgencyCd"].ToString();
			}
			else//mode is add
			{
				txtAquaticActivityCd.Text = Session["Version"].ToString();//water temperature monitoring
				txtagencycd.Text = Session["UserAgency"].ToString();
			}
			txtwaterbodyid.Text = SiteRow["WaterBodyID"].ToString();
			txtwaterbodyname.Text = SiteRow["WaterBodyName"].ToString();
			txtwatershed.Text = WaterRow["DrainName"].ToString();
			txtwatershedcode.Text = WaterRow["DrainageCd"].ToString();
			txtsitename.Text = SiteRow["AquaticSiteName"].ToString();
			txtsitedescription.Text = SiteRow["AquaticSiteDesc"].ToString();
			txtsource.Text = SiteRow["CoordinateSource"].ToString();
			txtsystem.Text = SiteRow["CoordinateSystem"].ToString();
			txtunits.Text = SiteRow["CoordinateUnits"].ToString();
			txtX.Text = SiteRow["XCoordinate"].ToString();
			txtY.Text = SiteRow["YCoordinate"].ToString();
			
			switch (SiteRow["CoordinateSystem"].ToString())
			{
				case "NAD27":
				case "NAD83":
				case "WGS84":
					lblX.Text = "Latitude:";
					lblY.Text = "Longitude:";
					break;
				case "UTM-NAD27 ZONE 19":
				case "UTM-NAD27 ZONE 20":
				case "UTM-NAD83 ZONE 19":
				case "UTM-NAD83 ZONE 20":
				case "UTM-WGS84 ZONE 19":
				case "UTM-WGS84 ZONE 20":
					lblX.Text = "Easting:";
					lblY.Text = "Northing:";
					break;
				case "ATS77 NB Stereographic":
				case "NAD83 (CSRS) NB Stereographic":
					lblX.Text = "X:";
					lblY.Text = "Y:";
					break;
				default:
					lblX.Text = "Latitude:";
					lblY.Text = "Longitude:";
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
			this.oleDbdatblAquaticSite = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdatblAquaticSiteAgencyUse = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdaWatersheds = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdstblAquaticSite = new NBADWDataEntryApplication.dstblAquaticSite();
			this.objdstblAquaticSiteAgencyUse = new NBADWDataEntryApplication.dstblAquaticSiteAgencyUse();
			this.objdsWatersheds = new NBADWDataEntryApplication.dsWatersheds();
			this.dvtblAquaticActivity = new System.Data.DataView();
			this.oleDbdatblAquaticActivity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdstblAquaticActivity = new NBADWDataEntryApplication.dstblAquaticActivity();
			this.dvtblAquaticSiteAgencyUse = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticSite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticSiteAgencyUse)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsWatersheds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblAquaticActivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblAquaticSiteAgencyUse)).BeginInit();
			// 
			// oleDbdatblAquaticSite
			// 
			this.oleDbdatblAquaticSite.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbdatblAquaticSite.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbdatblAquaticSite.SelectCommand = this.oleDbSelectCommand1;
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
			this.oleDbdatblAquaticSite.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM tblAquaticSite WHERE (AquaticSiteID = ?) AND (AquaticSiteDesc = ? OR ? IS NULL AND AquaticSiteDesc IS NULL) AND (AquaticSiteName = ? OR ? IS NULL AND AquaticSiteName IS NULL) AND (CoordinateSource = ? OR ? IS NULL AND CoordinateSource IS NULL) AND (CoordinateSystem = ? OR ? IS NULL AND CoordinateSystem IS NULL) AND (CoordinateUnits = ? OR ? IS NULL AND CoordinateUnits IS NULL) AND (DateEntered = ? OR ? IS NULL AND DateEntered IS NULL) AND (EndDesc = ? OR ? IS NULL AND EndDesc IS NULL) AND (EndRouteMeas = ? OR ? IS NULL AND EndRouteMeas IS NULL) AND (GeoReferencedInd = ? OR ? IS NULL AND GeoReferencedInd IS NULL) AND (HabitatDesc = ? OR ? IS NULL AND HabitatDesc IS NULL) AND (IncorporatedInd = ?) AND (ReachNo = ? OR ? IS NULL AND ReachNo IS NULL) AND (RiverSystemID = ? OR ? IS NULL AND RiverSystemID IS NULL) AND (SpecificSiteInd = ? OR ? IS NULL AND SpecificSiteInd IS NULL) AND (StartDesc = ? OR ? IS NULL AND StartDesc IS NULL) AND (StartRouteMeas = ? OR ? IS NULL AND StartRouteMeas IS NULL) AND (WaterBodyID = ? OR ? IS NULL AND WaterBodyID IS NULL) AND (WaterBodyName = ? OR ? IS NULL AND WaterBodyName IS NULL) AND (XCoordinate = ? OR ? IS NULL AND XCoordinate IS NULL) AND (YCoordinate = ? OR ? IS NULL AND YCoordinate IS NULL) AND (oldAquaticSiteID = ? OR ? IS NULL AND oldAquaticSiteID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc1", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
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
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO tblAquaticSite(AquaticSiteDesc, AquaticSiteID, AquaticSiteName, CoordinateSource, CoordinateSystem, CoordinateUnits, DateEntered, EndDesc, EndRouteMeas, GeoReferencedInd, HabitatDesc, IncorporatedInd, oldAquaticSiteID, ReachNo, RiverSystemID, SpecificSiteInd, StartDesc, StartRouteMeas, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "EndDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "EndRouteMeas"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, "GeoReferencedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReachNo", System.Data.OleDb.OleDbType.Integer, 0, "ReachNo"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, "RiverSystemID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, "SpecificSiteInd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "StartDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "StartRouteMeas"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT AquaticSiteDesc, AquaticSiteID, AquaticSiteName, CoordinateSource, CoordinateSystem, CoordinateUnits, DateEntered, EndDesc, EndRouteMeas, GeoReferencedInd, HabitatDesc, IncorporatedInd, oldAquaticSiteID, ReachNo, RiverSystemID, SpecificSiteInd, StartDesc, StartRouteMeas, WaterBodyID, WaterBodyName, XCoordinate, YCoordinate FROM tblAquaticSite";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblAquaticSite SET AquaticSiteDesc = ?, AquaticSiteID = ?, AquaticSiteName" +
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
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSource"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateSystem"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, "CoordinateUnits"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "EndDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "EndRouteMeas"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, "GeoReferencedInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, "HabitatDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReachNo", System.Data.OleDb.OleDbType.Integer, 0, "ReachNo"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, "RiverSystemID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, "SpecificSiteInd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, "StartDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, "StartRouteMeas"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "XCoordinate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, "YCoordinate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteDesc1", System.Data.OleDb.OleDbType.VarWChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteName1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSource1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSource", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateSystem1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateSystem", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CoordinateUnits1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoordinateUnits", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GeoReferencedInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GeoReferencedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_HabitatDesc1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HabitatDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReachNo1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReachNo", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RiverSystemID1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RiverSystemID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SpecificSiteInd1", System.Data.OleDb.OleDbType.VarWChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SpecificSiteInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDesc1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDesc", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartRouteMeas1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartRouteMeas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterBodyName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterBodyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_XCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "XCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YCoordinate1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YCoordinate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbdatblAquaticSiteAgencyUse
			// 
			this.oleDbdatblAquaticSiteAgencyUse.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbdatblAquaticSiteAgencyUse.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdatblAquaticSiteAgencyUse.SelectCommand = this.oleDbSelectCommand2;
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
			this.oleDbdatblAquaticSiteAgencyUse.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM tblAquaticSiteAgencyUse WHERE (AquaticSiteUseID = ?) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AgencySiteID = ? OR ? IS NULL AND AgencySiteID IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (AquaticSiteType = ? OR ? IS NULL AND AquaticSiteType IS NULL) AND (EndYear = ? OR ? IS NULL AND EndYear IS NULL) AND (IncorporatedInd = ?) AND (StartYear = ? OR ? IS NULL AND StartYear IS NULL) AND (YearsActive = ? OR ? IS NULL AND YearsActive IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteUseID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteUseID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tblAquaticSiteAgencyUse(AgencyCd, AgencySiteID, AquaticActivityCd, Aq" +
				"uaticSiteID, AquaticSiteType, EndYear, IncorporatedInd, StartYear, YearsActive) " +
				"VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticSiteType"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, "YearsActive"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivityCd, AquaticSiteID, AquaticSiteType," +
				" AquaticSiteUseID, EndYear, IncorporatedInd, StartYear, YearsActive FROM tblAqua" +
				"ticSiteAgencyUse";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE tblAquaticSiteAgencyUse SET AgencyCd = ?, AgencySiteID = ?, AquaticActivityCd = ?, AquaticSiteID = ?, AquaticSiteType = ?, EndYear = ?, IncorporatedInd = ?, StartYear = ?, YearsActive = ? WHERE (AquaticSiteUseID = ?) AND (AgencyCd = ? OR ? IS NULL AND AgencyCd IS NULL) AND (AgencySiteID = ? OR ? IS NULL AND AgencySiteID IS NULL) AND (AquaticActivityCd = ? OR ? IS NULL AND AquaticActivityCd IS NULL) AND (AquaticSiteID = ? OR ? IS NULL AND AquaticSiteID IS NULL) AND (AquaticSiteType = ? OR ? IS NULL AND AquaticSiteType IS NULL) AND (EndYear = ? OR ? IS NULL AND EndYear IS NULL) AND (IncorporatedInd = ?) AND (StartYear = ? OR ? IS NULL AND StartYear IS NULL) AND (YearsActive = ? OR ? IS NULL AND YearsActive IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, "AquaticSiteType"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, "EndYear"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, "StartYear"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, "YearsActive"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteUseID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteUseID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencySiteID1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencySiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteType1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartYear1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartYear", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_YearsActive1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "YearsActive", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbdaWatersheds
			// 
			this.oleDbdaWatersheds.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdaWatersheds.SelectCommand = this.oleDbSelectCommand3;
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
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO [DE-Watersheds] (DrainageCd, DrainName, Level1Name, Level2Name, Level" +
				"3Name, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainName", System.Data.OleDb.OleDbType.VarWChar, 255, "DrainName"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level1Name", System.Data.OleDb.OleDbType.VarWChar, 40, "Level1Name"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level2Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level2Name"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level3Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level3Name"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT DrainageCd, DrainName, Level1Name, Level2Name, Level3Name, WaterBodyID, Wa" +
				"terBodyName FROM [DE-Watersheds]";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// objdstblAquaticSite
			// 
			this.objdstblAquaticSite.DataSetName = "dstblAquaticSite";
			this.objdstblAquaticSite.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// objdstblAquaticSiteAgencyUse
			// 
			this.objdstblAquaticSiteAgencyUse.DataSetName = "dstblAquaticSiteAgencyUse";
			this.objdstblAquaticSiteAgencyUse.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// objdsWatersheds
			// 
			this.objdsWatersheds.DataSetName = "dsWatersheds";
			this.objdsWatersheds.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblAquaticActivity
			// 
			this.dvtblAquaticActivity.Table = this.objdstblAquaticActivity.tblAquaticActivity;
			// 
			// oleDbdatblAquaticActivity
			// 
			this.oleDbdatblAquaticActivity.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbdatblAquaticActivity.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdatblAquaticActivity.SelectCommand = this.oleDbSelectCommand4;
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
			this.oleDbdatblAquaticActivity.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = @"SELECT Agency2Cd, AgencyCd, AquaticActivityCd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityID, AquaticActivityLeader, AquaticActivityStartDate, AquaticActivityStartTime, AquaticMethodCd, AquaticProgramID, AquaticSiteID, Comments, Crew, DateEntered, IncorporatedInd, OldAquaticActivityID, oldAquaticSiteID, PrimaryActivityInd, project, Siltation, WaterLevel, WaterLevel_AM_cm, WaterLevel_cm, WaterLevel_PM_cm, WeatherConditions, Year FROM tblAquaticActivity";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = @"INSERT INTO tblAquaticActivity(Agency2Cd, AgencyCd, AquaticActivityCd, AquaticActivityEndDate, AquaticActivityEndTime, AquaticActivityID, AquaticActivityLeader, AquaticActivityStartDate, AquaticActivityStartTime, AquaticMethodCd, AquaticProgramID, AquaticSiteID, Comments, Crew, DateEntered, IncorporatedInd, OldAquaticActivityID, oldAquaticSiteID, PrimaryActivityInd, project, Siltation, WaterLevel, WaterLevel_AM_cm, WaterLevel_cm, WaterLevel_PM_cm, WeatherConditions, Year) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityEndDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityEndTime"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivityLeader"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticProgramID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "OldAquaticActivityID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, "PrimaryActivityInd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("project", System.Data.OleDb.OleDbType.VarWChar, 50, "project"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, "Siltation"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, "WaterLevel"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_AM_cm"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_cm"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_PM_cm"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, "WeatherConditions"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Year", System.Data.OleDb.OleDbType.VarWChar, 4, "Year"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE tblAquaticActivity SET Agency2Cd = ?, AgencyCd = ?, AquaticActivityCd = ?," +
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
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, "Agency2Cd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityEndDate"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityEndTime"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivityLeader"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, "AquaticActivityStartDate"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, "AquaticActivityStartTime"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticMethodCd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticProgramID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 250, "Comments"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Crew", System.Data.OleDb.OleDbType.VarWChar, 50, "Crew"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, "DateEntered"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, "IncorporatedInd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "OldAquaticActivityID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "oldAquaticSiteID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, "PrimaryActivityInd"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("project", System.Data.OleDb.OleDbType.VarWChar, 50, "project"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, "Siltation"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, "WaterLevel"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_AM_cm"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_cm"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterLevel_PM_cm"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, "WeatherConditions"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Year", System.Data.OleDb.OleDbType.VarWChar, 4, "Year"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryActivityInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_project", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "project", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_project1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "project", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM tblAquaticActivity WHERE (AquaticActivityID = ?) AND (Agency2Cd = ? O" +
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
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency2Cd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency2Cd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityEndTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityEndTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityLeader1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartDate1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityStartTime1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityStartTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticMethodCd1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticMethodCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticProgramID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticProgramID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Comments1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Crew1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Crew", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateEntered", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateEntered", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncorporatedInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncorporatedInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldAquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldAquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryActivityInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryActivityInd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Siltation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Siltation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_AM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_AM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_PM_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_PM_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WaterLevel_cm1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WaterLevel_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeatherConditions1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeatherConditions", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Year1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Year", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_oldAquaticSiteID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "oldAquaticSiteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_project", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "project", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_project1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "project", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblAquaticActivity
			// 
			this.objdstblAquaticActivity.DataSetName = "dstblAquaticActivity";
			this.objdstblAquaticActivity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblAquaticSiteAgencyUse
			// 
			this.dvtblAquaticSiteAgencyUse.Table = this.objdstblAquaticSiteAgencyUse.tblAquaticSiteAgencyUse;
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticSite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticSiteAgencyUse)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsWatersheds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblAquaticActivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblAquaticActivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblAquaticSiteAgencyUse)).EndInit();

		}
		#endregion		
		
		
		public int FindBiggest(DataTable t,string field)
		{
			Debug.WriteLine("Arrived at find biggest");
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
	}
}
