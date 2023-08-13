using Game.Models.RequestModels;
using Game.Models;
using AutoMapper;
using Game.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Game.Services
{
    public interface IKyNangNhanVatService
    {
        public Task<ICollection<KyNangNhanVat>> GetKyNangNhanVats();
        public Task<KyNangNhanVat> GetKyNangNhanVatByKyNangID(string KyNangNhanVatId);
        public Task<KyNangNhanVat> GetKyNangNhanVatByNhanVatID(string KyNangNhanVatId);
        public void CreateKyNangNhanVat(KyNangNhanVatRequest KyNangNhanVat);
        public void DeleteKyNangNhanVat(string idNV, string idKN0);
        

    }
    public class KyNangNhanVatService:IKyNangNhanVatService
    {
        private readonly KyNangNhanVatRepository _KyNangNhanVatRepository;
        private readonly IMapper _mapper;


        public KyNangNhanVatService(KyNangNhanVatRepository KyNangNhanVatRepository, IMapper mapper)
        {
            _KyNangNhanVatRepository = KyNangNhanVatRepository;
            _mapper = mapper;

        }
        public async void CreateKyNangNhanVat(KyNangNhanVatRequest KyNangNhanVat)
        {
            var newKyNangNhanVat = _mapper.Map<KyNangNhanVat>(KyNangNhanVat);
            if (newKyNangNhanVat == null)
            {
                throw new Exception();
            }
            await _KyNangNhanVatRepository.Add(newKyNangNhanVat);
        }

        public async Task<KyNangNhanVat> GetKyNangNhanVatByNhanVatID(string KyNangNhanVatId)
        {
            var KyNangNhanVat = await _KyNangNhanVatRepository.GetAll()
                .Where(o => o.NhanVatID == KyNangNhanVatId).FirstOrDefaultAsync();
            return KyNangNhanVat;
        }
        public async Task<KyNangNhanVat> GetKyNangNhanVatByKyNangID(string KyNangNhanVatId)
        {
            var KyNangNhanVat = await _KyNangNhanVatRepository.GetAll()
                .Where(o => o.KyNangID == KyNangNhanVatId).FirstOrDefaultAsync();
            return KyNangNhanVat;
        }
        public async Task<ICollection<KyNangNhanVat>> GetKyNangNhanVats()
        {
            var KyNangNhanVats = await _KyNangNhanVatRepository.GetAll().
                ToListAsync();
            return KyNangNhanVats;
        }
        public async void DeleteKyNangNhanVat(string idNV, string idKN)
        {
            var KyNangNhanVat = await _KyNangNhanVatRepository.GetAll()
                .Where(o => o.NhanVatID == idNV).Where(o=>o.KyNangID==idKN).FirstOrDefaultAsync();

            _KyNangNhanVatRepository.Delete(KyNangNhanVat);
        }


    }
}
