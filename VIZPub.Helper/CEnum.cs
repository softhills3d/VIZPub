using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Input File Format
    /// </summary>
    public enum InputFileFormat
    {
        /// <summary>
        /// PDMS (TRIBON, AVEVA) Review File (ASCII)
        /// </summary>
        REV = 0,

        /// <summary>
        /// PDMS (TRIBON, AVEVA) Review File (BINARY)
        /// </summary>
        RVM = 1
    }

    /// <summary>
    /// Output File Format
    /// </summary>
    public enum OutputFileFormat
    {
        /// <summary>
        /// SOFTHILLS VIZ FILE FORMAT. Desktop
        /// </summary>
        VIZ = 0,

        /// <summary>
        /// SOFTHILLS VIZM FILE FORMAT. Mobile (Android)
        /// </summary>
        VIZM = 1,

        /// <summary>
        /// SOFTHILLS VIZW FILE FORMAT. Web
        /// </summary>
        VIZW = 2
    }

    /// <summary>
    /// VIZ FILE VERSION
    /// </summary>
    public enum FileVersion
    {
        /// <summary>
        /// VIZ FILE VERSION 303
        /// </summary>
        V303 = 303,

        /// <summary>
        /// VIZ FILE VERSION 304
        /// </summary>
        V304 = 304
    }

    public enum PublishParameters
    {
        MODE = 0,
        INPUT = 1,
        OUTPUT = 2,
        OUTPUT_VIZM = 3,
        OUTPUT_VIZW = 4,

        VERSION = 10,
        EXPORT_MERGE_NODE = 11,

        MERGE_RULE_FILE = 20,
        ATTRIBUTE_FILE = 21,


        GENERATE_EDGE = 30,
        GENERATE_THUMBNAIL = 31,
        NORMAL_CYLINDER_COUNT = 32,
        SMALL_CYLINDER_COUNT = 33,
        REMOVE_NODENAME_SLASH = 34,
        DGN_QUALITY = 35,

        THUMBNAIL_WIDTH = 50,
        THUMBNAIL_HEIGHT = 51,
        THUMBNAIL_VIEW_DIRECTION = 52,
        THUMBNAIL_IMAGE_FORMAT = 53,
        THUMBNAIL_IMAGE_NAME = 54,
        THUMBNAIL_IMAGE_NODE_UNIT = 55,
        THUMBNAIL_IMAGE_MATRIX = 56,

        COLOR_A = 60,
        COLOR_R = 61,
        COLOR_G = 62,
        COLOR_B = 63,

        BOUNDBOX_INSPECTIOIN = 70,
        BOUNDBOX_MIN_X = 71,
        BOUNDBOX_MIN_Y = 72,
        BOUNDBOX_MIN_Z = 73,
        BOUNDBOX_MAX_X = 74,
        BOUNDBOX_MAX_Y = 75,
        BOUNDBOX_MAX_Z = 76,

        LIMIT_TRIANGLE = 77,
        LIMIT_TRIANGEL_COUNT = 78,


        DEBUG = 90,
        LOG = 99
    }

    public enum WorkingLocation
    {
        ORIGINAL_PATH = 0,
        LOCAL_PATH = 1
    }

    public enum LogKind
    {
        Disable = 0,
        Basic = 1,
        Detail = 2,
        Information = 3
    }

    public enum WriteOptions
    {
        AsIs = 0,
        LeafAssemblyToPart = 1,
        AllToPart = 2
    }
}
