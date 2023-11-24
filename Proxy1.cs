using System;

namespace ProxyPattern
{
    interface IService
    {
        void Login(int age);
    }

    class ConcreteService : IService
    {
        public void Login(int age)
        {
            Console.WriteLine($"You are logged in, your age is:  {age}.");
        }
    }

    class Proxy : IService
    {
        private IService service;

        public Proxy(IService service)
        {
            this.service = service;
        }

        public void Login(int age)
        {
            if (age < 18)
            {
                Console.WriteLine("You are too young!");
            }
            else
            {
                service.Login(age);
            }
        }

    }
    class Proxy1
    {
        static void Main(string[] args)
        {
            IService concreteService = new ConcreteService();

            IService proxy = new Proxy(concreteService);

            concreteService.Login(15);

            proxy.Login(15);

            concreteService.Login(18);

            proxy.Login(18);
        }
    }
        
    
    
    
   



}
