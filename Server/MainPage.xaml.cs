namespace LetMeInReceiver
{
  public class ColorHelper
  {
    public static (double, double, double) HSVtoRGB(double hue, double saturation, double value)
    {
      int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
      double f = hue / 60 - Math.Floor(hue / 60);

      value = value * 255;
      int v = Convert.ToInt32(value);
      int p = Convert.ToInt32(value * (1 - saturation));
      int q = Convert.ToInt32(value * (1 - f * saturation));
      int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

      if (hi == 0)
        return (v, t, p);
      else if (hi == 1)
        return (q, v, p);
      else if (hi == 2)
        return (p, v, t);
      else if (hi == 3)
        return (p, q, v);
      else if (hi == 4)
        return (t, p, v);
      else
        return (v, p, q);
    }

    public static Color HSVtoColor(double hue, double saturation, double value)
    {
      var (r, g, b) = HSVtoRGB(hue, saturation, value);
      return Color.FromRgb(r, g, b);
    }
  }
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
      while(true)
      {

      }
    }
    public async void SignalReceived()
    {
      for (int seconds = 60; seconds > 0; seconds--)
      {
        Time.Progress = (seconds / 60) * 100;
        var color = ColorHelper.HSVtoColor(seconds*2, 1, 1);
        Time.ProgressColor = color;
        await Task.Delay(1000);
      }
    }
  }
}
