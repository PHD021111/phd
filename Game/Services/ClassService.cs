using Game.Models.RequestModels;
using Game.Models;
using AutoMapper;
using Game.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Game.Services
{
    public interface IClassService
    {
        public Task<ICollection<Class>> GetClasss();
        public Task<Class> GetClass(string ClassId);
        public void CreateClass(ClassRequest Class);
        public void UpdateClass(string ID, ClassRequest Class);
        public void DeleteClass(string id);
            
    }
    public class ClassService:IClassService
    {
        private readonly ClassRepository _ClassRepository;
        private readonly IMapper _mapper;


        public ClassService(ClassRepository ClassRepository, IMapper mapper)
        {
            _ClassRepository = ClassRepository;
            _mapper = mapper;

        }
        public async void CreateClass(ClassRequest Class)
        {
            var newClass = _mapper.Map<Class>(Class);
            if (newClass == null)
            {
                throw new Exception();
            }
            await _ClassRepository.Add(newClass);
        }

        public async Task<Class> GetClass(string ClassId)
        {
            var Class = await _ClassRepository.GetAll()
                .Where(o => o.Id == ClassId).FirstOrDefaultAsync();
            return Class;
        }

        public async Task<ICollection<Class>> GetClasss()
        {
            var Classs = await _ClassRepository.GetAll().
                ToListAsync();
            return Classs;
        }
        public async void UpdateClass(string ID, ClassRequest cl)
        {
            var Class = await _ClassRepository.GetAll().Where(o => o.Id == ID).FirstOrDefaultAsync();

            _mapper.Map(cl, Class);
            _ClassRepository.Update(Class);


        }
        public async void DeleteClass(string id)
        {
            var Class = await _ClassRepository.GetAll().Where(o=>o.Id==id).FirstOrDefaultAsync();

            _ClassRepository.Delete(Class);
        }

        
    }
}
