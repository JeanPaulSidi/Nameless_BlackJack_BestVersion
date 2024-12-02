using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless_BlackJack
{
    public class Card
    {
        private int _pointvalue;
        private Image _image;

        public Card(int PointValue, Image Image) 
        {
            _pointvalue = PointValue;
            _image = Image;
        }

        public int PointValue 
        {
            get { return _pointvalue; }
            set { _pointvalue = value; }
        }

        public Image Image 
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
