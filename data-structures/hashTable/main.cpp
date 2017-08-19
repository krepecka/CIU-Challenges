# include <iostream>
# include "hashTable.h"

using namespace std;

int main()
{
    HashTable test (9);

    test.Add("Name", "Kristupas");
    test.Add("Surname", "Repecka");
    test.Add("Fruit", "Apple");
    test.Add("Drink", "Water");
    test.Add("Dog", "Rex");
    test.Add("Month", "July");
    test.Add("Day", "Friday");
    test.Add("Music", "Beautiful");
    // test.Add("Horseface", "Arya");

    for(int i = 0; i < 13; i++)
    {
        cout << test._data[i].value << endl;
    }

    cout << test.Get("Name") << endl;
    test.Remove("Dog");
    cout << test.Get("Dog") << endl;
    cout << test.Get("Music") << endl;
    cout << test.Get("Horseface") << endl;

}