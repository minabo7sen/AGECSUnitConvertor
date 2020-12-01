﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FreshMvvm
{
    public abstract class FreshBasePageModel : INotifyPropertyChanged
    {
        private bool _alreadyAttached;
        private object _args;
        private NavigationPage _navigationPage;

        /// <summary>
        ///     Used when a page is shown modal and wants a new Navigation Stack
        /// </summary>
        public string CurrentNavigationServiceName = Constants.DefaultNavigationServiceName;

        /// <summary>
        ///     Is true when this model is the first of a new navigation stack
        /// </summary>
        public bool IsModalFirstChild;

        /// <summary>
        ///     Used when a page is shown modal and wants a new Navigation Stack
        /// </summary>
        public string PreviousNavigationServiceName;

        public string Title { get; set; }
        public string Icon { get; set; }

        /// <summary>
        ///     This property is used by the FreshBaseContentPage and allows you to set the toolbar items on the page.
        /// </summary>
        public ObservableCollection<ToolbarItem> ToolbarItems { get; set; }

        /// <summary>
        ///     The previous page model, that's automatically filled, on push
        /// </summary>
        public FreshBasePageModel PreviousPageModel { get; set; }

        /// <summary>
        ///     A reference to the current page, that's automatically filled, on push
        /// </summary>
        public Page CurrentPage { get; set; }

        /// <summary>
        ///     Core methods are basic built in methods for the App including Pushing, Pop and Alert
        /// </summary>
        public IPageModelCoreMethods CoreMethods { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        ///     This event is raise when a page is Popped, this might not be raise everytime a page is Popped.
        ///     Note* this might be raised multiple times.
        /// </summary>
        public event EventHandler PageWasPopped;

        /// <summary>
        ///     This method is called when a page is Pop'd, it also allows for data to be returned.
        /// </summary>
        /// <param name="returnedData">This data that's returned from </param>
        public virtual void ReverseInit(object returnedData)
        {
        }

        /// <summary>
        ///     This method is called when the PageModel is loaded, the initData is the data that's sent from pagemodel before
        /// </summary>
        /// <param name="initData">Data that's sent to this PageModel from the pusher</param>
        public virtual async Task Init(object initData)
        {
            _args = initData;
        }

        internal void WireEvents(Page page)
        {
            page.Appearing += new WeakEventHandler<EventArgs>(ViewIsAppearing).Handler;
            page.Disappearing += new WeakEventHandler<EventArgs>(ViewIsDisappearing).Handler;
        }

        /// <summary>
        ///     This means the current PageModel is shown modally and can be pop'd modally
        /// </summary>
        public bool IsModalAndHasPreviousNavigationStack()
        {
            return !string.IsNullOrWhiteSpace(PreviousNavigationServiceName) &&
                   PreviousNavigationServiceName != CurrentNavigationServiceName;
        }

        /// <summary>
        ///     This method is called when the view is disappearing.
        /// </summary>
        protected virtual void ViewIsDisappearing(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     This methods is called when the View is appearing
        /// </summary>
        protected virtual void ViewIsAppearing(object sender, EventArgs e)
        {
            if (!_alreadyAttached)
                AttachPageWasPoppedEvent();
        }

        /// <summary>
        ///     This is used to attach the page was popped method to a NavigationPage if available
        /// </summary>
        private void AttachPageWasPoppedEvent()
        {
            if (!(CurrentPage.Parent is NavigationPage navPage)) return;
            _navigationPage = navPage;
            _alreadyAttached = true;
            navPage.Popped += new WeakEventHandler<NavigationEventArgs>(HandleNavPagePopped).Handler;
        }

        private void HandleNavPagePopped(object sender, NavigationEventArgs e)
        {
            if (e.Page == CurrentPage) RaisePageWasPopped();
        }

        public void RaisePageWasPopped()
        {
            PageWasPopped?.Invoke(this, EventArgs.Empty);

            if (CurrentPage.Parent is NavigationPage navPage)
                navPage.Popped -= HandleNavPagePopped;

            if (_navigationPage != null)
                _navigationPage.Popped -= HandleNavPagePopped;

            _navigationPage = null;

            CurrentPage.Appearing -= ViewIsAppearing;
            CurrentPage.Disappearing -= ViewIsDisappearing;
            CurrentPage.BindingContext = null;
        }

        protected virtual bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value)) return false;
            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}