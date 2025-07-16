using Ambev.DeveloperEvaluation.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.MongoDB.Mapping
{
    public class SalesCartItemConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<SalesCartItem>(map =>
            {
                map.AutoMap();
                // Configurar ProductId como string
                map.MapProperty(x => x.ProductId)
                   .SetSerializer(new GuidSerializer(BsonType.String))
                   .SetElementName("productId");                
            });
        }

    }
}
