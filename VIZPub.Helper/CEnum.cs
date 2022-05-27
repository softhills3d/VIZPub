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
        /// SOFTHILLS VIZ FILE FORMAT
        /// </summary>
        VIZ = 0
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
}
