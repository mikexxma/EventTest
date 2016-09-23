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
        
        public event PersonChanged ChangePerson;

        public void OnPersionChanged()
        {
            if (ChangePerson != null)
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
