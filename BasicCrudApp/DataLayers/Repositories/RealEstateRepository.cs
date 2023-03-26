using BasicCrudApp.DataLayers.Entities;
using System.Xml;

namespace BasicCrudApp.DataLayers.Repositories
{
    public interface IRealEstateRepository
    {
        List<RealEstateEntity> GetAll();

        RealEstateEntity? GetRealEstateById(int id);
        void AddRealEstate(RealEstateEntity realEstate);
        void UpdateRealEstate(int id ,RealEstateEntity realEstate);
        void DeleteRealEstate(int id);
        public void DeleteRealEstate(RealEstateEntity realEstate);
    }


    /// <summary>
    /// Class that simulates a database
    /// </summary>
    public class RealEstateRepository
    {
        /// <summary>
        /// Returns a list of all the RealEstates in the DboContext
        /// </summary>
        /// <returns>List of RealEstateEntity</returns>
        public List<RealEstateEntity> GetAll()
        {
            return DbContext._realEstates;
        }

        /// <summary>
        /// Returns a RealEstateEntity instance by id (Note: It might be null)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RealEstateEntity?</returns>
        public RealEstateEntity? GetRealEstateById(int id)
        {
            return DbContext._realEstates.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Function to add a new RealEstateEntity to the dboContext (Note: It auto-generates an Id)
        /// </summary>
        /// <param name="realEstate"></param>
        public void AddRealEstate(RealEstateEntity realEstate)
        {
            realEstate.Id = DbContext._realEstates.Count + 1;
            DbContext._realEstates.Add(realEstate);
        }

        /// <summary>
        /// Function that, given an Id and a RealEstateEntity instance, it finds the entity we want to modify and it updates its state to match the 2nd parameter given
        /// </summary>
        /// <param name="id"></param>
        /// <param name="realEstate"></param>
        public void UpdateRealEstate(int id, RealEstateEntity realEstate)
        {
            var existingRealEstate = GetRealEstateById(id);
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
        public void DeleteRealEstate(int id)
        {
            var existingRealEstate = GetRealEstateById(id);
            if (existingRealEstate != null)
            {
                DbContext._realEstates.Remove(existingRealEstate);
            }
        }

        public void DeleteRealEstate(RealEstateEntity realEstate)
        {
            if (realEstate != null)
            {
                DbContext._realEstates.Remove(realEstate);
            }
        }
    }
}
