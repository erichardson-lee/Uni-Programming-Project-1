using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamegrid
{

    public delegate void CellPressedEventHandler(object sender, CellPressedEventArgs e);


    public partial class GameGrid : UserControl
    {
        private class Cell
        {
            public int x;
            public int y;
            public Image Image;
        }

        private int _rows = 8;
        [Description("The number of rows to display"), Category("Game Grid")]
        public int Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
                if (DesignMode)
                    InitializeGrid();
            }
        }

        private int _columns = 8;
        [Description("The number of columns to display"), Category("Game Grid")]
        public int Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
                if (DesignMode)
                    InitializeGrid();
            }
        }

        Cell[,] _grid;
        //[Description("A 2D Array of all the pictureboxes"), Category("Game Grid")]
        //public PictureBox[,] Grid
        //{
        //    get
        //    {
        //        return _grid;
        //    }
        //}

        private Image _defaultImage;
        [Description("The default image to use when populating the board"), Category("Game Grid")]
        public Image DefaultImage
        {
            get
            {
                return _defaultImage;
            }
            set
            {
                _defaultImage = value;

                if (DesignMode)
                    InitializeGrid();
            }
        }

        public GameGrid()
        {
            InitializeComponent();
            if (Columns == 0 || Rows == 0)
            {
                MessageBox.Show($"Col: {Columns}, Row: {Rows}");
            }
            else
            {
                InitializeGrid();
            }
        }

        [Description("Event Called whenever a cell is clicked"), Category("Game Grid")]
        public event CellPressedEventHandler CellPressed;

        public Graphics gridGraphics;

        private int GridCellWidth, GridCellHeight;
        private int GridWidth, GridHeight;

        /// <summary>
        /// Initializes the grid with it's default squares
        /// </summary>
        public void InitializeGrid()
        {
            if (Columns <= 0 || Rows <= 0)
            {
                //MessageBox.Show($"Col: {_columns}, Row: {_rows}");
                return;
            }

            if (DefaultImage != null)
            {
                GridCellWidth = DefaultImage.Width;
                GridCellHeight = DefaultImage.Height;
            }
            else
            {
                GridCellWidth = 512;
                GridCellHeight = 512;
                return;
            }

            const int maxdim = 2048;

            if (GridCellWidth * Columns > maxdim || GridCellHeight * Rows > maxdim)
            {
                if (Columns > Rows)
                {
                    GridCellHeight = maxdim / Rows;
                    GridCellWidth = GridCellHeight;
                }
                else
                {
                    GridCellWidth = maxdim / Rows;
                    GridCellHeight = GridCellWidth;
                }
            }

            // set cursor to wait one
            Cursor.Current = Cursors.WaitCursor;

            _grid = new Cell[Columns, Rows];

            GridWidth = GridCellWidth * Columns;
            GridHeight = GridCellHeight * Rows;

            grid_picturebox.Image = new Bitmap(GridWidth, GridHeight);
            gridGraphics = Graphics.FromImage(grid_picturebox.Image);

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    SetCell(x, y, DefaultImage, false);
                }
            }

            grid_picturebox.Refresh();

            // Set cursor back to normal
            Cursor.Current = Cursors.Default;

        }

        ///// <summary>
        ///// Event called whenever any image gets clicked
        ///// </summary>
        //private void Img_Click(object sender, EventArgs e)
        //{
        //    CellPressed?.Invoke(cell, args);

        //}

        /// <summary>
        /// Set the image of a cell on the grid
        /// </summary>
        /// <param name="x">X value of the cell</param>
        /// <param name="y">Y value of the cell</param>
        /// <param name="img">Image to set it to.</param>
        public void SetCell(int x, int y, Image img, bool refreshImage = true)
        {
            int imgx = x * GridCellWidth;
            int imgy = y * GridCellHeight;
            //int imgy = (Rows - (y + 1)) * GridCellHeight;
            gridGraphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            gridGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            gridGraphics.DrawImage(img, imgx, imgy, GridCellWidth, GridCellHeight);
            gridGraphics.DrawRectangle(Pens.Black, imgx, imgy, GridCellWidth, GridCellHeight);

            if (refreshImage) grid_picturebox.Refresh();

            //_grid[x, y].Image = img;
        }

        /// <summary>
        /// Get the current image stored in a cell on the grid
        /// </summary>
        /// <param name="x">X value of the cell</param>
        /// <param name="y">Y value of the cell</param>
        /// <returns>Image currently in that cell</returns>
        public Image GetCell(int x, int y)
        {
            return _grid[x, y].Image;
        }

        private void grid_picturebox_Click(object sender, EventArgs e)
        {
            Point pos = TranslateZoomMousePosition(grid_picturebox.PointToClient(MousePosition), grid_picturebox.Image, grid_picturebox.Width, grid_picturebox.Height);

            if ((pos.X >= 0 && pos.X < GridWidth) && (pos.Y >= 0 && pos.Y < GridHeight))
            {

                CellPressedEventArgs args = new CellPressedEventArgs();

                args.x = pos.X / GridCellWidth;
                args.y = pos.Y / GridCellHeight;

                if ((args.x >= 0 && args.x < Columns) && (args.y >= 0 && args.y < Rows))
                {
                    CellPressed?.Invoke(sender, args);
                }
            }
        }
        public void Refresh()
        {
            grid_picturebox.Refresh();
        }


        // Code modified from https://www.codeproject.com/Articles/20923/Mouse-Position-over-Image-in-a-PictureBox
        // Translates clicked position on the image to co-ordinates on the image
        protected Point TranslateZoomMousePosition(Point coordinates, Image image, int width, int height)
        {
            // test to make sure our image is not null
            if (image == null) return coordinates;

            // Make sure our control width and height are not 0 and our 
            // image width and height are not 0
            if (width == 0 || height == 0 || image.Width == 0 || image.Height == 0) return coordinates;

            // This is the one that gets a little tricky. Essentially, need to check 
            // the aspect ratio of the image to the aspect ratio of the control
            // to determine how it is being rendered
            float imageAspect = (float)image.Width / image.Height;
            float controlAspect = (float)width / height;
            float newX = coordinates.X;
            float newY = coordinates.Y;
            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, 
                // meaning the image fills up the entire control from left to right
                float ratioWidth = (float)image.Width / width;
                newX *= ratioWidth;
                float scale = (float)width / image.Width;
                float displayHeight = scale * image.Height;
                float diffHeight = height - displayHeight;
                diffHeight /= 2;
                newY -= diffHeight;
                newY /= scale;
            }
            else
            {
                // This means that we are limited by height, 
                // meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)image.Height / height;
                newY *= ratioHeight;
                float scale = (float)height / image.Height;
                float displayWidth = scale * image.Width;
                float diffWidth = Width - displayWidth;
                diffWidth /= 2;
                newX -= diffWidth;
                newX /= scale;
            }
            return new Point((int)newX, (int)newY);
        }
    }

    public class CellPressedEventArgs : EventArgs
    {
        public PictureBox cell;
        public int x;
        public int y;
    }
}
