﻿using System;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\CreationZipFileKrasimira", @"C:\Users\Павел\Downloads\ResultZipFileKrasimira\myZipFile.zip");
        }
    }
}
