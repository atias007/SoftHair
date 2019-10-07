using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BizCare.Calendar.Library
{
    public class AttendeesCollection : CollectionBase
    {
        internal AttendeesCollection() { }


        public int this[int index]
        {
            get { return (int)List[index]; }
        }

        public void Add(int id)
        {
            List.Add(id);
        }

        public void Remove(int id)
        {
            List.Remove(id);
        }
    }
}
