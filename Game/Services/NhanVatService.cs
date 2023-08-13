using Game.Models.RequestModels;
using Game.Models;
using AutoMapper;
using Game.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Game.Services
{
    public interface INhanVatService
    {
        public Task<ICollection<NhanVat>> GetNhanVats();
        public Task<NhanVat> GetNhanVat(string NhanVatId);
        public void CreateNhanVat(NhanVatRequest NhanVat);
        public void UpdateNhanVat(string ID, NhanVatRequest nhanvat);
        public void DeleteNhanVat(string ID);
            
    }
    public class NhanVatService:INhanVatService
    {
        private readonly NhanVatRepository _NhanVatRepository;
        private readonly IMapper _mapper;


        public NhanVatService(NhanVatRepository NhanVatRepository, IMapper mapper)
        {
            _NhanVatRepository = NhanVatRepository;
            _mapper = mapper;

        }
        public async void CreateNhanVat(NhanVatRequest NhanVat)
        {
            var newNhanVat = _mapper.Map<NhanVat>(NhanVat);
            if (newNhanVat == null)
            {
                throw new Exception();
            }
            await _NhanVatRepository.Add(newNhanVat);
        }

        public async Task<NhanVat> GetNhanVat(string NhanVatId)
        {
            var NhanVat = await _NhanVatRepository.GetAll()
                .Where(o => o.Id == NhanVatId).FirstOrDefaultAsync();
            return NhanVat;
        }

        public async Task<ICollection<NhanVat>> GetNhanVats()
        {
            var NhanVats = await _NhanVatRepository.GetAll().
                ToListAsync();
            return NhanVats;
        }
        public async void UpdateNhanVat(String ID, NhanVatRequest nhanvat)
        {
            var NhanVat = await _NhanVatRepository.GetAll().Where(o => o.Id == ID).FirstOrDefaultAsync();

            _mapper.Map(nhanvat, NhanVat);
            _NhanVatRepository.Update(NhanVat);


        }
        public async void DeleteNhanVat(string id)
        {
            var NhanVat = await _NhanVatRepository.GetAll().Where(o => o.Id == id).FirstOrDefaultAsync();

            _NhanVatRepository.Delete(NhanVat);
        }

    }
}
