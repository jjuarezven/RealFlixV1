using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealFlix.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string Language { get; set; }
        public string Genres { get; set; }
        public string Status { get; set; }
        public int? Runtime { get; set; }
        public DateTime? Premiered { get; set; }
        public string OfficialSite { get; set; }
        public string ScheduledTime { get; set; }
        public string ScheduledDays { get; set; }
        public int? RatingAverage { get; set; }
        public int? Weight { get; set; }
        public int? NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string NetworkCountryName { get; set; }
        public string NetworkCountryCode { get; set; }
        public string WebChannel { get; set; }
        [Column(TypeName = "decimal(2,2)")]
        public decimal? ExternalsTvrage { get; set; }
        [Column(TypeName = "decimal(2,2)")]
        public decimal? ExternalsThetvdb { get; set; }
        [Column(TypeName = "decimal(2,2)")]
        public decimal? ExternalsImdb { get; set; }
        public string ImageMedium { get; set; }
        public string ImageOriginal { get; set; }
        public string Summary { get; set; }
        public DateTime? Updated { get; set; }
        public string LinksSelfHref { get; set; }
        public string LinksPreviousEpisodeHref { get; set; }
        public string LinksNextEpisodeHref { get; set; }
        public string Keywords { get; set; }

    }
}
