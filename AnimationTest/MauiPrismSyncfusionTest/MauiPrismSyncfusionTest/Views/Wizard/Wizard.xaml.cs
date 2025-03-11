

namespace MauiPrismSyncfusionTest.Views.Wizard;

public partial class Wizard : ContentPage
{
    double screenWidth;
    public Wizard()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        foreach (var child in horizontalStack.Children)
        {
            if (child is not null && child is View view)
            {
                view.WidthRequest = screenWidth;
            }
        }

    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        screenWidth = width;
        foreach (var child in horizontalStack.Children)
        {
            if (child is not null && child is View view)
            {
                view.WidthRequest = screenWidth;
            }
        }
    }

    private void horizontalStack_ChildAdded(object sender, ElementEventArgs e)
    {
        foreach (var child in horizontalStack.Children)
        {
            if (child is not null && child is View view)
            {
                view.WidthRequest = screenWidth;
            }
        }
    }
}

