using namespace std;
#include <vector>

class Heap
{
  public:
    Heap();

    void insert(int item);
    int get_max();
    int get_size();
    bool is_empty();
    int extract_max();
    void remove(int index);

    void heapify(int * elements, int n);
    static void heap_sort(int * elements, int n);

    void print();
  private:
    void sift_up(int index);
    void sift_down(int index);  
    
    vector<int> elements;

};