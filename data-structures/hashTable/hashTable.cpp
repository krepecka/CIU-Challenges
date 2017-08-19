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

    hash = hash % _capacity;
    return hash;
}

void HashTable::Add(string key, string value)
{
    //double if the size is above certain level
    if (_size >= _capacity * _expandAt)
    {
        Doubling(_capacity * 2);
    }

    int index = Hash(key);
    cout << key << " key " << index << endl;
    while (_data[index].key != HashItem::GetNullKey() && _data[index].key != HashItem::GetDeletedKey())
    {
        index++;
        if (index >= _capacity)
        {
            index = 0;
        }
        cout << key << " more " << index << endl;
    }
    HashItem item(key, value);
    _data[index] = item;
    _size++;
}

string HashTable::Get(string key)
{
    int index = Hash(key);
    HashItem item;

    do
    {
        item = _data[index];
        index++;
        if (index >= _capacity)
        {
            index = 0;
        }
    } while (item.key != key && item.key != HashItem::GetNullKey());

    return item.value;
}

void HashTable::Remove(string key)
{
    if (_size <= _capacity * _shrinkAt)
    {
        Doubling(_capacity / 2);
    }

    int index = Hash(key);
    HashItem *item;

    int cycleCount = 0;
    do
    {
        item = &_data[index];
        index++;
        if (index >= _capacity)
        {
            index = 0;
        }
        cycleCount++;
    } while (item->key != key && item->key != HashItem::GetNullKey() && cycleCount < _size);

    //Only if we found the item
    if (cycleCount < _size)
    {
        _size--;
        item->SetDeletedKey();
    }
}

bool HashTable::Exists(string key)
{
    int index = Hash(key);
    HashItem item;

    do
    {
        item = _data[index];
        index++;
        if (index >= _capacity)
        {
            index = 0;
        }
    } while (item.key != key && item.key != HashItem::GetNullKey() && item.key != HashItem::GetDeletedKey());

    return item.key == key;
}

void HashTable::Doubling(int newCapacity)
{
    HashItem *oldData = _data;
    int oldCapacity = _capacity;
    _data = new HashItem[newCapacity];
    _capacity = newCapacity;
    _size = 0;

    for (int i = 0; i < _capacity; i++)
    {
        _data[i].SetNullKey();
    }

    for (int j = 0; j < oldCapacity; j++)
    {
        if (oldData[j].key != HashItem::GetNullKey() && oldData[j].key != HashItem::GetDeletedKey())
        {
            Add(oldData[j].key, oldData[j].value);
        }
    }
}