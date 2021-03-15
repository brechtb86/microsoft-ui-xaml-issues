using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3Issues
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private double NavViewCompactModeThresholdWidth => this.NavView.CompactModeThresholdWidth;

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private readonly List<(string Tag, Type Page)> _pages = new()
        {
            ("home", typeof(HomePage)),
            ("itemsRepeaterScrollIssue", typeof(ItemsRepeaterScrollIssuePage))
        };

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            this.ContentFrame.Navigated += (sender, e) =>
            {
                this.NavView.IsBackEnabled = this.ContentFrame.CanGoBack;

                if (this.ContentFrame.SourcePageType == typeof(SettingsPage))
                {
                    this.NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
                    this.NavView.Header = "Settings";
                }
                else if (ContentFrame.SourcePageType != null)
                {
                    var item = this._pages.FirstOrDefault(p => p.Page == e.SourcePageType);

                    this.NavView.SelectedItem = this.NavView.MenuItems.OfType<NavigationViewItem>()
                        .First(n => n.Tag.Equals(item.Tag));

                    this.NavView.Header = ((NavigationViewItem)this.NavView.SelectedItem)?.Content?.ToString();
                }
            };

            this.NavView.SelectedItem = NavView.MenuItems[0];
            
            this.NavView_Navigate("home", new EntranceNavigationTransitionInfo());
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                this.NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();

                this.NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == true)
            {
                this.NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.SelectedItemContainer != null)
            {
                var navItemTag = args.SelectedItemContainer.Tag.ToString();

                this.NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type page = null;

            if (navItemTag == "settings")
            {
                page = typeof(SettingsPage);
            }
            else
            {
                var item = this._pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));

                page = item.Page;
            }

            var preNavPageType = this.ContentFrame.CurrentSourcePageType;

            if (page == null)
            {
                return;
            }

            if (preNavPageType != page)
            {
                this.ContentFrame.Navigate(page, transitionInfo);
            }
        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            this.TryGoBack();
        }

        private bool TryGoBack()
        {
            if (!this.ContentFrame.CanGoBack)
            {
                return false;
            }

            if (this.NavView.IsPaneOpen && (this.NavView.DisplayMode == NavigationViewDisplayMode.Compact || this.NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
            {
                return false;
            }

            this.ContentFrame.GoBack();

            return true;
        }
    }
}

