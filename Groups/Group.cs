using MafeuhBoids.Boids;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MafeuhBoids.Groups
{
    public class Group
    {
        private static Random rnd = new Random();
        public List<Boid> Members { get; set; }
        public Color GroupColor { get; set; } = new Color(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        public bool ShowMembersDetails { get; set; }




        public Group()
        {
            Members = new List<Boid>()
            {
                new Ship(this)
            };
        }
        public virtual void AddBoidToGroup(Boid newBoid)
        {
            newBoid.MemberOf = this;
            Members.Add(newBoid);
        }
        public virtual void Draw(SpriteBatch sbatch)
        {
            foreach (Boid b in Members)
            {
                b.Draw(sbatch);
            }
        }
        public void Update()
        {
            foreach(Boid b in Members)
            {
                b.Update();
                b.Think();
            }
        }
    }
}
