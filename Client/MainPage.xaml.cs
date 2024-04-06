using System.Threading;

namespace LetMeIn
{
  public partial class MainPage : ContentPage
  {
    string send = "Send Request";
    string cancel = "Cancel Request";
    public MainPage()
    {
      InitializeComponent();
      ((Button)rqst).BackgroundColor = Colors.Green;
      ((Button)rqst).Text = send;
    }

    public void Request(object sender, EventArgs e)
    {
      ((Button)rqst).BackgroundColor = Colors.Red;
      ((Button)rqst).Text = cancel;
      ((Button)rqst).Clicked -= Request;
      ((Button)rqst).Clicked += Cancel;
      DelayToCancel();
    }
    public void Cancel(object sender, EventArgs e)
    {
      ((Button)rqst).BackgroundColor = Colors.Green;
      ((Button)rqst).Text = send;
      ((Button)rqst).Clicked -= Cancel;
      ((Button)rqst).Clicked += Request;
    }
    public async void DelayToCancel()
    {
      for (int seconds = 60; seconds > 0; seconds--)
      {
        if (rqst.Text != send)
        {
          rqst.Text = cancel + " (auto cancel in: " + seconds.ToString() + ")";
          await Task.Delay(1000);
        }
      }
      Cancel(rqst,EventArgs.Empty);
    }
  }
}
