using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class New
    {
        public int NewID { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public UserPerson User { get; set; }
        public int UserID { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}
