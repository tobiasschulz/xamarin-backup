using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digitalkraft.Framework.Databases;
using Digitalkraft.Framework.Utilities;
using Xamarin.Forms;
using Xamarin.Utilities;

namespace Digitalkraft.Framework.Controls
{
	/*
	public sealed class Form_DropDown : Form_LabelValueControl<string>, IDataTarget
	{
		public Spinner_Implementation SpinnerImpl { get; set; }

		public DataSource<DropdownItem> DataSourceItems { get; set; }

		public EventHandler<DropdownItem> ItemSelected = EventHelper.Empty;

		public DropdownItem SelectedItem { get { return SpinnerImpl.SelectedItem; } set { SpinnerImpl.SelectedItem = value; } }

		public Form_DropDown ()
		{
			SpinnerImpl = Device.OS == TargetPlatform.Android ? new ActionSheet_Xamarin (this) : new Picker_Xamarin (this) as Spinner_Implementation;
			SpinnerImpl.HorizontalOptions = LayoutOptions.FillAndExpand;
			SpinnerImpl.ItemSelected += OnItemSelected;

			Content = new Form_StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {
					Label,
					SpinnerImpl
				}
			};
		}

		public DataSource<string> DataSource { set { DataSourceItems = value.Select (DropdownItem.FromString); } }

		#region IDataTarget implementation

		public async Task DataSource_Fetch ()
		{
			eventsEnabled = false;
			if (DataSourceItems != null) {
				await DataSourceItems.Fetch ();
			} else {
				Log.error ("Das " + this.GetType () + " mit dem Titel " + LabelText + " enthält keine DataSource!");
			}
			eventsEnabled = true;
		}

		public async Task DataTarget_InitializeUI ()
		{
			eventsEnabled = false;
			try {
				if (DataSourceItems != null) {
					// clear
					SpinnerImpl.Clear ();

					// determine the selected item
					DropdownItem selectedItem = DataSourceItems.First ();
					DataSource<DropdownItem> items = DataSourceItems;
					if (Value.Value != null) {
						string valueString = Value.Value;
						selectedItem = DataSourceItems.First (i => i.ID == valueString);
						if (selectedItem == null) {
							selectedItem = new DropdownItem { ID = valueString, DisplayName = valueString };
							items = DataSourceItems.Prepend (selectedItem);
						}
					}

					// add all items
					foreach (DropdownItem item in items.List ()) {
						SpinnerImpl.Add (item);
					}

					// set the selected item
					if (selectedItem != null) {
						SelectedItem = selectedItem;
						Log.message ("SelectedItem", "Setze ausgewählten Eintrag des Formulatelements " + LabelText + " auf " + selectedItem.ID);
					}
				}

				await SpinnerImpl.InitializeUI ();

			} catch (Exception ex) {
				Log.error (ex);
			}
			eventsEnabled = true;
		}

		#endregion

		bool eventsEnabled = true;

		void OnItemSelected (object sender, DropdownItem e)
		{
			//Log.message ("test", "eventsEnabled = " + eventsEnabled + ", value=" + Value.ToJson ());
			if (eventsEnabled) {
				// set selected value through accessor
				Value.Value = e.ID;
				Log.message ("test", "Der ausgewählte Wert " + e.ID + " wurde in das Form_Value-Objekt des Formularelements gespeichert.");


				// notify
				ItemSelected (sender, e);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
			}
		}

		public abstract class Spinner_Implementation : ContentView
		{
			public abstract Task InitializeUI ();

			public abstract void Add (DropdownItem item);

			public abstract void Clear ();

			public abstract DropdownItem SelectedItem { get; set; }

			public EventHandler<DropdownItem> ItemSelected = EventHelper.Empty;
		}

		public sealed class Spinner_Android : Spinner_Implementation
		{
			public Dropdown_AndroidNative androidSpinner { get; set; }

			readonly Form_DropDown formDropdown;

			public Spinner_Android (Form_DropDown formDropdown)
			{
				this.formDropdown = formDropdown;
				Content = androidSpinner = new Dropdown_AndroidNative {
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};
				// Analysis disable once ConvertClosureToMethodGroup
				androidSpinner.ItemSelected += (object sender, DropdownItem e) => ItemSelected (sender, e);
			}

			#region implemented abstract members of Picker_Implementation

			public override async Task InitializeUI ()
			{
				await androidSpinner.InitializeUI ();
			}

			public override void Add (DropdownItem item)
			{
				formDropdown.eventsEnabled = false;
				// Log.message ("Dropdown", "add: " + item.Item);
				androidSpinner.Items.Add (item);
				formDropdown.eventsEnabled = true;
			}

			public override void Clear ()
			{
				formDropdown.eventsEnabled = false;
				androidSpinner.Items.Clear ();
				formDropdown.eventsEnabled = true;
			}

			public override DropdownItem SelectedItem { get { return androidSpinner.SelectedItem; } set { androidSpinner.SelectedItem = value; } }

			#endregion
		}

		public sealed class Picker_Xamarin : Spinner_Implementation
		{
			public Picker Picker { get; set; }

			readonly Form_DropDown formDropdown;

			public Picker_Xamarin (Form_DropDown formDropdown)
			{
				this.formDropdown = formDropdown;
				Content = Picker = new Picker {
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				Picker.SelectedIndexChanged += (sender, e) => ItemSelected (sender, list [Picker.SelectedIndex, list.FirstOrDefault ()]);
			}

			#region implemented abstract members of Picker_Implementation

			public override Task InitializeUI ()
			{
				return Tasks.Completed;
			}

			public override void Add (DropdownItem item)
			{
				formDropdown.eventsEnabled = false;
				Picker.Items.Add (item.DisplayName);
				list.Add (item);
				formDropdown.eventsEnabled = true;
			}

			public override void Clear ()
			{
				formDropdown.eventsEnabled = false;
				Picker.Items.Clear ();
				list.Clear ();
				formDropdown.eventsEnabled = true;
			}

			public override DropdownItem SelectedItem { get { return list [Picker.SelectedIndex, list.FirstOrDefault ()]; } set { Picker.SelectedIndex = Math.Min (list.IndexOf (value), 0); } }

			#endregion

			public SafeList<DropdownItem> list = new SafeList<DropdownItem> ();
		}

		public sealed class ActionSheet_Xamarin : Spinner_Implementation
		{
			readonly Dropdown dropdown;
			readonly Form_DropDown formDropdown;

			public ActionSheet_Xamarin (Form_DropDown formDropdown)
			{
				Content = new Dropdown ();
				this.formDropdown = formDropdown;
			}

			#region implemented abstract members of Picker_Implementation

			public override Task InitializeUI ()
			{
				return Tasks.Completed;
			}

			public override void Add (DropdownItem item)
			{
				formDropdown.eventsEnabled = false;
				list.Add (item);
				formDropdown.eventsEnabled = true;
			}

			public override void Clear ()
			{
				formDropdown.eventsEnabled = false;
				list.Clear ();
				label.Text = "";
				formDropdown.eventsEnabled = true;
			}

			#endregion

			DropdownItem _selectedItem;

			public override DropdownItem SelectedItem { get { return label.Text; } set { label.Text = value; } }


			public SafeList<DropdownItem> list = new SafeList<DropdownItem> ();
		}
	}*/
}
