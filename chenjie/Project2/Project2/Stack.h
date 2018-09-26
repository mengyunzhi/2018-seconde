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
	Node<T> *top; //指向栈顶节点
};


template<class T>
LinkStack<T>::~LinkStack()
{
	//析构函数
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
	//栈是否满
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
	//添加元素X
	Node<T> *p = new Node<T>;
	p->data = x;
	p->link = top;
	top = p;
	return *this;
}

template<class T>
T LinkStack<T>::Top() const
{
	//返回栈顶元素
	if (!IsEmpty())
	{
		return top->data;
	}
}
template<class T>
LinkStack<T>& LinkStack<T>::Delete(T& x)
{
	//删除栈顶元素，并将其送入x
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