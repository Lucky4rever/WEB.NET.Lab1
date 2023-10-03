using System;
using System.Collections;
using System.Collections.Generic;

public class CustomArray<T> : IEnumerable<T>
{
    private T[] _array;
    private int _startIndex;

    public CustomArray(int size, int startIndex)
    {
        if (size <= 0)
        {
            throw new ArgumentException("You should set size bigger than 0");
        }

        this._startIndex = startIndex;
        this._array = new T[size];
    }

    public CustomArray(T[] initialArray, int startIndex)
    {
        if (initialArray == null)
        {
            throw new ArgumentNullException("Selected nullable data");
        }

        this._startIndex = startIndex;
        this._array = initialArray;
    }

    public T this[int index]
    {
        get
        {
            if (!IsIndexValid(index))
            {
                throw new IndexOutOfRangeException("Out of range");
            }

            return this._array[index - this._startIndex];
        }
        set
        {
            if (!IsIndexValid(index))
            {
                throw new IndexOutOfRangeException("Out of range");
            }

            this._array[index - this._startIndex] = value;
        }
    }

    public int StartIndex => this._startIndex;
    public int Length => this._array.Length;
    public T[] Array => this._array;
    public int FirstIndex => this._startIndex;
    public int LastIndex => this._startIndex + this._array.Length - 1;

    public T[] ToStandardArray()
    {
        return this._array;
    }

    private bool IsIndexValid(int index)
    {
        return index >= this._startIndex && index < this._startIndex + this._array.Length;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this._array.Length; i++)
        {
            yield return this._array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
