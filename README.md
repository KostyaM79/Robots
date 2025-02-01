# Имитация движения роботов, как в игре Nether Earth для ZX-Spectrum

Инструменты: MS Visual Studio 2019 Professional.

Стек технологий: .NET 5.0, VinForm.

Разработчик: Константин Махнутин.

## Описание.
Программа создаёт поле идентичное игровому полю игры Nether Earth. В правом верхнем углу интерфейса имеется три кнопки: "<<", ">>" и "Создать робота".
Кнопки со стрелками позволяют двигать поле вправо и влево, кнопка "Создать робота" соответственно создаёт робота. Созданный робот выходит из первой базы,
расположенной в левом краю поля. Оригинальная игра начинается именно с неё. Все постройки обозначены красными блоками на экране. Роботы - синие квадраты.
Задача состояла в том, чтобы максимально приблизить движение роботов к оригинальной игре, что и было выполнено. Роботы двигаются хаотично, на первый взгляд.
Однако вправо они двигаются немного чаще и дальше, чем в других направлениях. Встречая на пути препятствие в виде постройки или другого робота, робот меняет
направление движения, однако тенденция движения вправо сохраняется, так обеспечен обход препятствий. Таким образом, через некоторое время все роботы
оказываются у самой правой базы. Некоторые роботы могут попадать в "западни" - достаточно длинные участки, заканчивающиеся тупиком - так происходит
и в оригинальной игре. Робота можно выделить, щёлкнув по нему мышкой, тогда он будет обведён жёлтим прямоугольником, а в левом верхнем углу экрана будут
отображаться его координаты.
