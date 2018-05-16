using architecture.Data;
using architecture.Data.Infrastructure;
using architecture.Data.Repository;
using architecture.Entity;
using architecture.Service.Abstract;
using architecture.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Service.FunctionServices
{
    public class FService : IFunction
    {
        private readonly IEntityBaseRepository<Person> _userRepository;
        
        private readonly IUnitOfWork _IUnitOfWork;

        public FService(IEntityBaseRepository<Person> userRepository, IUnitOfWork IUnitOfWork)
        {
            _userRepository = userRepository;
           _IUnitOfWork = IUnitOfWork;
        }

        //get all record from the database
        public List<PersonVIewModel> getAllList()
        {

            var list = _userRepository.getAll().ToList();
            List<PersonVIewModel> personList = new List<PersonVIewModel>();
            Mapper.Map(list, personList);
            return personList;
        }
       

        //delete person from record

       public  int DeleteRecord(int personpersonId=0)
        {
            var tempDataToDelete = _userRepository.GetSingle(personpersonId);
            try
            {
                _userRepository.SoftDelete(tempDataToDelete);
                _IUnitOfWork.Commit();
                return 1;
            }
            catch(Exception )
            {
                return 0;
            }
        }
        //GetDataById 
        public PersonVIewModel getById(long? id)
        {
            PersonVIewModel pvm = new PersonVIewModel();
            try
            {
                var _tempData = _userRepository.FindBy(x => x.ID == id).ToList();
                //Mapper.Map(_tempData, pvm);
                pvm = (from c in _tempData
                       select new PersonVIewModel
                       {
                           ID = c.ID,
                           Name = c.Name,
                           Age = c.Age,
                           dateOfBirth = c.dateOfBirth

                       }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new PersonVIewModel();
            }

            return pvm;
        }
        //add data to the database
        public void AddData(PersonVIewModel model)
        {
            Person data = new Person();
            try
            {
                 AutoMapper.Mapper.Map<PersonVIewModel, Person>(model,data);
                _userRepository.Add(data);
                _IUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                
            }
            //var data = Mapper.Map<PersonVIewModel, Person>(model);
            
        }
        public int updateEmployee(PersonVIewModel personviewmodel)
        {
            Person data = new Person();
            
            try {
                var oldData = _userRepository.FindBy(x => x.ID == personviewmodel.ID).FirstOrDefault();
                var newdata= Mapper.Map<PersonVIewModel,Person>(personviewmodel);
                newdata.IsDeleted = false;
                _userRepository.Edit(oldData, newdata);
                _IUnitOfWork.Commit();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }
    }
}
