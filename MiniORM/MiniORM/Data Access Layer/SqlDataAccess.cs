using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;
using MiniORM.Models;

namespace MiniORM.Data_Access_Layer
{
    public class SqlDataAccess<T> : ISqlDataAccess<T> where T : class,new()
    {

        public const string ConnectionString = "Data Source = DESKTOP-2DBIAFT; Initial Catalog = MiniORM_db; Integrated Security = true";

        public void Insert(T item)
        {
            Queue<int> listValue = new Queue<int>();
            Queue<int> objectValue = new Queue<int>();
            InsertToDB(item, ref listValue, ref objectValue);
        }

        private int InsertToDB(T item, ref Queue<int> listValue, ref Queue<int> objectValue)
        {


            NestedInsertion(item, ref listValue, ref objectValue);

            var properties = item.GetType().GetProperties();


            var columns = string.Join(", ", properties.Select(p => p.Name));
            var columnParameters = string.Join(", ", properties.Select(p => $"@{p.Name}"));
            var sql = $"INSERT INTO {item.GetType().Name} ({columns}) VALUES ({columnParameters})";
            //Console.WriteLine(sql);

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                
                foreach (var property in properties)
                {
                    var propertyValue = property.GetValue(item);
                    Type propType = property.PropertyType;
                    if (propType.IsGenericType)
                        propType = propType.GetGenericTypeDefinition();
                    if (propType != typeof(int) && propType != typeof(string) && propType != typeof(double)
                                    && propType != typeof(DateTime))
                    {
                        if (propType == typeof(List<>))
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", listValue.Peek());

                            //Console.WriteLine($"from list, there we go @{property.Name}" + " " + listValue.Peek());

                            listValue.Dequeue();
                        }
                        else
                        {

                            command.Parameters.AddWithValue($"@{property.Name}", objectValue.Peek());

                           // Console.WriteLine($" from obj, there we go @{property.Name}" + " " + objectValue.Peek());

                            objectValue.Dequeue();
                        }

                    }
                    else
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item));
                }
                connection.Open();

                command.ExecuteNonQuery();
                var id = properties.Where(p => p.Name == "Id").Select(i => i.GetValue(item)).ToList();
               // Console.WriteLine("Id to return is " + id.First());
                return Convert.ToInt32(id.FirstOrDefault());

            }
        }
        private void NestedInsertion(T item,ref Queue<int>listValue,ref Queue<int>objectValue)
        {
            var properties = item.GetType().GetProperties();
          
            foreach (var val in properties)
            {
                var propertyValue = val.GetValue(item);

                Type propType = val.PropertyType;

                if (propType.IsGenericType)
                    propType = propType.GetGenericTypeDefinition();
                if (propType != typeof(int) && propType != typeof(string) && propType != typeof(double)
                    && propType != typeof(DateTime))
                {
                    if (propType == typeof(List<>))
                    {

                        Type genericTypeArgument = val.PropertyType.GetGenericArguments()[0];

                        var list = propertyValue as ICollection;

                        foreach (var it in list)
                        {
                            var b = InsertToDB((T)it,ref listValue,ref objectValue);
                            listValue.Enqueue(b);
                        }
                    }
                    else
                    {
                        var a = InsertToDB((T)propertyValue, ref listValue, ref objectValue);
                        objectValue.Enqueue(a);
                    }

                }
            }

        }
       
        public void Update(T item)
        {
            Queue<int> listValue = new Queue<int>();
            Queue<int> objectValue = new Queue<int>();
            UpdateDB(item, ref listValue, ref objectValue);
        }

        private int UpdateDB(T item, ref Queue<int> listValue, ref Queue<int> objectValue)
        {
            NestedUpdate(item, ref listValue, ref objectValue);

            var properties = item.GetType().GetProperties();

            var columnUpdates = properties.Where(p => (p.Name != "Id"))
                                          .Select(p => $"{p.Name} = @{p.Name}");
            var columns = string.Join(", ", columnUpdates);

           // Console.WriteLine(columns);
            var columnId = string.Join(", ", properties.Select(p => p.Name).Where(p => p == "Id"));
           // Console.WriteLine(columnId);

            var sql = $"UPDATE {item.GetType().Name} SET {columns} WHERE {columnId} = @{columnId}";
           // Console.WriteLine(sql);
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {

                foreach (var property in properties)
                {
                    var propertyValue = property.GetValue(item);
                    Type propType = property.PropertyType;
                    if (propType.IsGenericType)
                        propType = propType.GetGenericTypeDefinition();
                    if (propType != typeof(int) && propType != typeof(string) && propType != typeof(double)
                                    && propType != typeof(DateTime))
                    {
                        if (propType == typeof(List<>))
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", listValue.Peek());

                           // Console.WriteLine($"from list, there we go @{property.Name}" + " " + listValue.Peek());
                            listValue.Dequeue();
                        }
                        else
                        {

                            command.Parameters.AddWithValue($"@{property.Name}", objectValue.Peek());

                            //Console.WriteLine($" from obj, there we go @{property.Name}" + " " + objectValue.Peek());
                            objectValue.Dequeue();
                        }

                    }
                    else
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item));
                }
                connection.Open();
                command.ExecuteNonQuery();
                var id = properties.Where(p => p.Name == "Id").Select(i => i.GetValue(item)).ToList();
                return Convert.ToInt32(id.FirstOrDefault());
            }

        }
        private void NestedUpdate(T item, ref Queue<int> listValue, ref Queue<int> objectValue)
        {
            var properties = item.GetType().GetProperties();

            foreach (var val in properties)
            {
                var propertyValue = val.GetValue(item);
                Type propType = val.PropertyType;
                if (propType.IsGenericType)
                    propType = propType.GetGenericTypeDefinition();
                if (propType != typeof(int) && propType != typeof(string) && propType != typeof(double)
                    && propType != typeof(DateTime))
                {
                    if (propType == typeof(List<>))
                    {

                        Type genericTypeArgument = val.PropertyType.GetGenericArguments()[0];

                        var list = propertyValue as ICollection;

                        foreach (var it in list)
                        {
                            listValue.Enqueue(UpdateDB((T)it,ref listValue,ref objectValue));
                        }
                    }
                    else
                    { 
                          objectValue.Enqueue(UpdateDB((T)propertyValue,ref listValue, ref objectValue));
                    }

                }

            }

        }

        public void Delete(int id)
        {
            var sql = $"Delete from {typeof(T).Name} where Id=@Id";
           // Console.WriteLine(sql);
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }

        }
        public void Delete(T item)
        {

            NestedDelete(item);

            var properties = item.GetType().GetProperties();

            var id = Convert.ToInt32(properties.Where(p => p.Name == "Id").Select(i => i.GetValue(item)).ToList().FirstOrDefault());
            var sql = $"Delete from {item.GetType().Name} where Id=@Id";
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }

        }

        private void NestedDelete(T item)
        {
            var properties = item.GetType().GetProperties();

            foreach (var val in properties)
            {
                var propertyValue = val.GetValue(item);
                var propertyName = val.Name;
                Type propType = val.PropertyType;
                if (propType.IsGenericType)
                    propType = propType.GetGenericTypeDefinition();
                if (propType != typeof(int) && propType != typeof(string) && propType != typeof(double)
                    && propType != typeof(DateTime))
                {
                    if (propType == typeof(List<>))
                    {

                        Type genericTypeArgument = val.PropertyType.GetGenericArguments()[0];

                        var list = propertyValue as ICollection;

                        foreach (var it in list)
                        {
                            Delete((T)it);
                        }
                    }
                    else
                    {
                        Delete((T)propertyValue);

                    }

                }

            }
        }

        public List<T> GetAll()
        {
            var list = new List<T>();

            var properties = typeof(T).GetProperties();

            var columnNames = properties.Select(p => p.Name);
            var columns = string.Join(", ", columnNames);

            var sql = $"SELECT {columns} FROM {typeof(T).Name}";

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new T();

                        foreach (var property in properties)
                        {
                            property.SetValue(model, reader[property.Name]);
                        }

                        list.Add(model);
                    }
                }
            }

            return list;
        }


        public List<T> GetById(int id)
        {
            var list = new List<T>();

            var properties = typeof(T).GetProperties();

            var columnNames = properties.Select(p => p.Name);
            var columns = string.Join(", ", columnNames);

            var sql = $"SELECT {columns} FROM {typeof(T).Name} where Id=@Id";

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new T();

                        foreach (var property in properties)
                        {
                            property.SetValue(model, reader[property.Name]);
                        }

                        list.Add(model);
                    }
                }
            }

            return list;
        }
    }
}
