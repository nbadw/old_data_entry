<%@ Page language="c#" Inherits="NBADWDataEntryApplication.STKList" CodeFile="STKList.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>STKList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>
			FISH STOCKINGS</h1>
		<h2>STOCKING LIST</h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>Instructions</legend>
				<ul>
					<li>
					Listed below are the stockings that have occured at this site.
					<li>
						You may view (or edit if you have permission) the details of a particular 
						stocking by pressing <b><u>View</u></b>
					in the row containing the stocking of interest.
					<li>
						Data Entry Users: Press <b>Add New Stocking</b> to add a new stocking to this 
						site.</li></ul>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Site Info</legend>
				<table width="100%" border="0">
					<tr>
						<td vAlign="top"><asp:label id="Label1" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label><br>
							<asp:textbox id="txtdwsiteid" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td vAlign="top"><asp:label id="Label6" runat="server" CssClass="labelText">Site Name:</asp:label><br>
							<asp:textbox id="txtsitename" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"></td>
						<td vAlign="top"><asp:label id="Label7" runat="server" CssClass="labelText">Site Description:</asp:label><br>
							<asp:textbox id="txtsitedescription" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label9" runat="server" CssClass="labelText">Agency Code:</asp:label><br>
							<asp:textbox id="txtagencycd" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<td vAlign="top"><asp:label id="Label2" runat="server" CssClass="labelText">Agency Site ID:</asp:label><br>
							<asp:textbox id="txtgroupsiteid" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
					</tr>
					<TR>
						<TD vAlign="top"><asp:label id="Label3" runat="server" CssClass="labelText">Water Body ID:</asp:label><br>
							<asp:textbox id="txtwaterbodyid" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></TD>
						<td vAlign="top"><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label><br>
							<asp:textbox id="txtwaterbodyname" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox><br>
						</td>
					</TR>
					<tr>
						<td vAlign="top"><asp:label id="Label8" runat="server" CssClass="labelText">Watershed Code:</asp:label><br>
							<asp:textbox id="txtwatershedcode" runat="server" BackColor="WhiteSmoke" Enabled="False"></asp:textbox></td>
						<TD vAlign="top"><asp:label id="Label5" runat="server" CssClass="labelText">Watershed:</asp:label><br>
							<asp:textbox id="txtwatershed" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox><br>
						</TD>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:button id="btnAdd" runat="server" ToolTip="Adds a new logger to current site" Text="Add New Stocking"
				Visible="False" onclick="btnAdd_Click"></asp:button><asp:button id="btnReturn" runat="server" CssClass="buttonText" Text="Return to Site List" onclick="btnReturn_Click"></asp:button><br>
			<br>
			<fieldset class="standardText"><legend>Stocking Activities</legend><asp:datagrid id=dgActivities runat="server" CssClass="enclosedgridItem" BackColor="White" DataSource="<%# dvDE_StockedFish %>" DataKeyField="FishStockingID" CellPadding="3" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" AutoGenerateColumns="False" ShowFooter="True" AllowSorting="True">
					<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
					<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
					<Columns>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="View"></asp:EditCommandColumn>
						<asp:BoundColumn DataField="AquaticActivityStartDate" SortExpression="AquaticActivityStartDate" HeaderText="Stocking &lt;br&gt;Date"></asp:BoundColumn>
						<asp:BoundColumn DataField="AgencyCd" SortExpression="AgencyCd" HeaderText="Agency"></asp:BoundColumn>
						<asp:BoundColumn DataField="FishSpecies" SortExpression="FishSpecies" HeaderText="Fish Species"></asp:BoundColumn>
						<asp:BoundColumn DataField="FishAgeClass" HeaderText="Age&lt;br&gt;Class"></asp:BoundColumn>
						<asp:BoundColumn DataField="NoFish" HeaderText="No. of&lt;br&gt;Fish"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Satellite&lt;br&gt;Reared">
							<ItemTemplate>
								<%# ChangeValue(DataBinder.Eval(Container.DataItem,"SatelliteRearedInd")) %>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></fieldset>
		</form>
	</body>
</HTML>
