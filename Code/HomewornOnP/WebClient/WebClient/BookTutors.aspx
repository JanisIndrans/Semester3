<%@ Page Title="BookTutors" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookTutors.aspx.cs" Inherits="WebClient.BookTutors" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Container">
        <div class="row">
            <div class="columns" style="height:30px" >
                <div class="col-sm-3">
                    <asp:DropDownList ID="SubjectDrL" runat="server" style="text-wrap:normal" Width="215px" AutoPostBack="true" OnSelectedIndexChanged="SubjectDrL_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-sm-3">
                    <asp:DropDownList ID="TeacherDrL" runat="server" style="text-wrap:normal" Width="215px" AutoPostBack="true" OnSelectedIndexChanged="TeacherDrL_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
       </div>
            <div class="row">
                <div class="columns">
                    <div class="col-sm-2" style="width:300px">
                        <asp:Calendar ID="BookingCalendar" runat="server" OnDayRender="BookingCalendar_DayRender" OnSelectionChanged="BookingCalendar_SelectionChanged"></asp:Calendar>
                    </div>
                    <div class="col-sm-3" style="width: 440px; height: 185px; overflow: scroll">
                            <asp:GridView ID="TutorTable" runat="server"  Width="400px" AutoGenerateColumns ="false" ShowHeaderWhenEmpty="true"
                                BorderColor="#336699" BorderStyle="Solid" BorderWidth="2px"
                                CellPadding="4" ForeColor="#333333" OnRowCommand="TutorTable_RowCommand">
                
                             <Columns>

                            <asp:BoundField DataField="Name" HeaderText="Teacher Name" 
                                     SortExpression="TeacherID" ItemStyle-Width="100px" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>

                                 <asp:BoundField DataField="Subject" HeaderText="Subject"
                                     SortExpression="SubjectID" ItemStyle-Width="100px" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                 </asp:BoundField >

                             <asp:BoundField DataField="Time" HeaderText="Time" 
                                     SortExpression="SubjectID" ItemStyle-Width="100px" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>

                            <asp:ButtonField ButtonType="button" CommandName="Book"
                                    HeaderText="Book Tutor" Text="Book Tutor" ItemStyle-Width="100px" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"/>
                        

                             </Columns>
                            </asp:GridView>
                    </div>
                </div>
            </div>
        <div>
            <asp:Label ID="calendarLabel" runat="server" Text="colo" BackColor="Green" ForeColor="Green"></asp:Label>
            <asp:Label ID="calendarLabelText" runat="server" Text=": available dates for booking."></asp:Label>
        </div>
        <div>Click on the date to see all bookings for the date.</div>
    </div>

</asp:Content>