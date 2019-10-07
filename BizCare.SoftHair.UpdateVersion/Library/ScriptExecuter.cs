using System;
using System.Collections.Generic;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class ScriptExecuter : ActionBase
    {
        private List<string> Queries { get; set; }
        public SqlRunner Runner { get; set; }

        public ScriptExecuter(string scriptText, SqlRunner runner)
        {
            Runner = runner;

            var arr = scriptText.Split(';');
            Queries = new List<string>();
            foreach (var s in arr)
            {
                if (s.Trim().Length > 0)
                {
                    Queries.Add(s.Trim());
                }
            }
        }

        public int Count
        {
            get
            {
                return Queries.Count;
            }
        }

        public void Execute()
        {
            foreach (var q in Queries)
            {
                if (q.Trim().Length > 0)
                {
                    var text = q.Length <= 100 ? q : q.Substring(0, 100);
                    try
                    {
                        Runner.ExecuteSqlStatement(q);
                        OnLogCreated(new LogEntry("Execute script: " + text));
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("Fail execute script: " + text, ex);
                    }
                }
            }
        }
    }
}
