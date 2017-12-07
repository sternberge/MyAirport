using MyAirport.Pim.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyAirport.Pim.Service
{
    [ServiceContract]
    public interface IServicePim
    {
        [OperationContract]
        BagageDefinition GetBagageById(int idBagage);
        [OperationContract]
        BagageDefinition GetBagageByCodeIata(string codeIata);
        [OperationContract]
        int CreateBagage(BagageDefinition bag);
        
    }
}

