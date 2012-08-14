<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TTS.Web.Models.IndexModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Say shit on my computer!
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Say shit on my computer!</h2>

    <form id="frmSpeak" action="" method="post">
        <label for="txtSay">
            <span>Say:</span>
            <%--<input type="text" id="txtSay" name="txtSay" value="something" />--%>
            <textarea id="txtSay" name="txtSay">Something</textarea>
        </label>

        <label for="slctVoice" class="select-wrap-left">
            <span>Using Voice:</span>
            <select id="slctVoice" name="slctVoice">
                <% for (int i = 0; i < Model.InstalledVoices.Count; i++) { %>
                    <option value="<%=i %>"><%=Model.InstalledVoices[i] %></option>
                <% } %>
            </select>
        </label>

        <label for="slctRate" class="select-wrap-right">
            <span>At Rate:</span>
            <select id="slctRate" name="slctRate">
                <% for (int i = -10; i <= 10 ; i++) { %>
                    <option value="<%=i %>" <%=(i == -4 ? "selected=\"selected\"" : String.Empty) %>><%=i %></option>
                <% } %>
            </select>
        </label>

        <p class="button-wrap">
            <span id="status">Idle</span>
            <input type="submit" id="btnSubmit" name="btnSubmit" value="Speak!" />
        </p>
    </form>

</asp:Content>
