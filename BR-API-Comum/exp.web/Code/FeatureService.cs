using System.Collections.Generic;
using System.Linq;
using exp.dados;

namespace exp.web.Code
{
    public static class FeatureService
    {
        public static void SortList(ICollection<homecoluna> features, IList<int> modifiedOrder,
            IList<int> originalPositions)
        {
            for (var i = 0; i < features.Count; i++)
            {
                var feature = features.FirstOrDefault(h => h.id == modifiedOrder[i]);
                feature.ordem = originalPositions[i];
            }
        }
    }
}