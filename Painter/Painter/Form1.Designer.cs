namespace Painter
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menustrip_file = new System.Windows.Forms.ToolStripMenuItem();
			this.menustrip_file_new = new System.Windows.Forms.ToolStripMenuItem();
			this.menustrip_file_open = new System.Windows.Forms.ToolStripMenuItem();
			this.menustrip_file_save = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menustrip_file_exit = new System.Windows.Forms.ToolStripMenuItem();
			this.menustrip_image = new System.Windows.Forms.ToolStripMenuItem();
			this.menustrip_image_delete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStrip_colordialog = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip_pencil = new System.Windows.Forms.ToolStripButton();
			this.toolStrip_brush = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip_line = new System.Windows.Forms.ToolStripButton();
			this.toolStrip_square = new System.Windows.Forms.ToolStripButton();
			this.toolStrip_oval = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip_width = new System.Windows.Forms.ToolStripButton();
			this.toolStrip_fill = new System.Windows.Forms.ToolStripButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.widthContainer = new System.Windows.Forms.Panel();
			this.width5 = new System.Windows.Forms.Button();
			this.width4 = new System.Windows.Forms.Button();
			this.width3 = new System.Windows.Forms.Button();
			this.width2 = new System.Windows.Forms.Button();
			this.width1 = new System.Windows.Forms.Button();
			this.fillContainer = new System.Windows.Forms.Panel();
			this.fill2 = new System.Windows.Forms.Button();
			this.fill1 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.widthContainer.SuspendLayout();
			this.fillContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menustrip_file,
            this.menustrip_image});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(880, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menustrip_file
			// 
			this.menustrip_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menustrip_file_new,
            this.menustrip_file_open,
            this.menustrip_file_save,
            this.toolStripMenuItem1,
            this.menustrip_file_exit});
			this.menustrip_file.Name = "menustrip_file";
			this.menustrip_file.Size = new System.Drawing.Size(57, 20);
			this.menustrip_file.Text = "파일(&F)";
			this.menustrip_file.Click += new System.EventHandler(this.파일FToolStripMenuItem_Click);
			// 
			// menustrip_file_new
			// 
			this.menustrip_file_new.Name = "menustrip_file_new";
			this.menustrip_file_new.Size = new System.Drawing.Size(155, 22);
			this.menustrip_file_new.Text = "새로 만들기(&N)";
			this.menustrip_file_new.Click += new System.EventHandler(this.menustrip_file_new_Click);
			// 
			// menustrip_file_open
			// 
			this.menustrip_file_open.Name = "menustrip_file_open";
			this.menustrip_file_open.Size = new System.Drawing.Size(155, 22);
			this.menustrip_file_open.Text = "열기(&O)";
			this.menustrip_file_open.Click += new System.EventHandler(this.menustrip_file_open_Click);
			// 
			// menustrip_file_save
			// 
			this.menustrip_file_save.Name = "menustrip_file_save";
			this.menustrip_file_save.Size = new System.Drawing.Size(155, 22);
			this.menustrip_file_save.Text = "저장(&S)";
			this.menustrip_file_save.Click += new System.EventHandler(this.menustrip_file_save_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
			// 
			// menustrip_file_exit
			// 
			this.menustrip_file_exit.Name = "menustrip_file_exit";
			this.menustrip_file_exit.Size = new System.Drawing.Size(155, 22);
			this.menustrip_file_exit.Text = "끝내기(&X)";
			// 
			// menustrip_image
			// 
			this.menustrip_image.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menustrip_image_delete});
			this.menustrip_image.Name = "menustrip_image";
			this.menustrip_image.Size = new System.Drawing.Size(66, 20);
			this.menustrip_image.Text = "이미지(I)";
			// 
			// menustrip_image_delete
			// 
			this.menustrip_image_delete.Name = "menustrip_image_delete";
			this.menustrip_image_delete.Size = new System.Drawing.Size(167, 22);
			this.menustrip_image_delete.Text = "이미지 지우기(&N)";
			this.menustrip_image_delete.Click += new System.EventHandler(this.menustrip_image_delete_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_colordialog,
            this.toolStripButton1,
            this.toolStrip_pencil,
            this.toolStrip_brush,
            this.toolStripSeparator1,
            this.toolStrip_line,
            this.toolStrip_square,
            this.toolStrip_oval,
            this.toolStripSeparator2,
            this.toolStrip_width,
            this.toolStrip_fill});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(32, 547);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStrip_colordialog
			// 
			this.toolStrip_colordialog.Name = "toolStrip_colordialog";
			this.toolStrip_colordialog.ReadOnly = true;
			this.toolStrip_colordialog.Size = new System.Drawing.Size(27, 23);
			this.toolStrip_colordialog.Click += new System.EventHandler(this.toolStrip_colordialog_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(29, 4);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// toolStrip_pencil
			// 
			this.toolStrip_pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStrip_pencil.Image = global::Painter.Properties.Resources.pencil_48;
			this.toolStrip_pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStrip_pencil.Name = "toolStrip_pencil";
			this.toolStrip_pencil.Size = new System.Drawing.Size(29, 20);
			this.toolStrip_pencil.Text = "toolStripButton2";
			this.toolStrip_pencil.Click += new System.EventHandler(this.toolStrip_pencil_Click);
			// 
			// toolStrip_brush
			// 
			this.toolStrip_brush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStrip_brush.Image = global::Painter.Properties.Resources.brush_48;
			this.toolStrip_brush.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStrip_brush.Name = "toolStrip_brush";
			this.toolStrip_brush.Size = new System.Drawing.Size(29, 20);
			this.toolStrip_brush.Text = "toolStripButton3";
			this.toolStrip_brush.Click += new System.EventHandler(this.toolStrip_brush_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(29, 6);
			// 
			// toolStrip_line
			// 
			this.toolStrip_line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStrip_line.Image = global::Painter.Properties.Resources.line_48;
			this.toolStrip_line.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStrip_line.Name = "toolStrip_line";
			this.toolStrip_line.Size = new System.Drawing.Size(29, 20);
			this.toolStrip_line.Text = "toolStripButton4";
			this.toolStrip_line.Click += new System.EventHandler(this.toolStrip_line_Click);
			// 
			// toolStrip_square
			// 
			this.toolStrip_square.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStrip_square.Image = global::Painter.Properties.Resources.rectangular_48;
			this.toolStrip_square.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStrip_square.Name = "toolStrip_square";
			this.toolStrip_square.Size = new System.Drawing.Size(29, 20);
			this.toolStrip_square.Text = "toolStripButton5";
			this.toolStrip_square.Click += new System.EventHandler(this.toolStrip_square_Click);
			// 
			// toolStrip_oval
			// 
			this.toolStrip_oval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStrip_oval.Image = global::Painter.Properties.Resources.oval_48;
			this.toolStrip_oval.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStrip_oval.Name = "toolStrip_oval";
			this.toolStrip_oval.Size = new System.Drawing.Size(29, 20);
			this.toolStrip_oval.Text = "toolStripButton6";
			this.toolStrip_oval.Click += new System.EventHandler(this.toolStrip_oval_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(29, 6);
			// 
			// toolStrip_width
			// 
			this.toolStrip_width.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStrip_width.Image = global::Painter.Properties.Resources.line_width_48;
			this.toolStrip_width.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStrip_width.Name = "toolStrip_width";
			this.toolStrip_width.Size = new System.Drawing.Size(29, 20);
			this.toolStrip_width.Text = "toolStripButton7";
			this.toolStrip_width.Click += new System.EventHandler(this.toolStrip_width_Click);
			// 
			// toolStrip_fill
			// 
			this.toolStrip_fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStrip_fill.Image = global::Painter.Properties.Resources.rectangle_48;
			this.toolStrip_fill.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStrip_fill.Name = "toolStrip_fill";
			this.toolStrip_fill.Size = new System.Drawing.Size(29, 20);
			this.toolStrip_fill.Text = "toolStripButton8";
			this.toolStrip_fill.Click += new System.EventHandler(this.toolStrip_fill_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog2";
			// 
			// widthContainer
			// 
			this.widthContainer.Controls.Add(this.width5);
			this.widthContainer.Controls.Add(this.width4);
			this.widthContainer.Controls.Add(this.width3);
			this.widthContainer.Controls.Add(this.width2);
			this.widthContainer.Controls.Add(this.width1);
			this.widthContainer.Location = new System.Drawing.Point(29, 188);
			this.widthContainer.Name = "widthContainer";
			this.widthContainer.Size = new System.Drawing.Size(149, 30);
			this.widthContainer.TabIndex = 3;
			this.widthContainer.Visible = false;
			// 
			// width5
			// 
			this.width5.Location = new System.Drawing.Point(120, 4);
			this.width5.Name = "width5";
			this.width5.Size = new System.Drawing.Size(23, 23);
			this.width5.TabIndex = 4;
			this.width5.Text = "5";
			this.width5.UseVisualStyleBackColor = true;
			this.width5.Click += new System.EventHandler(this.width5_Click);
			// 
			// width4
			// 
			this.width4.Location = new System.Drawing.Point(91, 3);
			this.width4.Name = "width4";
			this.width4.Size = new System.Drawing.Size(23, 23);
			this.width4.TabIndex = 4;
			this.width4.Text = "4";
			this.width4.UseVisualStyleBackColor = true;
			this.width4.Click += new System.EventHandler(this.width4_Click);
			// 
			// width3
			// 
			this.width3.Location = new System.Drawing.Point(62, 3);
			this.width3.Name = "width3";
			this.width3.Size = new System.Drawing.Size(23, 23);
			this.width3.TabIndex = 2;
			this.width3.Text = "3";
			this.width3.UseVisualStyleBackColor = true;
			this.width3.Click += new System.EventHandler(this.width3_Click);
			// 
			// width2
			// 
			this.width2.Location = new System.Drawing.Point(33, 4);
			this.width2.Name = "width2";
			this.width2.Size = new System.Drawing.Size(23, 23);
			this.width2.TabIndex = 1;
			this.width2.Text = "2";
			this.width2.UseVisualStyleBackColor = true;
			this.width2.Click += new System.EventHandler(this.width2_Click);
			// 
			// width1
			// 
			this.width1.Location = new System.Drawing.Point(4, 4);
			this.width1.Name = "width1";
			this.width1.Size = new System.Drawing.Size(23, 23);
			this.width1.TabIndex = 0;
			this.width1.Text = "1";
			this.width1.UseVisualStyleBackColor = true;
			this.width1.Click += new System.EventHandler(this.width1_Click);
			// 
			// fillContainer
			// 
			this.fillContainer.Controls.Add(this.fill2);
			this.fillContainer.Controls.Add(this.fill1);
			this.fillContainer.Location = new System.Drawing.Point(29, 213);
			this.fillContainer.Name = "fillContainer";
			this.fillContainer.Size = new System.Drawing.Size(131, 27);
			this.fillContainer.TabIndex = 5;
			this.fillContainer.Visible = false;
			// 
			// fill2
			// 
			this.fill2.Location = new System.Drawing.Point(85, 2);
			this.fill2.Name = "fill2";
			this.fill2.Size = new System.Drawing.Size(41, 23);
			this.fill2.TabIndex = 1;
			this.fill2.Text = "단색";
			this.fill2.UseVisualStyleBackColor = true;
			this.fill2.Click += new System.EventHandler(this.fill2_Click);
			// 
			// fill1
			// 
			this.fill1.Location = new System.Drawing.Point(4, 2);
			this.fill1.Name = "fill1";
			this.fill1.Size = new System.Drawing.Size(75, 23);
			this.fill1.TabIndex = 0;
			this.fill1.Text = "채우기없음";
			this.fill1.UseVisualStyleBackColor = true;
			this.fill1.Click += new System.EventHandler(this.fill1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(880, 571);
			this.Controls.Add(this.fillContainer);
			this.Controls.Add(this.widthContainer);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "그림판";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.widthContainer.ResumeLayout(false);
			this.fillContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menustrip_file;
		private System.Windows.Forms.ToolStripMenuItem menustrip_file_new;
		private System.Windows.Forms.ToolStripMenuItem menustrip_file_open;
		public System.Windows.Forms.ToolStripMenuItem menustrip_file_save;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menustrip_file_exit;
		private System.Windows.Forms.ToolStripMenuItem menustrip_image;
		private System.Windows.Forms.ToolStrip toolStrip1;
		public System.Windows.Forms.ToolStripMenuItem menustrip_image_delete;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.ToolStripTextBox toolStrip_colordialog;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStrip_pencil;
		private System.Windows.Forms.ToolStripButton toolStrip_brush;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStrip_line;
		private System.Windows.Forms.ToolStripButton toolStrip_square;
		private System.Windows.Forms.ToolStripButton toolStrip_oval;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolStrip_width;
		private System.Windows.Forms.ToolStripButton toolStrip_fill;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Panel widthContainer;
		private System.Windows.Forms.Button width5;
		private System.Windows.Forms.Button width4;
		private System.Windows.Forms.Button width3;
		private System.Windows.Forms.Button width2;
		private System.Windows.Forms.Button width1;
		private System.Windows.Forms.Panel fillContainer;
		private System.Windows.Forms.Button fill2;
		private System.Windows.Forms.Button fill1;
	}
}

