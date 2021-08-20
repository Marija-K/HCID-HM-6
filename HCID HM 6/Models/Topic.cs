using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HCID_HM.Models
{
    public class Topic
    {
        [Key]
        public int  TopicId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime Event { get; set; }

        public ICollection<TopicInFavoritesList> TopicInFavoritesLists { get; set; }

    }
}
