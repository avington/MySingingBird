using AutoMapper;

namespace MySingingBird.Core.Map
{
    public class AutoMapperTask : IAutoMapperTask
    {
        public void Execute()
        {
            Initialize();
        }

        public static void Initialize()
        {
            Mapper.Initialize(x => x.AddProfile<SearchRequestProfile>());
            Mapper.Initialize(x => x.AddProfile<SearchResponseProfile>());

        }
    }
}