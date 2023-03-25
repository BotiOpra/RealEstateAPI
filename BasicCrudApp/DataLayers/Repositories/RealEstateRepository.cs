using BasicCrudApp.DataLayers.Entities;
using System.Xml;

namespace BasicCrudApp.DataLayers.Repositories
{
    /// <summary>
    /// Class that simulates a database
    /// </summary>
    public class RealEstateRepository
    {
        private List<RealEstateEntity> _realEstates;

        public RealEstateRepository()
        {
            _realEstates = new List<RealEstateEntity>();
        }

        /// <summary>
        /// Returns a list of all the RealEstates in the DboContext
        /// </summary>
        /// <returns>List of RealEstateEntity</returns>
        public List<RealEstateEntity> GetAll()
        {
            return _realEstates;
        }

        /// <summary>
        /// Returns a RealEstateEntity instance by id (Note: It might be null)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RealEstateEntity?</returns>
        public RealEstateEntity? GetById(int id)
        {
            return _realEstates.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Function to add a new RealEstate to the dboContext (Note: It auto-generates an Id)
        /// </summary>
        /// <param name="realEstate"></param>
        public void Add(RealEstateEntity realEstate)
        {
            realEstate.Id = _realEstates.Count + 1;
            _realEstates.Add(realEstate);
        }

        /// <summary>
        /// Function that, given an Id and a RealEstateEntity instance, it finds the entity we want to modify and it updates its state to match the 2nd parameter given
        /// </summary>
        /// <param name="id"></param>
        /// <param name="realEstate"></param>
        public void Update(int id, RealEstateEntity realEstate)
        {
            var existingRealEstate = GetById(id);
            if (existingRealEstate != null)
            {
                existingRealEstate.Owner = realEstate.Owner;
                existingRealEstate.Type = realEstate.Type;
                existingRealEstate.City = realEstate.City;
                existingRealEstate.Street = realEstate.Street;
                existingRealEstate.NumberOfRooms = realEstate.NumberOfRooms;
                existingRealEstate.SizeInSquareMeters = realEstate.SizeInSquareMeters;
            }
        }

        /// <summary>
        /// Function to delete an entity from dboContext, given its Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var existingRealEstate = GetById(id);
            if (existingRealEstate != null)
            {
                _realEstates.Remove(existingRealEstate);
            }
        }
    }
}
