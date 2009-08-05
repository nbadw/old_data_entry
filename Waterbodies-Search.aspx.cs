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

namespace NBADWDataEntryApplication
{
	/// <summary>
	/// Summary description for Waterbodies_Search2.
	/// </summary>
	public partial class Waterbodies_Search2 : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdaWaterbodySearch;
		protected System.Data.DataView dvWaterbodySearch;
		protected NBADWDataEntryApplication.dsWaterbodySearch objdsWaterbodySearch;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.DataView dvDrain1;
		protected System.Data.DataView dvDrain2;
		protected System.Data.DataView dvDrain3;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblDrainageUnits1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblDrainageUnits2;
		protected NBADWDataEntryApplication.dstblDrainageUnits1 objdstblDrainageUnits1;
		protected NBADWDataEntryApplication.dstblDrainageUnits2 objdstblDrainageUnits2;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblDrainageUnits3;
		protected NBADWDataEntryApplication.dstblDrainageUnits3 objdstblDrainageUnits3;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected string filterstring;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here


			if(!Page.IsPostBack)
			{
				LoadDrainDataSet();
				dlstDrain1.DataBind();
				dlstDrain1.Items.Add(new ListItem ("", ""));
				dlstDrain1.SelectedIndex = dlstDrain1.Items.Count -1;
				SetdlstDrain2();
				SetdlstDrain3();
			}
			else//retrieve datasets
			{
				System.IO.StringReader sr1 = new System.IO.StringReader((string)(ViewState["dSet1"]));
				System.IO.StringReader sr2 = new System.IO.StringReader((string)(ViewState["dSet2"]));
				System.IO.StringReader sr3 = new System.IO.StringReader((string)(ViewState["dSet3"]));
				
				objdstblDrainageUnits1.ReadXml(sr1);
				objdstblDrainageUnits2.ReadXml(sr2);
				objdstblDrainageUnits3.ReadXml(sr3);
			}
		}
		#region Set Drainage Lists
		private void SetdlstDrain2()
		{
			dvDrain2.RowFilter="Level1No='"+dlstDrain1.SelectedValue+"'";
			dlstDrain2.DataBind();
			dlstDrain2.Items.Add(new ListItem ("", ""));
			dlstDrain2.SelectedIndex = dlstDrain2.Items.Count -1;
		}

		private void SetdlstDrain3()
		{
			dvDrain3.RowFilter="Level1No='"+dlstDrain1.SelectedValue+"' AND Level2No='"+dlstDrain2.SelectedValue+"'";
			dlstDrain3.DataBind();
			dlstDrain3.Items.Add(new ListItem ("", ""));
			dlstDrain3.SelectedIndex = dlstDrain3.Items.Count -1;
		}
		#endregion

		#region Buttons
		protected void btnSearch2_Click(object sender, System.EventArgs e)
		{
			//filter the dataview, then bind to grid to display
			//this is a meaningless restriction to start off the filter
			filterstring = "(WaterBodyID > 0)";
			if(txtwaterbodyid.Text!="")
			{
				filterstring+= "AND WaterBodyID = "+txtwaterbodyid.Text;
			}
			if(dlstDrain1.Items.Count>0)
			{
				if(dlstDrain1.SelectedItem.ToString()!="")
				{
					filterstring += "AND Level1Name = '"+dlstDrain1.SelectedItem+"'";
				}
			}
			if(dlstDrain2.Items.Count>0)
			{
				if(dlstDrain2.SelectedItem.ToString()!="")
				{
					filterstring += "AND Level2Name = '"+dlstDrain2.SelectedItem+"'";
				}
			}
			if(dlstDrain3.Items.Count>0)
			{
				if(dlstDrain3.SelectedItem.ToString()!="" & dlstDrain3.Items.Count>0)
				{
					filterstring += "AND Level3Name = '"+dlstDrain3.SelectedItem+"'";
				}
			}
			/*if(txtlevel1.Text!="")
			{
				filterstring += "AND Level1Name LIKE  '"+txtlevel1.Text+"'";
			}
			if(txtlevel2.Text!="")
			{
				filterstring += " AND Level2Name LIKE '"+txtlevel2.Text+"'";
			}
			if(txtlevel3.Text!="")
			{
				filterstring += " AND Level3Name LIKE '"+txtlevel3.Text+"'";
			}
			*/
			if(txtwaterbodyname.Text!="")
			{
				filterstring += " AND WaterBodyName LIKE '"+txtwaterbodyname.Text+"'";
			}
			if(txtwatershedcode.Text!="")
			{
				filterstring += " AND DrainageCd LIKE '"+txtwatershedcode.Text+"'";
			}
			//save filter for subsequent posts
			Session["filterstring"] = filterstring;
			Debug.WriteLine(filterstring);
			dvWaterbodySearch.RowFilter = filterstring;
			//dvWaterbodySearch.Sort = "WaterBodyID ASC";
			try 
			{
				LoadDataSet();
			}
			catch (System.Exception eLoad) 
			{
				this.Response.Write(eLoad.Message);
			}

			if(dvWaterbodySearch.Count == 0)
			{
				lblMessage.Text = "There were no water bodies found matching your search criteria.  Please try again.";
				dgResults.DataBind();
			}
			else
			{
				lblMessage.Text = "";
				dgResults.DataBind();
				
			}

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

		#region Fill & Load
		public void FillDataSet(NBADWDataEntryApplication.dsWaterbodySearch dataSet)
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
				this.oleDbdaWaterbodySearch.Fill(dataSet);
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
			NBADWDataEntryApplication.dsWaterbodySearch objDataSetTemp;
			objDataSetTemp = new NBADWDataEntryApplication.dsWaterbodySearch();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDataSet(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdsWaterbodySearch.Clear();
				// Merge the records into the main dataset.
				objdsWaterbodySearch.Merge(objDataSetTemp);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		public void FillDrainDataSet(NBADWDataEntryApplication.dstblDrainageUnits1 dataSet1, NBADWDataEntryApplication.dstblDrainageUnits2 dataSet2, NBADWDataEntryApplication.dstblDrainageUnits3 dataSet3)
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
				this.oleDbdatblDrainageUnits1.Fill(dataSet1);
				this.oleDbdatblDrainageUnits2.Fill(dataSet2);
				this.oleDbdatblDrainageUnits3.Fill(dataSet3);
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

				System.IO.StringWriter sw1 = new System.IO.StringWriter();
				System.IO.StringWriter sw2 = new System.IO.StringWriter();
				System.IO.StringWriter sw3 = new System.IO.StringWriter();
				
				// Write the DataSet to the ViewState property.
				dataSet1.WriteXml(sw1);
				dataSet2.WriteXml(sw2);
				dataSet3.WriteXml(sw3);
				ViewState["dSet1"] = sw1.ToString();
				ViewState["dSet2"] = sw2.ToString();
				ViewState["dSet3"] = sw3.ToString();
			}

		}


		public void LoadDrainDataSet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblDrainageUnits1 objDataSetTemp1;
			NBADWDataEntryApplication.dstblDrainageUnits2 objDataSetTemp2;
			NBADWDataEntryApplication.dstblDrainageUnits3 objDataSetTemp3;

			objDataSetTemp1 = new NBADWDataEntryApplication.dstblDrainageUnits1();
			objDataSetTemp2 = new NBADWDataEntryApplication.dstblDrainageUnits2();
			objDataSetTemp3 = new NBADWDataEntryApplication.dstblDrainageUnits3();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDrainDataSet(objDataSetTemp1, objDataSetTemp2, objDataSetTemp3);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblDrainageUnits1.Clear();
				objdstblDrainageUnits2.Clear();
				objdstblDrainageUnits3.Clear();
				// Merge the records into the main dataset.
				objdstblDrainageUnits1.Merge(objDataSetTemp1);
				objdstblDrainageUnits2.Merge(objDataSetTemp2);
				objdstblDrainageUnits3.Merge(objDataSetTemp3);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
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
			this.oleDbdaWaterbodySearch = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdsWaterbodySearch = new NBADWDataEntryApplication.dsWaterbodySearch();
			this.dvWaterbodySearch = new System.Data.DataView();
			this.oleDbdatblDrainageUnits1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.dvDrain1 = new System.Data.DataView();
			this.objdstblDrainageUnits1 = new NBADWDataEntryApplication.dstblDrainageUnits1();
			this.dvDrain2 = new System.Data.DataView();
			this.objdstblDrainageUnits2 = new NBADWDataEntryApplication.dstblDrainageUnits2();
			this.dvDrain3 = new System.Data.DataView();
			this.objdstblDrainageUnits3 = new NBADWDataEntryApplication.dstblDrainageUnits3();
			this.oleDbdatblDrainageUnits2 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbdatblDrainageUnits3 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.objdsWaterbodySearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvWaterbodySearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDrain1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblDrainageUnits1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDrain2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblDrainageUnits2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDrain3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblDrainageUnits3)).BeginInit();
			this.dgResults.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgResults_PageIndexChanged);
			this.dgResults.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgResults_EditCommand);
			this.dgResults.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgResults_SortCommand);
			// 
			// oleDbdaWaterbodySearch
			// 
			this.oleDbdaWaterbodySearch.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdaWaterbodySearch.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbdaWaterbodySearch.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "DE-Watersheds", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("DrainageCd", "DrainageCd"),
																																																							  new System.Data.Common.DataColumnMapping("DrainName", "DrainName"),
																																																							  new System.Data.Common.DataColumnMapping("Level1Name", "Level1Name"),
																																																							  new System.Data.Common.DataColumnMapping("Level2Name", "Level2Name"),
																																																							  new System.Data.Common.DataColumnMapping("Level3Name", "Level3Name"),
																																																							  new System.Data.Common.DataColumnMapping("WaterBodyID", "WaterBodyID"),
																																																							  new System.Data.Common.DataColumnMapping("WaterBodyName", "WaterBodyName"),
																																																							  new System.Data.Common.DataColumnMapping("WaterBodyName_Abrev", "WaterBodyName_Abrev")})});
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO [DE-Watersheds] (DrainageCd, DrainName, Level1Name, Level2Name, Level" +
				"3Name, WaterBodyID, WaterBodyName, WaterBodyName_Abrev) VALUES (?, ?, ?, ?, ?, ?" +
				", ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainName", System.Data.OleDb.OleDbType.VarWChar, 255, "DrainName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level1Name", System.Data.OleDb.OleDbType.VarWChar, 40, "Level1Name"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level2Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level2Name"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level3Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level3Name"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName_Abrev", System.Data.OleDb.OleDbType.VarWChar, 40, "WaterBodyName_Abrev"));
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
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT DrainageCd, DrainName, Level1Name, Level2Name, Level3Name, WaterBodyID, Wa" +
				"terBodyName, WaterBodyName_Abrev FROM [DE-Watersheds]";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO [DE-Watersheds] (DrainageCd, DrainName, Level1Name, Level2Name, Level" +
				"3Name, WaterBodyID, WaterBodyName) VALUES (?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainageCd", System.Data.OleDb.OleDbType.VarWChar, 17, "DrainageCd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("DrainName", System.Data.OleDb.OleDbType.VarWChar, 255, "DrainName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level1Name", System.Data.OleDb.OleDbType.VarWChar, 40, "Level1Name"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level2Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level2Name"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level3Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Level3Name"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyID", System.Data.OleDb.OleDbType.Integer, 0, "WaterBodyID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WaterBodyName", System.Data.OleDb.OleDbType.VarWChar, 55, "WaterBodyName"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT DrainageCd, DrainName, Level1Name, Level2Name, Level3Name, WaterBodyID, Wa" +
				"terBodyName FROM [DE-Watersheds]";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// objdsWaterbodySearch
			// 
			this.objdsWaterbodySearch.DataSetName = "dsWaterbodySearch";
			this.objdsWaterbodySearch.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvWaterbodySearch
			// 
			this.dvWaterbodySearch.Sort = "WaterBodyID asc";
			this.dvWaterbodySearch.Table = this.objdsWaterbodySearch._DE_Watersheds;
			// 
			// oleDbdatblDrainageUnits1
			// 
			this.oleDbdatblDrainageUnits1.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdatblDrainageUnits1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "tblDraingeUnit", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("Level1Name", "Level1Name"),
																																																								 new System.Data.Common.DataColumnMapping("Level1No", "Level1No")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT DISTINCT Level1Name, Level1No FROM tblDraingeUnit";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// dvDrain1
			// 
			this.dvDrain1.Sort = "Level1Name";
			this.dvDrain1.Table = this.objdstblDrainageUnits1.tblDraingeUnit;
			// 
			// objdstblDrainageUnits1
			// 
			this.objdstblDrainageUnits1.DataSetName = "dstblDrainageUnits1";
			this.objdstblDrainageUnits1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDrain2
			// 
			this.dvDrain2.Sort = "Level2Name";
			this.dvDrain2.Table = this.objdstblDrainageUnits2.tblDraingeUnit;
			// 
			// objdstblDrainageUnits2
			// 
			this.objdstblDrainageUnits2.DataSetName = "dstblDrainageUnits2";
			this.objdstblDrainageUnits2.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvDrain3
			// 
			this.dvDrain3.Sort = "Level3Name";
			this.dvDrain3.Table = this.objdstblDrainageUnits3.tblDraingeUnit;
			// 
			// objdstblDrainageUnits3
			// 
			this.objdstblDrainageUnits3.DataSetName = "dstblDrainageUnits3";
			this.objdstblDrainageUnits3.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdatblDrainageUnits2
			// 
			this.oleDbdatblDrainageUnits2.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdatblDrainageUnits2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "tblDraingeUnit", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("Level2Name", "Level2Name"),
																																																								 new System.Data.Common.DataColumnMapping("Level2No", "Level2No"),
																																																								 new System.Data.Common.DataColumnMapping("Level1No", "Level1No")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT DISTINCT Level2Name, Level2No, Level1No FROM tblDraingeUnit";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// oleDbdatblDrainageUnits3
			// 
			this.oleDbdatblDrainageUnits3.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbdatblDrainageUnits3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "tblDraingeUnit", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("Level3Name", "Level3Name"),
																																																								 new System.Data.Common.DataColumnMapping("Level3No", "Level3No"),
																																																								 new System.Data.Common.DataColumnMapping("Level1No", "Level1No"),
																																																								 new System.Data.Common.DataColumnMapping("Level2No", "Level2No")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT DISTINCT Level3Name, Level3No, Level1No, Level2No FROM tblDraingeUnit";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.objdsWaterbodySearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvWaterbodySearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDrain1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblDrainageUnits1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDrain2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblDrainageUnits2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvDrain3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblDrainageUnits3)).EndInit();

		}
		#endregion

		#region dgResults
		private void dgResults_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//Set current page of Datagrid to selected page
			dgResults.CurrentPageIndex = e.NewPageIndex;
			dvWaterbodySearch.RowFilter = Session["filterstring"].ToString();
			LoadDataSet();
			dgResults.DataBind();
		}


		private void dgResults_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i = (int)dgResults.DataKeys[(int) e.Item.ItemIndex];
			Session["SelectedWaterBodyID"] = i;
			Server.Transfer(Session["PreviousPage"].ToString());
		}

#endregion

		#region dlst Selected Index Changed
		protected void dlstDrain1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetdlstDrain2();
			dlstDrain3.Items.Clear();
		}

		protected void dlstDrain2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetdlstDrain3();
		}

		private void dgResults_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LoadDataSet();
			dvWaterbodySearch.Sort = e.SortExpression;
			dgResults.DataBind();
		}
		#endregion		
	}
}
