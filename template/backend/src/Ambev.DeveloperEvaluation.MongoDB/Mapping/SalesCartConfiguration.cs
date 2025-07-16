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
    public class SalesCartConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<SalesCart>(map =>
            {
                map.AutoMap();

                // Configurar ID como string
                map.MapIdProperty(x => x.Id)
                   .SetSerializer(new GuidSerializer(BsonType.String));            
            });
        }
    }
}
