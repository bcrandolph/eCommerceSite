using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using eCommerceSite.Models;
using eCommerceSite.Dtos;
namespace eCommerceSite.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Bundle, BundleDto>();
            CreateMap<Report, ReportDto>();
            CreateMap<SizeReport, SizeReportDto>();
            CreateMap<Models.Type, TypeDto>();
            CreateMap<Size, SizeDto>();
            CreateMap<User, UserDto>();

            //Dto to Domain
            CreateMap<ReportDto, Report>();
            CreateMap<SizeReportDto, SizeReport>();
            CreateMap<BundleDto, Bundle>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<TypeDto, Models.Type>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<SizeDto, Size>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<UserDto, User>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}