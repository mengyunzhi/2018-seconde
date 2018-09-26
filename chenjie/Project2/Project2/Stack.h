#ifndef _LinkStack
#define _LinkStack
#include<iostream>
template<class T>class LinkStack;
template <class T>
class Node {
	friend LinkStack<T>;
private :
	T data;
	Node<T> *link;
};

template <class T>
class LinkStack {
public:
	LinkStack() { top = 0; }
	~LinkStack();
	bool IsEmpty() const { return top == 0; }
	bool IsFull() const;
	T Top() const;
	LinkStack<T>& Add(const T& x);
	LinkStack<T>& Delete(T& x);
private:
	Node<T> *top; //ָ��ջ���ڵ�
};


template<class T>
LinkStack<T>::~LinkStack()
{
	//��������
	Node<T> *next;
	while (top)
	{
		next = top->link;
		delete top;
		top = next;
	}
}

template<class T>
bool LinkStack<T>::IsFull() const
{
	//ջ�Ƿ���
	try
	{
		Node<T> *p = new Node<T>;
		delete p;
		return false;
	}
	catch (const std::exception&)
	{
		return true;
	}
}

template<class T>
LinkStack<T>& LinkStack<T>::Add(const T& x)
{
	//���Ԫ��X
	Node<T> *p = new Node<T>;
	p->data = x;
	p->link = top;
	top = p;
	return *this;
}

template<class T>
T LinkStack<T>::Top() const
{
	//����ջ��Ԫ��
	if (!IsEmpty())
	{
		return top->data;
	}
}
template<class T>
LinkStack<T>& LinkStack<T>::Delete(T& x)
{
	//ɾ��ջ��Ԫ�أ�����������x
	if (!IsEmpty())
	{
		x = top->data;
		Node<T> *p = top;
		top = top->link;
		delete p;
		return *this;
	}
}


#endif