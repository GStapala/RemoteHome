using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using RemoteHomePCL.Interfaces;
using Xamarin.Forms;

namespace RemoteHomePCL.ControlsForRenderers
{
    public class BindablePicker : Picker
    {
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem",
            typeof(object), typeof(BindablePicker), null, BindingMode.TwoWay, null, OnSelectedItemChanged, null, null,
            null);

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource",
            typeof(IEnumerable), typeof(BindablePicker), null, BindingMode.TwoWay, null, OnItemsSourceChanged, null,
            null, null);

        public static readonly BindableProperty DisplayPropertyProperty = BindableProperty.Create("DisplayProperty",
            typeof(string), typeof(BindablePicker), null, BindingMode.OneWay, null, OnDisplayPropertyChanged, null, null,
            null);

        private bool disableEvents;

        public BindablePicker()
        {
            SelectedIndexChanged += OnSelectedIndexChanged;
        }

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
                if (ItemsSource != null && SelectedItem != null)
                    if (ItemsSource.Contains(SelectedItem))
                        SelectedIndex = ItemsSource.IndexOf(SelectedItem);
                    else
                        SelectedIndex = -1;
            }
        }

        public string DisplayProperty
        {
            get { return "DIsplay"; }
            set { SetValue(DisplayPropertyProperty, value); }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (disableEvents) return;

            if (SelectedIndex == -1)
                SelectedItem = null;
            else
                SelectedItem = ItemsSource[SelectedIndex];
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (BindablePicker)bindable;
            picker.SelectedItem = newValue;
            if (picker.ItemsSource != null && picker.SelectedItem != null)
            {
                var count = 0;
                foreach (var obj in picker.ItemsSource)
                {
                    if (obj == picker.SelectedItem)
                    {
                        picker.SelectedIndex = count;
                        break;
                    }
                    count++;
                }
            }
        }

        private static void OnDisplayPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (BindablePicker)bindable;
            picker.DisplayProperty = ((IText)newValue).Text;
            LoadItemsAndSetSelected(bindable);
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (BindablePicker)bindable;

            picker.ItemsSource = (IList)newValue;

            LoadItemsAndSetSelected(bindable);
        }

        private static void LoadItemsAndSetSelected(BindableObject bindable)
        {
            var picker = (BindablePicker)bindable;
            if (picker.ItemsSource != null)
            {
                picker.disableEvents = true;
                picker.SelectedIndex = -1;
                picker.Items.Clear();
                var count = 0;
                foreach (IText obj in picker.ItemsSource)
                {
                    var value = string.Empty;
                    if (picker.DisplayProperty != null)
                    {
                        var prop =
                            obj.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, picker.DisplayProperty, StringComparison.OrdinalIgnoreCase));
                        if (prop != null)
                            value = prop.GetValue(obj).ToString();
                        else
                            value = obj.Text;
                    }
                    else
                    {
                        value = obj.ToString();
                    }
                    picker.Items.Add(value);
                    if (picker.SelectedItem != null)
                        if (picker.SelectedItem == obj)
                            picker.SelectedIndex = count;
                    count++;
                }
                picker.disableEvents = false;
            }
            else
            {
                picker.Items.Clear();
            }
        }
    }
}