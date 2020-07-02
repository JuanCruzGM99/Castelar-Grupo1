using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class Error : Identity
    {

        public int UserId { get; set; }

        public DateTime ErrorDate { get; set; }

        public String IpAddress { get; set; }

        public String Exception { get; set; }

        public String Message { get; set; }

        public String Everything { get; set; }

        public String HttpReferer { get; set; }

        public String PathAndQuery { get; set; }

        public Error()
        {
                
        }

        public Error(int id, int UserId, DateTime ErrorDate, String IpAddress, String Exception, String Message, String EveryThing, String HttpReferer, String PathAndQuery, DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {
            this.Id = id;
            this.UserId = UserId;
            this.ErrorDate = ErrorDate;
            this.IpAddress = IpAddress;
            this.Exception = Exception;
            this.Message = Message;
            this.Everything = Everything;
            this.HttpReferer = HttpReferer;
            this.PathAndQuery = PathAndQuery;
            this.CreatedOn = CreatedOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;

        }

    }
}
