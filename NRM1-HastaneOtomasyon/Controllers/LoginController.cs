using DataAccess.Abstract;
using Hastane.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NRM1_HastaneOtomasyon.Models;


namespace NRM1_HastaneOtomasyon.Controllers
{
	public class LoginController : Controller
	{
		private readonly IAdminRepo _adminRepo;
		private readonly IPersonnelRepo _personnelRepo;
		private readonly ImanagerRepo _ımanagerRepo;
		public LoginController(IAdminRepo adminRepo, ImanagerRepo managerRepo, IPersonnelRepo personnelRepo)
		{
			_adminRepo = adminRepo;
			_personnelRepo = personnelRepo;
			_ımanagerRepo = managerRepo;
		}
		////Giriş Yapan Kullanıcı Bilgileri Tutulur
		////Session 
		//public static IUser activePerson;
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(string emailAddress, string password)
		{
			//Admin,Manager,Personnel aslında tek bir tablodan yönetilir ve bu tablodan sorgu yapılır.Anlık çözüm üretmek için böyle bir davranış sergiledim.
			//BaseRepo'da yazabilirdim bu GetByEmail metotlarını yazmamamın nedeni ise BaseRepo'daki T kısıtlamasında emailAdress ve Password bilgilerinin bulunmamasından kaynaklanmaktadır!!
			var adminUser = _adminRepo.GetByEmail(emailAddress, password);
			var managerUser = _ımanagerRepo.GetByEmail(emailAddress, password);
			var personnelUser = _personnelRepo.GetByEmail(emailAddress, password);
			if (adminUser != null)
			{
				return RedirectToAction("Index", "Admin");
			}
			if (managerUser != null)
			{
				return RedirectToAction("Index", "Manager");
			}
			if (personnelUser != null)
			{
				return RedirectToAction("Index", "Personnel");
			}
			return View();
		}
	}
}
