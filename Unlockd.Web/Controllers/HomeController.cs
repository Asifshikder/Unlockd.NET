using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Network;
using Unlockd.Domain.Entities.Services;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Blog;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Services;
using Unlockd.Service.Interface.Testimonials;
using Unlockd.Web.Areas.Admin.Models.Blog;
using Unlockd.Web.Areas.Admin.Models.Brand;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Areas.Admin.Models.Testimonials;
using Unlockd.Web.Helpers;
using Unlockd.Web.Models;

namespace Unlockd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBrandService brandService;
        private IDeviceModelService deviceModelService;
        private IFAQService faqService;
        private ITestimonialService testimonialService;
        private IBlogPostService blogPostService;
        private IBlogCategoryService blogCategoryService;
        private ICountryService countryService;
        private INetworkCarrierService networkCarrierService;
        private IContactService contactService;
        private ILogService logService;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;

        public HomeController(ILogger<HomeController> logger,
            IBrandService brandService,
            IDeviceModelService deviceModelService,
            IFAQService faqService,
            ITestimonialService testimonialService,
            IBlogPostService blogPostService,
            IBlogCategoryService blogCategoryService,
            INetworkCarrierService networkCarrierService,
            IContactService contactService,
            ICountryService countryService,
            ILogService logService, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            _logger = logger;
            this.brandService = brandService;
            this.deviceModelService = deviceModelService;
            this.faqService = faqService;
            this.testimonialService = testimonialService;
            this.blogPostService = blogPostService;
            this.blogCategoryService = blogCategoryService;
            this.countryService = countryService;
            this.networkCarrierService = networkCarrierService;
            this.contactService = contactService;
            this.logService = logService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            int countryId = 0;
            if (signInManager.IsSignedIn(User))
            {
                countryId = GetCountry();
            }
            else
            {
                var usercount = userManager.Users.Count();
                var nextuser = (usercount + 1).ToString();
                var username = "guest" + nextuser ;
                var email = username+"@veeunlock.com";
                var password = "unlock1234";
                var country = countryService.AllAsList().FirstOrDefault();
                User user = new User();
                user.FullName = "Guest User";
                user.Email = email;
                user.UserName = username;
                user.CountryId = country.Id;
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    var findUser =await userManager.FindByEmailAsync(email);
                    var resulta = await signInManager.PasswordSignInAsync(findUser, password, false, false);
                    if (resulta.Succeeded)
                    {
                        countryId = findUser.CountryId.Value;
                    }

                }
            }

            var brandlist = brandService.AllAsIEnumerable().Where(s => s.Id != 18);
            var brands = brandlist.Where(b => b.IsFeatured == true);
            var brandVS = brandlist.Take(12);
            var faqs = faqService.AllAsIEnumerable();
            var testimonials = testimonialService.AllAsIEnumerable();
            var blogPosts = blogPostService.AllAsEnumerable().OrderByDescending(b => b.CreateDate).Take(4);
            
            var Carriers = countryId != 0 ? networkCarrierService.AllAsIEnumerable().Where(b => b.CountryId == countryId&&b.Id!=54).Take(12) : networkCarrierService.AllAsIEnumerable().Take(12);

            HomeContentsViewModel homeContents = new HomeContentsViewModel()
            {
                Brands = brands.Select(b => new BrandViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    BrandLogo = b.BrandLogo,
                    FeaturedImage = b.FeaturedImage,
                    ShortDescription = b.ShortDescription,
                    AverageUnlockingPrice = b.AverageUnlockingPrice,
                    Devices = deviceModelService.AllAsIEnumerable().Where(d => d.BrandId == b.Id && d.IsFeatured == true)
                }),

                FAQs = faqs,
                Brandlist = brandVS,

                Testimonials = testimonials.Select(t => new TestimonialViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Title = t.Title,
                    Company = t.Company,
                    Message = t.Message
                }),

                BlogPosts = blogPosts.Select(b => new BlogPostViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    PrimaryImage = b.PrimaryImage,
                    BlogCategoryName = blogCategoryService.GetById(b.BlogCategoryId).Name,
                    CreateDate = b.CreateDate
                }),
                NetworkCarriers = Carriers.Select(a => new NetworkCarrierViewModel()
                {
                    Id = a.Id,
                    NetworkName = a.NetworkName,
                    CarrierIcon = a.CarrierIcon
                })
            };

            return View(homeContents);
        }

        [HttpGet]
        [Authorize]
        public IActionResult UnlockPhone(int? id)
        {
            var BrandList = brandService.AllAsIEnumerable().Where(s => s.Id != 18).ToList();
            var CountryList = countryService.AllAsIEnumerable().ToList();
            BrandList.Insert(0, new Brand { Id = 0, Name = "Select" });
            CountryList.Insert(0, new Country { Id = 0, Name = "Select" });
            ViewBag.BrandList = BrandList;
            ViewBag.CountryList = CountryList;
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Contact(Contact model)
        {
            model.CountryId = Int32.Parse(HttpContext.Session.GetString("countryId"));
            contactService.InsertEntity(model);
            ViewBag.contactm = "Thank you for your message. We got your message. We will be back to you soon.";
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult FAQ()
        {
            var faqs = faqService.AllAsIEnumerable();
            return View(faqs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public int GetCountry()
        {
            var user = GetCurrentUser();
            return user.Result.CountryId.Value;
        }

        private async Task<User> GetCurrentUser()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return user;
        }
        public IActionResult PageTest()
        {
            return View();
        }

    }
}
