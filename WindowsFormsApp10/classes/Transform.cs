﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.classes
{
    public class Transform
    {
        public PointF position;
        public Size size;
        public Transform(PointF position, Size size)
        {
            this.position = position;
            this.size = size;
            
        }
    }
}
