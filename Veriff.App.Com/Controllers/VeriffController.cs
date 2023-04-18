using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veriff.Core.IServices;
using Veriff.Core.Model;

namespace Veriff.App.Com.Controllers
{
    public class VeriffController : Controller
    {

        #region Declaration
        private readonly IVeriffService _veriffService;

        #endregion

        #region Constructor
        public VeriffController(IVeriffService veriffService)
        {
            this._veriffService = veriffService;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        #region Create
        public ActionResult Create()
        {
            
            return View();
        }
        #endregion

        #region MyRegion
        [HttpPost]
        public ActionResult Create(verification verification)
        {
            verificationStatus verStatus = new verificationStatus();
            if (verification!=null)
            {
                verification.callback = "https://veriff.me";
                verification.vendorData = "Span Test";
                verification.document.country = "US";
               bool  isStatus= _veriffService.CreateVeriffSession(verification);

            }
            
            return RedirectToAction("Create", "Veriff");
        }
        #endregion
    }
}
