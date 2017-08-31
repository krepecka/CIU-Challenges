#include <iostream>
#include <cmath>
#include "heap.h"

using namespace std;

int main()
{
    Heap myHeap;

    cout << "is empty: " << myHeap.is_empty() << endl;

    myHeap.insert(1);
    myHeap.insert(2);
    myHeap.insert(3);
    myHeap.insert(4);
    myHeap.insert(5);
    myHeap.insert(6);
    myHeap.insert(7);
    myHeap.insert(8);
    myHeap.insert(9);
    myHeap.insert(10);
    myHeap.insert(11);
    myHeap.insert(12);
    myHeap.insert(7);

    myHeap.print();

    cout << "max: " << myHeap.get_max() << endl;
    cout << "size: " << myHeap.get_size() << endl;
    cout << "is empty: " << myHeap.is_empty() << endl;

    cout << "extract max " << myHeap.extract_max() << endl;
    myHeap.print();

    cout << "remove at index 4" << endl;
    myHeap.remove(4);
    myHeap.print();

    int test[9] = {7, 5, 3, 2, 9, 8, 1, 4, 6};

    cout << "Heap sort: " <<endl;
    myHeap.heap_sort(test, 9);

    for(int i = 0; i < 9; i++)
    {
        cout << test[i] << " ";
    }
    cout << endl;
}