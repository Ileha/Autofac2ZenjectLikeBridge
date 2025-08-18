using Autofac2ZenjectLikeBridge.Interfaces;

namespace Autofac2ZenjectLikeBridge
{
    public class PlaceholderFactory<TInstance> : IFactory<TInstance>
    {
        internal IFactory<TInstance> Nested { get; init; }

        public virtual TInstance Create()
        {
            return Nested.Create();
        }
    }

    public class PlaceholderFactory<P0, TInstance> : IFactory<P0, TInstance>
    {
        internal IFactory<P0, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0)
        {
            return Nested.Create(param0);
        }
    }

    public class PlaceholderFactory<P0, P1, TInstance> : IFactory<P0, P1, TInstance>
    {
        internal IFactory<P0, P1, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1)
        {
            return Nested.Create(param0, param1);
        }
    }

    public class PlaceholderFactory<P0, P1, P2, TInstance> : IFactory<P0, P1, P2, TInstance>
    {
        internal IFactory<P0, P1, P2, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1, P2 param2)
        {
            return Nested.Create(param0, param1, param2);
        }
    }

    public class PlaceholderFactory<P0, P1, P2, P3, TInstance> : IFactory<P0, P1, P2, P3, TInstance>
    {
        internal IFactory<P0, P1, P2, P3, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3)
        {
            return Nested.Create(param0, param1, param2, param3);
        }
    }

    public class PlaceholderFactory<P0, P1, P2, P3, P4, TInstance> : IFactory<P0, P1, P2, P3, P4, TInstance>
    {
        internal IFactory<P0, P1, P2, P3, P4, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4)
        {
            return Nested.Create(param0, param1, param2, param3, param4);
        }
    }

    public class PlaceholderFactory<P0, P1, P2, P3, P4, P5, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, TInstance>
    {
        internal IFactory<P0, P1, P2, P3, P4, P5, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5)
        {
            return Nested.Create(param0, param1, param2, param3, param4, param5);
        }
    }

    public class PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>
    {
        internal IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6)
        {
            return Nested.Create(param0, param1, param2, param3, param4, param5, param6);
        }
    }

    public class PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>
    {
        internal IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7)
        {
            return Nested.Create(param0, param1, param2, param3, param4, param5, param6, param7);
        }
    }

    public class PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>
    {
        internal IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7, P8 param8)
        {
            return Nested.Create(param0, param1, param2, param3, param4, param5, param6, param7, param8);
        }
    }

    public class PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>
    {
        internal IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> Nested { get; init; }

        public virtual TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7, P8 param8, P9 param9)
        {
            return Nested.Create(param0, param1, param2, param3, param4, param5, param6, param7, param8, param9);
        }
    }

}
