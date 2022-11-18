using System.ComponentModel.DataAnnotations;

namespace Persons_Handbook_API.Models
{
    public class Persons
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstname must be 2-50 length")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only ENG letters")]
        public string Firstname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname must be 2-50 length")]
        public string Lastname { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Personal Number must be 11")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Personal Number must be numeric")]
        public string PersonalNumber { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //[MinAge(18)]
        //public DateTime? DateOfBirth { get; set; }
        public string? City { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Phone must be 4-50 length")]
        public string Phone { get; set; }

        [DataType(DataType.Text)]
        public string PhotoID { get; set; }
        public string RelatedPersons { get; set; }

    }

    public enum Gender
    {
        Male, Female
    }
}
