using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
/* Author:      Zhencheng Chen
 * Program:     Flashcard for President
 * Date:          2/10/2020
 */
namespace Flashcard
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int currentIndex;
        bool headSide;
        public MainPage()
        {
            InitializeComponent();
            Data.DataLoad();
            headSide = true;
            currentIndex = 0;

            DisplayLabel.Text = Data.list[currentIndex].Name;
        }

        async void FlipBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            FlipBtn.IsEnabled = false;
            DisplayLabel.TranslateTo(100, 0, 400);
            await DisplayLabel.RotateYTo(-90, 200);
            DisplayLabel.RotationY = -270;

            if (headSide)
            {
                DisplayLabel.Text = Data.list[currentIndex].Year;
                headSide = false;
            }
            else
            {
                DisplayLabel.Text = Data.list[currentIndex].Name;
                headSide = true;
            }

            DisplayLabel.RotateYTo(-360, 200);
            await DisplayLabel.TranslateTo(0, 0, 220);
            DisplayLabel.RotationY = 0;
            FlipBtn.IsEnabled = true;

        }

        async void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch(e.Direction)
            {
                case SwipeDirection.Left:

                    if(currentIndex == Data.list.Count - 1)
                    {
                        currentIndex = 0;
                    }
                    else
                    {
                        currentIndex++;
                    }
                    DisplayLabel.Text = Data.list[currentIndex].Name;
                    headSide = true;

                    break;
                case SwipeDirection.Right:

                    if (currentIndex == 0)
                    {
                        currentIndex = Data.list.Count - 1;
                    }
                    else
                    {
                        currentIndex--;
                    }
                    DisplayLabel.Text = Data.list[currentIndex].Name;
                    headSide = true;

                    break;
                default:
                    break;
            }
        }
    }
}
