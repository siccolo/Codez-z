using System;
using System.Linq;
using System.Reflection;

namespace DataStore.Helpers
{
    public static class DataTableExtensions
    {
        public static T ToObject<T>(this System.Data.DataTable dt) where T : new()
        {
            var obj = dt.Rows.OfType<System.Data.DataRow>().Select(dr => dr.ToObject<T>()).FirstOrDefault();
            return obj;
        }

        public static T ToObject<T>(this System.Data.DataRow dataRow) where T : new()
        {
            T item = new T();
            foreach (System.Data.DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value)
                {
                    var result = Convert.ChangeType(dataRow[column], property.PropertyType);
                    property.SetValue(item, result, null);
                }
            }

            return item;
        }
    }
}
