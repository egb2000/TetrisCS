using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Tetris
{
    public partial class FormMain : Office2007Form
    {
        private const int ROW_COUNT = 18;
        private const int COLUMN_COUNT = 10;

        private const int MARGIN_SIZE = 5;
        private const int BLOCK_SIZE = 25;

        private const int BLOCKDOMNTIME = 700;  //成形方块自动下落一步用的时间，用着Timer的参数

        private List<bool[,]> BLOCKS_DEFINE = new List<bool[,]>
        {
            new bool[4, 4] { { false, true, false, false }, { false, true, false, false }, { false, true, false, false }, { false, true, false, false } },//条形状方块
            new bool[4, 4] { { false, false, false, false }, { false, true, true, false }, { false, true, true, false }, { false, false, false, false } },//田形状方块
            new bool[4, 4] { { false, true, false, false }, { false, true, false, false }, { false, true, true, false }, { false, false, false, false } },//L形状方块
            new bool[4, 4] { { false, false, true, false }, { false, false, true, false }, { false, true, true, false }, { false, false, false, false } },//J形状方块
            new bool[4, 4] { { false, false, false, false }, { false, true, false, false }, { true, true, true, false }, { false, false, false, false } },//土形状方块
            new bool[4, 4] { { false, false, false, false }, { false, true, true, false }, { true, true, false, false }, { false, false, false, false } },//S形状方块
            new bool[4, 4] { { false, false, false, false }, { true, true, false, false }, { false, true, true, false }, { false, false, false, false } } //2形状方块
        };

        private int previewBlockArrayIndex = 0;
        private bool[,] PreviewBlockArray { get { return BLOCKS_DEFINE[previewBlockArrayIndex]; } }
        private Color PreviewBlockColor;
         
        private bool[,] CurrentBlockArray { get; set; }
        private Color CurrentBlockColor;

        private int CurrentBlock_ColumnIndex = 3;//当前成形方块的列索引
        private int CurrentBlock_RowIndex = -3;//当前成形方块的行索引

        private Timer downTimer = null;   //用于控制下落的定时器

        private bool IsGameOver = false;
        private int Score = 0;

        private bool[,] _displayLabelArr = new bool[COLUMN_COUNT, ROW_COUNT];
        private Color[,] _displayLabelColor = new Color[COLUMN_COUNT, ROW_COUNT];

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            GeneratePreviewBlock();

        }

        /// <summary>
        /// 菜单中开局按扭的响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuBtnStart_Click(object sender, EventArgs e)
        {
            InitialDisplayLabelArr();
            InitialScore();
            CurrentBlock_ColumnIndex = 3;
            CurrentBlock_RowIndex = -3;
            IsGameOver = false;
            GameStart();
            labelDisplay.Invalidate();
            labelPreview.Invalidate();
        }

        private void GameStart()
        {
            BlockPropertyFromPreviewToCurrent();
            GeneratePreviewBlock();
            StartFall();
        }

        private void TryBlockMoveDown()
        {
            var pointBlock = GetCurrentBlockPositionList();
            foreach (Point p in pointBlock)
            {
                bool touched = false;//触碰到了墙or方块
                if (p.Y >= ROW_COUNT - 1)//下移时触底墙
                    touched = true;

                int nextRowIndex = p.Y + 1;
                if (0 <= nextRowIndex && nextRowIndex <= ROW_COUNT - 1 && _displayLabelArr[p.X, nextRowIndex])//下移时碰实块
                {
                    //检查游戏是否结束
                    if (pointBlock.Exists(pb => pb.Y < 0))
                    {
                        downTimer.Stop();
                        IsGameOver = true;
                        labelDisplay.Invalidate();
                        return;
                    }
                    touched = true;
                }

                if (touched)
                {
                    downTimer.Stop();
                    foreach (Point po in pointBlock)
                    {
                        _displayLabelArr[po.X, po.Y] = true;
                        _displayLabelColor[po.X, po.Y] = CurrentBlockColor;
                    }
                    CheckIsExistFullRowAndDestroy(pointBlock);
                    this.textBoxScore.Text = Score.ToString();

                    CurrentBlock_ColumnIndex = 3;
                    CurrentBlock_RowIndex = -3;

                    GameStart();
                    labelDisplay.Invalidate();
                    labelPreview.Invalidate();
                    return;
                }
            }
            CurrentBlock_RowIndex++;
            labelDisplay.Invalidate();
        }

        /// <summary>
        /// 键盘按键响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsGameOver)
                return;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    {
                        var pointBlock = GetCurrentBlockPositionList();
                        foreach (Point p in pointBlock)
                        {
                            if (p.X >= (COLUMN_COUNT - 1))//右移时碰壁
                                return;

                            if (p.Y >= 0 && _displayLabelArr[p.X + 1, p.Y])//右移时碰实块
                                return;
                        }
                        CurrentBlock_ColumnIndex++;
                        labelDisplay.Invalidate();
                        break;
                    }
                case Keys.Left:
                    {
                        var pointBlock = GetCurrentBlockPositionList();
                        foreach (Point p in pointBlock)
                        {
                            if (p.X <= 0)//左移时碰壁
                                return;

                            if (p.Y >= 0 && _displayLabelArr[p.X - 1, p.Y])//左移时碰实块
                                return;
                        }

                        CurrentBlock_ColumnIndex--;
                        labelDisplay.Invalidate();
                        break;
                    }
                case Keys.Down:
                    TryBlockMoveDown();
                    break;
                case Keys.Space:
                    if (RotateBlockOnce())
                        labelDisplay.Invalidate();
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// 预览块的重绘的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            RenderDisplayLabel(PreviewBlockColor, PreviewBlockArray, e.Graphics, 6, 6);
        }

        /// <summary>
        /// 重绘用于显示的Label控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            gp.Clear(Color.Black);
            for (int m = 0; m < 18; m++)
            {
                for (int n = 0; n < 10; n++)
                {
                    if (_displayLabelArr[n, m])
                    {
                        SolidBrush sb = new SolidBrush(_displayLabelColor[n, m]);
                        gp.FillRectangle(sb, n * (BLOCK_SIZE + MARGIN_SIZE) + MARGIN_SIZE, m * (BLOCK_SIZE + MARGIN_SIZE) + MARGIN_SIZE, BLOCK_SIZE, BLOCK_SIZE);
                    }
                }
            }
            if (IsGameOver)
                gp.DrawString("GAME OVER", new Font("宋体", 30), new SolidBrush(Color.White), new PointF(50, 200));

            int currentX = MARGIN_SIZE + CurrentBlock_ColumnIndex * (BLOCK_SIZE + MARGIN_SIZE);
            int currentY = MARGIN_SIZE + CurrentBlock_RowIndex * (BLOCK_SIZE + MARGIN_SIZE);
            RenderDisplayLabel(CurrentBlockColor, CurrentBlockArray, gp, currentX, currentY);
        }


        #region 自定义函数

        private void InitialDisplayLabelArr()
        {
            for (int j = 0; j < 18; j++)
                for (int i = 0; i < 10; i++)
                    _displayLabelArr[i, j] = false;
        }

        private void InitialDisplayLabelColor()
        {
            for (int j = 0; j < 18; j++)
                for (int i = 0; i < 10; i++)
                    _displayLabelColor[i, j] = Color.Black;
        }

        private void InitialScore()
        {
            this.textBoxScore.Text = Score.ToString();
        }

        /// <summary>
        /// 得到一个随机整数
        /// </summary>
        /// <returns></returns>
        private int GetRandom()
        {
            Random rd = new Random();
            return rd.Next();
        }

        /// <summary>
        /// 得到一个随机的块形状
        /// </summary>
        /// <returns></returns>
        private int GetRandomBlockArray()
        {
            return GetRandom() % BLOCKS_DEFINE.Count;
        }

        /// <summary>
        ///得到一种随机的颜色(红、黄、蓝) 
        /// </summary>
        /// <returns></returns>
        private Color GetRandomColor()
        {
            switch (GetRandom() % 3)
            {
                case 0:
                    return Color.Red;
                case 1:
                    return Color.Blue;
                case 2:
                default:
                    return Color.Yellow;
            }
        }

        /// <summary>
        /// 在labelPreview控件上重画一个成形方块，即得到下一个成形方块
        /// </summary>
        private void GeneratePreviewBlock()
        {
            PreviewBlockColor = GetRandomColor();
            previewBlockArrayIndex = GetRandomBlockArray();
        }

        /// <summary>
        /// 把预览窗口中成形方块的属性传递到当前窗口
        /// </summary>
        private void BlockPropertyFromPreviewToCurrent()
        {
            CurrentBlockColor = PreviewBlockColor;
            CurrentBlockArray = PreviewBlockArray.Clone() as bool[,];
        }

        /// <summary>
        /// 初始化当前Label窗口 
        /// </summary>
        private void RenderDisplayLabel(Color cl, bool[,] blockArray, Graphics gp, int x, int y)
        {
            if (blockArray == null)
                return;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (blockArray[j, i])
                    {
                        SolidBrush sb = new SolidBrush(cl);
                        gp.FillRectangle(sb, x + i * (BLOCK_SIZE + MARGIN_SIZE), y + j * (BLOCK_SIZE + MARGIN_SIZE), BLOCK_SIZE, BLOCK_SIZE);
                    }
                }
            }

        }

        /// <summary>
        /// 启动成形方块下落
        /// </summary>
        private void StartFall()
        {
            if (downTimer == null)
            {
                downTimer = new Timer();
                downTimer.Interval = BLOCKDOMNTIME;
                downTimer.Tick += new EventHandler(downTimer_Tick);
            }
            downTimer.Start();
        }

        private void downTimer_Tick(object sender, EventArgs e)
        {
            TryBlockMoveDown();
        }

        #endregion

        /// <summary>
        /// 获取当前块的四个真正显示小格的逻辑位置
        /// </summary>
        /// <returns></returns>
        private List<Point> GetCurrentBlockPositionList()
        {
            var blockArray = CurrentBlockArray;

            var columnIndex = CurrentBlock_ColumnIndex;
            var rowIndex = CurrentBlock_RowIndex;
            List<Point> points = new List<Point>();
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (blockArray[y, x])
                    {
                        points.Add(new Point(x + columnIndex, y + rowIndex));
                    }
                }
            }
            return points;
        }

        /// <summary>
        /// 成形方块旋转一次
        /// </summary>
        private bool RotateBlockOnce()
        {
            bool[,] tempArray = new bool[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    tempArray[i, j] = CurrentBlockArray[j, 3 - i];
                }
            }

            /////// 检测空间是否合适变形
            List<Point> tempPointBlock = new List<Point>();
            tempPointBlock.Clear();
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (tempArray[y, x])
                    {
                        tempPointBlock.Add(new Point(x + CurrentBlock_ColumnIndex, y + CurrentBlock_RowIndex));
                    }
                }
            }
            foreach (Point p in tempPointBlock)
            {
                if (p.Y < 0 || p.X < 0 || p.X > COLUMN_COUNT - 1 || p.Y > ROW_COUNT - 1 || _displayLabelArr[p.X, p.Y])
                {
                    return false;
                }
            }
            ///////////////////////////////

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    CurrentBlockArray[i, j] = tempArray[i, j];
                }
            }
            return true;
        }

        /// <summary>
        /// 检查是否有满行，如果有就清除该行
        /// </summary>
        private void CheckIsExistFullRowAndDestroy(List<Point> pointBlock)
        {
            List<int> Ypos = new List<int>();
            foreach (Point p in pointBlock)
            {
                if (Ypos.Count == 0)
                    Ypos.Add(p.Y);
                int temp = 0;
                for (int i = 0; i < Ypos.Count; i++)
                {
                    if (p.Y == Ypos[i])
                    {
                        break;
                    }
                    else
                    {
                        temp++;
                        if (temp == Ypos.Count)
                        {
                            Ypos.Add(p.Y);
                            temp = 0;
                        }
                    }
                }
            }

            int Count = 0;
            foreach (int ypos in Ypos)
            {
                if (ypos >= 0)
                {
                    Count = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        if (false == _displayLabelArr[i, ypos])
                        {
                            break;
                        }
                        else
                        {
                            Count++;
                            if (Count == 10)
                            {
                                Count = 0;
                                Score = Score + 10;
                                //消除该行，并把上面的依次传递下来
                                bool[,] tempDisplayLabelArr = _displayLabelArr;
                                Color[,] tempDisplayLabelColor = _displayLabelColor;
                                for (int j = ypos - 1; j >= 0; j--)
                                {
                                    for (int k = 0; k < 10; k++)
                                    {
                                        _displayLabelArr[k, j + 1] = tempDisplayLabelArr[k, j];
                                        tempDisplayLabelColor[k, j + 1] = tempDisplayLabelColor[k, j];
                                    }
                                }
                                for (int k = 0; k < 10; k++)
                                {
                                    _displayLabelArr[k, 0] = false;
                                    _displayLabelColor[k, 0] = Color.Black;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MenuBtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}