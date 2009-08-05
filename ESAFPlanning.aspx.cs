using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
	/// Summary description for ESAFPlanning.
	/// </summary>
	///
	
	public partial class ESAFPlanning : System.Web.UI.Page
	{
		#region Controls
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.DataView dvtblEnvironmentalPlanning;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblEnvironmentalPlanning;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected NBADWDataEntryApplication.dstblEnvPlanning dstblEnvPlanning1;
		protected NBADWDataEntryApplication.dstblEnvPlanning objdstblEnvPlanning;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		#endregion
        	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				dlstCategory.Items.Add(new ListItem("Land Use","Land Use"));
				dlstCategory.Items.Add(new ListItem("Water Quality","Water Quality"));
				dlstCategory.Items.Add(new ListItem("Instream Habitat","Instream Habitat"));
				dlstCategory.Items.Add(new ListItem("Riparian Quality & Process","Riparian Quality & Process"));
				dlstCategory.Items.Add(new ListItem("Physical Stream Character (e.g. width, depth, velocity)","Physical Stream Character"));

				dlstPriority.Items.Add(new ListItem("1 High", "1"));
				dlstPriority.Items.Add(new ListItem("2", "2"));
				dlstPriority.Items.Add(new ListItem("3", "3"));
				dlstPriority.Items.Add(new ListItem("4", "4"));
				dlstPriority.Items.Add(new ListItem("5", "5"));
				dlstPriority.Items.Add(new ListItem("6", "6"));
				dlstPriority.Items.Add(new ListItem("7", "7"));
				dlstPriority.Items.Add(new ListItem("8", "8"));
				dlstPriority.Items.Add(new ListItem("9", "9"));
				dlstPriority.Items.Add(new ListItem("10 Low", "10"));

				dvtblEnvironmentalPlanning.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
				dgCurrentRecords.DataBind();

				try
				{
					if((bool)Session["Modify"])
					{
						btnFinish.Visible = false;
						btnDone.Visible = true;
						LoadTable();
						dvtblEnvironmentalPlanning.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
						dgCurrentRecords.DataBind();

						//Set Labels
						lblh2.Text = "EDIT Assessment";
						lblStep.Visible = false;
					}
				}
				catch
				{
					//do nothing
				}
			}

		}


		#region Buttons
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			DataTable tEP = objdstblEnvPlanning.tblEnvironmentalPlanning;
			DataRow rEP = tEP.NewRow();

			rEP["AquaticActivityID"] = Session["CurrentActivityID"].ToString();
			rEP["IssueCategory"] = dlstCategory.SelectedValue;
			rEP["Issue"] = txtNature.Text;
			rEP["ActionRequired"] = txtActions.Text;
			if(txtTarget1.Text!="")
			{
				rEP["ActionTargetDate"] = txtTarget1.Text;
			}
			rEP["ActionPriority"] = dlstPriority.SelectedValue;
			if(txtCompleted1.Text!="")
			{
				rEP["ActionCompletionDate"] = txtCompleted1.Text;
			}
			rEP["FollowUpRequired"] = chkRequired.Checked;
			if(txtTarget2.Text!="")
			{
				rEP["FollowUpTargetDate"] = txtTarget2.Text;
			}
			if(txtCompleted2.Text!="")
			{
				rEP["FollowUpCompletionDate"] = txtCompleted2.Text;
			}

			tEP.Rows.Add(rEP);
            			
			try
			{
				oleDbdatblEnvironmentalPlanning.Update(objdstblEnvPlanning);
				ClearFields();
				LoadTable();
				dvtblEnvironmentalPlanning.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
				dgCurrentRecords.DataBind();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error during update of tblEnvironmental: "+ ex.ToString());
			}
		}

		protected void btnFinish_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFList.aspx");
		}

		protected void btnDone_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFView.aspx");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			//save record
			string strValues = "";
			strValues += "AquaticActivityID = "+Session["CurrentActivityID"].ToString();
			strValues += ", IssueCategory = '"+ dlstCategory.SelectedValue + "'";
			strValues += ", Issue = '" + txtNature.Text + "'";
			strValues += ", ActionRequired = '" + txtActions.Text + "'";
			if(txtTarget1.Text!="")
			{
				strValues += ", ActionTargetDate = '" + txtTarget1.Text + "'";
			}
			else
			{
				strValues += ", ActionTargetDate = Null";
			}
	
			if(txtCompleted1.Text!="")
			{
				strValues += ", ActionCompletionDate = '" + txtCompleted1.Text + "'";
			}
			else
			{
				strValues += ", ActionCompletionDate = Null";
			}

			strValues += ", ActionPriority = " + dlstPriority.SelectedValue;			
			strValues += ", FollowUpRequired = " + chkRequired.Checked;
			if(txtTarget2.Text!="")
			{
				strValues += ", FollowUpTargetDate = '" + txtTarget2.Text + "'";
			}
			else
			{
				strValues += ", FollowUpTargetDate = Null";
			}

			if(txtCompleted2.Text!="")
			{
				strValues += ", FollowUpCompletionDate = '" + txtCompleted2.Text + "'";
			}
			else
			{
				strValues += ", FollowUpCompletionDate = Null";
			}

			try
			{
				Debug.WriteLine("Values: "+strValues);
				string sql = "UPDATE tblEnvironmentalPlanning SET "+strValues+" WHERE EnvPlanningID = "+txtPlanningID.Text;
				Debug.WriteLine("SQL: "+sql);
				oleDbConnection1.Open();
				OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection1);
				cmd.ExecuteNonQuery();	
				oleDbConnection1.Close();
			}
			catch(System.Data.OleDb.OleDbException ex)
			{
				oleDbConnection1.Close();	
				Debug.WriteLine("Error during update: "+ex.ToString());
			}

			LoadTable();
			dvtblEnvironmentalPlanning.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
			dgCurrentRecords.DataBind();
			
			ClearFields();
			SetPageMode("Edit");//could pass anything here, just not "Modify"
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			ClearFields();
			SetPageMode("Edit");
		}
		#endregion

		#region Fill & Load
		public void FillTable(NBADWDataEntryApplication.dstblEnvPlanning dataSet3)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet3.EnforceConstraints = false;
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbdatblEnvironmentalPlanning.Fill(dataSet3);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet3.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}

		}


		public void LoadTable()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblEnvPlanning objDataSetTemp3;

			objDataSetTemp3 = new NBADWDataEntryApplication.dstblEnvPlanning();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillTable(objDataSetTemp3);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdstblEnvPlanning.Clear();
				// Merge the records into the main dataset.
				objdstblEnvPlanning.Merge(objDataSetTemp3);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}
		#endregion

		#region Show/Hide/Clear
		public void ClearFields()
		{
			txtNature.Text = "";
			txtActions.Text = "";
			txtTarget1.Text = "";
			txtCompleted1.Text = "";
			txtTarget2.Text = "";
			txtCompleted2.Text = "";
			chkRequired.Checked = false;

			dlstCategory.SelectedIndex = 0;
			dlstPriority.SelectedIndex = 0;
		}

		public void ShowModifyButtons()
		{
			btnSave.Visible = true;
			btnCancel.Visible = true;
		}

		public void HideModifyButtons()
		{
			btnSave.Visible = false;
			btnCancel.Visible = false;
		}
		public void ShowEditButtons()
		{
			btnAdd.Visible = true;
			btnDone.Visible = true;
		}

		public void HideEditButtons()
		{
			btnAdd.Visible = false;
			btnDone.Visible = false;
		}
		#endregion

		#region dgCurrentRecords
		private void dgCurrentRecords_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			LoadTable();
			int i = (int)dgCurrentRecords.DataKeys[(int) e.Item.ItemIndex];
						
			DataRow dr = objdstblEnvPlanning.tblEnvironmentalPlanning.Rows.Find(i);
			dr.Delete();
			
			try
			{
				oleDbdatblEnvironmentalPlanning.Update(objdstblEnvPlanning);
				LoadTable();
				dvtblEnvironmentalPlanning.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
				dgCurrentRecords.DataBind();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error during delete of tblEnvironmental: "+ ex.ToString());
			}
			// Add code to delete row from data source.
			//DataGrid1.DataBind();
		}

		private void dgCurrentRecords_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SetPageMode("Modify");	
			LoadTable();
			int i = (int)dgCurrentRecords.DataKeys[(int) e.Item.ItemIndex];

			txtPlanningID.Text = i.ToString();
						
			DataRow dr = objdstblEnvPlanning.tblEnvironmentalPlanning.Rows.Find(i);
			dlstCategory.SelectedValue = dr["IssueCategory"].ToString();
			txtNature.Text = dr["Issue"].ToString();
			txtActions.Text = dr["ActionRequired"].ToString();
			txtTarget1.Text = string.Format("{0:yyyy/MM/dd}",dr["ActionTargetDate"]);
            dlstPriority.SelectedValue = dr["ActionPriority"].ToString();
			txtCompleted1.Text = string.Format("{0:yyyy/MM/dd}",dr["ActionCompletionDate"]);
			chkRequired.Checked = (bool)dr["FollowUpRequired"];
			txtTarget2.Text = string.Format("{0:yyyy/MM/dd}",dr["FollowUpTargetDate"]);
			txtCompleted2.Text = string.Format("{0:yyyy/MM/dd}",dr["FollowUpCompletionDate"]);
		}
		#endregion

		public void SetPageMode(string mode)
		{
			switch(mode)
			{
				case "Modify":
					ShowModifyButtons();
					HideEditButtons();
					pnlPlanningList.Visible = false;
					pnlInstructions.Visible = false;
					break;
				default:
					Debug.Write("default setting triggered");
					HideModifyButtons();
					ShowEditButtons();
					pnlPlanningList.Visible = true;
					pnlInstructions.Visible = true;
					break;
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
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.dvtblEnvironmentalPlanning = new System.Data.DataView();
			this.objdstblEnvPlanning = new NBADWDataEntryApplication.dstblEnvPlanning();
			this.oleDbdatblEnvironmentalPlanning = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalPlanning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvPlanning)).BeginInit();
			this.dgCurrentRecords.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCurrentRecords_EditCommand);
			this.dgCurrentRecords.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCurrentRecords_DeleteCommand);
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
			// dvtblEnvironmentalPlanning
			// 
			this.dvtblEnvironmentalPlanning.Table = this.objdstblEnvPlanning.tblEnvironmentalPlanning;
			// 
			// objdstblEnvPlanning
			// 
			this.objdstblEnvPlanning.DataSetName = "dstblEnvPlanning";
			this.objdstblEnvPlanning.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdatblEnvironmentalPlanning
			// 
			this.oleDbdatblEnvironmentalPlanning.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbdatblEnvironmentalPlanning.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdatblEnvironmentalPlanning.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdatblEnvironmentalPlanning.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "tblEnvironmentalPlanning", new System.Data.Common.DataColumnMapping[] {
																																																												  new System.Data.Common.DataColumnMapping("ActionCompletionDate", "ActionCompletionDate"),
																																																												  new System.Data.Common.DataColumnMapping("ActionPriority", "ActionPriority"),
																																																												  new System.Data.Common.DataColumnMapping("ActionRequired", "ActionRequired"),
																																																												  new System.Data.Common.DataColumnMapping("ActionTargetDate", "ActionTargetDate"),
																																																												  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																												  new System.Data.Common.DataColumnMapping("EnvPlanningID", "EnvPlanningID"),
																																																												  new System.Data.Common.DataColumnMapping("FollowUpCompletionDate", "FollowUpCompletionDate"),
																																																												  new System.Data.Common.DataColumnMapping("FollowUpRequired", "FollowUpRequired"),
																																																												  new System.Data.Common.DataColumnMapping("FollowUpTargetDate", "FollowUpTargetDate"),
																																																												  new System.Data.Common.DataColumnMapping("Issue", "Issue"),
																																																												  new System.Data.Common.DataColumnMapping("IssueCategory", "IssueCategory")})});
			this.oleDbdatblEnvironmentalPlanning.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM tblEnvironmentalPlanning WHERE (EnvPlanningID = ?) AND (ActionCompletionDate = ? OR ? IS NULL AND ActionCompletionDate IS NULL) AND (ActionPriority = ? OR ? IS NULL AND ActionPriority IS NULL) AND (ActionRequired = ? OR ? IS NULL AND ActionRequired IS NULL) AND (ActionTargetDate = ? OR ? IS NULL AND ActionTargetDate IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FollowUpCompletionDate = ? OR ? IS NULL AND FollowUpCompletionDate IS NULL) AND (FollowUpRequired = ?) AND (FollowUpTargetDate = ? OR ? IS NULL AND FollowUpTargetDate IS NULL) AND (Issue = ? OR ? IS NULL AND Issue IS NULL) AND (IssueCategory = ? OR ? IS NULL AND IssueCategory IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvPlanningID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvPlanningID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tblEnvironmentalPlanning(ActionCompletionDate, ActionPriority, Action" +
				"Required, ActionTargetDate, AquaticActivityID, FollowUpCompletionDate, FollowUpR" +
				"equired, FollowUpTargetDate, Issue, IssueCategory) VALUES (?, ?, ?, ?, ?, ?, ?, " +
				"?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionCompletionDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, "ActionPriority"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, "ActionRequired"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionTargetDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpCompletionDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, "FollowUpRequired"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpTargetDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Issue", System.Data.OleDb.OleDbType.VarWChar, 250, "Issue"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, "IssueCategory"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ActionCompletionDate, ActionPriority, ActionRequired, ActionTargetDate, Aq" +
				"uaticActivityID, EnvPlanningID, FollowUpCompletionDate, FollowUpRequired, Follow" +
				"UpTargetDate, Issue, IssueCategory FROM tblEnvironmentalPlanning";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE tblEnvironmentalPlanning SET ActionCompletionDate = ?, ActionPriority = ?, ActionRequired = ?, ActionTargetDate = ?, AquaticActivityID = ?, FollowUpCompletionDate = ?, FollowUpRequired = ?, FollowUpTargetDate = ?, Issue = ?, IssueCategory = ? WHERE (EnvPlanningID = ?) AND (ActionCompletionDate = ? OR ? IS NULL AND ActionCompletionDate IS NULL) AND (ActionPriority = ? OR ? IS NULL AND ActionPriority IS NULL) AND (ActionRequired = ? OR ? IS NULL AND ActionRequired IS NULL) AND (ActionTargetDate = ? OR ? IS NULL AND ActionTargetDate IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FollowUpCompletionDate = ? OR ? IS NULL AND FollowUpCompletionDate IS NULL) AND (FollowUpRequired = ?) AND (FollowUpTargetDate = ? OR ? IS NULL AND FollowUpTargetDate IS NULL) AND (Issue = ? OR ? IS NULL AND Issue IS NULL) AND (IssueCategory = ? OR ? IS NULL AND IssueCategory IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionCompletionDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, "ActionPriority"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, "ActionRequired"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionTargetDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpCompletionDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, "FollowUpRequired"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpTargetDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Issue", System.Data.OleDb.OleDbType.VarWChar, 250, "Issue"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, "IssueCategory"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvPlanningID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvPlanningID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT ActionCompletionDate, ActionPriority, ActionRequired, ActionTargetDate, Aq" +
				"uaticActivityID, EnvPlanningID, FollowUpCompletionDate, FollowUpRequired, Follow" +
				"UpTargetDate, Issue, IssueCategory FROM tblEnvironmentalPlanning";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tblEnvironmentalPlanning(ActionCompletionDate, ActionPriority, Action" +
				"Required, ActionTargetDate, AquaticActivityID, FollowUpCompletionDate, FollowUpR" +
				"equired, FollowUpTargetDate, Issue, IssueCategory) VALUES (?, ?, ?, ?, ?, ?, ?, " +
				"?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionCompletionDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, "ActionPriority"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, "ActionRequired"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionTargetDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpCompletionDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, "FollowUpRequired"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpTargetDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Issue", System.Data.OleDb.OleDbType.VarWChar, 250, "Issue"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, "IssueCategory"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE tblEnvironmentalPlanning SET ActionCompletionDate = ?, ActionPriority = ?, ActionRequired = ?, ActionTargetDate = ?, AquaticActivityID = ?, FollowUpCompletionDate = ?, FollowUpRequired = ?, FollowUpTargetDate = ?, Issue = ?, IssueCategory = ? WHERE (EnvPlanningID = ?) AND (ActionCompletionDate = ? OR ? IS NULL AND ActionCompletionDate IS NULL) AND (ActionPriority = ? OR ? IS NULL AND ActionPriority IS NULL) AND (ActionRequired = ? OR ? IS NULL AND ActionRequired IS NULL) AND (ActionTargetDate = ? OR ? IS NULL AND ActionTargetDate IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FollowUpCompletionDate = ? OR ? IS NULL AND FollowUpCompletionDate IS NULL) AND (FollowUpRequired = ?) AND (FollowUpTargetDate = ? OR ? IS NULL AND FollowUpTargetDate IS NULL) AND (Issue = ? OR ? IS NULL AND Issue IS NULL) AND (IssueCategory = ? OR ? IS NULL AND IssueCategory IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionCompletionDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, "ActionPriority"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, "ActionRequired"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "ActionTargetDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpCompletionDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, "FollowUpRequired"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, "FollowUpTargetDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Issue", System.Data.OleDb.OleDbType.VarWChar, 250, "Issue"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, "IssueCategory"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvPlanningID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvPlanningID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM tblEnvironmentalPlanning WHERE (EnvPlanningID = ?) AND (ActionCompletionDate = ? OR ? IS NULL AND ActionCompletionDate IS NULL) AND (ActionPriority = ? OR ? IS NULL AND ActionPriority IS NULL) AND (ActionRequired = ? OR ? IS NULL AND ActionRequired IS NULL) AND (ActionTargetDate = ? OR ? IS NULL AND ActionTargetDate IS NULL) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FollowUpCompletionDate = ? OR ? IS NULL AND FollowUpCompletionDate IS NULL) AND (FollowUpRequired = ?) AND (FollowUpTargetDate = ? OR ? IS NULL AND FollowUpTargetDate IS NULL) AND (Issue = ? OR ? IS NULL AND Issue IS NULL) AND (IssueCategory = ? OR ? IS NULL AND IssueCategory IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvPlanningID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvPlanningID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionPriority1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionRequired1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActionTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActionTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpCompletionDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpCompletionDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpRequired", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FollowUpTargetDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FollowUpTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Issue1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Issue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IssueCategory1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IssueCategory", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalPlanning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvPlanning)).EndInit();

		}
		#endregion

		
	}
}
