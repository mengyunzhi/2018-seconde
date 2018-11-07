#include "pch.h"
#include <iostream>

using namespace std;
typedef struct node {							//队列节点，首节点存放队列长度
	int reach_time;
	int serve_time;
	int length;
	struct node * next;
}Node, *pNode;

class Road {									//便道类
	pNode head;									//首指针
	pNode tail;									//尾指针
public:
	Road() {									//队列初始化
		head = new Node;
		tail = head;
		head->next = NULL;
		head->length = 0;
	}
	void queueIn(int x, int y) {						//入队列
		pNode p = new Node;
		p->reach_time = x;
		p->serve_time = y;
		p->next = tail->next;

		tail->next = p;
		tail = p;
		head->length++;
	}
	
	int getQueuereach_time() {
		pNode p = head->next;
		return p->reach_time;
	}

	int getQueueserve_time() {
		pNode p = head->next;
		return p->serve_time;
	}

	void queueOut() {							//出队列
		if (head == tail)
		{
			cout << "队列已空";
		}
		pNode p = head->next;

		head->next = head->next->next;
		head->length--;
		if (head->length == 0) {
			tail = head;
		}
		delete p;
	}

	int isEmpty() {								//返回队列长，若为0则为空
		return head->length;
	}
};
class Serve
{
	int reach_time;
	int leave_time;
	int wait_time;
	int serve_time;
public:
	Serve()
	{
		reach_time = 0;
		wait_time = 0;
		serve_time = 0;
	}

	void setTime(int x, int y, int z) 
	{
		reach_time = x;
		serve_time = y;
		wait_time = z;
	}

	int getReach_time()
	{
		return reach_time;
	}

	int getServe_time()
	{
		return serve_time;
	}

	int getWait_time() 
	{
		return wait_time;
	}
};