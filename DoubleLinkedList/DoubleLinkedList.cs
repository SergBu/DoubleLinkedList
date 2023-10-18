using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        DoubleNode<T> head;
        DoubleNode<T> tail;
        int count;

        public void Add(T data)
        {
            var node = new DoubleNode<T>(data);

            //добавляется первый элемент
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }

            count++;
        }

        public void AddFirst(T data)
        {
            var node = new DoubleNode<T>(data);

            //добавляется первый элемент
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }

            count++;
        }

        public bool Remove(T data)
        {
            DoubleNode<T> current = head;

            while (current != null)
            {
                if (!current.Data.Equals(data))
                {
                    current = current.Next;
                    continue;
                }

                //если current.Next не установлен значит узел последний
                //изменяем переменную tail

                //если узел в середине или в конце убираем узел current
                if (current.Previous != null)
                {
                    //если current.Next не установлен значит узел последний
                    //изменяем переменную tail
                    if (current.Next == null)
                    {
                        current.Previous.Next = null;
                        tail = current.Previous;
                    }
                    //если в середине
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    
                }
                //если удаляется первый элемент, то переустанавливаем значение head
                else
                {
                    //current.Next.Previous = default;
                    //head = current.Next;
                    //count--;

                    //если current.Next не установлен значит узел последний
                    //изменяем переменную tail
                    if (current.Next == null)
                    {
                        head = default;
                        tail = default;
                    }
                    //если в середине
                    else
                    {
                        current.Next.Previous = null;
                        head = current.Next;
                    }
                }

                count--;
                return true;
            }

            return false;
        }

        public bool Contains(T data)
        {
            DoubleNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                
                current = current.Next;
            }

            return false;
        }

        public int Count()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Clear()
        {
            head = default;
            tail = default;
            count = 0;
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoubleNode<T> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoubleNode<T> current = tail;

            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
