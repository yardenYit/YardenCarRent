﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JohnBryce
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class YardenCarRentEntities : DbContext
    {
        public YardenCarRentEntities()
            : base("name=YardenCarRentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarFleet> CarFleets { get; set; }
        public virtual DbSet<CarManufacturer> CarManufacturers { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<ContactUsMessage> ContactUsMessages { get; set; }
        public virtual DbSet<GearType> GearTypes { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int AddCar(string carNumber, Nullable<int> currentMiles, string imageFileName, Nullable<bool> isOK2Rent, Nullable<int> carModelID, Nullable<int> year, Nullable<int> gearTypeID, Nullable<decimal> dailyCost, Nullable<decimal> dailyLateCost)
        {
            var carNumberParameter = carNumber != null ?
                new ObjectParameter("carNumber", carNumber) :
                new ObjectParameter("carNumber", typeof(string));
    
            var currentMilesParameter = currentMiles.HasValue ?
                new ObjectParameter("currentMiles", currentMiles) :
                new ObjectParameter("currentMiles", typeof(int));
    
            var imageFileNameParameter = imageFileName != null ?
                new ObjectParameter("imageFileName", imageFileName) :
                new ObjectParameter("imageFileName", typeof(string));
    
            var isOK2RentParameter = isOK2Rent.HasValue ?
                new ObjectParameter("isOK2Rent", isOK2Rent) :
                new ObjectParameter("isOK2Rent", typeof(bool));
    
            var carModelIDParameter = carModelID.HasValue ?
                new ObjectParameter("carModelID", carModelID) :
                new ObjectParameter("carModelID", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var gearTypeIDParameter = gearTypeID.HasValue ?
                new ObjectParameter("gearTypeID", gearTypeID) :
                new ObjectParameter("gearTypeID", typeof(int));
    
            var dailyCostParameter = dailyCost.HasValue ?
                new ObjectParameter("dailyCost", dailyCost) :
                new ObjectParameter("dailyCost", typeof(decimal));
    
            var dailyLateCostParameter = dailyLateCost.HasValue ?
                new ObjectParameter("dailyLateCost", dailyLateCost) :
                new ObjectParameter("dailyLateCost", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddCar", carNumberParameter, currentMilesParameter, imageFileNameParameter, isOK2RentParameter, carModelIDParameter, yearParameter, gearTypeIDParameter, dailyCostParameter, dailyLateCostParameter);
        }
    
        public virtual int AddMessage(string message, Nullable<System.DateTime> dateTime)
        {
            var messageParameter = message != null ?
                new ObjectParameter("message", message) :
                new ObjectParameter("message", typeof(string));
    
            var dateTimeParameter = dateTime.HasValue ?
                new ObjectParameter("dateTime", dateTime) :
                new ObjectParameter("dateTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddMessage", messageParameter, dateTimeParameter);
        }
    
        public virtual int AddReservation(Nullable<int> carFleetID, Nullable<int> userID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> desiredEndDate)
        {
            var carFleetIDParameter = carFleetID.HasValue ?
                new ObjectParameter("carFleetID", carFleetID) :
                new ObjectParameter("carFleetID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var desiredEndDateParameter = desiredEndDate.HasValue ?
                new ObjectParameter("desiredEndDate", desiredEndDate) :
                new ObjectParameter("desiredEndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddReservation", carFleetIDParameter, userIDParameter, startDateParameter, desiredEndDateParameter);
        }
    
        public virtual int AddUser(string userName, string password, string firstName, string lastName, string identityNumber, string email, Nullable<System.DateTime> birthDate, Nullable<int> roleID)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var identityNumberParameter = identityNumber != null ?
                new ObjectParameter("identityNumber", identityNumber) :
                new ObjectParameter("identityNumber", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("birthDate", birthDate) :
                new ObjectParameter("birthDate", typeof(System.DateTime));
    
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("roleID", roleID) :
                new ObjectParameter("roleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", userNameParameter, passwordParameter, firstNameParameter, lastNameParameter, identityNumberParameter, emailParameter, birthDateParameter, roleIDParameter);
        }
    
        public virtual ObjectResult<CheckIfRegistered_Result> CheckIfRegistered(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CheckIfRegistered_Result>("CheckIfRegistered", userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CheckIfRent(Nullable<int> carFleetID)
        {
            var carFleetIDParameter = carFleetID.HasValue ?
                new ObjectParameter("carFleetID", carFleetID) :
                new ObjectParameter("carFleetID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CheckIfRent", carFleetIDParameter);
        }
    
        public virtual ObjectResult<string> CheckIfUserNameExist(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("CheckIfUserNameExist", userNameParameter);
        }
    
        public virtual int DeleteCarFleet(Nullable<int> carFleetID)
        {
            var carFleetIDParameter = carFleetID.HasValue ?
                new ObjectParameter("carFleetID", carFleetID) :
                new ObjectParameter("carFleetID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCarFleet", carFleetIDParameter);
        }
    
        public virtual ObjectResult<GetAllCarFleet_Result> GetAllCarFleet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllCarFleet_Result>("GetAllCarFleet");
        }
    
        public virtual ObjectResult<string> GetAllCarImages()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetAllCarImages");
        }
    
        public virtual ObjectResult<GetAllCloseOrders_Result> GetAllCloseOrders()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllCloseOrders_Result>("GetAllCloseOrders");
        }
    
        public virtual ObjectResult<string> GetAllGearTypes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetAllGearTypes");
        }
    
        public virtual ObjectResult<GetAllManufactureName_Result> GetAllManufactureName()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllManufactureName_Result>("GetAllManufactureName");
        }
    
        public virtual ObjectResult<GetAllModelName_Result> GetAllModelName()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllModelName_Result>("GetAllModelName");
        }
    
        public virtual ObjectResult<GetAllMyOrders_Result> GetAllMyOrders(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllMyOrders_Result>("GetAllMyOrders", userIDParameter);
        }
    
        public virtual ObjectResult<GetAllOpenOrders_Result> GetAllOpenOrders()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllOpenOrders_Result>("GetAllOpenOrders");
        }
    
        public virtual ObjectResult<GetAllOrders_Result> GetAllOrders()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllOrders_Result>("GetAllOrders");
        }
    
        public virtual ObjectResult<GetAvailableCars4Rent_Result> GetAvailableCars4Rent(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAvailableCars4Rent_Result>("GetAvailableCars4Rent", startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<GetCars4Rent_Result> GetCars4Rent()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCars4Rent_Result>("GetCars4Rent");
        }
    
        public virtual ObjectResult<Nullable<int>> GetUserRoleID(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetUserRoleID", userIDParameter);
        }
    
        public virtual int ReturnCar(Nullable<System.DateTime> actualEndDate, Nullable<int> rentalID)
        {
            var actualEndDateParameter = actualEndDate.HasValue ?
                new ObjectParameter("actualEndDate", actualEndDate) :
                new ObjectParameter("actualEndDate", typeof(System.DateTime));
    
            var rentalIDParameter = rentalID.HasValue ?
                new ObjectParameter("rentalID", rentalID) :
                new ObjectParameter("rentalID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ReturnCar", actualEndDateParameter, rentalIDParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int UpdateCarFleet(Nullable<int> carFleetID, string carNumber, Nullable<int> currentMiles, string imageFileName, Nullable<bool> isOK2Rent, Nullable<int> carTypeID, Nullable<int> carModelID, Nullable<int> year, Nullable<int> gearTypeID, Nullable<decimal> dailyCost, Nullable<decimal> dailyLateCost, Nullable<int> carManufactureID, string carModelName, string carManufactureName)
        {
            var carFleetIDParameter = carFleetID.HasValue ?
                new ObjectParameter("carFleetID", carFleetID) :
                new ObjectParameter("carFleetID", typeof(int));
    
            var carNumberParameter = carNumber != null ?
                new ObjectParameter("carNumber", carNumber) :
                new ObjectParameter("carNumber", typeof(string));
    
            var currentMilesParameter = currentMiles.HasValue ?
                new ObjectParameter("currentMiles", currentMiles) :
                new ObjectParameter("currentMiles", typeof(int));
    
            var imageFileNameParameter = imageFileName != null ?
                new ObjectParameter("imageFileName", imageFileName) :
                new ObjectParameter("imageFileName", typeof(string));
    
            var isOK2RentParameter = isOK2Rent.HasValue ?
                new ObjectParameter("isOK2Rent", isOK2Rent) :
                new ObjectParameter("isOK2Rent", typeof(bool));
    
            var carTypeIDParameter = carTypeID.HasValue ?
                new ObjectParameter("carTypeID", carTypeID) :
                new ObjectParameter("carTypeID", typeof(int));
    
            var carModelIDParameter = carModelID.HasValue ?
                new ObjectParameter("carModelID", carModelID) :
                new ObjectParameter("carModelID", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var gearTypeIDParameter = gearTypeID.HasValue ?
                new ObjectParameter("gearTypeID", gearTypeID) :
                new ObjectParameter("gearTypeID", typeof(int));
    
            var dailyCostParameter = dailyCost.HasValue ?
                new ObjectParameter("dailyCost", dailyCost) :
                new ObjectParameter("dailyCost", typeof(decimal));
    
            var dailyLateCostParameter = dailyLateCost.HasValue ?
                new ObjectParameter("dailyLateCost", dailyLateCost) :
                new ObjectParameter("dailyLateCost", typeof(decimal));
    
            var carManufactureIDParameter = carManufactureID.HasValue ?
                new ObjectParameter("carManufactureID", carManufactureID) :
                new ObjectParameter("carManufactureID", typeof(int));
    
            var carModelNameParameter = carModelName != null ?
                new ObjectParameter("carModelName", carModelName) :
                new ObjectParameter("carModelName", typeof(string));
    
            var carManufactureNameParameter = carManufactureName != null ?
                new ObjectParameter("carManufactureName", carManufactureName) :
                new ObjectParameter("carManufactureName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCarFleet", carFleetIDParameter, carNumberParameter, currentMilesParameter, imageFileNameParameter, isOK2RentParameter, carTypeIDParameter, carModelIDParameter, yearParameter, gearTypeIDParameter, dailyCostParameter, dailyLateCostParameter, carManufactureIDParameter, carModelNameParameter, carManufactureNameParameter);
        }
    }
}
