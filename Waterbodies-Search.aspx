<%@ Page language="c#" Inherits="NBADWDataEntryApplication.Waterbodies_Search2" CodeFile="Waterbodies-Search.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Waterbodies-Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>NEW BRUNSWICK LAKES &amp; STREAMS</h1>
		<h2>SEARCH</h2>
		<fieldset class="standardText"><legend>Instructions</legend>
			<ul>
				<li>
				Enter one or more criteria below. You may use wild characters(*); place them at 
				the beginning and/or end of a water body name or watershed code. If you use the 
				watershed level criteria, wait for the screen to refresh after each entry.
				<li>
					<b>Search Results</b>: Click on a column heading to sort the list. Click <b><u>Select</u></b>
					in the record to be returned to the site form.</li></ul>
		</fieldset>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>Search Criteria</legend>
				<table>
					<tr>
						<td colSpan="2">
							<asp:Label id="Label8" runat="server" CssClass="labelText">* Indicates the form will refresh after you enter information in this field</asp:Label></td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server" CssClass="labelText">Water Body ID:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyid" tabIndex="3" runat="server"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label></td>
						<td><asp:textbox id="txtwaterbodyname" tabIndex="7" runat="server" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label1" runat="server" CssClass="labelText">Watershed Level 1*:</asp:label></td>
						<td><asp:dropdownlist id=dlstDrain1 runat="server" Width="520px" AutoPostBack="True" DataSource="<%# dvDrain1 %>" DataTextField="Level1Name" DataValueField="Level1No" onselectedindexchanged="dlstDrain1_SelectedIndexChanged"></asp:dropdownlist><br>
						</td>
					</tr>
					<tr>
						<td><asp:label id="Label2" runat="server" CssClass="labelText">Watershed Level 2*:</asp:label></td>
						<td><asp:dropdownlist id=dlstDrain2 runat="server" Width="520px" AutoPostBack="True" DataSource="<%# dvDrain2 %>" DataTextField="Level2Name" DataValueField="Level2No" onselectedindexchanged="dlstDrain2_SelectedIndexChanged"></asp:dropdownlist><br>
						</td>
					</tr>
					<tr>
						<td><asp:label id="Label3" runat="server" CssClass="labelText">Watershed Level 3:</asp:label></td>
						<td><asp:dropdownlist id=dlstDrain3 runat="server" Width="520px" DataSource="<%# dvDrain3 %>" DataTextField="Level3Name" DataValueField="Level3No"></asp:dropdownlist><br>
						</td>
					</tr>
					<tr>
						<td style="HEIGHT: 45px"><asp:label id="Label5" runat="server" CssClass="labelText">Watershed Code:</asp:label><br>
							<asp:label id="Label7" runat="server" CssClass="labelText">(e.g. 01-02-01-00-00-00)</asp:label></td>
						<td style="HEIGHT: 45px"><asp:textbox id="txtwatershedcode" tabIndex="8" runat="server" Width="520px"></asp:textbox></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:button id="btnSearch2" tabIndex="9" runat="server" CssClass="buttonText" Text="Search" onclick="btnSearch2_Click"></asp:button>
			<asp:button id="btnClose" tabIndex="1" runat="server" CssClass="buttonText" Width="60px" Text="Close" onclick="btnClose_Click"></asp:button>
			<asp:label id="lblMessage" runat="server" CssClass="labelText" ForeColor="Red"></asp:label>
			<br>
			<br>
			<asp:datagrid id=dgResults runat="server" CssClass="gridItem" DataSource="<%# dvWaterbodySearch %>" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" AllowSorting="True" AutoGenerateColumns="False" PageSize="5" ShowFooter="True" DataKeyField="WaterBodyID">
				<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" Wrap="False" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
					BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="Select"></asp:EditCommandColumn>
					<asp:BoundColumn DataField="WaterBodyID" SortExpression="WaterBodyID" HeaderText="Water Body ID">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyName_Abrev" SortExpression="WaterBodyName_Abrev" HeaderText="Water Body Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="DrainageCd" SortExpression="DrainageCd" HeaderText="Watershed&lt;br&gt;Code"></asp:BoundColumn>
					<asp:BoundColumn DataField="Level1Name" SortExpression="Level1Name" HeaderText="Level 1 Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="Level2Name" SortExpression="Level2Name" HeaderText="Level 2 Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="Level3Name" SortExpression="Level3Name" HeaderText="Level 3 Name"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="DrainName" SortExpression="DrainName" HeaderText="Watershed"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
