using namespace std;


class HashItem {
    public:
        string key;
        string value;

        HashItem() {}

        HashItem(string key, string value){
            this->key = key;
            this->value = value;
        }

        void SetDeletedKey(){
            key = GetDeletedKey();
        }

        void SetNullKey(){
            key = GetNullKey();
        }

        static string GetDeletedKey() { return "<DELETED>"; }
        static string GetNullKey() { return "<NULL>"; }
};