using System.ComponentModel.DataAnnotations;

namespace Lemoras.Remora.Roomshare.Api.Models
{
    public class PostAdvertRequest
    {
        [Required]
        public Domain.Enums.AdvertType AdvertType { get; set; }

        [Required]
        public int HouseId { get; set; }
    }
}
