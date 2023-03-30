using BasicCrudApp.DataLayers.DTOs;
using BasicCrudApp.DataLayers.Entities;
using BasicCrudApp.DataLayers.Repositories;

namespace BasicCrudApp.Services
{
    public class RealEstateService
    {
        private RealEstateRepository _repository { get; set; }

        public RealEstateService(RealEstateRepository repository)
        {
            _repository = repository;
        }

        public int Count
        {
            get
            {
                return _repository.GetAll().Count;
            }
        }

        public List<RealEstateEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public RealEstateEntity? GetRealEstateById(int id)
        {
            return _repository.GetRealEstateById(id);
        }

        public void AddRealEstate(RealEstateEntity realEstate)
        {
            _repository.AddRealEstate(realEstate);
        }

        public void UpdateRealEstate(int id, RealEstateEntity realEstate)
        {
            _repository.UpdateRealEstate(id, realEstate);
        }

        public void DeleteRealEstate(int id)
        {
            _repository.DeleteRealEstate(id);
        }

        public void DeleteRealEstate(RealEstateEntity realEstate)
        {
            _repository.DeleteRealEstate(realEstate);
        }

        public bool EditPrice(RealEstateUpdatePriceDto payload)
        {
            var realEstate = _repository.GetRealEstateById(payload.Id);

            if (realEstate == null)
                return false;

            realEstate.Price = payload.Price;
            return true;
        }
    }
}
