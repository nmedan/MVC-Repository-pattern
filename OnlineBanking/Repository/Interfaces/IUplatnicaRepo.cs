using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banka.Models;
namespace Banka.Repository.Interfaces
{
    public interface IUplatnicaRepo
    {
        IEnumerable<Uplatnica> GetAll(int id);
        void Create(Uplatnica uplatnica, int id);
        void Edit(Uplatnica uplatnica);
        void Delete(int id);
        Uplatnica GetById(int id);
    }
}
