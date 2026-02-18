using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Firestore_Demo.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace Firestore_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string projectId;
        private readonly FirestoreDb database;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            var filePath = Path.GetFullPath("./zenalforo-9c5c4-firebase-adminsdk-fbsvc-b5c536b428.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _logger = logger;
            _configuration = configuration;
            projectId = _configuration.GetValue<string>("Firestore_API:project_id");
            database = FirestoreDb.Create(projectId);
        }

        public async Task<IActionResult> Index()
        {
            Query documentsQuery = database.Collection("MyFirstCollection");
            QuerySnapshot documentsSnapshot = await documentsQuery.GetSnapshotAsync();
            List<Collection> collections = new List<Collection>();

            foreach (DocumentSnapshot collectionData in documentsSnapshot.Documents)
            {
                Dictionary<string, object> currentCollections = collectionData.ToDictionary();
                string json = JsonSerializer.Serialize(currentCollections);
                Collection currentCollection = JsonSerializer.Deserialize<Collection>(json);
                currentCollection.DocumentId = collectionData.Id;
                collections.Add(currentCollection);
            }
            return View(collections);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Collection());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Collection model)
        {
            CollectionReference collections = database.Collection("Collections");

            if (string.IsNullOrWhiteSpace(model.Title) && string.IsNullOrWhiteSpace(model.Description))
            {
                return View(model);
            }
            await collections.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}