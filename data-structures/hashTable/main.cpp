# include <iostream>
# include "hashTable.h"

using namespace std;

int main()
{
    HashTable test (9);
    // test._data[0] = "first";
    // test._data[1] = "sec";
    // test._data[2] = "third";
    // test._data[8] = "ninth";


    cout << "Kristupas: " << test.Hash("Kristupas") << endl;
    cout << "Filip: " << test.Hash("Filip") << endl;
    cout << "Thomas: " << test.Hash("Thomas") << endl;
    cout << "Kristupa: " << test.Hash("Kristupa") << endl;
    cout << "Lukas: " << test.Hash("Lukas") << endl;
    cout << "July: " << test.Hash("July") << endl;
    cout << "Jigsaw: " << test.Hash("Jigsaw") << endl;
    cout << "Tomahawk: " << test.Hash("Tomahawk") << endl;
    cout << "Squiglyface: " << test.Hash("Squiglyface") << endl;

    test.Add("Kristupas", "Kristupas1");
    test.Add("Filip", "Kristupas2");
    test.Add("Thomas", "Kristupas3");
    test.Add("Kristupa", "Kristupas4");
    test.Add("Lukas", "Kristupas6");
    test.Add("July", "Kristupas6");
    test.Add("Jigsaw", "Kristupas7");
    test.Add("Tomahawk", "Kristupas8");
    test.Add("Squiglyface", "Kristupas9");

    for(int i = 0; i < 9; i++)
    {
        cout << test._data[i].value << endl;
    }
}