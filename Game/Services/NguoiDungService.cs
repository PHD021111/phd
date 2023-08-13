using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Game.Models;
using Game.Repositories;
using Game.Models.RequestModels;

namespace Game.Services
{
    public interface INguoiDungService
    {
        public Task<ICollection<NguoiDung>> GetNguoiDungs();
        public Task<NguoiDung> GetNguoiDung(string NguoiDungId);
        public void CreateNguoiDung(NguoiDungRequest NguoiDung);
        public void UpdateNguoiDung(string ID, NguoiDungRequest nguoidung);
        public  void DeleteNguoiDung(string id);
    }
    public class NguoiDungService : INguoiDungService
    {
        private readonly NguoiDungRepository _NguoiDungRepository;
        private readonly IMapper _mapper;
        

        public NguoiDungService(NguoiDungRepository NguoiDungRepository, IMapper mapper)
        {
            _NguoiDungRepository = NguoiDungRepository;
            _mapper = mapper;
            
        }
        public async void CreateNguoiDung(NguoiDungRequest nguoidung)
        {
            var newNguoiDung = _mapper.Map<NguoiDung>(nguoidung);
            if (newNguoiDung == null)
            {
                throw new Exception();
            }
            await _NguoiDungRepository.Add(newNguoiDung);
        }

        public async Task<NguoiDung> GetNguoiDung(string NguoiDungId)
        {
            var NguoiDung = await _NguoiDungRepository.GetAll()
                .Where(o => o.Id == NguoiDungId).FirstOrDefaultAsync();
            return NguoiDung;
        }

        public async Task<ICollection<NguoiDung>> GetNguoiDungs()
        {
            var NguoiDungs = await _NguoiDungRepository.GetAll().
                ToListAsync();
            return NguoiDungs;
        }
        public async void UpdateNguoiDung(String ID, NguoiDungRequest nguoidung)
        {
            var NguoiDung = await _NguoiDungRepository.GetAll().Where(o => o.Id == ID).FirstOrDefaultAsync();

            _mapper.Map(nguoidung,NguoiDung);
            _NguoiDungRepository.Update(NguoiDung);
           
            
        }
        public async void DeleteNguoiDung(string id)
        {
            var Class = await _NguoiDungRepository.GetAll().Where(o => o.Id == id).FirstOrDefaultAsync();

            _NguoiDungRepository.Delete(Class);
        }

    }
}
