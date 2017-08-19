# include <string>
# include "hashItem.h"

using namespace std;

class HashTable{
    public:
        HashTable(int size);

        void Add(string key, string value);
        bool Exists(string key);
        string Get(string key);
        void Remove(string key);
        
    private:
        int _size, _capacity;
        HashItem * _data;

        int Hash(string key);
        void Doubling(int newCapacity);
        void Expand();

        static const double _shrinkAt = 0.25, _expandAt = 0.75;
};