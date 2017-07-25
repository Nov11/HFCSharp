using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Hound
    {
        public int startPosition;
        public int trackLength;
        public PictureBox box;
        public int location;
        public Random random;

        public bool run()
        {
            location += random.Next(1, 20);
            box.Left = startPosition + location;
            return location >= trackLength;
        }

        public void prepare()
        {
            location = 0;
            box.Left = startPosition;
        }
    }
}
