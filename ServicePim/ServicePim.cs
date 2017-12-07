using MyAirport.Pim.Entities;
using MyAirport.Pim.Models;
using System;
using System.Collections;
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
        int NbAppelsTotal = 0;
        int NbAppelsInstance = 0;
        public int CreateBagage(BagageDefinition bag)
        {
            try
            {
                Factory.Model.CreateBagage(bag);
            }
            catch (ArgumentException)
            {
                throw new FaultException(new FaultReason("La Compagnie saisie n'existe pas"));

            }
            return 0;
        }

        public BagageDefinition GetBagageByCodeIata(string codeIata)
        {
            NbAppelsTotal++;
            this.NbAppelsInstance++;
            List<MyAirport.Pim.Entities.BagageDefinition> maListeBagage = new List<MyAirport.Pim.Entities.BagageDefinition>();
            maListeBagage = Factory.Model.GetBagage((codeIata));
            if (maListeBagage != null)
            {
                if (maListeBagage.Count == 1)
                    return maListeBagage[0];
                else
                    throw new FaultException(new FaultReason("Il existe " + maListeBagage.Count + " bagages avec le code Iata demandé"), new FaultCode("MultipleBagage"));
                
            }
            else
                return null;
        }

        public BagageDefinition GetBagageById(int idBagage)
        {
            return MyAirport.Pim.Models.Factory.Model.GetBagage(idBagage);
        }
        
        
    }
}
