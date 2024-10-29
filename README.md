# Delivery Winform
Запуск программы осуществляется после компиляции в VS по пути \Delivery Winform\bin\Release\net8.0-windows\Delivery Winform.exe
При запуске программы Delivery доступно пять полей для ввода
Weight - ввод ограничен числами 1-100
CityDistrict - ввод ограничен числами от 100 до 1000, кратные 100
DeliveryDate - ввод ограничен под формат даты yyyy-MM-dd HH:mm:ss
FirstDeliveryDate - ввод ограничен так же как и у DeliveryDate
После корректного заполнения первые трех полей и нажатия на кнопку "Добавить заказ" данные заполняются в таблицу Orders.
Чтобы воспользоваться кнопкой "Удалить заказ" необходимо выделить все 4 столбца в DataGridView,
иначе вылетит исключение. Данная кнопка удалит заказ из таблицы Orders.
Для фильтрации заказов по району и дате необходимо заполнить данные поля CityDistrict и FirstDeliveryDate.
Фильтрация происходит сразу по двум параметрам - району и дате в интервале (введенная дата - введенная дата + полчаса).
Результирующие данные фильтрации записываются в таблицу Results.
Кнопка "Вывести таблицу заказов" - выводит данные из таблицы Orders.
Логи записываются по пути \Delivery Winform\bin\Debug\net8.0-windows\_deliveryLog
Для работы с базой использованы пакеты Microsoft.EntityFrameworkCore.SqlServer и 
Microsoft.EntityFrameworkCore.Tools
При первом запуске программы база создастся сама и заполниться начальными данными.
