using System;
using Xamarin.Forms;

namespace Digitalkraft.Framework.Controls
{
	public class _old__ImageButton : ContentView
	{
		EventHandler tapped;

		public event EventHandler Tapped { add { tapped += value; } remove { tapped -= value; }
		}

		public event EventHandler Clicked { add { tapped += value; } remove { tapped -= value; }
		}

		public _old__ImageButton ()
		{
			HorizontalOptions = LayoutOptions.Center;
			VerticalOptions = LayoutOptions.Center;

			Image = new Image ();

			var tapImage = new TapGestureRecognizer ();
			tapImage.Tapped += TapImage_Tapped;
			GestureRecognizers.Add (tapImage);
		}

		void TapImage_Tapped (object sender, EventArgs e)
		{
			if (tapped != null) {
				tapped (sender, e);
			}
		}

		public Image Image {
			get {
				return Content as Image;
			}
			set {
				value.InputTransparent = false;
				Content = value;
			}
		}

		public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create<_old__ImageButton,ImageSource> (c => c.ImageSource, "", BindingMode.OneWay, null, ImageSourceChanged);

		public static readonly BindableProperty ImageWidthRequestProperty = BindableProperty.Create<_old__ImageButton,int> (c => c.ImageWidthRequest, 50, BindingMode.OneWay, null, ImageWidthRequestChanged);

		public static readonly BindableProperty ImageHeightRequestProperty = BindableProperty.Create<_old__ImageButton,int> (c => c.ImageHeightRequest, 50, BindingMode.OneWay, null, ImageHeightRequestChanged);

		public ImageSource ImageSource {
			get { return (ImageSource)GetValue (ImageSourceProperty); }
			set { SetValue (ImageSourceProperty, value); }
		}

		public int ImageWidthRequest {
			get { return (int)GetValue (ImageWidthRequestProperty); }
			set { SetValue (ImageWidthRequestProperty, value); }
		}

		public int ImageHeightRequest {
			get { return (int)GetValue (ImageHeightRequestProperty); }
			set { SetValue (ImageHeightRequestProperty, value); }
		}

		static void ImageSourceChanged (BindableObject bindable, ImageSource oldValue, ImageSource newValue)
		{
			var self = bindable as _old__ImageButton;
			self.Image.Source = newValue;
		}

		static void ImageWidthRequestChanged (BindableObject bindable, int oldValue, int newValue)
		{
			var self = bindable as _old__ImageButton;
			self.Image.WidthRequest = newValue;
		}

		static void ImageHeightRequestChanged (BindableObject bindable, int oldValue, int newValue)
		{
			var self = bindable as _old__ImageButton;
			self.Image.HeightRequest = newValue;
		}
	}

}
