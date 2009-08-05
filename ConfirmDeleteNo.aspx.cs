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
	/// Summary description for ConfirmDeleteNo.
	/// </summary>
	public partial class ConfirmDeleteNo : System.Web.UI.Page
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
							lblH1.Text = "FISH STOCKING";
							
							break;
						case 2://electrofishing
							lblH1.Text = "ELECTROFISHING";
							
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
	}
}
