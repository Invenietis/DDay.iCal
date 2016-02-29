using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.iCal
{
    public class PeriodListEvaluator :
        Evaluator
    {
        #region Private Fields

        IPeriodList m_PeriodList;

        #endregion

        #region Constructors

        public PeriodListEvaluator(IPeriodList rdt)
        {
            m_PeriodList = rdt;
        }

        #endregion

        #region Overrides

        public override HashSet<IPeriod> Evaluate(IDateTime referenceDate, DateTime periodStart, DateTime periodEnd, bool includeReferenceDateInResults)
        {
            var periods = new HashSet<IPeriod>();

            if (includeReferenceDateInResults)
            {
                IPeriod p = new Period(referenceDate);
                if (!periods.Contains(p))
                {
                    periods.Add(p);
                }
            }

            if (periodEnd < periodStart)
                return periods;

            periods.UnionWith(m_PeriodList);
            
            return periods;
        }

        #endregion
    }
}
