#include "Car.h"
#include "Pavement.h"
#include <iostream>
using namespace std;

Pavement::Pavement()
{
	initialize();
}

Pavement::~Pavement()
{
}

// 初始化队列
void Pavement::initialize()
{
	//初始化头指针和尾指针
	front = new NODE;
	tail = new NODE;

	//将头尾连接

	front->data = new Car();
	tail->data = new Car();
	front->pre = tail->next = NULL;
	front->next = tail;
	tail->pre = front;

	//将元素个数置为0
	size = 0;
}

void Pavement::push(Car & newData)
{
	// 开辟新节点
	NODE *newElement = new NODE;
	newElement->data = new Car();

	//设置数据
	*newElement->data = newData;

	// 将新节点插入链表尾部
	tail->pre->next = newElement;
	newElement->next = tail;
	newElement->pre = tail->pre;
	tail->pre = newElement;

	// 元素个数增加
	size++;
}

bool Pavement::pop(Car & newData)
{
	if (isEmpty())
	{
		cout << "便道为空" << endl;
		return false;
	}
	else
	{
		NODE *temp = front->next;

		// 存储出队的数据
		newData = *temp->data;

		// 队头元素出队
		front->next = temp->next;
		temp->next->pre = front;
		delete(temp);

		// 元素个数减少
		size--;

		return true;
	}
}

void Pavement::display()
{
	NODE *temp = front->next;
	int i = 1;

	if (isEmpty())
	{
		cout << "### 便道为空" << endl;
		return;
	}

	while (temp != tail)
	{
		cout << "### 便道第" << i++ << "车的车牌号为：" << temp->data->getNumber() << endl;
		temp = temp->next;
	}
}

bool Pavement::isEmpty()
{
	return front->next == tail;
}

int Pavement::findPosition(int number)
{
	NODE *temp = front->next;
	int i = 1;
	while (temp != tail)
	{
		if (temp->data->getNumber() == number)
		{
			return i;
		}
		i++;
		temp = temp->next;
	}

	return 0;
}

bool Pavement::isInPavement(int number)
{
	NODE *temp = front->next;
	int i = 1;
	while (temp != tail)
	{
		if (number == temp->data->getNumber())
		{
			return true;
		}
		temp = temp->next;
	}

	return false;
	
}

Car Pavement::findByNumber(int number)
{
	NODE *temp = front->next;
	int i = 1;
	while (temp != tail)
	{
		if (number == temp->data->getNumber())
		{
			return *temp->data;
		}
		temp = temp->next;
	};
}

