using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace DemoDrawer2
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
       
        double yHalfPosition;
        double yFullPosition;
        double yZeroPosition;
        int currentPsotion;
        double currentPostionY;
        bool up;
        bool down;
        bool isTurnY;
        double valueY;
        double y;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            yHalfPosition = (App.screenHeight / 2) - 60;
            yFullPosition = App.screenHeight - 190;
            if (Device.RuntimePlatform == Device.iOS)
            {
                yFullPosition = App.screenHeight - (20 + 20 + 30 + 120);
            }
            yZeroPosition = 0;
            currentPsotion = 1;
            currentPostionY = yHalfPosition;
            bottomsheetListView.HeightRequest = yHalfPosition;

            bottomSheet.TranslateTo(bottomSheet.X, -yHalfPosition);
        }
        void PanGestureRecognizer_PanUpdated(System.Object sender, Xamarin.Forms.PanUpdatedEventArgs e)
        {
            
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    var translateY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs((Height * .25) - Height));
                    if (e.TotalY >= 5 || e.TotalY <= -5 && !isTurnY)
                    {
                        isTurnY = true;
                    }
                    if (isTurnY)
                    {
                        if (e.TotalY <= valueY)
                        {
                            up = true;

                        }
                        if (e.TotalY >= valueY)
                        {
                            down = true;

                        }
                    }
                    if (up)
                    {
                        if (Device.RuntimePlatform == Device.Android)
                        {
                            if (yFullPosition < (currentPostionY + (-1 * e.TotalY)))
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -yFullPosition);
                            }
                            else
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -1 * (currentPostionY + (-1 * e.TotalY)));
                            }
                        }
                        else
                        {
                            if (yFullPosition < (currentPostionY + (-1 * e.TotalY)))
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -yFullPosition, 20);
                            }
                            else
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -1 * (currentPostionY + (-1 * e.TotalY)), 20);
                            }
                        }
                    }
                    else if (down)
                    {
                        if (Device.RuntimePlatform == Device.Android)
                        {
                            if (yZeroPosition > currentPostionY - e.TotalY)
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -yZeroPosition);
                            }
                            else
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -(currentPostionY - (e.TotalY)));
                            }
                        }
                        else
                        {
                            if (yZeroPosition > currentPostionY - e.TotalY)
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -yZeroPosition, 20);
                            }
                            else
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -(currentPostionY - (e.TotalY)), 20);
                            }
                        }
                    }
                    break;
                case GestureStatus.Completed:
                    valueY = e.TotalY;
                    y = bottomSheet.TranslationY;


                    if (up)
                    {
                        if (currentPsotion == 1)
                        {
                            bottomSheet.TranslateTo(bottomSheet.X, -yFullPosition);
                            currentPsotion = 2;
                            currentPostionY = yFullPosition;
                            bottomsheetListView.HeightRequest = yFullPosition;
                            bottomsheetListView.HeightRequest = yFullPosition;
                        }
                        else if (currentPsotion == 0)
                        {
                            double currentY = (-1) * y;
                            double differentBetweenHalfAndCurrent = Math.Abs(currentY - yHalfPosition);
                            double differentBetweenFullAndCurrent = Math.Abs(currentY - yFullPosition);
                            if (differentBetweenHalfAndCurrent < differentBetweenFullAndCurrent)
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -yHalfPosition);
                                currentPsotion = 1;
                                currentPostionY = yHalfPosition;
                                bottomsheetListView.HeightRequest = yHalfPosition;
                            }
                            else
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -yFullPosition);
                                currentPsotion = 2;
                                currentPostionY = yFullPosition;
                                bottomsheetListView.HeightRequest = yFullPosition;
                            }

                        }
                    }
                    if (down)
                    {
                        if (currentPsotion == 1)
                        {
                            bottomSheet.TranslateTo(bottomSheet.X, -yZeroPosition);
                            currentPsotion = 0;
                            currentPostionY = yZeroPosition;
                        }
                        else if (currentPsotion == 2)
                        {
                            double currentY = (-1) * y;
                            double differentBetweenHalfAndCurrent = Math.Abs(currentY - yHalfPosition);
                            double differentBetweenZeroAndCurrent = Math.Abs(currentY - yZeroPosition);
                            if (differentBetweenHalfAndCurrent < differentBetweenZeroAndCurrent)
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -yHalfPosition);
                                currentPsotion = 1;
                                currentPostionY = yHalfPosition;
                                bottomsheetListView.HeightRequest = yHalfPosition;
                            }
                            else
                            {
                                bottomSheet.TranslateTo(bottomSheet.X, -yZeroPosition);
                                currentPsotion = 0;
                                currentPostionY = yZeroPosition;
                            }


                        }
                    }
                    y = bottomSheet.TranslationY;
                    up = false;
                    down = false;
                    break;
            }
        }
    }
}
