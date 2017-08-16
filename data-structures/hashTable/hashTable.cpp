# include <iostream>
# include "hashTable.h"

HashTable::HashTable(int size){
    _size = size;
    _data = new HashItem[size];
    for(int i = 0; i < size; i++){
        _data[i].key = HashItem::GetNullKey();
    }
}

// sdbm
int HashTable::Hash(string key){
    unsigned int hash = 0;

    for(int i = 0; i < key.length(); i++){
        hash = (int)key[i] + (hash << 6) + (hash << 16) - hash;
    }

    hash = hash % this->_size;
    return hash;
}

void HashTable::Add(string key, string value){

    //double if the size is above certain level

    int index = this.Hash(key);

    cout << key <<" first try " << index << endl;
    while(this._data[index].key != HashItem::GetNullKey()){
        if(index > this->_size){
            index = 0;
        }
        index++;
        cout << key << " more " << index << endl;
    }

    HashItem item (key, value);

    this->_data[index] = item;
}