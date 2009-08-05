<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFSiteCharacteristics" CodeFile="ESAFSiteCharacteristics.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd valign = top HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFSiteCharacteristics</title>
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
			<fieldset class="standardText"><legend><asp:label id="lblStep" runat="server">Step 4 of 7 - Enter </asp:label>
					Site Characteristics</legend>
				<table border="0">
					<tr>
						<td colspan="2">
							<asp:Label id="Label11" runat="server" CssClass="labelText">* Indicates the form will refresh after you enter information in this field</asp:Label></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label1" runat="server" CssClass="labelText">Stream Cover:</asp:label></td>
						<td vAlign="top"><asp:dropdownlist id="dlstStreamCover" runat="server" Width="185px" tabIndex="1"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label2" runat="server" CssClass="labelText">Stream Bank:</asp:label></td>
						<td vAlign="top"><asp:dropdownlist id="dlstStreamBank" runat="server" Width="185px" tabIndex="2"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label3" runat="server" CssClass="labelText"> Stream Bank Slope - Left:</asp:label></td>
						<td vAlign="top">
							<asp:TextBox id="txtStreamBankSlopeL" runat="server"></asp:TextBox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label10" runat="server" CssClass="labelText"> Stream Bank Slope - Right:</asp:label></td>
						<td vAlign="top">
							<asp:TextBox id="txtStreamBankSlopeR" runat="server"></asp:TextBox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px; HEIGHT: 41px" vAlign="top"><asp:label id="Label4" runat="server" CssClass="labelText">Stream Type*:</asp:label></td>
						<td vAlign="top" style="HEIGHT: 41px"><asp:dropdownlist id="dlstStreamType" runat="server" Width="185px" AutoPostBack="True" tabIndex="5" onselectedindexchanged="dlstStreamType_SelectedIndexChanged"></asp:dropdownlist>&nbsp;&nbsp;
							<asp:Label id="lblSpecify1" runat="server" CssClass="labelText" Visible="False">Specify:</asp:Label><asp:textbox id="txtOther1" runat="server" Enabled="False" tabIndex="6" Visible="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label5" runat="server" CssClass="labelText">Indicators of Possible Impaired Water Quality:</asp:label></td>
						<td vAlign="top">
							<table>
								<tr>
									<td vAlign="top"><asp:checkbox id="chkSuspendedSilt" runat="server" CssClass="labelText" Text="suspended silt"
											tabIndex="7"></asp:checkbox></td>
									<td vAlign="top"><asp:checkbox id="chkEmbeddedSubstrate" runat="server" CssClass="labelText" Text="embedded substrate"
											tabIndex="8"></asp:checkbox></td>
								<tr>
									<td vAlign="top"><asp:checkbox id="chkAquaticPlantsAbundant" runat="server" CssClass="labelText" Text="aquatic plants abundant"
											tabIndex="9"></asp:checkbox></td>
									<td vAlign="top"><asp:checkbox id="chkAlgae" runat="server" CssClass="labelText" Text="algae" tabIndex="10"></asp:checkbox></td>
								<tr>
									<td vAlign="top"><asp:checkbox id="chkPetroleum" runat="server" CssClass="labelText" Text="petroleum/oil" tabIndex="11"></asp:checkbox></td>
									<td vAlign="top"><asp:checkbox id="chkOdor" runat="server" CssClass="labelText" Text="odor" tabIndex="12"></asp:checkbox></td>
								<tr>
									<td style="HEIGHT: 21px" vAlign="top"><asp:checkbox id="chkFoam" runat="server" CssClass="labelText" Text="foam" tabIndex="13"></asp:checkbox></td>
									<td style="HEIGHT: 21px" vAlign="top"><asp:checkbox id="chkDeadFish" runat="server" CssClass="labelText" Text="dead fish" tabIndex="14"></asp:checkbox></td>
								<tr>
									<td vAlign="top" colspan="2"><asp:checkbox id="chkOther" runat="server" CssClass="labelText" AutoPostBack="True" Text="other*"
											tabIndex="15" oncheckedchanged="chkOther_CheckedChanged"></asp:checkbox>&nbsp;&nbsp;
										<asp:Label id="lblSpecify2" runat="server" CssClass="labelText" Visible="False">Specify:</asp:Label><asp:textbox id="txtOther2" runat="server" Enabled="False" tabIndex="16" Visible="False"></asp:textbox></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label6" runat="server" CssClass="labelText">Water Clarity:</asp:label></td>
						<td vAlign="top"><asp:dropdownlist id="dlstWaterClarity" runat="server" Width="185px" tabIndex="17"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label7" runat="server" CssClass="labelText">Water Colour:</asp:label></td>
						<td vAlign="top"><asp:dropdownlist id="dlstWaterColour" runat="server" Width="185px" tabIndex="18"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label8" runat="server" CssClass="labelText">Weather in Past 48 hours:</asp:label></td>
						<td vAlign="top"><asp:dropdownlist id="dlstWeatherinPast48hours" runat="server" Width="185px" tabIndex="19"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="WIDTH: 253px" vAlign="top"><asp:label id="Label9" runat="server" CssClass="labelText">Weather Currently:</asp:label></td>
						<td vAlign="top"><asp:dropdownlist id="dlstWeatherCurrently" runat="server" Width="185px" tabIndex="20"></asp:dropdownlist></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:button id="btnNext" runat="server" CssClass="buttonText" Text="Next" tabIndex="21" onclick="btnNext_Click"></asp:button>
			<asp:button id="btnSave" runat="server" CssClass="buttonText" Text="Save" tabIndex="21" Visible="False" onclick="btnSave_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" CssClass="buttonText" Text="Cancel" tabIndex="21"
				Visible="False" CausesValidation="False" onclick="btnCancel_Click"></asp:button>
		</form>
	</body>
</HTML>
