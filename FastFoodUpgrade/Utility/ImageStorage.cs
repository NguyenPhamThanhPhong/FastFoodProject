﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Utility
{
    public class ImageStorage
    {
        public static string CurrentSolutionLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        public static string StaffImageLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,"IMAGE_STAFF");
        public static string ProductImageLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "IMAGE_PRODUCT");
        public static string IngredientImageLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "IMAGE_INGREDIENT");

        public static void StoreImage(string SourcePath,string DesPath,string FileName)
        {
            if (File.Exists(SourcePath)&&!String.IsNullOrEmpty(FileName)) 
            { 
                File.Copy(SourcePath, Path.Combine(DesPath,FileName), true);
            }
        }
        public static void DeleteImage(string filepath,string filename)
        {
            if (!String.IsNullOrEmpty(filepath)&&!String.IsNullOrEmpty(filename))
            {
                string fullpath = Path.Combine(filepath, filename);
                if (File.Exists(fullpath))
                {
                    File.Delete(fullpath);
                }
            }
        }
        public static string GetImage(string path,string filename)
        {
            return Path.Combine(path, filename);
        }
    }
}
