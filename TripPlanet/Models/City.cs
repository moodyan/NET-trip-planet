using Geocoding;
using Geocoding.Google;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    [Table("Cities")]
    public class City
    {
        public City()
        {
            this.Lodgings = new HashSet<Lodging>();
            this.Activities = new HashSet<Activity>();
        }
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [DisplayName("Arrival Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ArrivalDate { get; set; }
        [DisplayName("Departure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DepartureDate { get; set; }
        public virtual ICollection<TripCity> TripCities { get; set; }
        public virtual ICollection<CityTransportation> CityTransportations { get; set; }
        public virtual ICollection<Lodging> Lodgings { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }

        

        //public static Location GetLatLong(string address, City city)
        //{
        //    RestClient client = new RestClient("https://maps.googleapis.com/maps/api/geocode");
        //    RestRequest request = new RestRequest($"/json?address={address}&key={EnvironmentVariables.GeocodingAPI}", Method.GET);
            
        //    RestResponse response = new RestResponse();

        //    Task.Run(async () =>
        //    {
        //        response = await GetResponseContentAsync(client, request) as RestResponse;
        //    }).Wait();
        //    //var root = JsonConvert.DeserializeObject<RootObject>(response.Content);
        //    //Location location = root.
        //    //foreach (var singleResult in root.results)
        //    //{
        //    //    var location = singleResult.geometry.location;
        //    //    var latitude = location.lat;
        //    //    var longitude = location.lng;
        //    //}

        //    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        //    var geocodeLocation = new Location();
            
        //    geocodeLocation = JsonConvert.DeserializeObject<Location>(jsonResponse["location"].ToString());

            
        //    //Debug.WriteLine(root);

        //    return geocodeLocation;
        //}

        //public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        //{
        //    var tcs = new TaskCompletionSource<IRestResponse>();
        //    theClient.ExecuteAsync(theRequest, response =>
        //    {
        //        tcs.SetResult(response);
        //    });
        //    return tcs.Task;
        //}
    }
}
