using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Translate Parameter Class
    /// </summary>
    public class BomXmlParameter
    {
        // ================================================
        // Attribute & Property
        // ================================================
        internal Dictionary<BomXmlParameters, object> Parameter { get; set; }


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public BomXmlParameter()
        {
            Parameter = new Dictionary<BomXmlParameters, object>();
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

        internal string GetReferenceFilePath(object value)
        {
            List<string> items = (List<string>)value;

            return string.Join(";", items.ToArray());
        }

        internal string GetParameter(BomXmlParameters key, object value)
        {
            string parameter = String.Empty;

            switch (key)
            {
                case BomXmlParameters.MODE:
                    parameter = string.Format("-mode {0}", value);
                    break;
                case BomXmlParameters.INPUT:
                    parameter = string.Format("-i \"{0}\"", value);
                    break;
                case BomXmlParameters.OUTPUT:
                    parameter = string.Format("-o \"{0}\"", value);
                    break;
                case BomXmlParameters.SERVER_IP:
                    parameter = string.Format("-si \"{0}\"", value);
                    break;
                case BomXmlParameters.SERVER_PORT:
                    parameter = string.Format("-sp \"{0}\"", value);
                    break;
                case BomXmlParameters.LOG:
                    parameter = string.Format("-log {0}", (int)((TranslateLog)value));
                    break;
                case BomXmlParameters.EXPORT_FULL_STRUCTURE:
                    parameter = string.Format("-fs {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.EXPORT_PART_ATTRIBUTE:
                    parameter = string.Format("-att {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.EXPORT_CAD_INFORMATION:
                    parameter = string.Format("-info {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.REFERENCE_FILE_PATH:
                    parameter = string.Format("-path {0}", GetReferenceFilePath(value));
                    break;
                case BomXmlParameters.SUPRESSED_ENTITY:
                    parameter = string.Format("-supressed {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.REFERENCE_NAME:
                    parameter = string.Format("-refName {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.THUMBNAIL_IMAGE_WIDTH:
                    parameter = string.Format("-iw {0}", GetInteger(value));
                    break;
                case BomXmlParameters.THUMBNAIL_IMAGE_HEIGHT:
                    parameter = string.Format("-ih {0}", GetInteger(value));
                    break;
                case BomXmlParameters.RESOLUTION:
                    parameter = string.Format("-dpi {0}", GetInteger(value));
                    break;
                case BomXmlParameters.IMAGE_QUALITY:
                    parameter = string.Format("-iq {0}", GetInteger(value));
                    break;
                case BomXmlParameters.THUMBNAIL_TARGET:
                    parameter = string.Format("-subimg {0}", (int)((ThumbnailImageTarget)value));
                    break;
                case BomXmlParameters.USE_MULTI_PROCESS:
                    parameter = string.Format("-useMulti {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.HIDDEN_ENTITY:
                    parameter = string.Format("-hidden {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.CREATE_NODE_MISSING_FILE:
                    parameter = string.Format("-cmfn {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.SPLIT_NAME_OPTION:
                    parameter = string.Format("-spName {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.READ_BREP:
                    parameter = string.Format("-brep {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.READ_DGMC:
                    parameter = string.Format("-dgmc {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case BomXmlParameters.READ_DGFC:
                    parameter = string.Format("-dgfc {0}", GetBoolean(value) == true ? "t" : "f");
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
        public bool Add(BomXmlParameters key, object value)
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
        public bool Exist(BomXmlParameters key)
        {
            return Parameter.ContainsKey(key);
        }

        /// <summary>
        /// Get Parameter Value
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Result</returns>
        public object GetValue(BomXmlParameters key)
        {
            if (Exist(key) == true) return Parameter[key];
            else return null;
        }

        /// <summary>
        /// Set Parameter Value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void SetValue(BomXmlParameters key, object value)
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

            foreach (KeyValuePair<BomXmlParameters, object> item in Parameter)
            {
                parameter += string.Format(" {0}", GetParameter(item.Key, item.Value));
            }

            return parameter;
        }
    }
}
