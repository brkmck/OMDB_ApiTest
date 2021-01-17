using NUnit.Framework;
using System.Collections.Generic;
using TestAutomationAPITest.Models;

namespace TestAutomationAPITest.Tests
{
    public class SearchMovieByIdTest
    {
        private const string EXPECTED_IMDB_ID = "tt0241527";
        private const string EXPECTED_TITLE = "Harry Potter and the Sorcerer's Stone";
        private const string EXPECTED_YEAR = "2001";
        private const string EXPECTED_RELEASED = "16 Nov 2001";

        [Test]
        public void MovieTest()
        {
            SearchMovieByIdModel model = new SearchMovieByIdModel();
            const string searchMovie = "Harry Potter";
            const string movieName = "Harry Potter and the Sorcerer's Stone";

            //Get movie id by search
            string movieImdbId = model.GetMovieIDBySearch(searchMovie, movieName);
            Assert.AreEqual(EXPECTED_IMDB_ID, movieImdbId);

            //Get movie infos by id
            Dictionary<string, string> movieInfo = model.GetMovieInfosById(movieImdbId);
            string movieTitle = movieInfo["Title"];
            string movieYear = movieInfo["Year"];
            string movieReleased = movieInfo["Released"];

            Assert.AreEqual(EXPECTED_TITLE, movieTitle);
            Assert.AreEqual(EXPECTED_YEAR, movieYear);
            Assert.AreEqual(EXPECTED_RELEASED, movieReleased);
        }
    }
}
