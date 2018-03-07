using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banka.Models;
namespace Banka.Repository.Interfaces
{
    public interface IRacunRepo
    {
        IEnumerable<Racun> GetAll();
        void Create();
        void Edit();
        void Delete();
        Racun GetById(int id);
    }
}
