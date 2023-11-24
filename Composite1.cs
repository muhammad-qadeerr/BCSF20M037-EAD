using System;

namespace CompositePattern
{
    interface IComponent
    {
        void Operation();
    }


    class Leaf : IComponent
    {
        private string _name;
        public Leaf(string name)
        {
            this._name = name;
        }

        public void Operation()
        {
            Console.WriteLine(_name);
        }
    }

    class Composite : IComponent
    {
        public List<IComponent> components = new List<IComponent>();
        private string _name;
        public Composite(string name)
        {
            this._name = name;
        }
        public void Operation()
        {
            Console.WriteLine(_name);

            foreach(var component in components)
            {
                component.Operation();
            }

        }


    }

    class Composite1
    {
        static void Main(string[] args)
        {

            Leaf leaf1 = new Leaf("Leaf1");
            Leaf leaf2 = new Leaf("Leaf2");

            Composite composite1 = new Composite("Composite1");
            Composite composite2 = new Composite("Composite2");

            composite1.components.Add(composite2);
            composite1.components.Add(leaf1);

            composite2.components.Add(leaf2);

            composite1.Operation();





        }
    }


}




   

