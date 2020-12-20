using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Webkit;
using System.Security.Policy;
using Plugin.Permissions;
using Plugin.CurrentActivity;


namespace TravelRecordApp.Droid
{
    [Activity(Label = "TravelRecordApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);

            string dbName = "travle_db.sqLite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(folderPath, dbName);

            LoadApplication(new App(fullPath));



        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }



    }


}


















//namespace TravelRecordApp.Droid
//{
//    [Activity(Label = "TravelRecordApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
//    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
//    {
//        protected override void OnCreate(Bundle bundle)//savedInstanceState//)
//        {
//            TabLayoutResource = Resource.Layout.Tabbar;
//            ToolbarResource = Resource.Layout.Toolbar;

//            base.OnCreate(bundle); //savedInstanceState);

//            Xamarin.Essentials.Platform.Init(this, bundle );//savedInstanceState);
//            global::Xamarin.Forms.Forms.Init(this, bundle);//savedInstanceState);


//            Plugin.Permissions.CrossPermissions.Current.Init(this, bundle);

//            //Plugin.CurrentActivity.CrossCurrentActivity.Current.Int(this, bundle);


//            Xamarin.FormsMaps.Init(this, savedInstanceState);                               // (this, bundle) siger han i videon nr 60, 1,20min.




//            string dbName = "travel_db.sqlite";
//            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//            string fullPath = Path.Combine(folderPath, dbName); 

//            LoadApplication(new App(fullPath));
//        }



//        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[]
//        {

//            /* Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults); */         /* Denne kode har han ikke med i hans projekt*/

//            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

//            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

//        }









//        // Det her kode er ikke i hans 
//        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
//        //{
//        //   /* Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults); */         /* Denne kode har han ikke med i hans projekt*/


//        //    PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

//        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
//        //}



//    }
//}