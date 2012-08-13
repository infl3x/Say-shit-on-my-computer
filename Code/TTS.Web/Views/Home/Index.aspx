<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TTS.Web.Models.IndexModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Say shit on my computer!</h2>

    <form id="frmSpeak" action="" method="post">
        <label for="txtSay">Say:</label>
        <input type="text" id="txtSay" name="txtSay" value="something" />

        <br />

        <label for="slctVoice">Using Voice:</label>
        <select id="slctVoice" name="slctVoice">
            <% for (int i = 0; i < Model.InstalledVoices.Count; i++) { %>
                <option value="<%=i %>"><%=Model.InstalledVoices[i] %></option>
            <% } %>
        </select>

        <p class="button-wrap">
            <span id="status">Idle</span>
            <input type="submit" id="btnSubmit" name="btnSubmit" value="Go!" />
        </p>
    </form>

</asp:Content>
