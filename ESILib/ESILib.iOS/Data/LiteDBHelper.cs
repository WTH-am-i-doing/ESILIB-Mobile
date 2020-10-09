using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ESILib.Data;
using Foundation;
using UIKit;

namespace ESILib.iOS.Data
{
    public class LiteDBHelper : ILiteDBHelper
    {
        public string GetFilePath(string file)
        {
            string document = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string library = Path.Combine(document, "..", "Library", "Databases");

            if (!Directory.Exists(library))
            {
                Directory.CreateDirectory(library);
            }

            return Path.Combine(library, file);
        }
    }
}
}