using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painter
{
	class MyRect
	{
		private Rectangle rect;
		private Pen pen;
		private Boolean fillMode;
		private SolidBrush solidBrush;

		public MyRect()
		{
			rect = new Rectangle();
		}
		public void setRect(Point start,Point finish, Pen shapePen,Boolean fillMode)
		{
			rect.X = Math.Min(start.X, finish.X);
			rect.Y = Math.Min(start.Y, finish.Y);
			rect.Height = Math.Abs(finish.Y - start.Y);
			rect.Width = Math.Abs(finish.X - start.X);
			this.pen = (Pen)shapePen.Clone();
			this.fillMode = fillMode;
		}
		public void setSolidRect(Point start,Point finish, SolidBrush sb, Boolean fillMode)
		{
			rect.X = Math.Min(start.X, finish.X);
			rect.Y = Math.Min(start.Y, finish.Y);
			rect.Height = Math.Abs(finish.Y - start.Y);
			rect.Width = Math.Abs(finish.X - start.X);
			this.solidBrush = (SolidBrush)sb.Clone();
			this.fillMode = fillMode;
		}
		public Rectangle getRect()
		{
			return rect;
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
