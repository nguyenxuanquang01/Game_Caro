using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class PlayerHistory
    {
        private Point point;

        private int curentIndex;

        public Point Point { get => point; set => point = value; }
        public int CurentIndex { get => curentIndex; set => curentIndex = value; }

        public PlayerHistory(Point point, int cunrentIndex) 
        {
            this.Point = point;
            this.CurentIndex = cunrentIndex;
        }
    }
}
