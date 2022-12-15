mermaid
classDiagram

VendingMachine <.. Manager : Dependency
 VendingMachine "*" --> "1" Manager
VendingMachine ..> PowerSource : Dependency
VendingMachine "*" --> "*" PowerSource
Product <.. VendingMachine : Dependency

    class VendingMachine{
    +AddProducts(Product  item)
    +BuyProduct(Product  item)
    +GetPriceOfProduct(string  product)
    +TotalAmountOfProductsBought()
    }
    class Manager{
    +RegisterVendingMachine()
    +GetTotalIncome()
    +GetAllSoldItems()
    +GetMostPopularProduct()
    +GetLeastPopularProduct()
    }
    
    class Product
    Product <|-- Chocolate : Inheritance
    Product <|-- Soda : Inhritance
    Product <|-- Chips : Inheritance
   
   class IPowerSource
   <<interface>> IPowerSource
   IPowerSource<|.. PowerSource : Implements
   IPowerSource : +PowerOn()
   IPowerSource : +SwitchOn()
   IPowerSource : +SwitchOn()
   IPowerSource : +getDescription()
   
   class PowerSource
   <<Abstract>> PowerSource
   PowerSource : -bool isOn
   PowerSource <|-- SolarPower : Inheritance
   PowerSource <|-- WallSocket : Inheritance
   PowerSource <|-- Battery : Inheritance
   class SolarPower{
   +getDescription()
   }
    class WallSocket{
   +getDescription()
   }
    class Battery{
   +getDescription()
   }
   
   







```
