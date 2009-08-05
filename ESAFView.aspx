<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFView" CodeFile="ESAFView.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
		<script>history.forward();</script>
	</HEAD>
	<body>
		<h1>ENVIRONMENTAL STREAM ASSESSMENT</h1>
		<h2><asp:Label id="lblHeading" runat="server" Font-Names="Times New Roman" Font-Bold="True">VIEW Assessment Information</asp:Label></h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>Instructions</legend>
				<ul>
					<li>
					Use the window’s scroll bar on the right to view all of the sections of the 
					Environmental Stream Assessment
					<li>
						To edit data in a particular section, click the section’s <b>Modify</b> button.
						<P></P>
					</li>
				</ul>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Site Identification</legend>
				<table border="0">
					<tr>
						<td><asp:label id="Label2" runat="server" CssClass="labelText">Agency Site ID:</asp:label></td>
						<td><asp:textbox id="txtgroupsiteid" tabIndex="6" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					<tr>
						<td><asp:label id="Label3" runat="server" CssClass="labelText">Water Body ID:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyid" tabIndex="7" runat="server" AutoPostBack="True" BackColor="WhiteSmoke"
								Enabled="False"></asp:textbox></td>
					<tr>
						<td><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyname" tabIndex="9" runat="server" Width="520px" BackColor="WhiteSmoke"
								Enabled="False"></asp:textbox></td>
					<tr>
						<td><asp:label id="Label5" runat="server" CssClass="labelText">Watershed:</asp:label></td>
						<td><asp:textbox id="txtwatershed" tabIndex="10" runat="server" Width="520px" BackColor="WhiteSmoke"
								Enabled="False"></asp:textbox></td>
					<tr>
						<td><asp:label id="Label8" runat="server" CssClass="labelText">Watershed Code:</asp:label></td>
						<td><asp:textbox id="txtwatershedcode" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server" CssClass="labelText">Site Name:</asp:label></td>
						<td><asp:textbox id="txtsitename" tabIndex="11" runat="server" Width="520px" BackColor="WhiteSmoke"
								Enabled="False"></asp:textbox></td>
					<tr>
						<td><asp:label id="Label7" runat="server" CssClass="labelText">Site Description:</asp:label></td>
						<td><asp:textbox id="txtsitedescription" tabIndex="12" runat="server" Width="520px" BackColor="WhiteSmoke"
								Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td><b>
								<asp:label id="Label51" Font-Bold="True" runat="server" CssClass="labelText">Coordinates</asp:label></b></td>
					</tr>
					<tr>
						<td><asp:label id="Label1" runat="server" CssClass="labelText">Source:</asp:label></td>
						<td><asp:textbox id="txtSource" tabIndex="16" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label49" runat="server" CssClass="labelText">System:</asp:label></td>
						<td><asp:textbox id="txtSystem" tabIndex="16" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label50" runat="server" CssClass="labelText">Units:</asp:label></td>
						<td><asp:textbox id="txtUnits" tabIndex="16" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="lblX" runat="server" CssClass="labelText">Longitude:</asp:label></td>
						<td><asp:textbox id="txtX" tabIndex="15" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox>
							<asp:button id="btnMap" runat="server" CssClass="buttonText" Text="Map" CausesValidation="False" onclick="btnMap_Click" Visible="False"></asp:button></td>
					</tr>
					<TR>
						<td><asp:label id="lblY" runat="server" CssClass="labelText">Latitude:</asp:label></td>
						<td><asp:textbox id="txtY" tabIndex="16" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</TR>
				</table>
				<asp:button id="btnModifySiteIdentification" runat="server" CssClass="enclosedbuttonText" Text="Modify"
					Visible="False" onclick="btnModifySiteIdentification_Click"></asp:button>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Survey Info</legend>
				<table border="0">
					<tr>
						<td align="right"><asp:label id="Label9" runat="server" CssClass="labelText">Date:</asp:label></td>
						<td><asp:textbox id="txtdate" tabIndex="1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td align="right"><asp:label id="Label10" runat="server" CssClass="labelText">Organization:</asp:label></td>
						<td><asp:textbox id="txtAgency" tabIndex="2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td align="right"><asp:label id="Label11" runat="server" CssClass="labelText">Personnel:</asp:label></td>
						<td><asp:textbox id="txtpersonnel1" tabIndex="3" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
				</table>
				<asp:button id="btnModifySurveyInfo" runat="server" CssClass="enclosedbuttonText" Text="Modify"
					Visible="False" onclick="btnModifySurveyInfo_Click"></asp:button>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Site Observations</legend><asp:datagrid id=dgSiteObservations runat="server" CssClass="enclosedgridItem" AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" DataSource="<%# dvtblEnvironmentalObservations %>" ShowFooter="True">
					<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
					<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="EnvObservationID" HeaderText="EnvObservationID"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="AquaticActivityID" HeaderText="AquaticActivityID"></asp:BoundColumn>
						<asp:BoundColumn DataField="ObservationGroup" HeaderText="Observation Group"></asp:BoundColumn>
						<asp:BoundColumn DataField="Observation" HeaderText="Observation"></asp:BoundColumn>
						<asp:BoundColumn DataField="ObservationSupp" HeaderText="Other Observation"></asp:BoundColumn>
						<asp:BoundColumn DataField="FishPassageObstructionInd" HeaderText="Obstruction to&lt;br&gt;Fish Passage"></asp:BoundColumn>
						<asp:BoundColumn DataField="PipeSize_cm" SortExpression="PipeSize_cm" HeaderText="PipeSize&lt;br&gt;(cm)"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
				</asp:datagrid><br>
				<asp:button id="btnModifySiteObservations" runat="server" CssClass="enclosedbuttonText" Text="Modify"
					Visible="False" onclick="btnModifySiteObservations_Click"></asp:button>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Site Characteristics</legend>
				<table border="0">
					<tr>
						<td vAlign="top"><asp:label id="Label12" runat="server" CssClass="labelText">Stream Cover:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtStreamCover" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label13" runat="server" CssClass="labelText">Stream Bank:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtStreamBank" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label14" runat="server" CssClass="labelText"> Stream Bank Slope - Left:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtStreamBankSlopeL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label15" runat="server" CssClass="labelText"> Stream Bank Slope - Right:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtStreamBankSlopeR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label16" runat="server" CssClass="labelText">Stream Type:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtStreamType" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox>&nbsp;<asp:textbox id="txtOther1" tabIndex="6" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label17" runat="server" CssClass="labelText">Indicators of Possible Impaired Water Quality:</asp:label></td>
						<td vAlign="top">
							<table>
								<tr>
									<td vAlign="top"><asp:checkbox id="chkSuspendedSilt" tabIndex="7" runat="server" CssClass="labelText" Text="suspended silt"
											Enabled="False"></asp:checkbox></td>
									<td vAlign="top"><asp:checkbox id="chkEmbeddedSubstrate" tabIndex="8" runat="server" CssClass="labelText" Text="embedded substrate"
											Enabled="False"></asp:checkbox></td>
								<tr>
									<td vAlign="top"><asp:checkbox id="chkAquaticPlantsAbundant" tabIndex="9" runat="server" CssClass="labelText" Text="aquatic plants abundant"
											Enabled="False"></asp:checkbox></td>
									<td vAlign="top"><asp:checkbox id="chkAlgae" tabIndex="10" runat="server" CssClass="labelText" Text="algae" Enabled="False"></asp:checkbox></td>
								<tr>
									<td vAlign="top"><asp:checkbox id="chkPetroleum" tabIndex="11" runat="server" CssClass="labelText" Text="petroleum/oil"
											Enabled="False"></asp:checkbox></td>
									<td vAlign="top"><asp:checkbox id="chkOdor" tabIndex="12" runat="server" CssClass="labelText" Text="odor" Enabled="False"></asp:checkbox></td>
								<tr>
									<td style="HEIGHT: 21px" vAlign="top"><asp:checkbox id="chkFoam" tabIndex="13" runat="server" CssClass="labelText" Text="foam" Enabled="False"></asp:checkbox></td>
									<td style="HEIGHT: 21px" vAlign="top"><asp:checkbox id="chkDeadFish" tabIndex="14" runat="server" CssClass="labelText" Text="dead fish"
											Enabled="False"></asp:checkbox></td>
								<tr>
									<td vAlign="top"><asp:checkbox id="chkOther" tabIndex="15" runat="server" CssClass="labelText" Text="other" AutoPostBack="True"
											Enabled="False"></asp:checkbox>&nbsp;<asp:textbox id="txtOther2" tabIndex="16" runat="server" Enabled="False" BackColor="WhiteSmoke"
											Visible="False"></asp:textbox></td>
									<td vAlign="top"></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label18" runat="server" CssClass="labelText">Water Clarity:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtWaterClarity" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label19" runat="server" CssClass="labelText">Water Colour:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtWaterColour" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label20" runat="server" CssClass="labelText">Weather in Past 48 hours:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtWeatherinPast48hours" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label21" runat="server" CssClass="labelText">Weather Currently:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtWeatherCurrently" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
				</table>
				<asp:button id="btnModifySiteCharacteristics" runat="server" CssClass="enclosedbuttonText" Text="Modify"
					Visible="False" onclick="btnModifySiteCharacteristics_Click"></asp:button>
				<asp:Button id="btnResume" runat="server" Text="Resume" CssClass="enclosedbuttonText" Visible="False" onclick="btnResume_Click"></asp:Button>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Upstream Vegetation</legend>
				<table border="0">
					<tr>
						<td><asp:label id="Label22" runat="server" CssClass="labelText">Riparian Zone (30m)</asp:label></td>
						<td><asp:label id="Label23" runat="server" CssClass="labelText">Left Bank (%)</asp:label></td>
						<td><asp:label id="Label24" runat="server" CssClass="labelText">Right Bank (%)</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label25" runat="server" CssClass="labelText">Lawn:</asp:label></td>
						<td><asp:textbox id="txtLawnL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtLawnR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label26" runat="server" CssClass="labelText">Row crop:</asp:label></td>
						<td><asp:textbox id="txtRowCropL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtRowCropR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label27" runat="server" CssClass="labelText">Forage/cover crop:</asp:label></td>
						<td><asp:textbox id="txtForageL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtForageR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label28" runat="server" CssClass="labelText">Shrubs:</asp:label></td>
						<td><asp:textbox id="txtShrubsL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtShrubsR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label29" runat="server" CssClass="labelText">Hardwood forest:</asp:label></td>
						<td><asp:textbox id="txtHardwoodL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtHardwoodR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label30" runat="server" CssClass="labelText">Softwood forest:</asp:label></td>
						<td><asp:textbox id="txtSoftwoodL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtSoftwoodR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label31" runat="server" CssClass="labelText">Mixed forest:</asp:label></td>
						<td><asp:textbox id="txtMixedL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtMixedR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label32" runat="server" CssClass="labelText">Meadow/Tall grasses:</asp:label></td>
						<td><asp:textbox id="txtMeadowL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtMeadowR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label33" runat="server" CssClass="labelText">Wetland:</asp:label></td>
						<td><asp:textbox id="txtWetlandL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtWetlandR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label34" runat="server" CssClass="labelText">Altered:</asp:label></td>
						<td><asp:textbox id="txtAlteredL" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtAlteredR" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
				</table>
				<asp:button id="btnModifyUpstreamVegetation" runat="server" CssClass="enclosedbuttonText" Text="Modify"
					Visible="False" onclick="btnModifyUpstreamVegetation_Click"></asp:button>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Field Measurements</legend>
				<table border="0">
					<tr>
						<td><asp:label id="Label35" runat="server" CssClass="labelText">Section Length (m):</asp:label></td>
						<td><asp:textbox id="txtSectionLength" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label36" runat="server" CssClass="labelText">Average Wet Stream Width (m):</asp:label></td>
						<td><asp:textbox id="txtAverageWetStreamWidth" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label37" runat="server" CssClass="labelText">Average Stream Depth (m):</asp:label></td>
						<td><asp:textbox id="txtAverageStreamDepth" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label38" runat="server" CssClass="labelText">Stream Velocity (m/s):</asp:label></td>
						<td><asp:textbox id="txtStreamVelocity" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
				</table>
				<br>
				<table border="0">
					<tr>
						<td><asp:label id="Parameter" runat="server" CssClass="labelText">Parameter</asp:label></td>
						<td><asp:label id="Stream" runat="server" CssClass="labelText">Stream</asp:label></td>
						<td><asp:label id="Label39" runat="server" CssClass="labelText">Groundwater Source # 1</asp:label></td>
						<td><asp:label id="Label40" runat="server" CssClass="labelText">Groundwater Source # 2</asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label41" runat="server" CssClass="labelText">Time of Day (24:00 format):</asp:label></td>
						<td><asp:textbox id="txtTod_ST" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtTod_GW1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtTod_GW2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label42" runat="server" CssClass="labelText">Dissolved Oxygen (ppm):</asp:label></td>
						<td><asp:textbox id="txtDo_ST" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtDo_GW1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtDo_GW2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label43" runat="server" CssClass="labelText">Air Temperature (°C):</asp:label></td>
						<td><asp:textbox id="txtAt_ST" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtAt_GW1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtAt_GW2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label44" runat="server" CssClass="labelText">Water Temperature (°C):</asp:label></td>
						<td><asp:textbox id="txtWt_ST" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtWt_GW1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtWt_GW2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label45" runat="server" CssClass="labelText">pH:</asp:label></td>
						<td><asp:textbox id="txtpH_ST" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtpH_GW1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtpH_GW2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label46" runat="server" CssClass="labelText">Conductivity (µSIE/cm):</asp:label></td>
						<td><asp:textbox id="txtCond_ST" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtCond_GW1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtCond_GW2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label47" runat="server" CssClass="labelText">Flow (cubic meters per second):</asp:label></td>
						<td><asp:textbox id="txtFlow_ST" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtFlow_GW1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtFlow_GW2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label48" runat="server" CssClass="labelText">Field number (DELG programs):</asp:label></td>
						<td><asp:textbox id="txtField_ST" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtField_GW1" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td><asp:textbox id="txtField_GW2" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
				</table>
				<asp:button id="btnModifyFieldMeasurements" runat="server" Text="Modify" CssClass="enclosedbuttonText"
					Visible="False" onclick="btnModifyFieldMeasurements_Click"></asp:button>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Planning</legend><asp:datagrid id=dgPlanning runat="server" CssClass="enclosedgridItem" DataSource="<%# dvtblEnvironmentalPlanning %>" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" AutoGenerateColumns="False" ShowFooter="True">
					<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
					<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="IssueCategory" HeaderText="Issue Category"></asp:BoundColumn>
						<asp:BoundColumn DataField="Issue" HeaderText="Issue"></asp:BoundColumn>
						<asp:BoundColumn DataField="ActionRequired" HeaderText="Action&lt;br&gt;Required"></asp:BoundColumn>
						<asp:BoundColumn DataField="ActionTargetDate" HeaderText="Action&lt;br&gt;Target Date" DataFormatString="{0:yyyy/MM/dd}"></asp:BoundColumn>
						<asp:BoundColumn DataField="ActionPriority" HeaderText="Action&lt;br&gt;Priority"></asp:BoundColumn>
						<asp:BoundColumn DataField="ActionCompletionDate" HeaderText="Action&lt;br&gt;Completion Date" DataFormatString="{0:yyyy/MM/dd}"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="AquaticActivityID" HeaderText="AquaticActivityID"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="EnvPlanningID" HeaderText="EnvPlanningID"></asp:BoundColumn>
						<asp:BoundColumn DataField="FollowUpRequired" HeaderText="Follow Up&lt;br&gt;Required"></asp:BoundColumn>
						<asp:BoundColumn DataField="FollowUpTargetDate" HeaderText="Follow Up&lt;br&gt;TargetDate" DataFormatString="{0:yyyy/MM/dd}"></asp:BoundColumn>
						<asp:BoundColumn DataField="FollowUpCompletionDate" HeaderText="Follow Up&lt;br&gt;Completion Date"
							DataFormatString="{0:yyyy/MM/dd}"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
				</asp:datagrid><br>
				<asp:button id="btnModifyPlanning" runat="server" Text="Modify" CssClass="enclosedbuttonText"
					Visible="False" onclick="btnModifyPlanning_Click"></asp:button>
			</fieldset>
			<br>
			<asp:button id="btnDone" runat="server" Text="Return to Site List" CssClass="buttonText" onclick="btnDone_Click"></asp:button>
			<asp:button id="btnDelete" runat="server" Text="Delete" CssClass="buttonText" Visible="False"
				ToolTip="Permanently Delete Current Assessment" onclick="btnDelete_Click"></asp:button>
		</form>
	</body>
</HTML>
