# UnitTestScreen

Тестирование функции Drag and Drop.

Для запуска нужно собрать проект в Visual Studio и запустить тест DroppableTests.DragAndDropTest из среды. 

Также возможен запуск из консоли командой `nunit3-console UnitTestScreen.dll --where "name=DroppableTests"`.

Тест выполняет следующие шаги: 

* Открывает http://way2automation.com/way2auto_jquery/droppable.php

* Перетаскивает элемент в принимающий.

* Убеждается, что текст принимающего элемента изменился.
