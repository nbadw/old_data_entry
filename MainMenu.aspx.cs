using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NBADWDataEntryApplication
{
	/// <summary>
	/// Summary description for MainMenu.
	/// </summary>
	public partial class MainMenu : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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

		protected void lnkWaterTemperature_Click(object sender, System.EventArgs e)
		{
			Session["Version"] = 20;
			Server.Transfer("TRSList.aspx");
		}

		protected void lnkFishStocking_Click(object sender, System.EventArgs e)
		{
			Session["Version"] = 5;
			Server.Transfer("TRSList.aspx");
		}

		protected void lnkEnvironmentalStreamAssessment_Click(object sender, System.EventArgs e)
		{
			Session["Version"] = 29;
			Server.Transfer("ESAFList.aspx");
		}

		protected void lnkElectrofishing_Click(object sender, System.EventArgs e)
		{
			Session["Version"] = 2;
			Server.Transfer("TRSList.aspx");
		}		
	}
}
