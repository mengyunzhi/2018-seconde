#include "pch.h"
#include <iostream>

using namespace std;

typedef struct node {							//队列节点，首节点存放队列长度
	char data;
	struct node * next;
}Node, *pNode;

class Track {									//便道类
	pNode head;									//首指针
	pNode tail;									//尾指针
public:
	Track() {									//队列初始化
		head = new Node;
		tail = head;
		head->next = NULL;
	}
	void queueIn(char x) {						//入队列
		pNode p = new Node;
		p->data = x;
		p->next = tail->next;

		tail->next = p;
		tail = p;
	}
	char queueOut() {							//出队列
		char x;
		if (head == tail)
		{
			cout << "队列已空";
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
class Stack {									//中间栈，用来暂时存放车辆
	char order[26];
	int top;
public:
	Stack() {
		top = -1;
	}
	void push(char x) {
		if (top == 26) {
			cout << "溢出";
		}
		else {
			order[++top] = x;
		}
	}
	char pop() {
		if (top == -1) {
			cout << "下溢";
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

