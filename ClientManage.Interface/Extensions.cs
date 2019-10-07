using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;

namespace ClientManage.Interfaces
{
    public static class Extensions
    {
        static readonly string[] ExludeColumns = new[] { "LINQEntityGUID", "LINQEntityState", "LINQEntityKeepOriginal", "IsRoot" };

        /// <summary>
        /// Toes the data set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            var elementType = typeof(T);
            var table = new DataTable();

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                if (propInfo.PropertyType.IsValueType || propInfo.PropertyType.Equals(typeof(string)))
                {
                    if (!ExludeColumns.Contains(propInfo.Name))
                    {
                        table.Columns.Add(propInfo.Name, GetPropertyType(propInfo));
                    }
                }
            }

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    if (propInfo.PropertyType.IsValueType || propInfo.PropertyType.Equals(typeof(string)))
                    {
                        if (!ExludeColumns.Contains(propInfo.Name))
                        {
                            try
                            {
                                row[propInfo.Name] = propInfo.GetValue(item, null);
                            }
                            catch (Exception)
                            {
                                row[propInfo.Name] = DBNull.Value;
                            }
                        }
                    }
                }

                //This line was missing:
                table.Rows.Add(row);
            }

            var result = new DataSet();
            result.Tables.Add(table);

            return result;
        }

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        private static Type GetPropertyType(PropertyInfo info)
        {
            var result = info.PropertyType;

            if(info.PropertyType.IsGenericType)
            {
                var types = info.PropertyType.GetGenericArguments();
                if(types.Length == 1)
                {
                    result = types[0];
                }
            }

            return result;
        }
    }
}
