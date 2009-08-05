<%@ Page language="c#" Inherits="NBADWDataEntryApplication.TemperatureRecordingSites" CodeFile="TRSList.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TemperatureRecordingSites-List</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1 align="left">
			<asp:Label id="lblHeading1" runat="server" Font-Bold="True" Font-Names="Times New Roman">TEMPERATURE DATA SITES</asp:Label></h1>
		<h2>SITE LIST</h2>
		<fieldset class="standardText"><legend>Instructions</legend>
			<ul>
				<li>
					Listed below are the sites where
					<asp:Label id="lblType1" runat="server">temperature</asp:Label>
				data has been collected. The list is limited to your organization's watershed 
				or area of interest. Sort the table by clicking on a column heading.
				<li>
					You may view (or edit if you have permission) the details of a particular site 
					by pressing <b><u>View</u></b>
				in the row containing the site of interest.
				<li>
					Data Entry Users: Press <b>Add New Site</b>
				to add a new site.
				<li>
					To view, add or edit
					<asp:Label id="lblType2" runat="server">temperature logger</asp:Label>
					details, first go to the site details by:
					<ul>
						<li>
							pressing <b><u>View</u></b>
						in the row containing the site of interest
						<li>
						searching, then selecting a site OR
						<li>
							adding a new site
						</li>
					</ul>
				<li>
					Sort the table by clicking on an <u>underlined</u>
				column heading.
				<li>
					Click on the Data Download button to search&nbsp;and download data as Excel 
					spreadsheets.
				</li>
			</ul>
		</fieldset>
		<form id="Form1" method="post" runat="server">
			<asp:button id="btnAdd" tabIndex="2" runat="server" CssClass="buttonText" Text="Add New Site"
				Visible="False" onclick="btnAdd_Click"></asp:button>&nbsp;
			<asp:button id="btnSearch" tabIndex="6" runat="server" CssClass="buttonText" Text="Search Sites" onclick="btnSearch_Click"></asp:button>&nbsp;
			<asp:button id="btnDownload" tabIndex="6" runat="server" Text="Search/Download Data" CssClass="buttonText" onclick="btnDownload_Click"></asp:button>&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:button id="btnReturn" runat="server" Text="Return to Main Menu" CssClass="buttonText" onclick="btnReturn_Click"></asp:button>
			<br>
			<br>
			<asp:datagrid id=masterDataGrid runat="server" CssClass="gridItem" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" ShowFooter="True" DataSource="<%# dvSortedSites %>" AutoGenerateColumns="False" AllowSorting="True" DataKeyField="AquaticSiteUseID">
				<FooterStyle Font-Bold="True" ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="10px" ForeColor="Black" VerticalAlign="Bottom"
					BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="View"></asp:EditCommandColumn>
					<asp:BoundColumn DataField="AquaticSiteID" SortExpression="AquaticSiteID" HeaderText="Aquatic&lt;br&gt;Site ID">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="AgencyCd" SortExpression="AgencyCd" HeaderText="Agency"></asp:BoundColumn>
					<asp:BoundColumn DataField="AgencySiteID" SortExpression="AgencySiteID" HeaderText="Agency&lt;br&gt;Site ID">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyID" SortExpression="WaterBodyID" HeaderText="Water Body&lt;br&gt;ID">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyName_Abrev" SortExpression="WaterBodyName_Abrev" HeaderText="Water Body Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="DrainageCd" SortExpression="DrainageCd" HeaderText="Watershed Code">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="AquaticSiteDesc" SortExpression="AquaticSiteDesc" HeaderText="Aquatic Site Description">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="AquaticSiteUseID" HeaderText="AquaticSiteUseID"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="" PrevPageText="" HorizontalAlign="Left" ForeColor="#000066" BackColor="White"
					PageButtonCount="15" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><BR>
			<br>
			<br>
		</form>
	</body>
</HTML>
