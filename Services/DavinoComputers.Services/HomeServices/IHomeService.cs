namespace DavinoComputers.Services.HomeServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DavinoComputers.Web.ViewModels.HomeViewModels;

    public interface IHomeService
    {
        HomeViewModel GetCounts();
    }
}
