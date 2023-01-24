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
        private Vector2 LeftCaptor { get =>   Position + new Vector2(Convert.ToSingle(Math.Sin(Orientation - Math.PI / 4) * 50),   -Convert.ToSingle(Math.Cos(Orientation - Math.PI / 10) * 50)); }
        private Vector2 FrontCaptor { get =>  Position + new Vector2(Convert.ToSingle(Math.Sin(Orientation) * 50),                  Convert.ToSingle(-Math.Cos(Orientation) * 50)); }
        private Vector2 RightCaptor { get =>  Position + new Vector2(Convert.ToSingle(Math.Sin(Orientation + Math.PI / 4) * 50),    Convert.ToSingle(-Math.Cos(Orientation + Math.PI / 10) * 50)); }
            
        public static Texture2D ShipTexture;
        public Ship(Group memberOf) : base(ShipTexture, memberOf)
        {
            Dimensions = new Point(40, 70);
        }
        public Ship(Vector2 position, float orientation, Group memberOf) : base(ShipTexture, memberOf, position, orientation)
        {

        }
        public override void Act()
        {
            if (!Simulation.CurrentSimulation.TimeFrozen)
            {
                DirectionalSpeed += new Vector2
                    (
                        Convert.ToSingle(Math.Sin(Orientation)),
                        -Convert.ToSingle(Math.Cos(Orientation))
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

            Position += DirectionalSpeed;
            Orientation += RotationSpeed;
        }

        public void TurnRight() => RotationSpeed += 2f;
        public void TurnLeft() => RotationSpeed -= 2f;

        public override void Draw(SpriteBatch sbatch)
        {
            base.Draw(sbatch);

            sbatch.Draw(Game1.Texture1Pixel, new Rectangle(LeftCaptor.ToPoint(), new Point(4, 4)), Color.Red);
            sbatch.Draw(Game1.Texture1Pixel, new Rectangle(RightCaptor.ToPoint(), new Point(4, 4)), Color.Red);
            sbatch.Draw(Game1.Texture1Pixel, new Rectangle(FrontCaptor.ToPoint(), new Point(4, 4)), Color.Red);

            DrawDetails(sbatch);
        }

        public override void DrawDetails(SpriteBatch sbatch)
        {
            sbatch.DrawString(Game1.Font, $"Position: {Position}", Position - new Vector2(5, 50), Color.Black);
            sbatch.DrawString(Game1.Font, $"Speed: {DirectionalSpeed}", Position - new Vector2(5, 40), Color.Black);
        }
    }
}
