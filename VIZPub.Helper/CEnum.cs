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
        /// SOFTHILLS VIZM FILE FORMAT. Mobile (Android) / VIZWing
        /// </summary>
        VIZM = 1,

        /// <summary>
        /// SOFTHILLS VIZW FILE FORMAT. Web (HTML5) / VIZWeb3D / VIZWide3D
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
    /// View Direction
    /// </summary>
    public enum ViewDirection
    {
        /// <summary>
        /// ISO +
        /// </summary>
        ISO_PLUS = 0,

        /// <summary>
        /// ISO -
        /// </summary>
        ISO_MINUS = 1,

        /// <summary>
        /// FRONT
        /// </summary>
        FRONT = 2,

        /// <summary>
        /// BACK
        /// </summary>
        BACK = 3,

        /// <summary>
        /// LEFT
        /// </summary>
        LEFT = 4,

        /// <summary>
        /// RIGHT
        /// </summary>
        RIGHT = 5,

        /// <summary>
        /// TOP
        /// </summary>
        TOP = 6,

        /// <summary>
        /// BOTTOM
        /// </summary>
        BOTTOM = 7
    }

    /// <summary>
    /// Image Format
    /// </summary>
    public enum ImageFormat
    {
        /// <summary>
        /// JPG
        /// </summary>
        JPG = 0,

        /// <summary>
        /// PNG
        /// </summary>
        PNG = 1
    }

    /// <summary>
    /// EXPORT NAME KIND
    /// </summary>
    public enum NameKind
    {
        /// <summary>
        /// 노드이름
        /// </summary>
        NODE_NAME = 0,

        /// <summary>
        /// 노드아이디
        /// </summary>
        NODE_ID = 1,

        /// <summary>
        /// 노드아이디 + "." + 노드이름
        /// </summary>
        NODE_ID_AND_NODE_NAME = 2,

        /// <summary>
        /// 미지정
        /// </summary>
        NONE = 3
    }

    /// <summary>
    /// Node Unit
    /// </summary>
    public enum NodeUnit
    {
        /// <summary>
        /// 전체 모델
        /// </summary>
        ALL_MODEL = 0,

        /// <summary>
        /// 노드 단위
        /// </summary>
        NODE_UNIT = 1
    }

    /// <summary>
    /// TARGET NODE KIND
    /// </summary>
    public enum TargetNodeKind
    {
        /// <summary>
        /// 전체 노드 : ASSEMBLY, PART
        /// </summary>
        ALL = 0,

        /// <summary>
        /// 파트 노드 : ONLY PART
        /// </summary>
        PART = 1
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
        INPUT,
        /// <summary>
        /// OUTPUT FILE
        /// </summary>
        OUTPUT,
        /// <summary>
        /// OUTPUT VIZM FILE
        /// </summary>
        OUTPUT_VIZM,
        /// <summary>
        /// OUTPUT VIZW FILE
        /// </summary>
        OUTPUT_VIZW,

        /// <summary>
        /// VIZ FILE VERSION
        /// </summary>
        VERSION,
        /// <summary>
        /// EXPORT MERGED NODE
        /// </summary>
        EXPORT_MERGE_NODE,

        /// <summary>
        /// MERGE RULE FILE
        /// </summary>
        MERGE_RULE_FILE,
        /// <summary>
        /// ATTRIBUTE FILE
        /// </summary>
        ATTRIBUTE_FILE,


        /// <summary>
        /// GENERATE EDGE DATA
        /// </summary>
        GENERATE_EDGE,

        /// <summary>
        /// GENERATE THUMBNAIL
        /// </summary>
        GENERATE_THUMBNAIL,
        /// <summary>
        /// CYLINDER SIDE COUNT (12 ~ 36)
        /// </summary>
        CYLINDER_SIDE_COUNT_NORMAL,
        /// <summary>
        /// CYLINDER SIDE COUNT (6~36)
        /// </summary>
        CYLINDER_SIDE_COUNT_SMALL,
        /// <summary>
        /// REMOVE NODENAME SLASH
        /// </summary>
        REMOVE_NODENAME_SLASH,
        /// <summary>
        /// DGN QUALITY
        /// </summary>
        DGN_QUALITY,

        /// <summary>
        /// NODE MERGE OPTIONS (NOT SIMPLIFY)
        /// </summary>
        NODE_MERGE_OPTIONS,

        /// <summary>
        /// THUMBNAIL WIDTH
        /// </summary>
        THUMBNAIL_WIDTH,
        /// <summary>
        /// THUMBNAIL HEIGHT
        /// </summary>
        THUMBNAIL_HEIGHT,
        /// <summary>
        /// THUMBNAIL VIEW DIRECTION
        /// </summary>
        THUMBNAIL_VIEW_DIRECTION,
        /// <summary>
        /// THUMBNAIL IMAGE FORMAT
        /// </summary>
        THUMBNAIL_IMAGE_FORMAT,
        /// <summary>
        /// THUMBNAIL IMAGE FILE NAME
        /// </summary>
        THUMBNAIL_IMAGE_NAME,
        /// <summary>
        /// THUMBNAIL IMAGE NODE UNIT
        /// </summary>
        THUMBNAIL_IMAGE_NODE_UNIT,
        /// <summary>
        /// THUMBNAIL IMAGE MATRIX
        /// </summary>
        THUMBNAIL_IMAGE_MATRIX,

        /// <summary>
        /// COLOR - ALPHA
        /// </summary>
        COLOR_A,
        /// <summary>
        /// COLOR - RED
        /// </summary>
        COLOR_R,
        /// <summary>
        /// COLOR - GREEN
        /// </summary>
        COLOR_G,
        /// <summary>
        /// COLOR - BLUE
        /// </summary>
        COLOR_B,

        /// <summary>
        /// BOUNDING BOX INSPECTION
        /// </summary>
        BOUNDBOX_INSPECTIOIN,
        /// <summary>
        /// BOUNDING BOX - MIN. X
        /// </summary>
        BOUNDBOX_MIN_X,
        /// <summary>
        /// BOUNDING BOX MIN. Y
        /// </summary>
        BOUNDBOX_MIN_Y,
        /// <summary>
        /// BOUNDING BOX MIN. Z
        /// </summary>
        BOUNDBOX_MIN_Z,
        /// <summary>
        /// BOUNDING BOX MAX. X
        /// </summary>
        BOUNDBOX_MAX_X,
        /// <summary>
        /// BOUNDING BOX MAX. Y
        /// </summary>
        BOUNDBOX_MAX_Y,
        /// <summary>
        /// BOUNDING BOX MAX. Z
        /// </summary>
        BOUNDBOX_MAX_Z,

        /// <summary>
        /// LIMIT TRIANGLE
        /// </summary>
        LIMIT_TRIANGLE,
        /// <summary>
        /// LIMIT TRIANGLE COUNT
        /// </summary>
        LIMIT_TRIANGEL_COUNT,

        /// <summary>
        /// OUTPUT FILE FORMAT
        /// </summary>
        OUTPUT_FILE_FORMAT,
        /// <summary>
        /// OUTPUT FILE NAME KIND
        /// </summary>
        OUTPUT_NAME_KIND,
        /// <summary>
        /// OUTPUT TARGET NODE
        /// </summary>
        OUTPUT_TARGET_NODE,

        /// <summary>
        /// DEBUG
        /// </summary>
        DEBUG,
        /// <summary>
        /// LOG
        /// </summary>
        LOG
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
    /// Node Merge Options (Not Simplify)
    /// </summary>
    public enum NodeMergeOptions
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
