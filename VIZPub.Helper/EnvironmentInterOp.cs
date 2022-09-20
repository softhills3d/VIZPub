using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// InterOp Environment Helper Class
    /// </summary>
    public class EnvironmentInterOp
    {
        /// <summary>
        /// Set Path
        /// </summary>
        /// <param name="path">Path : VIZPub Mechanical InterOp EXE Path</param>
        public static void SetPath(string path)
        {   
            SetPath(path, Environment.Is64BitProcess);
        }

        /// <summary>
        /// Set Path
        /// </summary>
        /// <param name="path">Path : VIZPub Mechanical InterOp EXE Path</param>
        /// <param name="x64">64Bit Process</param>
        public static void SetPath(string path, bool x64)
        {
            string ARCH = String.Empty;
            string X3DT = path;

            if (x64 == true)
                ARCH = "NT_VC14_64_DLL";
            else
                ARCH = "NT_VC14_DLL";

            string currentPath = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Process);
            string[] paths = currentPath.Split(';');

            if (paths.Contains(ARCH) == true) return;

            Environment.SetEnvironmentVariable("X3DT", X3DT);
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + @X3DT + "\\" + @ARCH + @"\code\bin;");
        }
    }
}
