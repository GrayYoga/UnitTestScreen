# UnitTestScreen
Реализовано автосохранение и повторное использование cookies.
Используется пакет Newtonsoft Json, позволяющий сериализовывать и десериализовывать объекты.

Для запуска нужно собрать проект в Visual Studio и запустить тесты из среды дважды.
Также возможен запуск из консоли командой ```nunit3-console UnitTestScreen.dll --where "name=UnitTestWithScreenshot"```.

При первом запуске произойдет авторизация на сайте при помощи логина и пароля. В папке с тестом будет создан файл courses.way2automation.com, в котором будут сохранены cookies.

При повторном запуске cookies будут прочитаны из файла и ввод логина и пароля не потребуется.

Страницы описаны с применением POM, локаторы переделаны на CSS.
Учтены замечания, сформулированные в открытом письме преподалвателя к слушателям.
