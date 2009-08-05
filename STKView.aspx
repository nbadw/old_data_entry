<%@ Page language="c#" Inherits="NBADWDataEntryApplication.STKView" CodeFile="STKView.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>STKView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>FISH STOCKINGS</h1>
		<h2><asp:label id="lblh2" runat="server" Font-Names="Times New Roman" Font-Bold="True">VIEW</asp:label></h2>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlAddInstructions" runat="server" Visible="False">
				<FIELDSET class="standardtext"><LEGEND>Instructions</LEGEND>
					<UL>
						<LI>
							Press the <B>Save</B> button to save the record or press <B>Cancel </B>to 
							return to the Site List.
						</LI>
					</UL>
				</FIELDSET>
				<BR>
			</asp:panel><asp:panel id="pnlEditInstructions" runat="server" Visible="False">
				<FIELDSET class="standardtext"><LEGEND>Instructions</LEGEND>
					<UL>
						<LI>
							If the stocking has been assigned to the wrong site, you may change the site by 
							clicking <B>Change Site for Current Stocking</B>. You will be presented 
						with a list of stocking sites set up by your organization.
						<LI>
						You may also make other changes.
						<LI>
							When done, click <B>Save</B> to save edits or click <B>Cancel</B> to exit 
							without saving.
						</LI>
					</UL>
				</FIELDSET>
				<BR>
			</asp:panel>
			<fieldset class="standardText"><legend>Site Info</legend>
				<table width="100%" border="0">
					<tr>
						<td vAlign="top"><asp:label id="Label16" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label><br>
							<asp:textbox id="txtdwsiteid" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><br>
							<asp:button id="btnChangeSite" tabIndex="2" runat="server" Visible="False" CssClass="buttonText"
								Text="Change Site for Current Stocking" CausesValidation="False" onclick="btnChangeSite_Click"></asp:button></td>
						<td vAlign="top"><asp:label id="Label17" runat="server" CssClass="labelText">Site Name:</asp:label><br>
							<asp:textbox id="txtsitename" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"></td>
						<td vAlign="top"><asp:label id="Label18" runat="server" CssClass="labelText">Site Description:</asp:label><br>
							<asp:textbox id="txtsitedescription" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label19" runat="server" CssClass="labelText">Agency Code:</asp:label><br>
							<asp:textbox id="txtagencycd" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
						<td vAlign="top"><asp:label id="Label20" runat="server" CssClass="labelText">Agency Site ID:</asp:label><br>
							<asp:textbox id="txtgroupsiteid" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
					</tr>
					<TR>
						<TD vAlign="top"><asp:label id="Label21" runat="server" CssClass="labelText">Water Body ID:</asp:label><br>
							<asp:textbox id="txtwaterbodyid" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></TD>
						<td vAlign="top"><asp:label id="Label22" runat="server" CssClass="labelText">Water Body Name:</asp:label><br>
							<asp:textbox id="txtwaterbodyname" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><br>
						</td>
					</TR>
					<tr>
						<td vAlign="top"><asp:label id="Label23" runat="server" CssClass="labelText">Watershed Code:</asp:label><br>
							<asp:textbox id="txtwatershedcode" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
						<TD vAlign="top"><asp:label id="Label24" runat="server" CssClass="labelText">Watershed:</asp:label><br>
							<asp:textbox id="txtwatershed" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><br>
						</TD>
					</tr>
				</table>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Stocking Info</legend>
				<table border="0">
					<TBODY>
						<tr>
							<td colSpan="2"><asp:label id="lblIndicator" runat="server" Visible="False" CssClass="labelText">* Indicates the form will refresh after you enter information in this field</asp:label></td>
						</tr>
						<tr>
							<td><asp:label id="Label1" runat="server" CssClass="labelText">Date (yyyy/mm/dd):</asp:label></td>
							<td><asp:textbox id="txtDate1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtDate2" runat="server" Visible="False"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Date is a required field"
									ControlToValidate="txtDate2" Display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ErrorMessage="Date must be of the form yyyy/mm/dd"
									ControlToValidate="txtDate2" Display="None" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"></asp:regularexpressionvalidator></td>
						</tr>
						<tr>
							<td><asp:label id="Label2" runat="server" CssClass="labelText">Satellite Reared:</asp:label></td>
							<td><asp:checkbox id="chkSatelliteReared1" runat="server" Enabled="False"></asp:checkbox><asp:checkbox id="chkSatelliteReared2" runat="server" Visible="False"></asp:checkbox></td>
						</tr>
						<tr>
							<td><asp:label id="Label3" runat="server" CssClass="labelText">Hatchery Source:</asp:label></td>
							<td><asp:textbox id="txtHatchery1" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="470px"></asp:textbox><asp:dropdownlist id=dlstHatchery2 runat="server" Visible="False" Width="470px" DataSource="<%# dvDE_Hatcheries %>" DataTextField="FishFacilityName" DataValueField="FishFacilityID"></asp:dropdownlist><asp:textbox id="txtHatcheryValue" runat="server" Visible="False"></asp:textbox></td>
						</tr>
						<tr>
							<td><asp:label id="Label25" runat="server" CssClass="labelText">Other Hatchery:</asp:label></td>
							<td><asp:textbox id="txtOtherHatchery1" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="470px"></asp:textbox><asp:textbox id="txtOtherHatchery2" runat="server" Visible="False" Width="470px"></asp:textbox></td>
						</tr>
						<tr>
							<td><asp:label id="Label4" runat="server" CssClass="labelText">Species*:</asp:label></td>
							<td><asp:textbox id="txtSpecies1" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="470px"></asp:textbox><asp:dropdownlist id=dlstSpecies2 runat="server" Visible="False" Width="470px" DataSource="<%# dvcdFishSpecies %>" DataTextField="FishSpecies" DataValueField="FishSpeciesCd" AutoPostBack="True" onselectedindexchanged="dlstSpecies2_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txtSpeciesValue" runat="server" Visible="False"></asp:textbox></td>
						</tr>
						<tr>
							<td><asp:label id="Label5" runat="server" CssClass="labelText">Stock:</asp:label></td>
							<td><asp:textbox id="txtStock1" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="470px"></asp:textbox><asp:dropdownlist id=dlstStock2 runat="server" Visible="False" Width="470px" DataSource="<%# dvDE_FishStock %>" DataTextField="Name" DataValueField="FishStockID"></asp:dropdownlist><asp:textbox id="txtStockValue" runat="server" Visible="False"></asp:textbox></td>
						</tr>
						<tr>
							<td><asp:label id="Label26" runat="server" CssClass="labelText">Other Stock:</asp:label></td>
							<td><asp:textbox id="txtOtherStock1" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="470px"></asp:textbox><asp:textbox id="txtOtherStock2" runat="server" Visible="False" Width="470px"></asp:textbox></td>
						</tr>
						<tr>
							<td vAlign="top"><asp:label id="Label6" runat="server" CssClass="labelText">Age Class*:</asp:label></td>
							<td><asp:textbox id="txtAgeClass1" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="470px"></asp:textbox><asp:dropdownlist id=dlstAgeClass2 runat="server" Visible="False" Width="470px" DataSource="<%# dvcdFishAgeClass %>" DataTextField="FishAgeClass" DataValueField="FishAgeClass" AutoPostBack="True" onselectedindexchanged="dlstAgeClass2_SelectedIndexChanged"></asp:dropdownlist><asp:panel id="pnlAdult" runat="server" Visible="False">
									<TABLE border="0">
										<TR>
											<TD>
												<asp:label id="lblAge" runat="server" Visible="False" CssClass="labelText">Age:</asp:label></TD>
											<TD>
												<asp:textbox id="txtAge1" runat="server" Visible="False" BackColor="WhiteSmoke" Enabled="False"></asp:textbox>
												<asp:textbox id="txtAge2" runat="server" Visible="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="lblAgeUnits" runat="server" Visible="False" CssClass="labelText">Age Units:</asp:label></TD>
											<TD>
												<asp:textbox id="txtAgeUnits1" runat="server" Visible="False" BackColor="WhiteSmoke" Enabled="False"></asp:textbox>
												<asp:dropdownlist id=dlstAgeUnits2 runat="server" Visible="False" DataValueField="FishAgeClass" DataTextField="FishAgeClass" DataSource="<%# dvcdFishAgeClass %>">
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="lblBroodstock" runat="server" Visible="False" CssClass="labelText">Broodstock:</asp:label></TD>
											<TD>
												<asp:checkbox id="chkBroodstock1" runat="server" Visible="False" Enabled="False"></asp:checkbox>
												<asp:checkbox id="chkBroodstock2" runat="server" Visible="False"></asp:checkbox></TD>
										</TR>
									</TABLE>
								</asp:panel></td>
						</tr>
						<tr>
							<td><asp:label id="Label7" runat="server" CssClass="labelText">Number of Fish:</asp:label></td>
							<td><asp:textbox id="txtNumberofFish1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtNumberofFish2" runat="server" Visible="False"></asp:textbox><asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="Number of Fish must be an integer"
									ControlToValidate="txtNumberofFish2" Display="None" MaximumValue="5000" MinimumValue="0" Type="Integer"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Number of Fish is a required field"
									ControlToValidate="txtNumberofFish2" Display="None"></asp:requiredfieldvalidator></td>
						</tr>
						<tr>
							<td><asp:label id="Label8" runat="server" CssClass="labelText">Average Length (cm):</asp:label></td>
							<td><asp:textbox id="txtAverageLength1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtAverageLength2" runat="server" Visible="False"></asp:textbox><asp:rangevalidator id="RangeValidator2" runat="server" ErrorMessage="Average Length must be numeric"
									ControlToValidate="txtAverageLength2" Display="None" MaximumValue="1000" MinimumValue="0" Type="Double"></asp:rangevalidator></td>
						</tr>
						<tr>
							<td><asp:label id="Label9" runat="server" CssClass="labelText">Average Weight (g):</asp:label></td>
							<td><asp:textbox id="txtAverageWeight1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtAverageWeight2" runat="server" Visible="False"></asp:textbox><asp:rangevalidator id="RangeValidator3" runat="server" ErrorMessage="Average Weight must be numeric"
									ControlToValidate="txtAverageWeight2" Display="None" MaximumValue="1000" MinimumValue="0" Type="Double"></asp:rangevalidator></td>
						</tr>
						<tr>
							<td><asp:label id="Label10" runat="server" CssClass="labelText">Number of Fish Measured:</asp:label></td>
							<td><asp:textbox id="txtNumberofFishMeasured1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtNumberofFishMeasured2" runat="server" Visible="False"></asp:textbox><asp:rangevalidator id="RangeValidator4" runat="server" ErrorMessage="Number of Fish Measured must be an integer"
									ControlToValidate="txtNumberofFishMeasured2" Display="None" MaximumValue="5000" MinimumValue="0" Type="Integer"></asp:rangevalidator></td>
						</tr>
						<tr>
							<td><asp:label id="Label11" runat="server" CssClass="labelText">Mark Applied:</asp:label></td>
							<td><asp:textbox id="txtMarkApplied1" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="470px"></asp:textbox><asp:dropdownlist id=dlstMarkApplied2 runat="server" Visible="False" Width="470px" DataSource="<%# dvcdFishMark %>" DataTextField="FishMark" DataValueField="FishMarkCd"></asp:dropdownlist><asp:textbox id="txtMarkAppliedValue" runat="server" Visible="False"></asp:textbox></td>
						</tr>
					</TBODY>
				</table>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Water Measurements</legend>
				<table border="0">
					<tr>
						<td><asp:label id="Label12" runat="server" CssClass="labelText"> Water Temperature (°C):</asp:label></td>
						<td><asp:textbox id="txtWaterTemperature1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtWaterTemperature2" runat="server" Visible="False"></asp:textbox><asp:rangevalidator id="RangeValidator5" runat="server" ErrorMessage="Water Temperature must be numeric"
								ControlToValidate="txtWaterTemperature2" Display="None" MaximumValue="50" MinimumValue="-50" Type="Double"></asp:rangevalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label13" runat="server" CssClass="labelText">Air Temperature (°C):</asp:label></td>
						<td><asp:textbox id="txtAirTemperature1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtAirTemperature2" runat="server" Visible="False"></asp:textbox><asp:rangevalidator id="RangeValidator6" runat="server" ErrorMessage="Air Temperature must be numeric"
								ControlToValidate="txtAirTemperature2" Display="None" MaximumValue="50" MinimumValue="-50" Type="Double"></asp:rangevalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label14" runat="server" CssClass="labelText"> Time of Day (24:00 format):</asp:label></td>
						<td><asp:textbox id="txtTimeofDay1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtTimeofDay2" runat="server" Visible="False"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Time of Day must be of form ##:##"
								ControlToValidate="txtTimeofDay2" Display="None" ValidationExpression="\d{2}:\d{2}"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label15" runat="server" CssClass="labelText"> Water Level (cm):</asp:label></td>
						<td><asp:textbox id="txtWaterLevel1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtWaterLevel2" runat="server" Visible="False"></asp:textbox></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Comments</legend><asp:textbox id="txtComments1" runat="server" Enabled="False" Width="100%" TextMode="MultiLine"
					Rows="3"></asp:textbox><asp:textbox id="txtComments2" runat="server" Visible="False" Width="100%" TextMode="MultiLine"
					Rows="3"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Comments cannot exceed 250 characters and can only contain letters and numbers"
					ControlToValidate="txtComments2" Display="None" ValidationExpression="[\d\w\s.-_]{0,250}"></asp:regularexpressionvalidator></fieldset>
			<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="labelText" ShowMessageBox="True"></asp:validationsummary><br>
			<asp:button id="btnModify" runat="server" Visible="False" CssClass="buttonText" Text="Modify"
				CausesValidation="False" onclick="btnModify_Click"></asp:button><asp:button id="btnDelete" runat="server" Visible="False" CssClass="buttonText" Text="Delete"
				CausesValidation="False" onclick="btnDelete_Click"></asp:button><asp:button id="btnReturn" runat="server" CssClass="buttonText" Text="Return to Stocking List"
				CausesValidation="False" onclick="btnReturn_Click"></asp:button><asp:button id="btnSave" runat="server" Visible="False" CssClass="buttonText" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" runat="server" Visible="False" CssClass="buttonText" Text="Cancel"
				CausesValidation="False" onclick="btnCancel_Click"></asp:button><asp:textbox id="txtAquaticActivityID" runat="server" Visible="False"></asp:textbox></form>
	</body>
</HTML>
