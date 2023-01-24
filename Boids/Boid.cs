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
        public Vector2 Position { get; set; }
        public Point Dimensions { get; set; }
        public Vector2 DirectionalSpeed { get; set; } = new Vector2();
        public float RotationSpeed { get; set; }
        public float Orientation { get; set; }
        public Group MemberOf { get; set; }

        private static Random rnd = new Random();
        public Boid(Texture2D texture2D, Group memberOf)
        {
            Texture2D = texture2D;
            Position = new Vector2(
                Game1._graphics.PreferredBackBufferWidth * Convert.ToSingle(rnd.NextDouble()),
                Game1._graphics.PreferredBackBufferHeight * Convert.ToSingle(rnd.NextDouble())
                );
            Orientation = Convert.ToSingle(rnd.NextDouble()*Math.PI*2);
            MemberOf = memberOf;
        }
        public Boid(Texture2D texture2D, Group memberOf, Vector2 position, float orientation) : this(texture2D, memberOf)
        {
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
                    Convert.ToInt32(Position.X),
                    Convert.ToInt32(Position.Y),
                    Convert.ToInt32(Dimensions.X / Simulation.CurrentSimulation.Zoom),
                    Convert.ToInt32(Dimensions.Y / Simulation.CurrentSimulation.Zoom)
                    /*
                    JE SAIS PAS NON PLUS COMMENT DIVISER PAR UN NOMBRE PLUS PETIT QUE 1
                    DIMINUE LA TAILLE MAIS JE POSE PAS DE QUESTIONS
                    */
                ), 
                null, 
                MemberOf.GroupColor, 
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
