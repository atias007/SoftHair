using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace ClientManage.Interfaces
{
    public class ClientPhotoCollection : CollectionBase
    {
        private EventHandler<PhotoListChangedEventArgs> onListChanged;

        public ClientPhoto this[int index]
        {
            get { return (ClientPhoto)List[index]; }
            set { List[index] = value; }
        }

        public ClientPhoto Find(int id)
        {
            ClientPhoto result = null;
            foreach (ClientPhoto photo in List)
            {
                if (photo.Id == id)
                {
                    result = photo;
                    break;
                }
            }
            return result;
        }

        public void Insert(int index, ClientPhoto photo)
        {
            List.Insert(index, photo);
        }

        public int Add(ClientPhoto photo)
        {
            var index = List.Add(photo);
            return index;
        }

        public void Remove(ClientPhoto photo)
        {
            var index = List.IndexOf(photo);
            List.Remove(photo);
        }

        protected virtual void OnListChanged(PhotoListChangedEventArgs ev)
        {
            if (ev.Photo != null && ev.Photo._suspendEvents) return;
            if (onListChanged != null)
            {
                onListChanged(this, ev);
            }
        }

        protected override void OnClear()
        {
            foreach (ClientPhoto photo in List)
            {
                photo.Parent = null;
            }
        }

        protected override void OnClearComplete()
        {
            OnListChanged(new PhotoListChangedEventArgs(ListChangedType.Reset, null));
        }

        protected override void OnInsertComplete(int index, object value)
        {
            var photo = (ClientPhoto)value;
            photo.Parent = this;
            OnListChanged(new PhotoListChangedEventArgs(ListChangedType.ItemAdded, photo));
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            var photo = (ClientPhoto)value;
            photo.Parent = this;
            OnListChanged(new PhotoListChangedEventArgs(ListChangedType.ItemDeleted, photo));
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            if (oldValue != newValue)
            {
                var oldPhoto = (ClientPhoto)oldValue;
                var newPhoto = (ClientPhoto)newValue;

                oldPhoto.Parent = null;
                newPhoto.Parent = this;

                OnListChanged(new PhotoListChangedEventArgs(ListChangedType.ItemAdded, newPhoto));
            }
        }

        internal void ClientPhotoChanged(ClientPhoto photo)
        {
            var index = List.IndexOf(photo);
            OnListChanged(new PhotoListChangedEventArgs(ListChangedType.ItemChanged, (ClientPhoto)List[index]));
        }


        #region IBindingList Members

        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotSupportedException();
        }

        public object AddNew()
        {
            var photo = new ClientPhoto();
            List.Add(photo);
            return photo;
        }

        public bool AllowEdit
        {
            get { return true; }
        }

        public bool AllowNew
        {
            get { return true; }
        }

        public bool AllowRemove
        {
            get { return true; }
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotSupportedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotSupportedException();
        }

        public bool IsSorted
        {
            get { throw new NotSupportedException(); }
        }

        public event EventHandler<PhotoListChangedEventArgs> ListChanged
        {
            add
            {
                onListChanged += value;
            }
            remove
            {
                onListChanged -= value;
            }
        }

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotSupportedException();
        }

        public void RemoveSort()
        {
            throw new NotSupportedException();
        }

        public ListSortDirection SortDirection
        {
            get { throw new NotSupportedException(); }
        }

        public PropertyDescriptor SortProperty
        {
            get { throw new NotSupportedException(); }
        }

        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        public bool SupportsSearching
        {
            get { return false; }
        }

        public bool SupportsSorting
        {
            get { return false; }
        }

        #endregion
    }
}
