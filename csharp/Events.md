# Events

events are special delegates that are used to execute multiple subscribing method on fired.

---

## Define an event

to define an event we first have to define the handler's delegate type:

```csharp
public delegate void StockEventFired(string name, double price);
```

then inside our class, define the event as a member:

```csharp
public class Stock
{
  //event declaration
  public event StockEventFired? OnPriceChanged;

  private string _name = "";
  private double _price;

  public string Name 
  { 
    get { return _name; } 
    set { _name = value; } 
  }
  public double Price 
  { 
    get => _price;
    set 
    { 
      if(_price != value)
      {
        _price = value;
        
      }
    } 
  }
}
```

our goal is to fire this event on price change, for this we check if the **event is not null**, then call the event and pass it the data as if it were a method:

```csharp 
 
if(_price != value)
{
  _price = value;
  //trigger event when price changes
  if(OnPriceChanged != null) OnPriceChanged(this.Name, this.Price);
}
```

---

## Subscribing and unsubscribing

other methods can subscribe/unsubscribe to an event trigger by using `+=` and `-=` for example:

```csharp
Stock stock = new Stock { Name = "MSFT", Price = 100.00 };
//subscribe to event using delegate handler
StockEventFired sef = (name, price) => System.Console.WriteLine("Changed");
stock.OnPriceChanged += sef;
//un-subscribe from event
stock.OnPriceChanged -= sef;
```
