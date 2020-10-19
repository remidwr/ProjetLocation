using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Services
{
    public class SectionService
    {
        private ISectionRepository<Section, Category> _sectionRepository;

        public SectionService(SectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public IEnumerable<Section> GetAll()
        {
            IEnumerable<Section> sections = _sectionRepository.GetAll().Select(x => x);

            return sections;
        }

        public IEnumerable<Category> GetCategoriesBySectionId(int categoryId)
        {
            IEnumerable<Category> categories = _sectionRepository.GetCategoriesBySectionId(categoryId).Select(x => x);

            return categories;
        }

        public IEnumerable<SectionWithCategories> GetAllSectionWithCategories()
        {
            IEnumerable<SectionWithCategories> sections = _sectionRepository.GetAll().Select(x => x.DALSectionWithCategoriesToAPI());
            foreach (SectionWithCategories section in sections)
            {
                section.Categories = GetCategoriesBySectionId(section.Id);
            }

            return sections;
        }

        public Section GetById(int categoryId)
        {
            Section section = _sectionRepository.GetById(categoryId);

            return section;
        }

        public int Post(Section section)
        {
            int Successful = _sectionRepository.Insert(section);

            return Successful;
        }

        public int Put(int categoryId, Section section)
        {
            int Successful = _sectionRepository.Update(categoryId, section);

            return Successful;
        }

        public int Delete(int categoryId)
        {
            int Successful = _sectionRepository.Delete(categoryId);

            return Successful;
        }
    }
}
