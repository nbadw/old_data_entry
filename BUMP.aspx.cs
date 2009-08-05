using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Access = Microsoft.Office.Interop.Access;
using Excel = Microsoft.Office.Interop.Excel;

namespace NBADWDataEntryApplication
{
	/// <summary>
	/// Summary description for BUMP.
	/// </summary>
	public partial class BUMP : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					txtSiteID.Text = Session["SelectedSiteID"].ToString();
				}
				catch
				{
					//do nothing
				}
				try
				{
					txtSiteUseID.Text = Session["SelectedSiteUseID"].ToString();
				}
				catch
				{
					//do nothing
				}

				//added this in for Mehmet Dogan at UNB
				/*
				SetValues();
				Session["ConnectionString"] = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
				Server.Transfer("TRSView.aspx");
				*/
				/*
				try
				{
					string s="";
					s+="window.open('http://www.pageresource.com/jscript/jex5.htm','Map Window','');";
					Button4.Attributes.Add("OnClick",s);
					Debug.WriteLine("Added the click event");
				}
				catch(Exception err)
				{
					Debug.WriteLine("Error adding event : "+err.ToString());
				}
				*/				
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

		}
		#endregion

		private void SetValues()
		{
			Debug.WriteLine("Setting Values");
			//Administrator
			if(rbAdmin.SelectedIndex==0)
			{
				Session["Administrator"] = true;
			}
			else
			{
				Session["Administrator"] = false;
			}
			Debug.WriteLine("Administrator is: "+Session["Administrator"].ToString());

			//Site Type
			if(rbSType.SelectedIndex==0)
			{
				Session["SiteType"] = "New Site";
			}
			else if(rbSType.SelectedIndex==1)
			{
				Session["SiteType"] = "New Use";
			}
			else
			{
				Session["SiteType"] = "Existing";
			}

			//siteid
			if(chkSite.Checked)
			{
				Debug.WriteLine("Setting SiteID");
				Session["SelectedSiteID"] = txtSiteID.Text;
			}
			if(chkSiteUse.Checked)
			{
				Debug.WriteLine("Setting SiteUseID");
				Session["SelectedSiteUseID"] = txtSiteUseID.Text;
			}

			//page mode
			if(rbMode.SelectedIndex==0)
			{
				Session["Mode"] = "View";
			}
			else if(rbMode.SelectedIndex==1)
			{
				Session["Mode"] = "Add New";
			}
			else if(rbMode.SelectedIndex==2)
			{
				Session["Mode"] = "Add Existing";
			}
			else if(rbMode.SelectedIndex==3)
			{
				Debug.WriteLine("Setting Mode to ADD");
				Session["Mode"] = "Add";
			}
			else if(rbMode.SelectedIndex==4)
			{
				Debug.WriteLine("Setting Mode to Modify");
				Session["Mode"] = "Modify";
			}
			else
			{
				Debug.WriteLine("Setting Mode to ModifySite");
				Session["Mode"] = "ModifySite";
			}

			//version
			if(rbVersion.SelectedIndex==0)
			{
				Session["Version"] = 1;
			}
			else if(rbVersion.SelectedIndex==1)
			{
				Session["Version"] = 2;
			}
			else
			{
				Session["Version"] = 3;
			}
			Debug.WriteLine("Version is "+Session["Version"].ToString());

			Debug.WriteLine("Mode is: "+Session["Mode"].ToString());

			//Agency
			Session["UserAgency"] = txtUserAgency.Text;
		}


		protected void Button1_Click(object sender, System.EventArgs e)
		{
			SetValues();
			Session["ConnectionString"] = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			Server.Transfer("TRSView.aspx");
		}
		
		protected void Button2_Click(object sender, System.EventArgs e)
		{
			SetValues();
			Server.Transfer("TLDView.aspx");
		}

		protected void Button3_Click(object sender, System.EventArgs e)
		{
			//string strConn = "C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb";
			Session["ConnectionString"] = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			Server.Transfer("ESAFSiteObservations.aspx");
		}

		protected void Button4_Click(object sender, System.EventArgs e)
		{
			Session["XCoord"] = "2513928.73";
			Session["YCoord"] = "7517796.67";
			Session["Units"] = "Meters";
			Session["CoordSys"] = "NAD83 (CSRS) NB Stereographic";
			Debug.WriteLine("Entered the button click event");
			if(!IsStartupScriptRegistered("MapWindow"))
			{
				//Page.RegisterStartupScript("MapWindow","<script language='javascript' id='MapWindow'>window.open('http://www.pageresource.com/jscript/jex5.htm');</script>");
				Page.RegisterStartupScript("MapWindow","<script language='javascript' id='MapWindow'>window.open('Map.aspx');</script>");
			}
					
		}

		protected void Button5_Click(object sender, System.EventArgs e)
		{
			Session["ConnectionString"] = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			Server.Transfer("Waterbodies-Search.aspx");
		}

		protected void Button6_Click(object sender, System.EventArgs e)
		{
			SetValues();
			Server.Transfer("STKView.aspx");
		}

		protected void Button7_Click(object sender, System.EventArgs e)
		{
			SetValues();
			Server.Transfer("STKList.aspx");
		}

		protected void Button8_Click(object sender, System.EventArgs e)
		{
			SetValues();
			Session["ConnectionString"] = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			
			Server.Transfer("ConfirmSave.aspx");
		}

		protected void Button9_Click(object sender, System.EventArgs e)
		{
			SetValues();
			Server.Transfer("ConfirmDelete.aspx");
		}

		protected void Button10_Click(object sender, System.EventArgs e)
		{			
			SetValues();
			Server.Transfer("ConfirmDeleteNo.aspx");
		}		
	}
}
