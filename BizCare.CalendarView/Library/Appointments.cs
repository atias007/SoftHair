using System;
using System.Collections;

namespace BizCare.Calendar.Library
{
    public class AppointmentsCollection : CollectionBase
    {
        private bool _chronologicalOrder = true;

        internal event EventHandler AppointmentsClear;

        internal AppointmentsCollection()
        {
        }

        public bool ChronologicalOrder
        {
            get { return _chronologicalOrder; }
            set { _chronologicalOrder = value; }
        }

        public Appointment this[int index]
        {
            get { return (Appointment)List[index]; }
            set { List[index] = value; }
        }

        public bool Remove(Appointment appointment)
        {
            if (appointment == null) return false;
            if (!List.Contains(appointment)) return false;
            List.Remove(appointment);
            return true;
        }

        public bool Contains(Appointment appointment)
        {
            if (appointment == null) return false;
            return List.Contains(appointment);
        }

        public void Remove(string id)
        {
            var app = FindAppointment(id);
            if (app == null) return;
            List.Remove(app);
        }

        public void Add(Appointment appointment)
        {
            int pos;
            if (_chronologicalOrder) pos = GetAppointmentPossition(appointment);
            else pos = -1;

            if (pos == -1)
            {
                List.Add(appointment);
            }
            else
            {
                List.Insert(pos, appointment);
            }
        }

        public void ReorderAppointments()
        {
            for (var i = 0; i < List.Count; i++)
            {
                for (var j = i + 1; j < List.Count; j++)
                {
                    if (((Appointment)List[i]).StartDate > ((Appointment)List[j]).StartDate)
                    {
                        SwitchAppointments(i, j);
                    }
                }
            }
        }

        private void SwitchAppointments(int i, int j)
        {
            var app = (Appointment)List[i];
            List[i] = List[j];
            List[j] = app;
        }

        public Appointment FindAppointment(string id)
        {
            foreach (Appointment app in List)
            {
                if (app.Id == id) return app;
            }
            return null;
        }

        public int IndexOf(Appointment appointment)
        {
            for (var i = 0; i < List.Count; i++)
            {
                if (List[i].Equals(appointment)) return i;
            }
            return -1;
        }

        //internal int GetMaxAppointmentId()
        //{
        //    var max = 0;
        //    foreach (Appointment app in List)
        //    {
        //        if (app.Id > max) max = app.Id;
        //    }
        //    return max;
        //}

        internal void SetWidthUnit(int columns)
        {
            foreach (Appointment app in List)
            {
                for (var j = app.VerticalOrder + 1; j <= columns; j++)
                {
                    if (IsAppointmentCongruentWithCol(app, j)) break;
                    app.WidthUnit++;
                }
            }
        }

        internal void ClearLocationData()
        {
            foreach (Appointment t in List)
            {
                t.VerticalOrder = 0;
                t.WidthUnit = 1;
            }
        }

        internal int SetVerticalOrder()
        {
            var cur = 0;

            foreach (Appointment t in List)
            {
                if (t.IsAllDayEvent)
                {
                    t.VerticalOrder = -1;
                    continue;
                }

                var isMatch = false;
                for (var j = 0; j <= cur; j++)
                {
                    if (!IsAppointmentCongruentWithCol(t, j))
                    {
                        t.VerticalOrder = j;
                        isMatch = true;
                        break;
                    }
                }

                if (!isMatch)
                {
                    cur++;
                    t.VerticalOrder = cur;
                }
            }

            if (cur == 0) cur = 1;
            return cur;
        }

        private int GetAppointmentPossition(Appointment appointment)
        {
            for (var i = 0; i < List.Count; i++)
            {
                if (((Appointment)List[i]).StartDate >= appointment.StartDate)
                {
                    return i;
                }
            }
            return -1;
        }

        private static bool IsAppointmentCongruent(Appointment appointment1, Appointment appointment2)
        {
            Appointment appE, appL;

            if (appointment1.StartDate < appointment2.StartDate)
            {
                appE = appointment1; appL = appointment2;
            }
            else
            {
                appE = appointment2; appL = appointment1;
            }

            var ret = (appE.EndDate > appL.StartDate);
            return ret;
        }

        private bool IsAppointmentCongruentWithCol(Appointment appointment, int col)
        {
            foreach (Appointment t in List)
            {
                if (t.VerticalOrder == col)
                {
                    if (IsAppointmentCongruent(appointment, t))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal int GetAllDayEventsCount()
        {
            var cnt = 0;
            foreach (Appointment t in List)
            {
                if (t.IsAllDayEvent) cnt++;
            }
            return cnt;
        }

        protected override void OnClear()
        {
            if (AppointmentsClear != null) AppointmentsClear(this, new EventArgs());
            base.OnClear();
        }
    }
}