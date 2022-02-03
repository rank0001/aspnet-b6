using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;

namespace MiniORM.Data_Access_Layer
{
    public class SqlDataAccess<T> : ISqlDataAccess<T> where T : class
    {

        public const string ConnectionString = "Data Source = DESKTOP-2DBIAFT; Initial Catalog = MiniORM_db;Integrated Security = true";

        public int Insert(T item)
        {
            var properties = item.GetType().GetProperties();
            int listValue = 0, objValue = 0;

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
                            var b = Insert((T)it);
                            Console.WriteLine("val of b " + b);
                            propertyValue = b;
                            listValue = b;
                            Console.WriteLine("val of listVal " + listValue);
                            // Console.WriteLine("fafs" + " " + propertyName);
                        }
                    }
                    else
                    {
                        var a = Insert((T)propertyValue);
                        propertyValue = a;
                        objValue = a;
                        //Console.WriteLine("objs" + " " + propertyName);
                    }

                }
            }
            var columns = string.Join(", ", properties.Select(p => p.Name));
            var columnParameters = string.Join(", ", properties.Select(p => $"@{p.Name}"));
            var sql = $"INSERT INTO {item.GetType().Name} ({columns}) VALUES ({columnParameters})";
            Console.WriteLine(sql);

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {

                foreach (var property in properties)
                {

                    //Console.WriteLine($"@{property.Name}" + property.GetValue(item));
                    var propertyValue = property.GetValue(item);
                    Type propType = property.PropertyType;
                    if (propType.IsGenericType)
                        propType = propType.GetGenericTypeDefinition();
                    if (propType != typeof(int) && propType != typeof(string) && propType != typeof(double)
                                    && propType != typeof(DateTime))
                    {
                        if (propType == typeof(List<>))
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", listValue);

                            Console.WriteLine($"from list, there we go @{property.Name}" + " " + listValue);
                        }
                        else
                        {

                            command.Parameters.AddWithValue($"@{property.Name}", objValue);

                            Console.WriteLine($" from obj, there we go @{property.Name}" + " " + objValue);
                        }

                    }
                    else
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item));
                }
                connection.Open();

                //command.ExecuteNonQuery();
                //foreach (var item1 in properties)
                //{
                //    if (item1.Name == "Id")
                //    {
                //        Console.WriteLine(item1.GetValue(room2));
                //    }
                //}
                //var vvv = properties.Where(p=>p.Name=="Id").Select(p => p.GetValue(item));
                var id = properties.Where(p => p.Name == "Id").Select(i => i.GetValue(item)).ToList();
                Console.WriteLine("Id to return is " + id.First());
                return Convert.ToInt32(id.FirstOrDefault());

            }
        }
        public int Update(T item)
        {
            var properties = item.GetType().GetProperties();
            int listValue = 0, objValue = 0;
            string objName = "", listName = "";

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

                        listName = propertyName;
                        Type genericTypeArgument = val.PropertyType.GetGenericArguments()[0];

                        var list = propertyValue as ICollection;

                        foreach (var it in list)
                        {
                            listValue = Update((T)it);
                            var prop = it.GetType().GetProperties();

                            //listValue = Convert.ToInt32(prop.Where(p => p.Name == "Id").Select(i => i.GetValue(item)).ToList().FirstOrDefault());

                        }
                    }
                    else
                    {
                        objName = propertyName;

                        objValue = Update((T)propertyValue);

                        // objValue = Convert.ToInt32(properties.Where(p => p.Name == "Id").Select(i => i.GetValue(item)).ToList().FirstOrDefault());
                    }

                }

            }

            var columnUpdates = properties.Where(p => (p.Name != "Id"))
                                          .Select(p => $"{p.Name} = @{p.Name}");
            var columns = string.Join(", ", columnUpdates);

            Console.WriteLine(columns);
            var columnId = string.Join(", ", properties.Select(p => p.Name).Where(p => p == "Id"));
            Console.WriteLine(columnId);

            var sql = $"UPDATE {item.GetType().Name} SET {columns} WHERE {columnId} = @{columnId}";
            Console.WriteLine(sql);
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {

                foreach (var property in properties)
                {

                    //Console.WriteLine($"@{property.Name}" + property.GetValue(item));
                    var propertyValue = property.GetValue(item);
                    Type propType = property.PropertyType;
                    if (propType.IsGenericType)
                        propType = propType.GetGenericTypeDefinition();
                    if (propType != typeof(int) && propType != typeof(string) && propType != typeof(double)
                                    && propType != typeof(DateTime))
                    {
                        if (propType == typeof(List<>))
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", listValue);

                            Console.WriteLine($"from list, there we go @{property.Name}" + " " + listValue);
                        }
                        else
                        {

                            command.Parameters.AddWithValue($"@{property.Name}", objValue);

                            Console.WriteLine($" from obj, there we go @{property.Name}" + " " + objValue);
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
        public int Delete(int id)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine();
            Type[] types = assembly.GetTypes();
            foreach (var item in types)
            {
                if (item.GetInterfaces().Contains(typeof(T)))
                    Console.WriteLine(item.Name);
            }

            var sql = $"Delete from {typeof(T).Name} where Id=@Id";
            Console.WriteLine(sql);
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                return command.ExecuteNonQuery();
            }
            //return 1;

        }
        public int Delete(T item)
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

            var id = Convert.ToInt32(properties.Where(p => p.Name == "Id").Select(i => i.GetValue(item)).ToList().FirstOrDefault());
            var sql = $"Delete from {item.GetType().Name} where Id=@Id";
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                return command.ExecuteNonQuery();
            }

            // return Delete(id);


        }

        //public List<T> GetAll()
        //{
        //    var list = new List<T>();

        //    var properties = typeof(T).GetProperties();
        //    foreach (var item in properties)
        //    {
        //        Console.WriteLine(item.Name);
        //    }

        //    var columnNames = properties.Select(p => p.Name);
        //    var columns = string.Join(", ", columnNames);

        //    var sql = $"SELECT {columns} FROM {typeof(T).Name}";
        //    Console.WriteLine(sql);
        //    Console.WriteLine(properties);

        //    using (var connection = new SqlConnection(ConnectionString))
        //    using (var command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var model = new T();

        //                foreach (var property in properties)
        //                {
        //                    property.SetValue(model, reader[property.Name]);
        //                }

        //                list.Add(model);
        //            }
        //        }
        //    }

        //    return list;
        //}
        //public List<T> GetById(int id)
        //{
        //    var list = new List<T>();

        //    var properties = typeof(T).GetProperties();

        //    var columnNames = properties.Select(p => p.Name);
        //    var columns = string.Join(", ", columnNames);

        //    var sql = $"SELECT {columns} FROM {typeof(T).Name} where Id=@personId";

        //    using (var connection = new SqlConnection(ConnectionString))
        //    using (var command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();
        //        command.Parameters.AddWithValue("@personId", id);
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var model = new T();

        //                foreach (var property in properties)
        //                {
        //                    property.SetValue(model, reader[property.Name]);
        //                }

        //                list.Add(model);
        //            }
        //        }
        //    }

        //    return list;
        //}
    }
}
