using System.Web.Mvc;
using MySingingBird.Core.Map;
using StructureMap;

namespace MySingingBird.Startup
{
    public static class Bootstrapper
    {
        public static void InitializeStructureMap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new Startup.MySingingBirdRegistry()));
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        public static void InitializeAutoMapper()
        {
            var mapper = ObjectFactory.GetInstance<IAutoMapperTask>();
            mapper.Execute();
        }
    }
}