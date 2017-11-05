using System;
using System.Collections;
using System.Collections.Generic;

namespace zad2
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int size;
        public int count = 0;


        public int Count => count;

        public GenericList()
        {
            _internalStorage = new X[4];
            size = 4;
        }
        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                System.Console.WriteLine("Size can not be negative");
                return;
            }
            _internalStorage = new X[initialSize];
            size = initialSize;
        }


        public void Add(X item)
        {
            if (count >= size)
            {
                size = size * 2;
                Array.Resize(ref _internalStorage, size);
                _internalStorage[count] = item;
                count++;
                //Console.WriteLine("IS {0}",count);
            }
            else
            {
                _internalStorage[count] = item;
                //Console.WriteLine("BUU {0}",count);

                count++;
            }
        }

        public void Clear()
        {
            count = 0;
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
        }

        public bool Contains(X item)
        {
            bool contains = false;
            for (int i = 0; i < count; i++)
            {
                if (Object.Equals(_internalStorage[i], item))
                {
                    contains = true;
                    return true;
                }
            }
            return contains;
        }

        public X GetElement(int index)
        {
            if (index >= size)
            {
                throw new IndexOutOfRangeException();

            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(X item)
        {
            if (Contains(item))
            {
                for (int i = 0; i < size; i++)
                {
                    if (_internalStorage[i].Equals(item))
                    {
                        return i;
                    }

                    continue;
                }
                return -1;


            }
            else
            {

                return -1;
            }
        }

        public bool Remove(X item)
        {
            if (Contains(item))
            {

                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (!(Object.Equals(_internalStorage[i], item)))
                    {
                        continue;
                    }
                    else
                    {

                        RemoveAt(i);
                        return true;


                    }

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > _internalStorage.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                count = count - 1;
                var newArray = new X[_internalStorage.Length - 1];
                int j = 0;
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (i == index) continue;
                    newArray[j] = _internalStorage[i];
                    j++;
                }
                for (int k = 0; k < newArray.Length; k++)
                {
                    Console.WriteLine("K {0}", newArray[k]);
                    _internalStorage[k] = newArray[k];
                }
                return true;
            }
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
    public class GenericListEnumerator<X> : IEnumerator<X>
    {

        private int position = -1;
        private GenericList<X> genericList;



        public GenericListEnumerator(GenericList<X> genericList)
        {
            this.genericList = genericList;
        }

        public X Current
        {
            get
            {
                try
                {
                    return genericList.GetElement(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        void IDisposable.Dispose() { }

        public bool MoveNext()
        {
            position++;
            return (position < genericList.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}