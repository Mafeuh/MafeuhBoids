using MafeuhBoids.Groups;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MafeuhBoids.Boids
{
    public abstract class Boid
    {
        private DateTime creationTime = DateTime.Now;
        protected Texture2D Texture2D { get; set; }
        public Point Position { get; set; }
        public Vector2 DirectionalSpeed { get; set; } = new Vector2();
        public float RotationSpeed { get; set; }
        public float Orientation { get; set; }
        public Group MemberOf { get; set; }

        private static Random rnd = new Random();
        public Boid(Texture2D texture2D)
        {
            Texture2D = texture2D;
            Position = new Point(
                Convert.ToInt32(Game1._graphics.PreferredBackBufferWidth * rnd.NextDouble()),
                Convert.ToInt32(Game1._graphics.PreferredBackBufferHeight * rnd.NextDouble())
                );
            Orientation = Convert.ToSingle(rnd.NextDouble()*Math.PI*2);
        }
        public Boid(Texture2D texture2D, Point position, float orientation)
        {
            Texture2D = texture2D;
            Position = position;
            Orientation = orientation;

        }
        public abstract void Think();
        public abstract void Act();
        public abstract void Update();
        public abstract void DrawDetails(SpriteBatch sbatch);
        public virtual void Draw(SpriteBatch sbatch)
        {
            sbatch.Draw(
                Texture2D,
                new Rectangle(
                    Position,
                    new Point(
                        Convert.ToInt32(Texture2D.Width * Simulation.CurrentSimulation.Zoom),
                        Convert.ToInt32(Texture2D.Height * Simulation.CurrentSimulation.Zoom)
                    )
                ), 
                null, 
                Color.White, 
                Orientation, 
                new Vector2(
                    Texture2D.Width / 2, 
                    Texture2D.Height / 2
                ), 
                SpriteEffects.None, 
                1f);
        }
    }
}
