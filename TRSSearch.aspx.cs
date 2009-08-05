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
	/// Summary description for TemperatureRecordingSites_Search.
	/// </summary>
	/// 
	
	public partial class TemperatureRecordingSites_Search : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.DataView dvSearchSites;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdAquaticActivity;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected NBADWDataEntryApplication.dscdAquaticActivity objdscdAquaticActivity;
		protected NBADWDataEntryApplication.dsSiteUseSearch objdsSiteUseSearch;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaSiteUseSearch;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaWatersheds;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaDE_Agencies;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		protected NBADWDataEntryApplication.dsDE_Agencies objdsDE_Agencies;
		protected NBADWDataEntryApplication.dsWatersheds objdsWatersheds;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				LoadCodeDataSet();

				if(Session["PreviousPage"].ToString()!="TRSList.aspx")
				{
					dlstSiteType.DataBind();
					dlstSiteType.Items.Add(new ListItem ("All","All"));
					dlstSiteType.SelectedIndex = dlstSiteType.Items.Count -1;
				}
				else
				{
					try 
					{
						switch ((int)Session["Version"])
						{
							case 20://thermistor
								lblH1.Text = "WATER TEMPERATURES";
								dlstSiteType.Visible=false;
								lblSiteType.Visible=false;
								break;
							case 5://stocking
								lblH1.Text = "FISH STOCKING";
								dlstSiteType.Visible=false;
								lblSiteType.Visible=false;
								break;
							case 2://electrofishing
								lblH1.Text = "ELECTROFISHING";
								dlstSiteType.Visible=false;
								lblSiteType.Visible=false;
								break;
							default:
								lblH1.Text = "";
								dlstSiteType.DataBind();
								dlstSiteType.Items.Add(new ListItem ("All","All"));
								dlstSiteType.SelectedIndex = dlstSiteType.Items.Count -1;
								break;
						}								
					}
					catch
					{
						lblH1.Text = "";
						dlstSiteType.DataBind();
						dlstSiteType.Items.Add(new ListItem ("All","All"));
						dlstSiteType.SelectedIndex = dlstSiteType.Items.Count -1;
					}
				}

				dlstAgencyCode.DataBind();
				dlstAgencyCode.Items.Add(new ListItem("All", "All"));
				dlstAgencyCode.SelectedIndex = dlstAgencyCode.Items.Count-1;					
			}					
		}

		public void SetValues()
		{
			//set the values of the txtboxes
			//note that we need both dataviews (they could be differnt versions of the same 
			//dataset but either way, we need two, one sorted by waterbodyid and one by 
			//waterbodyname.
			LoadWaterDataSet();
			DataView dvWatersheds = new DataView(objdsWatersheds.Tables["DE-Watersheds"],"","WaterBodyID", DataViewRowState.CurrentRows);
			int j = dvWatersheds.Find(Session["SelectedWaterBodyID"].ToString());
			
			txtwaterbodyid.Text = dvWatersheds[j]["WaterBodyID"].ToString();
			txtwaterbodyname.Text = dvWatersheds[j]["WaterBodyName"].ToString();
			txtwatershed.Text = dvWatersheds[j]["DrainageCd"].ToString();
		}


		#region dgResults
		private void dgResults_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//Set current page of Datagrid to selected page
			dgResults.CurrentPageIndex = e.NewPageIndex;
			dvSearchSites.RowFilter = Session["filterstring"].ToString();
			LoadDataSet();
			dgResults.DataBind();
		}
		
		private void dgResults_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//Debug.WriteLine("Selected Index is "+dgResults.SelectedIndex+ " and the dataview has "+ dvSearchSites.Count);
			//Debug.WriteLine("AquaticSiteID is "+e.Item.Cells[2]);
			//Session["SelectedAquaticSiteID"]=dvSearchSites[dgResults.SelectedIndex]["AquaticSiteID"];
			//Debug.WriteLine("The aquatic site id you have chosen is "+Session["SelectedAquaticSiteID"].ToString());
			//Session["SelectedSiteUseID"]=dgResults[dbResults.SelectedIndex][";
			//Server.Transfer("TemperatureRecordingSites-ModifyNew.aspx");	
	
			//for the following line of code to work, datakey field for datagrid must be set
			//needs to be set to siteuseid not siteid.  
			/*If using siteid, it will link to multiple records in the site use table
			if using siteuseid, this will only link to one record in the site table
			*/
			int i = (int)dgResults.DataKeys[(int) e.Item.ItemIndex];
			//Debug.WriteLine("selected index is "+ i);
			dvSearchSites.RowFilter = Session["filterstring"].ToString();
			dvSearchSites.Sort = "AquaticSiteUseID";
			LoadDataSet();
			int dvindex = dvSearchSites.Find(i);
			Session["SelectedSiteID"] = dvSearchSites[dvindex]["AquaticSiteID"];
			try
			{
				if(!(bool)Session["SiteOnly"])
				{
					Debug.WriteLine("Setting Site Use in try");
					Session["SelectedSiteUseID"]=dvSearchSites[dvindex]["AquaticSiteUseID"];
				}
				else
				{
					Debug.WriteLine("Not setting site use");
				}
			}
			catch
			{
				Debug.WriteLine("Setting Site Use in catch");
				Session["SelectedSiteUseID"]=dvSearchSites[dvindex]["AquaticSiteUseID"];
			}
			switch(Session["PreviousPage"].ToString())
			{
				case "TRSList.aspx":
					Session["Mode"] = "View";
					Server.Transfer("TRSView.aspx");
					break;
				default:
					Server.Transfer(Session["PreviousPage"].ToString());
					break;
			}
		}

		private void dgResults_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LoadDataSet();
			dvSearchSites.RowFilter = Session["filterstring"].ToString();
			dvSearchSites.Sort = e.SortExpression;
			dgResults.DataBind();
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
			this.dvSearchSites = new System.Data.DataView();
			this.objdsSiteUseSearch = new NBADWDataEntryApplication.dsSiteUseSearch();
			this.oleDbdacdAquaticActivity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdscdAquaticActivity = new NBADWDataEntryApplication.dscdAquaticActivity();
			this.oleDbdaSiteUseSearch = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdaWatersheds = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.objdsWatersheds = new NBADWDataEntryApplication.dsWatersheds();
			this.oleDbdaDE_Agencies = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.objdsDE_Agencies = new NBADWDataEntryApplication.dsDE_Agencies();
			((System.ComponentModel.ISupportInitialize)(this.dvSearchSites)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsSiteUseSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAquaticActivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsWatersheds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_Agencies)).BeginInit();
			this.dgResults.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgResults_PageIndexChanged);
			this.dgResults.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgResults_EditCommand);
			this.dgResults.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgResults_SortCommand);
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
			// dvSearchSites
			// 
			this.dvSearchSites.Table = this.objdsSiteUseSearch._DE_SiteSearch;
			// 
			// objdsSiteUseSearch
			// 
			this.objdsSiteUseSearch.DataSetName = "dsSiteUseSearch";
			this.objdsSiteUseSearch.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdacdAquaticActivity
			// 
			this.oleDbdacdAquaticActivity.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbdacdAquaticActivity.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdacdAquaticActivity.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdacdAquaticActivity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "cdAquaticActivity", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																									new System.Data.Common.DataColumnMapping("AquaticActivity", "AquaticActivity")})});
			this.oleDbdacdAquaticActivity.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM cdAquaticActivity WHERE (AquaticActivityCd = ?) AND (AquaticActivity " +
				"= ? OR ? IS NULL AND AquaticActivity IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivity", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivity1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivity", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO cdAquaticActivity(AquaticActivityCd, AquaticActivity) VALUES (?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT AquaticActivityCd, AquaticActivity FROM cdAquaticActivity";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE cdAquaticActivity SET AquaticActivityCd = ?, AquaticActivity = ? WHERE (Aq" +
				"uaticActivityCd = ?) AND (AquaticActivity = ? OR ? IS NULL AND AquaticActivity I" +
				"S NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivity", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivity1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivity", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdAquaticActivity
			// 
			this.objdscdAquaticActivity.DataSetName = "dscdAquaticActivity";
			this.objdscdAquaticActivity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaSiteUseSearch
			// 
			this.oleDbdaSiteUseSearch.InsertCommand = this.oleDbInsertCommand5;
			this.oleDbdaSiteUseSearch.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbdaSiteUseSearch.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "DE-SiteSearch", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																							new System.Data.Common.DataColumnMapping("AgencySiteID", "AgencySiteID"),
																																																							new System.Data.Common.DataColumnMapping("AquaticActivity", "AquaticActivity"),
																																																							new System.Data.Common.DataColumnMapping("AquaticActivityCd", "AquaticActivityCd"),
																																																							new System.Data.Common.DataColumnMapping("AquaticSiteID", "AquaticSiteID"),
																																																							new System.Data.Common.DataColumnMapping("AquaticSiteName", "AquaticSiteName"),
																																																							new System.Data.Common.DataColumnMapping("AquaticSiteUseID", "AquaticSiteUseID"),
																																																							new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																							new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																							new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																							new System.Data.Common.DataColumnMapping("AquaticSiteDesc", "AquaticSiteDesc"),
																																																							new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = "INSERT INTO [DE-SiteSearch] (AgencyCd, AgencySiteID, AquaticActivity, AquaticActi" +
				"vityCd, AquaticSiteID, AquaticSiteName, DrainageCd, WaterBodyID, WaterBodyName, " +
				"AquaticSiteDesc, WaterBodyName_Abrev) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarWChar, 150, "AquaticSiteDesc"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivity, AquaticActivityCd, AquaticSiteID," +
				" AquaticSiteName, AquaticSiteUseID, DrainageCd, WaterBodyID, WaterBodyName, Aqua" +
				"ticSiteDesc, WaterBodyName_Abrev FROM [DE-SiteSearch]";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO [DE-SiteSearch] (AgencyCd, AgencySiteID, AquaticActivity, AquaticActi" +
				"vityCd, AquaticSiteID, AquaticSiteName, DrainageCd, WaterBodyID, WaterBodyName, " +
				"AquaticSiteDesc) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencySiteID", System.Data.OleDb.OleDbType.VarWChar, 10, "AgencySiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivity", System.Data.OleDb.OleDbType.VarWChar, 50, "AquaticActivity"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityCd", System.Data.OleDb.OleDbType.SmallInt, 0, "AquaticActivityCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticSiteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteName", System.Data.OleDb.OleDbType.VarWChar, 100, "AquaticSiteName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticSiteDesc", System.Data.OleDb.OleDbType.VarChar, 150, "AquaticSiteDesc"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT AgencyCd, AgencySiteID, AquaticActivity, AquaticActivityCd, AquaticSiteID," +
				" AquaticSiteName, AquaticSiteUseID, DrainageCd, WaterBodyID, WaterBodyName, Aqua" +
				"ticSiteDesc FROM [DE-SiteSearch]";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbdaWatersheds
			// 
			this.oleDbdaWatersheds.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbdaWatersheds.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdaWatersheds.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "DE-Watersheds", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																						 new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																						 new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd")})});
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO [DE-Watersheds] (WaterBodyID, WaterBodyName, DrainageCd) VALUES (?, ?" +
				", ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT WaterBodyID, WaterBodyName, DrainageCd FROM [DE-Watersheds]";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// objdsWatersheds
			// 
			this.objdsWatersheds.DataSetName = "dsWatersheds";
			this.objdsWatersheds.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdaDE_Agencies
			// 
			this.oleDbdaDE_Agencies.InsertCommand = this.oleDbInsertCommand6;
			this.oleDbdaDE_Agencies.SelectCommand = this.oleDbSelectCommand6;
			this.oleDbdaDE_Agencies.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "DE-Agencies", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("AgencyCd", "AgencyCd"),
																																																						new System.Data.Common.DataColumnMapping("Agency", "Agency")})});
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM cdAgency WHERE (AgencyCd = ?) AND (Agency = ? OR ? IS NULL AND Agency" +
				" IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO cdAgency(Agency, AgencyCd) VALUES (?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT Agency, AgencyCd FROM cdAgency";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE cdAgency SET Agency = ?, AgencyCd = ? WHERE (AgencyCd = ?) AND (Agency = ?" +
				" OR ? IS NULL AND Agency IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarWChar, 60, "Agency"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, "AgencyCd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AgencyCd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Agency1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Agency", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT AgencyCd, Agency FROM [DE-Agencies]";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = "INSERT INTO [DE-Agencies] (AgencyCd, Agency) VALUES (?, ?)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("AgencyCd", System.Data.OleDb.OleDbType.VarWChar, 4, "AgencyCd"));
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Agency", System.Data.OleDb.OleDbType.VarChar, 60, "Agency"));
			// 
			// objdsDE_Agencies
			// 
			this.objdsDE_Agencies.DataSetName = "dsDE_Agencies";
			this.objdsDE_Agencies.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dvSearchSites)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsSiteUseSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdAquaticActivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsWatersheds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdsDE_Agencies)).EndInit();

		}
		#endregion

		#region Fill & Load
		public void FillDataSet(NBADWDataEntryApplication.dsSiteUseSearch dataSet1)
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
				this.oleDbdaSiteUseSearch.Fill(dataSet1);
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

		public void FillCodeDataSet(NBADWDataEntryApplication.dsDE_Agencies dataSet1, NBADWDataEntryApplication.dscdAquaticActivity dataSet2)
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
				this.oleDbdaDE_Agencies.Fill(dataSet1);
				this.oleDbdacdAquaticActivity.Fill(dataSet2);
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

		public void FillWaterDataSet(NBADWDataEntryApplication.dsWatersheds dataSet)
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
				this.oleDbdaWatersheds.Fill(dataSet);
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

		public void LoadDataSet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsSiteUseSearch objDataSetTemp1;
			//NBADWDataEntryApplication.dscdAquaticActivity objDataSetTemp2;
			objDataSetTemp1 = new NBADWDataEntryApplication.dsSiteUseSearch();
			//objDataSetTemp2 = new NBADWDataEntryApplication.dscdAquaticActivity();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDataSet(objDataSetTemp1);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsSiteUseSearch.Clear();
				//objdscdAquaticActivity.Clear();
				// Merge the records into the main dataset.
				objdsSiteUseSearch.Merge(objDataSetTemp1);
				//objdscdAquaticActivity.Merge(objDataSetTemp2);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		public void LoadCodeDataSet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsDE_Agencies objDataSetTemp1;
			NBADWDataEntryApplication.dscdAquaticActivity objDataSetTemp2;

			objDataSetTemp1 = new NBADWDataEntryApplication.dsDE_Agencies();
			objDataSetTemp2 = new NBADWDataEntryApplication.dscdAquaticActivity();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillCodeDataSet(objDataSetTemp1, objDataSetTemp2);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsDE_Agencies.Clear();
				objdscdAquaticActivity.Clear();
				// Merge the records into the main dataset.
				objdsDE_Agencies.Merge(objDataSetTemp1);
				objdscdAquaticActivity.Merge(objDataSetTemp2);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}
		}

		public void LoadWaterDataSet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dsWatersheds objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dsWatersheds();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillWaterDataSet(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsWatersheds.Clear();
				// Merge the records into the main dataset.
				objdsWatersheds.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		#endregion

		#region Buttons
		protected void btnSearch2_Click(object sender, System.EventArgs e)
		{
			//filter the dataview, then bind to grid to display
			//should set site use or at least display it.  otherwise, looks like duplicate records showing
			string filterstring = "";
			//get site type
			if(!dlstSiteType.Visible)
			{
				filterstring = "(AquaticActivityCd = "+Session["Version"].ToString()+")";
			}
			else if(dlstSiteType.SelectedValue=="All")
			{
				filterstring = "(AquaticActivityCd >0)";
			}
			else
			{
				filterstring = "(AquaticActivityCd = "+dlstSiteType.SelectedValue+")";
			}

			//get rest of query string
			if(txtdwsiteid.Text!="")
			{
				//this handles the possibility of the user entering a string
				//into a field that expects and int
				try
				{
					filterstring += "AND AquaticSiteID = " +Convert.ToInt32(txtdwsiteid.Text);
				}
				catch
				{
					filterstring += "AND AquaticSiteID = 0";
				}
			}				
			if(dlstAgencyCode.SelectedValue!="All")
			{
				filterstring += "AND AgencyCd = '"+dlstAgencyCode.SelectedValue+"'";
			}
			if(txtgroupsiteid.Text!="")
			{
				filterstring += " AND AgencySiteID LIKE '"+txtgroupsiteid.Text+"'";
			}
			if(txtwaterbodyid.Text!="")
			{
				//this handles the possibility of the user entering a string
				//into a field that expects and int
				try
				{
					filterstring += "AND WaterBodyID = " +Convert.ToInt32(txtwaterbodyid.Text);
				}
				catch
				{
					filterstring += "AND WaterBodyID = 0";
				}
				//filterstring += " AND  = '"+txtwaterbodyid.Text+"'";
			}
			if(txtwaterbodyname.Text!="")
			{
				filterstring += " AND WaterBodyName LIKE '"+txtwaterbodyname.Text+"'";
			}
			if(txtwatershed.Text!="")
			{
				filterstring += " AND DrainageCd LIKE '"+txtwatershed.Text+"'";
			}
			if(txtsitename.Text!="")
			{
				filterstring += " AND AquaticSiteName LIKE '"+txtsitename.Text+"'";
			}


			//Save filterstring for subsequent posts
			Session["filterstring"]=filterstring;
			dvSearchSites.RowFilter = filterstring;
			Debug.WriteLine("filter: "+filterstring);
			Debug.WriteLine("rowfilter = "+dvSearchSites.RowFilter.ToString());

			try 
			{
				LoadDataSet();
			}
			catch (System.Exception eLoad) 
			{
				this.Response.Write(eLoad.Message);
			}
			
			if(dvSearchSites.Count == 0)
			{
				lblMessage.Text = "There were no sites found matching your search criteria.  Please try again.";
				dgResults.DataBind();
			}
			else
			{
				lblMessage.Text = "";
				dgResults.DataBind();				
			}
		}

		private void btnSearchWaterbodyID_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "TRSSearch.aspx";
			Server.Transfer("Waterbodies-Search.aspx");
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["PreviousPage"] = "TemperatureRecordingSites-Search.aspx";
			Server.Transfer("wfSiteType.aspx");
		}

		protected void btnClose_Click(object sender, System.EventArgs e)
		{
			try
			{
				Server.Transfer(Session["PreviousPage"].ToString());
			}
			catch(System.NullReferenceException)
			{
				Server.Transfer("TRSList.aspx");
			}
		}
		#endregion

	}	
}
