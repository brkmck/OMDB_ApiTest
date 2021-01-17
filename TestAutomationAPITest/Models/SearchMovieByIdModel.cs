using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Net;


namespace TestAutomationAPITest.Models
{
    public class SearchMovieByIdModel
    {
        const string BASE_URL = "http://www.omdbapi.com/";

        public string GetMovieIDBySearch(string search, string movieName)
        {
            RestClient client = new RestClient(BASE_URL);
            JsonDeserializer deserialize = new JsonDeserializer();

            string movieImdbID = null;
            string movieSearch = search.Replace(' ', '+');

            var request = new RestRequest($"?s={search}&apikey=bbae84e3", Method.GET);
            request.AddUrlSegment("movieSearch", movieSearch);

            var response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var movieList = deserialize.Deserialize<Dictionary<string, List<string>>>(response);
            var movieListSearch = movieList["Search"];
            foreach (var item in movieListSearch)
            {
                if (item.Contains(movieName))
                {
                    var movie = item.Split(',');
                    movieImdbID = movie[2].Split('"')[3];
                    return movieImdbID;
                }

            }
            return movieImdbID;
        }

        public Dictionary<string, string> GetMovieInfosById(string movieId)
        {
            RestClient client = new RestClient(BASE_URL);
            JsonDeserializer deserialize = new JsonDeserializer();

            var request = new RestRequest($"?i={movieId}&apikey=bbae84e3", Method.GET);

            var response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var movieInfo = deserialize.Deserialize<Dictionary<string, string>>(response);

            return movieInfo;
        }
    }
}
