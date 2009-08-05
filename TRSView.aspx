<%@ Page language="c#" Inherits="NBADWDataEntryApplication.TRSView" CodeFile="TRSView.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TemperatureRecordingSites-View</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<h1>
				<asp:Label id="lblMainHeading" runat="server" Font-Bold="True" Font-Names="Times New Roman">TEMPERATURE DATA SITES</asp:Label></h1>
			<h2><asp:label id="lblHeading" runat="server" Font-Names="Times New Roman" Font-Bold="True">VIEW Site</asp:label></h2>
			<asp:panel id="pnlReplace" runat="server" Visible="False">
				<TABLE border="0">
					<TR>
						<TD class="standardText">Replace site</TD>
						<TD>
							<asp:Label id="lblCurrentSite" runat="server" BorderStyle="Solid" BorderColor="#E0E0E0" BorderWidth="2px"
								CssClass="standardText"></asp:Label></TD>
						<TD class="standardText">with the following site:</TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel id="pnlInstructions" runat="server" Visible="True">
				<FIELDSET class="standardText"><LEGEND>
						<asp:Label id="lblLegend" runat="server">Instructions</asp:Label></LEGEND>
					<asp:Panel id="pnlAddExisting" runat="server" Visible="False">
						<BR>
						<UL>
							<LI>
								This is an existing Data Warehouse site and you have set it up for
								<asp:Label id="lblType" runat="server">temperature</asp:Label>data.
							<LI>
								You can only enter your Site ID reference.</LI></UL>
					</asp:Panel>
					<asp:Panel id="pnlView" runat="server">
						<BR>
						<UL>
							<LI>
								<asp:Label id="lblDetails" runat="server"></asp:Label>
							<LI>
								If you have administrator access privileges, press <B>Modify</B> button to edit 
								the site information or press <B>Delete</B> to delete the site record (Note: 
								only new sites can be modified or deleted and a site cannot be deleted if
								<asp:Label id="lblTypeView" runat="server"></asp:Label>data has been 
							entered for the site).
							<LI>
								Press the <B>Map</B> button to view the site's location, plus all other data 
								collection sites in the area.
							</LI>
						</UL>
					</asp:Panel>
					<asp:Panel id="pnlAddNew" runat="server" Visible="False">
						<BR>
						<UL>
							<LI>
							You cannot type the name of the lake or stream. You may enter the ID of the 
							lake or stream if you know it or use the Look Up function to find it. The Look 
							Up screen will provide search instructions. Once a water body ID is entered, 
							either directly or through the Look Up, the associated water body name and 
							watershed information will be displayed.
							<LI>
								Press the <B>Save</B> button to save the record or press <B>Cancel</B> to 
								return to the Site List.
							</LI>
						</UL>
					</asp:Panel>
					<asp:Panel id="pnlModifyExisting" runat="server" Visible="False">
						<BR>
						<UL>
							<LI>
							This site is an existing Data Warehouse site and you have assigned a new type 
							of data to it, e.g. temperature data.
							<LI>
								You may change your site ID reference (Agency Site ID).
							</LI>
						</UL>
					</asp:Panel>
					<asp:Panel id="pnlModifyNew" runat="server" Visible="False">
						<BR>
						<UL>
							<LI>
							This is a new site that has not yet been incorporated in the Data Warehouse. 
							You may change any information on this site.
							<LI>
								Press the <B>Look Up</B> button to search for a new water body ID.
							</LI>
						</UL>
					</asp:Panel></FIELDSET>
			</asp:panel>
			<br>
			<fieldset class="standardText"><legend>Site Info</legend>
				<table border="0">
					<tr>
						<td colSpan="2">
							<asp:Label id="lblIndicator" runat="server" Visible="False" CssClass="labelText">* Indicates the form will refresh after you enter information in this field</asp:Label></td>
					</tr>
					<tr>
						<td><asp:label id="lbldwsiteid" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label></td>
						<td><asp:textbox id="txtdwsiteid" runat="server" Enabled="False" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtdwsiteid2" runat="server" Visible="False" BackColor="White"></asp:textbox>&nbsp;&nbsp;<asp:button id="btnSearchSiteID" tabIndex="12" runat="server" Visible="False" CssClass="buttonText"
								Text="Look Up" CausesValidation="False" onclick="btnSearchSiteID_Click"></asp:button><asp:button id="btnSwitchSiteID" tabIndex="12" runat="server" Visible="False" CssClass="buttonText"
								Text="Switch to Another Site" CausesValidation="False" onclick="btnSwitchSiteID_Click"></asp:button></td>
					</tr>
					<TR>
						<TD><asp:label id="Label14" runat="server" CssClass="labelText"> Agency Code:</asp:label></TD>
						<td><asp:textbox id="txtagencycd" runat="server" Font-Names="Arial" Font-Size="X-Small" Enabled="False"
								BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtAquaticActivityCd" runat="server" Visible="False" Enabled="False"></asp:textbox></td>
					</TR>
					<tr>
						<td><asp:label id="Label3" runat="server" CssClass="labelText">Water Body ID*:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyid" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtwaterbodyid2" runat="server" Visible="False" BackColor="White" AutoPostBack="True" ontextchanged="txtwaterbodyid2_TextChanged"></asp:textbox>&nbsp;&nbsp;<asp:button id="btnSearchWaterbodyID" tabIndex="8" runat="server" Visible="False" CssClass="buttonText"
								Text="Look Up" CausesValidation="False" onclick="btnSearchWaterbodyID_Click"></asp:button><asp:label id="lblwbMessage" runat="server" Font-Bold="True" Visible="False" CssClass="labelText"
								ForeColor="Red">The water body entered is not valid</asp:label><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtwaterbodyid2"
								ErrorMessage="Water Body ID is a required field"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyname" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><asp:textbox id="txtwaterbodyname2" runat="server" Visible="False" Enabled="False" BackColor="WhiteSmoke"
								Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label5" runat="server" CssClass="labelText">Watershed:</asp:label>
						<td><asp:textbox id="txtwatershed" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><asp:textbox id="txtwatershed2" runat="server" Visible="False" Enabled="False" BackColor="WhiteSmoke"
								Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label8" runat="server" CssClass="labelText">Watershed Code:</asp:label>
						<td><asp:textbox id="txtwatershedcode" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><asp:textbox id="txtwatershedcode2" runat="server" Visible="False" Enabled="False" BackColor="WhiteSmoke"
								Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server" CssClass="labelText">Site Name:</asp:label>
						<td><asp:textbox id="txtsitename" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><asp:textbox id="txtsitename2" runat="server" Visible="False" BackColor="White" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label7" runat="server" CssClass="labelText">Site Description:</asp:label></td>
						<td><asp:textbox id="txtsitedescription" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><asp:textbox id="txtsitedescription2" runat="server" Visible="False" BackColor="White" Width="520px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtsitedescription2"
								ErrorMessage="Site Description is a required field"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label2" runat="server" CssClass="labelText">Agency Site ID:</asp:label></td>
						<td><asp:textbox id="txtgroupsiteid" runat="server" Font-Names="Arial" Font-Size="X-Small" Enabled="False"
								BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtgroupsiteid2" runat="server" Visible="False" BackColor="White"></asp:textbox></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Coordinates</legend>
				<table>
					<tr>
						<td><asp:label id="Label13" runat="server" CssClass="labelText">Source*:</asp:label></td>
						<td><asp:textbox id="txtsource" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="312px"></asp:textbox><asp:dropdownlist id="dlstsource" runat="server" Visible="False" Width="312px" AutoPostBack="True" onselectedindexchanged="dlstSource_SelectedIndexChanged"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td><asp:label id="Label9" runat="server" CssClass="labelText">System:</asp:label></td>
						<td><asp:textbox id="txtsystem" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="312px"></asp:textbox><asp:dropdownlist id="dlstsystem" runat="server" Visible="False" Width="312px"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td><asp:label id="Label12" runat="server" CssClass="labelText">Units*:</asp:label></td>
						<td><asp:textbox id="txtunits" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="312px"></asp:textbox><asp:dropdownlist id="dlstunits" runat="server" Visible="False" AutoPostBack="True" Width="312px" onselectedindexchanged="dlstunits_SelectedIndexChanged"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td><asp:label id="lblX" runat="server" CssClass="labelText">Longitude:</asp:label></td>
						<td><asp:textbox id="txtX" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtX2" runat="server" Visible="False" BackColor="White"></asp:textbox><asp:label id="lblFormatX" runat="server" Visible="False" CssClass="labelText"></asp:label><asp:regularexpressionvalidator id="revX" runat="server" Display="None" ControlToValidate="txtX2"></asp:regularexpressionvalidator>&nbsp;&nbsp;<asp:button id="btnMap" runat="server" CssClass="buttonText" Text="Map" CausesValidation="False" onclick="btnMap_Click" Visible="False"></asp:button></td>
					</tr>
					<tr>
						<td><asp:label id="lblY" runat="server" CssClass="labelText">Latitude:</asp:label></td>
						<td><asp:textbox id="txtY" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox><asp:textbox id="txtY2" runat="server" Visible="False" BackColor="White"></asp:textbox><asp:label id="lblFormatY" runat="server" Visible="False" CssClass="labelText"></asp:label><asp:regularexpressionvalidator id="revY" runat="server" Display="None" ControlToValidate="txtY2"></asp:regularexpressionvalidator></td>
					</tr>
				</table>
			</fieldset>
			<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="labelText" ShowMessageBox="True"></asp:validationsummary><br>
			<asp:panel id="pnlViewBtns" runat="server">
				<TABLE width="100%" border="0">
					<TR>
						<TD>
							<asp:button id="btnLoggerDetails" runat="server" CausesValidation="False" Text="Logger Details" onclick="btnLoggerDetails_Click"></asp:button>
							<asp:button id="btnModify" runat="server" Visible="False" CausesValidation="False" Text="Modify" onclick="btnModify_Click"></asp:button>
							<asp:button id="btnDelete" runat="server" Visible="False" CausesValidation="False" Text="Delete" onclick="btnDelete_Click"></asp:button></TD>
						<TD>
							<asp:button id="btnClose" tabIndex="7" runat="server" CssClass="buttonText" CausesValidation="False"
								Text="Return to Site List" onclick="btnClose_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel id="pnlModifyBtns" runat="server" Visible="False">
				<asp:button id="btnSave" tabIndex="1" runat="server" CssClass="buttonText" Text="Save" onclick="btnSave_Click"></asp:button>
				<asp:button id="btnCancel" tabIndex="7" runat="server" CssClass="buttonText" CausesValidation="False"
					Text="Cancel" onclick="btnCancel_Click"></asp:button>
			</asp:panel></form>
	</body>
</HTML>
