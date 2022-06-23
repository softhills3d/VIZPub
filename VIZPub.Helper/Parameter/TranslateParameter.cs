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

        internal string GetReferenceFilePath(object value)
        {
            List<string> items = (List<string>)value;

            return string.Join(";", items.ToArray());
        }

        internal string GetParameter(TranslateParameters key, object value)
        {
            string parameter = String.Empty;

            switch (key)
            {
                case TranslateParameters.MODE:
                    parameter = string.Format("-mode {0}", value);
                    break;
                case TranslateParameters.INPUT:
                    parameter = string.Format("-i \"{0}\"", value);
                    break;
                case TranslateParameters.OUTPUT:
                    parameter = string.Format("-o \"{0}\"", value);
                    break;
                case TranslateParameters.MASS_PROPERTY:
                    parameter = string.Format("-mprop {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.TESSELLATION_QUALITY:
                    parameter = string.Format("-tq {0}", (int)((TesselationQuality)value));
                    break;
                case TranslateParameters.PSKERNEL:
                    parameter = string.Format("-ps {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.HEALING:
                    parameter = string.Format("-heal {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.FREE_POINT:
                    parameter = string.Format("-freep {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.FREE_SURFACE:
                    parameter = string.Format("-frees {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.FREE_CURVE:
                    parameter = string.Format("-freec {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.HIDDEN_ENTITY:
                    parameter = string.Format("-hidden {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.SUPRESSED_ENTITY:
                    parameter = string.Format("-supressed {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.LOG:
                    parameter = string.Format("-log {0}", (int)((TranslateLog)value));
                    break;
                case TranslateParameters.VIZ_VERSION:
                    parameter = string.Format("-ver {0}", (int)((VIZVersion)value));
                    break;
                case TranslateParameters.WITH_PMI:
                    parameter = string.Format("-pmi {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.REFERENCE_NAME:
                    parameter = string.Format("-refName {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.OUTPUT_THUMBNAIL:
                    parameter = string.Format("-thumbnail {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.OUTPUT_VIZM:
                    parameter = string.Format("-vizm {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.ASSEMBLY_ONLY:
                    parameter = string.Format("-assemblycon {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.BODY_TO_PART:
                    parameter = string.Format("-BodyToPart {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.VISIBLE_LAYER_ONLY:
                    parameter = string.Format("-vlayer {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.NURBS:
                    parameter = string.Format("-nurbs {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.OUTPUT_VIZW_PATH:
                    parameter = string.Format("-ovizw {0}", value);
                    break;
                case TranslateParameters.OUTPUT_THUMBNAIL_PATH:
                    parameter = string.Format("-othumb {0}", value);
                    break;
                case TranslateParameters.EXPORT_FULL_STRUCTURE:
                    parameter = string.Format("-fs {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.EXPORT_PART_ATTRIBUTE:
                    parameter = string.Format("-att {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.EXPORT_CAD_INFORMATION:
                    parameter = string.Format("-info {0}", GetBoolean(value) == true ? "t" : "f");
                    break;
                case TranslateParameters.REFERENCE_FILE_PATH:
                    parameter = string.Format("-reffp {0}", GetReferenceFilePath(value));
                    break;
                case TranslateParameters.THUMBNAIL_IMAGE_WIDTH:
                    parameter = string.Format("-iw {0}", GetInteger(value));
                    break;
                case TranslateParameters.THUMBNAIL_IMAGE_HEIGHT:
                    parameter = string.Format("-ih {0}", GetInteger(value));
                    break;
                case TranslateParameters.THUMBNAIL_TARGET:
                    parameter = string.Format("-subimg {0}", (int)((ThumbnailImageTarget)value));
                    break;
                case TranslateParameters.CAD2CAD:
                    parameter = string.Format("-c2c {0}", value);
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
