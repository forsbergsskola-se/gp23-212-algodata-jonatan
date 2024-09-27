#include <iostream>
#include <vector>

template<typename T>
class TurboBinarySearchTree {
private:
    struct Node {
        T value;
        Node* left;
        Node* right;

        Node(T val) : value(val), left(nullptr), right(nullptr) {}
    };

    Node* root;

    Node* insertRec(Node* node, T value) {
        if (node == nullptr) {
            return new Node(value);
        }

        if (value < node->value) {
            node->left = insertRec(node->left, value);
        } else if (value > node->value) {
            node->right = insertRec(node->right, value);
        }

        return node;
    }

    bool searchRec(Node* node, T value) {
        if (node == nullptr) {
            return false;
        }

        if (node->value == value) {
            return true;
        }

        if (value < node->value) {
            return searchRec(node->left, value);
        } else {
            return searchRec(node->right, value);
        }
    }

    Node* deleteRec(Node* node, T value, bool& found) {
        if (node == nullptr) {
            return node;
        }

        if (value < node->value) {
            node->left = deleteRec(node->left, value, found);
        } else if (value > node->value) {
            node->right = deleteRec(node->right, value, found);
        } else {
            found = true;

            if (node->left == nullptr) {
                Node* temp = node->right;
                delete node;
                return temp;
            } else if (node->right == nullptr) {
                Node* temp = node->left;
                delete node;
                return temp;
            }

            node->value = minValue(node->right);
            node->right = deleteRec(node->right, node->value, found);
        }

        return node;
    }

    T minValue(Node* node) {
        T minVal = node->value;
        while (node->left != nullptr) {
            minVal = node->left->value;
            node = node->left;
        }
        return minVal;
    }

    void inOrderRec(Node* node, std::vector<T>& vec) {
        if (node != nullptr) {
            inOrderRec(node->left, vec);
            vec.push_back(node->value);
            inOrderRec(node->right, vec);
        }
    }

public:
    TurboBinarySearchTree() : root(nullptr) {}

    void Insert(T value) {
        root = insertRec(root, value);
    }

    bool Search(T value) {
        return searchRec(root, value);
    }

    bool Delete(T value) {
        bool found = false;
        root = deleteRec(root, value, found);
        return found;
    }

    std::vector<T> InOrderTraversal() {
        std::vector<T> result;
        inOrderRec(root, result);
        return result;
    }
};

int main()
{
    TurboBinarySearchTree<int> tree;

    // Fill the tree with even numbers
    for (int i = 0; i < 1000000; i += 2) {
        tree.Insert(i);
    }

    std::cout << "Found 50000: " << tree.Search(50000) << std::endl; // should return true
    std::cout << "Deleted 50000: " << tree.Delete(50000) << std::endl; // should return true
    std::cout << "Found 50000: " << tree.Search(50000) << std::endl; // should return false
    std::cout << "Found 50001: " << tree.Search(50001) << std::endl; // should return false
    std::cout << "Deleted 50001: " << tree.Delete(50001) << std::endl; // should return false
    std::cout << "Found 50001: " << tree.Search(50001) << std::endl;
}
