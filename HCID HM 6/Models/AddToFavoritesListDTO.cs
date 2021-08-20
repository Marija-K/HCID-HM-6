using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCID_HM.Models
{
    public class AddToFavoritesListDTO
    {
        public Topic SelectedTopic { get; set; }
        public int TopicId { get; set; }
    }
}
