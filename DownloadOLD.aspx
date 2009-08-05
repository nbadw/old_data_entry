<%@ Page language="c#" Inherits="NBADWDataEntryApplication.Download" CodeFile="DownloadOLD.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Download</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<h1><asp:label id="lblh1" runat="server" Font-Bold="True" Font-Names="Times New Roman"></asp:label></h1>
			<h2><asp:label id="lblh2" runat="server" Font-Bold="True" Font-Names="Times New Roman">DOWNLOAD Data</asp:label></h2>
			<fieldset class="standardText"><legend>Instructions</legend>
				<ul>
					<li>
					Enter one or more search criteria below.
					<li>
					You may search for a single year of data (e.g. 2005) or a range of years (e.g. 
					1998-2005).
					<li>
					You may use wild characters (*); place them at the beginning and/or end of an 
					Agency Site ID, Water Body Name, or Watershed Code.
					<li>
						Click <b>Search</b>
					when done entering criteria. If data is found matching your criteria, the 
					results will be presented in one or more tables below.
					<li>
						The results generally include tables for site information, method details and 
						the field data.
						<ul>
							<li>
							Click the Download button below a table to download the information.
							<li>
							When prompted to Open or Save the file; click the Save button.
							<li>
							Navigate to the folder where you wish to save the data file.
							<li>
							Change the download file name from Download.xls to a meaningful name. Make sure 
							to keep the “.xls” extension.
							<li>
								Then click Save to complete the download.
							</li>
						</ul>
					</li>
				</ul>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Search Criteria</legend>
				<table border="0">
					<tr>
						<td><asp:label id="Label1" runat="server" CssClass="labelText">Year:</asp:label><br>
							<asp:label id="Label8" runat="server" CssClass="labelText">(e.g. 1995-1997)</asp:label></td>
						<td><asp:textbox id="txtyear" runat="server" Width="100%"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label2" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label></td>
						<td><asp:textbox id="txtdwsiteid" runat="server" Width="100%"></asp:textbox><asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="txtdwsiteid" Type="Integer"
								Operator="DataTypeCheck" Display="None" ErrorMessage="Aquatic Site ID must be numeric (integer)"></asp:comparevalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label3" runat="server" CssClass="labelText">Agency:</asp:label></td>
						<td><asp:dropdownlist id=dlstAgencyCode runat="server" DataSource="<%# objdscdAgency %>" DataTextField="Agency" DataValueField="AgencyCd"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" runat="server" CssClass="labelText">Agency Site ID:</asp:label></td>
						<td><asp:textbox id="txtgroupsiteid" runat="server" Width="100%"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label5" runat="server" CssClass="labelText">Water Body ID:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyid" runat="server" Width="100%"></asp:textbox><asp:comparevalidator id="CompareValidator2" runat="server" ControlToValidate="txtwaterbodyid" Type="Integer"
								Operator="DataTypeCheck" Display="None" ErrorMessage="Water Body ID must be numeric (integer)"></asp:comparevalidator></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server" CssClass="labelText">Water Body Name:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyname" runat="server" Width="100%"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label7" runat="server" CssClass="labelText">Watershed Code:</asp:label><br>
							<asp:label id="Label9" runat="server" CssClass="labelText">(e.g. 01-02-01-00-00-00)</asp:label></td>
						<td><asp:textbox id="txtwatershed" runat="server" Width="100%"></asp:textbox></td>
					</tr>
				</table>
			</fieldset>
			<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="labelText" ShowMessageBox="True"></asp:validationsummary><br>
			<asp:button id="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click"></asp:button>&nbsp;<asp:button id="btnReturn" runat="server" Text="Return to Site List" onclick="btnReturn_Click"></asp:button>
			<br>
			<asp:panel id="pnldg1" runat="server" Visible="False" Wrap="False">
				<H1>
					<asp:label id="lbldg1Heading" runat="server" Font-Names="Times New Roman" Font-Bold="True"></asp:label></H1>
				<asp:datagrid id="dg1" runat="server" CssClass="gridItem" ShowFooter="True" BorderColor="#CCCCCC"
					BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
					<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
				</asp:datagrid>
				<asp:button id="btndg1Download" runat="server" Text="Download" onclick="btndg1Download_Click"></asp:button>
			</asp:panel><asp:panel id="pnldg2" runat="server" Visible="False">
				<H1>
					<asp:label id="lbldg2Heading" runat="server" Font-Names="Times New Roman" Font-Bold="True"></asp:label></H1>
				<asp:datagrid id="dg2" runat="server" CssClass="gridItem" ShowFooter="True" BorderColor="#CCCCCC"
					BorderWidth="1px" AutoGenerateColumns="False">
					<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
				</asp:datagrid>
				<asp:Button id="btndg2Download" runat="server" Text="Download" onclick="btndg2Download_Click"></asp:Button>
			</asp:panel><asp:panel id="pnldg3" runat="server" Visible="False">
				<H1>
					<asp:label id="lbldg3Heading" runat="server" Font-Names="Times New Roman" Font-Bold="True"></asp:label></H1>
				<asp:datagrid id="dg3" runat="server" CssClass="gridItem" ShowFooter="True" BorderColor="#CCCCCC"
					BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
					<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
				</asp:datagrid>
				<asp:Button id="btndg3Download" runat="server" Text="Download" onclick="btndg3Download_Click"></asp:Button>
			</asp:panel><asp:panel id="pnldg4" runat="server" Visible="False">
				<H1>
					<asp:label id="lbldg4Heading" runat="server" Font-Names="Times New Roman" Font-Bold="True"></asp:label></H1>
				<asp:datagrid id="dg4" runat="server" CssClass="gridItem" ShowFooter="True" BorderColor="#CCCCCC"
					BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
					<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
				</asp:datagrid>
				<asp:Button id="btndg4Download" runat="server" Text="Download" onclick="btndg4Download_Click"></asp:Button>
			</asp:panel><asp:panel id="pnldg5" runat="server" Visible="False">
				<H1>
					<asp:label id="lbldg5Heading" runat="server" Font-Names="Times New Roman" Font-Bold="True"></asp:label></H1>
				<asp:datagrid id="dg5" runat="server" CssClass="gridItem" ShowFooter="True" BorderColor="#CCCCCC"
					BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
					<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
				</asp:datagrid>
				<asp:Button id="btndg5Download" runat="server" Text="Download" onclick="btndg5Download_Click"></asp:Button>
			</asp:panel><asp:panel id="pnldg6" runat="server" Visible="False">
				<H1>
					<asp:label id="lbldg6Heading" runat="server" Font-Names="Times New Roman" Font-Bold="True"></asp:label></H1>
				<asp:datagrid id="dg6" runat="server" CssClass="gridItem" ShowFooter="True" BorderColor="#CCCCCC"
					BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
					<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
				</asp:datagrid>
				<asp:Button id="btndg6Download" runat="server" Text="Download"></asp:Button>
			</asp:panel></form>
	</body>
</HTML>
