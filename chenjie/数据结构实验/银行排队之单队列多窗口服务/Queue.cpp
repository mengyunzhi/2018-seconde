#include "Queue.h"
#include <iostream>
using namespace std;
Queue::Queue()
{
	head = tail = NULL;
}

Queue::~Queue()
{
}

bool Queue::pop(Customer &empty)
{
	if (isEmpty()) {
		return false;
	}
	else {
		Node *p = head;
		empty = *p->data;
		head = head->next;
		delete p;
		return true;
	}
}

void Queue::push(Customer &newData)
{
	Node *p = new Node;
	*p->data = newData;
	p->next = NULL;
	if (isEmpty()) {
		head = tail = p;
	}
	else {
		tail->next = p;
		tail = p;
	}
}

bool Queue::isEmpty()
{
	return head == NULL;
}

Node::Node()
{
	data = new Customer();
}

Node::~Node()
{
	delete data;
}