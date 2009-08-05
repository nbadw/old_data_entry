<%@ Page language="c#" Inherits="NBADWDataEntryApplication.TemperatureRecordingSites_Search" CodeFile="TRSSearch.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TemperatureRecordingSites-Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>
			<asp:Label id="lblH1" runat="server" Font-Bold="True" Font-Names="Times New Roman"></asp:Label></h1>
		<h2>SEARCH Sites</h2>
		<fieldset class="standardText"><legend>Instructions</legend>
			<ul>
				<li>
				Enter one or more criteria below. You may use wild characters(*); place them at 
				the beginning and/or end of an Agency Site ID, Water Body Name or Watershed 
				Code.
				<li>
					Search Results: Click on a column heading to sort the list. Click <b><u>Select</u></b>
					in the record to be returned to the site form.</li></ul>
		</fieldset>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>Search Criteria</legend>
				<table border="0">
					<tr>
						<td><asp:label id="lblSiteType" runat="server" CssClass="labelText" Width="75px">Site Type</asp:label></td>
						<td><asp:dropdownlist id=dlstSiteType tabIndex=2 runat="server" DataValueField="AquaticActivityCd" DataTextField="AquaticActivity" DataSource="<%# objdscdAquaticActivity %>"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td><asp:label id="Label8" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label></td>
						<td><asp:textbox id="txtdwsiteid" tabIndex="3" runat="server"></asp:textbox>
							<asp:RegularExpressionValidator id="txtdwsiteidValidator" runat="server" ErrorMessage="Aquatic Site ID must be numeric (integer)"
								ControlToValidate="txtdwsiteid" ValidationExpression="[\d]+" Display="None"></asp:RegularExpressionValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label1" runat="server" CssClass="labelText"> Agency:</asp:label></td>
						<td><asp:dropdownlist id=dlstAgencyCode runat="server" DataValueField="AgencyCd" DataTextField="Agency" DataSource="<%# objdsDE_Agencies %>">
							</asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="HEIGHT: 25px"><asp:label id="Label2" runat="server" CssClass="labelText">Agency Site ID:</asp:label></td>
						<td style="HEIGHT: 25px"><asp:textbox id="txtgroupsiteid" tabIndex="5" runat="server"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label3" runat="server" CssClass="labelText">Water Body ID:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyid" tabIndex="6" runat="server"></asp:textbox>
							<asp:RegularExpressionValidator id="txtwaterbodyidValidator" runat="server" ErrorMessage="Water Body ID must be numeric (integer)"
								ControlToValidate="txtwaterbodyid" ValidationExpression="[\d]+" Display="None"></asp:RegularExpressionValidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyname" tabIndex="8" runat="server" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label5" runat="server" CssClass="labelText">Watershed Code:</asp:label><br>
							<asp:label id="Label9" runat="server" CssClass="labelText">(e.g. 01-02-01-00-00-00)</asp:label></td>
						<td><asp:textbox id="txtwatershed" tabIndex="9" runat="server" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server" CssClass="labelText" Visible="False">Site Name:</asp:label></td>
						<td><asp:textbox id="txtsitename" tabIndex="10" runat="server" Width="520px" Visible="False"></asp:textbox></td>
					</tr>
				</table>
			</fieldset>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="labelText" ShowMessageBox="True"></asp:ValidationSummary>
			<br>
			<asp:button id="btnSearch2" tabIndex="1" runat="server" CssClass="buttonText" Text="Search" onclick="btnSearch2_Click"></asp:button>
			<asp:button id="btnClose" tabIndex="11" runat="server" CssClass="buttonText" Width="60px" Text="Close" onclick="btnClose_Click"></asp:button>
			<asp:label id="lblMessage" runat="server" CssClass="labelText" ForeColor="Red"></asp:label>
			<br>
			<br>
			<asp:datagrid id="dgResults" runat="server" CssClass="gridItem" Width="95%" DataSource="<%# dvSearchSites %>" AllowSorting="True" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" PageSize="5" AutoGenerateColumns="False" ShowFooter="True" DataKeyField="AquaticSiteUseID">
				<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle Wrap="False" HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
					BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="Select"></asp:EditCommandColumn>
					<asp:BoundColumn DataField="AquaticSiteID" SortExpression="AquaticSiteID" HeaderText="Aquatic&lt;br&gt;Site ID">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="AgencyCd" SortExpression="AgencyCd" HeaderText="Agency">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="AgencySiteID" SortExpression="AgencySiteID" HeaderText="Agency&lt;br&gt;Site ID">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="AquaticActivityCd" HeaderText="AquaticActivityCd ">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="AquaticActivity" SortExpression="AquaticActivity" HeaderText="Aquatic&lt;br&gt;Activity">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyID" SortExpression="WaterBodyID" HeaderText="Water Body&lt;br&gt;ID">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyName_Abrev" SortExpression="WaterBodyName_Abrev" HeaderText="Water Body&lt;br&gt;Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="DrainageCd" SortExpression="DrainageCd" HeaderText="Watershed Code">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="AquaticSiteDesc" HeaderText="Aquatic Site Description">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="AquaticSiteName" HeaderText="Aquatic&lt;br&gt;Site Name"></asp:BoundColumn>
				</Columns>
				<PagerStyle VerticalAlign="Middle" HorizontalAlign="Left" ForeColor="#000066" BackColor="White"
					Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
