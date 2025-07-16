using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
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
    public static class ProductConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {
                map.AutoMap();

                // Configurar ID como string
                map.MapIdProperty(x => x.Id)
                   .SetSerializer(new GuidSerializer(BsonType.String));

                // Mapear propriedades com nomes customizados (opcional)
                map.MapProperty(x => x.Title).SetElementName("title");
                map.MapProperty(x => x.Price).SetElementName("price");
                map.MapProperty(x => x.Description).SetElementName("description");
                map.MapProperty(x => x.Category).SetElementName("category");
                map.MapProperty(x => x.Image).SetElementName("image");
                map.MapProperty(x => x.Rating).SetElementName("rating");
            });

            // Configurar enums (se ProductCategory for enum)
            BsonClassMap.RegisterClassMap<ProductCategory>(map =>
            {              
                map.AutoMap();
                // Adicione configurações específicas se necessário
            });

            // Configurar Rating se for uma classe
            BsonClassMap.RegisterClassMap<Rating>(map =>
            {
                map.AutoMap();
                // Adicione configurações específicas
            });
        }
    }
}
