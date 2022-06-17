using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.OwnerModels.PetHotelModel.Base;

namespace Entities
{
    public class Nfts
    { 
        public Nfttoken nfttoken { get; set; }
        public DigitalCollection digitalcollection { get; set; }
        public Currency currency { get; set; }
    }
    public partial class Nfttoken : BaseModel
    {
        
        public string DigitalCollectionId { get; set; }
        public string CurrencyId { get; set; }
        public long? TokenId { get; set; }
        public string AssetUrl { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public MetaData MetaData { get; set; }
        public string Owner { get; set; }


    }

    public partial class MetaData
    {
        public List<Attribute> Attributes { get; set; }
    }

    public partial class Attribute
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public double Rarity { get; set; }
    }
}
