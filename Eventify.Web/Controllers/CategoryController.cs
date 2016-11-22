using Eventify.Data.Models;
using Eventify.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;

namespace Eventify.Web.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService = null;

        public CategoryController()
        {
            categoryService = new CategoryService();
        }

        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<Category> listCategory = categoryService.getAllCategory();
            //ViewBag.listOfCategory = listCategory;
           


            categoryService.twitterCategory();
         
            return View(listCategory);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Category category = categoryService.GetById(id);
                categoryService.commit();
                string _consumerKey = "r9ourmJGw565hd9mTgown89US"; // Your key
                string _consumerSecret = "cjKp7ftZWKGd8kMTDh61mS8YRxM2hWbqV5UdV1vjpNKKXou3VO"; // Your key  
                string _accessToken = "2369334732-SytOgpaApi98Ts8GRb5q6vfxn1lJRIX6V2ko3db"; // Your key  
                string _accessTokenSecret = "dUgLrr4yLea4VBlQjkJv0LTLnuvpy2h5PrGNBGcb2P3qU"; // Your key  throw new NotImplementedException();
                TwitterService twitterService = new TwitterService(_consumerKey, _consumerSecret);
                twitterService.AuthenticateWith(_accessToken, _accessTokenSecret);

                int tweetcount = 1;
                // var tweets_search = twitterService.Search(new SearchOptions { Q = "#Ebay", Resulttype = TwitterSearchResultType.Popular });
                String hashtag = "#" + category.categoryName;
                var tweets_search = twitterService.Search(new SearchOptions { Q = hashtag, Count = 5 });
                //Resulttype can be TwitterSearchResultType.Popular or TwitterSearchResultType.Mixed or TwitterSearchResultType.Recent  
                List<TwitterStatus> resultList = new List<TwitterStatus>(tweets_search.Statuses);
                foreach (var tweet in tweets_search.Statuses)
                {
                    try
                    {
                        //tweet.User.ScreenName;  
                        //tweet.User.Name;   
                        // tweet.Text; // Tweet text  
                        //tweet.RetweetCount; //No of retweet on twitter  
                        //tweet.User.FavouritesCount; //No of Fav mark on twitter  
                        //tweet.User.ProfileImageUrl; //Profile Image of Tweet  
                        //tweet.CreatedDate; //For Tweet posted time  
                        //"https://twitter.com/intent/retweet?tweet_id=" + tweet.Id;  //For Retweet  
                        //"https://twitter.com/intent/tweet?in_reply_to=" + tweet.Id; //For Reply  
                        //"https://twitter.com/intent/favorite?tweet_id=" + tweet.Id; //For Favorite  

                        //Above are the things we can also get using TweetSharp.  
                        System.Diagnostics.Debug.WriteLine("User No: " + tweetcount + "\n" + tweet.User.Name + "\n" + tweet.User.ScreenName + "\n" + "https://twitter.com/intent/retweet?tweet_id=" + tweet.Id + "\n" + tweet.User.ProfileImageUrl+ "\n");
                        tweetcount++;
                    }
                    catch { }
                }
                ViewBag.tweet = tweets_search.Statuses;

                return View(category);
            }
            
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                categoryService.Add(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = categoryService.GetById(id);
            if (category.Equals(null)) { return RedirectToAction("Index"); }
            
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Category category = categoryService.GetById(id);
                
                System.Diagnostics.Debug.WriteLine("wiw" + category.id);
                category.categoryName = collection["categoryName"];
                categoryService.updateCategory(category);
                categoryService.commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = categoryService.GetById(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                categoryService.deteCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
