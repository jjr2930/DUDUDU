﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchHeap<T> where T : IHeapItem<T>{

    T[] items;
    int currentItemCount;

    public BinarySearchHeap( int heapMaxSize)
    {
        items = new T[heapMaxSize];
    }

    public void Add(T newItem)
    {
        newItem.HeapIndex = currentItemCount;
        items[currentItemCount] = newItem;
        SortUp( newItem );
        currentItemCount++;
    }
    public T RemoveFirst()
    {
        T firstItem = items[0];
        currentItemCount--;
        items[0] = items[currentItemCount];
        items[0].HeapIndex = 0;
        SortDown( items[0] );
        return firstItem;
    }

    public void UpdateItem(T item)
    {
        SortUp( item ); 
    }
   

    public int Count
    {
        get
        {
            return currentItemCount;
        }
    }

    public bool Contains(T item)
    {
        return Equals( items[item.HeapIndex], item );
    }

    void SortDown(T item)
    {
        while ( true )
        {
            int childIndexLeft = item.HeapIndex * 2 + 1;
            int childindexRight = item.HeapIndex * 2 + 1;
            int swapIndex = 0;

            if ( childIndexLeft < currentItemCount )
            {
                swapIndex = childIndexLeft;
                if ( childindexRight < currentItemCount )
                {
                    if ( items[childIndexLeft].CompareTo( items[childindexRight] ) < 0 )
                    {
                        swapIndex = childindexRight;
                    }
                }
                if(item.CompareTo(items[swapIndex]) < 0)
                {
                    Swap( item, items[swapIndex] );
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    void SortUp(T item)
    {
        int parentIndex = (item.HeapIndex -1 )/2;
        for( ; ;)
        {
            T parentItem = items[parentIndex];
            if ( item.CompareTo( parentItem ) > 0 )
            {
                Swap( parentItem, item );
            }
            else
            {
                break;
            }
            parentIndex = ( item.HeapIndex - 1 ) / 2;
        }
    }

    void Swap (T itemA, T itemB)
    {
        int tempIndex = itemA.HeapIndex;
        items[itemA.HeapIndex] = itemB;
        items[itemB.HeapIndex] = itemA;
        itemA.HeapIndex = itemB.HeapIndex;
        itemB.HeapIndex = tempIndex;
    }
}

public interface  IHeapItem<T> : IComparable<T>
{
    int HeapIndex { get; set; }


}