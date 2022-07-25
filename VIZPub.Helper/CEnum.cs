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
        /// SOFTHILLS VIZW FILE FORMAT. Web (HTML5) / VIZWeb3D
        /// </summary>
        VIZW = 2,

        /// <summary>
        /// SOFTHILLS VIZW FILE FORMAT. Web (HTML5) / VIZWide3D
        /// </summary>
        VIZW_LOD = 3
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
        /// COLOR
        /// </summary>
        COLOR,

        /// <summary>
        /// COLOR XML
        /// </summary>
        COLOR_XML,

        /// <summary>
        /// BOUND BOX XML
        /// </summary>
        BOUNDBOX_XML,

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
        /// KEEP STRUCTURE
        /// </summary>
        KEEP_STRUCTURE,

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
        /// FBX FILE ASCII
        /// </summary>
        FBX_FILE_ASCII,

        /// <summary>
        /// USING FBX SDK
        /// </summary>
        FBX_SDK,

        /// <summary>
        /// LOAD HIDDEN ENTITY
        /// </summary>
        LOAD_HIDDEN_ENTITY,

        /// <summary>
        /// INCLUDE BODY ATTRIBUTE
        /// </summary>
        INCLUDE_BODY_ATTRIBUTE,

        /// <summary>
        /// BOUNDING BOX SEARCH OPTION
        /// </summary>
        BOUNDBOX_SEARCH_OPTION,

        /// <summary>
        /// ROTATE :: X
        /// </summary>
        ROTATE_X,
        /// <summary>
        /// ROTATE :: Y
        /// </summary>
        ROTATE_Y,
        /// <summary>
        /// ROTATE :: Z
        /// </summary>
        ROTATE_Z,

        /// <summary>
        /// COMPRESS VIZW (VIZWide3D)
        /// </summary>
        COMPRESS_VIZW,

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

    /// <summary>
    /// Translate Parameters
    /// </summary>
    public enum TranslateParameters
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
        /// OUTPUT VIZW FILE PATH
        /// </summary>
        OUTPUT_VIZW_PATH,

        /// <summary>
        /// MASS PROPERTY
        /// </summary>
        MASS_PROPERTY,

        /// <summary>
        /// TESSELLATION QUALITY
        /// </summary>
        TESSELLATION_QUALITY,

        /// <summary>
        /// PSKERNEL
        /// </summary>
        PSKERNEL,

        /// <summary>
        /// HEALING
        /// </summary>
        HEALING,

        /// <summary>
        ///  FREE_SURFACE
        /// </summary>
        FREE_SURFACE,

        /// <summary>
        /// FREE POINT
        /// </summary>
        FREE_POINT,

        /// <summary>
        /// FREE CURVE
        /// </summary>
        FREE_CURVE,

        /// <summary>
        /// HIDDEN ENTITY
        /// </summary>
        HIDDEN_ENTITY,

        /// <summary>
        /// SUPRESSED ENTITY
        /// </summary>
        SUPRESSED_ENTITY,

        /// <summary>
        /// LOG
        /// </summary>
        LOG,

        /// <summary>
        /// STEP VERSION
        /// </summary>
        STEP_VERSION,

        /// <summary>
        /// VIZ VERSION
        /// </summary>
        VIZ_VERSION,

        /// <summary>
        /// JT VERSION
        /// </summary>
        JT_VERSION,

        /// <summary>
        /// U3D VERSION
        /// </summary>
        U3D_VERSION,

        /// <summary>
        /// WRITE PMI
        /// </summary>
        WRITE_PMI,

        /// <summary>
        /// WITH PMI
        /// </summary>
        WITH_PMI,

        /// <summary>
        /// REFERENCE NAME
        /// </summary>
        REFERENCE_NAME,

        /// <summary>
        /// OUTPUT THUMBNAIL
        /// </summary>
        OUTPUT_THUMBNAIL,

        /// <summary>
        /// OUTPUT THUMBNAIL PATH
        /// </summary>
        OUTPUT_THUMBNAIL_PATH,

        /// <summary>
        /// EXPORT ASSEMBLY ONLY
        /// </summary>
        ASSEMBLY_ONLY,

        /// <summary>
        /// BODY TO PART
        /// </summary>
        BODY_TO_PART,

        /// <summary>
        /// VISIBLE LAYER ONLY
        /// </summary>
        VISIBLE_LAYER_ONLY,

        /// <summary>
        /// NURBS
        /// </summary>
        NURBS,

        /// <summary>
        /// FACET TO WIREFRAME
        /// </summary>
        FACET_TO_WIREFRAME,

        /// <summary>
        /// USE SHORT NAME
        /// </summary>
        USE_SHORT_NAME,

        /// <summary>
        /// WRITE TESSELATION
        /// </summary>
        WRITE_TESSELATION,

        /// <summary>
        /// ACTIVE OBJ
        /// </summary>
        ACTIVE_OBJ,

        /// <summary>
        /// SAVE AS BINARY
        /// </summary>
        SAVE_AS_BINARY,

        /// <summary>
        /// KEEP TESSELLATION
        /// </summary>
        KEEP_TESSELLATION,

        /// <summary>
        /// SAVE AS MILLIMETER
        /// </summary>
        SAVE_AS_MILLIMETER,

        /// <summary>
        /// MESH QUALITY
        /// </summary>
        MESH_QUALITY,

        /// <summary>
        /// ACCURATE TESSELLATION
        /// </summary>
        ACCURATE_TESSELLATION,

        /// <summary>
        /// HIDDEN OBJECT
        /// </summary>
        HIDDEN_OBJECT,

        /// <summary>
        /// SOLID AS FACE
        /// </summary>
        SOLID_AS_FACE,

        /// <summary>
        /// WRITING MODE
        /// </summary>
        WRITE_MODE,

        /// <summary>
        /// EXPORT FULL STRUCTURE
        /// </summary>
        EXPORT_FULL_STRUCTURE,

        /// <summary>
        /// EXPORT PART ATTRIBUTE
        /// </summary>
        EXPORT_PART_ATTRIBUTE,

        /// <summary>
        /// EXPORT CAD INFORMATION
        /// </summary>
        EXPORT_CAD_INFORMATION,

        /// <summary>
        /// REFERENCE CAD FILE PATH
        /// </summary>
        REFERENCE_FILE_PATH,

        /// <summary>
        /// THUMBNAIL IMAGE WIDTH
        /// </summary>
        THUMBNAIL_IMAGE_WIDTH,

        /// <summary>
        /// THUMBNAIL IMAGE HEIGHT
        /// </summary>
        THUMBNAIL_IMAGE_HEIGHT,

        /// <summary>
        /// RESOLUTION
        /// </summary>
        RESOLUTION,

        /// <summary>
        /// IMAGE QUALITY
        /// </summary>
        IMAGE_QUALITY,

        /// <summary>
        /// THUMBNAIL TARGET
        /// </summary>
        THUMBNAIL_TARGET,

        /// <summary>
        /// THUMBNAIL DEFAULT VIEW
        /// </summary>
        THUMBNAIL_DEFAULT_VIEW,

        /// <summary>
        /// VIZW SPLIT COUNT
        /// </summary>
        SPLIT_COUNT,

        /// <summary>
        /// USE MULTI PROCESS
        /// </summary>
        USE_MULTI_PROCESS,

        /// <summary>
        /// CREATE NODE MISSING FILE
        /// </summary>
        CREATE_NODE_MISSING_FILE,

        /// <summary>
        /// SPLIT NAME OPTION
        /// </summary>
        SPLIT_NAME_OPTION,

        /// <summary>
        /// READ BREP
        /// </summary>
        READ_BREP,

        /// <summary>
        /// READ DGMC
        /// </summary>
        READ_DGMC,

        /// <summary>
        /// READ DGFC
        /// </summary>
        READ_DGFC,

        /// <summary>
        /// CAD TO CAD
        /// </summary>
        CAD2CAD,

        /// <summary>
        /// SERVER IP
        /// </summary>
        SERVER_IP,

        /// <summary>
        /// SERVER PORT
        /// </summary>
        SERVER_PORT
    }

    

    /// <summary>
    /// Thumbnail Image Target
    /// </summary>
    public enum ThumbnailImageTarget
    {
        /// <summary>
        /// MODEL
        /// </summary>
        MODEL = 0,

        /// <summary>
        /// ALL ASSEMBLY, PART...
        /// </summary>
        ALL_NODE = 1
    }

    /// <summary>
    /// Tesselation Quality
    /// </summary>
    public enum TesselationQuality
    {
        /// <summary>
        /// Coarse
        /// </summary>
        Coarse = 0,
        /// <summary>
        /// Normal
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Better
        /// </summary>
        Better = 2,
        /// <summary>
        /// Best
        /// </summary>
        Best = 3
    }

    /// <summary>
    /// BoundBox Search Option
    /// </summary>
    public enum BoundBoxSearchOption
    {
        /// <summary>
        /// Full Contained
        /// </summary>
        FullyContained = 0,
        /// <summary>
        /// Including Part
        /// </summary>
        IncludingPart = 1
    }

    /// <summary>
    /// Translate Log
    /// </summary>
    public enum TranslateLog
    {
        /// <summary>
        /// NONE
        /// </summary>
        NONE = 0,

        /// <summary>
        /// OUTPUT IF ERROR OCCURS
        /// </summary>
        OUTPUT_IF_ERROR = 1,

        /// <summary>
        /// ALWAYS OUTPUT
        /// </summary>
        OUTPUT_ALWAYS = 2
    }

    /// <summary>
    /// Step Version
    /// </summary>
    public enum StepVersion
    {
        /// <summary>
        /// 203 VERSION
        /// </summary>
        V203 = 203,

        /// <summary>
        /// 214 VERSION
        /// </summary>
        V214 = 214,

        /// <summary>
        /// 242 VERSION
        /// </summary>
        V242 = 242
    }

    /// <summary>
    /// VIZXML Node Kind
    /// </summary>
    public enum VIZXMLNodeKind
    {
        /// <summary>
        /// Node
        /// </summary>
        Node = 0,

        /// <summary>
        /// External Link File
        /// </summary>
        LinkFile = 1,

        /// <summary>
        /// External Link Node
        /// </summary>
        LinkNode = 2,

        /// <summary>
        /// External Link Id
        /// </summary>
        LinkId = 3
    }

    /// <summary>
    /// VIZXML Node Object Type
    /// </summary>
    public enum VIZXMLNodeType
    {
        /// <summary>
        /// Assembly Node
        /// </summary>
        Assembly = 0,

        /// <summary>
        /// Part Node
        /// </summary>
        Part = 1,

        /// <summary>
        /// Body Node
        /// </summary>
        Body = 2
    }

    /// <summary>
    /// VIZ Version
    /// </summary>
    public enum VIZVersion
    {
        /// <summary>
        /// 202 VERSION
        /// </summary>
        V202 = 202,

        /// <summary>
        /// 203 VERSION
        /// </summary>
        V203 = 203,

        /// <summary>
        /// 204 VERSION
        /// </summary>
        V204 = 204,

        /// <summary>
        /// 205 VERSION
        /// </summary>
        V205 = 205,

        /// <summary>
        /// 206 VERSION
        /// </summary>
        V206 = 206,

        /// <summary>
        /// 207 VERSION
        /// </summary>
        V207 = 207,

        /// <summary>
        /// 208 VERSION
        /// </summary>
        V208 = 208,

        /// <summary>
        /// 301 VERSION
        /// </summary>
        V301 = 301,

        /// <summary>
        /// 302 VERSION
        /// </summary>
        V302 = 302,

        /// <summary>
        /// 303 VERSION
        /// </summary>
        V303 = 303,

        /// <summary>
        /// 304 VERSION
        /// </summary>
        V304 = 304
    }

    /// <summary>
    /// JT Version
    /// </summary>
    public enum JtVersion
    {
        /// <summary>
        /// JT-8.1 VERSION
        /// </summary>
        JT_801 = 0,

        /// <summary>
        /// JT-9.5 VERSION
        /// </summary>
        JT_905 = 1
    }

    /// <summary>
    /// U3D Version
    /// </summary>
    public enum U3DVersion
    {
        /// <summary>
        /// U3D-CMA1 VERSION
        /// </summary>
        U3D_CMA1 = 0,

        /// <summary>
        /// U3D-CMA3 VERSION
        /// </summary>
        U3D_CMA3 = 1
    }

    /// <summary>
    /// Tessellation Writing Mode
    /// </summary>
    public enum WritingMode
    {
        /// <summary>
        /// Geometry
        /// </summary>
        Geometry = 0,

        /// <summary>
        /// Geometry_Tessellation
        /// </summary>
        Geometry_Tessellation = 1,

        /// <summary>
        /// Tessellation
        /// </summary>
        Tessellation = 2
    }

    /// <summary>
    /// Bom Xml Generator Parameters
    /// </summary>
    public enum BomXmlParameters
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
        /// LOG
        /// </summary>
        LOG,

        /// <summary>
        /// SUPRESSED ENTITY
        /// </summary>
        SUPRESSED_ENTITY,

        /// <summary>
        /// REFERENCE NAME
        /// </summary>
        REFERENCE_NAME,

        /// <summary>
        /// EXPORT FULL STRUCTURE
        /// </summary>
        EXPORT_FULL_STRUCTURE,

        /// <summary>
        /// EXPORT PART ATTRIBUTE
        /// </summary>
        EXPORT_PART_ATTRIBUTE,

        /// <summary>
        /// EXPORT CAD INFORMATION
        /// </summary>
        EXPORT_CAD_INFORMATION,

        /// <summary>
        /// REFERENCE CAD FILE PATH
        /// </summary>
        REFERENCE_FILE_PATH,

        /// <summary>
        /// THUMBNAIL IMAGE WIDTH
        /// </summary>
        THUMBNAIL_IMAGE_WIDTH,

        /// <summary>
        /// THUMBNAIL IMAGE HEIGHT
        /// </summary>
        THUMBNAIL_IMAGE_HEIGHT,

        /// <summary>
        /// RESOLUTION
        /// </summary>
        RESOLUTION,

        /// <summary>
        /// IMAGE QUALITY
        /// </summary>
        IMAGE_QUALITY,

        /// <summary>
        /// THUMBNAIL TARGET
        /// </summary>
        THUMBNAIL_TARGET,

        /// <summary>
        /// USE MULTI PROCESS
        /// </summary>
        USE_MULTI_PROCESS,

        /// <summary>
        /// HIDDEN ENTITY
        /// </summary>
        HIDDEN_ENTITY,

        /// <summary>
        /// CREATE NODE MISSING FILE
        /// </summary>
        CREATE_NODE_MISSING_FILE,

        /// <summary>
        /// SPLIT NAME OPTION
        /// </summary>
        SPLIT_NAME_OPTION,

        /// <summary>
        /// READ BREP
        /// </summary>
        READ_BREP,

        /// <summary>
        /// READ DGMC
        /// </summary>
        READ_DGMC,

        /// <summary>
        /// READ DGFC
        /// </summary>
        READ_DGFC,


        /// <summary>
        /// SERVER IP
        /// </summary>
        SERVER_IP,

        /// <summary>
        /// SERVER PORT
        /// </summary>
        SERVER_PORT
    }

    /// <summary>
    /// CAD Type
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// BST
        /// </summary>
        BST = 0,

        /// <summary>
        /// Acis
        /// </summary>
        Acis = 1,

        /// <summary>
        /// CatiaV4
        /// </summary>
        CatiaV4 = 2,

        /// <summary>
        /// CatiaV5
        /// </summary>
        CatiaV5 = 3,

        /// <summary>
        /// IGES
        /// </summary>
        IGES = 4,

        /// <summary>
        /// Invertor
        /// </summary>
        Invertor = 5,

        /// <summary>
        /// JT
        /// </summary>
        JT = 6,

        /// <summary>
        /// Parasolid
        /// </summary>
        Parasolid = 7,

        /// <summary>
        /// ProE
        /// </summary>
        ProE = 8,

        /// <summary>
        /// SolidWorks
        /// </summary>
        SolidWorks = 9,

        /// <summary>
        /// STEP
        /// </summary>
        STEP = 10,

        /// <summary>
        /// UGorProE
        /// </summary>
        UGorProE = 11,

        /// <summary>
        /// VDA
        /// </summary>
        VDA = 12,

        /// <summary>
        /// UG
        /// </summary>
        UG = 13,

        /// <summary>
        /// DAV
        /// </summary>
        DAV = 14,

        /// <summary>
        /// REV
        /// </summary>
        REV = 15,

        /// <summary>
        /// RVM
        /// </summary>
        RVM = 16,

        /// <summary>
        /// DGN
        /// </summary>
        DGN = 17,

        /// <summary>
        /// SITF
        /// </summary>
        SITF = 18,

        /// <summary>
        /// SolidEdge
        /// </summary>
        SolidEdge = 19,

        /// <summary>
        /// ProEorSolidEdge
        /// </summary>
        ProEorSolidEdge = 20,

        /// <summary>
        /// STL
        /// </summary>
        STL = 21,

        /// <summary>
        /// _3DXML
        /// </summary>
        _3DXML = 22,

        /// <summary>
        /// CGR
        /// </summary>
        CGR = 23,

        /// <summary>
        /// XCGM
        /// </summary>
        XCGM = 24,

        /// <summary>
        /// IFC
        /// </summary>
        IFC = 25,

        /// <summary>
        /// RVT
        /// </summary>
        RVT = 26,

        /// <summary>
        /// FBX
        /// </summary>
        FBX = 27,

        /// <summary>
        /// DWG
        /// </summary>
        DWG = 28,

        /// <summary>
        /// DXF
        /// </summary>
        DXF = 29,

        /// <summary>
        /// Universal3D
        /// </summary>
        Universal3D = 30,

        /// <summary>
        /// VRML
        /// </summary>
        VRML = 31,

        /// <summary>
        /// IDEAS
        /// </summary>
        IDEAS = 32,

        /// <summary>
        /// PRC
        /// </summary>
        PRC = 33,

        /// <summary>
        /// RHINO3D
        /// </summary>
        RHINO3D = 34,

        /// <summary>
        /// OBJ
        /// </summary>
        OBJ = 35,

        /// <summary>
        /// GLTF
        /// </summary>
        GLTF = 36,

        /// <summary>
        /// AUTODESK3DS
        /// </summary>
        AUTODESK3DS = 37,

        /// <summary>
        /// COLLADA
        /// </summary>
        COLLADA = 38,

        /// <summary>
        /// AUTODESKDWF
        /// </summary>
        AUTODESKDWF = 39,

        /// <summary>
        /// STEPXML
        /// </summary>
        STEPXML = 40,

        /// <summary>
        /// HMF
        /// </summary>
        HMF = 41,

        /// <summary>
        /// NWD
        /// </summary>
        NWD = 42,

        /// <summary>
        /// _3DPDF
        /// </summary>
        _3DPDF = 43,

        /// <summary>
        /// _3MF
        /// </summary>
        _3MF = 44,

        /// <summary>
        /// _3DPDF
        /// </summary>
        XML = 100,

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = -1


    }
}
