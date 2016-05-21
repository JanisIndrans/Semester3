<%@ page title="Home Page" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Default.aspx.cs" inherits="WebClient._Default" %>

<asp:content id="BodyContent" contentplaceholderid="MainContent" runat="server">

    <div class="row">

        <img src="Content/Image/UCN_logo.gif" class="margin-top-20 img-responsive center-content" />

        <div class="col-md-6 col-lg-offset-3 margin-top-20" >
            <a href="#" class="btn btn-primary btn-large btn-block"><span class="glyphicon glyphicon-folder-open"></span> Browse assignments</a>
            <a href="HomeworkSubmit.aspx" class="btn btn-primary btn-large btn-block"><span class="glyphicon glyphicon-cloud-upload"></span> Submit assignment</a>
            <a href="SubmissionHistory.aspx" class="btn btn-primary btn-large btn-block"><span class="glyphicon glyphicon-tags"></span> Submission History</a>
        </div>
        <div class="col-md-6 col-lg-offset-3 margin-top-20">
            <a href="BookTutors.aspx" class="btn btn-primary btn-large btn-block"><span class="glyphicon glyphicon-education"></span> Browse tutors</a>
            <a href="#" class="btn btn-primary btn-large btn-block"><span class="glyphicon glyphicon-time"></span> Book tutor</a>
        </div>
    </div>

</asp:content>
