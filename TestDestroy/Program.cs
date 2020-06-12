using System;
using TestWebApplication;

namespace TestDestroy
{
    class Program
    {
        static void Main(string[] args)
        {
//==========================================Destroy=====================================================================
            //https://metanit.com/sharp/tutorial/8.2.php
            //see destructor ~Person() and Destroy() method in Person
            TestDestroyMethod();
            
            for (int i = 0; i < 100000; i++)
            {
                string str = new string("This loop forces GC collect garbage. 100_000 is enough for my laptop.");
            }
            // GC.Collect();
        }
        
        private static void TestDestroyMethod()
        {
            Person pp = new Person("Ted", "Neward", 46);// в данном случае после вызова GC.Collect() (или достаточно большого for) пойдет в деструктор ~Person, так как Finalize не подавлен в Destroy() 

            // аналог try with resources  в java
            // если использовать using и потом вызвать GC.Collect(), то в деструктор (~Person) не пойдет так как подавили Finilize метод в Dispose()
            // using (Person p = new Person("Ted", "Neward", 46)) // в данном случае вызывается метод Destroy() у Person (по аналогии с close() в java) 
            // {
            //     var pAge = p.Age;
            // }
        }
    }

}