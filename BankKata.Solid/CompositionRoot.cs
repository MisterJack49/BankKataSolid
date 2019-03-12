using BankKata.Solid.DI;
using BankKata.Solid.Interfaces.Services;
using BankKata.Solid.Services;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace BankKata.Solid
{
    public class CompositionRoot : NinjectModule
    {
        public override void Load()
        {
            bool predicate(Assembly asm) => asm.FullName.StartsWith("BankKata");

            Kernel.Bind(x => x.FromAssembliesInPath(AppDomain.CurrentDomain.BaseDirectory, predicate)
                .SelectAllClasses()
                .BindDefaultInterfaces());

            Kernel.Bind(x => x.FromAssembliesInPath(AppDomain.CurrentDomain.BaseDirectory, predicate)
                .SelectAllInterfaces()
                .Where(c => c.GetCustomAttribute<AbstractFactoryAttribute>() != null)
                .BindToFactory()
                .Configure(y => y.InSingletonScope()));

            Kernel.Rebind<IAccountService>().To<AccountService>().InSingletonScope();
        }

        public IEnumerable<Assembly> GetAssemblies()
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();
            Func<AssemblyName, bool> predicate = (asm) => asm.FullName.StartsWith("BankKata.");

            stack.Push(Assembly.GetEntryAssembly());

            do
            {
                var asm = stack.Pop();

                yield return asm;

                foreach (var reference in asm.GetReferencedAssemblies().Where(predicate))
                    if (!list.Contains(reference.FullName))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }
            }
            while (stack.Count > 0);
        }
    }
}
