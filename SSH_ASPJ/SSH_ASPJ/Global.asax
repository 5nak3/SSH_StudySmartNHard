<%@ Application Codebehind="Global.asax.cs" Inherits="SSH_ASPJ.Global" Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">
    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
    }
   
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("DynamicPage", "Pages/{PageName}.aspx", "~/DynamicPage.aspx");
    }
</script>
