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
	/// Summary description for SelectSite.
	/// </summary>
	/// 
	/*
	 * try
			{
				//this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Registry Path=;Data Source=""C:\Data_Warehouse\Tabular_Data\NBAquaticDataWarehouse_DW.mdb"";Jet OLEDB:System database=;Jet OLEDB:Global Bulk Transactions=1;User ID=Admin;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:SFP=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Engine Type=5;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Global Partial Bulk Ops=2;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Create System Database=False;Jet OLEDB:Database Locking Mode=1";
				this.oleDbConnection1.ConnectionString = Session["ConnectionString"].ToString();
			}
			catch(System.NullReferenceException)
			{
				Server.Transfer("Login.aspx");
			}
			*/

	public partial class SelectSite : System.Web.UI.Page
	{
		#region Controls
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SitesNonElectrofishing;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SitesNonStocking;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SitesNonTemperature;
		protected NBADWDataEntryApplication.dsDE_SitesGeneric objdsDE_SitesGeneric;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SitesTemperature;
		protected System.Data.DataView dvDE_SitesGeneric;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SitesElectrofishing;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_SitesStocking;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand7;
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					switch (Session["Mode"].ToString())
					{
						case "Add Existing":
						{
							HidePanels();
							pnlAddSiteInstructions.Visible = true;
							dgAquaticSite.DataKeyField = "AquaticSiteID";
							lblH2.Text = "ADD New Data to Existing Site";

							switch ((int)Session["Version"])
							{
								case 20://thermistor
									lblH1.Text = "WATER TEMPERATURES";
									LoadDataSet(this.oleDbdaDE_SitesNonTemperature);
									break;
								case 5://stocking
									lblH1.Text = "FISH STOCKINGS";
									LoadDataSet(this.oleDbdaDE_SitesNonStocking);
									break;
								case 2://electrofishing
									lblH1.Text = "ELECTROFISHING";
									LoadDataSet(this.oleDbdaDE_SitesNonElectrofishing);
									break;
							}	
							break;
						}

						case "ModifySite":
						{	
							HidePanels();
							pnlChangeSiteInstructions.Visible = true;
							dgAquaticSite.DataKeyField = "AquaticSiteUseID";

							switch ((int)Session["Version"])
							{
								case 20://thermistor
									lblH1.Text = "WATER TEMPERATURES";
									lblH2.Text = "CHANGE SITE for Logger";
									lblType1.Text = "temperature";
									lblType2.Text = "Temperature";
									LoadDataSet(this.oleDbdaDE_SitesTemperature);
									break;
								case 5://stocking
									lblH1.Text = "FISH STOCKINGS";
									lblH2.Text = "CHANGE SITE for Stocking";
									lblType1.Text = "stocking";
									lblType2.Text = "Stocking";
									LoadDataSet(this.oleDbdaDE_SitesStocking);
									break;
								case 2://electrofishing
									lblH1.Text = "ELECTROFISHING";
									lblH2.Text = "CHANGE SITE for Electrofishing";
									lblType1.Text = "electrofishing";
									lblType2.Text = "Electrofishing";
									LoadDataSet(this.oleDbdaDE_SitesElectrofishing);
									break;							
							}
							break;
						}
					}
				}
				catch(Exception err)
				{
					lblH2.Text = "Unknown";
					Debug.WriteLine("Error in load: "+err.ToString());
				}
				dgAquaticSite.DataBind();
			}			
		}


		#region dgAquaticSite
		private void dgAquaticSite_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i = 0;
			switch (Session["Mode"].ToString())
			{
				case "Add Existing":
					i = (int)dgAquaticSite.DataKeys[(int) e.Item.ItemIndex];
					Session["SelectedSiteID"] = i;
					break;
				case "ModifySite":
					i = (int)dgAquaticSite.DataKeys[(int) e.Item.ItemIndex];
					Session["OldSelectedSiteUseID"] = Session["SelectedSiteUseID"];//save in case of cancel on change site page
					Session["SelectedSiteUseID"] = i;
					break;
			}
            Debug.WriteLine("I = "+i.ToString());
			Server.Transfer(Session["PreviousPage"].ToString());	
		}

		private void dgAquaticSite_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			switch (Session["Mode"].ToString())
			{
				case "Add Existing":
				{
					switch ((int)Session["Version"])
					{
						case 2:
							LoadDataSet(this.oleDbdaDE_SitesNonElectrofishing);
							break;
						case 5:
							LoadDataSet(this.oleDbdaDE_SitesNonStocking);
							break;
						case 20:
							LoadDataSet(this.oleDbdaDE_SitesNonTemperature);
							break;
					}
					break;
				}
				case "ModifySite":
				{
					switch ((int)Session["Version"])
					{
						case 2:
							LoadDataSet(this.oleDbdaDE_SitesElectrofishing);
							break;
						case 5:
							LoadDataSet(this.oleDbdaDE_SitesStocking);
							break;
						case 20:
							LoadDataSet(this.oleDbdaDE_SitesTemperature);
							break;
					}
					break;
				}
			}
			
			this.dvDE_SitesGeneric.Sort = e.SortExpression;
			dgAquaticSite.DataBind();
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
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbdaDE_SitesNonElectrofishing = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdaDE_SitesNonStocking = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdaDE_SitesNonTemperature = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_SitesGeneric = new NBADWDataEntryApplication.dsDE_SitesGeneric();
			this.oleDbdaDE_SitesTemperature = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.dvDE_SitesGeneric = new System.Data.DataView();
			this.oleDbdaDE_SitesElectrofishing = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdaDE_SitesStocking = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SitesGeneric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_SitesGeneric)).BeginInit();
			this.dgAquaticSite.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgAquaticSite_EditCommand);
			this.dgAquaticSite.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgAquaticSite_SortCommand);
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
			// 
			// oleDbdaDE_SitesNonElectrofishing
			// 
			this.oleDbdaDE_SitesNonElectrofishing.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbdaDE_SitesNonElectrofishing.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbdaDE_SitesNonElectrofishing.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "DE-SitesNonElectrofishing", new System.Data.Common.DataColumnMapping[] {
																																																													new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																													new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																													new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																													new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																													new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																													new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																													new System.Data.Common.DataColumnMapping("AquaticActivity", "AquaticActivity"),
																																																													new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																													new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																													new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO [DE-SitesNonElectrofishing] (AgencyCd, AquaticSiteID, DrainageCd, Wat" +
				"erBodyID, WaterBodyName, AquaticActivity, AquaticSiteDesc, AgencySiteID, WaterBo" +
				"dyName_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT AgencyCd, AquaticSiteID, DrainageCd, WaterBodyID, WaterBodyName, AquaticSi" +
				"teUseID, AquaticActivity, AquaticSiteDesc, AgencySiteID, WaterBodyName_Abrev FRO" +
				"M [DE-SitesNonElectrofishing]";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbdaDE_SitesNonStocking
			// 
			this.oleDbdaDE_SitesNonStocking.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdaDE_SitesNonStocking.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdaDE_SitesNonStocking.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "DE-SitesNonStocking", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																										new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																										new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																										new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																										new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																										new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																										new System.Data.Common.DataColumnMapping("AquaticActivity", "AquaticActivity"),
																																																										new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																										new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																										new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO [DE-SitesNonStocking] (AgencyCd, AquaticSiteID, DrainageCd, WaterBody" +
				"ID, WaterBodyName, AquaticActivity, AquaticSiteDesc, AgencySiteID, WaterBodyName" +
				"_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT AgencyCd, AquaticSiteID, DrainageCd, WaterBodyID, WaterBodyName, AquaticSi" +
				"teUseID, AquaticActivity, AquaticSiteDesc, AgencySiteID, WaterBodyName_Abrev FRO" +
				"M [DE-SitesNonStocking]";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbdaDE_SitesNonTemperature
			// 
			this.oleDbdaDE_SitesNonTemperature.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdaDE_SitesNonTemperature.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdaDE_SitesNonTemperature.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "DE-SitesNonTemperature", new System.Data.Common.DataColumnMapping[] {
																																																											  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																											  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticActivity", "AquaticActivity"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																											  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO [DE-SitesNonTemperature] (AgencyCd, AquaticSiteID, DrainageCd, WaterB" +
				"odyID, WaterBodyName, AquaticActivity, AquaticSiteDesc, AgencySiteID, WaterBodyN" +
				"ame_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 50, "WaterBodyName"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT AgencyCd, AquaticSiteID, DrainageCd, WaterBodyID, WaterBodyName, AquaticSi" +
				"teUseID, AquaticActivity, AquaticSiteDesc, AgencySiteID, WaterBodyName_Abrev FRO" +
				"M [DE-SitesNonTemperature]";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// objdsDE_SitesGeneric
			// 
			this.objdsDE_SitesGeneric.DataSetName = "dsDE_SitesGeneric";
			this.objdsDE_SitesGeneric.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaDE_SitesTemperature
			// 
			this.oleDbdaDE_SitesTemperature.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbdaDE_SitesTemperature.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdaDE_SitesTemperature.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "DE-SitesTemperature", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																										new System.Data.Common.DataColumnMapping("AquaticActivity", "AquaticActivity"),
																																																										new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																										new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																										new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																										new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																										new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																										new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																										new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																										new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																										new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO [DE-SitesTemperature] (AgencyCd, AquaticActivity, AquaticActivityCd, " +
				"AquaticSiteID, DrainageCd, WaterBodyID, WaterBodyName, AquaticSiteDesc, AgencySi" +
				"teID, WaterBodyName_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT AgencyCd, AquaticActivity, AquaticActivityCd, AquaticSiteID, DrainageCd, W" +
				"aterBodyID, WaterBodyName, AquaticSiteUseID, AquaticSiteDesc, AgencySiteID, Wate" +
				"rBodyName_Abrev FROM [DE-SitesTemperature]";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// dvDE_SitesGeneric
			// 
			this.dvDE_SitesGeneric.Table = this.objdsDE_SitesGeneric._DE_SitesNonTemperature;
			// 
			// oleDbdaDE_SitesElectrofishing
			// 
			this.oleDbdaDE_SitesElectrofishing.InsertCommand = this.oleDbInsertCommand5;
			this.oleDbdaDE_SitesElectrofishing.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbdaDE_SitesElectrofishing.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "DE-SitesElectrofishing", new System.Data.Common.DataColumnMapping[] {
																																																											  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																											  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticActivity", "AquaticActivity"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																											  new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																											  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																											  new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = "INSERT INTO [DE-SitesElectrofishing] (AgencyCd, AgencySiteID, AquaticActivity, Aq" +
				"uaticActivityCd, AquaticSiteDesc, AquaticSiteID, DrainageCd, WaterBodyID, WaterB" +
				"odyName, WaterBodyName_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivity, AquaticActivityCd, AquaticSiteDes" +
				"c, AquaticSiteID, AquaticSiteUseID, DrainageCd, WaterBodyID, WaterBodyName, Wate" +
				"rBodyName_Abrev FROM [DE-SitesElectrofishing]";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// oleDbdaDE_SitesStocking
			// 
			this.oleDbdaDE_SitesStocking.InsertCommand = this.oleDbInsertCommand7;
			this.oleDbdaDE_SitesStocking.SelectCommand = this.oleDbSelectCommand7;
			this.oleDbdaDE_SitesStocking.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "DE-SitesStocking", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																								  new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																								  new System.Data.Common.DataColumnMapping("AquaticActivity", "AquaticActivity"),
																																																								  new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																								  new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																								  new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																								  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																								  new System.Data.Common.DataColumnMapping("Expr1008", "Expr1008"),
																																																								  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																								  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																								  new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand7
			// 
			this.oleDbInsertCommand7.CommandText = "INSERT INTO [DE-SitesStocking] (AgencyCd, AgencySiteID, AquaticActivity, AquaticA" +
				"ctivityCd, AquaticSiteID, DrainageCd, Expr1008, WaterBodyID, WaterBodyName, Wate" +
				"rBodyName_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Expr1008", System.Data.OleDb.OleDbType.VarWChar, 50, "Expr1008"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
			// 
			// oleDbSelectCommand7
			// 
			this.oleDbSelectCommand7.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivity, AquaticActivityCd, AquaticSiteID," +
				" AquaticSiteUseID, DrainageCd, Expr1008, WaterBodyID, WaterBodyName, WaterBodyNa" +
				"me_Abrev FROM [DE-SitesStocking]";
			this.oleDbSelectCommand7.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = "INSERT INTO [DE-SitesStocking] (AgencyCd, AgencySiteID, AquaticActivity, AquaticA" +
				"ctivityCd, AquaticSiteID, DrainageCd, Expr1008, WaterBodyID, WaterBodyName, Wate" +
				"rBodyName_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Expr1008", System.Data.OleDb.OleDbType.VarWChar, 50, "Expr1008"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivity, AquaticActivityCd, AquaticSiteID," +
				" AquaticSiteUseID, DrainageCd, Expr1008, WaterBodyID, WaterBodyName, WaterBodyNa" +
				"me_Abrev FROM [DE-SitesStocking]";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_SitesGeneric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDE_SitesGeneric)).EndInit();

		}
		#endregion

		#region Buttons
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("TRSSearch.aspx");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			switch( Session["Mode"].ToString())
			{
				case "Add Existing":
					Server.Transfer("wfSiteType.aspx");
					break;
				case "ModifySite":
					Session["Mode"] = "View";
					Server.Transfer(Session["PreviousPage"].ToString());
					break;
			}
		}
		#endregion

		#region Fill & Load
		public void FillDataSet(NBADWDataEntryApplication.dsDE_SitesGeneric dataSet1, System.Data.OleDb.OleDbDataAdapter da)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet1.EnforceConstraints = false;
			//dataSet2.EnforceConstraints = false;
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				da.Fill(dataSet1._DE_SitesNonTemperature);
				//this.oleDbdacdAquaticActivity.Fill(dataSet2);
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
				//dataSet2.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}

		}

		public void LoadDataSet(System.Data.OleDb.OleDbDataAdapter da)
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_SitesGeneric objDataSetTemp1;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_SitesGeneric();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDataSet(objDataSetTemp1, da);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_SitesGeneric.Clear();
				// Merge the records into the main dataset.
				objdsDE_SitesGeneric.Merge(objDataSetTemp1);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}
		#endregion	

		private void HidePanels()
		{
			pnlAddSiteInstructions.Visible = false;
			pnlChangeSiteInstructions.Visible = false;
		}
	}
}
