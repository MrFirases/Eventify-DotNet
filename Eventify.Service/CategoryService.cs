using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Infrastructure;
using Eventify.Data.Models;
using Service.Pattern;
using System.IO;
using TweetSharp;
using static System.Net.Mime.MediaTypeNames;

namespace Eventify.Service
{
    public class CategoryService : MyServiceGeneric<Category>,ICategoryService
    {

        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public CategoryService() : base(itw)
        {

        }

        public bool addCategory(Category cateegory)
        {
            
            try
            {

                itw.getRepository<Category>().Add(cateegory);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
          
            
            
        }

      
        public bool deteCategory(int idCategory)
        {
            try
            {

             Category categorie=   itw.getRepository<Category>().GetById(idCategory);
                itw.getRepository<Category>().Delete(categorie);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public IEnumerable<Category> getAllCategory()
        {
            return itw.getRepository<Category>()
                .GetMany();
        }

        public Category getCategoryById(int idCategory)
        {
           
            Category categorie = itw.getRepository<Category>().GetById(idCategory);
            return categorie;
        }

        public IEnumerable<Category> getCategoryByName()
        {
            throw new NotImplementedException();
        }

       


        public bool updateCategory(Category category)
        {
            try
            {
             
                itw.getRepository<Category>().Update(category);
                
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public int categoryPerUser(int idCategory)
        {
            IEnumerable<Favorite> favories = itw.getRepository<Favorite>().GetMany(f => f.categoryId == idCategory);
            if (favories == null)
            {
                return 0;
            }
            else
            {
                int counted = favories.Select(u => u.userId).Distinct().Count();
                return counted;
            }


        }

        public int totalCategoryUsers()
        {
            
            IEnumerable<Favorite> favories = itw.getRepository<Favorite>().GetMany();
            if (favories == null)
            {
                return 0;
            }
            else
            {
                return favories.Select(f => f.userId).Distinct().Count();
            }
        }

        public List<Tuple<int, int>> mostUsedCategory()
        {
            // IEnumerable<IGrouping<int, Category>> groupCat = null;
            List<Tuple<int, int>> Favcat= new List<Tuple<int, int>>();
            IEnumerable<int> catids = itw.getRepository<Favorite>().GetMany().Select(f => f.categoryId ).Distinct();
            List<int> categoid = new List<int>();
            foreach (int catid in catids)
            {
               
                categoid.Add(catid);
            }
            foreach (int  item in categoid)
            {
                System.Diagnostics.Debug.WriteLine(item +"  "+ categoryPerUser(item));
                Favcat.Add(new Tuple<int, int>(item, categoryPerUser(item)));
            }
            Favcat.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            
            


            return Favcat;
            
        }

        public void twitterCategory()
        {
          //    string _consumerKey = "r9ourmJGw565hd9mTgown89US"; // Your key
          //string _consumerSecret = "cjKp7ftZWKGd8kMTDh61mS8YRxM2hWbqV5UdV1vjpNKKXou3VO"; // Your key  
          //    string _accessToken = "2369334732-SytOgpaApi98Ts8GRb5q6vfxn1lJRIX6V2ko3db"; // Your key  
          //     string _accessTokenSecret = "dUgLrr4yLea4VBlQjkJv0LTLnuvpy2h5PrGNBGcb2P3qU"; // Your key  throw new NotImplementedException();
          //  TwitterService twitterService = new TwitterService(_consumerKey, _consumerSecret);
          //  twitterService.AuthenticateWith(_accessToken, _accessTokenSecret);

          //  int tweetcount = 1;
          //  // var tweets_search = twitterService.Search(new SearchOptions { Q = "#Ebay", Resulttype = TwitterSearchResultType.Popular });
          //  var tweets_search = twitterService.Search(new SearchOptions { Q = "#Ebay", Count = 5 });
          //  //Resulttype can be TwitterSearchResultType.Popular or TwitterSearchResultType.Mixed or TwitterSearchResultType.Recent  
          //  List<TwitterStatus> resultList = new List<TwitterStatus>(tweets_search.Statuses);
            
            //foreach (var tweet in tweets_search.Statuses)
            //{
            //    try
            //    {
            //        //tweet.User.ScreenName;  
            //        //tweet.User.Name;   
            //       // tweet.Text; // Tweet text  
            //        //tweet.RetweetCount; //No of retweet on twitter  
            //        //tweet.User.FavouritesCount; //No of Fav mark on twitter  
            //        //tweet.User.ProfileImageUrl; //Profile Image of Tweet  
            //        //tweet.CreatedDate; //For Tweet posted time  
            //        //"https://twitter.com/intent/retweet?tweet_id=" + tweet.Id;  //For Retweet  
            //        //"https://twitter.com/intent/tweet?in_reply_to=" + tweet.Id; //For Reply  
            //        //"https://twitter.com/intent/favorite?tweet_id=" + tweet.Id; //For Favorite  

            //        //Above are the things we can also get using TweetSharp.  
            //        System.Diagnostics.Debug.WriteLine("User No: " + tweetcount + "\n" + tweet.User.Name + "\n" + tweet.User.ScreenName + "\n" + "https://twitter.com/intent/retweet?tweet_id=" + tweet.Id);
            //        tweetcount++;
            //    }
            //    catch { }
            //}



        }





    }



}
