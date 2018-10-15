#include <iostream>
using namespace std;
typedef int ElemType;
struct NodeType
{
	ElemType data;										//存放密码
	ElemType order;										//存放顺序
	NodeType *next;
};
class Clist
{
	NodeType *p;									//指向输出位序节点
	NodeType *q;									//指向p的前驱结点
	int length;
public:
	Clist()											//构造函数，创建首节点
	{
		p = new NodeType;
		p->next = p;
		length = 1;
	}

	void createBackward()							//创建链表，存入密码			
	{
		NodeType *r, *s;
		r = p;
		cout << "输入人数:" << endl;
		cin >> length;
		for (int i = 0; i < length; i++)
		{
			if (i == 0)								//存入第一个节点的密码
			{
				cout << "输入第1个人的密码:";
				cin >> p->data;
				p->order = i + 1;
			}
			else
			{
				s = new NodeType;						//依次存入剩下节点的密码
				cout << "输入第" << i + 1 << "个人的密码:";
				cin >> s->data;
				s->order = i + 1;
				s->next = r->next;
				r->next = s;
				r = r->next;
			}
		}
	}

	int getLength()									//获取链表的长度
	{
		return length;
	}

	int showOrder(int i)							//求出位序并返回
	{
		for (int j = 1; j < i; j++)
		{
			q = p;
			p = p->next;
		}
		return p->order;
	}

	int getData()									//获取输出位序的密码
	{
		return p->data;
	}

	void deleteNode() {								//删除输出位序的节点
		q->next = p->next;
		delete p;
		p = q->next;
		length--;
	}
};
