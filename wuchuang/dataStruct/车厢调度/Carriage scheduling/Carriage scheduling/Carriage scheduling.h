#include "pch.h"
#include <iostream>

using namespace std;

typedef struct node {							//���нڵ㣬�׽ڵ��Ŷ��г���
	char data;
	struct node * next;
}Node, *pNode;

class Track {									//�����
	pNode head;									//��ָ��
	pNode tail;									//βָ��
public:
	Track() {									//���г�ʼ��
		head = new Node;
		tail = head;
		head->next = NULL;
	}
	void queueIn(char x) {						//�����
		pNode p = new Node;
		p->data = x;
		p->next = tail->next;

		tail->next = p;
		tail = p;
	}
	char queueOut() {							//������
		char x;
		if (head == tail)
		{
			cout << "�����ѿ�";
			return '0';
		}
		pNode p = head->next;
		x = p->data;

		head->next = head->next->next;
		if (head->next == NULL) {
			tail = head;
		}
		delete p;

		return x;
	}
	char getHeadelem() {
		return head->next->data;
	}
	int is_Empty() {
		if (head == tail)
			return 1;
		else
			return 0;
	}
};
class Stack {									//�м�ջ��������ʱ��ų���
	char order[26];
	int top;
public:
	Stack() {
		top = -1;
	}
	void push(char x) {
		if (top == 26) {
			cout << "���";
		}
		else {
			order[++top] = x;
		}
	}
	char pop() {
		if (top == -1) {
			cout << "����";
		}
		else {
			return order[top--];
		}
	}
	int getTop() {
		return top;
	}
	char getTopelem() {
		return order[top];
	}
};

