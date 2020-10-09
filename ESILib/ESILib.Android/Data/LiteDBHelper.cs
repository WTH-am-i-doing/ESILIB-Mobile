using ESILib.Data;
using System;
using System.IO;
using Xamarin.Forms;

namespace ESILib.Droid.Data
{
    class LiteDBHelper : ILiteDBHelper
    {
        public string GetFilePath(string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, file);
        }
    }
}