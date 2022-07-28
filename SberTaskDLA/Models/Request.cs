using SberTaskDLA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberTaskDLA.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public RequestType requestType { get; set; }
        public RequestStatus requestStatus { get; set; }

        public int OperatorId { get; set; }
        public int RequestTypeId { get; set; }
        public int RequestStatusId { get; set; }
    }
}
