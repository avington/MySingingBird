using StructureMap.Configuration.DSL;

namespace MySingingBird.Startup
{
    public class MySingingBirdRegistry   : Registry
    {
        public MySingingBirdRegistry()
        {
            Scan(assemblyScanner =>
                     {
                         assemblyScanner.TheCallingAssembly();
                         assemblyScanner.Assembly("MySingingBird.Core");
                         assemblyScanner.WithDefaultConventions();
                     });

            
        }
    }
}