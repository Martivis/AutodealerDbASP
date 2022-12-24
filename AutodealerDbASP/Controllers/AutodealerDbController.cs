using AutodealerDbWF;
using AutodealerDbASP.Models.AutodealerDb.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutodealerDbASP.Models.AutodealerDb;
using PagedList.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace AutodealerDbASP.Controllers
{
    public class AutodealerDbController : Controller
    {
        private AutodealerDbStorage _db = new AutodealerDbStorage(new AutodealerDbContext());

        #region CarColor
        public ActionResult CarColorsList(int? page)
        {
            int pageSize = 3;
            int pageNumber = page ?? 1;
            return View(_db.GetAll<CarColor>().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult DeleteCarColor(int? id)
        {
            if (id == null)
                return NotFound();
            CarColor carColor = _db.Get<CarColor>((int)id);
            return View(carColor);
        }

        [HttpPost, ActionName("DeleteCarColor")]
        public ActionResult DeleteCarColorConfirmed(int id)
        {
            try
            {
                _db.Delete(_db.Get<CarColor>(id));
                return RedirectToAction("CarColorsList");
            }
            catch
            {
                CarColor carColor = _db.Get<CarColor>(id);
                ViewBag.ErrorMessage = "Не удалось удалить цвет, так как он используется моделью";
                return View(carColor);
            }
        }

        [HttpGet]
        public ActionResult EditCarColor(int? id)
        {
            if (id == null)
                return NotFound();
            CarColor carColor = _db.Get<CarColor>((int)id);
            return View(carColor);
        }

        [HttpPost]
        public ActionResult EditCarColor(CarColor carColor)
        {
            if (ModelState.IsValid)
            {
                _db.Update(carColor);
                return RedirectToAction("CarColorsList");
            }
            return View(carColor);
            
        }

        [HttpGet]
        public ActionResult AddCarColor()
        {
            return View(new CarColor());
        }

        [HttpPost]
        public ActionResult AddCarColor(CarColor carColor)
        {
            if (ModelState.IsValid)
            {
                _db.Add(carColor);
                return RedirectToAction("CarColorsList");
            }
            return View(carColor);
        }
        #endregion

        #region CarBrand
        public ActionResult CarBrandsList(int? page)
        {
			int pageSize = 3;
			int pageNumber = page ?? 1;
			return View(_db.GetAll<CarBrand>().ToPagedList(pageNumber, pageSize));
		}

        [HttpGet]
        public ActionResult DeleteCarBrand(int? id)
        {
            if (id == null)
                return NotFound();
            CarBrand carBrand = _db.Get<CarBrand>((int)id);
            return View(carBrand);
        }

        [HttpPost, ActionName("DeleteCarBrand")]
        public ActionResult DeleteCarBrandConfirmed(int id)
        {
            try
            {
                _db.Delete(_db.Get<CarBrand>(id));
                return RedirectToAction("CarBrandsList");
            }
            catch
            {
                ViewBag.ErrorMessage = "Не удалось удалить бренд, так как он используется моделью";
                CarBrand carBrand = _db.Get<CarBrand>(id);
                return View(carBrand);
            }
        }

        [HttpGet]
        public ActionResult EditCarBrand(int? id)
        {
            if (id == null)
                return NotFound();
            CarBrand carBrand = _db.Get<CarBrand>((int)id);
            return View(carBrand);
        }

        [HttpPost]
        public ActionResult EditCarBrand(CarBrand carBrand)
        {
            if (ModelState.IsValid)
            {
                _db.Update(carBrand);
                return RedirectToAction("CarBrandsList");
            }
            return View(carBrand);

        }

        [HttpGet]
        public ActionResult AddCarBrand()
        {
            return View(new CarBrand());
        }

        [HttpPost]
        public ActionResult AddCarBrand(CarBrand carBrand)
        {
            if (ModelState.IsValid)
            {
                _db.Add(carBrand);
                return RedirectToAction("CarBrandsList");
            }
            return View(carBrand);
        }
        #endregion

        #region Client
        public ActionResult ClientsList(int? page)
        {
			int pageSize = 3;
			int pageNumber = page ?? 1;
			return View(_db.GetAll<Client>().ToPagedList(pageNumber, pageSize));
		}

        [HttpGet]
        public ActionResult DeleteClient(int? id)
        {
            if (id == null)
                return NotFound();
            Client client = _db.Get<Client>((int)id);
            return View(client);
        }
        [HttpPost, ActionName("DeleteClient")]
        public ActionResult DeleteClientConfirmed(int id)
        {
            try
            {
                _db.Delete(_db.Get<Client>(id));
                return RedirectToAction("ClientsList");
            }
            catch
            {
                ViewBag.ErrorMessage = "Не удалось удалить данные клиента, так как они используются";
                Client client = _db.Get<Client>((int)id);
                return View(client);
            }
        }

        [HttpGet]
        public ActionResult EditClient(int? id)
        {
            if (id == null)
                return NotFound();
            Client client = _db.Get<Client>((int)id);
            return View(client);
        }
        [HttpPost]
        public ActionResult EditClient(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Update(client);
                return RedirectToAction("ClientsList");
            }
            return View(client);

        }

        [HttpGet]
        public ActionResult AddClient()
        {
            return View(new Client());
        }
        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Add(client);
                return RedirectToAction("ClientsList");
            }
            return View(client);
        }
        #endregion

        #region Provider
        public ActionResult ProvidersList(int? page)
        {
			int pageSize = 3;
			int pageNumber = page ?? 1;
			return View(_db.GetAll<Provider>().ToPagedList(pageNumber, pageSize));
		}

        [HttpGet]
        public ActionResult DeleteProvider(int? id)
        {
            if (id == null)
                return NotFound();
            Provider provider = _db.Get<Provider>((int)id);
            return View(provider);
        }

        [HttpPost, ActionName("DeleteProvider")]
        public ActionResult DeleteProviderConfirmed(int id)
        {
            try
            {
                _db.Delete(_db.Get<Provider>(id));
                return RedirectToAction("ProvidersList");
            }
            catch
            {
                ViewBag.ErrorMessage = "Не удалось удалить данные поставщика, так как они используются";
                Client client = _db.Get<Client>(id);
                return View(client);
            }
        }

        [HttpGet]
        public ActionResult EditProvider(int? id)
        {
            if (id == null)
                return NotFound();
            Provider provider = _db.Get<Provider>((int)id);
            return View(provider);
        }

        [HttpPost]
        public ActionResult EditProvider(Provider provider)
        {
            if (ModelState.IsValid)
            {
                _db.Update(provider);
                return RedirectToAction("ProvidersList");
            }
            return View(provider);

        }

        [HttpGet]
        public ActionResult AddProvider()
        {
            return View(new Provider());
        }

        [HttpPost]
        public ActionResult AddProvider(Provider provider)
        {
            if (ModelState.IsValid)
            {
                _db.Add(provider);
                return RedirectToAction("ProvidersList");
            }
            return View(provider);
        }
		#endregion

		#region Model
		public ActionResult ModelsList(int? page)
		{
			int pageSize = 3;
			int pageNumber = page ?? 1;
			return View(_db.GetAllModelsFull().ToPagedList(pageNumber, pageSize));
		}

		[HttpGet]
		public ActionResult DeleteModel(int? id)
		{
			if (id == null)
				return NotFound();
			Model model = _db.GetModelFull((int)id);
			return View(model);
		}

		[HttpPost, ActionName("DeleteModel")]
		public ActionResult DeleteModelConfirmed(int id)
		{
            try
            {
                _db.Delete(_db.Get<Model>(id));
                return RedirectToAction("ModelsList");
            }
            catch
            {
                ViewBag.ErrorMessage = "Не удалось удалить модель, так как она используется в лоте";
                Model model = _db.GetModelFull(id);
                return View(model);
            }
		}

		[HttpGet]
		public ActionResult EditModel(int? id)
		{
			if (id == null)
				return NotFound();
			ViewBag.CarBrands = new SelectList(_db.GetAll<CarBrand>(), "CarBrandId", "Name");
			ViewBag.CarColors = new SelectList(_db.GetAll<CarColor>(), "CarColorId", "Name");
			Model model = _db.Get<Model>((int)id);
			return View(model);
		}

		[HttpPost]
		public ActionResult EditModel(Model model)
		{
			if (ModelState.IsValid)
			{
				_db.Update(model);
				return RedirectToAction("ModelsList");
			}
			return View(model);
		}

		[HttpGet]
		public ActionResult AddModel()
		{
            ViewBag.CarBrands = new SelectList(_db.GetAll<CarBrand>(), "CarBrandId", "Name");
			ViewBag.CarColors = new SelectList(_db.GetAll<CarColor>(), "CarColorId", "Name");

			return View(new Model());
		}

		[HttpPost]
		public ActionResult AddModel(Model model)
		{
			if (ModelState.IsValid)
			{
				_db.Add(model);
				return RedirectToAction("ModelsList");
			}
			return View(model);
		}
		#endregion

		#region Lot
		public ActionResult LotsList(int? page)
		{
			int pageSize = 3;
			int pageNumber = page ?? 1;
			return View(_db.GetAllLotsFull().ToPagedList(pageNumber, pageSize));
		}

		[HttpGet]
		public ActionResult DeleteLot(int? id, string errorMessage = null)
		{
			if (id == null)
				return NotFound();
            ViewBag.ErrorMessage = errorMessage;
			Lot lot = _db.GetLotFull((int)id);
			return View(lot);
		}

		[HttpPost, ActionName("DeleteLot")]
		public ActionResult DeleteLotConfirmed(int id)
		{
            try
            {
                _db.Delete(_db.Get<Lot>(id));
                return RedirectToAction("LotsList");
            }
            catch
            {
                return RedirectToAction("DeleteLot", new { id, errorMessage = "Не удалось удалить" });
            }
		}

        [HttpGet]
		public ActionResult EditLot(int? id)
		{
			if (id == null)
				return NotFound();

            ViewBag.Models = new SelectList(_db.GetAll<Model>(), "ModelId", "Name");
            ViewBag.Providers = new SelectList(_db.GetAll<Provider>(), "ProviderId", "Name");
			Lot lot = _db.Get<Lot>((int)id);
			return View(lot);
		}

		[HttpPost]
		public ActionResult EditLot(Lot lot)
		{
			if (ModelState.IsValid)
			{
				_db.Update(lot);
				return RedirectToAction("LotsList");
			}
			return View(lot);
		}

		[HttpGet]
		public ActionResult AddLot()
		{
			ViewBag.Models = new SelectList(_db.GetAll<Model>(), "ModelId", "Name");
			ViewBag.Providers = new SelectList(_db.GetAll<Provider>(), "ProviderId", "Name");

			return View(new Lot());
		}

		[HttpPost]
		public ActionResult AddLot(Lot lot)
		{
			if (ModelState.IsValid)
			{
				_db.Add(lot);
				return RedirectToAction("LotsList");
			}
			return View(lot);
		}
		#endregion

		#region ClientDeal
		public ActionResult DealsList(int? page)
		{
			int pageSize = 3;
			int pageNumber = page ?? 1;
			return View(_db.GetAllClientDealsFull().ToPagedList(pageNumber, pageSize));
		}

		[HttpGet]
		public ActionResult DeleteDeal(int? id)
		{
			if (id == null)
				return NotFound();
			ClientDeal deal = _db.GetClientDealFull((int)id);
			return View(deal);
		}

		[HttpPost, ActionName("DeleteDeal")]
		public ActionResult DeleteDealConfirmed(int id)
		{
            try
            {
                _db.Delete(_db.GetClientDealFull(id));
                return RedirectToAction("DealsList");
            }
            catch
            {
                ViewBag.ErrorMessage = "Не удалось удалить сделку";
                ClientDeal deal = _db.GetClientDealFull((int)id);
                return View(deal);
            }
		}

		[HttpGet]
		public ActionResult EditDeal(int? id)
		{
			if (id == null)
				return NotFound();

            ClientDeal deal = _db.GetClientDealFull((int)id);

            var lots = _db.GetAvalableLotsWithModel().Append(deal.Lot);

			ViewBag.Lots = new SelectList(lots, "LotId", "PriceAmount");
			ViewBag.Clients = new SelectList(_db.GetAll<Client>(), "ClientId", "Name");

			return View(deal);
		}

		[HttpPost]
		public ActionResult EditDeal(ClientDeal deal)
		{
			if (ModelState.IsValid)
			{
				_db.Update(deal);
				return RedirectToAction("DealsList");
			}
			return View(deal);
		}

		[HttpGet]
		public ActionResult AddDeal()
		{
			ViewBag.Lots = new SelectList(_db.GetAvalableLotsWithModel(), "LotId", "PriceAmount");
			ViewBag.Clients = new SelectList(_db.GetAll<Client>(), "ClientId", "Name");

			return View(new ClientDeal());
		}

		[HttpPost]
		public ActionResult AddDeal(ClientDeal deal)
		{
			if (ModelState.IsValid)
			{
				_db.Add(deal);
				return RedirectToAction("DealsList");
			}
			return View(deal);
		}
		#endregion
	}
}
