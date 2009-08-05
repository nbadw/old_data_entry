/*
COPYRIGHT 1995-2004 ESRI

TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.

For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373

email: contracts@esri.com
*/using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ArcServer3
{
	public partial class ErrorPage : System.Web.UI.Page
	{


		// Before deploying application, set showTrace to false
		// to prevent web application users from seeing error details
		private bool showTrace = true;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//get error message stored in session
			string message = (string)Session["ErrorMessage"];

			//get details of error from exception stored in session
			string errorDetail = String.Empty;
			Exception exception = Session["Error"] as Exception;
			if (exception != null)
			{
				switch (exception.GetType().ToString())
				{
					case "System.UnauthorizedAccessException":
						UnauthorizedAccessException errorAccess = exception as UnauthorizedAccessException;
						if (errorAccess.StackTrace.ToUpper().IndexOf("SERVERCONNECTION.CONNECT") > 0)
							errorDetail = "Unable to connect to server. <br>" ;
						break;
				}
				errorDetail += exception.Message;
			}

			//create response and display it
			string response;
			if (message != null && message != String.Empty)
				response = String.Format("{0}<br>{1}", message, errorDetail);
			else
				response = errorDetail;
			lblError.Text = response;
			if ((showTrace) && (exception != null)) 
				lblExtendedMessage.Text = exception.StackTrace;


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
	}
}
