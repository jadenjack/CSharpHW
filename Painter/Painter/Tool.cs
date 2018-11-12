using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
	[SerializableAttribute]
	[ComVisibleAttribute(true)]
	public class Tool
	{
		public enum TOOL {PENCIL,BRUSH,LINE,SQUARE,OVAL,WIDTH,FILL, EMPTY};
	}
}
