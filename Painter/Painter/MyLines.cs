using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painter
{
	class MyLines
	{
		private Point[] point = new Point[2];
		private Pen pen;

		public MyLines()
		{
			point[0] = new Point();
			point[1] = new Point();
		}
		
		public void setPaint(Point start, Point finish, Pen shapePen)
		{
			point[0] = start;
			point[1] = finish;
			this.pen = (Pen)shapePen.Clone();
		}

		public Point getPoint1()
		{
			return point[0];
		}
		public Point getPoint2()
		{
			return point[1];
		}
		public Pen getPen()
		{
			return this.pen;
		}
	}
}
