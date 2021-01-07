using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace LatihanXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContohGeolocation : ContentPage
    {
        public ContohGeolocation()
        {
            InitializeComponent();
        }

        private async void btnCek_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    lblLatitude.Text = $"Latitude: {location.Latitude}";
                    lblLongitude.Text = $"Longitude: {location.Longitude}";
                }
                else
                {
                    lblLatitude.Text = string.Empty;
                    lblLongitude.Text = string.Empty;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Kesalahan", $"{fnsEx.Message}", "OK");
            }
            catch(FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Kesalahan", $"{fneEx.Message}", "OK");
            }
            catch(PermissionException pEx)
            {
                await DisplayAlert("Kesalahan", $"{pEx.Message}", "OK");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Kesalahan", $"{ex.Message}", "OK");
            }
        }


        private CancellationTokenSource cts;
        private async void btnCekGeo_Clicked(object sender, EventArgs e)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium,
                    TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                if (location != null)
                {
                    lblLatitude.Text = $"{location.Latitude}";
                    lblLongitude.Text = $"{location.Longitude}";
                    lblAltitude.Text = $"{location.Altitude}";
                }
                else
                {
                    lblLatitude.Text = string.Empty;
                    lblLongitude.Text = string.Empty;
                    lblAltitude.Text = string.Empty;
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Kesalahan", $"{fnsEx.Message}", "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Kesalahan", $"{fneEx.Message}", "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Kesalahan", $"{pEx.Message}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", $"{ex.Message}", "OK");
            }
        }

        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }

        private async void btnGeoCoding_Clicked(object sender, EventArgs e)
        {
            try
            {
                var address = "Jl Gowongan Lor 46, Yogyakarta, Indonesia";
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    await DisplayAlert("Posisi", $"Lat {location.Latitude} Lon {location.Longitude}", "OK");
                }
            }
            catch (FeatureNotSupportedException fnEx)
            {
                await DisplayAlert("Kesalahan", $"{fnEx.Message}", "OK");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Kesalahan", $"{ex.Message}", "OK");
            }
            
        }

        private async void btnReverseGeo_Clicked(object sender, EventArgs e)
        {
            try
            {
                double lat = Convert.ToDouble(lblLatitude.Text);
                double lon = Convert.ToDouble(lblLongitude.Text);

                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);
                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    var geocodesummary = $"AdminArea: {placemark.AdminArea} \n" +
                        $"Country Code: {placemark.CountryCode} \n" +
                        $"Country Name: {placemark.CountryName} \n" +
                        $"Feature Name: {placemark.FeatureName} \n" +
                        $"Subadmin : {placemark.SubAdminArea} \n" +
                        $"postal : {placemark.PostalCode} \n" +
                        $"local: {placemark.SubLocality} {placemark.SubThoroughfare} {placemark.Thoroughfare} \n";
                    lblReverseGeo.Text = geocodesummary;
                }
            }
            catch (FeatureNotSupportedException fnEx)
            {
                await DisplayAlert("Kesalahan", $"{fnEx.Message}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", $"{ex.Message}", "OK");
            }



        }

        private async void btnOpenMap_Clicked(object sender, EventArgs e)
        {
            double lat = Convert.ToDouble(lblLatitude.Text);
            double lon = Convert.ToDouble(lblLongitude.Text);
            var location = new Location(lat, lon);
            var options = new MapLaunchOptions { Name="Actual Training" };
            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", $"{ex.Message}", "OK");
            }
        }
    }
}