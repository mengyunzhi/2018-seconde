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

// ��ʼ������
void Pavement::initialize()
{
	//��ʼ��ͷָ���βָ��
	front = new NODE;
	tail = new NODE;

	//��ͷβ����

	front->data = new Car();
	tail->data = new Car();
	front->pre = tail->next = NULL;
	front->next = tail;
	tail->pre = front;

	//��Ԫ�ظ�����Ϊ0
	size = 0;
}

void Pavement::push(Car & newData)
{
	// �����½ڵ�
	NODE *newElement = new NODE;
	newElement->data = new Car();

	//��������
	*newElement->data = newData;

	// ���½ڵ��������β��
	tail->pre->next = newElement;
	newElement->next = tail;
	newElement->pre = tail->pre;
	tail->pre = newElement;

	// Ԫ�ظ�������
	size++;
}

bool Pavement::pop(Car & newData)
{
	if (isEmpty())
	{
		cout << "���Ϊ��" << endl;
		return false;
	}
	else
	{
		NODE *temp = front->next;

		// �洢���ӵ�����
		newData = *temp->data;

		// ��ͷԪ�س���
		front->next = temp->next;
		temp->next->pre = front;
		delete(temp);

		// Ԫ�ظ�������
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
		cout << "### ���Ϊ��" << endl;
		return;
	}

	while (temp != tail)
	{
		cout << "### �����" << i++ << "���ĳ��ƺ�Ϊ��" << temp->data->getNumber() << endl;
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

