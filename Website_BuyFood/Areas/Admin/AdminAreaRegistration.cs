using System.Web.Mvc;

namespace Website_BuyFood.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //Huynh cho mac đinh sẽ bat dang nhap
            
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Login", controller ="Home", id = UrlParameter.Optional }
            );
        }
    }
}