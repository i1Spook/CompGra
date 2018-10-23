using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;

namespace Teapot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int N = 2048;

        public MainWindow()
        {
            InitializeComponent();

            Disk(bottom, false, 0.75);
            Disk(top, true);
            Band();
        }
        /// <summary>
        /// Draw circles
        /// </summary>
        /// <param name="i"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        Point3D Circle(int i, double y, double faktor = 1)
        {
            double x = faktor * Math.Cos(i * 2 * Math.PI / N);
            double z = faktor * Math.Sin(i * 2 * Math.PI / N);
            return new Point3D(0.5*x-3, 0.75*y-1, z);
        }

        /// <summary>
        /// Draw disk
        /// </summary>
        /// <param name="m">Mesh</param>
        /// <param name="isTop">Checks whether or not current mesh is top</param>
        void Disk(MeshGeometry3D m, bool isTop, double faktor = 1)
        {
            m.Positions.Clear();
            m.TriangleIndices.Clear();

            double y = isTop ? 1 : 0;

            for (int i = 0; i < N; i++)
            {
                m.Positions.Add(Circle(i, y, faktor));
            }
            // Center of disk has index N
            m.Positions.Add(new Point3D(0-3, y-1, 0));

            for (int i = 0; i < N; i++)
            {
                m.TriangleIndices.Add(N);
                if (isTop)
                {
                    m.TriangleIndices.Add((i + 1) % N);
                    m.TriangleIndices.Add(i);
                }
                else
                {
                    m.TriangleIndices.Add(i);
                    m.TriangleIndices.Add((i + 1) % N);
                }
            }
        }
        /// <summary>
        /// Draw band
        /// </summary>
        void Band()
        {
            band.Positions.Clear();
            band.TriangleIndices.Clear();

            for (int i = 0; i < N; i++)
            {
                band.Positions.Add(Circle(i, 0, 0.75));
            }
            for (int i = 0; i < N; i++)
            {
                band.Positions.Add(Circle(i, 1.75, 1.25));
            }

            for (int i = 0; i < N; i++)
            {
                band.TriangleIndices.Add(i);
                band.TriangleIndices.Add(N + (i + 1) % N);
                band.TriangleIndices.Add((i + 1) % N);

                band.TriangleIndices.Add(N + (i + 1) % N);
                band.TriangleIndices.Add(i);
                band.TriangleIndices.Add(N + i);
            }
        }
    }
}
