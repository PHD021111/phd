using Game.Models.RequestModels;
using Game.Models;
using AutoMapper;
using Game.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Game.Services
{
    public interface IKyNangService
    {
        public Task<ICollection<KyNang>> GetKyNangs();
        public Task<KyNang> GetKyNang(string KyNangId);
        public void CreateKyNang(KyNangRequest KyNang);
        public void UpdateKyNang(string ID, KyNangRequest KyNang);
        public void DeleteKyNang(string ID);

    }
    public class KyNangService:IKyNangService
    {
        private readonly KyNangRepository _KyNangRepository;
        private readonly IMapper _mapper;


        public KyNangService(KyNangRepository KyNangRepository, IMapper mapper)
        {
            _KyNangRepository = KyNangRepository;
            _mapper = mapper;

        }
        public async void CreateKyNang(KyNangRequest KyNang)
        {
            var newKyNang = _mapper.Map<KyNang>(KyNang);
            if (newKyNang == null)
            {
                throw new Exception();
            }
            await _KyNangRepository.Add(newKyNang);
        }

        public async Task<KyNang> GetKyNang(string KyNangId)
        {
            var KyNang = await _KyNangRepository.GetAll()
                .Where(o => o.Id == KyNangId).FirstOrDefaultAsync();
            return KyNang;
        }

        public async Task<ICollection<KyNang>> GetKyNangs()
        {
            var KyNangs = await _KyNangRepository.GetAll().
                ToListAsync();
            return KyNangs;
        }
        public async void UpdateKyNang(String ID, KyNangRequest cl)
        {
            var KyNang = await _KyNangRepository.GetAll().Where(o => o.Id == ID).FirstOrDefaultAsync();

            _mapper.Map(cl, KyNang);
            _KyNangRepository.Update(KyNang);


        }
        public async void DeleteKyNang(string id)
        {
            var KyNang = await _KyNangRepository.GetAll().Where(o => o.Id == id).FirstOrDefaultAsync();

            _KyNangRepository.Delete(KyNang);
        }
    }
}
