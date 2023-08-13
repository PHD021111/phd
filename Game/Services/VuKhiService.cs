using Game.Models.RequestModels;
using Game.Models;
using AutoMapper;
using Game.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Game.Services
{
    public interface IVuKhiService
    {
        public Task<ICollection<VuKhi>> GetVuKhis();
        public Task<VuKhi> GetVuKhi(string VuKhiId);
        public void CreateVuKhi(VuKhiRequest VuKhi);
        public void UpdateVuKhi(string ID, VuKhiRequest VuKhi);
        public void DeleteVuKhi(string ID);
    }

    public class VuKhiService : IVuKhiService
    {
        private readonly VuKhiRepository _VuKhiRepository;
        private readonly IMapper _mapper;


        public VuKhiService(VuKhiRepository VuKhiRepository, IMapper mapper)
        {
            _VuKhiRepository = VuKhiRepository;
            _mapper = mapper;

        }
        public async void CreateVuKhi(VuKhiRequest VuKhi)
        {
            var newVuKhi = _mapper.Map<VuKhi>(VuKhi);
            if (newVuKhi == null)
            {
                throw new Exception();
            }
            await _VuKhiRepository.Add(newVuKhi);
        }

        public async Task<VuKhi> GetVuKhi(string VuKhiId)
        {
            var VuKhi = await _VuKhiRepository.GetAll()
                .Where(o => o.Id == VuKhiId).FirstOrDefaultAsync();
            return VuKhi;
        }

        public async Task<ICollection<VuKhi>> GetVuKhis()
        {
            var VuKhis = await _VuKhiRepository.GetAll().
                ToListAsync();
            return VuKhis;
        }
        public async void UpdateVuKhi(String ID, VuKhiRequest vukhi)
        {
            var VuKhi = await _VuKhiRepository.GetAll().Where(o => o.Id == ID).FirstOrDefaultAsync();

            _mapper.Map(vukhi, VuKhi);
            _VuKhiRepository.Update(VuKhi);


        }
        public async void DeleteVuKhi(string id)
        {
            var Class = await _VuKhiRepository.GetAll().Where(o => o.Id == id).FirstOrDefaultAsync();

            _VuKhiRepository.Delete(Class);
        }

    }
}
