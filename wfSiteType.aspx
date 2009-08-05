<%@ Page language="c#" Inherits="NBADWDataEntryApplication.wfSiteType" CodeFile="wfSiteType.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SiteType</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>
			<asp:Label id="lblH1" runat="server" Font-Bold="True" Font-Names="Times New Roman"></asp:Label></h1>
		<h2>ADD a Site</h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>
					Select New or Existing Site</legend>
				<ul>
					<li>
					Some organizations collect multiple types of data at a single site. For 
					instance, a temperature data logger may be installed at a counting fence or at 
					an electrofishing monitoring station.&nbsp;Sites must be geographically unique 
					and all types of data associated with a particular site are tracked.
					<li>
					When setting up a new site, you must select whether the site already exists and 
					you are collecting a new type of data at the site or whether it is actually a 
					new site that does not have any data associated with it.
					<li>
						Note: another agency may have already set up the site, so do not enter your 
						site again.&nbsp;Use the <STRONG>Map</STRONG> button on the next screen to 
						confirm you are setting up a geographically unique site.
					</li>
				</ul>
				<asp:label id="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"
					CssClass="enclosedbuttonText">Please select one of the following:</asp:label><asp:radiobuttonlist id="rblstSiteType" runat="server" CssClass="enclosedbuttonText">
					<asp:ListItem Value="new">the site is new and has never been used to collect any type of data</asp:ListItem>
					<asp:ListItem Value="existing">the site already exists in the system and you wish to add a new type of data to the site</asp:ListItem>
				</asp:radiobuttonlist></fieldset>
			<br>
			<table border="0">
				<tr>
					<td><asp:button id="btnContinue" runat="server" CssClass="buttonText" Text="Continue" onclick="btnContinue_Click"></asp:button></td>
					<td><asp:button id="btnCancel" runat="server" CssClass="buttonText" Text="Cancel" onclick="btnCancel_Click"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
