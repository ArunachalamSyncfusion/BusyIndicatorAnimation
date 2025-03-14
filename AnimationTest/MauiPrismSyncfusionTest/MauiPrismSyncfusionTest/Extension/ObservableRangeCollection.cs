﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

//This is from https://github.com/jamesmontemagno/mvvm-helpers/blob/master/MvvmHelpers/ObservableRangeCollection.cs
namespace MiPlanMobile.Model.Extension
{
    public class ObservableRangeCollection<T> : ObservableCollection<T>
    {
        /// <summary> 
        /// Initializes a new instance of the System.Collections.ObjectModel.ObservableCollection(Of T) class. 
        /// </summary> 
        public ObservableRangeCollection()
            : base()
        {
        }

        /// <summary> 
        /// Initializes a new instance of the System.Collections.ObjectModel.ObservableCollection(Of T) class that contains elements copied from the specified collection. 
        /// </summary> 
        /// <param name="collection">collection: The collection from which the elements are copied.</param> 
        /// <exception cref="System.ArgumentNullException">The collection parameter cannot be null.</exception> 
        public ObservableRangeCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }

        /// <summary> 
        /// Adds the elements of the specified collection to the end of the ObservableCollection(Of T). 
        /// </summary> 
        public void AddRange(IEnumerable<T> collection,
            NotifyCollectionChangedAction notificationMode = NotifyCollectionChangedAction.Add)
        {
            if (notificationMode != NotifyCollectionChangedAction.Add &&
                notificationMode != NotifyCollectionChangedAction.Reset)
            {
                throw new ArgumentException("Mode must be either Add or Reset for AddRange.", nameof(notificationMode));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            CheckReentrancy();

            int startIndex = Count;

            bool itemsAdded = AddArrangeCore(collection);

            if (!itemsAdded)
            {
                return;
            }

            if (notificationMode == NotifyCollectionChangedAction.Reset)
            {
                RaiseChangeNotificationEvents(action: NotifyCollectionChangedAction.Reset);
                return;
            }

            List<T> changedItems = collection is List<T> ? (List<T>) collection : new List<T>(collection);

            RaiseChangeNotificationEvents(
                action: NotifyCollectionChangedAction.Add,
                changedItems: changedItems,
                startingIndex: startIndex);
        }

        /// <summary> 
        /// Removes the first occurence of each item in the specified collection from ObservableCollection(Of T). NOTE: with notificationMode = Remove, removed items starting index is not set because items are not guaranteed to be consecutive.
        /// </summary> 
        public void RemoveRange(IEnumerable<T> collection,
            NotifyCollectionChangedAction notificationMode = NotifyCollectionChangedAction.Reset)
        {
            if (notificationMode != NotifyCollectionChangedAction.Remove &&
                notificationMode != NotifyCollectionChangedAction.Reset)
            {
                throw new ArgumentException("Mode must be either Remove or Reset for RemoveRange.",
                    nameof(notificationMode));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            CheckReentrancy();

            if (notificationMode == NotifyCollectionChangedAction.Reset)
            {
                bool raiseEvents = false;
                foreach (T item in collection)
                {
                    Items.Remove(item);
                    raiseEvents = true;
                }

                if (raiseEvents)
                {
                    RaiseChangeNotificationEvents(action: NotifyCollectionChangedAction.Reset);
                }

                return;
            }

            List<T> changedItems = new List<T>(collection);

            for (int iChangedItem = 0; iChangedItem < changedItems.Count; iChangedItem++)
            {
                if (!Items.Remove(changedItems[iChangedItem]))
                {
                    changedItems.RemoveAt(iChangedItem); //Can't use a foreach because changedItems is intended to be (carefully) modified
                    iChangedItem--;
                }
            }

            if (changedItems.Count == 0)
            {
                return;
            }

            RaiseChangeNotificationEvents(
                action: NotifyCollectionChangedAction.Remove,
                changedItems: changedItems);
        }

        /// <summary> 
        /// Clears the current collection and replaces it with the specified item. 
        /// </summary> 
        public void Replace(T item) => ReplaceRange(new T[] {item});

        /// <summary> 
        /// Clears the current collection and replaces it with the specified collection. 
        /// </summary> 
        public void ReplaceRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            CheckReentrancy();

            bool previouslyEmpty = Items.Count == 0;

            Items.Clear();

            AddArrangeCore(collection);

            bool currentlyEmpty = Items.Count == 0;

            if (previouslyEmpty && currentlyEmpty)
            {
                return;
            }

            RaiseChangeNotificationEvents(action: NotifyCollectionChangedAction.Reset);
        }

        private bool AddArrangeCore(IEnumerable<T> collection)
        {
            bool itemAdded = false;

            foreach (T item in collection)
            {
                Items.Add(item);
                itemAdded = true;
            }

            return itemAdded;
        }

        private void RaiseChangeNotificationEvents(NotifyCollectionChangedAction action, List<T>? changedItems = null,
            int startingIndex = -1)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));

            if (changedItems is null)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(action));
            }
            else
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, changedItems: changedItems,
                    startingIndex: startingIndex));
            }
        }
    }
}
