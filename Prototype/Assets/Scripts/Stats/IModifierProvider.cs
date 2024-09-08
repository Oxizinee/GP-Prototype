using System.Collections.Generic;

namespace IMPossible.Stats
{
    public interface IModifierProvider
    {
        public IEnumerable<float> GetAdditiveModifier(Stat stat);
    }
}
