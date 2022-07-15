using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandleController : ControllerBase
    {
        [HttpGet("Request")]
        public async Task<IActionResult> handler(string text)
        {
            var chuyendoi = LoaiDau(text).ToLower();
            string strPattern = @"[\s]+";
            Regex rgx = new Regex(strPattern);
            string Ouput = rgx.Replace(chuyendoi, "-");
            return Ok(Ouput);
        }
        [HttpGet]
        public string LoaiDau(string str)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty)
                        .Replace('đ', 'd').Replace('Đ', 'D');
        }
        [HttpPost("iphone13")]
        public async Task<Nfttoken> iphone13()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var database = dbClient.GetDatabase("Nfts");
            var nfttoken = database.GetCollection<Nfttoken>("nfttoken");
            var nfttokenResult = new Nfttoken();
            string ratity = "0.000001";
            var MaxSupply = 999999;
            for (int x = 1; x <= MaxSupply; x++)
            {
                var tokenID = x;
                var format = tokenID.ToString().PadLeft(MaxSupply.ToString().Length, '0');
                var nfttokenformat = @"{     
  'NFTsCollectionId': 'NFTsCollection/3',
  'AssetsId': 'Assets/3',
  'TokenId': {2},
  'AssetURL': '',
  'Image': 'https://bac-img.heineken-starverse.com/photo/Users/Images/Customer/10/products/items/Product/2687/342_342/iphone-13-pro-max-ve-tham-may-man.webp',
  'Icon': 'https://bac-img.heineken-starverse.com/photo/Users/Images/Customer/10/products/items/Product/2687/342_342/iphone-13-pro-max-ve-tham-may-man.webp',
  'Name': 'Vé Thăm May Mắn iPhone 13 # {2}',
  'MetaData': {
        'Attributes': [
           {
            'PropertyName': 'Số May Mắn',
            'Value': '{3}',
            'Rarity': 0.000001
          }
        ]
      },
  'Owner': '',
   'Visible': true,
    'UserGuid': 'Customer/10'
}";


                var json = nfttokenformat.Replace("{2}", tokenID.ToString()).Replace("{5}", ratity).Replace("{3}", format);

                if (json != null && json != "")
                {
                    nfttokenResult = JsonConvert.DeserializeObject<Nfttoken>(json);
                }
                await nfttoken.InsertOneAsync(nfttokenResult);
            }
            return nfttokenResult;
        }
        [HttpPost("loa")]
        public async Task<Nfttoken> loa()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var database = dbClient.GetDatabase("Nfts");
            var nfttoken = database.GetCollection<Nfttoken>("nfttoken");
            var nfttokenResult = new Nfttoken();
            string ratity = "0.000001";
            var MaxSupply = 999999;
            for (int x = 1; x <= MaxSupply; x++)
            {
                var tokenID = x;
                var format = tokenID.ToString().PadLeft(MaxSupply.ToString().Length, '0');
                var nfttokenformat = @"{     
  'NFTsCollectionId': 'NFTsCollection/4',
  'AssetsId': 'Assets/4',
  'TokenId': {2},
  'AssetURL': '',
  'Image': 'https://bac-img.heineken-starverse.com/photo/Users/Images/Customer/10/products/items/Product/2688/342_342/loa-harman-kardon-ve-tham-may-man.webp',
  'Icon': 'https://bac-img.heineken-starverse.com/photo/Users/Images/Customer/10/products/items/Product/2688/342_342/loa-harman-kardon-ve-tham-may-man.webp',
  'Name': 'Vé Thăm May Mắn Loa Harman Kardon # {2}',
  'MetaData': {
        'Attributes': [
           {
            'PropertyName': 'Số May Mắn',
            'Value': '{3}',
            'Rarity': 0.000001
          }
        ]
      },
  'Owner': '',
   'Visible': true,
    'UserGuid': 'Customer/10'
}";


                var json = nfttokenformat.Replace("{2}", tokenID.ToString()).Replace("{5}", ratity).Replace("{3}", format);

                if (json != null && json != "")
                {
                    nfttokenResult = JsonConvert.DeserializeObject<Nfttoken>(json);
                }
                await nfttoken.InsertOneAsync(nfttokenResult);
            }
            return nfttokenResult;
        }
        [HttpPost("SaigonCentre")]
        public async Task<Nfttoken> SaigonCentre()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://heineken:0MfKs8PRBRfYpazG@heineken-prod.enndt.mongodb.net/test");
            var database = dbClient.GetDatabase("Heineken");
            var nfttoken = database.GetCollection<Nfttoken>("NFTsToken");
            var nfttokenResult = new Nfttoken();
            string ratity = "0.000001";
            var MaxSupply = 50000;
            for (int x = 1; x <= MaxSupply; x++)
            {
                var tokenID = x;
                var format = tokenID.ToString().PadLeft(MaxSupply.ToString().Length, '0');
                var nfttokenformat = @"{     
  'NFTsCollectionId': 'NFTsCollection/6',
  'AssetsId': 'Assets/6',
  'TokenId': {2},
  'AssetURL': '',
  'Image': 'https://bac-img.heineken-starverse.com/Photo/Users/Images/Customer/10/layouts/ContentBlock/Group46343.jpg',
  'Icon': 'https://bac-img.heineken-starverse.com/Photo/Users/Images/Customer/10/layouts/ContentBlock/Group46343.jpg',
  'Name': 'Vé Thăm May Mắn Saigon Centre # {2}',
  'MetaData': {
        'Attributes': [
           {
            'PropertyName': 'Số May Mắn',
            'Value': '{3}',
            'Rarity': 0.000001
          }
        ]
      },
  'Owner': '',
   'Visible': true,
    'UserGuid': 'Customer/10'
}";


                var json = nfttokenformat.Replace("{2}", tokenID.ToString()).Replace("{5}", ratity).Replace("{3}", format);

                if (json != null && json != "")
                {
                    nfttokenResult = JsonConvert.DeserializeObject<Nfttoken>(json);
                }
                await nfttoken.InsertOneAsync(nfttokenResult);
            }
            return nfttokenResult;
        }
        [HttpPost("TrucNhan")]
        public async Task<Nfttoken> TrucNhan()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://heineken:0MfKs8PRBRfYpazG@heineken-prod.enndt.mongodb.net/test");
            var database = dbClient.GetDatabase("Heineken");
            var nfttoken = database.GetCollection<Nfttoken>("NFTsToken");
            var nfttokenResult = new Nfttoken();
            string ratity = "0.000001";
            var MaxSupply = 4500;
            for (int x = 1; x <= MaxSupply; x++)
            {
                var tokenID = x;
                var format = tokenID.ToString().PadLeft(MaxSupply.ToString().Length, '0');
                var nfttokenformat = @"{     
  'NFTsCollectionId': 'NFTsCollection/7',
  'AssetsId': 'Assets/7',
  'TokenId': {2},
  'AssetURL': '',
  'Image': 'https://bac-img.heineken-starverse.com/photo/Users/Images/Customer/10/products/items/Product/2697/342_342/truc-nhan-chiec-hop-bi-an.webp',
  'Icon': 'https://bac-img.heineken-starverse.com/photo/Users/Images/Customer/10/products/items/Product/2697/342_342/truc-nhan-chiec-hop-bi-an.webp',
  'Name': 'Trúc Nhân - Chiếc hộp bí ẩn # {2}',
  'MetaData': {
        'Attributes': [
           {
            'PropertyName': '???',
            'Value': '???',
            'Rarity': 0.002
          }
        ]
      },
  'Owner': '',
   'Visible': true,
    'UserGuid': 'Customer/10'
}";


                var json = nfttokenformat.Replace("{2}", tokenID.ToString()).Replace("{5}", ratity).Replace("{3}", format);

                if (json != null && json != "")
                {
                    nfttokenResult = JsonConvert.DeserializeObject<Nfttoken>(json);
                }
                await nfttoken.InsertOneAsync(nfttokenResult);
            }
            return nfttokenResult;
        }
        [HttpPost("MinhTu")]
        public async Task<Nfttoken> MinhTu()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://heineken:0MfKs8PRBRfYpazG@heineken-prod.enndt.mongodb.net/test");
            var database = dbClient.GetDatabase("Heineken");
            var nfttoken = database.GetCollection<Nfttoken>("NFTsToken");
            var nfttokenResult = new Nfttoken();
            string ratity = "0.000001";
            var MaxSupply = 4500;
            for (int x = 1; x <= MaxSupply; x++)
            {
                var tokenID = x;
                var format = tokenID.ToString().PadLeft(MaxSupply.ToString().Length, '0');
                var nfttokenformat = @"{     
  'NFTsCollectionId': 'NFTsCollection/8',
  'AssetsId': 'Assets/8',
  'TokenId': {2},
  'AssetURL': '',
  'Image': 'https://bac-img.heineken-starverse.com/photo/Users/Images/Customer/10/products/items/Product/2696/342_342/minh-tu-chiec-hop-bi-an.webp',
  'Icon': 'https://bac-img.heineken-starverse.com/photo/Users/Images/Customer/10/products/items/Product/2696/342_342/minh-tu-chiec-hop-bi-an.webp',
  'Name': 'Minh Tú - Chiếc hộp bí ẩn # {2}',
  'MetaData': {
        'Attributes': [
           {
            'PropertyName': '???',
            'Value': '???',
            'Rarity': 0.002
          }
        ]
      },
  'Owner': '',
   'Visible': true,
    'UserGuid': 'Customer/10'
}";


                var json = nfttokenformat.Replace("{2}", tokenID.ToString()).Replace("{5}", ratity).Replace("{3}", format);

                if (json != null && json != "")
                {
                    nfttokenResult = JsonConvert.DeserializeObject<Nfttoken>(json);
                }
                await nfttoken.InsertOneAsync(nfttokenResult);
            }
            return nfttokenResult;
        }
    }
}

