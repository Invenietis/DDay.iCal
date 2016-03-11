using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DDay.iCal
{
    public class TimeZoneInfoEvaluator :
        RecurringEvaluator
    {
        #region Protected Properties

        protected ITimeZoneInfo TimeZoneInfo
        {
            get { return Recurrable as ITimeZoneInfo; }
            set { Recurrable = value; }
        }

        #endregion

        #region Constructors

        public TimeZoneInfoEvaluator(ITimeZoneInfo tzi) : base(tzi)
        {
        }

        #endregion       
 
        #region Overrides

        public override HashSet<IPeriod> Evaluate(IDateTime referenceDate, DateTime periodStart, DateTime periodEnd, bool includeReferenceDateInResults)
        {
            // Time zones must include an effective start date/time
            // and must provide an evaluator.
            if (TimeZoneInfo != null)
            {
                // Always include the reference date in the results
                return base.Evaluate(referenceDate, periodStart, periodEnd, true);
            }

            return new HashSet<IPeriod>();            
        }

        #endregion
    }
}
