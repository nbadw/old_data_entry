<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ELECTView" CodeFile="ELECTView.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ELECTView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>ELECTROFISHING</h1>
		<h2><asp:label id="lblh2" runat="server" Font-Names="Times New Roman" Font-Bold="True">VIEW</asp:label></h2>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlInstructions1" runat="server">
				<FIELDSET class="standardText"><LEGEND>Step 1 - Enter Activity and Method Details</LEGEND>
					<UL>
						<LI>
						Enter the activity and method details below.
						<LI>
							Click <B>Next</B> to move to the next page of data entry or <B>Cancel</B> to 
							stop data entry and return to the Electrofishing List.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructions2" runat="server">
				<FIELDSET class="standardText"><LEGEND>Step 2 - Enter Site Details</LEGEND>
					<UL>
						<LI>
						Ensure the site measurements on the paper form match the units below.
						<LI>
							Percentages of stream types and substrate types must each equal 100%.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructions3" runat="server">
				<FIELDSET class="standardText"><LEGEND>Step 3 - Enter Photos</LEGEND>
					<UL>
						<LI>
						Enter the path and folder name where the photo is stored and the photo’s file 
						name.
						<LI>
							Click the <B>Add</B>
						button to add the photo record to the Photo List.
						<LI>
							Click <U><B>Delete</B></U>
						to remove a photo in the Photo List.
						<LI>
							Click the <B>Next</B> button to move to the next page of data entry.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructions4" runat="server">
				<FIELDSET class="standardText"><LEGEND>Step 4 - Enter Water Measurements</LEGEND>
					<UL>
						<LI>
							Ensure the water measurements on the paper form match the units below.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructions6a" runat="server">
				<FIELDSET class="standardText"><LEGEND>Step 5 - Enter Sweep Data</LEGEND>
					<UL>
						<LI>
						Enter the length, weight and sweep data for a species and age class.
						<LI>
							Click <B>Calculate Zippin Estimates</B> to calculate the populate estimates or 
							click <B>Enter Estimates</B>
						if you wish to enter your own estimates.
						<LI>
						Remember to recalculate the estimates if you change the sweep data.
						<LI>
							Click the <B>Add</B>
						button to add the data to the Sweep Data List.
						<LI>
							To change data once it is added to the Sweep Data List, click <U><B>Modify</B></U>
						in the row of interest.
						<LI>
							Click <U><B>Delete</B></U>
						to remove a record in the Sweep Data List.
						<LI>
							Click the <B>Done</B> button when finished.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructionsSiteMeasurementsModify" Runat="server">
				<FIELDSET class="standardtext"><LEGEND>Site Measurements</LEGEND>
					<UL>
						<LI>
						The Site Measurements List contains data that has already been input.
						<LI>
							To add additional measurements, complete the Site Measurement Input section, 
							then click the <B>Add</B>
						button to add the parameter to the Site Measurements List.
						<LI>
							Click <U><B>Delete</B></U>
						to remove a record in the Site Measurements List.
						<LI>
							Click <B>Done</B> when finished editing.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructionsSitePhotosModify" Runat="server">
				<FIELDSET class="standardtext"><LEGEND>Site Photos</LEGEND>
					<UL>
						<LI>
						The Photos List contains data that has already been input.
						<LI>
							To add additional photos, complete the Photo Input section, then click the <B>Add</B>
						button to add the photo to the Photos List.
						<LI>
							Click <B><U>Delete</U></B>
						to remove a photo in the Photos List.
						<LI>
							Click <B>Done</B> when finished editing.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructionsWaterMeasurementsModify" Runat="server">
				<FIELDSET class="standardtext"><LEGEND>Water Measurements</LEGEND>
					<UL>
						<LI>
						The Water Measurements List contains data that has already been input.
						<LI>
							To add additional measurements, complete the Water Measurement Input section, 
							then click the <B>Add</B>
						button to add the parameter to the Water Measurements List/
						<LI>
							Click <B><U>Delete</U></B>
						to remove a record in the Water Measurements List.
						<LI>
							Click <B>Done</B> when finished editing.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructionsSweepDataModify" Runat="server">
				<FIELDSET class="standardtext"><LEGEND>Sweep Data &amp; Population Estimates</LEGEND>
					<UL>
						<LI>
						The Sweep Data List contains data that has already been input.
						<LI>
							To add additional data, complete the Sweep Data and Population Estimate Input 
							section:
							<UL>
								<LI>
								Enter the length, weight and sweep data for a species and age class
								<LI>
									Click <B>Calculate Zippin Estimates</B> to calculate the populate estimates or 
									click <B>Enter Estimates</B>
								if you wish to enter your own estimates.
								<LI>
								Remember to recalculate the estimates if you change the sweep data.
								<LI>
									Click the <B>Add</B> button to add the data to the Sweep Data List.
								</LI>
							</UL>
						<LI>
							To change data in Sweep Data List, click <U><B>Modify</B></U>
						in the row of interest.
						<LI>
							Click <U><B>Delete</B></U>
						to remove a record in the Sweep Data List.
						<LI>
							Click the <B>Done</B> button when finished editing.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructionsChangeSite" Runat="server">
				<FIELDSET class="standardtext"><LEGEND>Instructions</LEGEND>
					<UL>
						<LI>
						The electrofishing data below is now linked to a different site.
						<LI>
							Click the <B>Save</B> button on the bottom of the page to save this change or 
							click <B>Cancel</B> to abort the site change.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlInstructionsView" Runat="server">
				<FIELDSET class="standardtext"><LEGEND>Instructions</LEGEND>
					<UL>
						<LI>
							If the electrofishing data has been assigned to the wrong site, you may change 
							the site by clicking <B>Change Site for Current Electrofishing</B>. You 
						will be presented with a list of electrofishing sites set up by your 
						organization.
						<LI>
							The other sections of electrofishing data may be modified by clicking the <B>Modify</B>
						button in the appropriate section.
						<LI>
							All of the electrofishing data currently being viewed can be deleted by 
							clicking the <B>Delete</B>
						button at the bottom of the page.
						<LI>
							Click the <B>Return to Electrofishing Site List</B> button at the bottom of the 
							page to return to the site list.
						</LI>
					</UL>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlSiteInfo" runat="server"><BR>
				<FIELDSET class="standardText"><LEGEND>Site Info</LEGEND>
					<TABLE width="100%" border="0">
						<TR>
							<TD vAlign="top">
								<asp:label id="Label1" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label><BR>
								<asp:textbox id="txtdwsiteid" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><BR>
								<asp:button id="btnChangeSite" tabIndex="2" runat="server" CssClass="buttonText" Text="Change Site for Current Electrofishing"
									CausesValidation="False" onclick="btnChangeSite_Click"></asp:button></TD>
							<TD vAlign="top">
								<asp:label id="Label6" runat="server" CssClass="labelText">Site Name:</asp:label><BR>
								<asp:textbox id="txtsitename" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox></TD>
						</TR>
						<TR>
							<TD vAlign="top"></TD>
							<TD vAlign="top">
								<asp:label id="Label7" runat="server" CssClass="labelText">Site Description:</asp:label><BR>
								<asp:textbox id="txtsitedescription" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox></TD>
						</TR>
						<TR>
							<TD vAlign="top">
								<asp:label id="Label9" runat="server" CssClass="labelText">Agency Code:</asp:label><BR>
								<asp:textbox id="txtagencycd" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></TD>
							<TD vAlign="top">
								<asp:label id="Label2" runat="server" CssClass="labelText">Agency Site ID:</asp:label><BR>
								<asp:textbox id="txtgroupsiteid" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></TD>
						</TR>
						<TR>
							<TD vAlign="top">
								<asp:label id="Label3" runat="server" CssClass="labelText">Water Body ID:</asp:label><BR>
								<asp:textbox id="txtwaterbodyid" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></TD>
							<TD vAlign="top">
								<asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label><BR>
								<asp:textbox id="txtwaterbodyname" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox><BR>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top">
								<asp:label id="Label8" runat="server" CssClass="labelText">Watershed Code:</asp:label><BR>
								<asp:textbox id="txtwatershedcode" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></TD>
							<TD vAlign="top">
								<asp:label id="Label5" runat="server" CssClass="labelText">Watershed:</asp:label><BR>
								<asp:textbox id="txtwatershed" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox><BR>
							</TD>
						</TR>
					</TABLE>
				</FIELDSET>
			</asp:panel><asp:panel id="pnlActivityDetails" Runat="server"><BR>
				<FIELDSET class="standardText"><LEGEND>Activity Details</LEGEND>
					<TABLE border="0">
						<TR>
							<TD>
								<asp:Label id="Label44" runat="server" CssClass="labeltext">Fish Collection Permit #:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtFishCollectionPermit1" runat="server" BackColor="WhiteSmoke" Enabled="False"
									Width="100%"></asp:TextBox>
								<asp:TextBox id="txtFishCollectionPermit2" runat="server" Width="100%"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label12" runat="server" CssClass="labeltext">Date (yyyy/mm/dd):</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtDate1" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="100%"></asp:TextBox>
								<asp:TextBox id="txtDate2" runat="server" Width="100%"></asp:TextBox>
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtDate2"
									ErrorMessage="Date is a required field"></asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="txtDate2"
									ErrorMessage="Recording Start Date must be of the form yyyy/mm/dd" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"></asp:RegularExpressionValidator></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label31" runat="server" CssClass="labeltext">Personnel:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtPersonnel1" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="100%"></asp:TextBox>
								<asp:TextBox id="txtPersonnel2" runat="server" Width="100%"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label13" runat="server" CssClass="labeltext">Second Agency:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtSecondAgency1" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="100%"></asp:TextBox>
								<asp:DropDownList id=dlstSecondAgency2 runat="server" DataSource="<%# objdscdAgency %>" DataTextField="Agency" DataValueField="AgencyCd">
								</asp:DropDownList>
								<asp:TextBox id="txtSecondAgencyCd" runat="server" Visible="False"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label45" runat="server" CssClass="labeltext">Second Agency Contact:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtSecondAgencyContact1" runat="server" BackColor="WhiteSmoke" Enabled="False"
									Width="100%"></asp:TextBox>
								<asp:TextBox id="txtSecondAgencyContact2" runat="server" Width="100%"></asp:TextBox></TD>
						</TR>
					</TABLE>
					<BR>
					<asp:Button id="btnModifyActivityDetails" runat="server" Text="Modify" CausesValidation="False" onclick="btnModifyActivityDetails_Click"></asp:Button></FIELDSET>
			</asp:panel><asp:panel id="pnlMethodDetails" runat="server"><BR>
				<FIELDSET class="standardText"><LEGEND>Method Details</LEGEND>
					<TABLE border="0">
						<TR>
							<TD>
								<asp:Label id="Label59" runat="server" CssClass="labeltext">Electrofishing Method:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtElectrofishingMethod1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:DropDownList id=dlstElectrofishingMethod2 runat="server" DataSource="<%# dvcdAquaticActivityMethod %>" DataTextField="AquaticMethod" DataValueField="AquaticMethodCd">
								</asp:DropDownList>
								<asp:TextBox id="txtElectrofishingMethodCd" runat="server" Visible="False"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label14" runat="server" CssClass="labeltext">Site Setup:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtSiteSetup1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:DropDownList id="dlstSiteSetup2" runat="server" Width="100%"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label15" runat="server" CssClass="labeltext">No. Sweeps:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtNoSweeps1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtNoSweeps2"
									ErrorMessage="No. Sweeps is a required field"></asp:RequiredFieldValidator>
								<asp:CompareValidator id="CompareValidator55" runat="server" Display="None" ControlToValidate="txtNoSweeps2"
									ErrorMessage="No. Sweeps must be numeric (integer)" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
								<asp:RangeValidator id="RangeValidator1" runat="server" Display="None" ControlToValidate="txtNoSweeps2"
									ErrorMessage="No. Sweeps must be between 0 and 6" Type="Integer" MaximumValue="6" MinimumValue="0"></asp:RangeValidator>
								<asp:TextBox id="txtNoSweeps2" runat="server" Width="100%"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label10" runat="server" CssClass="labeltext">Gear Used:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtGearUsed1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:DropDownList id="dlstGearUsed2" runat="server" Width="100%"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label18" runat="server" CssClass="labeltext">Voltage:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtVoltage1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:CompareValidator id="CompareValidator1" runat="server" Display="None" ControlToValidate="txtVoltage2"
									ErrorMessage="Voltage must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
								<asp:TextBox id="txtVoltage2" runat="server" Width="100%"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label19" runat="server" CssClass="labeltext">Frequency (Hz):</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtFrequency1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:CompareValidator id="CompareValidator2" runat="server" Display="None" ControlToValidate="txtFrequency2"
									ErrorMessage="Frequency must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
								<asp:TextBox id="txtFrequency2" runat="server" Width="100%"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label20" runat="server" CssClass="labeltext">Duty Cycle (units?):</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtDutyCycle1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:CompareValidator id="CompareValidator3" runat="server" Display="None" ControlToValidate="txtDutyCycle2"
									ErrorMessage="Duty Cycle must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
								<asp:TextBox id="txtDutyCycle2" runat="server" Width="100%"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label21" runat="server" CssClass="labeltext">POW Setting:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtPOWSetting1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:CompareValidator id="CompareValidator4" runat="server" Display="None" ControlToValidate="txtPOWSetting2"
									ErrorMessage="POW Setting must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
								<asp:TextBox id="txtPOWSetting2" runat="server" Width="100%"></asp:TextBox></TD>
						</TR>
					</TABLE>
					<BR>
					<asp:Button id="btnModifyMethodDetails" runat="server" Text="Modify" CausesValidation="False"
						Visible="False" onclick="btnModifyMethodDetails_Click"></asp:Button></FIELDSET>
			</asp:panel><asp:panel id="pnlSiteDetails" Runat="server"><BR>
				<asp:panel id="pnlSiteDetailsView" Runat="server">
					<FIELDSET class="StandardText"><LEGEND>Site Measurements</LEGEND>
						<asp:DataGrid id=dgSiteDetails1 runat="server" CssClass="enclosedgriditem" DataSource="<%# dvDE_ELECTSiteMeasurement %>" AutoGenerateColumns="False" ShowFooter="True">
							<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
								BackColor="LightSteelBlue"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="OandM_Group" SortExpression="OandM_Group" HeaderText="Measurement Category"></asp:BoundColumn>
								<asp:BoundColumn DataField="OandM_Parameter" HeaderText="Parameter"></asp:BoundColumn>
								<asp:BoundColumn DataField="Bank" SortExpression="Bank" HeaderText="Bank"></asp:BoundColumn>
								<asp:BoundColumn DataField="Measurement" HeaderText="Measurement"></asp:BoundColumn>
								<asp:BoundColumn DataField="UnitofMeasureAbv" SortExpression="UnitofMeasureAbv" HeaderText="Unit of&lt;br&gt;Measure"></asp:BoundColumn>
								<asp:BoundColumn DataField="Instrument" HeaderText="Instrument"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid><BR>
						<asp:Button id="btnModifySiteDetails" runat="server" Text="Modify" CausesValidation="False" onclick="btnModifySiteDetails_Click"></asp:Button></FIELDSET>
				</asp:panel>
				<asp:Panel id="pnlSiteDetailsModify" Runat="server" Visible="False">
					<FIELDSET class="StandardText"><LEGEND>Site Measurements List</LEGEND>
						<asp:DataGrid id=dgSiteDetails2 runat="server" CssClass="enclosedGridItem" DataSource="<%# dvDE_ELECTSiteMeasurement %>" AutoGenerateColumns="False" ShowFooter="True" DataKeyField="SiteMeasurementID">
							<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
								BackColor="LightSteelBlue"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="OandM_Group" SortExpression="OandM_Group" HeaderText="Measurement Category"></asp:BoundColumn>
								<asp:BoundColumn DataField="OandM_Parameter" HeaderText="Parameter"></asp:BoundColumn>
								<asp:BoundColumn DataField="Bank" SortExpression="Bank" HeaderText="Bank"></asp:BoundColumn>
								<asp:BoundColumn DataField="Measurement" HeaderText="Measurement"></asp:BoundColumn>
								<asp:BoundColumn DataField="UnitofMeasureAbv" SortExpression="UnitofMeasureAbv" HeaderText="Unit of&lt;br&gt;Measure"></asp:BoundColumn>
								<asp:BoundColumn DataField="Instrument" HeaderText="Instrument"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></FIELDSET>
					<BR>
					<FIELDSET class="StandardText"><LEGEND>Site Measurement Input</LEGEND>
						<TABLE>
							<TR>
								<TD colSpan="2">
									<asp:Label id="lblIndicator" runat="server" CssClass="labelText">* Indicates the form will refresh after you enter information in this field</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label83" runat="server" CssClass="labelText">Measurement Category*:</asp:Label></TD>
								<TD>
									<asp:DropDownList id=dlstGroup2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Category %>" DataTextField="OandM_Group" DataValueField="OandM_Group" AutoPostBack="True" onselectedindexchanged="dlstGroup2_SelectedIndexChanged">
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label71" runat="server" CssClass="labelText">Parameter*:</asp:Label></TD>
								<TD>
									<asp:DropDownList id=dlstValueMeasured2_SiteDetails runat="server" Width="100%" DataSource="<%# dvcdOandM %>" DataTextField="OandM_Parameter" DataValueField="OandMCd" AutoPostBack="True" onselectedindexchanged="dlstValueMeasured2_SiteDetails_SelectedIndexChanged">
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label53" runat="server" CssClass="labelText">Bank:</asp:Label></TD>
								<TD>
									<asp:RadioButtonList id="rblBank" runat="server" CssClass="labelText" RepeatDirection="Horizontal">
										<asp:ListItem Value="" Selected="True">N/A</asp:ListItem>
										<asp:ListItem Value="Left">Left</asp:ListItem>
										<asp:ListItem Value="Right">Right</asp:ListItem>
									</asp:RadioButtonList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label76" runat="server" CssClass="labelText">Measurement:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtMeasurement2_SiteDetails" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator5" runat="server" Display="None" ControlToValidate="txtMeasurement2_SiteDetails"
										ErrorMessage="Measurement must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="txtMeasurement2_SiteDetails"
										ErrorMessage="Measurement is a required field"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label77" runat="server" CssClass="labelText">Unit of Measure:</asp:Label></TD>
								<TD>
									<asp:DropDownList id=dlstUnitofMeasure2_SiteDetails runat="server" Width="100%" DataSource="<%# dvDE_OandM_UnitofMeasure %>" DataTextField="UnitofMeasure" DataValueField="UnitofMeasureCd">
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label72" runat="server" CssClass="labelText">Instrument:</asp:Label></TD>
								<TD>
									<asp:DropDownList id=dlstInstrument2_SiteDetails runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
							</TR>
						</TABLE>
					</FIELDSET>
				</asp:Panel>
				<asp:panel id="pnlSiteDetailsAdd" Runat="server" Visible="False">
					<FIELDSET class="StandardText"><LEGEND>Site Details</LEGEND>
						<TABLE>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label17" Font-Bold="True" runat="server" CssClass="labeltext">Site Measurements</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:Label id="Label60" Font-Bold="True" runat="server" CssClass="labeltext">Instrument</asp:Label></TD>
								<TD>
									<asp:Label id="Label61" Font-Bold="True" runat="server" CssClass="labeltext">Measurement</asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label16" runat="server" CssClass="labeltext">Stream Length (m):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:DropDownList id=dlstStreamLength2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtStreamLength2" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtStreamLength2"
										ErrorMessage="Stream Length is a required field"></asp:RequiredFieldValidator>
									<asp:CompareValidator id="CompareValidator6" runat="server" Display="None" ControlToValidate="txtStreamLength2"
										ErrorMessage="Stream Length must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label32" runat="server" CssClass="labeltext">Wet Width (m):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:DropDownList id=dlstWetWidth2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtWetWidth2" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtWetWidth2"
										ErrorMessage="Wet Width is a required field"></asp:RequiredFieldValidator>
									<asp:CompareValidator id="CompareValidator7" runat="server" Display="None" ControlToValidate="txtWetWidth2"
										ErrorMessage="Wet Width must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label33" runat="server" CssClass="labeltext">Bank Full (Channel) Width (m):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:DropDownList id=dlstBankWidth2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtBankWidth2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator9" runat="server" Display="None" ControlToValidate="txtBankWidth2"
										ErrorMessage="Bank Full (Channel) Width must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label34" runat="server" CssClass="labeltext">Average Depth (cm):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:DropDownList id=dlstAverageDepth2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtAverageDepth2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator8" runat="server" Display="None" ControlToValidate="txtAverageDepth2"
										ErrorMessage="Average Depth must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label56" Font-Bold="True" runat="server" CssClass="labeltext">Stream Type</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:Label id="Label57" Font-Bold="True" runat="server" CssClass="labeltext">Percent</asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label36" runat="server" CssClass="labeltext">Riffle:</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtRiffle2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator10" runat="server" Display="None" ControlToValidate="txtRiffle2"
										ErrorMessage="Riffle must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label38" runat="server" CssClass="labeltext">Run:</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtRun2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator11" runat="server" Display="None" ControlToValidate="txtRun2"
										ErrorMessage="Run must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label40" runat="server" CssClass="labeltext">Pool:</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtPool2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator12" runat="server" Display="None" ControlToValidate="txtPool2"
										ErrorMessage="Pool must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label39" runat="server" CssClass="labeltext">Rapid:</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtRapid2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator13" runat="server" Display="None" ControlToValidate="txtRapid2"
										ErrorMessage="Rapid must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label41" runat="server" CssClass="labeltext">Other:</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtOther2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator14" runat="server" Display="None" ControlToValidate="txtOther2"
										ErrorMessage="Other must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2"></TD>
								<TD style="WIDTH: 180px">
									<asp:Label id="Label42" runat="server" CssClass="labeltext">Total = 100%</asp:Label></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label35" Font-Bold="True" runat="server" CssClass="labeltext">Substrate Type</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:Label id="Label58" Font-Bold="True" runat="server" CssClass="labeltext">Percent</asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label37" runat="server" CssClass="labeltext">Bedrock (ledge):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtBedrock2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator15" runat="server" Display="None" ControlToValidate="txtBedrock2"
										ErrorMessage="Bedrock (ledge) must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label43" runat="server" CssClass="labeltext">Boulder (>460mm):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtBoulder2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator16" runat="server" Display="None" ControlToValidate="txtBoulder2"
										ErrorMessage="Boulder must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label46" runat="server" CssClass="labeltext">Rock (180-460 mm):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtRock2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator17" runat="server" Display="None" ControlToValidate="txtRock2"
										ErrorMessage="Rock must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label47" runat="server" CssClass="labeltext">Rubble (54-179mm):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtRubble2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator18" runat="server" Display="None" ControlToValidate="txtRubble2"
										ErrorMessage="Rubble must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label48" runat="server" CssClass="labeltext">Gravel (2.6-53mm):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtGravel2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator19" runat="server" Display="None" ControlToValidate="txtGravel2"
										ErrorMessage="Gravel must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label49" runat="server" CssClass="labeltext">Sand (0.06-2.6mm):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtSand2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator20" runat="server" Display="None" ControlToValidate="txtSand2"
										ErrorMessage="Sand must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label50" runat="server" CssClass="labeltext">Fines (0.0005-0.005mm):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtFines2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator21" runat="server" Display="None" ControlToValidate="txtFines2"
										ErrorMessage="Fines must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2"></TD>
								<TD style="WIDTH: 180px">
									<asp:Label id="Label62" runat="server" CssClass="labeltext">Total = 100%</asp:Label></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2"></TD>
								<TD style="WIDTH: 180px">
									<asp:Label id="Label51" Font-Bold="True" runat="server" CssClass="labeltext">Left Bank</asp:Label></TD>
								<TD>
									<asp:Label id="Label63" Font-Bold="True" runat="server" CssClass="labeltext">Right Bank</asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label54" runat="server" CssClass="labeltext">Overhanging Vegetation (%):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtLeftBankOverhangingVegetation2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator31" runat="server" Display="None" ControlToValidate="txtLeftBankOverhangingVegetation2"
										ErrorMessage="Overhanging Vegetation Left Bank must be numeric (double)" Operator="DataTypeCheck"
										Type="Double"></asp:CompareValidator></TD>
								<TD>
									<asp:TextBox id="txtRightBankOverhangingVegetation2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator32" runat="server" Display="None" ControlToValidate="txtRightBankOverhangingVegetation2"
										ErrorMessage="Overhanging Vegetation Right Bank must be numeric (double)" Operator="DataTypeCheck"
										Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label55" runat="server" CssClass="labeltext">Undercut Bank (%):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtLeftBankUndercutBank2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator33" runat="server" Display="None" ControlToValidate="txtLeftBankUndercutBank2"
										ErrorMessage="Undercut Bank Left Bank must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
								<TD>
									<asp:TextBox id="txtRightBankUndercutBank2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator34" runat="server" Display="None" ControlToValidate="txtRightBankUndercutBank2"
										ErrorMessage="Undercut Bank Right Bank must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label52" runat="server" CssClass="labeltext">Large Woody Debris (m):</asp:Label></TD>
								<TD style="WIDTH: 180px">
									<asp:TextBox id="txtLargeWoodyDebris2" runat="server" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator35" runat="server" Display="None" ControlToValidate="txtLargeWoodyDebris2"
										ErrorMessage="Large Woody Debris must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
						</TABLE>
					</FIELDSET>
				</asp:panel>
			</asp:panel><asp:panel id="pnlPhotos" Runat="server"><BR>
				<asp:panel id="pnlPhotosView" Runat="server">
					<FIELDSET class="standardText"><LEGEND>Site Photos</LEGEND>
						<asp:DataGrid id=dgPhotos1 runat="server" CssClass="enclosedGridItem" DataSource="<%# dvtblPhotos %>" AutoGenerateColumns="False" ShowFooter="True" DataKeyField="PhotoID">
							<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
								BackColor="LightSteelBlue"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Path" SortExpression="Path" HeaderText="Path"></asp:BoundColumn>
								<asp:BoundColumn DataField="FileName" SortExpression="FileName" HeaderText="File Name"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid><BR>
						<asp:Button id="btnModifyPhotos" runat="server" Text="Modify" CausesValidation="False" onclick="btnModifyPhotos_Click"></asp:Button></FIELDSET>
				</asp:panel>
				<asp:panel id="pnlPhotosAddModify" Runat="server" Visible="False">
					<FIELDSET class="standardText"><LEGEND>Photos List</LEGEND>
						<asp:DataGrid id=dgPhotos2 runat="server" CssClass="enclosedGridItem" DataSource="<%# dvtblPhotos %>" AutoGenerateColumns="False" ShowFooter="True" DataKeyField="PhotoID">
							<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
								BackColor="LightSteelBlue"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="Path" SortExpression="Path" HeaderText="Path"></asp:BoundColumn>
								<asp:BoundColumn DataField="FileName" SortExpression="FileName" HeaderText="File Name"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></FIELDSET>
					<BR>
					<FIELDSET class="standardText"><LEGEND>Photo Input</LEGEND>
						<TABLE>
							<TR>
								<TD>
									<asp:Label id="Label64" runat="server" CssClass="labeltext">Path:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtPath2" runat="server"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label65" runat="server" CssClass="labeltext">File Name:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtFileName2" runat="server"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</FIELDSET>
				</asp:panel>
			</asp:panel><asp:panel id="pnlWaterMeasurements" runat="server"><BR>
				<asp:panel id="pnlWaterMeasurementsView" runat="server">
					<FIELDSET class="standardText"><LEGEND>Water Measurements</LEGEND>
						<asp:DataGrid id=dgWaterMeasurements1 runat="server" CssClass="enclosedGridItem" DataSource="<%# dvDE_ELECTWaterMeasurement %>" AutoGenerateColumns="False" ShowFooter="True">
							<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
								BackColor="LightSteelBlue"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="OandM_Parameter" SortExpression="OandM_Parameter" HeaderText="Parameter"></asp:BoundColumn>
								<asp:BoundColumn DataField="Measurement" SortExpression="Measurement" HeaderText="Measurement"></asp:BoundColumn>
								<asp:BoundColumn DataField="UnitofMeasureAbv" SortExpression="UnitofMeasureAbv" HeaderText="Unit of&lt;br&gt;Measure"></asp:BoundColumn>
								<asp:BoundColumn DataField="Instrument" SortExpression="Instrument" HeaderText="Instrument"></asp:BoundColumn>
								<asp:BoundColumn DataField="TimeofDay" SortExpression="TimeofDay" HeaderText="Time of Day"></asp:BoundColumn>
								<asp:BoundColumn DataField="WaterDepth_m" SortExpression="WaterDepth_m" HeaderText="Sample Depth"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid><BR>
						<asp:Button id="btnModifyWaterMeasurements" runat="server" Text="Modify" CausesValidation="False"
							Visible="False" onclick="btnModifyWaterMeasurements_Click"></asp:Button></FIELDSET>
				</asp:panel>
				<asp:Panel id="pnlWaterMeasurementsModify" Runat="server" Visible="False">
					<FIELDSET class="standardText"><LEGEND>Water Measurements List</LEGEND>
						<asp:DataGrid id=dgWaterMeasurements2 runat="server" CssClass="enclosedGridItem" DataSource="<%# dvDE_ELECTWaterMeasurement %>" AutoGenerateColumns="False" ShowFooter="True" DataKeyField="WaterMeasurementID">
							<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
								BackColor="LightSteelBlue"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="OandM_Parameter" SortExpression="OandM_Parameter" HeaderText="Parameter"></asp:BoundColumn>
								<asp:BoundColumn DataField="Measurement" SortExpression="Measurement" HeaderText="Measurement"></asp:BoundColumn>
								<asp:BoundColumn DataField="UnitofMeasureAbv" SortExpression="UnitofMeasureAbv" HeaderText="Unit of&lt;br&gt;Measure"></asp:BoundColumn>
								<asp:BoundColumn DataField="Instrument" SortExpression="Instrument" HeaderText="Instrument"></asp:BoundColumn>
								<asp:BoundColumn DataField="TimeofDay" SortExpression="TimeofDay" HeaderText="Time of Day"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></FIELDSET>
					<BR>
					<FIELDSET class="standardText"><LEGEND>Water Measurement Input</LEGEND>
						<TABLE>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label87" runat="server" CssClass="labelText">* Indicates the form will refresh after you enter information in this field</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label78" runat="server" CssClass="labelText">Parameter*:</asp:Label></TD>
								<TD>
									<asp:DropDownList id=dlstValueMeasured2_WaterMeasurements runat="server" DataSource="<%# dvcdOandM %>" DataTextField="OandM_Parameter" DataValueField="OandMCd" AutoPostBack="True" onselectedindexchanged="dlstValueMeasured2_WaterMeasurements_SelectedIndexChanged">
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label80" runat="server" CssClass="labelText">Measurement:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtMeasurement2_WaterMeasurements" runat="server" Width="100%"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" Display="None" ControlToValidate="txtMeasurement2_WaterMeasurements"
										ErrorMessage="Measurement is a required field"></asp:RequiredFieldValidator>
									<asp:CompareValidator id="CompareValidator22" runat="server" Display="None" ControlToValidate="txtMeasurement2_WaterMeasurements"
										ErrorMessage="Measurement must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label81" runat="server" CssClass="labelText">Unit of Measure:</asp:Label></TD>
								<TD>
									<asp:DropDownList id=dlstUnitofMeasure2_WaterMeasurements runat="server" Width="100%" DataSource="<%# dvDE_OandM_UnitofMeasure %>" DataTextField="UnitofMeasure" DataValueField="UnitofMeasureCd">
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label79" runat="server" CssClass="labelText">Instrument:</asp:Label></TD>
								<TD>
									<asp:DropDownList id=dlstInstrument2_WaterMeasurements runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label82" runat="server" CssClass="labelText">Time of Day (24:00):</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtTimeofDay2" runat="server" Width="100%"></asp:TextBox>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" Display="None" ControlToValidate="txtTimeofDay2"
										ErrorMessage="Time of Day must be ##:##" ValidationExpression="\d{2}[:]\d{2}"></asp:regularexpressionvalidator></TD>
							</TR>
						</TABLE>
					</FIELDSET>
				</asp:Panel>
				<asp:Panel id="pnlWaterMeasurementsAdd" Runat="server" Visible="False">
					<FIELDSET class="standardText"><LEGEND>Water Measurements</LEGEND>
						<TABLE>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label66" Font-Bold="True" runat="server" CssClass="labeltext">Parameter</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:Label id="Label67" Font-Bold="True" runat="server" CssClass="labeltext">Instrument</asp:Label></TD>
								<TD>
									<asp:Label id="Label68" Font-Bold="True" runat="server" CssClass="labeltext">Measurement</asp:Label></TD>
								<TD>
									<asp:Label id="Label28" Font-Bold="True" runat="server" CssClass="labeltext">Time of Day<br>(24:00)</asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label26" runat="server" CssClass="labeltext">Start Water Temperature (°C):</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstStartWaterTemperatureInstrument2 runat="server" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtStartWaterTemperatureMeasurement2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator23" runat="server" Display="None" ControlToValidate="txtStartWaterTemperatureMeasurement2"
										ErrorMessage="Start Water Temperature Measurement must be numeric (double)" Operator="DataTypeCheck"
										Type="Double"></asp:CompareValidator></TD>
								<TD>
									<asp:TextBox id="txtStartWaterTemperatureTimeofDay2" runat="server"></asp:TextBox>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" Display="None" ControlToValidate="txtStartWaterTemperatureTimeofDay2"
										ErrorMessage="Start Water Temperature Time of Day must be ##:##" ValidationExpression="\d{2}[:]\d{2}"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label27" runat="server" CssClass="labeltext">Start Air Temperature (°C):</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstStartAirTemperatureInstrument2 runat="server" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtStartAirTemperatureMeasurement2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator24" runat="server" Display="None" ControlToValidate="txtStartAirTemperatureMeasurement2"
										ErrorMessage="Start Air Temperature Measurement must be numeric (double)" Operator="DataTypeCheck"
										Type="Double"></asp:CompareValidator></TD>
								<TD>
									<asp:TextBox id="txtStartAirTemperatureTimeofDay2" runat="server"></asp:TextBox>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" Display="None" ControlToValidate="txtStartAirTemperatureTimeofDay2"
										ErrorMessage="Start Air Temperature Time of Day must be ##:##" ValidationExpression="\d{2}[:]\d{2}"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label29" runat="server" CssClass="labeltext">End Water Temperature (°C):</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstEndWaterTemperatureInstrument2 runat="server" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtEndWaterTemperatureMeasurement2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator25" runat="server" Display="None" ControlToValidate="txtEndWaterTemperatureMeasurement2"
										ErrorMessage="End Water Temperature Measurement must be numeric (double)" Operator="DataTypeCheck"
										Type="Double"></asp:CompareValidator></TD>
								<TD>
									<asp:TextBox id="txtEndWaterTemperatureTimeofDay2" runat="server"></asp:TextBox>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" Display="None" ControlToValidate="txtEndWaterTemperatureTimeofDay2"
										ErrorMessage="End Water Temperature Time of Day must be ##:##" ValidationExpression="\d{2}[:]\d{2}"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label30" runat="server" CssClass="labeltext">End Air Temperature (°C):</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstEndAirTemperatureInstrument2 runat="server" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtEndAirTemperatureMeasurement2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator26" runat="server" Display="None" ControlToValidate="txtEndAirTemperatureMeasurement2"
										ErrorMessage="End Air Temperature Measurement must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
								<TD>
									<asp:TextBox id="txtEndAirTemperatureTimeofDay2" runat="server"></asp:TextBox>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" Display="None" ControlToValidate="txtEndAirTemperatureTimeofDay2"
										ErrorMessage="End Air Temperature Time of Day must be ##:##" ValidationExpression="\d{2}[:]\d{2}"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label23" runat="server" CssClass="labelText">Water Velocity (m/sec):</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstWaterVelocityInstrument2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtWaterVelocityMeasurement2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator27" runat="server" Display="None" ControlToValidate="txtWaterVelocityMeasurement2"
										ErrorMessage="Water Velocity Measurement must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label24" runat="server" CssClass="labelText">Water Flow (m<sup>3</sup>/sec):</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstWaterFlowInstrument2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtWaterFlowMeasurement2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator28" runat="server" Display="None" ControlToValidate="txtWaterFlowMeasurement2"
										ErrorMessage="Water Flow Measurement must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label11" runat="server" CssClass="labelText">Ambient Water Conductivity (µS/cm):</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstAmbientWaterConductivityInstrument2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtAmbientWaterConductivityMeasurement2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator29" runat="server" Display="None" ControlToValidate="txtAmbientWaterConductivityMeasurement2"
										ErrorMessage="Ambient Water Measurement must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label22" runat="server" CssClass="labelText">Specific Water Conductivity (µS/cm):</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstSpecificWaterConductivityInstrument2 runat="server" Width="100%" DataSource="<%# dvDE_OandM_Instrument %>" DataTextField="Instrument" DataValueField="InstrumentCd">
									</asp:DropDownList></TD>
								<TD>
									<asp:TextBox id="txtSpecificWaterConductivityMeasurement2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator30" runat="server" Display="None" ControlToValidate="txtSpecificWaterConductivityMeasurement2"
										ErrorMessage="Specific Water Conductivity Measurement must be numeric (double)" Operator="DataTypeCheck"
										Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="Label25" runat="server" CssClass="labelText">Water Clarity:</asp:Label></TD>
								<TD style="WIDTH: 179px">
									<asp:DropDownList id=dlstWaterClarityMeasurement2 runat="server" Width="100%" DataSource="<%# dvcdOandMValues %>" DataTextField="Value" DataValueField="OandMValuesCd">
									</asp:DropDownList></TD>
							</TR>
						</TABLE>
					</FIELDSET>
				</asp:Panel>
			</asp:panel><asp:panel id="pnlObservations" Runat="server"><BR>
				<FIELDSET class="standardText"><LEGEND>Water Observations</LEGEND>
					<TABLE>
						<TR>
							<TD>
								<asp:Label id="Label69" runat="server" CssClass="labelText">Water Clarity:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtWaterClarity1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:TextBox>
								<asp:DropDownList id=dlstWaterClarity2 runat="server" DataSource="<%# dvcdOandMValues %>" DataTextField="Value" DataValueField="OandMValuesCd">
								</asp:DropDownList>
								<asp:TextBox id="txtWaterClarityCd" runat="server" Visible="False"></asp:TextBox></TD>
						</TR>
					</TABLE>
					<asp:Button id="btnModifySiteObservations" runat="server" Text="Modify" CausesValidation="False"
						Visible="False" onclick="btnModifySiteObservations_Click"></asp:Button></FIELDSET>
			</asp:panel><asp:panel id="pnlSweepData" Runat="server"><BR>
				<asp:panel id="pnlSweepDataView" runat="server">
					<FIELDSET class="standardText"><LEGEND>Sweep Data</LEGEND>
						<asp:DataGrid id=dgSweepData1 runat="server" CssClass="enclosedGridItem" DataSource="<%# dvDE_ELECTSweepData %>" AutoGenerateColumns="False" ShowFooter="True">
							<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
								BackColor="LightSteelBlue"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="FishSpecies" SortExpression="FishSpecies" HeaderText="Species"></asp:BoundColumn>
								<asp:BoundColumn DataField="FishAgeClass" SortExpression="FishAgeClass" HeaderText="Age Class"></asp:BoundColumn>
								<asp:BoundColumn DataField="AveWeight_gm" SortExpression="AveWeight_gm" HeaderText="Average Weight (gm)"></asp:BoundColumn>
								<asp:BoundColumn DataField="AveForkLength_cm" SortExpression="AveForkLength_cm" HeaderText="Average Fork Length (cm)"></asp:BoundColumn>
								<asp:BoundColumn DataField="AveTotalLength_cm" SortExpression="AveTotalLength_cm" HeaderText="Average Total Length (cm)"></asp:BoundColumn>
								<asp:BoundColumn DataField="PercentClipped" SortExpression="PercentClipped" HeaderText="Percent Clipped"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep1NoFish" SortExpression="Sweep1NoFish" HeaderText="Sweep 1 No"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep1Time_s" SortExpression="Sweep1Time_s" HeaderText="Sweep 1 Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep2NoFish" SortExpression="Sweep2NoFish" HeaderText="Sweep 2 No"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep2Time_s" SortExpression="Sweep2Time_s" HeaderText="Sweep 2 Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep3NoFish" SortExpression="Sweep3NoFish" HeaderText="Sweep 3 No"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep3Time_s" SortExpression="Sweep3Time_s" HeaderText="Sweep 3 Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep4NoFish" SortExpression="Sweep4NoFish" HeaderText="Sweep 4 No"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep4Time_s" SortExpression="Sweep4Time_s" HeaderText="Sweep 4 Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep5NoFish" SortExpression="Sweep5NoFish" HeaderText="Sweep 5 No"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep5Time_s" SortExpression="Sweep5Time_s" HeaderText="Sweep 5 Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep6NoFish" SortExpression="Sweep6NoFish" HeaderText="Sweep 6 No"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sweep6Time_s" SortExpression="Sweep6Time_s" HeaderText="Sweep 6 Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="TotalNoFish" SortExpression="TotalNoFish" HeaderText="Total No"></asp:BoundColumn>
								<asp:BoundColumn DataField="Density" SortExpression="Density" HeaderText="Density" DataFormatString="{0:#####.##}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Biomass" SortExpression="Biomass" HeaderText="Biomass" DataFormatString="{0:G2}"></asp:BoundColumn>
								<asp:BoundColumn DataField="PHS" SortExpression="PHS" HeaderText="PHS" DataFormatString="{0:G2}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Formula" SortExpression="Formula" HeaderText="Formula"></asp:BoundColumn>
								<asp:BoundColumn DataField="AutoCalculatedInd" SortExpression="AutoCalculatedInd" HeaderText="Auto Calculated"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid><BR>
						<asp:Button id="btnModifySweepData" runat="server" Text="Modify" CausesValidation="False" Visible="False" onclick="btnModifySweepData_Click"></asp:Button></FIELDSET>
				</asp:panel>
				<asp:panel id="pnlSweepDataAddModify" Runat="server" Visible="False">
					<asp:panel id="pnlSweepList" Runat="server">
						<FIELDSET class="standardText"><LEGEND>Sweep Data List</LEGEND>
							<asp:DataGrid id=dgSweepData2 runat="server" CssClass="enclosedGridItem" DataSource="<%# dvDE_ELECTSweepData %>" AutoGenerateColumns="False" ShowFooter="True" DataKeyField="EFDataID" onselectedindexchanged="dgSweepData2_SelectedIndexChanged">
								<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
									BackColor="LightSteelBlue"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="Modify" CommandName="Select"></asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
									<asp:BoundColumn DataField="FishSpecies" SortExpression="FishSpecies" HeaderText="Species"></asp:BoundColumn>
									<asp:TemplateColumn Visible="False" HeaderText="FishSpeciesCd">
										<ItemTemplate>
											<asp:Label id = "lblFishSpeciesCd" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FishSpeciesCd") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Age Class">
										<ItemTemplate>
											<asp:Label ID="lblFishAgeClass" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FishAgeClass") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Average Weight (gm)">
										<ItemTemplate>
											<asp:Label id = "lblAverageWeight" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AveWeight_gm") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Average Fork Length (cm)">
										<ItemTemplate>
											<asp:Label ID="lblAverageForkLength" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AveForkLength_cm") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Average Total Length (cm)">
										<ItemTemplate>
											<asp:Label ID="lblAverageTotalLength" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AveTotalLength_cm") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Percent Clipped">
										<ItemTemplate>
											<asp:Label id="lblPercentClipped" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PercentClipped") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S1 No">
										<ItemTemplate>
											<asp:Label ID="lblSweep1Number" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep1NoFish") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S1 Time">
										<ItemTemplate>
											<asp:Label ID="lblSweep1Time" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep1Time_s") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S2 No">
										<ItemTemplate>
											<asp:Label ID="lblSweep2Number" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep2NoFish") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S2 Time">
										<ItemTemplate>
											<asp:Label ID="lblSweep2Time" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep2Time_s") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S3 No">
										<ItemTemplate>
											<asp:Label ID="lblSweep3Number" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep3NoFish") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S3 Time">
										<ItemTemplate>
											<asp:Label ID="lblSweep3Time" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep3Time_s") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S4 No">
										<ItemTemplate>
											<asp:Label ID="lblSweep4Number" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep4NoFish") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S4 Time">
										<ItemTemplate>
											<asp:Label ID="lblSweep4Time" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep4Time_s") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S5 No">
										<ItemTemplate>
											<asp:Label ID="lblSweep5Number" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep5NoFish") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S5 Time">
										<ItemTemplate>
											<asp:Label ID="lblSweep5Time" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep5Time_s") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S6 No">
										<ItemTemplate>
											<asp:Label ID="lblSweep6Number" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep6NoFish") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="S6 Time">
										<ItemTemplate>
											<asp:Label ID="lblSweep6Time" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sweep6Time_s") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="TotalNoFish" SortExpression="TotalNoFish" HeaderText="Total No"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Density">
										<ItemTemplate>
											<asp:Label ID="lblDensity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Density", "{0:N2}") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Biomass">
										<ItemTemplate>
											<asp:Label ID="lblBiomass" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Biomass", "{0:N2}") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="PHS">
										<ItemTemplate>
											<asp:Label ID="lblPHS" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PHS", "{0:N2}") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Formula">
										<ItemTemplate>
											<asp:Label ID="lblFormula" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Formula") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Formula") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Auto Calculated">
										<ItemTemplate>
											<asp:Label ID="lblAutoCalculated" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AutoCalculatedInd") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn Visible="False" HeaderText="EFDataID">
										<ItemTemplate>
											<asp:Label id = "EFDataID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EFDataID") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid></FIELDSET>
						<BR>
					</asp:panel>
					<FIELDSET class="standardText"><LEGEND>Sweep Data &amp; Population Estimate Input</LEGEND>
						<TABLE border="0">
							<TR>
								<TD>
									<asp:Label id="lblSpecies" runat="server" CssClass="labelText">Species:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtSpecies1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:DropDownList id=dlstSpecies2 runat="server" Width="100%" DataSource="<%# dvcdFishSpecies %>" DataTextField="FishSpecies" DataValueField="FishSpeciesCd">
									</asp:DropDownList></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblAgeClass" runat="server" CssClass="labelText">Age Class:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtAgeClass1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:DropDownList id=dlstAgeClass2 runat="server" Width="100%" DataSource="<%# dvcdFishAgeClass %>" DataTextField="FishAgeClass" DataValueField="FishAgeClass">
									</asp:DropDownList></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblAveWeight" runat="server" CssClass="labelText">Average Weight (gm):</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtAverageWeight1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:TextBox id="txtAverageWeight2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:CompareValidator id="CompareValidator36" runat="server" Display="None" ControlToValidate="txtAverageWeight2"
										ErrorMessage="Average Weight must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblAveForkLength" runat="server" CssClass="labelText">Average Fork Length (cm):</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtAverageForkLength1" runat="server" BackColor="WhiteSmoke" Enabled="False"
										Visible="False"></asp:TextBox>
									<asp:TextBox id="txtAverageForkLength2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:CompareValidator id="CompareValidator37" runat="server" Display="None" ControlToValidate="txtAverageForkLength2"
										ErrorMessage="Average Fork Length must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblAveTotalLength" runat="server" CssClass="labelText">Average Total Length (cm):</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtAverageTotalLength1" runat="server" BackColor="WhiteSmoke" Enabled="False"
										Visible="False"></asp:TextBox>
									<asp:TextBox id="txtAverageTotalLength2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:CompareValidator id="CompareValidator38" runat="server" Display="None" ControlToValidate="txtAverageTotalLength2"
										ErrorMessage="Average Total Length must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblPClipped" runat="server" CssClass="labelText">Percent Clipped:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtPercentClipped1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:TextBox id="txtPercentClipped2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:CompareValidator id="CompareValidator39" runat="server" Display="None" ControlToValidate="txtPercentClipped2"
										ErrorMessage="Percent Clipped must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<asp:Label id="lblNoFish" Font-Bold="True" runat="server" CssClass="labelText">Number of Fish</asp:Label></TD>
								<TD>
									<asp:Label id="lblTime" Font-Bold="True" runat="server" CssClass="labelText">Time (s)</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblSweep1" runat="server" CssClass="labelText">Sweep 1:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtSweep1No1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator40" runat="server" Display="None" ControlToValidate="txtSweep1No2"
										ErrorMessage="Sweep 1 Number of Fish must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" Display="None" ControlToValidate="txtSweep1No2"
										ErrorMessage="Sweep 1 Number of Fish is a required field"></asp:RequiredFieldValidator>
									<asp:TextBox id="txtSweep1No2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:TextBox id="txtSweep1Time1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:TextBox id="txtSweep1Time2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator41" runat="server" Display="None" ControlToValidate="txtSweep1Time2"
										ErrorMessage="Sweep 1 Time  must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblSweep2" runat="server" CssClass="labelText">Sweep 2:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtSweep2No1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator42" runat="server" Display="None" ControlToValidate="txtSweep2No2"
										ErrorMessage="Sweep 2 Number of Fish must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:TextBox id="txtSweep2No2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:TextBox id="txtSweep2Time1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:TextBox id="txtSweep2Time2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator43" runat="server" Display="None" ControlToValidate="txtSweep2Time2"
										ErrorMessage="Sweep 2 Time  must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblSweep3" runat="server" CssClass="labelText">Sweep 3:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtSweep3No1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator44" runat="server" Display="None" ControlToValidate="txtSweep3No2"
										ErrorMessage="Sweep 3 Number of Fish must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:TextBox id="txtSweep3No2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:TextBox id="txtSweep3Time1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:TextBox id="txtSweep3Time2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator45" runat="server" Display="None" ControlToValidate="txtSweep3Time2"
										ErrorMessage="Sweep 3 Time  must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblSweep4" runat="server" CssClass="labelText">Sweep 4:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtSweep4No1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator46" runat="server" Display="None" ControlToValidate="txtSweep4No2"
										ErrorMessage="Sweep 4 Number of Fish must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:TextBox id="txtSweep4No2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:TextBox id="txtSweep4Time1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:TextBox id="txtSweep4Time2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator47" runat="server" Display="None" ControlToValidate="txtSweep4Time2"
										ErrorMessage="Sweep 4 Time  must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblSweep5" runat="server" CssClass="labelText">Sweep 5:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtSweep5No1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator48" runat="server" Display="None" ControlToValidate="txtSweep5No2"
										ErrorMessage="Sweep 5 Number of Fish must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:TextBox id="txtSweep5No2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:TextBox id="txtSweep5Time1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:TextBox id="txtSweep5Time2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator49" runat="server" Display="None" ControlToValidate="txtSweep5Time2"
										ErrorMessage="Sweep 5 Time  must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblSweep6" runat="server" CssClass="labelText">Sweep 6:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtSweep6No1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator50" runat="server" Display="None" ControlToValidate="txtSweep6No2"
										ErrorMessage="Sweep 6 Number of Fish must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:TextBox id="txtSweep6No2" runat="server" Width="100%"></asp:TextBox></TD>
								<TD>
									<asp:TextBox id="txtSweep6Time1" runat="server" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:TextBox>
									<asp:TextBox id="txtSweep6Time2" runat="server"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator51" runat="server" Display="None" ControlToValidate="txtSweep6Time2"
										ErrorMessage="Sweep 6 Time  must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label91" Font-Bold="True" runat="server" CssClass="labelText">Population Estimates</asp:Label></TD>
								<TD>
									<asp:Button id="btnCalculatePopEstimates" runat="server" Text="Calculate Zippin Estimates" CausesValidation="True" onclick="btnCalculatePopEstimates_Click"></asp:Button>
								<TD>
									<asp:Button id="btnEnterEstimates" runat="server" Text="Enter Estimates" CausesValidation="False" onclick="btnEnterEstimates_Click"></asp:Button></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label92" runat="server" CssClass="labelText">Formula:</asp:Label></TD>
								<TD>
									<asp:RadioButtonList id="rblFormula" runat="server" CssClass="labelText" RepeatDirection="Horizontal">
										<asp:ListItem Value="Zippin" Selected="True">Zippin</asp:ListItem>
										<asp:ListItem Value="Delury">Delury</asp:ListItem>
									</asp:RadioButtonList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label88" runat="server" CssClass="labelText">Density:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtDensity1" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator52" runat="server" Display="None" ControlToValidate="txtDensity2"
										ErrorMessage="Density must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:TextBox id="txtDensity2" runat="server" Width="100%" Visible="False"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label89" runat="server" CssClass="labelText">Biomass:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtBiomass1" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator53" runat="server" Display="None" ControlToValidate="txtBiomass2"
										ErrorMessage="Biomass must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:TextBox id="txtBiomass2" runat="server" Width="100%" Visible="False"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label90" runat="server" CssClass="labelText">PHS:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtPHS1" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="100%"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator54" runat="server" Display="None" ControlToValidate="txtPHS2"
										ErrorMessage="PHS must be numeric (double)" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
									<asp:TextBox id="txtPHS2" runat="server" Width="100%" Visible="False"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</FIELDSET>
				</asp:panel>
			</asp:panel><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="labelText" ShowMessageBox="True"></asp:validationsummary><br>
			<asp:button id="btnAdd" runat="server" CssClass="buttonText" Text="Add" Visible="False" onclick="btnAdd_Click"></asp:button><asp:button id="btnNext" runat="server" CssClass="buttonText" Text="Next" Visible="False" onclick="btnNext_Click"></asp:button><asp:button id="btnDone" runat="server" CssClass="buttonText" Text="Done" CausesValidation="False"
				Visible="False" onclick="btnDone_Click"></asp:button><asp:button id="btnSave" runat="server" CssClass="buttonText" Text="Save" Visible="False" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" runat="server" CssClass="buttonText" Text="Cancel" CausesValidation="False"
				Visible="False" onclick="btnCancel_Click"></asp:button><asp:button id="btnDelete" runat="server" CssClass="buttonText" Text="Delete" CausesValidation="False"
				Visible="False" onclick="btnDelete_Click"></asp:button><asp:button id="btnReturn" runat="server" CssClass="buttonText" Text="Return to Electrofishing List"
				CausesValidation="False" onclick="btnReturn_Click"></asp:button></form>
	</body>
</HTML>
