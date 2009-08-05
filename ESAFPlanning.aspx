<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ESAFPlanning" CodeFile="ESAFPlanning.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ESAFPlanning</title>
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
			<asp:Panel Runat="server" ID="pnlInstructions">
				<FIELDSET class="standardText"><LEGEND>
						<asp:label id="lblStep" runat="server">Step 7 of 7 - Enter </asp:label>Planning 
						Information</LEGEND>
					<UL>
						<LI>
							Enter planning information below, then click the <B>Add</B>
						button to add a planning record. It will appear in the Planning List box.
						<LI>
							Click <B><U>Modify</U></B>
						to&nbsp;edit a record in the Planning List.
						<LI>
							Click <B><U>Delete</U></B> to remove a record in the Planning List.
						</LI>
					</UL>
				</FIELDSET>
			</asp:Panel>
			<asp:Panel id="pnlPlanningList" runat="server">
				<BR>
				<FIELDSET class="standardText"><LEGEND>Planning List</LEGEND>
					<asp:datagrid id=dgCurrentRecords runat="server" DataKeyField="EnvPlanningID" ShowFooter="True" CssClass="enclosedgridItem" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" DataSource="<%# dvtblEnvironmentalPlanning %>">
						<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
						<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
						<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom"
							BackColor="LightSteelBlue"></HeaderStyle>
						<Columns>
							<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Modify"></asp:EditCommandColumn>
							<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
							<asp:BoundColumn DataField="IssueCategory" HeaderText="IssueCategory"></asp:BoundColumn>
							<asp:BoundColumn DataField="Issue" HeaderText="Issue"></asp:BoundColumn>
							<asp:BoundColumn DataField="ActionRequired" HeaderText="ActionRequired"></asp:BoundColumn>
							<asp:BoundColumn DataField="ActionTargetDate" HeaderText="Action&lt;br&gt;Target Date" DataFormatString="{0:yyyy/MM/dd}"></asp:BoundColumn>
							<asp:BoundColumn DataField="ActionPriority" HeaderText="Action&lt;br&gt;Priority"></asp:BoundColumn>
							<asp:BoundColumn DataField="ActionCompletionDate" HeaderText="Action&lt;br&gt;Completion Date" DataFormatString="{0:yyyy/MM/dd}"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="AquaticActivityID" HeaderText="AquaticActivityID"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="EnvPlanningID" HeaderText="EnvPlanningID"></asp:BoundColumn>
							<asp:BoundColumn DataField="FollowUpRequired" HeaderText="Follow Up&lt;br&gt;Required"></asp:BoundColumn>
							<asp:BoundColumn DataField="FollowUpTargetDate" HeaderText="Follow Up&lt;br&gt;Target Date" DataFormatString="{0:yyyy/MM/dd}"></asp:BoundColumn>
							<asp:BoundColumn DataField="FollowUpCompletionDate" HeaderText="Follow Up&lt;br&gt;Completion Date"
								DataFormatString="{0:yyyy/MM/dd}"></asp:BoundColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
					</asp:datagrid></FIELDSET>
			</asp:Panel>
			<br>
			<fieldset class="standardText"><legend>Planning Record</legend>
				<table width="100%">
					<tr>
						<td vAlign="top"><asp:label id="Label1" runat="server" CssClass="labelText">Category:</asp:label></td>
						<td vAlign="top"><asp:dropdownlist id="dlstCategory" runat="server"></asp:dropdownlist>
							<asp:TextBox id="txtPlanningID" runat="server" Visible="False"></asp:TextBox></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label2" runat="server" CssClass="labelText">Nature of Problem / Potential Impacts:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtNature" runat="server" Width="100%" Rows="5" TextMode="MultiLine"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label3" runat="server" CssClass="labelText">Actions Required:</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtActions" runat="server" Width="100%" Rows="5" TextMode="MultiLine"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label4" runat="server" CssClass="labelText">Target Date (yyyy/mm/dd):</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtTarget1" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="txtTarget1" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"
								Display="None" ErrorMessage="Action Target Date must be of the form yyyy/mm/dd"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label5" runat="server" CssClass="labelText">Priority:</asp:label></td>
						<td vAlign="top"><asp:dropdownlist id="dlstPriority" runat="server"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label6" runat="server" CssClass="labelText">Completed Date (yyyy/mm/dd):</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtCompleted1" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ControlToValidate="txtCompleted1"
								ValidationExpression="\d{4}[/]\d{2}[/]\d{2}" Display="None" ErrorMessage="Action Completed Date must be of the form yyyy/mm/dd"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label7" runat="server" CssClass="labelText">Required Follow Up:</asp:label></td>
						<td vAlign="top"><asp:checkbox id="chkRequired" runat="server"></asp:checkbox></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label8" runat="server" CssClass="labelText">Target Date  (yyyy/mm/dd):</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtTarget2" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" ControlToValidate="txtTarget2" ValidationExpression="\d{4}[/]\d{2}[/]\d{2}"
								Display="None" ErrorMessage="Follow Up Target Date must be of the form yyyy/mm/dd"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label9" runat="server" CssClass="labelText">Completed Date (yyyy/mm/dd):</asp:label></td>
						<td vAlign="top"><asp:textbox id="txtCompleted2" runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" ControlToValidate="txtCompleted2"
								ValidationExpression="\d{4}[/]\d{2}[/]\d{2}" Display="None" ErrorMessage="Follow Up Completed Date must be of the form yyyy/mm/dd"></asp:regularexpressionvalidator></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" CssClass="labelText"></asp:validationsummary>
			<asp:button id="btnAdd" runat="server" Text="Add" CssClass="buttonText" onclick="btnAdd_Click"></asp:button>
			<asp:button id="btnFinish" runat="server" Text="Finish" CssClass="buttonText" CausesValidation="False" onclick="btnFinish_Click"></asp:button>
			<asp:button id="btnDone" runat="server" Text="Done" Visible="False" CausesValidation="False"
				CssClass="buttonText" onclick="btnDone_Click"></asp:button>
			<asp:Button id="btnSave" runat="server" Text="Save" Visible="False" CssClass="buttonText" onclick="btnSave_Click"></asp:Button>
			<asp:Button id="btnCancel" runat="server" Text="Cancel" CausesValidation="False" Visible="False"
				CssClass="buttonText" onclick="btnCancel_Click"></asp:Button>
		</form>
	</body>
</HTML>
