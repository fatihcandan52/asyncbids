using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigortamNet.Data.UnitOfWork;

namespace SigortamNet.Data.Extensions
{
    public static class EfCoreExtensions
    {
        public static bool HasActiveTransaction(this DatabaseFacade databaseFacade)
        {
            return databaseFacade.CurrentTransaction != null;
        }

        public static UowTransaction CreateOrGetCurrentTransaction(this DatabaseFacade databaseFacade)
        {
            return !databaseFacade.HasActiveTransaction()
                ? new UowTransaction(databaseFacade.BeginTransaction(), true)
                : new UowTransaction(databaseFacade.CurrentTransaction, false);
        }

        public static PropertyBuilder<string> TrimBeforeWrite(this PropertyBuilder<string> builder)
        {
            return builder.HasConversion(x => x, x => x.Trim());
        }
    }
}
