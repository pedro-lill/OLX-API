using AutoMapper; 
using olxapi.Dtos;
using olxapi.Models;

namespace olxapi.Profiles;

public class AdProfile : Profile
{
   public AdProfile()
   {
        CreateMap<CreateAdDto, Ad>();
        CreateMap<UpdateAdDto, Ad>();
        CreateMap<Ad, UpdateAdDto>();
        //CreateMap<Ad, ReadAdDto>();
   } 
}