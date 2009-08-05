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
	/// Summary description for ESAFSiteObservations_WaterCrossing.
	/// </summary>
	public partial class ESAFSiteObservations : System.Web.UI.Page
	{
		#region Controls
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected NBADWDataEntryApplication.dscdEnvironmentalObservations objdscdEnvironmentalObservations;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdatblEnvironmentalObservations;
		protected NBADWDataEntryApplication.dstblEnvironmentalObservations objdstblEnvironmentalObservations;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdEnvironmentalObservations;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbDataAdapter oleDbdacdEnvironmentalObservations_Groups;
		protected System.Data.DataView dvcdEnvironmentalObservations;
		protected NBADWDataEntryApplication.dscdEnvironmentalObservations_Groups objdscdEnvironmentalObservations_Groups;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		protected System.Data.DataView dvtblEnvironmentalObservations;	
		#endregion
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				LoadDataSets();
				dlstObservationGroup.DataBind();
				dlstObservationGroup.SelectedIndex = 0;
				SetdlstObservation();
				dvtblEnvironmentalObservations.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
				dgCurrentRecords.DataBind();
				
				try
				{
					if((bool)Session["Modify"])
					{
						dvtblEnvironmentalObservations.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
						dgCurrentRecords.DataBind();
						btnNext.Visible = false;
						btnReturn.Visible = true;

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
			else//retrieve datasets
			{
				System.IO.StringReader sr1 = new System.IO.StringReader((string)(ViewState["dSet1"]));
				System.IO.StringReader sr2 = new System.IO.StringReader((string)(ViewState["dSet2"]));
				//System.IO.StringReader sr3 = new System.IO.StringReader((string)(ViewState["dSet3"]));
				
				objdscdEnvironmentalObservations_Groups.ReadXml(sr1);
				objdscdEnvironmentalObservations.ReadXml(sr2);
				//objdstblEnvironmentalObservations.ReadXml(sr3);
			}
		}


		#region SetValues
		public void SetdlstObservation()
		{
			
			Debug.WriteLine("Setting observations");
			dvcdEnvironmentalObservations.RowFilter= "ObservationGroup= '"+dlstObservationGroup.SelectedItem+ "'";
			dlstObservation.DataBind();
			dlstObservation.SelectedIndex = 0;
			SetSupplimentaryFields();
		}

		public void SetSupplimentaryFields()
		{
			ClearSupplimentaryValues();
			switch (dlstObservation.SelectedValue)
			{
				//Other 
				case "4":
				case "15":
				case "18":
				case "22":
				case "33":
				case "37":
				case "38":
				case "43":
				case "48":
				case "57":
					lblSpecify.Visible = true;
					txtSpecify.Visible = true;
					break;
				//Pipe Size
				case "8":
					lblPipeSize.Visible = true;
					txtPipeSize.Visible = true;
                    txtPipeSizeValidator.Enabled = true;
					break;
				//Obstruction of fish passage
				case "23":
				case "24":
				case "28":
				case "29":
				case "49":
				case "50":
				case "51":
				case "52":
					lblObstruction.Visible = true;
					chkObstruction.Visible = true;
					break;
				//Name/Species
				case "34":
				case "35":
				case "36":
					lblSpecies.Visible = true;
					txtSpecies.Visible = true;
					break;
				//Specify Name
				case "46":
					lblName.Visible = true;
					txtName.Visible = true;
					break;
			}
		}

		public void ClearSupplimentaryValues()
		{
			lblSpecify.Visible = false;
			txtSpecify.Visible = false;
			lblPipeSize.Visible = false;
			txtPipeSize.Visible = false;
            txtPipeSizeValidator.Enabled = false;
			lblObstruction.Visible = false;
			chkObstruction.Visible = false;
			lblSpecies.Visible = false;
			txtSpecies.Visible = false;
			lblName.Visible = false;
			txtName.Visible = false;
		}
		#endregion

		#region Fill & Load
		public void FillDataSets(NBADWDataEntryApplication.dscdEnvironmentalObservations_Groups dataSet1, NBADWDataEntryApplication.dscdEnvironmentalObservations dataSet2, NBADWDataEntryApplication.dstblEnvironmentalObservations dataSet3)
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
				this.oleDbdacdEnvironmentalObservations_Groups.Fill(dataSet1);
				this.oleDbdacdEnvironmentalObservations.Fill(dataSet2);
				this.oleDbdatblEnvironmentalObservations.Fill(dataSet3);
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
				//System.IO.StringWriter sw3 = new System.IO.StringWriter();
				
				// Write the DataSet to the ViewState property.
				dataSet1.WriteXml(sw1);
				dataSet2.WriteXml(sw2);
				//dataSet3.WriteXml(sw3);
				ViewState["dSet1"] = sw1.ToString();
				ViewState["dSet2"] = sw2.ToString();
				//ViewState["dSet3"] = sw3.ToString();

				//tEO = objdstblEnvironmentalObservations.Tables["tblEnvironmentalObservations"];
			}

		}


		public void LoadDataSets()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dscdEnvironmentalObservations_Groups objDataSetTemp1;
			NBADWDataEntryApplication.dscdEnvironmentalObservations objDataSetTemp2;
			NBADWDataEntryApplication.dstblEnvironmentalObservations objDataSetTemp3;

			objDataSetTemp1 = new NBADWDataEntryApplication.dscdEnvironmentalObservations_Groups();
			objDataSetTemp2 = new NBADWDataEntryApplication.dscdEnvironmentalObservations();
			objDataSetTemp3 = new NBADWDataEntryApplication.dstblEnvironmentalObservations();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDataSets(objDataSetTemp1, objDataSetTemp2, objDataSetTemp3);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				// Empty the old records from the dataset.
				objdscdEnvironmentalObservations_Groups.Clear();
				objdscdEnvironmentalObservations.Clear();
				objdstblEnvironmentalObservations.Clear();
				// Merge the records into the main dataset.
				objdscdEnvironmentalObservations_Groups.Merge(objDataSetTemp1);
				objdscdEnvironmentalObservations.Merge(objDataSetTemp2);
				objdstblEnvironmentalObservations.Merge(objDataSetTemp3);
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		public void FillTable(NBADWDataEntryApplication.dstblEnvironmentalObservations dataSet3)
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
				this.oleDbdatblEnvironmentalObservations.Fill(dataSet3);
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

				//System.IO.StringWriter sw3 = new System.IO.StringWriter();
				
				// Write the DataSet to the ViewState property.
				//dataSet3.WriteXml(sw3);
				
				//ViewState["dSet3"] = sw3.ToString();
			}

		}


		public void LoadTable()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			NBADWDataEntryApplication.dstblEnvironmentalObservations objDataSetTemp3;

			objDataSetTemp3 = new NBADWDataEntryApplication.dstblEnvironmentalObservations();
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
				objdstblEnvironmentalObservations.Clear();
				// Merge the records into the main dataset.
				objdstblEnvironmentalObservations.Merge(objDataSetTemp3);
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
			this.oleDbdacdEnvironmentalObservations_Groups = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.objdscdEnvironmentalObservations = new NBADWDataEntryApplication.dscdEnvironmentalObservations();
			this.oleDbdatblEnvironmentalObservations = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.objdstblEnvironmentalObservations = new NBADWDataEntryApplication.dstblEnvironmentalObservations();
			this.dvcdEnvironmentalObservations = new System.Data.DataView();
			this.oleDbdacdEnvironmentalObservations = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.objdscdEnvironmentalObservations_Groups = new NBADWDataEntryApplication.dscdEnvironmentalObservations_Groups();
			this.dvtblEnvironmentalObservations = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.objdscdEnvironmentalObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvironmentalObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdEnvironmentalObservations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdEnvironmentalObservations_Groups)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalObservations)).BeginInit();
			this.dgCurrentRecords.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCurrentRecords_DeleteCommand);
			// 
			// oleDbdacdEnvironmentalObservations_Groups
			// 
			this.oleDbdacdEnvironmentalObservations_Groups.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbdacdEnvironmentalObservations_Groups.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																new System.Data.Common.DataTableMapping("Table", "cdEnvironmentalObservations", new System.Data.Common.DataColumnMapping[] {
																																																															   new System.Data.Common.DataColumnMapping("ObservationGroup", "ObservationGroup")})});
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT MIN(ObservationID) AS ObservationID, ObservationGroup FROM cdEnvironmental" +
				"Observations GROUP BY ObservationGroup ORDER BY MIN(ObservationID)";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
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
			// objdscdEnvironmentalObservations
			// 
			this.objdscdEnvironmentalObservations.DataSetName = "dscdEnvironmentalObservations";
			this.objdscdEnvironmentalObservations.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbdatblEnvironmentalObservations
			// 
			this.oleDbdatblEnvironmentalObservations.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbdatblEnvironmentalObservations.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbdatblEnvironmentalObservations.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbdatblEnvironmentalObservations.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "tblEnvironmentalObservations", new System.Data.Common.DataColumnMapping[] {
																																																														  new System.Data.Common.DataColumnMapping("AquaticActivityID", "AquaticActivityID"),
																																																														  new System.Data.Common.DataColumnMapping("EnvObservationID", "EnvObservationID"),
																																																														  new System.Data.Common.DataColumnMapping("FishPassageObstructionInd", "FishPassageObstructionInd"),
																																																														  new System.Data.Common.DataColumnMapping("Observation", "Observation"),
																																																														  new System.Data.Common.DataColumnMapping("ObservationGroup", "ObservationGroup"),
																																																														  new System.Data.Common.DataColumnMapping("ObservationSupp", "ObservationSupp"),
																																																														  new System.Data.Common.DataColumnMapping("PipeSize_cm", "PipeSize_cm")})});
			this.oleDbdatblEnvironmentalObservations.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM tblEnvironmentalObservations WHERE (EnvObservationID = ?)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EnvObservationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvObservationID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tblEnvironmentalObservations(AquaticActivityID, FishPassageObstructio" +
				"nInd, Observation, ObservationGroup, ObservationSupp, PipeSize_cm) VALUES (?, ?," +
				" ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishPassageObstructionInd"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Observation", System.Data.OleDb.OleDbType.VarWChar, 50, "Observation"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationGroup"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationSupp"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, "PipeSize_cm"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT AquaticActivityID, EnvObservationID, FishPassageObstructionInd, Observatio" +
				"n, ObservationGroup, ObservationSupp, PipeSize_cm FROM tblEnvironmentalObservati" +
				"ons";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE tblEnvironmentalObservations SET AquaticActivityID = ?, FishPassageObstructionInd = ?, Observation = ?, ObservationGroup = ?, ObservationSupp = ?, PipeSize_cm = ? WHERE (EnvObservationID = ?) AND (AquaticActivityID = ? OR ? IS NULL AND AquaticActivityID IS NULL) AND (FishPassageObstructionInd = ?) AND (Observation = ? OR ? IS NULL AND Observation IS NULL) AND (ObservationGroup = ? OR ? IS NULL AND ObservationGroup IS NULL) AND (ObservationSupp = ? OR ? IS NULL AND ObservationSupp IS NULL) AND (PipeSize_cm = ? OR ? IS NULL AND PipeSize_cm IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, "AquaticActivityID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, "FishPassageObstructionInd"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Observation", System.Data.OleDb.OleDbType.VarWChar, 50, "Observation"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationGroup"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationSupp", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationSupp"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, "PipeSize_cm"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EnvObservationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EnvObservationID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AquaticActivityID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AquaticActivityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FishPassageObstructionInd", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FishPassageObstructionInd", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationSupp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationSupp1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationSupp", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PipeSize_cm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PipeSize_cm", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PipeSize_cm1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PipeSize_cm", System.Data.DataRowVersion.Original, null));
			// 
			// objdstblEnvironmentalObservations
			// 
			this.objdstblEnvironmentalObservations.DataSetName = "dstblEnvironmentalObservations";
			this.objdstblEnvironmentalObservations.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvcdEnvironmentalObservations
			// 
			this.dvcdEnvironmentalObservations.Table = this.objdscdEnvironmentalObservations.cdEnvironmentalObservations;
			// 
			// oleDbdacdEnvironmentalObservations
			// 
			this.oleDbdacdEnvironmentalObservations.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbdacdEnvironmentalObservations.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbdacdEnvironmentalObservations.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbdacdEnvironmentalObservations.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														 new System.Data.Common.DataTableMapping("Table", "cdEnvironmentalObservations", new System.Data.Common.DataColumnMapping[] {
																																																														new System.Data.Common.DataColumnMapping("Observation", "Observation"),
																																																														new System.Data.Common.DataColumnMapping("ObservationCategory", "ObservationCategory"),
																																																														new System.Data.Common.DataColumnMapping("ObservationGroup", "ObservationGroup"),
																																																														new System.Data.Common.DataColumnMapping("ObservationID", "ObservationID")})});
			this.oleDbdacdEnvironmentalObservations.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM cdEnvironmentalObservations WHERE (ObservationID = ?) AND (Observation = ? OR ? IS NULL AND Observation IS NULL) AND (ObservationCategory = ? OR ? IS NULL AND ObservationCategory IS NULL) AND (ObservationGroup = ? OR ? IS NULL AND ObservationGroup IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationCategory", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationCategory1", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO cdEnvironmentalObservations(Observation, ObservationCategory, Observa" +
				"tionGroup) VALUES (?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Observation", System.Data.OleDb.OleDbType.VarWChar, 50, "Observation"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationCategory", System.Data.OleDb.OleDbType.VarWChar, 40, "ObservationCategory"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationGroup"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT Observation, ObservationCategory, ObservationGroup, ObservationID FROM cdE" +
				"nvironmentalObservations";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE cdEnvironmentalObservations SET Observation = ?, ObservationCategory = ?, ObservationGroup = ? WHERE (ObservationID = ?) AND (Observation = ? OR ? IS NULL AND Observation IS NULL) AND (ObservationCategory = ? OR ? IS NULL AND ObservationCategory IS NULL) AND (ObservationGroup = ? OR ? IS NULL AND ObservationGroup IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Observation", System.Data.OleDb.OleDbType.VarWChar, 50, "Observation"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationCategory", System.Data.OleDb.OleDbType.VarWChar, 40, "ObservationCategory"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, "ObservationGroup"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Observation1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Observation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationCategory", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationCategory1", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationCategory", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ObservationGroup1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ObservationGroup", System.Data.DataRowVersion.Original, null));
			// 
			// objdscdEnvironmentalObservations_Groups
			// 
			this.objdscdEnvironmentalObservations_Groups.DataSetName = "dscdEnvironmentalObservations_Groups";
			this.objdscdEnvironmentalObservations_Groups.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvtblEnvironmentalObservations
			// 
			this.dvtblEnvironmentalObservations.Table = this.objdstblEnvironmentalObservations.tblEnvironmentalObservations;
			((System.ComponentModel.ISupportInitialize)(this.objdscdEnvironmentalObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdstblEnvironmentalObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvcdEnvironmentalObservations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objdscdEnvironmentalObservations_Groups)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvtblEnvironmentalObservations)).EndInit();

		}
		#endregion

		#region Index Changed
		protected void dlstObservationGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Debug.WriteLine("index has changed");
			SetdlstObservation();
			
		}

		protected void dlstObservation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetSupplimentaryFields();
		}
		#endregion

		#region Buttons
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			DataTable tEO = objdstblEnvironmentalObservations.tblEnvironmentalObservations;
			DataRow rEO = tEO.NewRow();

			rEO["AquaticActivityID"] = Session["CurrentActivityID"];
			rEO["ObservationGroup"] = dlstObservationGroup.SelectedItem;
			rEO["Observation"] = dlstObservation.SelectedItem;
			if (txtSpecify.Visible)
			{
				rEO["ObservationSupp"] = txtSpecify.Text;
			}
			if (txtPipeSize.Visible)
			{
                try
                {
                    rEO["PipeSize_cm"] = int.Parse(txtPipeSize.Text);
                }
                catch (Exception)
                {
                }
			}
			if (chkObstruction.Visible)
			{
				rEO["FishPassageObstructionInd"] = chkObstruction.Checked;
			}
			if (txtSpecies.Visible)
			{
				rEO["ObservationSupp"] = txtSpecies.Text;
			}
			if (txtName.Visible)
			{
				rEO["ObservationSupp"] = txtName.Text;
			}

			tEO.Rows.Add(rEO);
			
			try
			{
				oleDbdatblEnvironmentalObservations.Update(objdstblEnvironmentalObservations);
				LoadTable();
				dvtblEnvironmentalObservations.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
				dgCurrentRecords.DataBind();
				if(!(bool)Session["Modify"])
				{
					btnNext.Visible = true;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error during update of tblEnvironmental: "+ ex.ToString());
			}

		}

		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFSiteCharacteristics.aspx");
		}

		protected void btnReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ESAFView.aspx");
		}
		#endregion

		private void dgCurrentRecords_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			LoadTable();
			int i = (int)dgCurrentRecords.DataKeys[(int) e.Item.ItemIndex];
						
			DataRow dr = objdstblEnvironmentalObservations.tblEnvironmentalObservations.Rows.Find(i);
			dr.Delete();
			
			try
			{
				oleDbdatblEnvironmentalObservations.Update(objdstblEnvironmentalObservations);
				LoadTable();
				dvtblEnvironmentalObservations.RowFilter = "AquaticActivityID = '"+Session["CurrentActivityID"].ToString()+"'";
				dgCurrentRecords.DataBind();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error during delete of tblEnvironmental: "+ ex.ToString());
			}
			
		}

				
	}
}
