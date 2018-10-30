using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace DEM
{
    class Terrain
    {
        // Does two things: 
        // Adds the cartesian coordinates of all valid height cells (heixels) (indicated by a value != -32768) to the positions collection.
        // Returns a 2D array indicating the 0-based index of each added position within the collection (-1 if it was invalid).
        public static int[,] CreatePositions(short[,] heixels, out Point3DCollection positions)
        {
            // TODO
            positions = new Point3DCollection();
            int[,] positionIndices = new int[heixels.GetLength(0), heixels.GetLength(1)];

            int faktor = 111;

            for (int x = 0; x < heixels.GetLength(0); x++)
            {
                for (int z = 0; z < heixels.GetLength(1); z++)
                {
                    //aus heixel array neue position collection befüllen
                    Point3D point = new Point3D(x * faktor, heixels[x, z], z * faktor);
                    positions.Add(point);


                    positionIndices[x, z] = x;
                }
            }          
            return positionIndices;
        }

        // Generates the triangle indices of a mesh from a 2D array of position indices. 
        // Adds the triangle indices and returns the collection. Leaves out triangles for invalid vertex positions.
        public static Int32Collection CreateTriangleIndices(int[,] positionIndices)
        {
            // TODO
            return null;
        }
    }
}
