namespace DavinoComputers.Web.Areas.Administration.Controllers
{
    using DavinoComputers.Common;
    using DavinoComputers.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
