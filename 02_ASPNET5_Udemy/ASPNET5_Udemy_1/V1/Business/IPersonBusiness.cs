using ASPNET5_Udemy_1.Model;
using System.Collections.Generic;

namespace ASPNET5_Udemy_1.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
