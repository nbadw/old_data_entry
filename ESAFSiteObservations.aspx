<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFSiteObservations" CodeFile="ESAFSiteObservations.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFSiteObservations</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
		<script>history.forward();</script>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<h1>ENVIRONMENTAL STREAM ASSESSMENT</h1>
			<h2><asp:label id="lblh2" runat="server" Font-Bold="True" Font-Names="Times New Roman">ADD New Assessment</asp:label></h2>
			<fieldset class="standardText"><legend><asp:label id="lblStep" runat="server">Step 3 of 7 - Enter </asp:label>Site 
					Observations</legend>
				<ul>
					<li>
					Select the category of noteworthy observation or potential environmental issue 
					from list below. Wait for the page to refresh, then select an observation. You 
					may then be prompted for supplemental information.
					<li>
						Click the <b>Add</b>
					button to add the observation. It will appear in the Observation List box.
					<li>
						Click <b><u>Delete</u></b> to remove a record in the Observation List.
					</li>
				</ul>
			</fieldset>
			<br>
			<FIELDSET class="standardText"><LEGEND>Observation List</LEGEND><asp:datagrid id=dgCurrentRecords runat="server" ShowFooter="True" DataSource="<%# dvtblEnvironmentalObservations %>" AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" CssClass="enclosedgridItem" DataKeyField="EnvObservationID">
					<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
					<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn Visible="False" DataField="EnvObservationID" HeaderText="EnvObservationID"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="AquaticActivityID" HeaderText="AquaticActivityID"></asp:BoundColumn>
						<asp:BoundColumn DataField="ObservationGroup" HeaderText="Observation Group"></asp:BoundColumn>
						<asp:BoundColumn DataField="Observation" HeaderText="Observation"></asp:BoundColumn>
						<asp:BoundColumn DataField="ObservationSupp" HeaderText="Observation Supplement"></asp:BoundColumn>
						<asp:BoundColumn DataField="FishPassageObstructionInd" HeaderText="Obstruction to&lt;br&gt;Fish Passage"></asp:BoundColumn>
						<asp:BoundColumn DataField="PipeSize_cm" SortExpression="PipeSize_cm" HeaderText="PipeSize&lt;br&gt;(cm)"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></FIELDSET>
			<br>
			<fieldset class="standardText"><legend>Observation Selection</legend>
				<table border="0">
					<tr>
						<td vAlign="top"><asp:label id="Label1" runat="server" CssClass="labelText">Category*:</asp:label><br>
							<asp:dropdownlist id=dlstObservationGroup tabIndex=1 runat="server" DataSource="<%# objdscdEnvironmentalObservations_Groups %>" AutoPostBack="True" Width="336px" DataValueField="ObservationGroup" DataTextField="ObservationGroup" onselectedindexchanged="dlstObservationGroup_SelectedIndexChanged">
							</asp:dropdownlist></td>
						<td vAlign="top"><asp:label id="Label2" runat="server" CssClass="labelText">Observation*:</asp:label><br>
							<asp:dropdownlist id=dlstObservation tabIndex=2 runat="server" DataSource="<%# dvcdEnvironmentalObservations %>" AutoPostBack="True" Width="256px" DataValueField="ObservationID" DataTextField="Observation" onselectedindexchanged="dlstObservation_SelectedIndexChanged">
							</asp:dropdownlist></td>
						<td vAlign="top"><asp:label id="lblSpecify" runat="server" CssClass="labelText" Visible="False">Specify:</asp:label><asp:label id="lblPipeSize" runat="server" CssClass="labelText" Visible="False">Pipe Size (cm):</asp:label><asp:label id="lblSpecies" runat="server" CssClass="labelText" Visible="False">Name/Species:</asp:label><asp:label id="lblName" runat="server" CssClass="labelText" Visible="False">Specify Name:</asp:label><br>
							<asp:label id="lblObstruction" runat="server" CssClass="labelText" Visible="False">Obstruction to fish passage:</asp:label><asp:checkbox id="chkObstruction" tabIndex="5" runat="server" Visible="False"></asp:checkbox><asp:textbox id="txtSpecify" tabIndex="3" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtPipeSize" tabIndex="4" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtSpecies" tabIndex="6" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtName" tabIndex="7" runat="server" Visible="False"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="2"><asp:label id="Label3" runat="server" CssClass="labelText">* Indicates the form will refresh after you enter information in this field</asp:label></td>
						<td></td>
					</tr>
				</table>
			</fieldset>
            <asp:RegularExpressionValidator ID="txtPipeSizeValidator" runat="server" ControlToValidate="txtPipeSize"
                ErrorMessage="Pipe Size must be an integer!" Enabled="False" ValidationExpression="[\d]+"></asp:RegularExpressionValidator><br>
			<asp:button id="btnAdd" tabIndex="8" runat="server" CssClass="buttonText" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnNext" tabIndex="9" runat="server" CssClass="buttonText" Visible="False" Text="Next" onclick="btnNext_Click"></asp:button><asp:button id="btnReturn" tabIndex="9" runat="server" CssClass="buttonText" Visible="False"
				Text="Done" onclick="btnReturn_Click"></asp:button></FORM>
	</body>
</HTML>
