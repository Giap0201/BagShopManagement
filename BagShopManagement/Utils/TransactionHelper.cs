// Utils/TransactionHelper.cs
using System;
using System.Transactions;

namespace BagShopManagement.Utils
{
    /// <summary>
    /// Helper để chạy nhiều thao tác DB trong cùng 1 transaction scope.
    /// </summary>
    public static class TransactionHelper
    {
        public static void RunInTransaction(Action action)
        {
            using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TransactionManager.DefaultTimeout
                },
                TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    action();
                    scope.Complete();
                }
                catch
                {
                    // TransactionScope sẽ tự rollback khi không gọi Complete()
                    throw;
                }
            }
        }
    }
}
