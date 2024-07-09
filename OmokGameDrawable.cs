using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace MyMauiApp
{
    internal class OmokGameDrawable : IDrawable
    {
        private readonly OmokRule _omokLogic;

        public OmokGameDrawable(OmokRule omokLogic)
        {
            _omokLogic = omokLogic;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            DrawBoard(canvas);
            DrawStones(canvas);
        }

        private void DrawBoard(ICanvas canvas)
        {
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 1;

            for (int i = 0; i < 19; i++)
            {
                canvas.DrawLine(30, 30 + i * 30, 570, 30 + i * 30);
                canvas.DrawLine(30 + i * 30, 30, 30 + i * 30, 570);
            }
        }

        private void DrawStones(ICanvas canvas)
        {
            for (int x = 0; x < 19; x++)
            {
                for (int y = 0; y < 19; y++)
                {
                    int stone = _omokLogic.GetStone(x, y);
                    if (stone != (int)OmokRule.StoneType.None)
                    {
                        canvas.FillColor = (stone == (int)OmokRule.StoneType.Black) ? Colors.Black : Colors.White;
                        canvas.FillEllipse(15 + x * 30, 15 + y * 30, 30, 30);
                    }
                }
            }
        }
    }
}
