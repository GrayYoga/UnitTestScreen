# UnitTestScreen
Тестирование заполнения текста в Alert. 
Для запуска нужно собрать проект в Visual Studio и запустить тест DroppableTests.AlertsTests из среды. 
Также возможен запуск из консоли командой `nunit3-console UnitTestScreen.dll --where "name=AlertsTests"`.

В решении реализован один тест:

* Открывает http://way2automation.com/way2auto_jquery/frames-and-windows.php
* Нажимает Input Alert
* Нажимает кнопку, вводит текст
* Проверяет, что текст в окне содержит введенное значение
