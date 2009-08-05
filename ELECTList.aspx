<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ElectList" CodeFile="ELECTList.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ElectList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>ELECTROFISHING</h1>
		<h2>ELECTROFISHING LIST</h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>Instructions</legend>
				<ul>
					<li>
					Listed below are the electrofishings that have occured at this site.
					<li>
						You may view (or edit if you have permission) the details of a particular 
						electrofishing by pressing <b><u>View</u></b>
					in the row of interest.
					<li>
						Data Entry Users: Press <b>Add Electrofishing Data</b> to add electrofishing 
						data to this site.</li></ul>
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
			<asp:button id="btnAdd" runat="server" Visible="False" Text="Add Electrofishing Data" ToolTip="Adds a new logger to current site" onclick="btnAdd_Click"></asp:button><asp:button id="btnReturn" runat="server" CssClass="buttonText" Text="Return to Site List" onclick="btnReturn_Click"></asp:button><br>
			<br>
			<asp:datagrid id="dgActivities" runat="server" CssClass="gridItem" AutoGenerateColumns="False" DataSource="<%# dvDE_ELECTList %>" DataKeyField="AquaticActivityID" ShowFooter="True" AllowSorting="True">
				<FooterStyle BackColor="LightSteelBlue"></FooterStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
					BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="View"></asp:EditCommandColumn>
					<asp:BoundColumn DataField="AquaticActivityStartDate" SortExpression="AquaticActivityStartDate" HeaderText="Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="AgencyCd" SortExpression="AgencyCd" HeaderText="Agency"></asp:BoundColumn>
					<asp:BoundColumn DataField="AquaticMethod" HeaderText="Method"></asp:BoundColumn>
					<asp:BoundColumn DataField="NoSweeps" HeaderText="No.&lt;br&gt;Sweeps"></asp:BoundColumn>
					<asp:BoundColumn DataField="FishSpecies" SortExpression="FishSpecies" HeaderText="Species"></asp:BoundColumn>
					<asp:BoundColumn DataField="FishAgeClass" HeaderText="Age Class"></asp:BoundColumn>
					<asp:BoundColumn DataField="Density" HeaderText="Density" DataFormatString="{0:N2}"></asp:BoundColumn>
					<asp:BoundColumn DataField="Biomass" HeaderText="Biomass" DataFormatString="{0:N2}"></asp:BoundColumn>
					<asp:BoundColumn DataField="PHS" HeaderText="PHS" DataFormatString="{0:N2}"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
		</form>
	</body>
</HTML>
