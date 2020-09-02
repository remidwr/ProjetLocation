using System.Web.Http;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class Extensions
    {
        internal static int GetUserId(this ApiController controller)
        {
            return (int)controller.RequestContext.RouteData.Values["UserId"];
        }
    }
}
