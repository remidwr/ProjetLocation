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
        private readonly SectionRepository _sectionRepository;

        public SectionService(SectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public IEnumerable<SectionFull> GetAll()
        {
            List<SectionFull> sections = _sectionRepository.GetAll().Select(x => x.DALSectionWithCategoriesToAPI()).ToList();

            if (!(sections is null))
            {
                foreach (SectionFull section in sections)
                {
                    section.Categories = _sectionRepository.GetCategoriesBySectionId(section.Id).Select(x => x.DALCategoryToAPI());
                }
            }

            return sections;
        }

        public SectionFull GetById(int sectionId)
        {
            SectionFull section = _sectionRepository.GetById(sectionId).DALSectionWithCategoriesToAPI();

            if (!(section is null))
            {
                section.Categories = _sectionRepository.GetCategoriesBySectionId(section.Id).Select(x => x.DALCategoryToAPI());
            }

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
            _sectionRepository.Delete(sectionId);
        }
    }
}
