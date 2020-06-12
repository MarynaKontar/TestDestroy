﻿using System;

namespace TestWebApplication
{
    public class Person: IDisposable
    {
        public string FirstName { get; set; } 
        
        public string LastName { get; set; }
        
        public int Age { get; set; } 

        public Person(string fn, string ln, int a)
        {
            this.FirstName = fn;
            this.LastName = ln;
            this.Age = a;
        }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, " +
                   $"{nameof(LastName)}: {LastName}, " +
                   $"{nameof(Age)}: {Age}";
        }

//=====================================DESTRUCTOR=======================================================================        
        //Освобождение неуправляемых ресурсов подразумевает реализацию одного из двух механизмов:
        //Создание деструктора
        //Реализация классом интерфейса System.IDisposable
        
        //https://www.c-sharpcorner.com/article/expression-bodied-members/
        // DESTRUCTOR implemented using Expression Bodied  
        // Expression or right side followed with => must be valid and should be one statement  
        // Only assignment, call, increment, decrement, and new object expression can be used as a statement  
        // This feature can only be used in C# 7.0 or onwards.
        //https://metanit.com/sharp/tutorial/8.2.php

        private bool disposed = false;
 
        // реализация интерфейса IDisposable.
        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }
 
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    Console.WriteLine("Releases the managed resources");
                    Console.Beep();
                }
                // освобождаем неуправляемые объекты
                Console.WriteLine("Releases the unmanaged resources");
                Console.Beep(); 
                Console.Beep();
                disposed = true;
            }
        }
 
        // Деструктор (компилятор переделывает его в Finalize метод)
        ~Person()
        {
            Dispose (false); // если не вызывать метод Destroy(), то все равно вызовется этот деструктор, если память будет сильно перегружена, и тогда освободятся все ресурсы (если здесь будет true) или только неуправляемые (если здесь будет false). !!! Надо подумать, когда буду использовать реальные ресурсы
            
            // https://metanit.com/sharp/tutorial/8.2.php
            //При вызове деструктора в качестве параметра disposing передается значение false, чтобы избежать очистки
            //управляемых ресурсов, так как мы не можем быть уверенными в их состоянии, что они до сих пор находятся
            //в памяти. И в этом случае остается полагаться на деструкторы этих ресурсов
        }
    }
}