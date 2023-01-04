using AutoMapper;
using Hastane.Business.Models.DTOs;
using Hastane.Business.Models.VMs;
using Hastane.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Business.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Employee,AddManagerDTO>().ReverseMap();
            CreateMap<Employee,ListOfManagerVM>().ReverseMap();
            CreateMap<UpdateManagerDto,UpdateManagerVM>().ReverseMap();
            CreateMap<Employee,UpdateManagerDto>().ReverseMap();
            CreateMap<Employee,UpdateManagerVM>().ReverseMap();
        }
    }
}
