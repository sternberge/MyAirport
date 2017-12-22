using MyAirport.Pim.Entities;
using MyAirport.Pim.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            // Deux types d'exceptions sont gérés et renvoyés au client
            catch (ArgumentException)
            {
                throw new FaultException(new FaultReason("La Compagnie saisie n'existe pas"));

            }
            catch (SqlException)
            {
                throw new FaultException(new FaultReason("Impossible de se connecter au serveur SQL"));

            }
            return 0;
        }

        public BagageDefinition GetBagageByCodeIata(string codeIata)
        {
            NbAppelsTotal++;
            this.NbAppelsInstance++;
            List<MyAirport.Pim.Entities.BagageDefinition> maListeBagage = new List<MyAirport.Pim.Entities.BagageDefinition>();
            try {
                maListeBagage = Factory.Model.GetBagage((codeIata));
            }
            catch (SqlException)
            {
                throw new FaultException(new FaultReason("Impossible de se connecter au serveur SQL"));

            }

            if (maListeBagage != null)
            {
                if (maListeBagage.Count == 1)
                    return maListeBagage[0];

                else if (maListeBagage.Count > 1)
                {
                    MultipleBagageFault bagages = new MultipleBagageFault();
                    bagages.CodeIata = codeIata;
                    bagages.ListBagages = maListeBagage;
                    bagages.Message = "Il existe " + maListeBagage.Count + " bagages avec le code Iata demandé";
                    throw new FaultException<MultipleBagageFault>(bagages); // création d'une exception qui sera récupérée dans le client
                }

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
