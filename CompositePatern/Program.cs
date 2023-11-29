using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatern
{
    public interface IComponent
    {
        void Display();
    }
    public class Leaf : IComponent
    {
        private string _name;

        public Leaf(string name)
        {
            _name = name;
        }

        public void Display()
        {
            Console.WriteLine($"Leaf: {_name}");
        }
    }
    // Контейнер, представляющий раздел и содержащий другие компоненты
    public class Composite : IComponent
    {
        private List<IComponent> _children = new List<IComponent>();
        private string _name;

        public Composite(string name)
        {
            _name = name;
        }

        public void Add(IComponent component)
        {
            _children.Add(component);
        }

        public void Display()
        {
            Console.WriteLine($"Composite: {_name}");

            foreach (var child in _children)
            {
                child.Display();
            }
        }
    }
    class Program
    {
        static void Main()
        {
            // Создание компонентов
            var page1 = new Leaf("Page 1");
            var page2 = new Leaf("Page 2");
            var page3 = new Leaf("Page 3");

            var section1 = new Composite("Section 1");
            section1.Add(page1);
            section1.Add(page2);

            var section2 = new Composite("Section 2");
            section2.Add(page3);

            var siteMap = new Composite("Site Map");
            siteMap.Add(section1);
            siteMap.Add(section2);

            // Выводим иерархию
            siteMap.Display();
        }
    }

}
