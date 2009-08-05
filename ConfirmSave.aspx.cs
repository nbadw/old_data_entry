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
	/// Summary description for ConfirmSave.
	/// </summary>
	public partial class ConfirmSave : System.Web.UI.Page
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
							btnDetails.Text = "Add New Logger";
							break;
						case 5://stocking
							lblH1.Text = "FISH STOCKING";
							btnDetails.Text = "Add New Stocking";
							break;
						case 2://electrofishing
							lblH1.Text = "ELECTROFISHING";
							btnDetails.Text = "Add Electrofishing Data";
							break;
						case 29:
							lblH1.Text = "ENVIRONMENTAL STREAM ASSESSMENT";
							break;
					}								
				}
				catch
				{
					lblH1.Text = "Unknown";
				}
			}
		}


		#region Buttons
		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			try
			{
				Server.Transfer(Session["List"].ToString());
			}
			catch(System.NullReferenceException)
			{
				Server.Transfer("MainMenu.aspx");
			}
		}

		protected void btnDetails_Click(object sender, System.EventArgs e)
		{
			Session["Mode"] = "Add";

			try 
			{
				switch ((int)Session["Version"])
				{
					case 20://thermistor
						Server.Transfer("TLDView.aspx");
						break;
					case 5://stocking
						Server.Transfer("STKView.aspx");						
						break;
					case 2://electrofishing
						Server.Transfer("ELECTView.aspx");
						break;
				}								
			}
			catch(Exception er)
			{
				Debug.WriteLine("Error :"+ er.ToString());
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

		}
		#endregion

		
	}
}
