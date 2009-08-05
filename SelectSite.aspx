<%@ Page language="c#" Inherits="NBADWDataEntryApplication.SelectSite" CodeFile="SelectSite.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SelectSite</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<h1>
				<asp:Label id="lblH1" runat="server" Font-Bold="True" Font-Names="Times New Roman"></asp:Label></h1>
			<h2>
				<asp:Label id="lblH2" Font-Names="Times New Roman" Font-Bold="True" runat="server"></asp:Label>
			</h2>
			<asp:Panel id="pnlAddSiteInstructions" runat="server">
				<FIELDSET class="standardText"><LEGEND>Select an Existing Site</LEGEND>
					<UL>
						<LI>
						You have selected the option to set up an existing site with a new type of 
						data.
						<LI>
							Click on <B><U>Select</U></B> in the appropriate row below to select the site.
						</LI>
					</UL>
				</FIELDSET>
			</asp:Panel>
			<asp:Panel id="pnlChangeSiteInstructions" runat="server">
				<FIELDSET class="standardText"><LEGEND>Instructions</LEGEND>
					<UL>
						<LI>
							Listed below are the <asp:Label id="lblType1" runat="server"></asp:Label> sites set up by your 
							organization. If you do not see the site you wish to switch the data to, click 
							Cancel and return to the <asp:Label id="lblType2" runat="server"></asp:Label> Site List page and 
						click Add a New Site.
						<LI>
							Click on <B><U>Select</U></B>
						in the appropriate row below to select the site.
						<LI>
							Remember to click <B>Save</B> when you return to EDIT page to save the data to 
							the new site.
						</LI>
					</UL>
				</FIELDSET>
			</asp:Panel>
			<br>
			<table border="0">
				<tr>
					<td><asp:button id="btnSearch" runat="server" CssClass="buttonText" Text="Search" Visible="False" onclick="btnSearch_Click"></asp:button></td>
					<td><asp:button id="btnCancel" runat="server" CssClass="buttonText" Text="Cancel" onclick="btnCancel_Click"></asp:button></td>
				</tr>
			</table>
			<br>
			<asp:datagrid id=dgAquaticSite runat="server" CssClass="gridItem" AllowSorting="True" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" AutoGenerateColumns="False" DataSource="<%# dvDE_SitesGeneric %>" ShowFooter="True" >
				<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
					BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="Select"></asp:EditCommandColumn>
					<asp:BoundColumn DataField="AquaticSiteID" SortExpression="AquaticSiteID" HeaderText="Aquatic&lt;br&gt;Site ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="AgencyCd" SortExpression="AgencyCd" HeaderText="Agency"></asp:BoundColumn>
					<asp:BoundColumn DataField="AgencySiteID" SortExpression="AgencySiteID" HeaderText="Agency&lt;br&gt;Site ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="AquaticActivity" SortExpression="AquaticActivity" HeaderText="Aquatic Activity"></asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyID" SortExpression="WaterBodyID" HeaderText="Water Body&lt;br&gt;ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyName_Abrev" SortExpression="WaterBodyName_Abrev" HeaderText="Water Body&lt;br&gt;Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="DrainageCd" SortExpression="DrainageCd" HeaderText="Watershed Code">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="AquaticSiteDesc" SortExpression="AquaticSiteDesc" HeaderText="Aquatic Site Description">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
