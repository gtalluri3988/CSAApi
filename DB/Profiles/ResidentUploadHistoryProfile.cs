using AutoMapper;
using DB.EFModel;
using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Profiles
{
    public class ResidentUploadHistoryProfile : Profile
    {
        public ResidentUploadHistoryProfile()
        {
            CreateMap<ResidentUploadHistory, ResidentUploadHistoryDTO>();
            CreateMap<ResidentUploadHistoryDTO, ResidentUploadHistory>();
        }
    }
}

