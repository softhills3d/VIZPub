﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    public class PublishParameter
    {
        // ================================================
        // Attribute & Property
        // ================================================
        internal Dictionary<PublishParameters, object> Parameter { get; set; }


        // ================================================
        // Construction
        // ================================================
        public PublishParameter()
        {
            Parameter = new Dictionary<PublishParameters, object>();
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

        internal string GetParameter(PublishParameters key, object value)
        {
            string parameter = String.Empty;

            switch (key)
            {
                case PublishParameters.MODE:
                    parameter = string.Format("-mode {0}", GetInteger(value));
                    break;
                case PublishParameters.INPUT:
                    parameter = string.Format("-i \"{0}\"", value);
                    break;
                case PublishParameters.OUTPUT:
                    parameter = string.Format("-o \"{0}\"", value);
                    break;
                case PublishParameters.OUTPUT_VIZM:
                    parameter = string.Format("-om \"{0}\"", value);
                    break;
                case PublishParameters.OUTPUT_VIZW:
                    parameter = string.Format("-ow \"{0}\"", value);
                    break;
                case PublishParameters.VERSION:
                    parameter = string.Format("-ver {0}", value);
                    break;
                case PublishParameters.EXPORT_MERGE_NODE:
                    break;
                case PublishParameters.MERGE_RULE_FILE:
                    parameter = string.Format("-rfm \"{0}\"", value);
                    break;
                case PublishParameters.ATTRIBUTE_FILE:
                    parameter = string.Format("-a \"{0}\"", value);
                    break;
                case PublishParameters.GENERATE_EDGE:
                    parameter = string.Format("-e {0}", GetBoolean(value) == true ? 1 : 0);
                    break;
                case PublishParameters.GENERATE_THUMBNAIL:
                    parameter = string.Format("-t {0}", GetBoolean(value) == true ? 1 : 0);
                    break;
                case PublishParameters.NORMAL_CYLINDER_COUNT:
                    parameter = string.Format("-csn {0}", GetInteger(value));
                    break;
                case PublishParameters.SMALL_CYLINDER_COUNT:
                    parameter = string.Format("-css {0}", GetInteger(value));
                    break;
                case PublishParameters.REMOVE_NODENAME_SLASH:
                    parameter = string.Format("-rs {0}", GetBoolean(value) == true ? 1 : 0);
                    break;
                case PublishParameters.DGN_QUALITY:
                    parameter = string.Format("-dq {0}", value);
                    break;
                case PublishParameters.THUMBNAIL_WIDTH:
                    parameter = string.Format("-w {0}", GetInteger(value));
                    break;
                case PublishParameters.THUMBNAIL_HEIGHT:
                    parameter = string.Format("-h {0}", GetInteger(value));
                    break;
                case PublishParameters.THUMBNAIL_VIEW_DIRECTION:
                    parameter = string.Format("-vd {0}", value);
                    break;
                case PublishParameters.THUMBNAIL_IMAGE_FORMAT:
                    parameter = string.Format("-if {0}", value);
                    break;
                case PublishParameters.THUMBNAIL_IMAGE_NAME:
                    parameter = string.Format("-nt {0}", value);
                    break;
                case PublishParameters.THUMBNAIL_IMAGE_NODE_UNIT:
                    parameter = string.Format("-nu {0}", value);
                    break;
                case PublishParameters.THUMBNAIL_IMAGE_MATRIX:
                    parameter = string.Format("-matrix {0}", value);
                    break;
                case PublishParameters.COLOR_A:
                    parameter = string.Format("-ca {0}", value);
                    break;
                case PublishParameters.COLOR_R:
                    parameter = string.Format("-cr {0}", value);
                    break;
                case PublishParameters.COLOR_G:
                    parameter = string.Format("-cg {0}", value);
                    break;
                case PublishParameters.COLOR_B:
                    parameter = string.Format("-cb {0}", value);
                    break;
                case PublishParameters.BOUNDBOX_INSPECTIOIN:
                    parameter = string.Format("-eb {0}", GetBoolean(value) == true ? 1 : 0);
                    break;
                case PublishParameters.BOUNDBOX_MIN_X:
                    parameter = string.Format("-minx {0}", value);
                    break;
                case PublishParameters.BOUNDBOX_MIN_Y:
                    parameter = string.Format("-miny {0}", value);
                    break;
                case PublishParameters.BOUNDBOX_MIN_Z:
                    parameter = string.Format("-minz {0}", value);
                    break;
                case PublishParameters.BOUNDBOX_MAX_X:
                    parameter = string.Format("-maxx {0}", value);
                    break;
                case PublishParameters.BOUNDBOX_MAX_Y:
                    parameter = string.Format("-maxy {0}", value);
                    break;
                case PublishParameters.BOUNDBOX_MAX_Z:
                    parameter = string.Format("-maxz {0}", value);
                    break;
                case PublishParameters.LIMIT_TRIANGLE:
                    parameter = string.Format("-lt {0}", GetBoolean(value) == true ? 1 : 0);
                    break;
                case PublishParameters.LIMIT_TRIANGEL_COUNT:
                    parameter = string.Format("-tc {0}", value);
                    break;
                case PublishParameters.DEBUG:
                    parameter = string.Format("-debug {0}", GetBoolean(value) == true ? 1 : 0);
                    break;
                case PublishParameters.LOG:
                    parameter = string.Format("-log {0}", value);
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
        public bool Add(PublishParameters key, object value)
        {
            if (Parameter.ContainsKey(key) == true) return false;

            Parameter.Add(key, value);
            return true;
        }

        public bool Exist(PublishParameters key)
        {
            return Parameter.ContainsKey(key);
        }

        public override string ToString()
        {
            string parameter = String.Empty;

            foreach (KeyValuePair<PublishParameters, object> item in Parameter)
            {
                parameter += string.Format(" {0}", GetParameter(item.Key, item.Value));
            }

            return parameter;
        }
    }
}