#include "pch.h"
#include <iostream>
using namespace std;

class Parking {									//ͣ������
	int car_number[3];							//ջ����ų��ƺ�
	int top;									//ջ��ָ��
	int timein;									//��վʱ��
	int timeout;								//��վʱ��
public:
	Parking() {									//��ʼ��ջ
		top = -1;
	}
	void push(int x) {							//��ջ
		if (top == 2) {
			cout << "����";
		}
		else {
			car_number[++top] = x;
		}
	}
	int pop() {									//��ջ
		if (top == -1) {
			cout << "����";
			return 0;
		}
		else {
			return car_number[top--];
		}
	}
	int getTop() {								//����ջ��ָ��
		return top;
	}
	int searchOrder(int i) {					//ȷ��������ռ�е�λ��
		for (int j = 0; j < 3; j++) {
			if (car_number[j] == i) {
				return j;
			}
		}
		return -1;
	}
	int getTimein() {							//��ȡ��վʱ��
		return timein;
	}
	int getTimeout() {							//��ȡ��վʱ��
		return timeout;
	}
	void cinTimein(int i) {						//�����չʱ��
		timein = i;
	}
	void cinTimeout(int i) {					//�����վʱ��
		timeout = i;
	}
};
class Car : public Parking						//�����࣬������ͣ�����еĳ����в���
{
	int number;
public:
	void carNum(int i) {						//���복�ƺ�
		number = i;
	}
	int getNumber() {							//��ȡ���ƺ�
		return number;
	}
};
class Stack1 {									//�м�ջ��������ʱ��ų���
	int car_number[3];
	int top;
public:
	Stack1() {
		top = -1;
	}
	void push(int x) {
		if (top == 2) {
			cout << "���";
		}
		else {
			car_number[++top] = x;
		}
	}
	int pop() {
		if (top == -1) {
			cout << "����";
		}
		else {
			return car_number[top--];
		}
	}
	int getTop() {
		return top;
	}
};
typedef struct node {							//���нڵ㣬�׽ڵ��Ŷ��г���
	int data;									
	struct node * next;
}Node, *pNode;

class Road {									//�����
	pNode head;									//��ָ��
	pNode tail;									//βָ��
public:
	Road () {									//���г�ʼ��
		head = new Node;
		tail = head;
		head->next = NULL;
		head->data = 0;
	}
	void queueIn(int x) {						//�����
		pNode p = new Node;
		p->data = x;
		p->next = tail->next;

		tail->next = p;
		tail = p;
		head->data++;
	}
	int queueOut() {							//������
		int x;
		if (head == tail)
		{
			cout << "�����ѿ�";
			return 0;
		}
		pNode p = head->next;
		x = p->data;

		head->next = head->next->next;
		head->data--;
		if (head->data == 0) {
			tail = head;
		}
		delete p;

		return x;
	}
	int isEmpty() {								//���ض��г�����Ϊ0��Ϊ��
		return head->data;
	}
};
class Cost {									//������
	int cost;
public:
	Cost() {
		cost = 4;								//�������ѵ�ԪΪ4Ԫ
	}
	int showCost(int i, int j) {				//������ѽ��
		return (i - j)*cost;
	}
};



