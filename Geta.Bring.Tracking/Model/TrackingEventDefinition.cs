using System;

namespace Geta.Bring.Tracking.Model
{
    public class TrackingEventDefinition
    {
        public TrackingEventDefinition(string term, string explanation)
        {
            if (term == null) throw new ArgumentNullException("term");
            if (explanation == null) throw new ArgumentNullException("explanation");
            Explanation = explanation;
            Term = term;
        }

        public string Term { get; private set; }
        public string Explanation { get; private set; }
    }
}