using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mouse mouse = new Mouse();
            RightClick rightClick = new RightClick();
            LeftClick leftClick = new LeftClick();  
            MiddleButton middleButton = new MiddleButton();

            mouse.AddComponent(middleButton);
            mouse.AddComponent(leftClick);
            mouse.AddComponent(rightClick);

            InputUnit inputUnit = new InputUnit();   
            KeyBoard keyBoard = new KeyBoard();
            
            inputUnit.AddComponent(keyBoard);
            inputUnit.AddComponent(mouse);
            inputUnit.DoWork();
        }
    }

    interface IComponent
    {
        void DoWork();
    }

    interface ILeaf : IComponent
    {
    }

    interface IComposite : IComponent
    {
        void AddComponent(IComponent component);
    }

    class RightClick : ILeaf
    {
        public void DoWork()
        {
            Console.WriteLine("Right click is working.");
        }
    }

    class LeftClick : ILeaf
    {
        public void DoWork()
        {
            Console.WriteLine("Left click is working.");
        }
    }

    class MiddleButton : ILeaf
    {
        public void DoWork()
        {
            Console.WriteLine("Middle button is working.");
        }
    }

    class Mouse : IComposite
    {
        private List<IComponent> components = new List<IComponent>();
        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void DoWork() //composit altındaki göervleri de yapmalı
        {
            Console.WriteLine("SubComposite : ");
            Console.WriteLine("Mouse is working.");
            Console.WriteLine("******************");

            foreach (IComponent component in components)
            {
                Console.WriteLine("Composite Mouse's Leaf : ");
                component.DoWork();
            }

        } 
    }

    class KeyBoard : ILeaf
    {
        public void DoWork()
        {
            Console.WriteLine("Keyboard is working.");
        }
    }

    class InputUnit : IComposite
    {
        private List<IComponent> components = new List<IComponent>();
        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void DoWork()
        {
            Console.WriteLine("Composite : ");
            Console.WriteLine("InputUnit is working.");
            Console.WriteLine("******************");

            foreach (IComponent component in components)
            {
                Console.WriteLine("Composite InputUnit's Leaf : ");
                component.DoWork();
            }
        }
    }
}

/*Yorum satırı ile ağaç yapısının gösterimi                   
           InputUnit                
            *       *                
        Keyboard  Mouse         
                  * * *
                 *******  
                 *  *  *
             Right  Middle   Left
*/

