using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampSharp.GameMode;

namespace Racing_System.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 GetVector3(float[] coords)
        {
            if (coords.Length != 3) throw new Exception("El vector debe de tener 3 dimensiones");
            return new Vector3(coords[0], coords[1], coords[2]);
        }

        public static void SetVector3(this ref Vector3 vector, float[] coords)
        {
            if (coords.Length != 3) throw new Exception("El vector debe de tener 3 dimensiones");
            vector = new Vector3(coords[0], coords[1], coords[2]);
        }

        public static List<Vector3> GetCoordinatesFromFile(string path)
        {
            if(!File.Exists(path)) return new List<Vector3>();
            List<Vector3> list = new();
            using StreamReader sr = new(path);
            string line;
            while((line = sr.ReadLine()) != null)
            {
                list.Add(GetVector3(GetVectorFloat(line)));
            }
            return list;
        }

        private static float[] GetVectorFloat(string vector)
        {
            string[] newVector = vector.Split(", ");

            float[] result = new float[newVector.Length];
            int i = 0;
            foreach(var f in newVector)
            {
                result[i++] = float.Parse(f);
            }
            return result;
        }
    }
}
