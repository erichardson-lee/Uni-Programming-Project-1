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
        private class Cell : PictureBox
        {
            public int x;
            public int y;
        }

        private int _rows;
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
                if (_rows > 0 && _columns > 0)
                {
                    InitializeGrid();
                }
            }
        }

        private int _columns;
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
                if (_rows > 0 && _columns > 0)
                {
                    InitializeGrid();
                }
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
                InitializeGrid();
            }
        }

        public GameGrid()
        {
            InitializeComponent();
        }

        [Description("Event Called whenever a cell is clicked"), Category("Game Grid")]
        public event CellPressedEventHandler CellPressed;

        /// <summary>
        /// Initializes the grid with it's default squares
        /// </summary>
        public void InitializeGrid()
        {
            if (_columns == 0 || _rows == 0)
            {
                //MessageBox.Show($"Col: {_columns}, Row: {_rows}");
                return;
            }

            _grid = new Cell[_columns, _rows];

            int colWidth = 100 / _columns;
            int rowHeight = 100 / _rows;

            tbl_gameGrid.Controls.Clear();
            tbl_gameGrid.ColumnStyles.Clear();
            tbl_gameGrid.RowStyles.Clear();

            tbl_gameGrid.ColumnCount = _columns;
            tbl_gameGrid.RowCount = _rows;

            for (int y = 0; y < _rows; y++)
            {
                tbl_gameGrid.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
                for (int x = 0; x < _rows; x++)
                {
                    tbl_gameGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colWidth));

                    // Flips y axis, so _grid [1,1] is bottom left,
                    // +'ve X is going right, and +'ve Y is going up.
                    ref Cell img = ref _grid[x, _rows - (y + 1)];

                    img = new Cell() { Image = _defaultImage };
                    img.Dock = DockStyle.Fill;
                    img.SizeMode = PictureBoxSizeMode.StretchImage;
                    img.Margin = new Padding(0);
                    img.x = x;
                    img.y = _rows - (y + 1);
                    img.Click += Img_Click;
                    tbl_gameGrid.Controls.Add(img, x, y);
                }
            }
        }

        private void Img_Click(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;
            CellPressedEventArgs args = new CellPressedEventArgs();

            args.cell = cell;
            args.x = cell.x;
            args.y = cell.y;

            CellPressed?.Invoke(cell, args);

        }

        /// <summary>
        /// Set the image of a cell on the grid
        /// </summary>
        /// <param name="x">X value of the cell</param>
        /// <param name="y">Y value of the cell</param>
        /// <param name="img">Image to set it to.</param>
        public void SetCell(int x, int y, Image img)
        {
            _grid[x, y].Image = img;
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

        /// <summary>
        /// If the component changes size, resize the grid so it stays square and goes as big as possible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbl_centerformat_Paint(object sender, PaintEventArgs e)
        {
            if (tbl_centerformat.Height > tbl_centerformat.Width)
            {
                tbl_gameGrid.Height = tbl_gameGrid.Width = tbl_centerformat.Width;
            }
            else
            {
                tbl_gameGrid.Height = tbl_gameGrid.Width = tbl_centerformat.Height;
            }
        }
    }

    public class CellPressedEventArgs : EventArgs
    {
        public PictureBox cell;
        public int x;
        public int y;
    }
}
