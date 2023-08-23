

//Abstract Factory: Podría utilizarse para crear diferentes tipos de repartidores (drones, bicicletas, etc.) según las necesidades del cliente.
//Observer: Podría aplicarse para notificar a otros componentes del sistema cuando se realicen cambios en las entidades de PedidosYa Blue.
//Iterator: Podría utilizarse para recorrer y manipular una lista de entidades en el ABM (Alta, Baja y Modificación) de PedidosYa Blue.



Abstract Factory:

csharp
public interface IRepartidorFactory
{
    IRepartidor CrearRepartidor();
}

public class DronFactory : IRepartidorFactory
{
    public IRepartidor CrearRepartidor()
    {
        return new DronRepartidor();
    }
}

public interface IRepartidor
{
    void EntregarPedido();
}

public class DronRepartidor : IRepartidor
{
    public void EntregarPedido()
    {
        Console.WriteLine("Entrega de pedido con dron");
    }
}

// Uso del patrón Abstract Factory
IRepartidorFactory fabrica = new DronFactory();
IRepartidor repartidor = fabrica.CrearRepartidor();
repartidor.EntregarPedido();
//Observer:

csharp
public interface IEntidadObserver
{
    void Actualizar(Entidad entidad);
}

public class EntidadObservable
{
    private List<IEntidadObserver> observers = new List<IEntidadObserver>();

    public void AgregarObserver(IEntidadObserver observer)
    {
        observers.Add(observer);
    }

    public void EliminarObserver(IEntidadObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotificarObservers(Entidad entidad)
    {
        foreach (var observer in observers)
        {
            observer.Actualizar(entidad);
        }
    }
}

public class EntidadObserver : IEntidadObserver
{
    public void Actualizar(Entidad entidad)
    {
        // Lógica para manejar la actualización de la entidad observada
        Console.WriteLine("Entidad actualizada: " + entidad.Nombre);
    }
}

// Uso del patrón Observer
var observable = new EntidadObservable();
var observer = new EntidadObserver();

observable.AgregarObserver(observer);
observable.NotificarObservers(entidadActualizada);
observable.EliminarObserver(observer);


//Iterator:

csharp
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

public class EntidadesIterator : IIterator<Entidad>
{
    private List<Entidad> entidades;
    private int index;

    public EntidadesIterator(List<Entidad> entidades)
    {
        this.entidades = entidades;
        index = 0;
    }

    public bool HasNext()
    {
        return index < entidades.Count;
    }

    public Entidad Next()
    {
        return entidades[index++];
    }
}

// Uso del patrón Iterator
var entidades = new List<Entidad>();
entidades.Add(new Entidad("Entidad 1"));
entidades.Add(new Entidad("Entidad 2"));

var iterator = new EntidadesIterator(entidades);
while (iterator.HasNext())
{
    var entidad = iterator.Next();
    Console.WriteLine(entidad.Nombre);
}
