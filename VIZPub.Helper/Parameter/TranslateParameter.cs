using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Translate Parameter Class
    /// </summary>
    public class TranslateParameter
    {
        // ================================================
        // Attribute & Property
        // ================================================
        internal Dictionary<TranslateParameters, object> Parameter { get; set; }


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public TranslateParameter()
        {
            Parameter = new Dictionary<TranslateParameters, object>();
        }

        // ================================================
        // Function
        // ================================================
        internal bool GetBoolean(object value)
        {
            bool val = false;

            if (value is System.Boolean)
                val = ((bool)value) == true ? true : false;
            else if (value is System.Int32)
                val = ((int)value) == 1 ? true : false;
            else if (value is System.String)
                val = ((string)value) == "1" ? true : false;

            return val;
        }

        internal int GetInteger(object value)
        {
            int val = 0;

            if (value is System.String)
                val = Convert.ToInt32((string)value);
            else if (value is System.Int32)
                val = (int)value;

            return val;
        }

        internal string GetParameter(TranslateParameters key, object value)
        {
            string parameter = String.Empty;

            switch (key)
            {
                case TranslateParameters.MODE:
                    parameter = string.Format("-mode {0}", GetInteger(value));
                    break;
                case TranslateParameters.INPUT:
                    parameter = string.Format("-i \"{0}\"", value);
                    break;
                case TranslateParameters.OUTPUT:
                    parameter = string.Format("-o \"{0}\"", value);
                    break;
                default:
                    throw new NullReferenceException("Undefined Parameter.");
                    //break;
            }

            if (String.IsNullOrEmpty(parameter) == true)
                throw new NullReferenceException("Null Parameter.");

            return parameter;
        }



        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Add Parameter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <returns>Result</returns>
        public bool Add(TranslateParameters key, object value)
        {
            if (Parameter.ContainsKey(key) == true) return false;

            Parameter.Add(key, value);
            return true;
        }

        /// <summary>
        /// Exist Parameter
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Result</returns>
        public bool Exist(TranslateParameters key)
        {
            return Parameter.ContainsKey(key);
        }

        /// <summary>
        /// Get Parameter Value
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Result</returns>
        public object GetValue(TranslateParameters key)
        {
            if (Exist(key) == true) return Parameter[key];
            else return null;
        }

        /// <summary>
        /// Set Parameter Value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void SetValue(TranslateParameters key, object value)
        {
            if (Exist(key) == false)
                Add(key, value);
            else
                Parameter[key] = value;
        }

        /// <summary>
        /// Parameter To String
        /// </summary>
        /// <returns>Result</returns>
        public override string ToString()
        {
            string parameter = String.Empty;

            foreach (KeyValuePair<TranslateParameters, object> item in Parameter)
            {
                parameter += string.Format(" {0}", GetParameter(item.Key, item.Value));
            }

            return parameter;
        }
    }
}
