# UnitTestScreen
Тестирование создания новой вкладки по ссылке. 
Для запуска нужно собрать проект в Visual Studio и запустить тест DroppableTests.FramesAndWindowsTests из среды. 
Также возможен запуск из консоли командой `nunit3-console UnitTestScreen.dll --where "name=FramesAndWindowsTests"`.

В решении реализованы два теста:

#### Тест NewBrowserTabTest
* Открывает http://way2automation.com/way2auto_jquery/frames-and-windows.php
* Нажимает на ссылку
* Переносит фокус на новую вкладку, нажимает ссылку
* Проверяет, что открылась третья вкладка


#### Тест NewMultiplewindowsTest 
* Открывает http://way2automation.com/way2auto_jquery/frames-and-windows.php
* Открывает Open Multiple Windows
* Нажимает на ссылку
* Переносит фокус на новое окно, нажимает ссылку
* Проверяет, что открылось новое окно
