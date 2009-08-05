<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFFieldMeasurements" CodeFile="ESAFFieldMeasurements.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFFieldMeasurements</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
		<script>history.forward();</script>
	</HEAD>
	<body>
		<h1>ENVIRONMENTAL STREAM ASSESSMENT</h1>
		<h2><asp:label id="lblh2" runat="server" Font-Names="Times New Roman" Font-Bold="True">ADD New Assessment</asp:label></h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend><asp:label id="lblStep" runat="server">Step 6 of 7 - Enter </asp:label>
					Field Measurements</legend>
				<ul>
					<li>
						Ensure the field measurement on the paper form match the units used below.</li>
				</ul>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Stream Measurements</legend>
				<table border="0">
					<tr>
						<td><asp:label id="Label1" CssClass="labelText" runat="server">Section Length (m):</asp:label></td>
						<td><asp:textbox id="txtSectionLength" runat="server"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Section Length must be numeric"
								ControlToValidate="txtSectionLength" Display="None" ValidationExpression="\d{1,}"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label2" CssClass="labelText" runat="server">Average Wet Stream Width (m):</asp:label></td>
						<td><asp:textbox id="txtAverageWetStreamWidth" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Average Wet Stream Width must be numeric"
								ControlToValidate="txtAverageWetStreamWidth" Display="None" ValidationExpression="\d{1,}"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label3" CssClass="labelText" runat="server">Average Stream Depth (m):</asp:label></td>
						<td><asp:textbox id="txtAverageStreamDepth" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ErrorMessage="Average Stream Depth must be numeric"
								ControlToValidate="txtAverageStreamDepth" Display="None" ValidationExpression="\d{1,}"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" CssClass="labelText" runat="server">Stream Velocity (m/s):</asp:label></td>
						<td><asp:textbox id="txtStreamVelocity" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" ErrorMessage="Stream Velocity must be numeric"
								ControlToValidate="txtStreamVelocity" Display="None" ValidationExpression="\d{1,}"></asp:regularexpressionvalidator></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Water Measurements</legend>
				<table border="0">
					<tr>
						<td><asp:label id="Parameter" CssClass="labelText" runat="server">Parameter</asp:label></td>
						<td align="center"><asp:label id="Stream" CssClass="labelText" runat="server">Stream</asp:label></td>
						<td align="center"><asp:label id="Label15" CssClass="labelText" runat="server">Groundwater Seep # 1</asp:label></td>
						<td align="center"><asp:label id="Label16" CssClass="labelText" runat="server">Groundwater Seep # 2</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" CssClass="labelText" runat="server">Time of Day (24:00 format):</asp:label></td>
						<td><asp:textbox id="txtTod_ST" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" ErrorMessage="Stream Time of Day must be ##:##"
								ControlToValidate="txtTod_ST" Display="None" ValidationExpression="\d{2}[:]\d{2}"></asp:regularexpressionvalidator></td>
						<td><asp:textbox id="txtTod_GW1" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" ErrorMessage="Groundwater Seep # 1 Time of Day must be ##:##"
								ControlToValidate="txtTod_GW1" Display="None" ValidationExpression="\d{2}[:]\d{2}"></asp:regularexpressionvalidator></td>
						<td><asp:textbox id="txtTod_GW2" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator7" runat="server" ErrorMessage="Groundwater Seep # 2 Time of Day must be ##:##"
								ControlToValidate="txtTod_GW2" Display="None" ValidationExpression="\d{2}[:]\d{2}"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label7" CssClass="labelText" runat="server">Dissolved Oxygen (ppm):</asp:label></td>
						<td><asp:textbox id="txtDo_ST" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator1" runat="server" Display="None" ControlToValidate="txtDo_ST"
								ErrorMessage="Stream Dissolved Oxygen must be double and within range 0 to 20" MinimumValue="0"
								MaximumValue="20" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtDo_GW1" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator2" runat="server" Display="None" ControlToValidate="txtDo_GW1"
								ErrorMessage="Groundwater Seep # 1 Dissolved Oxygen must be double and within range 0 to 20" MinimumValue="0"
								MaximumValue="20" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtDo_GW2" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator3" runat="server" Display="None" ControlToValidate="txtDo_GW2"
								ErrorMessage="Groundwater Seep #2 Dissolved Oxygen must be double and within range 0 to 20" MinimumValue="0"
								MaximumValue="20" Type="Double"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label8" CssClass="labelText" runat="server">Air Temperature (°C):</asp:label></td>
						<td><asp:textbox id="txtAt_ST" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator4" runat="server" Display="None" ControlToValidate="txtAt_ST"
								ErrorMessage="Stream Air Temperature must be double and within range -50 to 50" MinimumValue="-50"
								MaximumValue="50" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtAt_GW1" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator5" runat="server" Display="None" ControlToValidate="txtAt_GW1"
								ErrorMessage="Groundwater Seep # 1 Air Temperature must be double and within range -50 to 50" MinimumValue="-50"
								MaximumValue="50" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtAt_GW2" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator6" runat="server" Display="None" ControlToValidate="txtAt_GW2"
								ErrorMessage="Groundwater Seep # 2 Air Temperature must be double and within range -50 to 50" MinimumValue="-50"
								MaximumValue="50" Type="Double"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label9" CssClass="labelText" runat="server">Water Temperature (°C):</asp:label></td>
						<td><asp:textbox id="txtWt_ST" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator7" runat="server" Display="None" ControlToValidate="txtWt_ST"
								ErrorMessage="Stream Water Temperature must be double and within range -5 to 45" MinimumValue="-5"
								MaximumValue="45" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtWt_GW1" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator8" runat="server" Display="None" ControlToValidate="txtWt_GW1"
								ErrorMessage="Groundwater Seep # 1 Water Temperature must be double and within range -5 to 45" MinimumValue="-5"
								MaximumValue="45" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtWt_GW2" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator9" runat="server" Display="None" ControlToValidate="txtWt_GW2"
								ErrorMessage="Groundwater Seep # 2 Water Temperature must be double and within range -5 to 45" MinimumValue="-5"
								MaximumValue="45" Type="Double"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label10" CssClass="labelText" runat="server">pH:</asp:label></td>
						<td><asp:textbox id="txtpH_ST" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator10" runat="server" Display="None" ControlToValidate="txtpH_ST"
								ErrorMessage="Stream pH must be double and within range 0 to 14" MinimumValue="0" MaximumValue="14"
								Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtpH_GW1" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator11" runat="server" Display="None" ControlToValidate="txtpH_GW1"
								ErrorMessage="Groundwater Seep # 1 pH must be double and within range 0 to 14" MinimumValue="0"
								MaximumValue="14" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtpH_GW2" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator12" runat="server" Display="None" ControlToValidate="txtpH_GW2"
								ErrorMessage="Groundwater Seep # 2 pH must be double and within range 0 to 14" MinimumValue="0"
								MaximumValue="14" Type="Double"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label11" CssClass="labelText" runat="server">Conductivity (µSIE/cm):</asp:label></td>
						<td><asp:textbox id="txtCond_ST" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator13" runat="server" Display="None" ControlToValidate="txtCond_ST"
								ErrorMessage="Stream Conductivity must be double and within range 0 to 10 000" MinimumValue="0"
								MaximumValue="10000" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtCond_GW1" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator14" runat="server" Display="None" ControlToValidate="txtCond_GW1"
								ErrorMessage="Groundwater Seep # 1 Conductivity must be double and within range 0 to 10 000" MinimumValue="0"
								MaximumValue="10000" Type="Double"></asp:RangeValidator></td>
						<td><asp:textbox id="txtCond_GW2" runat="server"></asp:textbox>
							<asp:RangeValidator id="RangeValidator15" runat="server" Display="None" ControlToValidate="txtCond_GW2"
								ErrorMessage="Groundwater # 2 Conductivity must be double and within range 0 to 10 000" MinimumValue="0"
								MaximumValue="10000" Type="Double"></asp:RangeValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label12" CssClass="labelText" runat="server">Flow (cubic meters per second):</asp:label></td>
						<td><asp:textbox id="txtFlow_ST" runat="server"></asp:textbox></td>
						<td><asp:textbox id="txtFlow_GW1" runat="server"></asp:textbox></td>
						<td><asp:textbox id="txtFlow_GW2" runat="server"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label13" CssClass="labelText" runat="server">Field number (DELG programs):</asp:label></td>
						<td><asp:textbox id="txtField_ST" runat="server"></asp:textbox></td>
						<td><asp:textbox id="txtField_GW1" runat="server"></asp:textbox></td>
						<td><asp:textbox id="txtField_GW2" runat="server"></asp:textbox></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" CssClass="labelText"></asp:validationsummary><asp:button id="btnNext" runat="server" Text="Next" onclick="btnNext_Click"></asp:button><asp:button id="btnSave" runat="server" Text="Save" Visible="False" onclick="btnNext_Click"></asp:button><asp:button id="btnCancel" runat="server" Text="Cancel" Visible="False" CausesValidation="False" onclick="btnCancel_Click"></asp:button></form>
	</body>
</HTML>
