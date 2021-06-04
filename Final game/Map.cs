using System.Collections.Generic;
using System.Drawing;

namespace Final_game
{
    public class Map
    {
        public List<Environment> Boundaries_1,
                                 Boundaries_2,
                                 Boundaries_3,
                                 Boundaries_4,
                                 Doors;

        private readonly Image Door = Images.door,
                               Wall = Images.wall;

        public Map()
        {
            Boundaries_1 = new List<Environment>();
            Boundaries_2 = new List<Environment>();
            Boundaries_3 = new List<Environment>();
            Boundaries_4 = new List<Environment>();
            Doors = new List<Environment>();
            MakeMap();
        }

        private void MakeMap()
        {
            var door1_1 = new Environment(20, 17, 37, 45, Door);
            var door1_2 = new Environment(128, 125, 37, 45, Door);
            var door2_1 = new Environment(134, 181, 37, 45, Door);
            var door2_2 = new Environment(136, 322, 37, 45, Door);
            var door3_1 = new Environment(180, 280, 37, 45, Door);
            var door3_2 = new Environment(596, 256, 37, 45, Door);
            var door4_1 = new Environment(668, 190, 37, 45, Door);
            var door4_2 = new Environment(913, 17, 37, 45, Door);

            Doors.Add(door1_1);
            Doors.Add(door1_2);
            Doors.Add(door2_1);
            Doors.Add(door2_2);
            Doors.Add(door3_1);
            Doors.Add(door3_2);
            Doors.Add(door4_1);
            Doors.Add(door4_2);


            var wallN = new Environment(0, 0, 985, 15, Wall);
            var wallW = new Environment(0, 0, 25, 425, Wall);
            var wallE = new Environment(947, 0, 25, 425, Wall);
            var wallS = new Environment(0, 368, 985, 15, Wall);
            var wall1_1 = new Environment(196, 0, 10, 150, Wall);
            var wall1_2 = new Environment(162, 130, 10, 50, Wall);
            var wall2_1 = new Environment(171, 146, 15, 250, Wall);
            var wall2_2 = new Environment(27, 335, 61, 70, Wall);
            var wall2_3 = new Environment(112, 366, 85, 15, Wall);
            var wall3_1 = new Environment(175, 235, 245, 41, Wall);
            var wall3_2 = new Environment(304, 330, 39, 60, Wall);
            var wall3_3 = new Environment(415, 235, 280, 13, Wall);
            var wall3_4 = new Environment(530, 245, 69, 37, Wall);
            var wall3_5 = new Environment(640, 250, 100, 13, Wall);
            var wall3_6 = new Environment(730, 249, 15, 120, Wall);
            var wall4_1 = new Environment(650, 234, 290, 7, Wall);
            var wall4_2 = new Environment(660, 0, 12, 370, Wall);
            var wall4_3 = new Environment(910, 203, 90, 50, Wall);
            var wall4_4 = new Environment(803, 170, 28, 70, Wall);

            var block1_1 = new Environment(25, 62, 100, 10, Wall);
            var block1_2 = new Environment(72, 113, 136, 10, Wall);
            var block1_3 = new Environment(20, 171, 159, 6, Wall);
            var block2_1 = new Environment(86, 227, 100, 10, Wall);
            var block2_2 = new Environment(113, 298, 70, 1, Wall); 
            var block3_1 = new Environment(180, 325, 62, 1, Wall);
            var block3_2 = new Environment(385, 322, 76, 1, Wall);
            var block3_3 = new Environment(482, 296, 116, 1, Wall);
            var block3_4 = new Environment(590, 305, 80, 1, Wall);
            var block3_5 = new Environment(706, 327, 50, 1, Wall);
            var block4_1 = new Environment(670, 185, 75, 1, Wall);
            var block4_2 = new Environment(860, 186, 25, 1, Wall);
            var block4_3 = new Environment(670, 128, 32, 1, Wall);
            var block4_4 = new Environment(743, 145, 29, 1, Wall);
            var block4_5 = new Environment(800, 123, 29, 1, Wall);
            var block4_6 = new Environment(812, 81, 25, 1, Wall);
            var block4_7 = new Environment(857, 62, 100, 7, Wall);

            Boundaries_1.Add(wallN);
            Boundaries_1.Add(wallW);
            Boundaries_1.Add(wall1_1);
            Boundaries_1.Add(wall1_2);
            Boundaries_2.Add(wallW);
            Boundaries_2.Add(wallS);
            Boundaries_2.Add(block1_3);
            Boundaries_2.Add(wall2_1);
            Boundaries_2.Add(wall2_2);
            Boundaries_2.Add(wall2_3);
            Boundaries_3.Add(wallS);
            Boundaries_3.Add(wall2_1);
            Boundaries_3.Add(wall3_1);
            Boundaries_3.Add(wall3_2);
            Boundaries_3.Add(wall3_3);
            Boundaries_3.Add(wall3_4);
            Boundaries_3.Add(wall3_5);
            Boundaries_3.Add(wall3_6);
            Boundaries_4.Add(wallN);
            Boundaries_4.Add(wallE);
            Boundaries_4.Add(wall4_1);
            Boundaries_4.Add(wall4_2);
            Boundaries_4.Add(wall4_3);
            Boundaries_4.Add(wall4_4);

            Boundaries_1.Add(block1_1);
            Boundaries_1.Add(block1_2);
            Boundaries_1.Add(block1_3);
            Boundaries_2.Add(block2_1);
            Boundaries_2.Add(block2_2);
            Boundaries_3.Add(block3_1);
            Boundaries_3.Add(block3_2);
            Boundaries_3.Add(block3_3);
            Boundaries_3.Add(block3_4);
            Boundaries_3.Add(block3_5);
            Boundaries_4.Add(block4_1);
            Boundaries_4.Add(block4_2);
            Boundaries_4.Add(block4_3);
            Boundaries_4.Add(block4_4);
            Boundaries_4.Add(block4_5);
            Boundaries_4.Add(block4_6);
            Boundaries_4.Add(block4_7);
        }
    }
}
