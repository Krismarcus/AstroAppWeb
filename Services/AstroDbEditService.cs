using System.IO;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
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

        // ALWAYS load fresh JSON from disk
        public async Task<AppDB?> ForceReloadAsync()
        {
            Db = await _http.GetFromJsonAsync<AppDB>("data/astrodb.json");
            return Db;
        }

        // Load only if not loaded yet
        public async Task<AppDB?> EnsureLoadedAsync()
        {
            if (Db is null)
                Db = await _http.GetFromJsonAsync<AppDB>("data/astrodb.json");

            return Db;
        }

        // Replace DB with revert snapshot
        public void ReplaceDb(AppDB newDb)
        {
            Db = newDb;
        }

        // Clear DB when leaving Admin page
        public void ClearDb()
        {
            Db = null;
        }

        // Save the current in-memory DB to JSON file
        public async Task SaveAsync()
        {
            if (Db is null)
                return;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(Db, options);

            var physicalPath = Path.Combine("wwwroot", "data", "astrodb.json");
            var directory = Path.GetDirectoryName(physicalPath);

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            await File.WriteAllTextAsync(physicalPath, json);
        }
    }
}
