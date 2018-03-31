﻿using System.Net;
using System.Web.Mvc;
using GetHired.DTO;
using GetHired.Services.Contracts;

namespace GetHired.ASPClient.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        // GET: Company
        public ActionResult Index()
        {
            var companies = companyService.GetAll();
            return View(companies);
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = this.companyService.GetById(id.Value);
            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyModel company)
        {
            if (this.companyService.Add(company))
            {
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = this.companyService.GetById(id.Value);
            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyModel company)
        {
            if (this.companyService.Update(company))
            {
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = this.companyService.GetById(id.Value);
            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var company = this.companyService.GetById(id);
            if (company == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (this.companyService.Delete(company))
            {
                return RedirectToAction("Index");
            }

            return View(company);
        }
    }
}
