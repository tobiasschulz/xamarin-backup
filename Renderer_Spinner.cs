/*
using System;
using System.Collections.Specialized;
using System.Linq;
using Android.Widget;
using Digitalkraft.Framework.Controls;
using Posdb.Android.Platforms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Droid = Android;
using Digitalkraft.Framework.Utilities;

[assembly: ExportRenderer (typeof(Digitalkraft.Framework.Controls.Dropdown_AndroidNative), typeof(Renderer_Spinner))]
namespace Posdb.Android.Platforms
{
	public sealed class Renderer_Spinner : ViewRenderer<Dropdown_AndroidNative, Spinner>, AdapterView.IOnItemSelectedListener
	{
		public Renderer_Spinner ()
		{
			base.AutoPackage = false;
		}

		Dropdown_AndroidNative model { get { return base.Element; } }

		protected override void OnElementChanged (ElementChangedEventArgs<Dropdown_AndroidNative> e)
		{
			if (e.OldElement != null) {
				//e.OldElement.Items.CollectionChanged -= new NotifyCollectionChangedEventHandler (this.RowsCollectionChanged);
				if (base.Control != null) {
					//base.Control.ItemSelected -= OnItemSelected;
				}
			}
			if (e.NewElement != null) {
				//model = e.NewElement;
				//e.NewElement.Items.CollectionChanged += new NotifyCollectionChangedEventHandler (this.RowsCollectionChanged);
				if (base.Control == null) {
					base.SetNativeControl (new Spinner (Forms.Context));
				}
				updateData (e.NewElement, base.Control, this);
				//spinner.ItemSelected += OnItemSelected;

				//this.UpdatePicker ();
			}
			base.OnElementChanged (e);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			updateData (base.Element, base.Control, this);
			base.OnElementPropertyChanged (sender, e);
		}

		static void updateData (Dropdown_AndroidNative model, Spinner control, AdapterView.IOnItemSelectedListener listener)
		{
			try {
				control.OnItemSelectedListener = null;
				var adapter = new ArrayAdapter<string> (Forms.Context, Droid.Resource.Layout.SimpleDropdownItem, model.Items.Select (itemToString).ToArray ());
				adapter.SetDropDownViewResource (Droid.Resource.Layout.SimpleSpinnerDropDownItem);
				control.Adapter = adapter;
				Log.message ("SetSelection", "model.SelectedItem = " + model.SelectedItem + ", model.Items.IndexOf (model.SelectedItem) = " + model.Items.IndexOf (model.SelectedItem));
				control.SetSelection (Math.Min (0, model.Items.IndexOf (model.SelectedItem)));
				control.Post (delegate {
					try {
						control.OnItemSelectedListener = listener;
					} catch (Exception ex) {
						Log.error ("Exception in Renderer_Spinner.updateData.Post: " + ex.ToString ());
					}
				});
			} catch (Exception ex) {
				Log.error ("Exception in Renderer_Spinner.updateData: " + ex.ToString ());
			}
		}

		public void OnItemSelected (AdapterView parent, Droid.Views.View view, int position, long id)
		{
			string selectedItem = parent.GetItemAtPosition (position).ToString ();
			//int i = 0;
			foreach (var elem in base.Element.Items) {
				//if (i == position) {
				if (itemToString (elem) == selectedItem) {
					base.Element.SelectedItem = elem;
					base.Element.OnItemSelected (elem);
				}
				//i++;
			}
		}

		static string itemToString (DropdownItem item)
		{
			return item.DisplayName;
		}

		public void OnNothingSelected (AdapterView parent)
		{
			
		}
	}
}

*/