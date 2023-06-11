using CarRental.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CarRental.Core.Aspects.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {

        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    if (invocation.ReturnValue is Task returnValueTask)
                    {
                        returnValueTask.GetAwaiter().GetResult();
                    }
                    if (invocation.ReturnValue is Task task && task.Exception != null)
                    {
                        throw task.Exception;
                    }
                    transactionScope.Complete();

                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw ;
                }
            }

            base.Intercept(invocation);
        }
    }
}
