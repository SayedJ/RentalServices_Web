
namespace RentalServicesWebApi.Models
{
    public class UploadedFiles
    {

        public int Id { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadedBy { get; set; }
        public byte[] FileContent { get; set; }
    }
}