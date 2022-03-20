using DersDagitimProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Npgsql;
using PagedList;
using System.Data.SqlClient;

namespace DersDagitimProjesi.Controllers
{
    public class SabitBilgiController : Controller
    {
        Context c = new Context();
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var sorgu = c.SabitBilgis.OrderByDescending(x => x.SabitID).ToList().ToPagedList(page, pageSize);
            return View("Index", sorgu);
        }
        [HttpPost]
        public IActionResult CheckBox(SabitBilgi sabit)
        {
            if (sabit.BaslangicSaati == "1")
            {
                if (sabit.OgleArasi == false && sabit.GunlukMaksDers > 6)
                {
                    if (sabit.GunlukMaksDers == 8)
                    {
                        sabit.GunlukMaksDers = 7;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();


                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();

                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }

                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j ];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j ];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 9)
                    {
                        sabit.GunlukMaksDers = 8;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j ];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j ];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 10)
                    {
                        sabit.GunlukMaksDers = 9;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j ];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j ];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == true && sabit.GunlukMaksDers > 6)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j ];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j ];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == false && sabit.GunlukMaksDers < 7)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j ];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j ];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
            }
            else if (sabit.BaslangicSaati == "2")
            {
                if (sabit.OgleArasi == false && sabit.GunlukMaksDers > 6)
                {
                    if (sabit.GunlukMaksDers == 8)
                    {
                        sabit.GunlukMaksDers = 7;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        
                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();

                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }

                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 1];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 1];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 9)
                    {
                        sabit.GunlukMaksDers = 8;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 1];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 1];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 10)
                    {
                        sabit.GunlukMaksDers = 9;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 1];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 1];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == true && sabit.GunlukMaksDers > 6)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 1];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j + 1];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == false && sabit.GunlukMaksDers < 7)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 1];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j + 1];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
            }
            else if (sabit.BaslangicSaati == "3")
            {
                if (sabit.OgleArasi == false && sabit.GunlukMaksDers > 6)
                {
                    if (sabit.GunlukMaksDers == 8)
                    {
                        sabit.GunlukMaksDers = 7;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();


                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();

                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }

                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j+2];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j+2];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 9)
                    {
                        sabit.GunlukMaksDers = 8;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j+2];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j+2];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 10)
                    {
                        sabit.GunlukMaksDers = 9;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j+2];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j+2];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == true && sabit.GunlukMaksDers > 6)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j+2];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j+2];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == false && sabit.GunlukMaksDers < 7)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j+2];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j+2];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
            }
            else if (sabit.BaslangicSaati == "4")
            {
                if (sabit.OgleArasi == false && sabit.GunlukMaksDers > 6)
                {
                    if (sabit.GunlukMaksDers == 8)
                    {
                        sabit.GunlukMaksDers = 7;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();


                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();

                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }

                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 3];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 3];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 9)
                    {
                        sabit.GunlukMaksDers = 8;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 3];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j +3];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 10)
                    {
                        sabit.GunlukMaksDers = 9;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 3];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 3];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == true && sabit.GunlukMaksDers > 6)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 3];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j + 3];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == false && sabit.GunlukMaksDers < 7)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 3];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j + 3];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
            }
            else if (sabit.BaslangicSaati == "5")
            {
                if (sabit.OgleArasi == false && sabit.GunlukMaksDers > 6)
                {
                    if (sabit.GunlukMaksDers == 8)
                    {
                        sabit.GunlukMaksDers = 7;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();


                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();

                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }

                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j +4];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 4];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 9)
                    {
                        sabit.GunlukMaksDers = 8;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 4];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 4];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 10)
                    {
                        sabit.GunlukMaksDers = 9;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 4];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 4];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == true && sabit.GunlukMaksDers > 6)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 4];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j + 4];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == false && sabit.GunlukMaksDers < 7)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 4];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j + 4];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
            }
            else if (sabit.BaslangicSaati == "6")
            {
                if (sabit.OgleArasi == false && sabit.GunlukMaksDers > 6)
                {
                    if (sabit.GunlukMaksDers == 8)
                    {
                        sabit.GunlukMaksDers = 7;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();


                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();

                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }

                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 5];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j +5];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 9)
                    {
                        sabit.GunlukMaksDers = 8;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 5];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 5];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                    else if (sabit.GunlukMaksDers == 10)
                    {
                        sabit.GunlukMaksDers = 9;

                        Random rastgele = new Random();
                        c.SabitBilgis.Add(sabit);
                        c.SaveChanges();

                        var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                        var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                        var gun = c.Guns.Select(x => x.GunID).ToList();
                        var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                        var saat = c.Saats.Select(x => x.SaatID).ToList();
                        var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                        for (int i = 0; i < sin.Count; i++)
                        {
                            var sil = c.DersPrograms.Find(sin[i]);
                            c.DersPrograms.Remove(sil);
                        }
                        for (int k = 0; k < sinif.Count; k++)
                        {
                            for (int i = 0; i < gun.Count; i++)
                            {
                                for (int j = 0; j < a.GunlukMaksDers; j++)
                                {
                                    if (a.OgleArasi == true)
                                    {
                                        if (j == 5)
                                        {
                                            var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                            if (oglearasivarmi != 0)
                                            {
                                                DersProgram ders = new DersProgram();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = oglearasivarmi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                            else
                                            {
                                                DersProgram ders = new DersProgram();
                                                Ders oglearasi = new Ders();
                                                oglearasi.DersAd = "Öğle Arası";
                                                c.Derss.Add(oglearasi);
                                                c.SaveChanges();
                                                var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                                ders.Gunid = gun[i];
                                                ders.Dersid = yenioglearasi;
                                                ders.Sinifid = sinif[k];
                                                j = 14;
                                                ders.Saatid = saat[j];
                                                j = 5;
                                                c.DersPrograms.Add(ders);
                                            }
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            int sayi = rastgele.Next(dersler.Count);
                                            ders.Gunid = gun[i];
                                            var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                            if (varmi >= 2)
                                            {
                                                int sayi1 = rastgele.Next(dersler.Count);
                                                ders.Dersid = dersler[sayi1];
                                            }
                                            else
                                            {
                                                ders.Dersid = dersler[sayi];
                                            }
                                            ders.Sinifid = sinif[k];
                                            ders.Saatid = saat[j + 5];
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 5];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == true && sabit.GunlukMaksDers > 6)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 5];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j + 5];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
                else if (sabit.OgleArasi == false && sabit.GunlukMaksDers < 7)
                {
                    Random rastgele = new Random();
                    c.SabitBilgis.Add(sabit);
                    c.SaveChanges();

                    var a = c.SabitBilgis.OrderBy(x => x.SabitID).LastOrDefault();
                    var sinif = c.Sinifs.Select(x => x.SinifID).ToList();
                    var gun = c.Guns.Select(x => x.GunID).ToList();
                    var dersler = c.Derss.Where(y => y.DersAd != "Öğle Arası").Select(x => x.DersID).ToList();
                    var saat = c.Saats.Select(x => x.SaatID).ToList();
                    var sin = c.DersPrograms.Select(x => x.ProgramID).ToList();
                    for (int i = 0; i < sin.Count; i++)
                    {
                        var sil = c.DersPrograms.Find(sin[i]);
                        c.DersPrograms.Remove(sil);
                    }
                    for (int k = 0; k < sinif.Count; k++)
                    {
                        for (int i = 0; i < gun.Count; i++)
                        {
                            for (int j = 0; j < a.GunlukMaksDers; j++)
                            {
                                if (a.OgleArasi == true)
                                {
                                    if (j == 5)
                                    {
                                        var oglearasivarmi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();

                                        if (oglearasivarmi != 0)
                                        {
                                            DersProgram ders = new DersProgram();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = oglearasivarmi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                        else
                                        {
                                            DersProgram ders = new DersProgram();
                                            Ders oglearasi = new Ders();
                                            oglearasi.DersAd = "Öğle Arası";
                                            c.Derss.Add(oglearasi);
                                            c.SaveChanges();
                                            var yenioglearasi = c.Derss.Where(y => y.DersAd == "Öğle Arası").Select(x => x.DersID).FirstOrDefault();
                                            ders.Gunid = gun[i];
                                            ders.Dersid = yenioglearasi;
                                            ders.Sinifid = sinif[k];
                                            j = 14;
                                            ders.Saatid = saat[j];
                                            j = 5;
                                            c.DersPrograms.Add(ders);
                                        }
                                    }
                                    else
                                    {
                                        DersProgram ders = new DersProgram();
                                        int sayi = rastgele.Next(dersler.Count);
                                        ders.Gunid = gun[i];
                                        var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                        if (varmi >= 2)
                                        {
                                            int sayi1 = rastgele.Next(dersler.Count);
                                            ders.Dersid = dersler[sayi1];
                                        }
                                        else
                                        {
                                            ders.Dersid = dersler[sayi];
                                        }
                                        ders.Sinifid = sinif[k];
                                        ders.Saatid = saat[j + 5];
                                        c.DersPrograms.Add(ders);
                                    }
                                }
                                else
                                {
                                    DersProgram ders = new DersProgram();
                                    int sayi = rastgele.Next(dersler.Count);
                                    ders.Gunid = gun[i];
                                    var varmi = c.DersPrograms.Count(x => x.Dersid == dersler[sayi]);
                                    if (varmi >= 2)
                                    {
                                        int sayi1 = rastgele.Next(dersler.Count);
                                        ders.Dersid = dersler[sayi1];
                                    }
                                    else
                                    {
                                        ders.Dersid = dersler[sayi];
                                    }
                                    ders.Sinifid = sinif[k];
                                    ders.Saatid = saat[j +5];
                                    c.DersPrograms.Add(ders);
                                }
                            }
                        }
                    }
                }
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      

    }
}
