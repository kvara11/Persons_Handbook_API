using System.ComponentModel.DataAnnotations;

namespace Persons_Handbook_API.Models
{
    public class Photos
    {
        public int Id { get; set; }
        public int PersonID { get; set; }

        [DataType(DataType.Text)]
        public string? PhotoLocation { get; set; }
    }
}
