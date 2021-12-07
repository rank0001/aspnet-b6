using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Assignment
{
    public static class JSONFormatter
    {

        public static string jsonString = "";
        public static string Convert<T>(object targetObject)
        {
            jsonString += "{";
            Serialization(targetObject, ref jsonString);
            jsonString += "\n}";
            return jsonString;

        }
        public static void Serialization(object mainObject, ref string json, object rootObject = null, int level = 1)
        {
            if (rootObject == null)
                rootObject = mainObject;
            var propertyInfo = mainObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
                );
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                bool commaCheck = true;
                if (i == propertyInfo.Length - 1)
                    commaCheck = false;
                SerializeObject(propertyInfo[i], ref json, rootObject, commaCheck, level);
            }

        }
        public static void SerializeObject(PropertyInfo property, ref string data, object targetObject, bool CheckComma, int level = 1)
        {

            var propertyValue = property.GetValue(targetObject);

            Type propType = property.PropertyType;


            if (propType.IsGenericType)
                propType = propType.GetGenericTypeDefinition();

            if (propType.IsArray)
                propType = typeof(Array);

            if (propType == typeof(int) || propType.IsEnum)
            {
                data = StringConcat(propType, propertyValue, property, CheckComma, ref data, level);
            }
            else if (propType == typeof(double))
            {
                data = StringConcat(propType, propertyValue, property, CheckComma, ref data, level);
            }
            else if (propType == typeof(string))
            {
                data = StringConcat(propType, propertyValue, property, CheckComma, ref data, level);
            }
            else if (propType == typeof(DateTime))
            {
                data = StringConcat(propType, propertyValue, property, CheckComma, ref data, level);
            }
            else if (propType == typeof(List<>))
            {
                int size = 0;
                Type genericTypeArgument = property.PropertyType.GetGenericArguments()[0];
                var list = propertyValue as ICollection;
                
                if (genericTypeArgument.IsClass || (genericTypeArgument.IsValueType && !genericTypeArgument.IsEnum))
                {
                    int i = 0;
                    data = StringConcat(propType, propertyValue, property, false, ref data, level, genericTypeArgument);
                    foreach (var item in list)
                    {
                        data = StringConcat(propType, propertyValue, property, false, ref data, level, genericTypeArgument, '{');

                        //creating the nested object recursively

                        Serialization(item, ref data, item, level + 1);

                        i++;
                        if (i == list.Count)
                        {
                            data = StringConcat(propType, propertyValue, property, false, ref data, level, genericTypeArgument, '}');
                        }
                        else
                        {
                            data = StringConcat(propType, propertyValue, property, false, ref data, level, genericTypeArgument, '}') + ",";
                        }
                    }
                    if(level==1 && CheckComma)
                    {
                        data = StringConcat(propType, propertyValue, property, true, ref data, level, genericTypeArgument, ']');
                    }
                    else
                    {
                        data = StringConcat(propType, propertyValue, property, false, ref data, level, genericTypeArgument, ']');
                    }
                    
                }
            }
            else
            {
                data = StringConcat(propType, propertyValue, property, false, ref data, level) + "\"" + property.Name + "\"" + ":";

                data = StringConcat(propType, propertyValue, property, false, ref data, level) + "{";

                //creating the nested object recursively

                Serialization(propertyValue, ref data, propertyValue, level + 1);

                data = StringConcat(propType, propertyValue, property, false, ref data, level) + "},";

            }
        }
        //helper function for concatenating the json data
        private static string StringConcat(Type propertyType, object propValue, PropertyInfo prop, bool CheckingComma, ref string jsonData, int level, Type genericArgument = null, char ch = '(')
        {
            jsonData += "\n";
            for (int j = 0; j < level; j++)
            {
                
                jsonData += "\t";
            }
            if (propertyType == typeof(string))
                jsonData += "\"" + prop.Name + "\"" + " : " + "\"" + (string)propValue + "\"";
            else if (propertyType == typeof(double))
                jsonData += "\"" + prop.Name + "\"" + " : " + (double)propValue;
            else if (propertyType == typeof(int))
                jsonData += "\"" + prop.Name + "\"" + " : " + (int)propValue;
            else if (propertyType == typeof(DateTime))
                jsonData += "\"" + prop.Name + "\"" + " : " + "\"" + (string)propValue.ToString() + "\"";
            else if (propertyType == typeof(List<>))
            {
                if (ch != '(')
                {
                    jsonData += ch;
                }
                else
                {
                    jsonData += "\"" + genericArgument.Name + "\"" + ":";
                    jsonData += "\n";
                    for (int j = 0; j < level; j++)
                    {
                        jsonData += "\t";
                    }
                    jsonData += "[";
                }
            }
            if (CheckingComma)
                jsonData += ",";
            return jsonData;
        }
    }

}