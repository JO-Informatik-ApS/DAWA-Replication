namespace JOInformatik.DawaReplication.Helpers
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>Utility class for logging text.</summary>
    public static class LoggingUtils
    {
        /// <summary>
        /// Returns member name via CallerMemberNameAttribute.
        /// </summary>
        /// <param name="memberName">Leave it empty!</param>
        /// <returns>The value of CallerMemberNameAttribute or paramter if not empty.</returns>
        public static string GetMemberName([CallerMemberName]string memberName = null)
        {
            return memberName;
        }

        /// <summary>
        /// Returns method name via CallerMemberNameAttribute with '()' as postfix.
        /// </summary>
        /// <param name="methodName">Leave it empty!</param>
        /// <returns>The value of CallerMemberNameAttribute or paramter if not empty.</returns>
        public static string GetMethodName([CallerMemberName]string methodName = null)
        {
            // Maybe later: [CallerLineNumber]int lineNumber= 0
            return methodName + "()";
        }

        /// <summary>
        /// Returns input parameter value as JSON string.
        /// </summary>
        /// <param name="value">Any object.</param>
        /// <param name="formatting">Controls if the returned JSON string should be indented.</param>
        /// <returns>A JSON string.</returns>
        public static string Json(object value, Newtonsoft.Json.Formatting formatting = Newtonsoft.Json.Formatting.None)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value, formatting);
        }

        /// <summary>
        /// Creates a formatted message for logging purpose.
        /// </summary>
        /// <param name="methodName">The name of the method creating the message.</param>
        /// <param name="message">The initial message string.</param>
        /// <param name="value">Any object that should be added to the message.</param>
        /// <param name="valueToJson">Controls if parameter value is serialized into a JSON string.</param>
        /// <returns>A string in format methodName + " " + message + " " + value.</returns>
        public static string MakeMessage(string methodName, string message = null, object value = null, bool valueToJson = true)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                // Make sure methodName is never empty:
                methodName = "MethodNameIsMissing";
            }

            var msg = methodName;

            if (!string.IsNullOrEmpty(message))
            {
                msg += " " + message;
            }

            if (value != null)
            {
                if (!msg.EndsWith(" ", StringComparison.CurrentCultureIgnoreCase))
                {
                    msg += " ";
                }

                if (valueToJson)
                {
                    msg += Newtonsoft.Json.JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.None);
                }
                else
                {
                    msg += value.ToString();
                }
            }

            return msg;
        }
    }
}

