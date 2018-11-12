using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Painter
{
	public partial class Form1 : Form
	{
		Form2 child;
		public int numOfChild;
		public Color selectedColor = Color.Black;
		public float selectedWidth = 1.0f;
		public Boolean fillMode = false;

		
		public Tool.TOOL selectedTool;
		enum TOOL {PENCIL,BRUSH,LINE,SQUARE,OVAL,WIDTH,FILL};

		public Form1()
		{
			InitializeComponent();
			this.toolStrip_colordialog.BackColor = Color.Black;
			this.selectedTool = Tool.TOOL.EMPTY;
		}

		private void 파일FToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		public void decreaseNumOfChild()
		{
			numOfChild--;
		}
		public void increaseNumOfChild()
		{
			numOfChild++;
		}
		public void syncButtonEnable()
		{
			if (numOfChild > 0)
			{
				this.menustrip_file_save.Enabled = true;
				this.menustrip_image_delete.Enabled = true;
			}
			else
			{
				this.menustrip_file_save.Enabled = false;
				this.menustrip_image_delete.Enabled = false;
			}


		}

		private void Form1_Load(object sender, EventArgs e)
		{
			numOfChild = 0;
			syncButtonEnable();
		}

		private void menustrip_file_new_Click(object sender, EventArgs e)
		{
			numOfChild++;
			if (numOfChild == 1)
			{
				child = new Form2();
				child.WindowState = FormWindowState.Maximized;
				child.MdiParent = this;
				child.Text = "제목 없음";
			}
			else
			{
				child.WindowState = FormWindowState.Normal;
				child = new Form2();
				child.MdiParent = this;
				child.Text = "제목 없음";
			}
			Image image = new Bitmap(this.Width, this.Height);
			Rectangle rect = new Rectangle(Point.Empty, image.Size);
			using (Graphics G = Graphics.FromImage(image))
			{
				G.Clear(Color.White);
				G.DrawImageUnscaledAndClipped(image, rect);
			}
			child.panel1.BackgroundImage = image;
			child.Show();
		}

		private void menustrip_file_open_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "이미지 파일 (*.jpg)|*.jpg|이미지 파일 (*.jpeg)|*.jpeg|비트맵 파일 (*.bmp)|*.bmp|png 파일 (*.png)|*.png";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if (numOfChild == 1)
				{
					child.WindowState = FormWindowState.Normal;
				}
				numOfChild++;
				child = new Form2();
				child.MdiParent = this;
				//파일의 절대경로
				string fullFileName = openFileDialog1.FileName;
				child.fullPath = fullFileName;
				//파일의 이름
				child.Text = Path.GetFileName(fullFileName);
				child.path = Path.GetFileName(fullFileName);

				FileStream fs = new System.IO.FileStream(fullFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				child.panel1.BackgroundImage = System.Drawing.Image.FromStream(fs);
				fs.Close();
				//child.panel1.BackgroundImage = Image.FromFile(fullFileName);
				child.panel1.BackgroundImageLayout = ImageLayout.Stretch;
				
				child.Width = child.panel1.BackgroundImage.Width + 16;
				child.Height = child.panel1.BackgroundImage.Height + 39;
				child.Show();
			}

		}

		private void menustrip_file_save_Click(object sender, EventArgs e)
		{
			Form2 ac = (Form2)this.ActiveMdiChild;
			
			
			if (ac.fullPath == null )
			{
				saveFileDialog1.Filter = "이미지 파일 (*.jpg)|*.jpg|이미지 파일 (*.jpeg)|*.jpeg|비트맵 파일 (*.bmp)|*.bmp|png 파일 (*.png)|*.png";
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					ac.fullPath = saveFileDialog1.FileName;
					ac.path = Path.GetFileName(ac.fullPath);
				}
			}
			saveImage(ac);
		}
		public void saveImage(Form2 ac)
		{
			Bitmap bmp = new Bitmap(ac.panel1.Width, ac.panel1.Height);
			ac.panel1.DrawToBitmap(bmp, new Rectangle(0, 0, ac.panel1.Width, ac.panel1.Height));

			ImageFormat fmt = getImageFormat(ac.fullPath);
			try
			{
				if (File.Exists(ac.fullPath))
				{
					File.Delete(ac.fullPath);
				}


			}
			catch (IOException ex)
			{
				ac.panel1.BackgroundImage.Dispose();
				ac.panel1.BackgroundImage = null;
				File.Delete(ac.fullPath);
			}
			finally
			{
				bmp.Save(ac.fullPath, fmt);
				ac.Text = ac.path;
				bmp.Dispose();
				FileStream fs = new System.IO.FileStream(ac.fullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				ac.panel1.BackgroundImage = System.Drawing.Image.FromStream(fs);
				fs.Close();
			}
		}

		private ImageFormat getImageFormat(string fullpath)
		{
			string extension = Path.GetExtension(fullpath);
			switch (extension)
			{
				case ".jpg":
				case ".jpeg":
					return ImageFormat.Jpeg;
				case ".bmp":
					return ImageFormat.Bmp;
				case ".gif":
					return ImageFormat.Gif;
				case ".png":
					return ImageFormat.Png;
			}
			return null;
		}

		private void toolStrip_colordialog_Click(object sender, EventArgs e)
		{
			this.toolStrip_colordialog.Enabled = false;
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				this.toolStrip_colordialog.BackColor = colorDialog1.Color;
				this.selectedColor = colorDialog1.Color;
			}
			this.toolStrip_colordialog.Enabled = true;
		}

		private void toolStrip_pencil_Click(object sender, EventArgs e)
		{
			this.selectedTool = Tool.TOOL.PENCIL;
		}

		private void toolStrip_brush_Click(object sender, EventArgs e)
		{
			this.selectedTool = Tool.TOOL.BRUSH;
		}

		private void toolStrip_line_Click(object sender, EventArgs e)
		{
			this.selectedTool = Tool.TOOL.LINE;
		}

		private void toolStrip_square_Click(object sender, EventArgs e)
		{
			this.selectedTool = Tool.TOOL.SQUARE;
		}

		private void toolStrip_oval_Click(object sender, EventArgs e)
		{
			this.selectedTool = Tool.TOOL.OVAL;
		}

		private void toolStrip_width_Click(object sender, EventArgs e)
		{
			widthContainer.Visible ^= true;
		}

		private void toolStrip_fill_Click(object sender, EventArgs e)
		{
			fillContainer.Visible ^= true;
		}

		private void width1_Click(object sender, EventArgs e)
		{
			this.selectedWidth = 1.0f;
		}

		private void width2_Click(object sender, EventArgs e)
		{
			this.selectedWidth = 2.0f;
		}

		private void width3_Click(object sender, EventArgs e)
		{
			this.selectedWidth = 3.0f;
		}

		private void width4_Click(object sender, EventArgs e)
		{
			this.selectedWidth = 4.0f;
		}

		private void width5_Click(object sender, EventArgs e)
		{
			this.selectedWidth = 5.0f;
		}

		private void fill1_Click(object sender, EventArgs e)
		{
			this.fillMode = false;
		}

		private void fill2_Click(object sender, EventArgs e)
		{
			this.fillMode = true;
		}

		private void menustrip_image_delete_Click(object sender, EventArgs e)
		{
			Form2 activeChild = (Form2)this.ActiveMdiChild;
			activeChild.clearAll();
			Graphics g = Graphics.FromImage(activeChild.panel1.BackgroundImage);
			g.Clear(Color.White);
			activeChild.panel1.Refresh();
		}
	}
}
