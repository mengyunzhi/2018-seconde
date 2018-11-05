#include "pch.h"
#include <iostream>

using namespace std;
typedef struct node {							//���нڵ㣬�׽ڵ��Ŷ��г���
	int reach_time;
	int serve_time;
	int length;
	struct node * next;
}Node, *pNode;

class Road {									//�����
	pNode head;									//��ָ��
	pNode tail;									//βָ��
public:
	Road() {									//���г�ʼ��
		head = new Node;
		tail = head;
		head->next = NULL;
		head->length = 0;
	}
	void queueIn(int x, int y) {						//�����
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

	void queueOut() {							//������
		if (head == tail)
		{
			cout << "�����ѿ�";
		}
		pNode p = head->next;

		head->next = head->next->next;
		head->length--;
		if (head->length == 0) {
			tail = head;
		}
		delete p;
	}

	int isEmpty() {								//���ض��г�����Ϊ0��Ϊ��
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