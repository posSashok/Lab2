// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Proekt.Controllers;
using Proekt.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Npgsql.Internal.TypeHandlers.NumericHandlers;
using System.Linq;
using Proekt;
using Proekt.Models;
using Microsoft.Extensions.Hosting;

namespace Proekt.Controllers
{
    public class FilmiController : Controller
    {

        private readonly CinemaContext _filmiContext;
        public FilmiController(CinemaContext filmiContext)
        {
            _filmiContext = filmiContext;
        }

        public IActionResult reg()
        {
            return View();
        }

        public IActionResult PrivacyAd()
        {
            return View();
        }

        public IActionResult AdminStart()
        {
            return View();
        }

        public IActionResult UserStart()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TicketFormUser()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult AddSeanseForm()
        {
            return View();
        }

        public IActionResult AddTicketForm()
        {
            return View();
        }

        //Фильмы
        [HttpGet]
        public IActionResult Index1()
        {
            List<Film> films = _filmiContext.Films.ToList();
            return View(films);
        }

        public IActionResult Filmi()
        {
            List<Film> films = _filmiContext.Films.ToList();
            return View(films);
        }

        public IActionResult AddFilmForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index1(string FilmName, string Long, string Janr, string Country, string Rating, string Old)
        {
            Film films = new Film { FilmName = FilmName, Long = Long, Janr = Janr, Country = Country, Rating = Rating, Old = Old };
            _filmiContext.Films.Add(films);
            _filmiContext.SaveChanges();
            return RedirectToAction("Index1");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Film? films = await _filmiContext.Films.FirstOrDefaultAsync(p => p.FilmId == id);
                {
                    _filmiContext.Films.Remove(films);
                    await _filmiContext.SaveChangesAsync();
                    return RedirectToAction("Index1");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> change(int? id)
        {
            Film? films = await _filmiContext.Films.FirstOrDefaultAsync(p => p.FilmId == id);
            if (id != null)
            {
                return View(films);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> change(Film films)
        {
            if (films != null)
            {
                _filmiContext.Films.Update(films);
                await _filmiContext.SaveChangesAsync();
            }
            return RedirectToAction("Index1");
        }


        //Билеты
        [HttpGet]
        public IActionResult Tickets()
        {
            List<Ticket> tickets = _filmiContext.Tickets.ToList();
            return View(tickets);
        }



        [HttpPost]
        public IActionResult AddTickets(int TicketId, int SeansId, int KlientId, int ZalId, decimal Cost, decimal Sale, decimal Finaly)
        {

            Ticket tickets = new Ticket { TicketId = TicketId, SeansId = SeansId, KlientId = KlientId, ZalId = ZalId, Cost = Cost, Sale = Sale, Finaly = Finaly };
            _filmiContext.Tickets.Add(tickets);
            _filmiContext.SaveChanges();
            return RedirectToAction("Tickets");

        }
        public IActionResult AddTicketsUser(int TicketId, int SeansId, int KlientId, int ZalId, decimal Cost, decimal Sale, decimal Finaly)
        {

            Ticket tickets = new Ticket { TicketId = TicketId, SeansId = SeansId, KlientId = KlientId, ZalId = ZalId, Cost = Cost, Sale = Sale, Finaly = Finaly };
            _filmiContext.Tickets.Add(tickets);
            _filmiContext.SaveChanges();
            return RedirectToAction("OK");

        }

        public async Task<IActionResult> change2(Ticket tickets)
        {
            if (tickets != null)
            {
                _filmiContext.Tickets.Update(tickets);
                await _filmiContext.SaveChangesAsync();
            }
            return RedirectToAction("Tickets");
        }


        public async Task<IActionResult> change2(int? id)
        {
            Ticket? tickets = await _filmiContext.Tickets.FirstOrDefaultAsync(p => p.TicketId == id);
            if (id != null)
            {
                return View(tickets);
            }
            return NotFound();
        }


        public IActionResult OK()
        {
            return View();
        }

        public async Task<IActionResult> Delete1(int? id)
        {
            if (id != null)
            {
                Ticket? tickets = await _filmiContext.Tickets.FirstOrDefaultAsync(p => p.TicketId == id);
                if (id != null)
                {
                    _filmiContext.Tickets.Remove(tickets);
                    await _filmiContext.SaveChangesAsync();
                    return RedirectToAction("Tickets");
                }
            }
            return NotFound();
        }

        //Сеансы
        [HttpGet]
        public IActionResult Seanses()
        {
            List<Seanse> seanses = _filmiContext.Seanses.ToList();
            return View(seanses);
        }

        public IActionResult SeanseUser()
        {
            List<Seanse> seanses = _filmiContext.Seanses.ToList();
            return View(seanses);
        }

        [HttpPost]
        public IActionResult AddSeanses(int SeansId, int FilmId, DateTime Nachalo, int OstMest, string? Ps)
        {
            Seanse seanses = new Seanse { SeansId = SeansId, FilmId = FilmId, Nachalo = Nachalo, OstMest = OstMest, Ps = Ps };

            _filmiContext.Seanses.Add(seanses);
            _filmiContext.SaveChanges();
            return RedirectToAction("Seanses");
        }

        public async Task<IActionResult> Delete11(int? id)
        {
            if (id != null)
            {
                Seanse? seanses = await _filmiContext.Seanses.FirstOrDefaultAsync(p => p.SeansId == id);
                if (id != null)
                {
                    _filmiContext.Seanses.Remove(seanses);
                    await _filmiContext.SaveChangesAsync();
                    return RedirectToAction("Seanses");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> change1(Seanse seanses)
        {
            if (seanses != null)
            {
                _filmiContext.Seanses.Update(seanses);
                await _filmiContext.SaveChangesAsync();
            }
            return RedirectToAction("Seanses");
        }


        public async Task<IActionResult> change1(int? id)
        {
            Seanse? seanses = await _filmiContext.Seanses.FirstOrDefaultAsync(p => p.SeansId == id);
            if (id != null)
            {
                return View(seanses);
            }
            return NotFound();
        }


        //Klients
        [HttpGet]
        public IActionResult Klients()
        {
            List<Klient> klients = _filmiContext.Klients.ToList();
            return View(klients);
        }


        public IActionResult AddKlientForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddKlient(int KlientId, string Familia, string Name, string? Otchestvo, string Bday, string Kontact)
        {

            Klient klients = new Klient { KlientId = KlientId, Familia = Familia, Name = Name, Otchestvo = Otchestvo, Bday = Bday, Kontact = Kontact };
            _filmiContext.Klients.Add(klients);
            _filmiContext.SaveChanges();
            return RedirectToAction("Klients");

        }

        public IActionResult AddKlient1(int KlientId, string Familia, string Name, string? Otchestvo, string Bday, string Kontact)
        {

            Klient klients = new Klient { KlientId = KlientId, Familia = Familia, Name = Name, Otchestvo = Otchestvo, Bday = Bday, Kontact = Kontact };
            _filmiContext.Klients.Add(klients);
            _filmiContext.SaveChanges();
            return RedirectToAction("Privacy");

        }


        public async Task<IActionResult> Deleteklients(int? id)
        {
            if (id != null)
            {
                Klient? klients = await _filmiContext.Klients.FirstOrDefaultAsync(p => p.KlientId == id);
                if (id != null)
                {
                    _filmiContext.Klients.Remove(klients);
                    await _filmiContext.SaveChangesAsync();
                    return RedirectToAction("Klients");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> changeklients(int? id)
        {
            Klient? klients = await _filmiContext.Klients.FirstOrDefaultAsync(p => p.KlientId == id);
            if (id != null)
            {
                return View(klients);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> changeklients(Klient klients)
        {
            if (klients != null)
            {
                _filmiContext.Klients.Update(klients);
                await _filmiContext.SaveChangesAsync();
            }
            return RedirectToAction("Klients");
        }


        //Вход пользователя
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, int password)
        {
            if (ModelState.IsValid)
            {
                Klient klients = _filmiContext.Klients.FirstOrDefault(u => u.Familia == login && u.KlientId == password);

                if (klients != null)
                {

                    return RedirectToAction("UserStart");

                }
                else return View("Error");
            }
            else return View("Error");
        }


        //Вход администратора
        [HttpGet]
        public IActionResult LoginAd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAd(string login1, int password1)
        {
            if (ModelState.IsValid)
            {
                Personal personal = _filmiContext.Personals.FirstOrDefault(u => u.Familia == login1 && u.NomPers == password1);

                if (personal != null)
                {
                    return RedirectToAction("AdminStart");

                }
                else return View("Error");
            }
            else return View("Error");
        }
        public IActionResult LoginAd7(string login1, int password1)
        {
            if (ModelState.IsValid)
            {
                Personal personal = _filmiContext.Personals.FirstOrDefault(u => u.Familia == login1 && u.NomPers == password1);

                if (personal != null)
                {
                    return RedirectToAction("AdminStart");

                }
                else return View("Error");
                if (personal != null)
                {
                    return RedirectToAction("AdminStart");

                }
                else return View("Error");
            }
            else return View("Error");
        }
    }
    }



