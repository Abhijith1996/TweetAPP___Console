using System;
using System.Collections.Generic;

#nullable disable

namespace com.TweetApp.Model
{
    public partial class Tweet
    {
        public string EmailId { get; set; }
        public DateTime? TweetTime { get; set; }
        public string TweetMessage { get; set; }

        public virtual Registration Email { get; set; }
    }
}
