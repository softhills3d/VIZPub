using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Image Parameter Class
    /// </summary>
    public class ImageParameter
    {
        // ================================================
        // Attribute & Property
        // ================================================
        internal Dictionary<ImageParameters, object> Parameter { get; set; }


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public ImageParameter()
        {
            Parameter = new Dictionary<ImageParameters, object>();
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

        internal float GetFloat(object value)
        {
            float val = 0.0f;

            if (value is System.String)
                val = Convert.ToSingle((string)value);
            else if (value is System.Single)
                val = Convert.ToSingle(value);

            return val;
        }

        internal string GetParameter(ImageParameters key, object value)
        {
            string parameter = String.Empty;

            switch (key)
            {
                case ImageParameters.INPUT:
                    parameter = string.Format("-i \"{0}\"", value);
                    break;
                case ImageParameters.OUTPUT:
                    parameter = string.Format("-o \"{0}\"", value);
                    break;
                case ImageParameters.WIDTH:
                    parameter = string.Format("-w {0}", GetInteger(value));
                    break;
                case ImageParameters.HEIGHT:
                    parameter = string.Format("-h {0}", GetInteger(value));
                    break;
                case ImageParameters.SCALE:
                    parameter = string.Format("-is {0}", GetFloat(value));
                    break;
                case ImageParameters.LOG:
                    parameter = string.Format("-log {0}", GetBoolean(value) == true ? "t" : "f");
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
        public bool Add(ImageParameters key, object value)
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
        public bool Exist(ImageParameters key)
        {
            return Parameter.ContainsKey(key);
        }

        /// <summary>
        /// Get Parameter Value
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Result</returns>
        public object GetValue(ImageParameters key)
        {
            if (Exist(key) == true) return Parameter[key];
            else return null;
        }

        /// <summary>
        /// Set Parameter Value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void SetValue(ImageParameters key, object value)
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

            foreach (KeyValuePair<ImageParameters, object> item in Parameter)
            {
                parameter += string.Format(" {0}", GetParameter(item.Key, item.Value));
            }

            return parameter;
        }
    }
}
