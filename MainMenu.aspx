<%@ Page language="c#" Inherits="NBADWDataEntryApplication.MainMenu" CodeFile="MainMenu.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainMenu</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>NB AQUATIC DATA WAREHOUSE</h1>
		<h2>Main Menu</h2>
		<form id="Form1" method="post" runat="server">
			<table border="0">
				<tr>
					<td valign="top">
						<fieldset class="standardText">
							<legend>
								Angling Regulations</legend><span style="COLOR: silver">Angling Leases<br>
								Crown Reserves<br>
								Regulated Waters </span></SPAN></fieldset>
					</td>
					<td valign="top">
						<fieldset class="standardText">
							<legend>
								Protected Areas</legend><span style="COLOR: silver"> Designated Drinking Water 
								Supply Watersheds<br>
								Designated Drinking Water Supply Well Fields<br>
								Protected Natural Areas </span>
						</fieldset>
					</td>
				</tr>
				<tr>
					<td valign="top">
						<fieldset class="standardText">
							<legend>
								Fish Management</legend><span style="COLOR: silver"> Broodstock Collection<br>
								<asp:LinkButton id="lnkElectrofishing" runat="server" onclick="lnkElectrofishing_Click">Electrofishing</asp:LinkButton><br>
								Fish Run Counts<br>
								<asp:LinkButton id="lnkFishStocking" runat="server" onclick="lnkFishStocking_Click">Fish Stocking</asp:LinkButton><br>
								Fish Translocations<br>
								Individual Fish Measurements<br>
								Redd Survey </span>
						</fieldset>
					</td>
					<td valign="top">
						<fieldset class="standardText"><legend>Water Monitoring</legend><span style="COLOR: silver">
								Bacterial Analysis<br>
								Groundwater Level Monitoring<br>
								Hydrometric Stations<br>
								MacroInvertebrates<br>
								Sedimentation (Vibert Box)<br>
								Water Chemistry<br>
								<asp:LinkButton id="lnkWaterTemperature" runat="server" onclick="lnkWaterTemperature_Click">Water Temperature</asp:LinkButton>
							</span>
						</fieldset>
					</td>
				</tr>
				<tr>
					<td valign="top">
						<fieldset class="standardText"><legend>Habitat Restoration
							</legend>
							<span style="COLOR: silver">Habitat Restoration<br>
								<br>
							</span>
						</fieldset>
					</td>
					<td valign="top">
						<fieldset class="standardText"><legend>Recreational Fishing</legend><span style="COLOR: silver">
								Angling License Sales<br>
								Angler Catch &amp; Effort </span>
						</fieldset>
					</td>
				</tr>
				<tr>
					<td valign="top">
						<fieldset class="standardText"><legend>Lake &amp; Stream Surveys</legend><span style="COLOR: silver">
								<asp:LinkButton id="lnkEnvironmentalStreamAssessment" runat="server" onclick="lnkEnvironmentalStreamAssessment_Click">Environmental Stream Assessment</asp:LinkButton><br>
								Habitat Stream Survey<br>
								Lake Survey<br>
								Reconnaissance Stream Survey<br>
							</span>
						</fieldset>
					</td>
					<td valign="top">
						<fieldset class="standardText"><legend>Watersheds</legend><span style="COLOR: silver"> Lakes 
								and Streams<br>
								Major Drainage Basins<br>
								Watershed Units
								<br>
								<br>
							</span>
						</fieldset>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
