using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryTeller.Core.Model
{
    public class DecisionsTaken
    {
        private SortedDictionary<int, char> DecisionsTakenField { get; set; }

        public DecisionsTaken()
        {
            DecisionsTakenField = new SortedDictionary<int, char>();
        }

        public DecisionsTaken(char[] decisions) : this()
        {
            var i = 1;
            foreach (var decision in decisions)
            {
                Add(i, decision);
                i++;
            }
        }

        public void Add(int chapter, char decision)
        {
            if (!DecisionsTakenField.ContainsKey(chapter))
                DecisionsTakenField.Add(chapter, decision);
        }

        public char Get(int chapter)
        {
            if (!DecisionsTakenField.TryGetValue(chapter, out var decision))
                decision = Char.MaxValue;
            return decision;
        }

        public int DecisionsMade => DecisionsTakenField.Count;
        public char[] Decisions => DecisionsTakenField.Values.ToArray();

        public string DecisionsAsString =>
            string.Join(",", DecisionsTakenField.Select(d => $"{d.Key}-{d.Value}").ToArray());

        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            var d = obj as DecisionsTaken;

            if (DecisionsMade != d.DecisionsMade)
                return false;

            for (var i = 0; i < DecisionsMade; i++)
            {
                if (Decisions[i] != d.Decisions[i])
                {
                    return false;
                }
            }

            return true;
        }
        public override int GetHashCode()
        {
            return string.Join(",", Decisions).GetHashCode();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var decision in DecisionsTakenField)
            {
                stringBuilder.AppendLine($"{decision.Key},{decision.Value}");
            }

            return stringBuilder.ToString();
        }

        public static DecisionsTaken Load(string text)
        {
            var decisionsTaken = new DecisionsTaken();
            if (!string.IsNullOrWhiteSpace(text))
            {
                foreach (var line in text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var split = line.Split(',');
                        if (split.Length == 2)
                        {
                            decisionsTaken.Add(int.Parse(split[0]), split[1][0]);
                        }
                    }
                }
            }

            return decisionsTaken;
        }
    }
}
