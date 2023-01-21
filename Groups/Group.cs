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
        public List<Boid> Members { get; set; }
        public Color TeamColor { get; set; }
        public bool ShowMembersDetails { get; set; }
        public virtual void AddBoidToGroup(Boid newBoid)
        {
            newBoid.MemberOf = this;
            Members.Add(newBoid);
        }
        public virtual void Draw(SpriteBatch sbatch)
        {
            foreach(Boid b in Members)
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
