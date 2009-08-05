<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFSearch" CodeFile="ESAFSearch.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFSearch</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
		<script>history.forward();</script>
	</HEAD>
	<body>
		<h1>ENVIRONMENTAL STREAM ASSESSMENT</h1>
		<h2>SEARCH</h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>Instructions</legend>
				<ul>
					<li>
					Enter one or more search criteria below. You may use wild characters(*); place 
					them at the beginning and/or end of a Water Body Name or Watershed Code.
					<li>
						Search Results: Click on a column heading to sort the list. Click <b><u>Select</u></b>
						in the record to be returned to the site form.
					</li>
				</ul>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Search Criteria</legend><table>
					<tr>
						<td><asp:Label id="Label1" runat="server" CssClass="labelText">Agency Code:</asp:Label>
						</td>
						<td>
							<asp:DropDownList id=dlstAgencyCd runat="server" DataSource="<%# objdsDE_Agencies %>" DataTextField="Agency" DataValueField="AgencyCd">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td><asp:Label id="Label2" runat="server" CssClass="labelText">Water Body ID:</asp:Label>
						</td>
						<td><asp:TextBox id="txtWaterBodyID" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td><asp:Label id="Label3" runat="server" CssClass="labelText">Water Body Name:</asp:Label>
						</td>
						<td><asp:TextBox id="txtWaterBodyName" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td><asp:Label id="Label4" runat="server" CssClass="labelText">Watershed Code:</asp:Label>
						</td>
						<td><asp:TextBox id="txtWatershedCode" runat="server"></asp:TextBox>
						</td>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:Button id="btnSearch" runat="server" Text="Search" CssClass="buttonText" onclick="btnSearch_Click"></asp:Button>
			<asp:Button id="btnCancel" runat="server" Text="Cancel" CssClass="buttonText" onclick="btnCancel_Click"></asp:Button>
			<asp:Label id="lblMessage" runat="server" CssClass="labelText" ForeColor="Red"></asp:Label>
			<br>
			<br>
			<asp:DataGrid id="dgResults" runat="server" CssClass="gridItem" BorderColor="#CCCCCC" BorderStyle="None"
				BorderWidth="1px" BackColor="White" CellPadding="3" DataSource="<%# dvDE_ESAFSiteList %>" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True" DataKeyField="AquaticActivityID">
				<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
					BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="View"></asp:EditCommandColumn>
					<asp:BoundColumn DataField="AgencyCd" SortExpression="AgencyCd" HeaderText="Agency"></asp:BoundColumn>
					<asp:BoundColumn DataField="AgencySiteID" HeaderText="Agency&lt;br&gt;Site ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyID" SortExpression="WaterBodyID" HeaderText="Water Body&lt;br&gt;ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="WaterBodyName" SortExpression="WaterBodyName" HeaderText="Water Body&lt;br&gt;Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="DrainageCd" SortExpression="DrainageCd" HeaderText="Watershed Code"></asp:BoundColumn>
					<asp:BoundColumn DataField="AquaticActivityStartDate" SortExpression="AquaticActivityStartDate" HeaderText="Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="ObservationCategory" SortExpression="ObservationCategory" HeaderText="Site Type"></asp:BoundColumn>
					<asp:BoundColumn DataField="NumActions" HeaderText="No.&lt;br&gt;Action Items"></asp:BoundColumn>
					<asp:BoundColumn DataField="NumCompleted" HeaderText="No.&lt;br&gt;Completed"></asp:BoundColumn>
					<asp:BoundColumn DataField="NumFollowUp" SortExpression="NumFollowUp" HeaderText="No.&lt;br&gt;Follow Up"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="AquaticSiteUseID" HeaderText="AquaticSiteUseID"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="AquaticActivityID" HeaderText="AquaticActivityID"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
