using System;

namespace Geta.Bring.Tracking.Model
{
    /// <summary>
    /// Tracking event definitions.
    /// </summary>
    public class TrackingEventDefinition
    {
        public TrackingEventDefinition(string term, string explanation)
        {
            if (term == null) throw new ArgumentNullException("term");
            if (explanation == null) throw new ArgumentNullException("explanation");
            Explanation = explanation;
            Term = term;
        }

        /// <summary>
        /// Tracking event definition term.
        /// </summary>
        public string Term { get; private set; }

        /// <summary>
        /// Tracking event definition explanation.
        /// </summary>
        public string Explanation { get; private set; }
    }
}