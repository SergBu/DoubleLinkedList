using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    //класс узла
    public class DoubleNode<T>
    {
        //каждый узел хранит ссылку на следующий и предидущий узел
        public T Data;
        public DoubleNode(T data)
        {
            Data = data;
        }
        public DoubleNode<T> Previous;
        public DoubleNode<T> Next;
    }
}
