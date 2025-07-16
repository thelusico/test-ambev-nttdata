using Ambev.DeveloperEvaluation.Domain.ValueObjects;
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
    public class CustomerInfoConfiguration
    {

        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<CustomerInfo>(map =>
            {
                map.AutoMap();

                map.MapProperty(x => x.UserId)
                   .SetSerializer(new GuidSerializer(BsonType.String))
                   .SetElementName("userId");
            });
        }

    }
}
