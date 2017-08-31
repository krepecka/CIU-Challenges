#include "heap.h"
#include <iostream>
#include <algorithm>

using namespace std;

Heap::Heap(){}

void Heap::print()
{
    for(int item : this->elements)
    {
        cout << item << " ";
    }
    cout << endl;
}

void Heap::insert(int item)
{
    this->elements.push_back(item);

    int lastIndex = this->elements.size() - 1;
    if(lastIndex > 0)
    {
        this->sift_up(lastIndex);
    }  
}

void Heap::sift_up(int elemIndex)
{
    int parentIndex = ((elemIndex + 1) / 2) - 1;

    if(this->elements[elemIndex] > this->elements[parentIndex] && parentIndex > -1)
    {
        int tmp = this->elements[parentIndex];
        this->elements[parentIndex] = this->elements[elemIndex];
        this->elements[elemIndex] = tmp;

        this->sift_up(parentIndex);
    }
    else
    {
        return;
    }
}

void Heap::sift_down(int elemIndex)
{
    int heapSize = this->elements.size();
    if( elemIndex >= heapSize || elemIndex < 0)
    {
        return;
    }

    int leftIndex = elemIndex * 2 + 1;
    int rightIndex = (leftIndex + 1 < heapSize) ? leftIndex + 1 : -1;
    int elem = this->elements[elemIndex];

    //there might be only left child
    if(leftIndex < heapSize)
    {
        int left = this->elements[leftIndex];
        int right = this->elements[rightIndex];
        
        if(elem < left && left > right)
        {
            this->elements[elemIndex] = left;
            this->elements[leftIndex] = elem;
            this->sift_down(leftIndex);
        }
        else if(elem < right)
        {
            this->elements[elemIndex] = right;
            this->elements[rightIndex] = elem;
            this->sift_down(rightIndex);
        }
    }
    else
    {
        return;
    }
}

int Heap::get_max()
{
    return this->elements.at(0);
}

int Heap::get_size()
{
    return this->elements.size();
}

bool Heap::is_empty()
{
    return this->elements.size() == 0;
}

int Heap::extract_max()
{
    int result = this->elements.at(0);
    this->elements.at(0) = this->elements.back();
    this->elements.erase(this->elements.begin() + (this->elements.size() - 1));

    this->sift_down(0);

    return result;
}

void Heap::remove(int index)
{
    this->elements.at(index) = this->elements.back();
    this->print();
    this->elements.erase(this->elements.begin() + (this->elements.size() - 1));
    this->sift_down(index);
}

void Heap::heapify(int * arr, int n)
{
    for(int i = 0; i < n; i++)
    {
        this->insert(arr[i]);
    }
}

void Heap::heap_sort(int * arr, int n)
{
    Heap result;
    result.heapify(arr, n);

    for(int i = 0; i < n; i++)
    {
        arr[i] = result.extract_max();
    }
}