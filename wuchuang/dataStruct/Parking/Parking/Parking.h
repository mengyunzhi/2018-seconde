#include "pch.h"
#include <iostream>
using namespace std;

class Parking {									//停车场类
	int car_number[3];							//栈，存放车牌号
	int top;									//栈顶指针
	int timein;									//进站时间
	int timeout;								//出站时间
public:
	Parking() {									//初始化栈
		top = -1;
	}
	void push(int x) {							//进栈
		if (top == 2) {
			cout << "上溢";
		}
		else {
			car_number[++top] = x;
		}
	}
	int pop() {									//出栈
		if (top == -1) {
			cout << "下溢";
			return 0;
		}
		else {
			return car_number[top--];
		}
	}
	int getTop() {								//返回栈顶指针
		return top;
	}
	int searchOrder(int i) {					//确定车辆在占中的位置
		for (int j = 0; j < 3; j++) {
			if (car_number[j] == i) {
				return j;
			}
		}
		return -1;
	}
	int getTimein() {							//获取进站时间
		return timein;
	}
	int getTimeout() {							//获取出站时间
		return timeout;
	}
	void cinTimein(int i) {						//输入进展时间
		timein = i;
	}
	void cinTimeout(int i) {					//输入出站时间
		timeout = i;
	}
};
class Car : public Parking						//车辆类，用来对停车场中的车进行操作
{
	int number;
public:
	void carNum(int i) {						//输入车牌号
		number = i;
	}
	int getNumber() {							//获取车牌号
		return number;
	}
};
class Stack1 {									//中间栈，用来暂时存放车辆
	int car_number[3];
	int top;
public:
	Stack1() {
		top = -1;
	}
	void push(int x) {
		if (top == 2) {
			cout << "溢出";
		}
		else {
			car_number[++top] = x;
		}
	}
	int pop() {
		if (top == -1) {
			cout << "下溢";
		}
		else {
			return car_number[top--];
		}
	}
	int getTop() {
		return top;
	}
};
typedef struct node {							//队列节点，首节点存放队列长度
	int data;									
	struct node * next;
}Node, *pNode;

class Road {									//便道类
	pNode head;									//首指针
	pNode tail;									//尾指针
public:
	Road () {									//队列初始化
		head = new Node;
		tail = head;
		head->next = NULL;
		head->data = 0;
	}
	void queueIn(int x) {						//入队列
		pNode p = new Node;
		p->data = x;
		p->next = tail->next;

		tail->next = p;
		tail = p;
		head->data++;
	}
	int queueOut() {							//出队列
		int x;
		if (head == tail)
		{
			cout << "队列已空";
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
	int isEmpty() {								//返回队列长，若为0则为空
		return head->data;
	}
};
class Cost {									//消费类
	int cost;
public:
	Cost() {
		cost = 4;								//基本消费单元为4元
	}
	int showCost(int i, int j) {				//输出消费金额
		return (i - j)*cost;
	}
};



