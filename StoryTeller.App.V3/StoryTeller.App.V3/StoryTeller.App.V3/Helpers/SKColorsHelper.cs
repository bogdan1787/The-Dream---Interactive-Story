using System;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;

namespace StoryTeller.App.V3.Helpers
{
    public static class SkColorsHelper
    {
        private static SKColor GetColor(string[] colors)
        {
            var red = 120f;
            var blue = 120f;
            var green = 120f;

            var countRed = colors.Count(d => string.Equals(d, "red", StringComparison.InvariantCultureIgnoreCase));
            var countBlue = colors.Count(d => string.Equals(d, "blue", StringComparison.InvariantCultureIgnoreCase));
            var countGreen = colors.Count(d => string.Equals(d, "green", StringComparison.InvariantCultureIgnoreCase));

            red = (countRed == 0 ? 0 : (float)countRed / colors.Length) * red;
            blue = (countBlue == 0 ? 0 : (float)countBlue / colors.Length) * blue;
            green = (countGreen == 0 ? 0 : (float)countGreen / colors.Length) * green;
            var color = new SKColor(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue), Convert.ToByte(160f));
            return color;
        }

        public static List<SKColor> GetBackgroundColors(string[] decisionColors)
        {
            var colors = new List<SKColor>();

            //var colors = new[] { SKColors.Black, SKColors.Gray };

            if (decisionColors == null || decisionColors.Length == 0)
            {
                var color = new SKColor(42, 50, 50);
                colors.AddRange(new[] { color, color });
            }
            else
            {
                var decColor = GetColor(decisionColors);
                colors.AddRange(new[] { decColor, decColor });
            }

            colors.Insert(1, SKColors.Black);
            colors.Insert(1, SKColors.Black);
            colors.Insert(1, SKColors.Black);
            colors.Insert(1, SKColors.Black);
            return colors;
        }

    }
}
