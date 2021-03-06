﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace StickyFingers
{
    public class Variables
    {
        public static string xfbin1Path;
        public static string xfbin2Path;
        public static string nudPath;
        public static string meshFormat;
        public static string dragFilePath;
        public static bool xfbin1Open;
        public static bool xfbin2Open;
        public static bool nudOpen;
        public static bool noesisStarted = false;
        public static bool allGroupBytes = false; // Future option for alternative end bytes fixing
        public static List<byte> file1Bytes;
        public static List<byte> file2Bytes;
        public static List<Group> xfbin1Groups;
        public static List<Group> xfbin2Groups;
        public static List<int> searchResults;
        public static List<NUD> meshList1;
        public static List<NUD> meshList2;
        public static NUD externalMesh;
        public static int meshCount1;
        public static int meshCount2;
        public static int nameSizeOffset;
        public static Process Noesis;
        public static List<int> BoneIDs = new List<int>();
        public static List<string> BoneNames = new List<string>();
        public static string modelName;

        public static string ProgramVersion
        {
            get { return "1.0"; }
        }

        public static string appData = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "StickyFingers"
            );
    }

    public class NUD
    {
        public string MeshName { get; set; }
        public string MeshFormat { get; set; }
        public int NudIndex { get; set; }
        public int FileStart { get; set; }
        public int HeaderSize { get; set; }
        public int FileSize { get; set; }
        public int NDP3Size { get; set; }
        public int MeshIndex { get; set; }
        public int TriIndex { get; set; }
        public int TriSize { get; set; }
        public int UVIndex { get; set; }
        public int UVSize { get; set; }
        public int VertIndex { get; set; }
        public int VertSize { get; set; }
        public int VertFormat { get; set; }
        public int GroupCount { get; set; }
        public string Material { get; set; }
        public bool Mirror { get; set; }
        public List<byte> TriFile { get; set; }
        public List<byte> UVFile { get; set; }
        public List<byte> VertFile { get; set; }
        public List<byte> NudFile { get; set; }
        public List<Group> GroupBytes { get; set; }
        public List<BoneBytes> Bones { get; set; }
        public List<Polygon> Polygons { get; set; }
        public int MaxBone { get; set; }
    }

    public class BoneBytes
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }
        public int Id3 { get; set; }
    }

    public class Polygon
    {
        public int VertCount { get; set; }
        public int FormatByte { get; set; }
        public int MeshFormat { get; set; }
        public int BoneOffset { get; set; }
        public string MatName { get; set; }
        public byte EndByte { get; set; }
    }

    public class Group
    {
        public string Name { get; set; }
        public byte EndByte { get; set; }
    }
}