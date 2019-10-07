using System.Collections;

namespace ClientManage.BL.Library
{
    public class TaskCollection : CollectionBase
    {
        public Task this[int index]
        {
            get { return (Task)List[index]; }
            set { List[index] = value; }
        }

        public Task this[string name]
        {
            get 
            { 
                Task res = null;
                var index = IndexOf(name);
                if (index >= 0) res = (Task)List[index];
                return res;
            }
            set 
            {
                var index = IndexOf(name);
                if (index >= 0) List[index] = value;
            }
        }

        public int IndexOf(string name)
        {
            var index = -1;
            for (var i = 0; i < List.Count; i++)
            {
                if (((Task)List[i]).Name == name)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public bool Contains(string name)
        {
            return IndexOf(name) >= 0;
        }

        public void Remove(Task task)
        {
            List.Remove(task);
        }

        public void Remove(string taskName)
        {
            for (var i = 0; i < List.Count; i++)
            {
                if (((Task)List[i]).Name == taskName)
                {
                    List.RemoveAt(i);
                    break;
                }
            }
        }

        public void Add(Task task)
        {
            List.Add(task);
        }

        public void ResetTasks()
        {
            foreach (Task task in List)
            {
                task.Enable = true;
            }
        }
    }
}