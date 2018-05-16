using architecture.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Service.Abstract
{
    public interface IFunction
    {
         List<PersonVIewModel> getAllList();
         void AddData(PersonVIewModel personviewmodel);
         int DeleteRecord(int personId = 0);
         PersonVIewModel getById(long? id);
         int updateEmployee(PersonVIewModel personviewmodel);
    }
}
