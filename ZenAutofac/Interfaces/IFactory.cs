namespace ZenAutofac.Interfaces
{
    //generated amount 10

    public interface IFactory<out T>
    {
        T Create();
    }

    public interface IFactory<in TP0, out T>
    {
        T Create(TP0 param0);
    }

    public interface IFactory<in TP0, in TP1, out T>
    {
        T Create(TP0 param0, TP1 param1);
    }

    public interface IFactory<in TP0, in TP1, in TP2, out T>
    {
        T Create(TP0 param0, TP1 param1, TP2 param2);
    }

    public interface IFactory<in TP0, in TP1, in TP2, in TP3, out T>
    {
        T Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3);
    }

    public interface IFactory<in TP0, in TP1, in TP2, in TP3, in TP4, out T>
    {
        T Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4);
    }

    public interface IFactory<in TP0, in TP1, in TP2, in TP3, in TP4, in TP5, out T>
    {
        T Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5);
    }

    public interface IFactory<in TP0, in TP1, in TP2, in TP3, in TP4, in TP5, in TP6, out T>
    {
        T Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6);
    }

    public interface IFactory<in TP0, in TP1, in TP2, in TP3, in TP4, in TP5, in TP6, in TP7, out T>
    {
        T Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7);
    }

    public interface IFactory<in TP0, in TP1, in TP2, in TP3, in TP4, in TP5, in TP6, in TP7, in TP8, out T>
    {
        T Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8);
    }

    public interface IFactory<in TP0, in TP1, in TP2, in TP3, in TP4, in TP5, in TP6, in TP7, in TP8, in TP9, out T>
    {
        T Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8, TP9 param9);
    }

}