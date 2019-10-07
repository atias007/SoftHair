using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BizCare.Calendar.Library
{
    public class CalendarWorkersCollection : CollectionBase
    {
        internal CalendarWorkersCollection() { }

        public CalendarWorker this[int index]
        {
            get { return (CalendarWorker)List[index]; }
        }

        public void Add(CalendarWorker worker)
        {
            List.Insert(0, worker);
        }

        public void Remove(CalendarWorker worker)
        {
            List.Remove(worker);
        }
        public void Remove(int workerId)
        {
            for (var i = 0; i < List.Count; i++)
            {
                if (((CalendarWorker)List[i]).Id == workerId)
                {
                    List.RemoveAt(i);
                    break;
                }
            }
        }
        public bool Contains(int workerId)
        {
            foreach (CalendarWorker worker in List)
            {
                if (worker.Id == workerId) return true;
            }
            return false;
        }

        public CalendarWorker FindWorker(int id)
        {
            foreach (CalendarWorker worker in List)
            {
                if (worker.Id == id) return worker;
            }
            return null;
        }
    }
}
