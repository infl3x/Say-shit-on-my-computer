<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TTS.Web.Models.LogModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Log &raquo; Say shit on my computer!
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Log</h2>

    <div id="previous-requests">
        <ul>
            <% if (Model.SpeechRequests.Count == 0) { %>
                <li>No requests</li>
            <% } else { %>
                <% for (int i = 0; i < Model.SpeechRequests.Count; i++) { %>
                    <li><%=Html.Encode(Model.SpeechRequests[i]) %></li>
                <% } %>
            <% } %>
        </ul>
    </div>

    <div id="block-list">
    </div>
</asp:Content>
