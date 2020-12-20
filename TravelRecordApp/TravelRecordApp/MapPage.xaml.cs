
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Permissions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using TravelRecordApp.Model;





// kursus kode min var overhoved ikke det samme i map
//namespace TravelRecordApp
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class MapPage : ContentPage
//    {
//        public MapPage()
//        {
//            InitializeComponent();
//        }

//        protected async override void OnAppearing()
//        {
//            base.OnAppearing();

//            var locator = CrossGeolocator.Current;
//            locator.PositionChanged += Locator_PositionChanged;
//            await locator.StartListeningAsync(0, 100);

//            var position = await locator.GetPositionAsync();

//            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
//            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);

//            LocationsMap.MoveToRegion(span);




//            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
//            {
//                conn.CreateTable<Post>();
//                var posts = conn.Table<Post>().ToList();

//                DisplayInMap(posts);

//            }

//        }

//        protected override async void OnDisappearing()
//        {
//            base.OnDisappearing();

//            var locator = CrossGeolocator.Current;
//            locator.PositionChanged -= Locator_PositionChanged;

//            await locator.StopListeningAsync();
//        }

//        private void DisplayInMap(List<Post> posts)
//        {
//            foreach (var post in posts)
//            {
//                try
//                {
//                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);

//                    var pin = new Xamarin.Forms.Maps.Pin()
//                    {
//                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
//                        Position = position,
//                        Label = post.VenueName,
//                        Address = post.Address
//                    };

//                    LocationsMap.Pins.Add(pin);
//                }
//                catch (NullReferenceException nre) { }
//                catch (Exception ex) { }
//            }
//        }

//        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
//        {
//            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
//            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
//            LocationsMap.MoveToRegion(span);


//        }
//    }
//}










namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;

        public MapPage()
        {
            InitializeComponent();

            GetPermissions();
        }

        private async void GetPermissions()
        {

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your location", "We need to access your location", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }

                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    LocationsMap.IsShowingUser = true;


                    //locationsMap.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location denied", "You didn't give us permission to access location, so we can't show you where you are", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;

                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }
           
            GetLocation();
            // lektion 72 har tilføjet her
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();

                DisplayInMap(posts);

            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;

            await locator.StopListeningAsync();
            
        }


        private void DisplayInMap(List<Post> posts)
        {
            foreach(var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);


                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };

                    LocationsMap.Pins.Add(pin);
                }
                catch(NullReferenceException nre) { }
                catch (Exception ex) { }




            }
        }

        void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            LocationsMap.MoveToRegion(span);

            // locationsMap.MoveToRegion(span);
        }
    }
}







//namespace TravelRecordApp
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class MapPage : ContentPage
//    {
//        private bool hasLocationPersission = false;
//        public MapPage()
//        {
//            InitializeComponent();

//            GetPermissions();
//        }

//        // kan være ekstre kode og vil ikke kunne ses 

//        private async void GetPermissions()
//        {

//            try
//            {

//                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
//                if (status != PermissionStatus.Granted)
//                {
//                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
//                    {
//                        await DisplayAlert("Need your location", "We need to access your location", "Ok");

//                    }

//                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
//                    if (results.ContainsKey(Permission.LocationWhenInUse))
//                        status = results[Permission.LocationWhenInUse];

//                }


//                    if (status == PermissionStatus.Granted)
//                    {
//                        LocationsMap.IsShowingUser = true;
//                        hasLocationPersission = true;

//                        GetLocation();
//                    }
//                    else
//                    {
//                        await DisplayAlert("Need your location", "We need to access your location", "Ok");

//                    }




//            }
//            catch (Exception ex)
//            {
//                await DisplayAlert("Error", ex.Message, "Ok");

//            }            
//        }

//        protected override async void OnAppearing()
//        {
//            base.OnAppearing();
//            if (hasLocationPersission)
//            {
//                var locator = CrossGeolocator.Current;

//                locator.PositionChanged += Locator_PositionChanged;
//                await locator.StartListeningAsync(TimeSpan.Zero, 100);

//            }

//            GetLocation();

//                //if (hasLocationPersission)
//                //{
//                //    var locator = CrossGeolocator.Current;
//                //    var position = await locator.GetPositionAsync();
//                //}           
//        }
//        protected override void OnDisappearing()
//        {
//            base.OnDisappearing();

//            CrossGeolocator.Current.StopListeningAsync();
//            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
//        }

//        // Fra start genererer den private void, hans siger void +  throw new NotImplementedException();
//        void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
//        {
//            //throw new NotImplementedException();

//            MoveMap(e.Position);


//        }

//        private async void GetLocation()
//        {
//            if (hasLocationPersission)
//            {
//                var locator = CrossGeolocator.Current;
//                var position = await locator.GetPositionAsync();

//                MoveMap(position);

//                //var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
//                //var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
//                //LocationsMap.MoveToRegion(span);
//            }
//        }
//        private void MoveMap(Position position)
//        {
//            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
//            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
//            LocationsMap.MoveToRegion(span);


//        }
//    }

//}


