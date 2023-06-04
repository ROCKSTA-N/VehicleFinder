using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFinder.Services
{
   public static class DatFIleReader
    {
        public static byte[] ReadFileContent(string path) =>
          File.ReadAllBytes(path);
    }
}