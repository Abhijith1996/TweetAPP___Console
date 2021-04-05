using System;
using System.Collections.Generic;

#nullable disable

namespace com.TweetApp.Model
{
    public partial class Registration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string EmailId { get; set; }
        public string Passcode { get; set; }

        public virtual Tweet Tweet { get; set; }
    }
}
