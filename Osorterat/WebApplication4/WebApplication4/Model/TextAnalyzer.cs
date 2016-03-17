using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Model
{
    public class TextAnalyzer
    {
        public int GetNumberOfCapitals(string text)
        {
            int capitals = 0;

            foreach (char c in text)
            {
                if (char.IsUpper(c))
                {
                    capitals++;
                }
            }

            return capitals;
        }
    }
}