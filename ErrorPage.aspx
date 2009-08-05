<%@ Page language="c#" Inherits="ArcServer3.ErrorPage" CodeFile="ErrorPage.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title id="TitleText">Application Error</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language=javascript>
					function start() {
						window.focus();
						// Hide the Loading banner on the main page if this page is called from a child window
						if (opener) opener.HideLoading();
					}

		</script>
	</HEAD>
	<body id="BodyTag" onload="start()">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblError" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 72px" runat="server"
				Font-Size="Medium" Font-Names="Arial" Width="921" Height="120px"></asp:label><asp:label id="lblTitle" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server"
				Font-Size="Large" Font-Names="Arial" Width="921" Height="40px" ForeColor="Navy" Font-Bold="True">Application Error</asp:label>
			<asp:Label id="lblExtendedMessage" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 208px"
				runat="server" Font-Size="X-Small" Font-Names="Arial,Helvetica,San Serif" Width="921px"
				Height="104px"></asp:Label></form>
	</body>
</HTML>
