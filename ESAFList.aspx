<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFList" CodeFile="ESAFList.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>ENVIRONMENTAL STREAM ASSESSMENT</h1>
		<h2>SITE LIST</h2>
		<fieldset class="standardText"><legend>Instructions</legend>
			<ul>
				<li>
				Listed below are the sites identified as noteworthy or potential environmental 
				issue. The list is limited to your organization's watershed or area of 
				interest. Sort the table by clicking on a column heading.
				<li>
					You may view (or edit if you have permission) the details of a particular site 
					by pressing <b><u>View</u></b>
				in the row containing the site of interest.
				<li>
					Press the <b>Search</b>
				button to search for a particular site.
				<li>
					Data Entry Users: Press the <b>Add New&nbsp;Assessment</b> to add a new 
					assessment.
				</li>
			</ul>
		</fieldset>
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td><asp:button id="btnAdd" runat="server" Text="Add New Assessment" CssClass="buttonText" Visible="False" onclick="btnAdd_Click"></asp:button><asp:button id="btnSearch" runat="server" Text="Search Sites" CssClass="buttonText" onclick="btnSearch_Click"></asp:button>
						<asp:button id="btnDownload" tabIndex="6" runat="server" CssClass="buttonText" Text="Search/Download Data" onclick="btnDownload_Click"></asp:button></td>
					<td align="left"><asp:button id="btnReturn" runat="server" Text="Return to Main Menu" CssClass="buttonText" onclick="btnReturn_Click"></asp:button></td>
				</tr>
			</table>
			<br>
			<asp:datagrid id=dgSiteList runat="server" CssClass="gridItem" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" DataSource="<%# dvDE_ESAFSiteList %>" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True" DataKeyField="AquaticActivityID">
				<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
					BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="View"></asp:EditCommandColumn>
					<asp:BoundColumn Visible="False" DataField="AquaticActivityID" HeaderText="AquaticActivityID"></asp:BoundColumn>
					<asp:BoundColumn DataField="AgencyCd" SortExpression="AgencyCd" HeaderText="Agency">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="AgencySiteID" HeaderText="Agency&lt;br&gt;Site ID">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyID" SortExpression="WaterBodyID" HeaderText="Water Body&lt;br&gt;ID">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyName" SortExpression="WaterBodyName" HeaderText="Water Body&lt;br&gt;Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="DrainageCd" SortExpression="DrainageCd" HeaderText="Watershed Code"></asp:BoundColumn>
					<asp:BoundColumn DataField="AquaticActivityStartDate" SortExpression="AquaticActivityStartDate" HeaderText="Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="ObservationCategory" SortExpression="ObservationCategory" HeaderText="Site Type"></asp:BoundColumn>
					<asp:BoundColumn DataField="NumActions" HeaderText="No.&lt;br&gt;Action Items">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NumCompleted" HeaderText="No.&lt;br&gt;Completed">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NumFollowUp" SortExpression="NumFollowUp" HeaderText="No.&lt;br&gt;Follow Up"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
