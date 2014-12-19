using System;

namespace Geta.Bring.Tracking.Model
{
    /// <summary>
    /// Recipient signature.
    /// </summary>
    public class RecipientSignature
    {
        public RecipientSignature(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }

        /// <summary>
        /// Signature name.
        /// </summary>
        public string Name { get; private set; }
    }
}