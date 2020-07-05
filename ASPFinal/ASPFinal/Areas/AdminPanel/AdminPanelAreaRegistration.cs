using System.Web.Mvc;

namespace ASPFinal.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPanel_default",
                "AdminPanel/{controller}/{action}/{id}",
                new {controller="", action = "Index", id = UrlParameter.Optional },
                new[] { "ASPFinal.Areas.AdminPanel.Controllers" }
            );
        }
    }
}