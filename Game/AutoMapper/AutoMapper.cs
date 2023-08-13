using AutoMapper;
using Game.Models;
using Game.Models.RequestModels;
using Game.Models.ResponseModels;
using NhanVatGame.Models.ResponseModels;

namespace Game.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapNguoiDung();
            MapNhanVat();
            MapVuKhi();
            MapClass();
            MapKyNang();
            MapKyNangNhanVat();
        }

       private void MapNguoiDung()
        {
            CreateMap<NguoiDungRequest, NguoiDung>()
                 .ForMember(x => x.Id, opt => opt.Ignore())
                 .ReverseMap();
            CreateMap<NguoiDungResponse, NguoiDung>().ReverseMap();
        }

        private void MapNhanVat()
        { 
            CreateMap<NhanVatRequest,NhanVat>().ForMember(x => x.Id, opt => opt.Ignore())
                 .ReverseMap();
            CreateMap<NhanVat, NhanVatResponse>()
                .ForMember(x => x.NguoiDung, opt => opt.MapFrom(src => src.NguoiDungID))
                .ForMember(x => x.VuKhi, opt => opt.MapFrom(src => src.VuKhiID))
                .ForMember(x => x.Class, opt => opt.MapFrom(src => src.ClassID));


        }
        private void MapVuKhi()
        {
            CreateMap<VuKhiRequest, VuKhi>()
                 .ForMember(x => x.Id, opt => opt.Ignore())
                 .ReverseMap();
            CreateMap<VuKhi,VuKhiResponse >().ReverseMap();

        }
        private void MapClass()
        {
            CreateMap<ClassRequest,Class>().ForMember(x => x.Id, opt => opt.Ignore())
                 .ReverseMap();
            CreateMap<Class, ClassResponse>().ReverseMap();
        }
        private void MapKyNang()
        {
            CreateMap<KyNangRequest, KyNang>().ForMember(x => x.Id, opt => opt.Ignore())
                 .ReverseMap();
            CreateMap<KyNang, KyNangResponse>().ReverseMap();
        }
        private void MapKyNangNhanVat()
        {
            CreateMap<KyNangNhanVat, KyNangNhanVatRequest>().ReverseMap();
            CreateMap<KyNangNhanVatResponse, KyNangNhanVat>().ReverseMap();
        }






        
        

    }
}
