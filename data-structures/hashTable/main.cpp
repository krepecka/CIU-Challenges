# include <iostream>
# include "hashTable.h"

using namespace std;

int main()
{
    HashTable test (7);

    test.Add("Name", "Kristupas");
    test.Add("Surname", "Repecka");
    test.Add("Fruit", "Apple");
    test.Add("Drink", "Water");
    test.Add("Dog", "Rex");
    test.Add("Month", "July");
    test.Add("Day", "Friday");
    test.Add("Music", "Beautiful");
    test.Add("Horseface", "Arya");

    test.Remove("Name");
    test.Remove("Surname");
    test.Remove("Fruit");
    test.Remove("Drink");
    test.Remove("Dog");
    test.Remove("Month");
    test.Remove("Day");
    test.Remove("Music");

    cout << test.Get("Name") << endl;
    test.Remove("Dog");
    cout << test.Get("Dog") << endl;
    cout << test.Get("Music") << endl;
    cout << test.Get("Horseface") << endl;
    cout << test.Exists("Hsrs") << endl;

}