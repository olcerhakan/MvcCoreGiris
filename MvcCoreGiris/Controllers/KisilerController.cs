﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreGiris.Models;

namespace MvcCoreGiris.Controllers
{
    public class KisilerController : Controller
    {
        private readonly OkulContext db;
        public KisilerController(OkulContext okulContext)
        {
            db = okulContext;
        }

        // GET: Kisiler
        public IActionResult Index()
        {
            return View(db.Kisiler.ToList());
        }

        public IActionResult Yeni()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Yeni(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                // db.Kisiler.Add(kisi);
                db.Add(kisi);
                db.SaveChanges();
                TempData["mesaj"] = $"'{kisi.KisiAd}' adlı kişi başarı ile eklenmiştir.";
                // Index in adı üstte değişince burda da değişiyor.
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                return NotFound();
            }
            return View(kisi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(Kisi kisi)
        {
            
            if (ModelState.IsValid)
            {
                //db.Entry(kisi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.Update(kisi);
                db.SaveChanges();
                TempData["mesaj"] = $" '{kisi.KisiAd} ' adlı kişi başarı ile güncellenmiştir.";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kisi = db.Kisiler.Find(id);


            if (kisi == null)
            {
                return NotFound();
            }
            db.Remove(kisi);
            db.SaveChanges();
            TempData["mesaj"] = $"'{kisi.KisiAd}' adlı kişi başarı ile silinmiştir.";
            return RedirectToAction(nameof(Index));
        }

    }
}
