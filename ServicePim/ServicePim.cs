using MyAirport.Pim.Entities;
using MyAirport.Pim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyAirport.Pim.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ServicePim : IServicePim
    {
        public int CreateBagage(BagageDefinition bag)
        {
            Factory.Model.CreateBagage(bag);
            return 0;
        }

        public BagageDefinition GetBagageByCodeIata(string codeIata)
        {
            List<MyAirport.Pim.Entities.BagageDefinition> maListeBagage = new List<MyAirport.Pim.Entities.BagageDefinition>();
            maListeBagage = Factory.Model.GetBagage((codeIata));
            if (maListeBagage.Count == 1)
                return maListeBagage[0];
            else
                return null;
        }

        public BagageDefinition GetBagageById(int idBagage)
        {
            return MyAirport.Pim.Models.Factory.Model.GetBagage(idBagage);
        }


        
    }
}
