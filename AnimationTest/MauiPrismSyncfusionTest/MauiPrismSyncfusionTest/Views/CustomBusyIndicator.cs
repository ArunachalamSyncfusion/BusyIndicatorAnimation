using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animation = Microsoft.Maui.Controls.Animation;

namespace MauiPrismSyncfusionTest.Views
{
    public class CustomBusyIndicator : ContentView
    {
        private BoxView _busyBox;
        private Label _loadingLabel;

        public CustomBusyIndicator()
        {
            _busyBox = new BoxView
            {
                Color = Colors.Blue,
                WidthRequest = 50,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            _loadingLabel = new Label
            {
                Text = "Loading...",
                TextColor=Colors.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 60, 0, 0)
            };

            var grid = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            grid.Children.Add(_busyBox);
            grid.Children.Add(_loadingLabel);

            Content = grid;
        }

        public static readonly BindableProperty IsBusyProperty =
            BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(CustomBusyIndicator), false, propertyChanged: OnIsBusyChanged);

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        private static void OnIsBusyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomBusyIndicator)bindable;
            if ((bool)newValue)
            {
                control.AnimateBusyBox();
            }
            else
            {
                control._busyBox.AbortAnimation("BusyAnimation");
            }
        }

        private void AnimateBusyBox()
        {
            var animation = new Animation(v => _busyBox.Rotation = v, 0, 360);
            _busyBox.Animate("BusyAnimation", animation, length: 100, repeat: () => IsBusy);
        }
    }
}
