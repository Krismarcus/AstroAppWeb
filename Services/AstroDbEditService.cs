using System.Net.Http.Json;
using System.Text.Json;
using Astrodaiva.Data.Models;

namespace Astrodaiva.Blazor.Services
{
    public class AstroDbEditService
    {
        private readonly HttpClient _http;

        public AstroDbEditService(HttpClient http)
        {
            _http = http;
        }

        public AppDB? Db { get; private set; }

        public bool IsLoaded => Db is not null;

        public async Task<AppDB?> EnsureLoadedAsync()
        {
            if (Db is not null)
                return Db;

            try
            {
                Db = await _http.GetFromJsonAsync<AppDB>("data/astrodb.json");
            }
            catch
            {
                Db = null;
            }

            return Db;
        }
    }
}
