<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFSiteIdentification" CodeFile="ESAFSiteIdentification.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>TemperatureRecordingSites-AddNew</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<h1>ENVIRONMENTAL STREAM ASSESSMENT</h1>
		<h2><asp:label id="lblh2" Font-Bold="True" Font-Names="Times New Roman" runat="server">ADD New Assessment</asp:label></h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend><asp:label id="lblStep" runat="server">Step 1 of 7 - Enter </asp:label>Site 
					Information</legend>
				<table border="0">
					<tr>
						<td colspan="2"><asp:label id="Label1" runat="server" CssClass="labelText">* Indicates the form will refresh after you enter information in this field</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label3" runat="server" CssClass="labelText">Water Body ID*:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyid" tabIndex="7" runat="server" AutoPostBack="True" ontextchanged="txtwaterbodyid_TextChanged"></asp:textbox>&nbsp;&nbsp;<asp:button id="btnSearchWaterbodyID" tabIndex="8" runat="server" CssClass="buttonText" CausesValidation="False"
								Text="Look Up" onclick="btnSearchWaterbodyID_Click"></asp:button>
							<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Water Body ID is a required field"
								Display="None" ControlToValidate="txtwaterbodyid"></asp:requiredfieldvalidator><asp:label id="lblwbMessage" Font-Bold="True" runat="server" CssClass="labelText" ForeColor="Red"
								Visible="False">The water body entered is not valid</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyname" tabIndex="9" runat="server" Enabled="False" Width="520px"
								BorderWidth="0px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label5" runat="server" CssClass="labelText">Watershed:</asp:label></td>
						<td><asp:textbox id="txtwatershed" tabIndex="10" runat="server" Enabled="False" Width="520px" BorderWidth="0px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label8" runat="server" CssClass="labelText">Watershed Code:</asp:label></td>
						<td><asp:textbox id="txtwatershedcode" runat="server" Enabled="False" BorderWidth="0px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server" CssClass="labelText">Site Name:</asp:label></td>
						<td><asp:textbox id="txtsitename" tabIndex="11" runat="server" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label7" runat="server" CssClass="labelText">Site Description:</asp:label></td>
						<td><asp:textbox id="txtsitedescription" tabIndex="12" runat="server" Width="520px"></asp:textbox>
                            <asp:RequiredFieldValidator ID="txtSiteDescriptionValidator" runat="server" ControlToValidate="txtsitedescription"
                                Display="None" ErrorMessage="Site description cannot be emtpy!"></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label2" runat="server" CssClass="labelText">Agency Site ID:</asp:label></td>
						<td><asp:textbox id="txtgroupsiteid" tabIndex="6" runat="server"></asp:textbox></td>
					</tr>
					<tr>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td><asp:label id="Label11" runat="server" CssClass="labelText" Font-Bold="True">Coordinates</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label10" runat="server" CssClass="labelText">Source*:</asp:label></td>
						<td><asp:dropdownlist id="dlstSource" tabIndex="13" runat="server" AutoPostBack="True" Width="312px" onselectedindexchanged="dlstSource_SelectedIndexChanged"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td><asp:label id="Label9" runat="server" CssClass="labelText">System:</asp:label></td>
						<td><asp:dropdownlist id="dlstSystem" tabIndex="13" runat="server" Width="312px"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td><asp:label id="Label12" runat="server" CssClass="labelText">Units*:</asp:label></td>
						<td><asp:dropdownlist id="dlstUnits" tabIndex="14" runat="server" AutoPostBack="True" Width="312px" onselectedindexchanged="dlstUnits_SelectedIndexChanged"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td><asp:label id="lblX" runat="server" CssClass="labelText">Longitude:</asp:label></td>
						<td><asp:textbox id="txtX" tabIndex="15" runat="server"></asp:textbox>&nbsp;&nbsp;<asp:label id="lblFormatX" runat="server" CssClass="labelText"></asp:label><asp:regularexpressionvalidator id="revX" runat="server" CssClass="labelText" Display="None" ControlToValidate="txtX"></asp:regularexpressionvalidator>&nbsp;&nbsp;<asp:button id="btnMap" runat="server" CssClass="buttonText" CausesValidation="False" Text="Map" onclick="btnMap_Click" Visible="False"></asp:button></td>
					</tr>
					<tr>
						<td><asp:label id="lblY" runat="server" CssClass="labelText">Latitude:</asp:label></td>
						<td><asp:textbox id="txtY" tabIndex="16" runat="server"></asp:textbox>&nbsp;&nbsp;<asp:label id="lblFormatY" runat="server" CssClass="labelText"></asp:label><asp:regularexpressionvalidator id="revY" runat="server" CssClass="labelText" Display="None" ControlToValidate="txtY"></asp:regularexpressionvalidator></td>
					</tr>
				</table>
			</fieldset>
			<br/>
			<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="labelText" ShowMessageBox="True"></asp:validationsummary>
			<asp:button id="btnNext" tabIndex="2" runat="server" CssClass="buttonText" Text="Next" Width="60px" onclick="btnNext_Click"></asp:button>
			<asp:Button id="btnCancel2" runat="server" Text="Cancel" CausesValidation="False" onclick="btnCancel2_Click"></asp:Button>
			<asp:button id="btnSave" tabIndex="1" runat="server" CssClass="buttonText" Text="Save" Width="60px"
				Visible="False" onclick="btnSave_Click"></asp:button>
			<asp:button id="btnCancel" tabIndex="2" runat="server" CssClass="buttonText" Text="Cancel" Width="60px"
				Visible="False" CausesValidation="False" onclick="btnCancel_Click"></asp:button></form>
	</body>
</html>
