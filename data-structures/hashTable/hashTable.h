# include <string>
# include "hashItem.h"

using namespace std;

class HashTable{
    public:
        HashTable(int size);

        void Add(string key, string value);
        void Exists(string key);
        string Get(string key);
        void Remove(string key);
        
        HashItem * _data;
        int Hash(string key);
    private:
        int _size;
        
};