csharp
using ShopSystem;

try
{
    var items = new List<Product?>
    {
        new(10, "Товар A", 25.500),
        new(11, "Товар B", 12.750),
        new(12, "Товар C", 87.300)
    };

    var cart = new Order(items);

    Console.WriteLine("Список доступных товаров:");
    foreach (var item in items)
        Console.WriteLine($"ID: {item!.Id}, Название: {item.Name}, Цена: {item.Price}");

    Console.Write("Введите ID выбранного товара: ");
    var inputId = Console.ReadLine();

    if (!int.TryParse(inputId, out var chosenId))
        Console.WriteLine("Ошибка: нужно ввести число!");

    var chosenProduct = items.FirstOrDefault(x => x!.Id == chosenId);
    cart.AddProduct(chosenProduct);

    Console.WriteLine("Укажите тип клиента для скидки:" +
                      "\n1 - Бронза" +
                      "\n2 - Серебро" +
                      "\n3 - Золото");

    var discountCalc = Console.ReadLine() switch
    {
        "1" => new DiscountCalculate(new BronzeCustomer()),
        "2" => new DiscountCalculate(new SilverCustomer()),
        "3" => new DiscountCalculate(new GoldCustomer()),
        _ => new DiscountCalculate(new BronzeCustomer())
    };

    var finalPrice = discountCalc.CalculateDiscount(cart.TotalPrice);

    Console.WriteLine("Выберите метод оплаты:" +
                      "\n1 - Банковская карта" +
                      "\n2 - Электронный кошелек" +
                      "\n3 - Перевод на счет");

    var paymentHandler = Console.ReadLine() switch
    {
        "1" => new Payment(new CreditCard()),
        "2" => new Payment(new PayPal()),
        "3" => new Payment(new BankTransfer()),
        _ => new Payment(new CreditCard())
    };
    paymentHandler.PaymentMethod(finalPrice);

    Console.WriteLine("Укажите способ доставки:" +
                      "\n1 - Почтовая служба" +
                      "\n2 - Курьерская доставка" +
                      "\n3 - Самовывоз");

    IDelivery deliveryOption = Console.ReadLine() switch
    {
        "1" => new PostDelivery(),
        "2" => new CourierDelivery(),
        "3" => new PickUpPointDelivery(),
        _ => new PostDelivery()
    };
    deliveryOption.DeliveryOrder(cart);

    var notifier = new SmsNotification();
    notifier.SendNotification("Ваш заказ успешно принят!");
}
catch (Exception ex)
{
    Console.WriteLine("Произошла ошибка: " + ex.Message);
    throw;
}



