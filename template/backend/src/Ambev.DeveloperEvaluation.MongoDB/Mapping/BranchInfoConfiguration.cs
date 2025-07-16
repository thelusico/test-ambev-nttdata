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
    public class BranchInfoConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BranchInfo>(map =>
            {
                map.AutoMap();
                map.MapProperty(x => x.BranchId)
                   .SetSerializer(new GuidSerializer(BsonType.String))
                   .SetElementName("branchId");               
            });
        }

    }
}
