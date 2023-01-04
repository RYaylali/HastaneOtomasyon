
using AutoMapper;
using Hastane.Business.Models.DTOs;
using Hastane.Business.Models.VMs;
using Hastane.Core.Enums;
using Hastane.DataAccess.Abstract;
using Hastane.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Business.Services.AdminService
{
	public class AdminService : IAdminService
	{
		private readonly IEmployeeRepo _employeeRepo;
		public readonly IMapper _mapper;
		public AdminService(IEmployeeRepo employeeRepo, IMapper mapper)
		{
			_employeeRepo = employeeRepo;
			_mapper = mapper;
		}

		public async Task AddManager(AddManagerDTO addManagerDTO)
		{
			//Employee employee = new Employee();
			//employee.Id = addManagerDTO.Id;
			//employee.Name = addManagerDTO.Name;
			//employee.Surname = addManagerDTO.Surname;
			//employee.Salary = addManagerDTO.Salary;
			//employee.CreatedDate = addManagerDTO.CreatedDate;
			//employee.Status = addManagerDTO.Status;
			//employee.EmailAddress = addManagerDTO.EmailAddress;
			var employee= _mapper.Map<Employee>(addManagerDTO);
			employee.Password = GivePassword();
			await _employeeRepo.Add(employee);
		}

		public async Task<List<ListOfManagerVM>> ListOfManager()
		{
			var managers = await _employeeRepo.GetFilteredList(
				select: x => new ListOfManagerVM
				{
					Id= x.Id,
					Name = x.Name,
					Surname = x.Surname,
					EmailAddress = x.EmailAddress,
					Salary = x.Salary,
				}, where: x => x.Status == Status.Active,
				orderBy: x => x.OrderBy(x => x.Name));
			return managers;
		}
		private string GivePassword()
		{
			Random rastgele = new Random();
			string sifre = String.Empty;
		

			for (int i = 1; i <= 6; i++)
			{
				int sayi1 = rastgele.Next(65, 91);
				//65 dahil, 91 dahil değil A ile Z arasında
				sifre += (char)sayi1;
			}



			return sifre;
		}

		public async Task<UpdateManagerDto> GetManager(Guid id)
		{
			var employeeVm = await _employeeRepo.GetFilteredFirstOrDefault(select: x => new UpdateManagerVM
			{
				Id = x.Id,
				Name = x.Name,
				Surname = x.Surname,
				EmailAddress = x.EmailAddress,
				Salary = x.Salary,
				IdentityNumber = x.IdentityNumber,
				UpdatedDate = x.UpdatedDate
			}, where: x => x.Id == id);
			var updateDTO= _mapper.Map<UpdateManagerDto>(employeeVm);
			return updateDTO;
		}

		public async Task UpdateManager(UpdateManagerDto updateManagerDto)
		{
			//createddate=01.01.0001 tarihine verir
			var employee=await _employeeRepo.GetById(updateManagerDto.Id);
			employee.Name = updateManagerDto.Name;
			employee.Surname = updateManagerDto.Surname;
			employee.EmailAddress = updateManagerDto.EmailAddress;
			employee.Salary = updateManagerDto.Salary;
			employee.IdentityNumber = updateManagerDto.IdentityNumber;
			employee.UpdatedDate = updateManagerDto.UpdatedDate;
			await _employeeRepo.Update(employee);
		}

       
    }
}
