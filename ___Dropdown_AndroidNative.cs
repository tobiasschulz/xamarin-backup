
/*
using System;
using Xamarin.Forms;
using Xamarin.Utilities;
using System.Threading.Tasks;
using Digitalkraft.Framework.Utilities;

namespace Digitalkraft.Framework.Controls
{
	public class Dropdown_AndroidNative : View
	{
		public EventHandler<DropdownItem> ItemSelected = EventHelper.Empty;

		public ExtendedObservableCollection<DropdownItem> Items { get; private set; }

		DropdownItem _selectedItem;

		public DropdownItem SelectedItem {
			get { return _selectedItem; }
			set {
				_selectedItem = value;
			}
		}

		public Dropdown_AndroidNative ()
		{
			Items = new ExtendedObservableCollection<DropdownItem> ();
			//Items.CollectionChanged += (sender, e) => this.OnPropertyChanged ();
		}

		public void OnItemSelected (DropdownItem elem)
		{
			ItemSelected (this, elem);
		}

		public Task InitializeUI ()
		{
			try {
				this.OnPropertyChanged ();
			} catch (Exception ex) {
				Log.error ("Error in Android_Spinner.InitializeUI:" + ex.ToString ());
			}
			return Tasks.Completed;
		}
	}
}

*/
