using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HCID_HM.Models
{
    public class FavoritesList
    {
        [Key]
        public int FavoritesListId { get; set; }
        public string UserId { get; set; }
        public ICollection<TopicInFavoritesList> TopicsInFavoritesList { get; set; }

    }
}
