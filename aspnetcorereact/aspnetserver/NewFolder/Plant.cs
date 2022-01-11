using System.ComponentModel.DataAnnotations;

namespace aspnetserver.NewFolder
{
    internal sealed class Plant
    {
        [Key]
        public int plantId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public bool WateringStatus { get; set; } = false;

        [Required]
        public DateTime lastWatered { get; set; } = new DateTime();
    }
}
