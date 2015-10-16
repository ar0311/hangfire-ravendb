﻿using Hangfire.States;
using Hangfire.Storage;

namespace Hangfire.Raven.StateHandlers
{
    public class SucceededStateHandler : IStateHandler
    {
        public void Apply(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            transaction.InsertToList("succeeded", context.JobId);
            transaction.TrimList("succeeded", 0, 99);
        }

        public void Unapply(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            transaction.RemoveFromList("succeeded", context.JobId);
        }

        public string StateName
        {
            get { return SucceededState.StateName; }
        }
    }
}
