using AutoMapper;
using AutoMapper.Internal;

namespace CashMinder.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> TypePairs { get => typePairs; set => typePairs = value; }


        private IMapper mapperContainer;

        private static List<TypePair> typePairs = new();


        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(ignore: ignore);
            return mapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            Config<IList<TDestination>, TSource>(ignore: ignore);
            return mapperContainer.Map< IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            Config<TDestination, object>(ignore: ignore);
            return mapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {

            Config<IList<TDestination>, object>(ignore: ignore);
            return mapperContainer.Map<IList<TDestination>>(source);
        }

        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TDestination), typeof(TSource));
            if (typePairs.Contains(typePair) && ignore == null)
            {
                return;
            }

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                typePairs.ForEach(item =>
                {
                    if (ignore != null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore,  x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();


                });

            });

            mapperContainer = config.CreateMapper();
        }
    }
}
