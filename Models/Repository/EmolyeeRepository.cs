using Api.Data;
using Api.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace Api.Models.Repository
{
    public class EmolyeeRepository : IbaseRepository<Employee , EmployeeModel>
    {
        private readonly ApplicationDbContext context;

        public EmolyeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(EmployeeModel employee)
        {

            if (employee != null)
            {
                var emp = new Employee
                {
                    Name = employee.Name,
                    Phone = employee.Phone,
                    Salary = employee.Salary,
                };

                context.Employees.Add(emp);
                context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var emp = context.Employees.FirstOrDefault(x => x.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();

        }

        public void DeleteByName(string name)
        {
            var emp = context.Employees.FirstOrDefault(x => x.Name == name);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            var emp = context.Employees.FirstOrDefault(x => x.Id == id);
            return emp;
        }

        public Employee GetByName(string name)
        {
            var emp = context.Employees.FirstOrDefault(x => x.Name == name);
            return emp;
        }

        void IbaseRepository<Employee, EmployeeModel>.Add(EmployeeModel entity)
        {
            throw new NotImplementedException();
        }

        //public Employee UpdateEmployee(int id, Employee emp)
        //{
        //    var existemp = context.Employees.FirstOrDefault(x => x.Id == id);

        //    existemp.Name = emp.Name;
        //    existemp.Phone = emp.Phone;
        //    existemp.Salary = emp.Salary;
        //    context.SaveChanges();
        //    return existemp;
        //}

        Employee IbaseRepository<Employee, EmployeeModel>.Update(int id, EmployeeModel entity)
        {
            var existemp = context.Employees.FirstOrDefault(x => x.Id == id);
            existemp.Name = entity.Name;
            existemp.Phone = entity.Phone;
            existemp.Salary = entity.Salary;
            context.SaveChanges();
            return existemp;
        }

        Employee IbaseRepository<Employee , EmployeeModel>.UpdateWithPatch(JsonPatchDocument<Employee> entity, int id)
        {
            var oldemp = GetById(id);
            if (oldemp != null)
            {
                entity.ApplyTo(oldemp);
                context.SaveChanges();
                return oldemp;
            }
            return null;

        }
    }
}
