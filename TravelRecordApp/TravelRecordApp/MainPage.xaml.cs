﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;





// kursus kode
namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}



//namespace TravelRecordApp
//{
//    public partial class MainPage : ContentPage
//    {
//        public MainPage()
//        {
//            InitializeComponent();

//            var assembly = typeof(MainPage);

//            //IconImageSource = ImageSource.FromResource("TravelRecordApp.Assets.Images.Plane..png", assembly);
//            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane..png", assembly);

//        }

//        //private void Button_Clicked(object sender, EventArgs e)
//        //{

//        //}






//        private void LoginButton_Clicked(object sender, EventArgs e)
//        {
//            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
//            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

//            if(isEmailEmpty || isPasswordEmpty)
//            {

//            }
//            else
//            {
//                Navigation.PushAsync(new HomePage());
//            }
//        }
//    }
//}
