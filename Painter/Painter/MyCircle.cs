using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace Painter
{
	public class MyCircle
	{
		private Rectangle rectC;
		private Pen pen;
		private SolidBrush solidBrush;
		private Boolean fillMode;

		public MyCircle()
		{
			this.rectC = new Rectangle();
		}
		public void setRect(Point start,Point finish, Pen shapePen,Boolean fillMode)
		{
			rectC.X = Math.Min(start.X, finish.X);
			rectC.Y = Math.Min(start.Y, finish.Y);
			rectC.Width = Math.Abs(start.X - finish.X);
			rectC.Height = Math.Abs(start.Y - finish.Y);
			this.pen = (Pen)shapePen.Clone();
			this.fillMode = fillMode;
		}
		public void setSolidRect(Point start, Point finish, SolidBrush sb,Boolean fillMode)
		{
			rectC.X = Math.Min(start.X, finish.X);
			rectC.Y = Math.Min(start.Y, finish.Y);
			rectC.Width = Math.Abs(start.X - finish.X);
			rectC.Height = Math.Abs(start.Y - finish.Y);
			this.solidBrush = (SolidBrush)sb.Clone();
			this.fillMode = fillMode;
		}
		public Rectangle getRectC()
		{
			return rectC;
		}
		public Pen getPen()
		{
			return this.pen;
		}
		public Boolean getFillMode()
		{
			return this.fillMode;
		}
		public SolidBrush getSolidBrush()
		{
			return this.solidBrush;
		}
	}
}
