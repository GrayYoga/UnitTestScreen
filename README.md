# UnitTestScreen
Минимальный проект со скриншотами упавших тестов в reportunit. Скриншот вставляется в отчет в виде base64 текста.
Для запуска нужно собрать проект в Visual Studio, затем запустить его через nunit3-console и преобразовать TestResult.xml в TestResult.html при помощи reportunit.

Последовательность команд в консоли для создания и открытия отчета:
```nunit3-console UnitTestScreen.dll & reportunit TestResult.xml & TestResult.html```


