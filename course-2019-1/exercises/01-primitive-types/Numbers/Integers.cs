﻿/*
    В данном файле вместо методов класса Integers стоят заглушки, которые просто генерируют исключение NotImplementedException.
    Задание: написать реализацию этих методов.
    
    Ты можешь протестировать свое решение сам, вызывая его из Main(), в том числе и в дебаггинг режиме.
    Либо воспользуйся тестами проекта Numbers.Tests. Тесты можно запускать из IDE - в студию такая возможность встроена (Test->Run->All tests), в других возможно есть плагины.
    Еще тесты можно запускать из консоли, используя .net CLI tools (для продвинутого использования скорее всего придется погуглить как пользоваться тулзой):
    
        $>cd ???/01-primitive-types/Numbers/
        $>dotnet test Numbers.Tests -v q

    Есть смысл сдавать только после того, как твое решение проходит все тесты. Можешь ради интереса так же посмотреть сам код в тестах.

    _Хозяйке на заметку_

    Как видите, ничего нигде не подчеркивается красным, и, если попробовать скомпилировать проект в текущем изначальном виде, никаких ошибок компиляции не будет. 
    Если же убрать генерацию исключений и оставить методы пустыми, появятся ошибки в стиле "метод ничего не возвращает". 

    Генерация исключения NotImplementedException в еще нереализованных кусках программы - это стандартный и "правильный" способ делать заглушки, оставляя реализацию "на потом".
    Например, если вы пишете прототип и сосредоточены на высокоуровневом алгоритме решения задачи, нежели на его непосредственной реализации.

    TL;DR
        * делать заглушки - нормально,
        * писать заглушки в стиле "вернуть хотя бы что-то лишь бы скомпилировалось" - не твой бро,
        * throw new NotImplementedException() - твой бро.

    Как думаешь, почему?
*/

using System;

namespace Numbers
{
    /// <summary>
    /// Класс методов для работы с целыми числами.
    /// </summary>
    public static class Integers
    {
        /// <summary>
        /// Возвращает половину максимального числа типа int.
        /// </summary>
        internal static int HalfIntMaxValue()
        {
            /*
                После C++ вы будете приятно удивлены какое умное в .Net автодополнение (IntelliSense).
                Особенно это касается связки Visual Studio + Resharper, используя которую, если просто набрать return и нажать пробел,
                    то в появившемся списке автодополнения одной из первых будет нужная тебе константа :)
            */
            return int.MaxValue / 2;
        }

        /// <summary>
        /// Возвращает куб заданного целого числа типа int.
        /// </summary>
        internal static int Cube( int x )
        {
            // не сомневайся, пиши. Тут без подвохов.
            return x * x * x;
        }

        /// <summary>
        /// Возвращает куб заданного целого числа типа int. Вычисление куба проводится в режиме проверки переполнения типа.
        /// </summary>
        internal static int CubeWithOverflowCheck( int x )
        {
            /*
                Если спал на лекции, то тут придется погуглить, сорри.
                И заодно подумай какой режим выставлен по умолчанию. Почему. И почему категорически нельзя надеяться на режим по умолчанию.
            */
            checked
            {
                return x * x * x;
            };
        }

        /// <summary>
        /// Возвращает куб заданного целого числа типа int. Вычисление куба проводится в режиме игнорирования переполнения типа.
        /// </summary>
        internal static int CubeWithoutOverflowCheck( int x )
        {
            // если сделал предыдущие, то с этим уже должно быть понятно.
            unchecked
            {
                return x * x * x;
            };
        }

        /// <summary>
        /// Конвертирует числовое значение в эквивалентное ему строковое представление.
        /// </summary>
        /// <param name="x">Числовое значение для конвертации.</param>
        /// <returns>Эквивалентное строковое представление числа.</returns>
        internal static string ToString( int x )
        {
            /*
                Возможно ты уже в курсе, что "эквивалентное ему строковое представление" - понятие очень расплывчатое, и существует
                огромная куча различных форматов вывода чисел: "123456789", "123 456 789", "0123456789" и т.п.
                Сейчас представим, что такой проблемы не существует, и выберем самый простой вариант, который использует какие-то дефолтные настройки.

                Подсказка: нужно воспользоваться методом, который есть у абсолютно всех объектов.
            */
            return x.ToString();
        }

        /// <summary>
        /// Конвертирует строковое представление числа в его 32-битное знаковое целочисленное представление.
        /// </summary>
        /// <param name="s">Строковое представление числа.</param>
        /// <returns>32-битное знаковое целочисленное представление числа.</returns>
        internal static int Parse( string s )
        {
            /*
                Продолжай идти простым путем -нужен метод, обратный методу ToString выше, который распарсит дефолтное строковое представление числа.
                Подсказка: у каждого примитивного типа есть набор статических методов, среди которых есть нужный.
            */
            return int.Parse( s );
        }

        /// <summary>
        /// Возвращает число в 10 раз большее заданного.
        /// </summary>
        internal static int TenTimes( int x )
        {
            /*
                Реализуй умножение числа на 10 без использования арифметических операций над числами.
                Воспользуйся реализованными выше методами ToString и Parse. И не думай ни о каких переполнениях - задача не на это :)
            */
            return Parse( ToString( x ) + "0" );
        }

        /// <summary>
        /// Конвертирует числовое значение в эквивалентное ему строковое представление в шестнадцатиричной системе счисления.
        /// </summary>
        /// <param name="x">Числовое значение для конвертации.</param>
        /// <returns>Эквивалентное строковое представление в шестнадцатиричной системе счисления.</returns>
        internal static string ToHexString( int x )
        {
            /*
                У метода ToString числовых типов есть перегрузка, которая принимает строку с одним из заданного набора форматов.
                В студии дается хорошая и понятная подсказка с этим набором форматов, в других же IDE скорее всего такого не будет, и придется погуглить форматы.
            */
            return x.ToString( "X" );
        }

        /*
            Закончил? Переходи в FloatNumbers.cs
        */
    }
}
