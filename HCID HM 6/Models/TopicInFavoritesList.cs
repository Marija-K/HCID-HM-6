using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HCID_HM.Models
{
    public class TopicInFavoritesList
    {
        public int TopicId { get; set; }
        public int FavoritesListId { get; set; }
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }
        [ForeignKey("FavoritesListId")]
        public FavoritesList FavoritesList { get; set; }
    }
}
