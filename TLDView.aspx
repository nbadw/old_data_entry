<%@ Page language="c#" Inherits="NBADWDataEntryApplication.TLDView" CodeFile="TLDView.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TLDView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>WATER TEMPERATURES</h1>
		<h2><asp:label id="lblh2" Font-Bold="True" Font-Names="Times New Roman" runat="server">VIEW</asp:label></h2>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlAdd" runat="server" Visible="False">
				<FIELDSET class="standardtext"><LEGEND>Instructions</LEGEND>
					<UL>
						<LI>
							Press the <B>Save</B> button to save the record or press <B>Cancel </B>to 
							return to the Site List.</LI></UL>
				</FIELDSET>
			</asp:panel>
			<asp:panel id="pnlEdit" runat="server" Visible="False">
				<FIELDSET class="standardtext"><LEGEND>Instructions</LEGEND>
					<UL>
						<LI>
							If the data logger has been assigned to the wrong site, you may change the site 
							by clicking <B>Change Site for Current Logger</B>. You will be presented 
						with a list of temperature logger sites set up by your organization.
						<LI>
						You may also make other changes.
						<LI>
							When done, click <B>Save</B> to save edits or click <B>Cancel</B> to exit 
							without saving.</LI></UL>
				</FIELDSET>
			</asp:panel>
			<br>
			<fieldset class="standardText"><legend>Site Info</legend>
				<table width="100%" border="0">
					<tr>
						<td vAlign="top"><asp:label id="Label1" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label><br>
							<asp:textbox id="txtdwsiteid" tabIndex="1" runat="server" AutoPostBack="True" BackColor="WhiteSmoke"
								Enabled="False"></asp:textbox>
							<asp:button id="btnLookUp" tabIndex="1" runat="server" Visible="False" Text="Look Up" onclick="btnLookUp_Click"></asp:button><br>
							<asp:button id="btnChangeSite" tabIndex="2" runat="server" Visible="False" CssClass="buttonText"
								Text="Change Site for Current Logger" CausesValidation="False" onclick="btnChangeSite_Click"></asp:button></td>
						<td vAlign="top"><asp:label id="Label6" runat="server" CssClass="labelText">Site Name:</asp:label><br>
							<asp:textbox id="txtsitename" tabIndex="3" runat="server" BackColor="WhiteSmoke" Enabled="False"
								Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top">
							<asp:TextBox id="txtUNCHANGEDdwsiteid" runat="server" Visible="False"></asp:TextBox></td>
						<td vAlign="top"><asp:label id="Label7" runat="server" CssClass="labelText">Site Description:</asp:label><br>
							<asp:textbox id="txtsitedescription" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label2" runat="server" CssClass="labelText">Agency Code:</asp:label><br>
							<asp:textbox id="txtagencycd" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td vAlign="top"><asp:label id="Label29" runat="server" CssClass="labelText">Agency Site ID:</asp:label><br>
							<asp:textbox id="txtgroupsiteid" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<TR>
						<TD vAlign="top"><asp:label id="Label3" runat="server" CssClass="labelText">Water Body ID:</asp:label><br>
							<asp:textbox id="txtwaterbodyid" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></TD>
						<td vAlign="top"><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label><br>
							<asp:textbox id="txtwaterbodyname" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox><br>
						</td>
					</TR>
					<tr>
						<td vAlign="top"><asp:label id="Label8" runat="server" CssClass="labelText">Watershed Code:</asp:label><br>
							<asp:textbox id="txtwatershedcode" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<TD vAlign="top"><asp:label id="Label5" runat="server" CssClass="labelText">Watershed:</asp:label><br>
							<asp:textbox id="txtwatershed" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox><br>
						</TD>
					</tr>
				</table>
			</fieldset>
			<BR>
			<FIELDSET class="standardText"><legend>Agency Info</legend>
				<table border="0">
					<!--
					<tr>
						<td><asp:label id="Label12" runat="server" CssClass="labelText"> Agency:</asp:label></td>
						<td colSpan="2"><asp:dropdownlist id=dlstAgency1 runat="server" Visible="False" DataValueField="AgencyCd" DataTextField="Agency" DataSource="<%# dvcdAgency %>"></asp:dropdownlist><asp:textbox id="txtAgency1" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
					</tr>
					-->
					<tr>
						<td><asp:label id="Label27" runat="server" CssClass="labelText">Second Agency:</asp:label></td>
						<td colSpan="2"><asp:dropdownlist id=dlstAgency2 runat="server" Visible="False" DataSource="<%# dvcdAgency %>" DataTextField="Agency" DataValueField="AgencyCd"></asp:dropdownlist><asp:textbox id="txtAgency2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label28" runat="server" CssClass="labelText">Personnel:</asp:label></td>
						<td colSpan="2"><asp:textbox id="txtPersonnel" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="100%"></asp:textbox></td>
					</tr>
				</table>
			</FIELDSET>
			<br>
			<FIELDSET class="standardText"><legend>Data Logger</legend>
				<table>
					<tr>
						<td><asp:label id="Label9" runat="server" CssClass="labelText">Logger Identifier:</asp:label></td>
						<td><asp:textbox id="txtDataLoggerID" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Width="95px" Display="None" ControlToValidate="txtDataLoggerID"
								ErrorMessage="Data Logger ID is a required field"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label10" runat="server" CssClass="labelText">Data File Name:</asp:label></td>
						<td><asp:textbox id="txtDataFileName" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtDataFileName"
								ErrorMessage="Data File Name is a required field"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label15" runat="server" CssClass="labelText">Sample Interval (minutes):</asp:label></td>
						<td><asp:textbox id="txtSampleInterval" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtSampleInterval"
								ErrorMessage="Sample Interval is a required field"></asp:requiredfieldvalidator><asp:rangevalidator id="RangeValidator4" runat="server" Display="None" ControlToValidate="txtSampleInterval"
								ErrorMessage="Sample Interval must be numeric" Type="Double" MinimumValue="0" MaximumValue="1000"></asp:rangevalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label21" runat="server" CssClass="labelText"> Data Begins (yyyy/mm/dd):</asp:label></td>
						<td>
							<asp:textbox id="txtRecordingStartDate" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtRecordingStartDate"
								ErrorMessage="Recording Start Date is a required field"></asp:requiredfieldvalidator>
							<asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" Display="None" ControlToValidate="txtRecordingStartDate"
								ErrorMessage="Recording Start Date must be of the form yyyy/mm/dd" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"></asp:regularexpressionvalidator></td>
						<td></td>
						<td colspan="2"><asp:label id="Label31" runat="server" CssClass="labelText">(Date of first full day of <u>
									valid</u> water temperature recordings)</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label23" runat="server" CssClass="labelText"> Data Ends (yyyy/mm/dd):</asp:label></td>
						<td>
							<asp:textbox id="txtRecordingEndDate" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="txtRecordingEndDate"
								ErrorMessage="Recording End Date is a required field"></asp:requiredfieldvalidator>
							<asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" Display="None" ControlToValidate="txtRecordingEndDate"
								ErrorMessage="Recording End Date must be of the form yyyy/mm/dd" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"></asp:regularexpressionvalidator></td>
						<td></td>
						<td colspan="2"><asp:label id="Label36" runat="server" CssClass="labelText">(Date of last full day of <u>
									valid</u> water temperature recordings)</asp:label></td>
					</tr>
					<tr>
						<td>
							<asp:label id="Label37" runat="server" CssClass="labelText">Out of Water Readings Occurred:</asp:label>
						<td>
							<asp:CheckBox id="chkOutofWaterReadingsOccurred" runat="server" Enabled="False"></asp:CheckBox></td>
					</tr>
					<tr>
						<td>
							<asp:label id="Label38" runat="server" CssClass="labelText">Out of Water Readings Removed:</asp:label>
						<td>
							<asp:CheckBox id="chkOutofWaterReadingsRemoved" runat="server" Enabled="False"></asp:CheckBox></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td>&nbsp;</td>
						<td>&nbsp;</td>
						<td>&nbsp;</td>
						<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label13" runat="server" CssClass="labelText">Distance From Shore (m):</asp:label></td>
						<td><asp:label id="Label16" runat="server" CssClass="labelText">True Left Bank:</asp:label></td>
						<td></td>
						<td><asp:textbox id="txtTrueLeftBank" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator1" runat="server" Display="None" ControlToValidate="txtTrueLeftBank"
								ErrorMessage="True Left Bank must be numeric" Type="Double" MinimumValue="-1000" MaximumValue="1000"></asp:rangevalidator></td>
					</tr>
					<tr>
						<td></td>
						<td><asp:label id="Label17" runat="server" CssClass="labelText">True Right Bank:</asp:label></td>
						<td></td>
						<td><asp:textbox id="txtTrueRightBank" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator2" runat="server" Display="None" ControlToValidate="txtTrueRightBank"
								ErrorMessage="True Right Bank must be numeric" Type="Double" MinimumValue="-1000" MaximumValue="1000"></asp:rangevalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label14" runat="server" CssClass="labelText">Water Depth (cm):</asp:label></td>
						<td><asp:textbox id="txtWaterDepth" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator3" runat="server" Display="None" ControlToValidate="txtWaterDepth"
								ErrorMessage="Water Depth must be numeric" Type="Double" MinimumValue="0" MaximumValue="1000"></asp:rangevalidator></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td></td>
						<td><asp:label id="Label33" runat="server" CssClass="labelText">Installation</asp:label></td>
						<td></td>
						<td><asp:label id="Label34" runat="server" CssClass="labelText">Removal</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label11" runat="server" CssClass="labelText">Date (yyyy/mm/dd):</asp:label></td>
						<td><asp:textbox id="txtInstallationDate" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" Display="None" ControlToValidate="txtInstallationDate"
								ErrorMessage="Installation Date must be of the form yyyy/mm/dd" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"></asp:regularexpressionvalidator></td>
						<td></td>
						<td><asp:textbox id="txtRemovalDate" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator5" runat="server" Display="None" ControlToValidate="txtRemovalDate"
								ErrorMessage="Removal Date must be of the form yyyy/mm/dd" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label24" runat="server" CssClass="labelText">Water Temp (°C):</asp:label></td>
						<td><asp:textbox id="txtInstallWaterTemp" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator5" runat="server" Display="None" ControlToValidate="txtInstallWaterTemp"
								ErrorMessage="Install Water Temp must be numeric" Type="Double" MinimumValue="-50" MaximumValue="50"></asp:rangevalidator></td>
						<td></td>
						<td><asp:textbox id="txtRemoveWaterTemp" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator6" runat="server" Display="None" ControlToValidate="txtRemoveWaterTemp"
								ErrorMessage="Removal Water Temp must be numeric" Type="Double" MinimumValue="-50" MaximumValue="50"></asp:rangevalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label25" runat="server" CssClass="labelText">Air Temp (°C):</asp:label></td>
						<td><asp:textbox id="txtInstallAirTemp" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator7" runat="server" Display="None" ControlToValidate="txtInstallAirTemp"
								ErrorMessage="Install Air Temp must be numeric" Type="Double" MinimumValue="-50" MaximumValue="50"></asp:rangevalidator></td>
						<td></td>
						<td><asp:textbox id="txtRemoveAirTemp" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator8" runat="server" Display="None" ControlToValidate="txtRemoveAirTemp"
								ErrorMessage="Removal Air Temp must be numeric" Type="Double" MinimumValue="-50" MaximumValue="50"></asp:rangevalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label26" runat="server" CssClass="labelText"> Time of Day (24:00):</asp:label></td>
						<td><asp:textbox id="txtInstallTimeofDay" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" Display="None" ControlToValidate="txtInstallTimeofDay"
								ErrorMessage="Install Time of Day must be of form ##:##" ValidationExpression="\d{2}:\d{2}"></asp:regularexpressionvalidator></td>
						<td></td>
						<td><asp:textbox id="txtRemoveTimeofDay" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator7" runat="server" Display="None" ControlToValidate="txtRemoveTimeofDay"
								ErrorMessage="Remove Time of Day must be of form ##:##" ValidationExpression="\d{2}:\d{2}"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label30" runat="server" CssClass="labelText"> Water Level:</asp:label></td>
						<td><asp:textbox id="txtInstallWaterLevel" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:dropdownlist id="dlstInstallWaterLevel" runat="server" Width="100%"></asp:dropdownlist></td>
						<td></td>
						<td><asp:textbox id="txtRemoveWaterLevel" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:dropdownlist id="dlstRemoveWaterLevel" runat="server" Width="100%"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td><asp:label id="Label18" runat="server" CssClass="labelText">Brand Name:</asp:label></td>
						<td><asp:textbox id="txtBrandName" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label19" runat="server" CssClass="labelText">Model:</asp:label></td>
						<td><asp:textbox id="txtModel" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label20" runat="server" CssClass="labelText">Resolution:</asp:label></td>
						<td><asp:textbox id="txtResolution" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label35" runat="server" CssClass="labelText">Accuracy:</asp:label></td>
						<td><asp:textbox id="txtAccuracy" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label22" runat="server" CssClass="labelText">Temperature Range (°C):</asp:label></td>
						<td><asp:textbox id="txtRangeFrom" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox>
							<asp:rangevalidator id="RangeValidator9" runat="server" Display="None" ControlToValidate="txtRangeFrom"
								ErrorMessage="Temperature Range values must be numeric" Type="Double" MinimumValue="-1000" MaximumValue="1000"></asp:rangevalidator></td>
						<td><asp:label id="Label32" runat="server" CssClass="labelText">to</asp:label></td>
						<td><asp:textbox id="txtRangeTo" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator10" runat="server" Display="None" ControlToValidate="txtRangeTo"
								ErrorMessage="Temperature Range values must be numeric" Type="Double" MinimumValue="-1000" MaximumValue="1000"></asp:rangevalidator></td>
					</tr>
				</table>
			</FIELDSET>
			<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="labelText" ShowMessageBox="True"></asp:validationsummary><br>
			<asp:button id="btnModify" runat="server" Visible="False" CssClass="buttonText" Text="Modify"
				CausesValidation="False" onclick="btnModify_Click"></asp:button><asp:button id="btnDelete" runat="server" Visible="False" CssClass="buttonText" Text="Delete"
				CausesValidation="False" onclick="btnDelete_Click"></asp:button>
			<asp:button id="btnSave" runat="server" Visible="False" CssClass="buttonText" Text="Save" onclick="btnSave_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Visible="False" CssClass="buttonText" Text="Cancel"
				CausesValidation="False" onclick="btnCancel_Click"></asp:button>
			<asp:button id="btnData" runat="server" CssClass="buttonText" Text="Temperature Data" CausesValidation="False"
				Visible="False" onclick="btnData_Click"></asp:button>
			&nbsp;&nbsp;<asp:button id="btnReturn" runat="server" CssClass="buttonText" Text="Return to Logger List"
				CausesValidation="False" onclick="btnReturn_Click"></asp:button></form>
	</body>
</HTML>
