using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Art_Shop_Data.Model
{
    public class Identity
    {

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public String CreatedBy { get; set; }

        public DateTime ChangedOn { get; set; }

        public String ChangedBy { get; set; }
    }
}
