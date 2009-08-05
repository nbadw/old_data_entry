<%@ Page language="c#" Inherits="NBADWDataEntryApplication.Users" CodeFile="Users.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Users</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id=dgUsers runat="server" DataSource="<%# objdsUser %>" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False">
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="FirstName" HeaderText="FirstName"></asp:BoundColumn>
					<asp:BoundColumn DataField="LastName" HeaderText="LastName"></asp:BoundColumn>
					<asp:BoundColumn DataField="Organization" HeaderText="Organization"></asp:BoundColumn>
					<asp:BoundColumn DataField="UserAgency" HeaderText="UserAgency"></asp:BoundColumn>
					<asp:BoundColumn DataField="UserName" HeaderText="UserName"></asp:BoundColumn>
					<asp:BoundColumn DataField="UserDatabase" HeaderText="UserDatabase"></asp:BoundColumn>
					<asp:BoundColumn DataField="Administrator" HeaderText="Administrator"></asp:BoundColumn>
					<asp:BoundColumn DataField="LastLogin" HeaderText="LastLogin"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
