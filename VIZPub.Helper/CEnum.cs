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

    /// <summary>
    /// Publish Parameters
    /// </summary>
    public enum PublishParameters
    {
        /// <summary>
        /// MODE
        /// </summary>
        MODE = 0,
        /// <summary>
        /// INPUT FILE
        /// </summary>
        INPUT = 1,
        /// <summary>
        /// OUTPUT FILE
        /// </summary>
        OUTPUT = 2,
        /// <summary>
        /// OUTPUT VIZM FILE
        /// </summary>
        OUTPUT_VIZM = 3,
        /// <summary>
        /// OUTPUT VIZW FILE
        /// </summary>
        OUTPUT_VIZW = 4,

        /// <summary>
        /// VIZ FILE VERSION
        /// </summary>
        VERSION = 10,
        /// <summary>
        /// EXPORT MERGED NODE
        /// </summary>
        EXPORT_MERGE_NODE = 11,

        /// <summary>
        /// MERGE RULE FILE
        /// </summary>
        MERGE_RULE_FILE = 20,
        /// <summary>
        /// ATTRIBUTE FILE
        /// </summary>
        ATTRIBUTE_FILE = 21,


        /// <summary>
        /// GENERATE EDGE DATA
        /// </summary>
        GENERATE_EDGE = 30,

        /// <summary>
        /// GENERATE THUMBNAIL
        /// </summary>
        GENERATE_THUMBNAIL = 31,
        /// <summary>
        /// CYLINDER SIDE COUNT (12 ~ 36)
        /// </summary>
        CYLINDER_SIDE_COUNT_NORMAL = 32,
        /// <summary>
        /// CYLINDER SIDE COUNT (6~36)
        /// </summary>
        CYLINDER_SIDE_COUNT_SMALL = 33,
        /// <summary>
        /// REMOVE NODENAME SLASH
        /// </summary>
        REMOVE_NODENAME_SLASH = 34,
        /// <summary>
        /// DGN QUALITY
        /// </summary>
        DGN_QUALITY = 35,

        /// <summary>
        /// THUMBNAIL WIDTH
        /// </summary>
        THUMBNAIL_WIDTH = 50,
        /// <summary>
        /// THUMBNAIL HEIGHT
        /// </summary>
        THUMBNAIL_HEIGHT = 51,
        /// <summary>
        /// THUMBNAIL VIEW DIRECTION
        /// </summary>
        THUMBNAIL_VIEW_DIRECTION = 52,
        /// <summary>
        /// THUMBNAIL IMAGE FORMAT
        /// </summary>
        THUMBNAIL_IMAGE_FORMAT = 53,
        /// <summary>
        /// THUMBNAIL IMAGE FILE NAME
        /// </summary>
        THUMBNAIL_IMAGE_NAME = 54,
        /// <summary>
        /// THUMBNAIL IMAGE NODE UNIT
        /// </summary>
        THUMBNAIL_IMAGE_NODE_UNIT = 55,
        /// <summary>
        /// THUMBNAIL IMAGE MATRIX
        /// </summary>
        THUMBNAIL_IMAGE_MATRIX = 56,

        /// <summary>
        /// COLOR - ALPHA
        /// </summary>
        COLOR_A = 60,
        /// <summary>
        /// COLOR - RED
        /// </summary>
        COLOR_R = 61,
        /// <summary>
        /// COLOR - GREEN
        /// </summary>
        COLOR_G = 62,
        /// <summary>
        /// COLOR - BLUE
        /// </summary>
        COLOR_B = 63,

        /// <summary>
        /// BOUNDING BOX INSPECTION
        /// </summary>
        BOUNDBOX_INSPECTIOIN = 70,
        /// <summary>
        /// BOUNDING BOX - MIN. X
        /// </summary>
        BOUNDBOX_MIN_X = 71,
        /// <summary>
        /// BOUNDING BOX MIN. Y
        /// </summary>
        BOUNDBOX_MIN_Y = 72,
        /// <summary>
        /// BOUNDING BOX MIN. Z
        /// </summary>
        BOUNDBOX_MIN_Z = 73,
        /// <summary>
        /// BOUNDING BOX MAX. X
        /// </summary>
        BOUNDBOX_MAX_X = 74,
        /// <summary>
        /// BOUNDING BOX MAX. Y
        /// </summary>
        BOUNDBOX_MAX_Y = 75,
        /// <summary>
        /// BOUNDING BOX MAX. Z
        /// </summary>
        BOUNDBOX_MAX_Z = 76,

        /// <summary>
        /// LIMIT TRIANGLE
        /// </summary>
        LIMIT_TRIANGLE = 77,
        /// <summary>
        /// LIMIT TRIANGLE COUNT
        /// </summary>
        LIMIT_TRIANGEL_COUNT = 78,

        /// <summary>
        /// DEBUG
        /// </summary>
        DEBUG = 90,
        /// <summary>
        /// LOG
        /// </summary>
        LOG = 99
    }

    /// <summary>
    /// Log Kind
    /// </summary>
    public enum LogKind
    {
        /// <summary>
        /// NONE
        /// </summary>
        NONE = 0,
        /// <summary>
        /// BASIC
        /// </summary>
        BASIC = 1,
        /// <summary>
        /// DETAIL
        /// </summary>
        DETAIL = 2,
        /// <summary>
        /// INFORMATION
        /// </summary>
        INFORMATION = 3
    }

    /// <summary>
    /// VIZ WRITE OPTIONS
    /// </summary>
    public enum WriteOptions
    {
        /// <summary>
        /// AS IS
        /// </summary>
        AS_IS = 0,
        /// <summary>
        /// LEAF ASSEMBLY TO PART
        /// </summary>
        LEAF_ASSEMBLY_TO_PART = 1,
        /// <summary>
        /// ALL TO PART
        /// </summary>
        ALL_PART = 2
    }

    internal enum LocalPaths
    {
        Input = 0,
        Intermediate = 1,
        Output = 2
    }
}
