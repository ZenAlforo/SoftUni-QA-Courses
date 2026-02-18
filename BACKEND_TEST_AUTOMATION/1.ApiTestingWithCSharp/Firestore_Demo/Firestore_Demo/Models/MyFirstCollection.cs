using Google.Cloud.Firestore;

namespace Firestore_Demo.Models
{
    [FirestoreData]
    public class Collection
    {
        public string DocumentId { get; set; }

        [FirestoreProperty]
        public string Title { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }
    }
}