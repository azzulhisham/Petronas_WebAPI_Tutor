using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Test.Models
{
    public class UserDownloadSession
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string AppUID { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public DateTime InstallTimeStamp { get; set; }
        public string Remark { get; set; }
    }
}