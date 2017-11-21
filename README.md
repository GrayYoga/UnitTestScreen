# UnitTestScreen

Тестирование функции Drag and Drop 2 - сортировка. 

Для запуска нужно собрать проект в Visual Studio и запустить тест DroppableTests.SortableTests из среды. 

Также возможен запуск из консоли командой `nunit3-console UnitTestScreen.dll --where "name=SortableTests"`.

Тест выполняет следующие шаги: 

* Открывает http://way2automation.com/way2auto_jquery/sortable.php

* Проверяет прямой порядок сортировки.

* Меняет параметр сортировки списка элементов.

* Проверяет обратный порядок сортировки.
