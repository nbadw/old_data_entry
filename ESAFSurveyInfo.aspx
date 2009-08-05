<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFSurveyInfo" CodeFile="ESAFSurveyInfo.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFSurveyInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
		<script>history.forward();</script>
	</HEAD>
	<body>
		<h1>ENVIRONMENTAL STREAM ASSESSMENT</h1>
		<h2><asp:Label id="lblh2" runat="server" Font-Names="Times New Roman" Font-Bold="True">ADD New Assessment</asp:Label></h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend><asp:label id="lblStep" runat="server">Step 2 of 7 - Enter </asp:label>
					Survey Info</legend>
				<table border="0">
					<tr>
						<td align="right"><asp:label id="Label1" runat="server" CssClass="labelText">Date (yyyy/mm/dd):</asp:label></td>
						<td><asp:textbox id="txtdate" tabIndex="1" runat="server"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Date must be yyyy/mm/dd"
								Display="None" ControlToValidate="txtdate" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"></asp:regularexpressionvalidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate" Display="None"
								ErrorMessage="You must enter a date"></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td align="right"><asp:label id="Label2" runat="server" CssClass="labelText">Agency Code:</asp:label></td>
						<td><asp:dropdownlist id=dlstAgency tabIndex=2 runat="server" DataValueField="AgencyCd" DataTextField="Agency" DataSource="<%# dvcdAgency %>" Visible="False"></asp:dropdownlist>
							<asp:TextBox id="txtAgency" runat="server" Enabled="False"></asp:TextBox></td>
					</tr>
					<tr>
						<td align="right"><asp:label id="Label3" runat="server" CssClass="labelText">  Personnel:</asp:label></td>
						<td><asp:textbox id="txtpersonnel1" tabIndex="3" runat="server" Wrap="False" Width="100%"></asp:textbox></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" CssClass="labelText"></asp:validationsummary>
			<asp:button id="btnNext" runat="server" CssClass="buttonText" Text="Next" onclick="btnNext_Click"></asp:button>
			<asp:Button id="btnSave" runat="server" CssClass="buttonText" Text="Save" Visible="False" onclick="btnSave_Click"></asp:Button>
			<asp:Button id="btnCancel" runat="server" CssClass="buttonText" Text="Cancel" Visible="False"
				CausesValidation="False" onclick="btnCancel_Click"></asp:Button></form>
	</body>
</HTML>
