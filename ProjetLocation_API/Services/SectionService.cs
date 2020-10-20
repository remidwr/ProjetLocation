using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Utils.Extensions;
using System;
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

        public IEnumerable<SectionWithCategories> GetAll()
        {
            List<SectionWithCategories> sections = _sectionRepository.GetAll().Select(x => x.DALSectionWithCategoriesToAPI()).ToList();
            foreach (SectionWithCategories section in sections)
            {
                section.Categories = _sectionRepository.GetCategoriesBySectionId(section.Id);
            }

            return sections;
        }

        public IEnumerable<SectionWithCategories> GetAllSectionWithCategories()
        {
            List<SectionWithCategories> sections = _sectionRepository.GetAll().Select(x => x.DALSectionWithCategoriesToAPI()).ToList();
            foreach (SectionWithCategories section in sections)
            {
                section.Categories = _sectionRepository.GetCategoriesBySectionId(section.Id);
            }

            return sections;
        }

        public Section GetById(int sectionId)
        {
            Section section = _sectionRepository.GetById(sectionId);

            return section;
        }

        public void Post(Section section)
        {
            try
            {
                _sectionRepository.Insert(section);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Put(int sectionId, Section section)
        {
            try
            {
                _sectionRepository.Update(sectionId, section);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int sectionId)
        {
            try
            {
                _sectionRepository.Delete(sectionId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
