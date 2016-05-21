<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeworkSubmit.aspx.cs" Inherits="WebClient.HomeworkSubmit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-6 col-lg-offset-3 margin-top-20" style="float:left">
            <div>
                <p>Select an assignment: </p>
                <asp:DropDownList ID="assignmentList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="assignmentList_SelectedIndexChanged" />
                <asp:RequiredFieldValidator id="RequiredFieldValidator1"
                        ControlToValidate="assignmentList"
                        Display="Static"
                        InitialValue="0"
                        ErrorMessage="Please select an assignment"
                        runat="server"
                        ForeColor="Red"/>
                
                <div class="margin-top-20">
                    <asp:TextBox ID="assignmentTB" Enabled="false" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                </div>
                
                <div class="margin-top-20">
                    <p>Select homework file: </p>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator"
                        ControlToValidate="FileUpload1"
                        Display="Static"
                        ErrorMessage="Please select a file"
                        runat="server"
                        ForeColor="Red"/> 
                </div>
            </div><br />

            <div>
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            </div>
        </div>
    </div>

</asp:Content>
