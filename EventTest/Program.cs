using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public delegate void PersonChanged();
    class Person
    {
        private int age;
        private int height;
        private int weight;        
        public event PersonChanged ChangePerson;//其实就是一个委托 面向对象思想设计把委托封装在类里面
        public void OnPersionChanged()// 通过方法调用委托(参数就是方法)
        {
            if (ChangePerson != null)//判断方法有没有赋值 
            {
                ChangePerson();
            }
        }
        public void setAge(int mage)
        {
            age = mage;
            OnPersionChanged();
        }

        public int Age
        {
            get{ return age;}
            set { OnPersionChanged(); age = value;}
        }
       public int Height
       {
            get { return height; }
            set { OnPersionChanged(); height = value; }
       }
        public int Weight
        {
            get { return weight; }
            set { OnPersionChanged(); weight = value; }
        }
    }
    class EventTest
    {
        class Listenter
        {
            public Listenter(Person p1)
            {
                // Add "ListChanged" to the Changed event on "List".
                p1.ChangePerson += new PersonChanged(PChanged);
            }
            //用一个代理方法 来监听事件 然后再事件发生的时候做点什么
            private void PChanged()
            {
                Console.WriteLine("Hello person changed");
            }
        }
        public static void Main()
        {
            Person p = new Person();
            Listenter listenter = new Listenter(p);
            p.Age = 19;
            Console.ReadLine();
        }                
    }
}
