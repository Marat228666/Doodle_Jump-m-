using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp10.classes;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        Player player;
        public Form1()
        {
            InitializeComponent();
            Init();
            timer1.Start();

        }
        private void Init()
        {
            PlatformController.platforms = new List<Platform>();
            PlatformController.AddPlatform(new PointF(100, 400));
            PlatformController.startPlatformPosY = 400;
            PlatformController.score = 0;
            PlatformController.GenerateStartSequence();

            player = new Player();
        }

        private void Update(object sender, EventArgs e)
        {
            this.Text = "Doodle Jump: Score - " + PlatformController.score;

            if (player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 200)
            {
                Init();
            }
            player.physics.CalculatePhysics();
            FollowPlayer();

            Invalidate();
        }

        private void FollowPlayer()
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.position.Y += offset;
            }
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player.physics.dx = 6;
                    break;
                case "Left":
                    player.physics.dx = -6;
                    break;
            }
        }
        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0;
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            if (PlatformController.platforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                    PlatformController.platforms[i].DrawSprite(e.Graphics);
            }
            player.DrawSprite(e.Graphics);
        }
    }
}
