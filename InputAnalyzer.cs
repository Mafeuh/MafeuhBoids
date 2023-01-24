using System;
using System.Collections.Generic;
using System.Text;

namespace MafeuhBoids
{
    public class InputAnalyzer
    {
        private String input;
        public InputAnalyzer(String input)
        {
            this.input = input;
        }

        public void Analyze()
        {
            String[] commandParts = input.ToLower().Replace('\r', ' ').Split(" ");
            switch (commandParts[0])
            {
                case "spawn":
                    break;
                case "team":
                    break;
            }
        }
    }
}
