﻿using Xamarin.Forms;
using System.Collections.Specialized;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace FreshMvvm
{
    public class FreshBaseContentPage : ContentPage
    {
        public FreshBaseContentPage()
        {
            // On<Xamarin.Forms.PlatformConfiguration.iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Automatic);

            var safeInsets = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            safeInsets.Bottom = 0;
            Padding = safeInsets;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var pageModel = BindingContext as FreshBasePageModel;

            if (pageModel != null && pageModel.ToolbarItems != null && pageModel.ToolbarItems.Count > 0)
            {

                pageModel.ToolbarItems.CollectionChanged += PageModel_ToolbarItems_CollectionChanged;

                foreach (var toolBarItem in pageModel.ToolbarItems)
                {
                    if (!(this.ToolbarItems.Contains(toolBarItem)))
                    {
                        this.ToolbarItems.Add(toolBarItem);
                    }
                }
            }

        }

        void PageModel_ToolbarItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (ToolbarItem toolBarItem in e.NewItems)
            {
                if (!(this.ToolbarItems.Contains(toolBarItem)))
                {
                    this.ToolbarItems.Add(toolBarItem);
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (ToolbarItem toolBarItem in e.OldItems)
                {
                    if (!(this.ToolbarItems.Contains(toolBarItem)))
                    {
                        this.ToolbarItems.Add(toolBarItem);
                    }
                }
            }
        }
    }
}

