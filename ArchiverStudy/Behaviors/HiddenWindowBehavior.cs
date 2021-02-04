using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArchiverStudy.Behaviors
{
    internal class HiddenWindowBehavior
    {
        public static readonly DependencyProperty IsHiddenProperty = DependencyProperty.RegisterAttached(
            "IsHidden",
            typeof(bool),
            typeof(HiddenWindowBehavior),
            new PropertyMetadata(false, OnIsHiddenChanged)
            );

        public static bool GetIsHidden(DependencyObject target) => (bool)target.GetValue(IsHiddenProperty);
        public static void SetIsHidden(DependencyObject target, bool value) => target.SetValue(IsHiddenProperty, value);

        private static void OnIsHiddenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window element && e.NewValue is bool value && value)
            {
                element.Hide();
                element.Initialized += OnInitialized;
            }
        }

        private static void OnInitialized(object? sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnLoad");
            if (sender is Window element)
            {
                element.ContextMenu.IsOpen = true;
                element.ContextMenu.Closed += (sender, e) =>
                {
                    element.Close();
                };
            }
        }
    }
}
