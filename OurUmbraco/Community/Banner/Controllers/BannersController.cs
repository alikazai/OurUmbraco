﻿using OurUmbraco.Community.Banner.Models;
using OurUmbraco.Location;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace OurUmbraco.Community.Banner.Controllers
{
    public class BannersController : SurfaceController
    {
        private readonly BannerService _bannerService;
        private readonly LocationService _locationService;

        public BannersController()
        {
            _bannerService = new BannerService();
            _locationService = new LocationService();
        }

        public ActionResult Render(int id)
        {
            var page = Umbraco.TypedContent(id);
            if (page != null && page.DocumentTypeAlias == "Community")
            {
                var vm = new Banners
                {
                    Collection = _bannerService.GetBannersByPage(page),
                    Location = _locationService.GetLocationByIp(Request.UserHostAddress)
                };
                return PartialView("Home/Banners", vm);
            }

            return null;
        }
    }
}
