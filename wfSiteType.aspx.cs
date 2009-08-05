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
	/// Summary description for wfSiteType.
	/// </summary>
	public partial class wfSiteType : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try 
				{
					switch ((int)Session["Version"])
					{
						case 20://thermistor
							lblH1.Text = "WATER TEMPERATURES";
							break;
						case 5://stocking
							lblH1.Text = "FISH STOCKINGS";
							break;
						case 2://electrofishing
							lblH1.Text = "ELECTROFISHING";
							break;
					}				
				}
				catch
				{
					lblH1.Text = "Unknown";
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

		}
		#endregion


		protected void btnContinue_Click(object sender, System.EventArgs e)
		{
			/*when user selects one of the radio buttons, save the value of the selected
			button to the session variable "SiteType" then transfer to the appropriate page
			*/
			try
			{
				string s = rblstSiteType.SelectedItem.Value;
				if(s == "new")
				{
					Session["Mode"] = "Add New";
					Server.Transfer("TRSView.aspx");
				}
				else if(s == "existing")
				{
					Session["Mode"] = "Add Existing";
					Session["SelectedSiteID"] = "";
					Session["PreviousPage"] = "TRSView.aspx";
					Server.Transfer("SelectSite.aspx");
				}
			}
			catch (Exception err)
			{
				Debug.WriteLine("Error: "+err.ToString());
				lblMessage.Visible = true;
				rblstSiteType.Font.Bold = true;
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("TRSList.aspx");
		}
	}
}
