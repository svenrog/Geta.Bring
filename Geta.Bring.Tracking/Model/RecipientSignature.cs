using System;

namespace Geta.Bring.Tracking.Model
{
    public class RecipientSignature
    {
        public RecipientSignature(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }

        public string Name { get; private set; }
    }
}