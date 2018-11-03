#pragma once
#include "Customer.h"

class Customer;
class Node
{
	Node();
	~Node();
private:
	Customer *data;
	Node *next;
	friend class Queue;
};
class Queue
{
public:
	Queue();
	~Queue();
	bool pop(Customer &);
	void push(Customer &);
	bool isEmpty();
private:
	Node *head;
	Node *tail;
};

