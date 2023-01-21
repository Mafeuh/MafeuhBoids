using MafeuhBoids.Groups;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MafeuhBoids.Boids
{
    class Ship : Boid
    {
        private Point LeftCaptor { get =>   Position + new Point(Convert.ToInt32(Math.Sin(Orientation - Math.PI / 4) * 50), -Convert.ToInt32(Math.Cos(Orientation - Math.PI / 10) * 50)); }
        private Point FrontCaptor { get =>  Position + new Point(Convert.ToInt32(Math.Sin(Orientation) * 50), Convert.ToInt32(-Math.Cos(Orientation) * 50)); }
        private Point RightCaptor { get =>  Position + new Point(Convert.ToInt32(Math.Sin(Orientation + Math.PI / 4) * 50), Convert.ToInt32(-Math.Cos(Orientation + Math.PI / 10) * 50)); }
            
        public static Texture2D ShipTexture;
        public Ship() : base(ShipTexture)
        {
            Dimensions = new Point(40, 70);
        }
        public Ship(Point position, float orientation) : base(ShipTexture, position, orientation)
        {

        }
        public override void Act()
        {
            if (!Simulation.CurrentSimulation.TimeFrozen)
            {
                DirectionalSpeed += new Vector2
                    (
                        Convert.ToInt32(Math.Sin(Orientation)),
                        -Convert.ToInt32(Math.Cos(Orientation))
                    );
            }
        }
        public override void Think()
        {
            Act();
        }
        public override void Update()
        {
            RotationSpeed *= 0.9f;

            DirectionalSpeed *= 0.9f;

            Position += DirectionalSpeed.ToPoint();
            Orientation += RotationSpeed;
        }

        public void TurnRight() => RotationSpeed += 2f;
        public void TurnLeft() => RotationSpeed -= 2f;

        public override void Draw(SpriteBatch sbatch)
        {
            base.Draw(sbatch);

            sbatch.Draw(Game1.Texture1Pixel, new Rectangle(LeftCaptor, new Point(4, 4)), Color.Red);
            sbatch.Draw(Game1.Texture1Pixel, new Rectangle(RightCaptor, new Point(4, 4)), Color.Red);
            sbatch.Draw(Game1.Texture1Pixel, new Rectangle(FrontCaptor, new Point(4, 4)), Color.Red);

            DrawDetails(sbatch);
        }

        public override void DrawDetails(SpriteBatch sbatch)
        {
            sbatch.DrawString(Game1.Font, $"Position: {Position}", Position.ToVector2() - new Vector2(5, 50), Color.Black);
            sbatch.DrawString(Game1.Font, $"Speed: {DirectionalSpeed}", Position.ToVector2() - new Vector2(5, 40), Color.Black);
        }
    }
}
