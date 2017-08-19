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
            this->key = GetDeletedKey();
            this->value = "";
        }

        void SetNullKey(){
            key = GetNullKey();
            value = "";
        }

        static string GetDeletedKey() { return "<DELETED>"; }
        static string GetNullKey() { return "<NULL>"; }
};