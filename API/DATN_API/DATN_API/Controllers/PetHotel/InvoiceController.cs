using BusinessLogicLayer.BusinessWrapper;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        public InvoiceController(IBusinessWrapper businessWrapper)
        {
            this.businessWrapper = businessWrapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await businessWrapper.invoice.GetAll());
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            return Ok(await businessWrapper.invoice.Delete(id));
        }


        //[HttpPost("nfttoken")]
        //public async Task<Nfttoken> PostCollection()
        //{
        //    MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
        //    var database = dbClient.GetDatabase("Nfts");

        //    var nfttoken = database.GetCollection<Nfttoken>("nfttoken");
        //    var DigitalCollectionId = database.GetCollection<DigitalCollection>("DigitalCollectionId");
        //    var CurrencyId = database.GetCollection<Currency>("CurrencyId");


        //    var nfttokenResult = new Nfttoken();
        //    var digitalCollectionIdResult = new DigitalCollection();
        //    var currencyIdResult = new Currency();



           
        //    string ratity = "0.000001";
        //    var MaxSupply = 10;


        //    for (int i = 1; i < 2; i++)
        //    {

        //        var currencyIdformat = @"{    
                                     
        //                              'Name': 'Vé Thăm May Mắn',
        //                              'Type': 5,
        //                              'Symbol': '',
        //                              'CirculatingSupply': 0,
        //                              'hasMaxSupply': true,
        //                              'MaxSupply': 999999,
        //                              'Network': 3,
        //                              'ContractAddress': 'System',
        //                              'CreatorAddress': 'System',
        //                              'OwnerAddress': 'System',
        //                              'TokenStandard': 0,
        //                              'Icon': ''
        //                            }";
        //        var json = currencyIdformat;

        //        currencyIdResult = JsonConvert.DeserializeObject<Currency>(json);

        //        CurrencyId.InsertOneAsync(currencyIdResult);

        //        if(currencyIdResult._id != null)
        //        {
        //            for (int y = 1; y < 2; y++)
        //            {
                        
        //                var digitalCollectionIdformat = @"{
                                         
        //                                  'Name': '',
        //                                  'Description': '',
        //                                  'ReferenceId': 'CurrencyId/{0}',
        //                                  'DigitalAssetType': 1,
        //                                  'MaxSupply': 999999
        //                                }";

        //                var json2 = digitalCollectionIdformat.Replace("{0}", currencyIdResult._id.ToString());

        //                if (json2 != null && json2 != "")
        //                {
        //                    digitalCollectionIdResult = JsonConvert.DeserializeObject<DigitalCollection>(json2);
        //                }
        //                var postDigitalCollectionId= DigitalCollectionId.InsertOneAsync(digitalCollectionIdResult);

        //                if(digitalCollectionIdResult._id != null)
        //                {
        //                    for (int x = 1; x <= MaxSupply; x++)
        //                    {
        //                        var tokenID = x;

                                
        //                       var nfttokenformat = @"{
                                                          
        //                                                  'DigitalCollectionId': 'Collection/{0}',
        //                                                  'CurrencyId': 'CurrencyId/{1}',
        //                                                  'TokenId': {2},
        //                                                  'AssetURL': '',
        //                                                  'Image': '',
        //                                                  'Icon': '',
        //                                                  'Name': 'Vé Thăm May Mắn #{3}',
        //                                                  'MetaData': {
        //                                                        'Attributes': [
        //                                                           {
        //                                                            'PropertyName': 'Số May Mắn',
        //                                                            'Value': '1',
        //                                                            'Rarity': 0.000001
        //                                                          }
        //                                                        ]
        //                                                      },
        //                                                  'Owner': ''
        //                                                }";


        //                        var json3 = nfttokenformat.Replace("{0}", digitalCollectionIdResult._id.ToString()).Replace("{1}", currencyIdResult._id.ToString()).Replace("{2}", tokenID.ToString()).Replace("{3}", tokenID.ToString()).Replace("{4}", tokenID.ToString()).Replace("{5}", ratity); ;

        //                        if (json != null && json != "")
        //                        {
        //                            nfttokenResult = JsonConvert.DeserializeObject<Nfttoken>(json3);
                                    
        //                        }
        //                        nfttoken.InsertOneAsync(nfttokenResult);




        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return nfttokenResult;

        //}



        //[HttpPost("CollectionOneMilion/coll1")]
        //public async Task<Coll> PostCollectionByParallel()
        //{
        //    MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
        //    var database = dbClient.GetDatabase("PetShop");
        //    var coll = database.GetCollection<Coll>("Coll1");

        //    var response = new Coll();
        //    var primes = new ConcurrentDictionary<Coll, int>();
        //    var CollectionName = "Vé Thăm May Mắn";
        //    string ratity = "0.000001";
        //    Parallel.For(1, 1000000, i =>
        //    {

        //        var tokenID = i;
        //        var format = @"{
        //                      'CollectionName': '{0}',
        //                      'ContractAddress': 'System',
        //                      'CreatorAddress': 'System',
        //                      'CollectionId': 20001,
        //                      'TokenId': {1},
        //                      'TokenStandard': 0,
        //                      'AssetURL': '',
        //                      'Image': '',
        //                      'Icon': '',
        //                      'Name': '{0} #{1}',
        //                      'MetaData': {
        //                        'Attributes': [
        //                          {
        //                            'SoMayMan': {1},
        //                            'rarity:': {2}
        //                          }
        //                        ]
        //                      },
        //                      'Owner': ''

        //                    }";
        //        var json = format.Replace("{0}", CollectionName).Replace("{1}", tokenID.ToString()).Replace("{2}", ratity);

        //        if (json != null && json != "")
        //        {
        //            response = JsonConvert.DeserializeObject<Coll>(json);
        //        }
        //        coll.InsertOneAsync(response);

        //    });

        //    return response;
        //}

    }
}
