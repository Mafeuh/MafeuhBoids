using MafeuhBoids.Boids;
using MafeuhBoids.Groups;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MafeuhBoids
{
    public class Simulation
    {
        public static Simulation CurrentSimulation = new Simulation();
        public Point Dimensions
        {
            get => Dimensions;
            set
            {
                if (value.X < 100) value.X = 100;
                if (value.Y < 100) value.Y = 100;
            }
        }
        public float SimSpeed { get; set; } = 0.3f;
        public bool AutoSort { get; set; }
        public float Zoom { get; set; } = 0.5f;
        public long Score { get; set; }
        public bool ShowScore { get; set; }
        public bool ShowSimDetails { get; set; }
        public List<Group> Groups { get; set; }
        public bool TimeFrozen { get; set; }
        public int TotalShipAmount { get
            {
                int result = 0;
                Groups.ForEach(g => result += g.Members.Count);
                return result;
            } 
        }
        public Simulation()
        {
            Dimensions = new Point(500, 500);
            SimSpeed = 10;
            AutoSort = true;
            Zoom = 2;
            Score = 0;
            ShowScore = false;
            ShowSimDetails = false;
            Groups = new List<Group>()
            {
                new Group()
                {
                    Members = new List<Boid>()
                    {
                        new Ship()
                    }
                }
            };
            TimeFrozen = false;
        }
        public void Update()
        {
            foreach(Group g in Groups)
            {
                g.Update();
            }
        }
        public void Draw(SpriteBatch sbatch)
        {
            foreach (Group g in Groups) g.Draw(sbatch);
            if (ShowSimDetails)
            {
                foreach(Group g in Groups)
                {
                    int numEquipe = Groups.IndexOf(g);
                    g.Draw(sbatch);
                    sbatch.DrawString(
                        Game1.Font,
                        $"Equipe n°{numEquipe}: {g.Members.Count}",
                        new Vector2(10, 20 * numEquipe),
                        g.TeamColor);
                }
            }
        }
    }
}
