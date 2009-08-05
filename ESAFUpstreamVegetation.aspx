<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFUpstreamVegetation" CodeFile="ESAFUpstreamVegetation.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFUpstreamVegetation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
		<script>history.forward();</script>
	</HEAD>
	<body>
		<h1>ENVIRONMENTAL STREAM ASSESSMENT</h1>
		<h2><asp:Label id="lblh2" runat="server" Font-Names="Times New Roman" Font-Bold="True">ADD New Assessment</asp:Label></h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend><asp:label id="lblStep" runat="server">Step 5 of 7 - Enter </asp:label>
					Upstream Vegetation</legend><br>
				<table border="0">
					<tr>
						<td><asp:label id="Label1" runat="server" CssClass="labelText">Riparian Zone (30m)</asp:label></td>
						<td align="center"><asp:label id="Label2" runat="server" CssClass="labelText">Left Bank (%)</asp:label></td>
						<td align="center"><asp:label id="Label3" runat="server" CssClass="labelText">Right Bank (%)</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" runat="server" CssClass="labelText">Lawn:</asp:label></td>
						<td><asp:textbox id="txtLawnL" runat="server"></asp:textbox><asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="Lawn Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtLawnL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtLawnR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator11" runat="server" ErrorMessage="Lawn Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtLawnR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label5" runat="server" CssClass="labelText">Row crop:</asp:label></td>
						<td><asp:textbox id="txtRowCropL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator2" runat="server" ErrorMessage="Row Crop Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtRowCropL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtRowCropR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator12" runat="server" ErrorMessage="Row Crop Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtRowCropR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server" CssClass="labelText">Forage/cover crop:</asp:label></td>
						<td><asp:textbox id="txtForageL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator3" runat="server" ErrorMessage="Forage Crop Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtForageL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtForageR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator13" runat="server" ErrorMessage="Forage Crop Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtForageR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label7" runat="server" CssClass="labelText">Shrubs:</asp:label></td>
						<td><asp:textbox id="txtShrubsL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator4" runat="server" ErrorMessage="Shrubs Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtShrubsL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtShrubsR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator14" runat="server" ErrorMessage="Shrubs Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtShrubsR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label8" runat="server" CssClass="labelText">Hardwood forest:</asp:label></td>
						<td><asp:textbox id="txtHardwoodL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator5" runat="server" ErrorMessage="Hardwood Forest Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtHardwoodL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtHardwoodR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator15" runat="server" ErrorMessage="Hardwood Forest Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtHardwoodR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label9" runat="server" CssClass="labelText">Softwood forest:</asp:label></td>
						<td><asp:textbox id="txtSoftwoodL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator6" runat="server" ErrorMessage="Softwood Forest Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtSoftwoodL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtSoftwoodR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator16" runat="server" ErrorMessage="Softwood Forest Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtSoftwoodR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label10" runat="server" CssClass="labelText">Mixed forest:</asp:label></td>
						<td><asp:textbox id="txtMixedL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator7" runat="server" ErrorMessage="Mixed Forest Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtMixedL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtMixedR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator17" runat="server" ErrorMessage="Mixed Forest Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtMixedR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label11" runat="server" CssClass="labelText">Meadow/Tall grasses:</asp:label></td>
						<td><asp:textbox id="txtMeadowL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator8" runat="server" ErrorMessage="Meadow Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtMeadowL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtMeadowR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator18" runat="server" ErrorMessage="Meadow Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtMeadowR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label12" runat="server" CssClass="labelText">Wetland:</asp:label></td>
						<td><asp:textbox id="txtWetlandL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator9" runat="server" ErrorMessage="Wetland Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtWetlandL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtWetlandR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator19" runat="server" ErrorMessage="Wetland Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtWetlandR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label13" runat="server" CssClass="labelText">Altered:</asp:label></td>
						<td><asp:textbox id="txtAlteredL" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator10" runat="server" ErrorMessage="Altered Left Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtAlteredL" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
						<td><asp:textbox id="txtAlteredR" runat="server"></asp:textbox><asp:RangeValidator id="Rangevalidator20" runat="server" ErrorMessage="Altered Right Bank entry must be numeric and between 0 and 100"
								Display="None" ControlToValidate="txtAlteredR" MinimumValue="0" MaximumValue="100" Type="Integer"></asp:RangeValidator></td>
					</tr>
				</table>
			</fieldset>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" CssClass="labelText"></asp:ValidationSummary>
			<br>
			<asp:Button id="btnNext" runat="server" CssClass="buttonText" Text="Next" onclick="btnNext_Click"></asp:Button>
			<asp:Button id="btnSave" runat="server" Text="Save" Visible="False" onclick="btnNext_Click"></asp:Button>
			<asp:Button id="btnCancel" runat="server" Text="Cancel" Visible="False" CausesValidation="False" onclick="btnCancel_Click"></asp:Button></form>
	</body>
</HTML>
