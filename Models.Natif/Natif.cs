using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirport.Pim.Models
{
    public class Natif: AbstractDefinition
    {
        List<BagageDefinition> bagages = new List<BagageDefinition>();
        public override Entities.BagageDefinition GetBagage(int idBagage)
        {
            throw new NotImplementedException();
        }

        public override List<Entities.BagageDefinition> GetBagage(string codeIataBagage)
        {
            bagages.Add(new BagageDefinition() { CodeIata = "01234567", Compagnie = "LH" });
            return bagages;

            // throw new NotImplementedException();
        }

        public override int CreateBagage(BagageDefinition bag)
        {
            throw new NotImplementedException();
        }

    }
}
