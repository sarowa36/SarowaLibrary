namespace SarowaLibrary.ToolsLayer.String
{
    public static class StringSpecialFormatter
    {
        /// <summary>
        /// Replace keys to setted value in object. 
        /// <para>Result Example;</para>
        /// <para>str = "Lorem Ipsum {foo} dolor", obj = {foo="bar"} => Lorem Ipsum bar dolor</para>
        /// </summary>
        public static string SpecialFormat(this string str,object obj)
        {
            obj.GetType().GetProperties().ToList().ForEach(field =>
            {
              str=  System.Text.RegularExpressions.Regex.Replace(str, $"{{\\s*{field.Name}\\s*}}",field.GetValue(obj).ToString());
            }); 
            return str;
        }
    }
}
