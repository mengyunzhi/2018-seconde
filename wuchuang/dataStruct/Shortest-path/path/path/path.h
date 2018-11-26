#include <iostream>
#include <queue>
#include<iomanip>
using namespace std;

typedef struct EdgeNode
{
	int adjvex;
	struct EdgeNode * next;
} EdgeNode;

//�����ڵ�ṹ��һ��data�����洢���ݣ�һ��firstedge������ָ��߱�ĵ�һ���ڵ�
typedef struct
{
	int tag;
	EdgeNode * firstedge;
} AdjList;
//�����adjList[15]��ʾ�Ҹ��������15�ĵ�λ��С��Ȼ��numVertex,numEdge��һ��ͼ�Ķ������ͱ���
class Graph
{
	AdjList adjList[15];
	int num_edge;
	int num_vertex;
public:
	Graph()
	{
		for (int i = 0; i < 15; i++)
		{
			adjList[i].firstedge = NULL;
			adjList[i].tag = 0;
		}
	}
	void add(int x, int y) {
		if (adjList[x - 1].firstedge == NULL)
		{
			EdgeNode *p;
			p = new EdgeNode;
			p->adjvex = y - 1;
			p->next = NULL;
			adjList[x - 1].firstedge = p;
		}
		else {
			EdgeNode *p , *q;
			p = adjList[x - 1].firstedge;
			while (p->next)
			{
				p = p->next;
			}
			q = new EdgeNode;
			q->adjvex = y - 1;
			q->next = NULL;
			p->next = q;
		}
		if (adjList[y - 1].firstedge == NULL)
		{
			EdgeNode *p;
			p = new EdgeNode;
			p->adjvex = x - 1;
			p->next = NULL;
			adjList[y - 1].firstedge = p;
		}
		else {
			EdgeNode *p, *q;
			p = adjList[y - 1].firstedge;
			while (p->next)
			{
				p = p->next;
			}
			q = new EdgeNode;
			q->adjvex = x - 1;
			q->next = NULL;
			p->next = q;
		}
	}
	void setEdge(int x)
	{
		num_edge = x;
	}
	void setVertex(int x)
	{
		num_vertex = x;
	}
	void showGraph() 
	{
		for (int i = 0; i < num_edge; i++)
		{
			EdgeNode *p;
			p = adjList[i].firstedge;
			while (p->next)
			{
				cout << p->adjvex;
				p = p->next;
			}
			cout << p->adjvex;
			cout << endl;
		}
	}

	void BL(int x)
	{
		double num[10];
		for (int i = 0; i < x; i++)
		{
			num[i] = 1;
		}
		queue<int>q;
		queue<int>r;
		for (int i = 0; i < num_vertex; i++)
		{
			int k = 0;
			EdgeNode *p;
			adjList[i].tag = 1;
			p = adjList[i].firstedge;
			while (p) {
				if (adjList[p->adjvex].tag == 0)
				{
					num[i]++;
					adjList[p->adjvex].tag = 1;
					q.push(p->adjvex);
				}
				if (!p->next)
				{
					break;
				}
				if (p->next)
				{
					p = p->next;
				}
			}

			k++;

			while (!q.empty() && k < 6)
			{
				p = adjList[q.front()].firstedge;
				q.pop();				
				while (p) {
					if (adjList[p->adjvex].tag == 0)
					{
						num[i]++;
						adjList[p->adjvex].tag = 1;
						r.push(p->adjvex);
					}
					if (!p->next)
					{
						break;
					}
					else p = p->next;
				}
				if (q.empty() && !r.empty())
				{
					while (!r.empty())
					{
						q.push(r.front());
						r.pop();
					}
					k++;
				}
			}
			for (int j = 0; j < num_vertex; j++)
			{
				adjList[j].tag = 0;
			}
			while (!q.empty())
			{
				q.pop();
			}
			while (!r.empty())
			{
				r.pop();
			}
		}
		for (int i = 0; i < x; i++)
		{
			double y;
			y = num[i] / x;
			y = y * 100;
			cout << i+1 << ": " << setiosflags(ios::fixed) << setprecision(2) << y << "%" << endl;
		}
	}
};