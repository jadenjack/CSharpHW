using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
	public partial class Form2 : Form
	{
		Tool.TOOL selectedTool;
		Form1 parent;
		public string path;
		public string fullPath;
		bool isRecord;
		List<Point> posList;
		Pen MyPencil;
		Pen MyBrush;
		Pen ShapePen;
		SolidBrush ShapeSolidPen;

		Point ShapeStartPosition;
		Point ShapeEndPosition;

		Graphics g;

		private MyLines newline = new MyLines();
		private MyRect newrect = new MyRect();
		private MyCircle newcircle = new MyCircle();
		private Point start;
		private Point finish;
		private int nline = 0;
		private int nrect = 0;
		private int ncircle = 0;
		private List<MyLines> lines;
		private List<MyRect> rects;
		private List<MyCircle> circles;


		public const float DEFAULT_PENCIL_WIDTH = 1.0f;
		public const float DEFAULT_BRUSH_WIDTH = 5.0f;
		public const float DEFAULT_SHAPE_WIDTH = 1.0f;

		public Form2()
		{
			InitializeComponent();

		}

		private void Form2_Load(object sender, EventArgs e)
		{
			parent = (Form1)this.MdiParent;
			isRecord = false;
			if (parent != null)
				parent.syncButtonEnable();
			MyPencil = new Pen(parent.selectedColor, DEFAULT_PENCIL_WIDTH);
			MyBrush = new Pen(parent.selectedColor, DEFAULT_BRUSH_WIDTH);
			ShapePen = new Pen(parent.selectedColor, DEFAULT_SHAPE_WIDTH);
			ShapeSolidPen = new SolidBrush(parent.selectedColor);
			posList = new List<Point>();

			lines = new List<MyLines>();
			rects = new List<MyRect>();
			circles = new List<MyCircle>();
		}
		private void Form2_FormClosed(object sender, FormClosedEventArgs e)
		{
			parent.decreaseNumOfChild();
			parent.syncButtonEnable();
			if(this.fullPath!=null)
				parent.saveImage(this);
		}

		private void Form2_MouseDown(object sender, MouseEventArgs e)
		{
			this.selectedTool = ((Form1)this.MdiParent).selectedTool;
			isRecord = true;
			switch (this.selectedTool)
			{
				case Tool.TOOL.PENCIL:
				case Tool.TOOL.BRUSH:
					Pencil_Start();
					break;
				case Tool.TOOL.LINE:
				case Tool.TOOL.SQUARE:
				case Tool.TOOL.OVAL:
					Shape_Start();
					break;
				case Tool.TOOL.WIDTH:
					break;
				case Tool.TOOL.FILL:
					break;
			}
		}

		private void Form2_MouseMove(object sender, MouseEventArgs e)
		{
			if (!isRecord)
				return;

			this.selectedTool = ((Form1)this.MdiParent).selectedTool;
			switch (this.selectedTool)
			{
				case Tool.TOOL.PENCIL:
				case Tool.TOOL.BRUSH:
					Pencil_Move();
					break;
				case Tool.TOOL.LINE:
				case Tool.TOOL.SQUARE:
				case Tool.TOOL.OVAL:
					Shape_Move();
					break;
				case Tool.TOOL.WIDTH:
					break;
				case Tool.TOOL.FILL:
					break;
			}
			this.panel1.Update();
		}

		private void Form2_MouseUp(object sender, MouseEventArgs e)
		{
			this.selectedTool = ((Form1)this.MdiParent).selectedTool;

			switch (this.selectedTool)
			{
				case Tool.TOOL.PENCIL:
				case Tool.TOOL.BRUSH:
					Pencil_Up();
					isRecord = false;
					break;
				case Tool.TOOL.LINE:
				case Tool.TOOL.SQUARE:
				case Tool.TOOL.OVAL:
					Shape_Up();
					break;
				case Tool.TOOL.WIDTH:
					break;
				case Tool.TOOL.FILL:
					break;
			}
			drawAllUp();
			this.panel1.Update();
		}

		private void Pencil_Start()
		{
			Form1 parent = ((Form1)this.parent);
			Color sColor = parent.selectedColor;
			switch (this.selectedTool)
			{
				case Tool.TOOL.PENCIL:
					MyPencil.Color = sColor;
					break;
				case Tool.TOOL.BRUSH:
					MyBrush.Color = sColor;
					break;
			}
			posList.Add(GetCurrentPosision());
		}
		private void Pencil_Move()
		{
			posList.Add(GetCurrentPosision());
			this.panel1.Invalidate();
		}
		private void Pencil_Up()
		{
			posList.Add(GetCurrentPosision());
			this.panel1.Invalidate();
			posList.Clear();
		}

		private void Shape_Start()
		{
			ShapeStartPosition = GetCurrentPosision();
			PrepareShapePen();
			PrepareShape();
		}
		private void Shape_Move()
		{
			ShapeEndPosition = GetCurrentPosision();
			switch (this.selectedTool)
			{
				case Tool.TOOL.LINE:
					MyDrawLine(g, ShapeStartPosition, ShapeEndPosition);
					break;
				case Tool.TOOL.SQUARE:
					MyDrawRectangle(g, ShapeStartPosition, ShapeEndPosition);
					break;
				case Tool.TOOL.OVAL:
					MyDrawOval(g, ShapeStartPosition, ShapeEndPosition);
					break;
			}
			this.panel1.Invalidate(true);
		}
		private void Shape_Up()
		{
			ShapeEndPosition = GetCurrentPosision();
			this.panel1.Invalidate(true);
			isRecord = false;
			EndShape();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			if (!isRecord)
				return;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			try
			{
				switch (this.selectedTool)
				{
					case Tool.TOOL.PENCIL:
						g = Graphics.FromImage(panel1.BackgroundImage);
						g.DrawLines(MyPencil, posList.ToArray());
						break;
					case Tool.TOOL.BRUSH:
						g = Graphics.FromImage(panel1.BackgroundImage);
						g.DrawLines(MyBrush, posList.ToArray());
						break;
					case Tool.TOOL.WIDTH:
						break;
					case Tool.TOOL.FILL:
						break;
				}
			}catch(ArgumentException a)
			{
				Console.WriteLine("ArgumentException");
			}
			drawAll(e.Graphics);
		}



		private Point GetCurrentPosision()
		{
			return this.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
		}

		private void PrepareShapePen()
		{
			if (parent.fillMode == false)
			{//채우기 없음
				if (ShapePen.Color != parent.selectedColor)
					ShapePen.Color = parent.selectedColor;
				if (ShapePen.Width != parent.selectedWidth)
					ShapePen.Width = parent.selectedWidth;
			}
			else
			{
				if (ShapeSolidPen.Color != parent.selectedColor)
					ShapeSolidPen.Color = parent.selectedColor;
			}
		}
		private void PrepareShape()
		{
			switch (this.selectedTool)
			{
				case Tool.TOOL.LINE:
					lines.Add(newline);
					break;
				case Tool.TOOL.SQUARE:
					rects.Add(newrect);
					break;
				case Tool.TOOL.OVAL:
					circles.Add(newcircle);
					break;
			}
		}
		private void EndShape()
		{
			switch (this.selectedTool)
			{
				case Tool.TOOL.LINE:
					nline++;
					break;
				case Tool.TOOL.SQUARE:
					nrect++;
					break;
				case Tool.TOOL.OVAL:
					ncircle++;
					break;
			}
		}
		private void MyDrawLine(Graphics g, Point start, Point end)
		{
			newline.setPaint(start, end, ShapePen);
			lines[nline] = newline;
		}
		private void MyDrawRectangle(Graphics g, Point start, Point end)
		{
			if (parent.fillMode == false)
				newrect.setRect(start, end, ShapePen, parent.fillMode);
			else
				newrect.setSolidRect(start, end, ShapeSolidPen, parent.fillMode);
			rects[nrect] = newrect;

		}
		private void MyDrawOval(Graphics g, Point start, Point end)
		{
			if (parent.fillMode == false)
				newcircle.setRect(start, end, ShapePen,parent.fillMode);
			else
				newcircle.setSolidRect(start, end, ShapeSolidPen, parent.fillMode);
			circles[ncircle] = newcircle;
		}
		private void drawAll(Graphics e)
		{
			foreach (MyLines line in lines)
			{
				e.DrawLine(line.getPen(), line.getPoint1(), line.getPoint2());
			}
			foreach (MyRect rect in rects)
			{
				if(rect.getFillMode()==false)
					e.DrawRectangle(rect.getPen(), rect.getRect());
				else
					e.FillRectangle(rect.getSolidBrush(), rect.getRect());
			}
			foreach (MyCircle circle in circles)
			{
				if (circle.getFillMode() == false)
					e.DrawEllipse(circle.getPen(), circle.getRectC());
				else
					e.FillEllipse(circle.getSolidBrush(), circle.getRectC());
			}
		}

		private void drawAllUp()
		{
			g = Graphics.FromImage(panel1.BackgroundImage);
			drawAll(g);
		}
		public void clearAll()
		{
			this.lines.Clear();
			this.circles.Clear();
			this.rects.Clear();
		}
	}

}
