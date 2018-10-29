#include "Track1.h"
Track1::Track1()
{
	head = tail = NULL;
	size = 0;
}


Track1::~Track1()
{
}

bool Track1::pop(char &empty)
{
	if (isEmpty()) {
		return false;
	} else {
		Node *p = head;
		empty = p->data;
		head = head->next;
		size--;
		delete p;
		return true;
	}
}

bool Track1::push(char &newData)
{
	Node *p = new Node;
	p->data = newData;
	p->next = NULL;
	if (isEmpty()) {
		head = tail = p;
	} else {
		tail->next = p;
		tail = p;
	}
	size++;
	return true;
}

void Track1::disPlay()
{
	if (isEmpty())
	{
		cout << "¹ìµÀÎª¿Õ" << endl;
	}
	Node *p = head;
	while (p)
	{
		switch (p->data)
		{
		case '+': {cout << "1-2"<<endl; break; }
		case '-': {cout << "1-3"<<endl; break; }
		case '*': {cout << "3-2"<<endl; break; }
		default:
			break;
		}
		p = p->next;
	}
	cout << endl;
}

bool Track1::isEmpty()
{
	return head == NULL;
}

bool Track1::isHeadEqualto(char data)
{
	return data == head->data;
}

bool Track1::toTrack2(Track2 &track2)
{
	char temp;
	if (pop(temp) && track2.push(temp)) {
		return true;
	}
	else return false;
}

bool Track1::toTrack3(Track3 &track3)
{
	char temp;
	if (pop(temp) && track3.push(temp)) {
		return true;
	}
	else return false;
}

char Track1::getHeadValue()
{
	return head->data;
}

int Track1::getSize()
{
	return size;
}
