using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AutomapperUnityInterceptionTest
{
    public class TestInterceptorBehavior: IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            string method = input.MethodBase.Name;
            Console.WriteLine(String.Format("Inside Test Interceptor. About to call method '{0}'", method));
            var result = getNext()(input, getNext);
            Console.WriteLine(String.Format("Exiting Test Interceptor. Returned from wrapped call to '{0}'", method));
            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; } 

        }
    }
}
