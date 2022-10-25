using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SIBKMNET_WebApp.Context;
using SIBKMNET_WebApp.Models;
using SIBKMNET_WebApp.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApp.Controllers
{
    public class ProvinceController : Controller
    {

       ProvinceRepository ProvinceRepository;

        public ProvinceController(ProvinceRepository provinceRepository)
        {
            this.ProvinceRepository = provinceRepository;     
        }

        // GET ALL
        // GET
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role").Equals("Admin"))
            {
                var data = ProvinceRepository.Get();
                return View(data);
            }
            return RedirectToAction("Unautorized", "ErroPage");
        }

        // GET BY ID
        // GET 
        public IActionResult Details(int id)
        {
            var data = ProvinceRepository.Get(id);
            return View();
        }

        // CREATE 
        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {
                var result = ProvinceRepository.Post(province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // UPDATE
        // GET
        public IActionResult Edit(int id)
        {
            var data = ProvinceRepository.Get(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Province province)
        {
            if (ModelState.IsValid)
            {
                var result = ProvinceRepository.Put(id, province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // DELETE
        // GET
        public IActionResult Delete(int id)
        {
            var data = ProvinceRepository.Get(id);
            return View(data);
        }
        // POST
        public IActionResult DeleteConfirm(Province province)
        {
            var result = ProvinceRepository.Delete(province);
            if (result > 0)
                return RedirectToAction("Index");
            return View();
        }

    }
  }

