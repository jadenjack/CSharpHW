using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
	public class DoubleBufferedPanel : Panel
	{
		public DoubleBufferedPanel()
		{
			EnableDoubleBuffering();
		}
		public void EnableDoubleBuffering()
		{
			// Set the value of the double-buffering style bits to true.
			this.SetStyle(ControlStyles.DoubleBuffer |
			   ControlStyles.UserPaint |
			   ControlStyles.AllPaintingInWmPaint |
			   ControlStyles.OptimizedDoubleBuffer,
			   true);
			this.UpdateStyles();
		}
	}
}
