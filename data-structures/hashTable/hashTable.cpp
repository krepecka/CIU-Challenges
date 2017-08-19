#include <iostream>
#include "hashTable.h"

HashTable::HashTable(int initSize)
{
    _capacity = initSize;
    _size = 0;
    _data = new HashItem[initSize];
    for (int i = 0; i < initSize; i++)
    {
        _data[i].key = HashItem::GetNullKey();
    }
}

// sdbm
int HashTable::Hash(string key)
{
    unsigned int hash = 0;

    for (int i = 0; i < key.length(); i++)
    {
        hash = (int)key[i] + (hash << 6) + (hash << 16) - hash;
    }

    hash = hash % this->_capacity;
    return hash;
}

void HashTable::Add(string key, string value)
{

    //double if the size is above certain level

    int index = this->Hash(key);

    cout << key << " first try " << index << endl;
    // cout << "Deleted key " << HashItem::GetDeletedKey();
    while (this->_data[index].key != HashItem::GetNullKey() && this->_data[index].key != HashItem::GetDeletedKey())
    {
        index++;
        if (index >= this->_capacity)
        {
            index = 0;
        }
        cout << key << " more " << index << endl;
    }
    HashItem item(key, value);
    this->_data[index] = item;
    this->_size++;
    // cout << this->_size << " and capacity " << this->_capacity << endl;
}

string HashTable::Get(string key)
{
    int index = this->Hash(key);
    HashItem item;

    do
    {
        item = this->_data[index];
        index++;
        if (index >= this->_capacity)
        {
            index = 0;
        }
    } while (item.key != key && item.key != HashItem::GetNullKey());

    return item.value;
}

void HashTable::Remove(string key)
{
    int index = this->Hash(key);
    HashItem * item;
    do
    {
        item = &this->_data[index];
        index++;
        if (index >= this->_capacity)
        {
            index = 0;
        }
    } while (item->key != key && item->key != HashItem::GetNullKey());
    // cout << item.key << item.value << " item " << endl;
    item->SetDeletedKey();
    // item->value = "";

    for(int i = 0; i < this->_capacity; i++){
        cout << this->_data[i].key << " key " << this->_data[i].value << " value" << endl; 
    }
}