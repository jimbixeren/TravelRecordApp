using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                var categories = (from p in postTable
                                  orderby p.CategoryId
                                  select p.CategoryName).Distinct().ToList();


                // der er en anden måde at skrive det på
                //var categories2 = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

               



                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach (var category in categories)
                {
                    var count = (from post in postTable
                                 where post.CategoryName == category
                                 select post).ToList().Count;
                    // fra kursus q and a 
                    if (category != null)
                    {
                        categoriesCount.Add(category, count);
                    }
                    else
                    {
                        categoriesCount.Add("- category not specified -", count);
                    }

                    //var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count;

                    //categoriesCount.Add(category, count2);
                  
                }
               


                categoriesListView.ItemsSource = categoriesCount;

                postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}

//namespace TravelRecordApp
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class ProfilePage : ContentPage
//    {
//        public ProfilePage()
//        {
//            InitializeComponent();
//        }




//        // fra kursus
//        protected override void OnAppearing()
//        {
//            base.OnAppearing();

//            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
//            {  

//                var postTable = conn.Table<Post>().ToList();

//                var categories = (from p in postTable
//                                  orderby p.CategoryId
//                                  select p.CategoryName).Distinct().ToList();

//                // fra kursus q and a her bil den andrig blive Null
//                postCountLabel.Text = (from post in postTable
//                                       where post.CategoryName != null
//                                       select post).ToList().Count.ToString();

//                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
//                foreach (var category in categories)
//                {
//                    var count = (from post in postTable
//                                 where post.CategoryName == category
//                                 select post).ToList().Count;

//                    var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count;

//                    //categoriesCount.Add(category, count2);
//                }

//                categoriesListView.ItemsSource = categoriesCount;

//                postCountLabel.Text = postTable.Count.ToString();
//                //postCountLabel.Text = (from post in postTable
//                //                       where post.CategoryName != null
//                //                       select post).ToList().Count.ToString();

//            }
//        }
//    }



    //    protected override void OnAppearing()
    //    {
    //        base.OnAppearing();

    //        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
    //        {
    //            var postTable = conn.Table<Post>().ToList();

    //            // lektion 78 using linq er ikke sikker på det virker 100% i post 
    //            var categories = (from p in postTable
    //                              orderby p.Categoryid
    //                              select p.CategorName).Distinct().ToList();

    //            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
    //            foreach(var category in categories)
    //            {
    //                var count = (from post in postTable
    //                             where post.Categorname == category
    //                             select post).ToList().Count;

    //                categoriesCount.Add(category, count);

    //            }

    //            postCountLabel.Text = postTable.Count.ToString();


    //        }
    //    }
    //}
//}










//namespace TravelRecordApp
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class ProfilePage : ContentPage
//    {
//        public ProfilePage()
//        {
//            InitializeComponent();
//        }

//        protected override void OnAppearing()
//        {
//            base.OnAppearing();


//            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
//            {
//                var postTable = conn.Table<Post>().ToList();

//                postCountLabel.Text = postTable.Count.ToString();

//                //postCountLable.Text = postTable.Count.ToString();


//            }


//        }
//    }
//}