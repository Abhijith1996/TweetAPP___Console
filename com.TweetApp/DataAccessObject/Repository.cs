using com.TweetApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.TweetApp.DataAccessObject
{
    class Repository : IRepository
    {
        //private readonly TweetAppContext dbContext;
        //public Repository(TweetAppContext tweetAppContext)
        //{
        //     dbContext = tweetAppContext;

        //}
        private TweetAppContext dbContext;
        public Repository()
        {
            this.dbContext = new TweetAppContext();

        }
        public bool UserLogin(string emailId, string password)
        {
            var regUserDetails = dbContext.Registrations
                                      .Where(s => s.EmailId == emailId && s.Passcode == password).FirstOrDefault();
            if (regUserDetails != null)
                return true;
            else
                return false;
        }

        public bool UserRegistration(Registration reg)
        {
            try
            {
                dbContext.Registrations.Add(reg);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public bool PostTweet(Tweet tweet)
        {
            try
            {
                dbContext.Tweets.Add(tweet);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }
        public List<Tweet> GetTweetById(string EmailID)
        {
            List<Tweet> tweetAll = new List<Tweet>();

            tweetAll = dbContext.Tweets.Where(x => x.EmailId == EmailID).ToList<Tweet>();
            return tweetAll;
        }
        public List<Tweet> GetAllTweet()
        {
            List<Tweet> tweetAll = new List<Tweet>();
            tweetAll = dbContext.Tweets.ToList();
            return tweetAll;
        }

        public bool ForgetPassword(string user, DateTime dob, string pass)
        {
            var result=dbContext.Registrations.Where(x => x.EmailId == user && x.Dob == dob).FirstOrDefault();
            if (result != null)
            {
                result.Passcode = pass;
                dbContext.SaveChanges();
                return true;

            }
        
            else
                return false;
        }


        public bool ResetPassword(string user, string oldpass, string pass)
        {
            var result = dbContext.Registrations.Where(x => x.EmailId == user && x.Passcode == oldpass).FirstOrDefault();
            if (result != null)
            {
                result.Passcode = pass;
                dbContext.SaveChanges();
                return true;

            }

            else
                return false;
        }




    }
}
