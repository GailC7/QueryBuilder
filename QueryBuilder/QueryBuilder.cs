
using Microsoft.Data.Sqlite;
using QueryBuilder_Lab.Models;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace QueryBuilder_Lab
{
        public class QueryBuilder : IDisposable
        {
            // db connection referenced by the 'connection' field
            private SqliteConnection connection;

        /// <summary>
        /// Constructor will set up our connection to a given SQLite database file and open it.
        /// </summary>
        /// <param name="locationOfDatabase">File path to a .db file</param>
        public QueryBuilder(string locationOfDatabase)
            {
                connection = new SqliteConnection("Data Source=" + locationOfDatabase);
                connection.Open();
            }

            /// <summary>
            /// By implementing IDisposable, we have the capability to 
            /// use a QueryBuilder object in a 'using' statement in our
            /// driver; when that using statement is complete, our Sqlite
            /// connection will be closed automatically
            /// </summary>
            
            
            public List<T> ReadAll<T>() where T : IClassModel, new()
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {typeof(T).Name}";
                var reader = command.ExecuteReader();
                T data;
                var datas = new List<T>();
                while (reader.Read())
                {
                    data = new T();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (typeof(T).GetProperty(reader.GetName(i)).PropertyType == typeof(int))
                            typeof(T).GetProperty(reader.GetName(i)).SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                        else
                            typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
                    }
                    datas.Add(data);
                }
                return datas;
            }

            public T Read<T>(int id) where T : IClassModel, new()
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE Id = {id}";
                var reader = command.ExecuteReader();
                T data = new T();
                var datas = new List<T>();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (typeof(T).GetProperty(reader.GetName(i)).PropertyType == typeof(int))
                            typeof(T).GetProperty(reader.GetName(i)).SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                        else
                            typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));

                    }
            }
                return data;
            }

            public void Create<T>(T obj)
            {
                //Get prop names as an object
                PropertyInfo[] properties = typeof(T).GetProperties();

                List<string> values = new List<string>();
                List<string> names = new List<string>();
                PropertyInfo property;

                //Loop through each of the object properties
                foreach(PropertyInfo propertyInfo in properties)
                {
                    if(propertyInfo.PropertyType == typeof(string))
                    {
                        values.Add("\"" + propertyInfo.GetValue(obj) + "\"");
                        
                    }
                    else //If a number
                    {
                        values.Add(propertyInfo.GetValue(obj).ToString());
                    } 
                    names.Add(propertyInfo.Name);
                    
                }

                //Formatting a string to make it work in SQLLite as a command
                StringBuilder sbValues = new StringBuilder();
                StringBuilder sbNames = new StringBuilder();
                
                for(int i = 0; i < values.Count; i++)
                {
                    //dont want commas at the end of the INSERT command
                    if(i == values.Count -1)
                    {
                        sbValues.Append($"{values[i]}");
                        sbNames.Append($"{names[i]}");
                    }
                    else
                    {
                        sbValues.Append($"{values[i]}, ");
                        sbNames.Append($"{names[i]}, ");
                    }

                }

                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO {typeof(T).Name} ({sbNames}) VALUES ({sbValues})";
                
                var insert = command.ExecuteNonQuery();
            }
            
            public void Update<T>(T obj)
            {
                //Get prop names as an object
                PropertyInfo[] properties = typeof(T).GetProperties();

                List<string> values = new List<string>();
                List<string> names = new List<string>();
                PropertyInfo property;

                //Loop through each of the object properties
                foreach (PropertyInfo propertyInfo in properties)
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        values.Add("\"" + propertyInfo.GetValue(obj) + "\"");

                    }
                    else //If a number
                    {
                        values.Add(propertyInfo.GetValue(obj).ToString());
                    }
                    names.Add(propertyInfo.Name);

                }

                //Formatting a string to make it work in SQLLite as a command
                StringBuilder sbValues = new StringBuilder();
                StringBuilder sbNames = new StringBuilder();

                for (int i = 0; i < values.Count; i++)
                {
                    //dont want commas at the end of the INSERT command
                    if (i == values.Count - 1)
                    {
                        sbValues.Append($"{values[i]}");
                        sbNames.Append($"{names[i]}");
                    }
                    else
                    {
                        sbValues.Append($"{values[i]}, ");
                        sbNames.Append($"{names[i]}, ");
                    }

                }

                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE {typeof(T).Name} SET ({sbNames}) = ({sbValues}) WHERE Id = 99";

                var update = command.ExecuteNonQuery();

            }
            
            public void Delete<T>(T obj) where T : IClassModel
            {
                //Get prop names as an object
                PropertyInfo[] properties = typeof(T).GetProperties();

                List<string> values = new List<string>();
                List<string> names = new List<string>();
                PropertyInfo property;

                //Loop through each of the object properties
                foreach (PropertyInfo propertyInfo in properties)
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        values.Add("\"" + propertyInfo.GetValue(obj) + "\"");

                    }
                    else //If a number
                    {
                        values.Add(propertyInfo.GetValue(obj).ToString());
                    }
                    names.Add(propertyInfo.Name);

                }

                //Formatting a string to make it work in SQLLite as a command
                StringBuilder sbValues = new StringBuilder();
                StringBuilder sbNames = new StringBuilder();

                for (int i = 0; i < values.Count; i++)
                {
                    //dont want commas at the end of the INSERT command
                    if (i == values.Count - 1)
                    {
                        sbValues.Append($"{values[i]}");
                        sbNames.Append($"{names[i]}");
                    }
                    else
                    {
                        sbValues.Append($"{values[i]}, ");
                        sbNames.Append($"{names[i]}, ");
                    }

                }

                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE Id = ({values[0]}) "; 

                var delete = command.ExecuteNonQuery();
                
            }

            public void Dispose()
            {
                connection.Dispose();
            }

        }
    }


